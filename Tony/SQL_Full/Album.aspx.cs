using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;

public partial class Album : MojoCube.Api.UI.WebPage
{
    public string strLanguage;

    protected void Page_Init(object sender, EventArgs e)
    {
        strLanguage = MojoCube.Api.UI.Language.GetLanguage();

        #region  动态添加head的标签
        MojoCube.Api.Html.Header header = new MojoCube.Api.Html.Header(this.Page);
        //Meta
        string title = MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage);
        string keywords = MojoCube.Web.Site.Cache.GetSiteKeyword(strLanguage);
        string description = MojoCube.Web.Site.Cache.GetSiteDescription(strLanguage);

        if (Request.QueryString["pageName"] != null)
        {
            MojoCube.Web.Album.Category category = new MojoCube.Web.Album.Category();
            category.GetData(Request.QueryString["pageName"]);

            ViewState["pk_Category"] = category.pk_Category;
            hlTitle.Text = category.CategoryName;

            if (category.SEO_Title != "")
            {
                title = category.SEO_Title;
            }
            if (category.SEO_Keyword != "")
            {
                keywords = category.SEO_Keyword;
            }
            if (category.SEO_Description != "")
            {
                description = category.SEO_Description;
            }
        }

        header.AddMeta("title", title);
        header.AddMeta("keywords", keywords);
        header.AddMeta("description", description);
        //Link
        header.AddLiteral("<link rel=\"shortcut icon\" href=\"images/favicon.ico\" type=\"image/x-icon\" />");
        //CSS
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/bootstrap.css");
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/glide.css");
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/detailGlide.css");
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/style.css");
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/lightgallery.css");
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
            AlbumUL.InnerHtml = CreateList();
            firstpane.InnerHtml = CreateNav();
            BannerDiv.InnerHtml = MojoCube.Web.Site.Cache.GetSiteBanner(strLanguage, 1);
            this.Title = MojoCube.Web.String.GetTitle(hlTitle.Text, MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage));
        }
    }

    #region 创建列表
    private string CreateList()
    {
        StringBuilder sb = new StringBuilder();

        string where = "Issue=1 and Language='" + strLanguage + "'";

        if (ViewState["pk_Category"] != null)
        {
            where += " and (CategoryID1=" + ViewState["pk_Category"].ToString() + " or CategoryID2=" + ViewState["pk_Category"].ToString() + ")";
        }

        MojoCube.Api.UI.WebPager pager = new MojoCube.Api.UI.WebPager(ListPager);
        pager.Language = strLanguage;
        pager.ConnStr = MojoCube.Web.Connection.ConnString();
        pager.PageSize = MojoCube.Web.String.PageSize("album");
        pager.TableName = "Album_List";
        pager.strGetFields = "*";
        pager.where = where;
        pager.fldName = "CreateDate";
        pager.OrderType = true;
        ListPager.NumericButtonCount = MojoCube.Web.String.GetNumericButtonCount();
        ListPager.EnableUrlRewriting = true;

        if (Request.QueryString["pageName"] != null)
        {
            ListPager.UrlRewritePattern = MojoCube.Web.Site.Cache.GetUrlExtension("AC-%pageName%", strLanguage) + "?page={0}";
        }
        else
        {
            ListPager.UrlRewritePattern = MojoCube.Web.Site.Cache.GetUrlExtension("Album", strLanguage) + "?page={0}";
        }

        DataTable dt = new DataTable();
        dt = pager.GetTable();

        if (dt.Rows.Count > 0)
        {
            string url = string.Empty;
            string title = string.Empty;
            string img = string.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                url = MojoCube.Web.Site.Cache.GetUrlExtension("A-" + dt.Rows[i]["PageName"].ToString(), strLanguage);
                title = dt.Rows[i]["Title"].ToString();
                img = "Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["ImagePath"].ToString()) + "&w=500&h=500";

                sb.Append("<li class=\"col-sm-4 col-md-3 col-mm-6\">");
                sb.Append("<div class=\"albumImg\" data-responsive='' data-src='" + img + "' data-sub-html=''>");
                sb.Append("<img class=\"viewBig\" src=\"" + img + "\" alt=\"" + title + "\" />");
                sb.Append("</div>");
                sb.Append("<a class=\"albumTitle\" href=\"" + url + "\" title=\"" + title + "\">" + title + "</a>");
                sb.Append("</li>");
            }
        }

        return sb.ToString();
    }
    #endregion

    #region 创建导航
    private string CreateNav()
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = new DataTable();

        dt = MojoCube.Web.Sql.SqlQueryDS("select * from Album_Category where Visible=1 and Language='" + strLanguage + "' order by SortID asc").Tables[0];

        if (dt.Rows.Count > 0)
        {
            DataRow[] dr;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ParentID"].ToString() == "0")
                {
                    dr = dt.Select("ParentID=" + dt.Rows[i]["pk_Category"].ToString());

                    sb.Append("<li>");
                    sb.Append("<a class=\"biglink\" href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("AC-" + dt.Rows[i]["PageName"].ToString(), strLanguage) + "\">" + dt.Rows[i]["CategoryName"].ToString() + "</a><span class=\"menu_head\">+</span>");
                    sb.Append("<ul class=\"left_snav_ul menu_body\">");
                    if (dr.Length > 0)
                    {
                        for (int j = 0; j < dr.Length; j++)
                        {
                            sb.Append("<li><a href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("AC-" + dr[j]["PageName"].ToString(), strLanguage) + "\">" + dr[j]["CategoryName"].ToString() + "</a></li>");
                        }
                    }
                    sb.Append("</ul>");
                    sb.Append("</li>");
                }
            }
        }

        return sb.ToString();
    }
    #endregion
}