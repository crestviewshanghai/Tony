using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class Pay : MojoCube.Api.UI.WebPage
{
    public string strLanguage;

    protected void Page_Init(object sender, EventArgs e)
    {
        strLanguage = MojoCube.Api.UI.Language.GetLanguage();

        MojoCube.Web.Member.List.ChkLogin();

        #region  动态添加head的标签
        MojoCube.Api.Html.Header header = new MojoCube.Api.Html.Header(this.Page);
        //Meta
        header.AddMeta("title", MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage));
        header.AddMeta("keywords", MojoCube.Web.Site.Cache.GetSiteKeyword(strLanguage));
        header.AddMeta("description", MojoCube.Web.Site.Cache.GetSiteDescription(strLanguage));
        //Link
        header.AddLiteral("<link rel=\"shortcut icon\" href=\"images/favicon.ico\" type=\"image/x-icon\" />");
        //CSS
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/bootstrap.css");
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/bootstrap-dialog.min.css");
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/glide.css");
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/style.css");
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/online.css");
        //JS
        header.AddJS("JS/jquery.min.js");
        header.AddJS("JS/bootstrap.js");
        header.AddJS("JS/bootstrap-dialog.min.js");
        header.AddJS("JS/jquery.glide.js");
        #endregion
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

            WUC_MemberMenu.CssFocus = "id=\"\"";
            BannerDiv.InnerHtml = MojoCube.Web.Site.Cache.GetSiteBanner(strLanguage, 1);
            InfoDiv.InnerHtml = CreateInfo();
            this.Title = MojoCube.Web.String.GetTitle(hlTitle.Text, MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage));
        }
    }

    private string CreateInfo()
    {
        StringBuilder sb = new StringBuilder();

        MojoCube.Web.Order.List order = new MojoCube.Web.Order.List();
        order.GetData(int.Parse(ViewState["pk_Order"].ToString()));

        if (order.pk_Order == 0 || order.StatusID > 0 || order.fk_Member.ToString() != Session["Member_UserID"].ToString())
        {
            Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage));
        }

        sb.Append("<div class=\"pay-wrap\">");
        sb.Append("<table>");
        sb.Append("<tr>");
        sb.Append("<td class=\"pay-td\">订单编号：</td>");
        sb.Append("<td>" + order.OrderNumber + "</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td class=\"pay-td\">订单描述：</td>");
        sb.Append("<td>" + order.Description + "</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td class=\"pay-td\">订单金额：</td>");
        sb.Append("<td><span class=\"price\">" + MojoCube.Web.String.GetCurrency(order.Amount) + "</span></td>");
        sb.Append("</tr>");
        sb.Append("</table>");
        sb.Append("</div>");
        sb.Append("<div class=\"pay-title\">");
        sb.Append("<b>请选择支付方式：</b>");
        sb.Append("</div>");
        sb.Append("<div class=\"pay-item-wrap\">");
        sb.Append("<div class=\"pay-item-div\">");

        DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select TypeID,ImagePath,Title from Payment_List where Visible=1 order by SortID asc").Tables[0];

        if (dt.Rows.Count > 0)
        {
            string url = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch (dt.Rows[i]["TypeID"].ToString())
                { 
                    case "0":
                        url = MojoCube.Web.Site.Cache.GetUrlExtension("Alipay_Post", strLanguage);
                        break;
                    case "1":
                        url = MojoCube.Web.Site.Cache.GetUrlExtension("Paypal_Post", strLanguage);
                        break;
                    case "2":
                        url = MojoCube.Web.Site.Cache.GetUrlExtension("WxPay", strLanguage);
                        break;
                }
                sb.Append("<div class=\"pay-item\"><a href=\"" + url + "?id=" + Request.QueryString["id"] + "\" target=\"_blank\" onclick=\"openDialog();\"><img src=\"Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["ImagePath"].ToString()) + "\" alt=\"" + dt.Rows[i]["Title"].ToString() + "\" /><br />" + dt.Rows[i]["Title"].ToString() + "</a></div>");
            }
        }

        sb.Append("</div>");
        sb.Append("</div>");

        //提示框信息
        sb.Append("<script type=\"text/javascript\">");
        sb.Append("function openDialog() {");
        sb.Append("BootstrapDialog.show({");
        sb.Append("title: '支付情况',");
        sb.Append("message: '如果您已经付款成功，请返回订单查看订单状态；如果付款过程中出现问题，请重试一次。',");
        sb.Append("buttons: [{");
        sb.Append("label: '支付成功，返回订单',");
        sb.Append("cssClass: 'btn-primary',");
        sb.Append("action: function () {");
        sb.Append("window.location.href = '" + MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage) + "';");
        sb.Append("}");
        sb.Append("}, {");
        sb.Append("label: '再试一次',");
        sb.Append("cssClass: 'btn-warning',");
        sb.Append("action: function (dialogItself) {");
        sb.Append("dialogItself.close();");
        sb.Append("}");
        sb.Append("}]");
        sb.Append("});");
        sb.Append("}");
        sb.Append("</script>");

        return sb.ToString();
    }
}