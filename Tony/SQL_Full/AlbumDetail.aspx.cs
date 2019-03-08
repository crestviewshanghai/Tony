using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;

public partial class AlbumDetail : MojoCube.Api.UI.WebPage
{
    public string strLanguage;
    public DataTable dtMain;

    protected void Page_Init(object sender, EventArgs e)
    {
        strLanguage = MojoCube.Api.UI.Language.GetLanguage();

        ArrayList parameter = new ArrayList();
        parameter.Add(MojoCube.Web.SqlHelper.CreateParameter("@PageName", Request.QueryString["pageName"], SqlDbType.NVarChar));
        dtMain = MojoCube.Web.SqlHelper.SqlQueryDS("select top 1 pk_Album,CategoryID1,CategoryID2,Title,Subtitle,Description,Clicks,SEO_Title,SEO_Keyword,SEO_Description,ImagePath,CreateDate from Album_List where PageName=@PageName and Issue=1 and Language='" + strLanguage + "'", parameter).Tables[0];

        #region  动态添加head的标签
        MojoCube.Api.Html.Header header = new MojoCube.Api.Html.Header(this.Page);
        //Meta
        string title = MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage);
        string keywords = MojoCube.Web.Site.Cache.GetSiteKeyword(strLanguage);
        string description = MojoCube.Web.Site.Cache.GetSiteDescription(strLanguage);

        if (dtMain.Rows.Count > 0)
        {
            if (dtMain.Rows[0]["SEO_Title"].ToString() != "")
            {
                title = dtMain.Rows[0]["SEO_Title"].ToString();
            }
            if (dtMain.Rows[0]["SEO_Keyword"].ToString() != "")
            {
                keywords = dtMain.Rows[0]["SEO_Keyword"].ToString();
            }
            if (dtMain.Rows[0]["SEO_Description"].ToString() != "")
            {
                description = dtMain.Rows[0]["SEO_Description"].ToString();
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
            CreateContent();
            firstpane.InnerHtml = CreateNav();

            #region  连接数据层
            StringBuilder strSql = new StringBuilder();
            //0：上一篇
            strSql.Append(" select top 1 PageName,Title from Album_List where CategoryID1=" + ViewState["CategoryID1"].ToString() + " and pk_Album<" + ViewState["pk_Album"].ToString() + " and Language='" + strLanguage + "' and Issue=1 order by CreateDate desc");
            //1：下一篇
            strSql.Append(" select top 1 PageName,Title from Album_List where CategoryID1=" + ViewState["CategoryID1"].ToString() + " and pk_Album>" + ViewState["pk_Album"].ToString() + " and Language='" + strLanguage + "' and Issue=1 order by CreateDate asc");

            DataSet ds = MojoCube.Web.Sql.SqlQueryDS(strSql.ToString());
            #endregion

            PNDiv.InnerHtml = CreatePN(ds.Tables[0], ds.Tables[1]);
            BannerDiv.InnerHtml = MojoCube.Web.Site.Cache.GetSiteBanner(strLanguage, 1);
            this.Title = MojoCube.Web.String.GetTitle(hlTitle.Text, MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage));
        }
    }

    #region 创建内容
    private void CreateContent()
    {
        if (dtMain.Rows.Count > 0)
        {
            //增加点击数
            MojoCube.Web.Sql.AddClicks("Album_List", "pk_Album=" + dtMain.Rows[0]["pk_Album"].ToString(), int.Parse(dtMain.Rows[0]["Clicks"].ToString()));

            ViewState["pk_Album"] = dtMain.Rows[0]["pk_Album"].ToString();
            ViewState["CategoryID1"] = dtMain.Rows[0]["CategoryID1"].ToString();
            ViewState["CategoryID2"] = dtMain.Rows[0]["CategoryID2"].ToString();

            MojoCube.Web.Album.Category category = new MojoCube.Web.Album.Category();
            if (ViewState["CategoryID2"].ToString() != "0")
            {
                category.GetData(int.Parse(ViewState["CategoryID2"].ToString()));
            }
            else
            {
                category.GetData(int.Parse(ViewState["CategoryID1"].ToString()));
            }
            hlTitle.Text = category.CategoryName;

            imgMain.ImageUrl = "Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(dtMain.Rows[0]["ImagePath"].ToString());

            ImageDiv.InnerHtml = CreateImageList();

            ContentDiv.InnerHtml = dtMain.Rows[0]["Description"].ToString();
        }
    }

    private string CreateImageList()
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select FilePath,Title from Album_Image where fk_Album=" + ViewState["pk_Album"].ToString() + " and Visible=1 order by SortID asc").Tables[0];

        if (dt.Rows.Count > 0)
        {
            string imagePath = string.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                imagePath = "Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["FilePath"].ToString());

                sb.Append("<div><img src=\"" + imagePath + "\" /></div>");
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

    #region  上下一篇
    private string CreatePN(DataTable dt1, DataTable dt2)
    {
        StringBuilder sb = new StringBuilder();

        //上一篇
        if (dt1.Rows.Count > 0)
        {
            sb.Append("<div class='prevBox'>上一篇：<a title='" + dt1.Rows[0]["Title"].ToString() + "' href='" + MojoCube.Web.Site.Cache.GetUrlExtension("A-" + dt1.Rows[0]["PageName"].ToString(), strLanguage) + "'>" + dt1.Rows[0]["Title"].ToString() + "</a></div>");
        }

        //下一篇
        if (dt2.Rows.Count > 0)
        {
            sb.Append("<div class='nextBox'>下一篇：<a title='" + dt2.Rows[0]["Title"].ToString() + "' href='" + MojoCube.Web.Site.Cache.GetUrlExtension("A-" + dt2.Rows[0]["PageName"].ToString(), strLanguage) + "'>" + dt2.Rows[0]["Title"].ToString() + "</a></div>");
        }

        return sb.ToString();
    }
    #endregion
}