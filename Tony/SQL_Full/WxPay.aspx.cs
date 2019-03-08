using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;
using MojoCube.Web.Payment.WxPay;

public partial class WxPay : MojoCube.Api.UI.WebPage
{
    public string strLanguage;
    public string appId;
    public string prepayId;
    public string nonceStr;
    public string timeStamp;
    public string sign;

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

            WxPayJS();
        }
    }

    #region JSAPI支付

    private void WxPayJS()
    {
        string siteUrl = MojoCube.Web.Site.Cache.GetDomain(strLanguage);  //获取网站的域名

        MojoCube.Web.Payment.List payment = new MojoCube.Web.Payment.List();
        payment.GetDataByType(2);

        MojoCube.Web.Order.List order = new MojoCube.Web.Order.List();
        order.GetData(int.Parse(ViewState["pk_Order"].ToString()));

        if (order.pk_Order == 0 || order.StatusID > 0 || order.fk_Member.ToString() != Session["Member_UserID"].ToString())
        {
            Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage));
        }

        appId = payment.AppID;
        string partnerId = payment.PartnerID;
        string key = payment.KeyCode;
        string secret = payment.Secret;
        int price = (int)(order.Amount * 100);
        string body = order.Description;

        if (body.Length > 20)
        {
            body = body.Substring(0, 20);
        }

        //调用【网页授权获取用户信息】接口获取用户的openid和access_token
        GetOpenidAndAccessToken(appId, secret);

        UnifiedOrder order1 = new UnifiedOrder();
        order1.appid = appId;
        order1.mch_id = partnerId;
        order1.nonce_str = TenpayUtil.getNoncestr();
        order1.body = body;
        order1.out_trade_no = order.OrderNumber;
        order1.total_fee = price;
        order1.spbill_create_ip = Page.Request.UserHostAddress;
        order1.notify_url = siteUrl + MojoCube.Web.Site.Cache.GetUrlExtension("WxPay_Notify", strLanguage);
        order1.trade_type = "JSAPI";
        if (ViewState["OpenID"] != null)
        {
            order1.openid = ViewState["OpenID"].ToString();  //JSAPI必须传入openid
        }

        TenpayUtil tu = new TenpayUtil();

        prepayId = tu.getPrepay_id(order1, key);
        nonceStr = order1.nonce_str;
        timeStamp = TenpayUtil.getTimestamp();

        SortedDictionary<string, string> sParams = new SortedDictionary<string, string>();
        sParams.Add("appId", appId);
        sParams.Add("nonceStr", nonceStr);
        sParams.Add("package", "prepay_id=" + prepayId);
        sParams.Add("signType", "MD5");
        sParams.Add("timeStamp", timeStamp);
        sign = tu.getsign(sParams, key);
    }

    public void GetOpenidAndAccessToken(string appId, string secret)
    {
        if (!string.IsNullOrEmpty(this.Request.QueryString["code"]))
        {
            //获取code码，以获取openid和access_token
            string code = this.Request.QueryString["code"];
            Log.Debug(this.GetType().ToString(), "Get code : " + code);
            GetOpenidAndAccessTokenFromCode(code, appId, secret);
        }
        else
        {
            //构造网页授权获取code的URL
            string host = this.Request.Url.Host;
            string path = this.Request.Path + "?orderId=" + ViewState["pk_Order"].ToString();
            string redirect_uri = HttpUtility.UrlEncode("http://" + host + path);
            WxPayData data = new WxPayData();
            data.SetValue("appid", appId);
            data.SetValue("redirect_uri", redirect_uri);
            data.SetValue("response_type", "code");
            data.SetValue("scope", "snsapi_base");
            data.SetValue("state", "STATE" + "#wechat_redirect");
            string url = "https://open.weixin.qq.com/connect/oauth2/authorize?" + data.ToUrl();
            Log.Debug(this.GetType().ToString(), "Will Redirect to URL : " + url);
            try
            {
                //触发微信返回code码         
                this.Response.Redirect(url);//Redirect函数会抛出ThreadAbortException异常，不用处理这个异常
            }
            catch
            {

            }
        }
    }

    public void GetOpenidAndAccessTokenFromCode(string code, string appId, string secret)
    {
        try
        {
            //构造获取openid及access_token的url
            WxPayData data = new WxPayData();
            data.SetValue("appid", appId);
            data.SetValue("secret", secret);
            data.SetValue("code", code);
            data.SetValue("grant_type", "authorization_code");
            string url = "https://api.weixin.qq.com/sns/oauth2/access_token?" + data.ToUrl();

            //请求url以获取数据
            string result = HttpService.Get(url);

            Log.Debug(this.GetType().ToString(), "GetOpenidAndAccessTokenFromCode response : " + result);

            //保存access_token，用于收货地址获取
            JsonData jd = JsonMapper.ToObject(result);
            string access_token = (string)jd["access_token"];

            //获取用户openid
            string openid = (string)jd["openid"];
            ViewState["OpenID"] = openid;

            Log.Debug(this.GetType().ToString(), "Get openid : " + openid);
            Log.Debug(this.GetType().ToString(), "Get access_token : " + access_token);
        }
        catch (Exception ex)
        {
            Log.Error(this.GetType().ToString(), ex.ToString());
            throw new WxPayException(ex.ToString());
        }
    }

    #endregion
}