using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;

public partial class Article : MojoCube.Api.UI.WebPage
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
            MojoCube.Web.Article.Category category = new MojoCube.Web.Article.Category();
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
            ArticleUL.InnerHtml = CreateList();
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

        if (Request.QueryString["q"] != null)
        {
            string keyword = MojoCube.Api.Text.CheckSql.Filter(Request.QueryString["q"]);
            hlTitle.Text = keyword;
            where += " and (Title like '%" + keyword + "%' or Description like '%" + keyword + "%')";

            //加入搜索记录
            MojoCube.Web.Site.Search.InsertData(keyword, 1);
        }

        MojoCube.Api.UI.WebPager pager = new MojoCube.Api.UI.WebPager(ListPager);
        pager.Language = strLanguage;
        pager.ConnStr = MojoCube.Web.Connection.ConnString();
        pager.PageSize = MojoCube.Web.String.PageSize("article");
        pager.TableName = "Article_List";
        pager.strGetFields = "*";
        pager.where = where;
        pager.fldName = "CreateDate desc,pk_Article";
        pager.OrderType = true;
        ListPager.NumericButtonCount = MojoCube.Web.String.GetNumericButtonCount();
        ListPager.EnableUrlRewriting = true;

        if (Request.QueryString["pageName"] != null)
        {
            ListPager.UrlRewritePattern = MojoCube.Web.Site.Cache.GetUrlExtension("NC-%pageName%", strLanguage) + "?page={0}";
        }
        else if (Request.QueryString["q"] != null)
        {
            ListPager.UrlRewritePattern = MojoCube.Web.Site.Cache.GetUrlExtension("News", strLanguage) + "?q=%q%&page={0}";
        }
        else
        {
            ListPager.UrlRewritePattern = MojoCube.Web.Site.Cache.GetUrlExtension("News", strLanguage) + "?page={0}";
        }

        DataTable dt = new DataTable();
        dt = pager.GetTable();

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime time = DateTime.Parse(dt.Rows[i]["CreateDate"].ToString());

                sb.Append("<li>");
                sb.Append("<a class=\"wrapper\" href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("N-" + dt.Rows[i]["PageName"].ToString(), strLanguage) + "\">");
                sb.Append("<div class=\"time\">");
                sb.Append("<div class=\"day\">" + time.ToString("dd") + "</div>");
                sb.Append("<div class=\"date\">" + time.ToString("yyyy/MM") + "</div>");
                sb.Append("</div>");
                if (dt.Rows[i]["ImagePath"].ToString() != "")
                {
                    string img = "Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["ImagePath"].ToString()) + "&w=500&h=500";
                    sb.Append("<img src=\"" + img + "\" />");
                }
                else
                {
                    sb.Append("<img src=\"Images/no_image.jpg\" />");
                }
                sb.Append("<span>" + dt.Rows[i]["Title"].ToString() + "</span>");
                sb.Append("<p>" + MojoCube.Api.Text.Content.GetContentSummary(dt.Rows[i]["Description"].ToString(), 150, true) + "</p>");
                sb.Append("</a>");
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

        dt = MojoCube.Web.Sql.SqlQueryDS("select * from Article_Category where Visible=1 and Language='" + strLanguage + "' order by SortID asc").Tables[0];

        if (dt.Rows.Count > 0)
        {
            DataRow[] dr;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ParentID"].ToString() == "0")
                {
                    dr = dt.Select("ParentID=" + dt.Rows[i]["pk_Category"].ToString());

                    sb.Append("<li>");
                    sb.Append("<a class=\"biglink\" href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("NC-" + dt.Rows[i]["PageName"].ToString(), strLanguage) + "\">" + dt.Rows[i]["CategoryName"].ToString() + "</a><span class=\"menu_head\">+</span>");
                    sb.Append("<ul class=\"left_snav_ul menu_body\">");
                    if (dr.Length > 0)
                    {
                        for (int j = 0; j < dr.Length; j++)
                        {
                            sb.Append("<li><a href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("NC-" + dr[j]["PageName"].ToString(), strLanguage) + "\">" + dr[j]["CategoryName"].ToString() + "</a></li>");
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