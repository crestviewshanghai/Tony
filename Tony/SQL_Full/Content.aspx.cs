using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;

public partial class Content : MojoCube.Api.UI.WebPage
{
    public string strLanguage;
    public DataTable dtMain;

    protected void Page_Init(object sender, EventArgs e)
    {
        strLanguage = MojoCube.Api.UI.Language.GetLanguage();

        ArrayList parameter = new ArrayList();
        parameter.Add(MojoCube.Web.SqlHelper.CreateParameter("@PageName", Request.QueryString["pageName"], SqlDbType.NVarChar));
        dtMain = MojoCube.Web.SqlHelper.SqlQueryDS("select top 1 Title,Description,SEO_Title,SEO_Keyword,SEO_Description,PageName from Content_List where PageName=@PageName and Visible=1 and Language='" + strLanguage + "'", parameter).Tables[0];

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
            lblContent.Text = CreateContent();
            firstpane.InnerHtml = CreateNav();
            BannerDiv.InnerHtml = MojoCube.Web.Site.Cache.GetSiteBanner(strLanguage, 1);
            this.Title = MojoCube.Web.String.GetTitle(hlTitle.Text, MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage));
        }
    }

    #region 创建内容
    private string CreateContent()
    {
        StringBuilder sb = new StringBuilder();

        if (dtMain.Rows.Count > 0)
        {
            ViewState["PageName"] = dtMain.Rows[0]["PageName"].ToString();

            hlTitle.Text = dtMain.Rows[0]["Title"].ToString();
            hlTitle.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension(ViewState["PageName"].ToString(), strLanguage);

            sb.Append(dtMain.Rows[0]["Description"].ToString());
        }

        return sb.ToString();
    }
    #endregion

    #region 创建导航
    private string CreateNav()
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = new DataTable();

        ArrayList parameter = new ArrayList();
        parameter.Add(MojoCube.Web.SqlHelper.CreateParameter("@Url", Request.QueryString["pageName"], SqlDbType.NVarChar));
        dt = MojoCube.Web.SqlHelper.SqlQueryDS("select Url,MenuName from Site_Menu where ParentID=(select ParentID from Site_Menu where Url=@Url and TypeID=0 and ParentID>0 and Language='" + strLanguage + "') order by SortID asc", parameter).Tables[0];

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("<li>");
                if (ViewState["PageName"].ToString() == dt.Rows[i]["Url"].ToString())
                {
                    sb.Append("<a class=\"firstSelected selected\" href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension(dt.Rows[i]["Url"].ToString(), strLanguage) + "\">" + dt.Rows[i]["MenuName"].ToString() + "</a>");
                }
                else
                {
                    sb.Append("<a href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension(dt.Rows[i]["Url"].ToString(), strLanguage) + "\">" + dt.Rows[i]["MenuName"].ToString() + "</a>");
                }
                sb.Append("</li>");
            }
        }

        return sb.ToString();
    }
    #endregion
}