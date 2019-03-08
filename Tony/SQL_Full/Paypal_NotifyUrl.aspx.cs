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
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

public partial class Paypal_NotifyUrl : MojoCube.Api.UI.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MojoCube.Web.Payment.List payment = new MojoCube.Web.Payment.List();
        payment.GetDataByType(1);

        string strUrl = payment.Gateway;
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strUrl);

        // Set values for the request back
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";
        byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
        string strRequest = Encoding.ASCII.GetString(param);
        strRequest += "&cmd=_notify-validate";
        req.ContentLength = strRequest.Length;

        //for proxy
        //WebProxy proxy = new WebProxy(new Uri("http://url:port#"));
        //req.Proxy = proxy;

        //Send the request to PayPal and get the response
        StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
        streamOut.Write(strRequest);
        streamOut.Close();
        StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
        string responseTxt = streamIn.ReadToEnd();
        streamIn.Close();

        string business = GetString("business");//收款方帐号ok
        string item_name = GetString("item_name");//商品名ok
        string ordersn = GetString("item_number");//订单号ok
        string username = GetString("username");
        string txnid = GetString("txn_id").ToString();//ok
        string ppStatus = GetString("payment_status").ToString();//状态 ok//成功返回：Completed
        string ppDate = GetString("payment_date").ToString();//paypal服务器支付时间ok
        string ppPrice = GetString("mc_gross").ToString();//金额ok

        MojoCube.Web.Order.List order = new MojoCube.Web.Order.List();
        order.GetData(ordersn);

        if (order.pk_Order > 0)
        {
            if (responseTxt != "VERIFIED")
            {
                return;
            }

            if (!MojoCube.Web.Sql.IsExist("Order_Log", "fk_Order", order.pk_Order, "TransStatus='" + ppStatus + "'"))
            {
                bool isSuccess = false;

                if (ppStatus == "Completed")
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
                log.TransStatus = ppStatus;
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
                log.ChannelType = "Paypal";
                log.ResponseCode = responseTxt;
                log.OrderStartTime = ppDate;
                log.OrderAmt = ppPrice;
                log.OrderTimeOut = "0";
                log.OrderType = "普通消费";
                log.DeviceType = "Web";
                log.ResponseTime = log.OrderStartTime;
                log.CurrencyType = "RMB";
                log.Result = business + "|" + item_name + "|" + ordersn + "|" + username + "|" + txnid + "|" + ppStatus + "|" + ppDate + "|" + ppPrice;
                log.CreateDate = DateTime.Now.ToString();
                log.InsertData();

                //支付成功
                if (isSuccess)
                {
                    //修改订单状态
                    order.StatusID = 1;
                    order.fk_Payment = 2;
                    order.PaymentDate = DateTime.Now.ToString();
                    order.UpdateData(order.pk_Order);
                }
            }
        }
    }

    private string GetString(string para)
    {
        if (HttpContext.Current.Request.RequestType.ToLower().Equals("get"))
        {
            return GetQueryString(para);
        }
        return GetFormString(para);
    }

    private string GetQueryString(string para)
    {
        string queryString = "";
        if (HttpContext.Current.Request.QueryString[para] != null)
        {
            queryString = HttpContext.Current.Request.QueryString[para].ToString();
        }
        else
        {
            queryString = "";
        }
        return InputTexts(queryString.Trim());
    }

    public string GetFormString(string para)
    {
        string formString = "";
        if (HttpContext.Current.Request.Form[para] != null)
        {
            formString = HttpContext.Current.Request.Form[para].ToString();
        }
        else
        {
            formString = "";
        }
        return InputTexts(formString.Trim());
    }

    private string InputTexts(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return string.Empty;
        }
        text = Regex.Replace(text, @"[\s]{2,}", " ");
        text = Regex.Replace(text, @"(<[b|B][r|R]/*>)+|(<[p|P](.|\n)*?>)", "\n");
        text = Regex.Replace(text, @"(\s*&[n|N][b|B][s|S][p|P];\s*)+", " ");
        text = Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
        text = text.Replace("'", "''");
        return text;
    }
}