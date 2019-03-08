using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paypal_Post : MojoCube.Api.UI.WebPage
{
    public string strLanguage;

    public string strUrl = string.Empty; //测试用
    public string ordersn = string.Empty;//订单号，现随机生的，正式环境改成接收过来的订单号
    public string item_name = string.Empty;//商品名
    public double amount = 0;//订单总金额
    public string currency_code = string.Empty;//货币类型
    public string username = string.Empty;//用户名
    public string business = string.Empty;//收款（卖家）帐号
    public string notify_url = string.Empty;
    public string cancel_return = string.Empty;
    public string success_return = string.Empty;

    protected void Page_Init(object sender, EventArgs e)
    {
        strLanguage = MojoCube.Api.UI.Language.GetLanguage();

        MojoCube.Web.Member.List.ChkLogin();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage));
            }

            ViewState["pk_Order"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

            MojoCube.Web.Order.List order = new MojoCube.Web.Order.List();
            order.GetData(int.Parse(ViewState["pk_Order"].ToString()));

            if (order.pk_Order == 0 || order.StatusID > 0 || order.fk_Member.ToString() != Session["Member_UserID"].ToString())
            {
                Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage));
            }

            string siteUrl = MojoCube.Web.Site.Cache.GetDomain(strLanguage);  //获取网站的域名

            MojoCube.Web.Payment.List payment = new MojoCube.Web.Payment.List();
            payment.GetDataByType(1);

            strUrl = payment.Gateway;
            ordersn = order.OrderNumber;
            item_name = HttpUtility.UrlEncode(order.Description, System.Text.Encoding.UTF8);
            amount = (double)order.Amount * double.Parse(payment.Rate.ToString());
            amount = double.Parse(amount.ToString("0.00"));
            currency_code = "USD";
            username = HttpUtility.UrlEncode(order.CustomerName, System.Text.Encoding.UTF8);
            business = payment.Account;
            notify_url = siteUrl + MojoCube.Web.Site.Cache.GetUrlExtension("Paypal_NotifyUrl", strLanguage);
            cancel_return = siteUrl + MojoCube.Web.Site.Cache.GetUrlExtension("Paypal_Cancel", strLanguage) + "?username=" + username + "&ordersn=" + ordersn;
            success_return = siteUrl + MojoCube.Web.Site.Cache.GetUrlExtension("Paypal_Success", strLanguage) + "?username=" + username + "&ordersn=" + ordersn;
        }
    }
}