using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;

public partial class Member : MojoCube.Api.UI.WebPage
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
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/glide.css");
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/style.css");
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/online.css");
        //JS
        header.AddJS("JS/jquery.min.js");
        header.AddJS("JS/bootstrap.js");
        header.AddJS("JS/jquery.glide.js");
        #endregion
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WUC_MemberMenu.CssFocus = "id=\"Menu1\"";
            InfoDiv.InnerHtml = CreateInfo();
            BannerDiv.InnerHtml = MojoCube.Web.Site.Cache.GetSiteBanner(strLanguage, 1);
            this.Title = MojoCube.Web.String.GetTitle(hlTitle.Text, MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage));
        }
    }

    private string CreateInfo()
    {
        StringBuilder sb = new StringBuilder();

        MojoCube.Web.Member.List user = new MojoCube.Web.Member.List();
        user.GetData(int.Parse(Session["Member_UserID"].ToString()));

        string img = "Admin/Images/user.png";

        if (user.ImagePath != "")
        {
            img = "Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(user.ImagePath);
        }

        int msgCount = MojoCube.Web.Sql.GetResultCount("Member_Message", "ReceiveUserID=" + Session["Member_UserID"].ToString() + " and IsDeleted=0 and IsRead=0");

        sb.Append("<div style=\"text-align:left; background:#eee; padding:10px;\">");
        sb.Append("<a href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("Setting", strLanguage) + "\"><img src=\"" + img + "\" class=\"toppic\" /> " + user.LastName + user.FirstName + "（" + user.Phone1 + "）</a>");
        if (msgCount > 0)
        {
            sb.Append("您有<a href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("Message", strLanguage) + "\"><b class=\"price\"> " + msgCount + " </b></a>条新的消息，请到消息中心查看。");
        }
        sb.Append("</div>");

        string orderUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage);

        sb.Append("<table style=\"width:100%;\">");
        sb.Append("<tr>");
        sb.Append("<td style=\"border-right:solid 1px #ddd; text-align:center; padding:10px;\"><a href=\"" + orderUrl + "?status=0\">待付款" + GetOrderStatus(0) + "</a></td>");
        sb.Append("<td style=\"border-right:solid 1px #ddd; text-align:center; padding:10px;\"><a href=\"" + orderUrl + "?status=1\">待发货" + GetOrderStatus(1) + "</a></td>");
        sb.Append("<td style=\"border-right:solid 1px #ddd; text-align:center; padding:10px;\"><a href=\"" + orderUrl + "?status=2\">待收货" + GetOrderStatus(2) + "</a></td>");
        sb.Append("<td style=\"text-align:center; padding:10px;\"><a href=\"" + orderUrl + "?status=3\">待评价" + GetOrderStatus(3) + "</a></td>");
        sb.Append("</tr>");
        sb.Append("</table>");

        return sb.ToString();
    }

    private string GetOrderStatus(int statusId)
    {
        string text = string.Empty;

        int count = MojoCube.Web.Sql.GetResultCount("Order_List", "fk_Member=" + Session["Member_UserID"].ToString() + " and IsDeleted=0 and IsComment=0 and StatusID=" + statusId);

        if (count > 0)
        {
            text = "（<b class=\"price\">" + count.ToString() + "</b>）";
        }

        return text;
    }
}