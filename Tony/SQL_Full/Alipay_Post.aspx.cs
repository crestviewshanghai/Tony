using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Alipay_Post : MojoCube.Api.UI.WebPage
{
    public string strLanguage;

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

            Response.Redirect(GetPostUrl());
        }
    }

    private string GetPostUrl()
    {
        string siteUrl = MojoCube.Web.Site.Cache.GetDomain(strLanguage);  //获取网站的域名

        MojoCube.Web.Payment.List payment = new MojoCube.Web.Payment.List();
        payment.GetDataByType(0);

        MojoCube.Web.Order.List order = new MojoCube.Web.Order.List();
        order.GetData(int.Parse(ViewState["pk_Order"].ToString()));

        if (order.pk_Order == 0 || order.StatusID > 0 || order.fk_Member.ToString() != Session["Member_UserID"].ToString())
        {
            Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage));
        }

        ///////////////////////以下参数是需要设置的相关配置参数，设置后不会更改的///////////////////////////
        string service = payment.Service;       //服务类型：create_partner_trade_by_buyer（支付宝中介担保交易）或者trade_create_by_buyer（即时到账）
        string partner = payment.PartnerID;                                     //合作身份者ID
        string key = payment.KeyCode;                         //安全检验码
        string seller_email = payment.Account;                             //签约支付宝账号或卖家支付宝帐户
        string input_charset = payment.InputCharset;                                          //字符编码格式 目前支持 gb2312 或 utf-8
        string notify_url = siteUrl + MojoCube.Web.Site.Cache.GetUrlExtension("Alipay_Notify", strLanguage); //交易过程中服务器通知的页面 要用 http://格式的完整路径，不允许加?id=123这类自定义参数
        string return_url = siteUrl + MojoCube.Web.Site.Cache.GetUrlExtension("Alipay_Return", strLanguage); //付完款后跳转的页面 要用 http://格式的完整路径，不允许加?id=123这类自定义参数
        string show_url = siteUrl;                     //网站商品的展示地址，不允许加?id=123这类自定义参数
        string sign_type = payment.SignType;                                                //加密方式 不需修改

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////以下参数是需要通过下单时的订单数据传入进来获得////////////////////////////////
        //必填参数
        string out_trade_no = order.OrderNumber;  //请与贵网站订单系统中的唯一订单号匹配
        string subject = order.Description;                      //订单名称，显示在支付宝收银台里的“商品名称”里，显示在支付宝的交易管理的“商品名称”的列表里。
        string body = "订单描述：" + order.Description;                                   //订单描述、订单详细、订单备注，显示在支付宝收银台里的“商品描述”里
        string price = order.Amount.ToString("0.00");                  		                //订单总金额，显示在支付宝收银台里的“商品单价”里

        string logistics_fee = "0.00";                  				//物流费用，即运费。
        string logistics_type = "EXPRESS";				                //物流类型，三个值可选：EXPRESS（快递）、POST（平邮）、EMS（EMS）
        string logistics_payment = "SELLER_PAY";            			//物流支付方式，两个值可选：SELLER_PAY（卖家承担运费）、BUYER_PAY（买家承担运费）

        string quantity = "1";              							//商品数量，建议默认为1，不改变值，把一次交易看成是一次下订单而非购买一件商品。

        //扩展参数——买家收货信息（推荐作为必填）
        //该功能作用在于买家已经在商户网站的下单流程中填过一次收货信息，而不需要买家在支付宝的付款流程中再次填写收货信息。
        //若要使用该功能，请至少保证receive_name、receive_address有值
        string receive_name = order.CustomerName;			                    //收货人姓名，如：张三
        string receive_address = order.CustomerAddress;			                //收货人地址，如：XX省XXX市XXX区XXX路XXX小区XXX栋XXX单元XXX号
        string receive_zip = order.CustomerZip;                  			//收货人邮编，如：123456
        string receive_phone = order.CustomerPhone1;                		//收货人电话号码，如：0571-81234567
        string receive_mobile = order.CustomerPhone1;               		//收货人手机号码，如：13312341234

        //扩展参数——第二组物流方式
        //物流方式是三个为一组成组出现。若要使用，三个参数都需要填上数据；若不使用，三个参数都需要为空
        //有了第一组物流方式，才能有第二组物流方式，且不能与第一个物流方式中的物流类型相同，
        //即logistics_type="EXPRESS"，那么logistics_type_1就必须在剩下的两个值（POST、EMS）中选择
        string logistics_fee_1 = "";                					//物流费用，即运费。
        string logistics_type_1 = "";               					//物流类型，三个值可选：EXPRESS（快递）、POST（平邮）、EMS（EMS）
        string logistics_payment_1 = "";           					    //物流支付方式，两个值可选：SELLER_PAY（卖家承担运费）、BUYER_PAY（买家承担运费）

        //扩展参数——第三组物流方式
        //物流方式是三个为一组成组出现。若要使用，三个参数都需要填上数据；若不使用，三个参数都需要为空
        //有了第一组物流方式和第二组物流方式，才能有第三组物流方式，且不能与第一组物流方式和第二组物流方式中的物流类型相同，
        //即logistics_type="EXPRESS"、logistics_type_1="EMS"，那么logistics_type_2就只能选择"POST"
        string logistics_fee_2 = "";                					//物流费用，即运费。
        string logistics_type_2 = "";               					//物流类型，三个值可选：EXPRESS（快递）、POST（平邮）、EMS（EMS）
        string logistics_payment_2 = "";            					//物流支付方式，两个值可选：SELLER_PAY（卖家承担运费）、BUYER_PAY（买家承担运费）

        //扩展功能参数——其他
        string buyer_email = "";                    					//默认买家支付宝账号
        string discount = "";                       					//折扣，是具体的金额，而不是百分比。若要使用打折，请使用负数，并保证小数点最多两位数

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        //构造请求函数
        MojoCube.Web.Payment.Alipay.Service aliService = new MojoCube.Web.Payment.Alipay.Service(
            partner,
            seller_email,
            return_url,
            notify_url,
            show_url,
            out_trade_no,
            subject,
            body,
            price,
            logistics_fee,
            logistics_type,
            logistics_payment,
            quantity,
            receive_name,
            receive_address,
            receive_zip,
            receive_phone,
            receive_mobile,
            logistics_fee_1,
            logistics_type_1,
            logistics_payment_1,
            logistics_fee_2,
            logistics_type_2,
            logistics_payment_2,
            buyer_email,
            discount,
            key,
            input_charset,
            sign_type,
            service);

        //GET方式传递
        return aliService.Create_url();
    }
}