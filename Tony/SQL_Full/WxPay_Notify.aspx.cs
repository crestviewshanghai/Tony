using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Xml;
using System.Data;
using System.Collections;

public partial class WxPay_Notify : MojoCube.Api.UI.WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string data = string.Empty;

            try
            {
                //接收并读取POST过来的XML文件流
                StreamReader reader = new StreamReader(Request.InputStream);
                String xmlData = reader.ReadToEnd();

                data = xmlData;
            }
            catch { }

            MojoCube.Web.Order.List order = new MojoCube.Web.Order.List();
            order.GetData(GetWxKeyValue(data, "out_trade_no"));

            if (order.pk_Order > 0)
            {
                ViewState["AppID"] = GetWxKeyValue(data, "appid");
                string responseTxt = GetWxKeyValue(data, "return_code");

                if (!IsAllow())
                {
                    return;
                }

                if (!MojoCube.Web.Sql.IsExist("Order_Log", "fk_Order", order.pk_Order, "TransStatus='" + responseTxt + "'"))
                {
                    bool isSuccess = false;

                    if (responseTxt == "SUCCESS")
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
                    log.AppID = ViewState["AppID"].ToString();
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
                    log.ChannelType = "微信支付";
                    log.ResponseCode = responseTxt;
                    log.OrderStartTime = GetWxKeyValue(data, "time_end");
                    log.OrderAmt = GetWxKeyValue(data, "total_fee");
                    log.OrderTimeOut = "0";
                    log.OrderType = "普通消费";
                    log.DeviceType = GetWxKeyValue(data, "trade_type");
                    log.ResponseTime = log.OrderStartTime;
                    log.CurrencyType = GetWxKeyValue(data, "fee_type");
                    log.Result = data;
                    log.CreateDate = DateTime.Now.ToString();
                    log.InsertData();

                    //支付成功
                    if (isSuccess)
                    {
                        //修改订单状态
                        order.StatusID = 1;
                        order.fk_Payment = 3;
                        order.PaymentDate = DateTime.Now.ToString();
                        order.UpdateData(order.pk_Order);

                        //通知微信已收到通知
                        Response.Write(CreateMsg());
                    }
                }
            }
        }
    }

    #region 微信檢查

    /// <summary>
    /// 检查传过来的AppID是否正确，防止假通知
    /// </summary>
    /// <returns></returns>
    private bool IsAllow()
    {
        bool allow = false;

        DataTable dt = new DataTable();

        ArrayList parameter = new ArrayList();
        parameter.Add(MojoCube.Web.SqlHelper.CreateParameter("@AppID", ViewState["AppID"].ToString(), SqlDbType.NVarChar));
        dt = MojoCube.Web.SqlHelper.SqlQueryDS("select AppID from Payment_List where AppID=@AppID and Visible=1", parameter).Tables[0];

        if (dt.Rows.Count > 0)
        {
            allow = true;
        }

        return allow;
    }

    /// <summary>
    /// 收到通知告诉微信
    /// </summary>
    /// <returns></returns>
    private string CreateMsg()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<xml>");
        sb.Append("<return_code><![CDATA[SUCCESS]]></return_code>");
        sb.Append("<return_msg><![CDATA[OK]]></return_msg>");
        sb.Append("</xml>");
        return sb.ToString();
    }

    private string GetWxKeyValue(string data, string key)
    {
        string value = "";
        SortedDictionary<string, string> requestXML = GetInfoFromXml(data);
        foreach (KeyValuePair<string, string> k in requestXML)
        {
            if (k.Key == key)
            {
                value = k.Value;
                break;
            }
        }
        return value;
    }

    /// <summary>
    /// 把XML数据转换为SortedDictionary<string, string>集合
    /// </summary>
    /// <param name="strxml"></param>
    /// <returns></returns>
    protected SortedDictionary<string, string> GetInfoFromXml(string xmlstring)
    {
        SortedDictionary<string, string> sParams = new SortedDictionary<string, string>();
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstring);
            XmlElement root = doc.DocumentElement;
            int len = root.ChildNodes.Count;
            for (int i = 0; i < len; i++)
            {
                string name = root.ChildNodes[i].Name;
                if (!sParams.ContainsKey(name))
                {
                    sParams.Add(name.Trim(), root.ChildNodes[i].InnerText.Trim());
                }
            }
        }
        catch { }
        return sParams;
    }

    #endregion
}