using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;

public partial class Favorite : MojoCube.Api.UI.WebPage
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
            WUC_MemberMenu.CssFocus = "id=\"Menu3\"";
            ProductUL.InnerHtml = CreateList();
            BannerDiv.InnerHtml = MojoCube.Web.Site.Cache.GetSiteBanner(strLanguage, 1);
            this.Title = MojoCube.Web.String.GetTitle(hlTitle.Text, MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage));
        }
    }

    #region 创建列表
    private string CreateList()
    {
        StringBuilder sb = new StringBuilder();

        MojoCube.Api.UI.WebPager pager = new MojoCube.Api.UI.WebPager(ListPager);
        pager.Language = strLanguage;
        pager.ConnStr = MojoCube.Web.Connection.ConnString();
        pager.PageSize = MojoCube.Web.String.PageSize("product");
        pager.TableName = "View_Member_Favorite";
        pager.strGetFields = "*";
        pager.where = "fk_Member=" + Session["Member_UserID"].ToString();
        pager.fldName = "CreateDate";
        pager.OrderType = true;
        ListPager.NumericButtonCount = MojoCube.Web.String.GetNumericButtonCount();
        ListPager.EnableUrlRewriting = true;

        ListPager.UrlRewritePattern = MojoCube.Web.Site.Cache.GetUrlExtension("Favorite", strLanguage) + "?page={0}";

        DataTable dt = new DataTable();
        dt = pager.GetTable();

        if (dt.Rows.Count > 0)
        {
            string url = string.Empty;
            string del = string.Empty;
            string title = string.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                url = MojoCube.Web.Site.Cache.GetUrlExtension("P-" + dt.Rows[i]["PageName"].ToString(), strLanguage);
                del = MojoCube.Web.Site.Cache.GetUrlExtension("FavoriteAdd", strLanguage) + "?del=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["pk_Favorite"].ToString());
                title = dt.Rows[i]["ProductName"].ToString();

                sb.Append("<li class=\"col-sm-4 col-md-3 col-mm-6\">");
                sb.Append("<div class=\"productImg\">");
                sb.Append("<img src=\"Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["ImagePath"].ToString()) + "&w=500&h=500\" alt=\"" + title + "\" />");
                sb.Append("<span>" + title + "</span>");
                sb.Append("<a class=\"productTitle\" href=\"" + url + "\" title=\"" + title + "\">查看详情</a>&nbsp;&nbsp;");
                sb.Append("<a class=\"productTitle\" href=\"" + del + "\" title=\"" + title + "\" style=\"background:#C10404\">删除收藏</a>");
                sb.Append("<div class=\"price_item\">" + MojoCube.Web.String.GetCurrency(decimal.Parse(dt.Rows[i]["Price"].ToString())) + "</div>");
                sb.Append("</div>");
                sb.Append("</li>");
            }
        }

        return sb.ToString();
    }
    #endregion
}