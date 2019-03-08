using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class _Default : MojoCube.Api.UI.WebPage
{
    public string strLanguage;

    protected void Page_Init(object sender, EventArgs e)
    {
        strLanguage = MojoCube.Api.UI.Language.GetLanguage();

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

        this.Title = MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            #region  连接数据层
            StringBuilder strSql = new StringBuilder();
            //0：关于
            strSql.Append(" select top 1 ImagePath,Title,Subtitle,PageName from Content_List where PageName='About' and Visible=1 and Language='" + strLanguage + "'");
            //1：文章
            strSql.Append(" select top 6 Title,PageName,CreateDate,Subtitle,ImagePath from Article_List where Issue=1 and Language='" + strLanguage + "' order by CreateDate desc");
            //2：产品
            strSql.Append(" select top 9 ProductName,PageName,ImagePath,Price from Product_List where Issue=1 and Language='" + strLanguage + "' order by CreateDate desc");
            //3：分类
            strSql.Append(" select * from Product_Category where Visible=1 and Language='" + strLanguage + "' order by SortID asc");

            DataSet ds = MojoCube.Web.Sql.SqlQueryDS(strSql.ToString());
            #endregion

            //AboutDiv.InnerHtml = CreateAbout(ds.Tables[0]);
            //ArticleUL.InnerHtml = CreateArticle(ds.Tables[1]);
            //ProductDiv.InnerHtml = CreateProduct(ds.Tables[2]);
            //firstpane.InnerHtml = CreateCategory(ds.Tables[3]);
           // BannerDiv.InnerHtml = MojoCube.Web.Site.Cache.GetSiteBanner(strLanguage, 1);
        }
    }

    #region 创建关于
    private string CreateAbout(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            sb.Append("<div class=\"container\">");
            sb.Append("<div class=\"row\">");
            sb.Append("<div class=\"col-xs-12 col-sm-12 col-md-12\">");
            sb.Append("<div class=\"aboutBox\">");
            sb.Append("<section>");
            sb.Append("<img src=\"Files/" + dt.Rows[0]["ImagePath"].ToString() + "\" alt=\"" + dt.Rows[0]["Title"].ToString() + "\" width=\"352\" height=\"267\" />");
            sb.Append("<p class=\"aboutContent\">");
            sb.Append("<span>");
            sb.Append(dt.Rows[0]["Subtitle"].ToString());
            sb.Append("</span>");
            sb.Append("</p>");
            sb.Append("<a href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension(dt.Rows[0]["PageName"].ToString(), strLanguage) + "\" class=\"aboutMore\">更多介绍&gt;&gt;</a>");
            sb.Append("</section>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
        }

        return sb.ToString();
    }
    #endregion

    #region 创建文章
    private string CreateArticle(DataTable dt)
    {
        hlMore.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("News", strLanguage);

        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["ImagePath"].ToString() != "")
            {
                imgArticle.ImageUrl = "Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[0]["ImagePath"].ToString()) + "&w=500&h=500";
            }
            hlArticleTitle.Text = dt.Rows[0]["Title"].ToString();
            hlArticleTitle.NavigateUrl = hlArticleDetail.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("N-" + dt.Rows[0]["PageName"].ToString(), strLanguage);
            lblArticleSubtitle.Text = dt.Rows[0]["Subtitle"].ToString();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("<li class=\"col-xs-12 col-sm-12 col-md-6\">");
                sb.Append("<a href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("N-" + dt.Rows[i]["PageName"].ToString(), strLanguage) + "\" title=\"" + dt.Rows[i]["Title"].ToString() + "\">");
                sb.Append(dt.Rows[i]["Title"].ToString());
                sb.Append("</a>");
                sb.Append("</li>");
            }
        }

        return sb.ToString();
    }
    #endregion

    #region 创建产品
    private string CreateProduct(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            string url = string.Empty;
            string title = string.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                url = MojoCube.Web.Site.Cache.GetUrlExtension("P-" + dt.Rows[i]["PageName"].ToString(), strLanguage);
                title = dt.Rows[i]["ProductName"].ToString();

                sb.Append("<div class=\"col-sm-6 col-md-4 col-mm-6\">");
                sb.Append("<div class=\"productImg\">");
                sb.Append("<img src=\"Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["ImagePath"].ToString()) + "&w=500&h=500\" alt=\"" + title + "\" />");
                sb.Append("<span>");
                sb.Append(title);
                sb.Append("</span>");
                sb.Append("<a class=\"productTitle\" href=\"" + url + "\" title=\"" + title + "\">查看详情</a>");
                sb.Append("<div class=\"price_item\">" + MojoCube.Web.String.GetCurrency(decimal.Parse(dt.Rows[i]["Price"].ToString())) + "</div>");
                sb.Append("</div>");
                sb.Append("</div>");
            }
        }

        return sb.ToString();
    }
    #endregion

    #region 创建分类
    private string CreateCategory(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            DataRow[] dr;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ParentID"].ToString() == "0")
                {
                    dr = dt.Select("ParentID=" + dt.Rows[i]["pk_Category"].ToString());

                    sb.Append("<li>");
                    sb.Append("<a class=\"biglink\" href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("PC-" + dt.Rows[i]["PageName"].ToString(), strLanguage) + "\">" + dt.Rows[i]["CategoryName"].ToString() + "</a><span class=\"menu_head\">+</span>");
                    sb.Append("<ul class=\"left_snav_ul menu_body\">");
                    if (dr.Length > 0)
                    {
                        for (int j = 0; j < dr.Length; j++)
                        {
                            sb.Append("<li><a href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("PC-" + dr[j]["PageName"].ToString(), strLanguage) + "\">" + dr[j]["CategoryName"].ToString() + "</a></li>");
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