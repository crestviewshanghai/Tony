using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Specialized;

public partial class Alipay_Notify : MojoCube.Api.UI.WebPage
{
    public static string GetMD5(string s)
    {
        /// <summary>
        /// 与ASP兼容的MD5加密算法
        /// </summary>

        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] t = md5.ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(s));
        StringBuilder sb = new StringBuilder(32);
        for (int i = 0; i < t.Length; i++)
        {
            sb.Append(t[i].ToString("x").PadLeft(2, '0'));
        }
        return sb.ToString();
    }

    public static string[] BubbleSort(string[] r)
    {
        /// <summary>
        /// 冒泡排序法
        /// </summary>

        int i, j; //交换标志 
        string temp;
        bool exchange;

        for (i = 0; i < r.Length; i++) //最多做R.Length-1趟排序 
        {
            exchange = false; //本趟排序开始前，交换标志应为假

            for (j = r.Length - 2; j >= i; j--)
            {
                if (System.String.CompareOrdinal(r[j + 1], r[j]) < 0)　//交换条件
                {
                    temp = r[j + 1];
                    r[j + 1] = r[j];
                    r[j] = temp;

                    exchange = true; //发生了交换，故将交换标志置为真 
                }
            }

            if (!exchange) //本趟排序未发生交换，提前终止算法 
            {
                break;
            }

        }
        return r;
    }

    //获取远程服务器ATN结果
    public String Get_Http(String a_strUrl, int timeout)
    {
        string strResult;
        try
        {

            HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(a_strUrl);
            myReq.Timeout = timeout;
            HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
            Stream myStream = HttpWResp.GetResponseStream();
            StreamReader sr = new StreamReader(myStream, Encoding.Default);
            StringBuilder strBuilder = new StringBuilder();
            while (-1 != sr.Peek())
            {
                strBuilder.Append(sr.ReadLine());
            }

            strResult = strBuilder.ToString();
        }
        catch (Exception exp)
        {
            strResult = "错误：" + exp.Message;
        }

        return strResult;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //*****************************************************************************************
        ///当不知道https的时候，请使用http
        //string alipayNotifyURL = "https://www.alipay.com/cooperate/gateway.do?";
        string alipayNotifyURL = "http://notify.alipay.com/trade/notify_query.do?";

        MojoCube.Web.Payment.List payment = new MojoCube.Web.Payment.List();
        payment.GetDataByType(0);

        string partner = payment.PartnerID; 		//*********partner合作伙伴id（必须填写）
        string key = payment.KeyCode; //************partner 的对应交易安全校验码（必须填写）

        //alipayNotifyURL = alipayNotifyURL + "service=notify_verify" + "&partner=" + partner + "&notify_id=" + Request.Form["notify_id"];
        alipayNotifyURL = alipayNotifyURL + "partner=" + partner + "&notify_id=" + Request.Form["notify_id"];

        //获取支付宝ATN返回结果，true是正确的订单信息，false 是无效的
        string responseTxt = Get_Http(alipayNotifyURL, 120000);

        //****************************************************************************************
        int i;
        NameValueCollection coll;
        //Load Form variables into NameValueCollection variable.
        coll = Request.Form;

        // Get names of all forms into a string array.
        String[] requestarr = coll.AllKeys;

        //进行排序；
        string[] Sortedstr = BubbleSort(requestarr);

        //for (i = 0; i < Sortedstr.Length; i++)
        //{
        //  Response.Write("Form: " + Sortedstr[i] + "=" + Request.Form[Sortedstr[i]] + "<br>");
        //}

        //构造待md5摘要字符串；
        string prestr = "";
        for (i = 0; i < Sortedstr.Length; i++)
        {
            if (Request.Form[Sortedstr[i]] != "" && Sortedstr[i] != "sign" && Sortedstr[i] != "sign_type")
            {
                if (i == Sortedstr.Length - 1)
                {
                    prestr = prestr + Sortedstr[i] + "=" + Request.Form[Sortedstr[i]];
                }
                else
                {
                    prestr = prestr + Sortedstr[i] + "=" + Request.Form[Sortedstr[i]] + "&";
                }
            }

        }
        prestr = prestr + key;

        string mysign = GetMD5(prestr);//生成MD5摘要
        string sign = Request.Form["sign"];//签名
        string business = Request.Form["seller_email"].ToString();//收款方帐号ok
        string item_name = Request.Form["subject"].ToString();//商品名ok
        string ordersn = Request.Form["out_trade_no"].ToString();//订单号ok
        string username = Request.Form["receive_name"].ToString();
        string ppPrice = Request.Form["price"].ToString();//金额ok

        MojoCube.Web.Order.List order = new MojoCube.Web.Order.List();
        order.GetData(ordersn);

        if (order.pk_Order > 0)
        {
            if (mysign != sign)
            {
                return;
            }

            if (!MojoCube.Web.Sql.IsExist("Order_Log", "fk_Order", order.pk_Order, "TransStatus='" + responseTxt + "'"))
            {
                bool isSuccess = false;

                if (responseTxt == "true")
                {
                    isSuccess = true;
                }

                MojoCube.Web.Order.Log log = new MojoCube.Web.Order.Log();
                log.Number = MojoCube.Api.Text.Function.DateTimeString(true);
                log.OrderNumber = order.OrderNumber;
                log.fk_Order = order.pk_Order;
                log.fk_Member = order.fk_Member;
                log.TypeID = 0;
                log.StatusID = 0;
                log.Title = string.Empty;
                log.Description = order.Description;
                log.Amount = order.Amount;
                log.AppID = string.Empty;
                log.TransStatus = responseTxt;
                if (isSuccess)
                {
                    log.TransName = "支付成功";
                    log.ResponseMsg = "交易成功";
                }
                else
                {
                    log.TransName = "支付失败";
                    log.ResponseMsg = "交易失败";
                }
                log.ChannelType = "支付宝";
                log.ResponseCode = responseTxt;
                log.OrderStartTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                log.OrderAmt = ppPrice;
                log.OrderTimeOut = "0";
                log.OrderType = "普通消费";
                log.DeviceType = "Web";
                log.ResponseTime = log.OrderStartTime;
                log.CurrencyType = "RMB";
                log.Result = sign + "|" + business + "|" + item_name + "|" + ordersn + "|" + username + "|" + ppPrice;
                log.CreateDate = DateTime.Now.ToString();
                log.InsertData();

                //支付成功
                if (isSuccess)
                {
                    //修改订单状态
                    order.StatusID = 1;
                    order.fk_Payment = 1;
                    order.PaymentDate = DateTime.Now.ToString();
                    order.UpdateData(order.pk_Order);

                    Response.Write("支付成功！");     //返回给支付宝消息，成功
                    Response.Write("<br>------------------" + Request.Form["body"]);
                }
                else
                {
                    Response.Write("支付失败，请与商家联系！");
                    Response.Write("<br>------------------" + Request.Form["body"]);
                }
            }
        }
    }
}