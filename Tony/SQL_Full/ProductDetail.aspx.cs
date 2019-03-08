using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;

public partial class ProductDetail : MojoCube.Api.UI.WebPage
{
    public string strLanguage;
    public DataTable dtMain;

    protected void Page_Init(object sender, EventArgs e)
    {
        strLanguage = MojoCube.Api.UI.Language.GetLanguage();

        ArrayList parameter = new ArrayList();
        parameter.Add(MojoCube.Web.SqlHelper.CreateParameter("@PageName", Request.QueryString["pageName"], SqlDbType.NVarChar));
        dtMain = MojoCube.Web.SqlHelper.SqlQueryDS("select top 1 pk_Product,CategoryID1,CategoryID2,ProductName,Number,Subtitle,Description,Clicks,SEO_Title,SEO_Keyword,SEO_Description,ImagePath,Attribute,CreateDate,Price,IsComment from Product_List where PageName=@PageName and Issue=1 and Language='" + strLanguage + "'", parameter).Tables[0];

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
            detailvalue0.InnerHtml = CreateContent();
            firstpane.InnerHtml = CreateNav();

            #region  连接数据层
            StringBuilder strSql = new StringBuilder();
            //0：上一篇
            strSql.Append(" select top 1 PageName,ProductName from Product_List where CategoryID1=" + ViewState["CategoryID1"].ToString() + " and pk_Product<" + ViewState["pk_Product"].ToString() + " and Language='" + strLanguage + "' and Issue=1 order by CreateDate desc");
            //1：下一篇
            strSql.Append(" select top 1 PageName,ProductName from Product_List where CategoryID1=" + ViewState["CategoryID1"].ToString() + " and pk_Product>" + ViewState["pk_Product"].ToString() + " and Language='" + strLanguage + "' and Issue=1 order by CreateDate asc");
            //2：评论
            strSql.Append(" select * from View_Comment_List where fk_ID=" + ViewState["pk_Product"].ToString() + " and Language='" + strLanguage + "' order by CreateDate asc");

            DataSet ds = MojoCube.Web.Sql.SqlQueryDS(strSql.ToString());
            #endregion

            PNDiv.InnerHtml = CreatePN(ds.Tables[0], ds.Tables[1]);
            if (bool.Parse(ViewState["IsComment"].ToString()))
            {
                CommentDiv.InnerHtml = CreateComment(ds.Tables[2]);
            }
            BannerDiv.InnerHtml = MojoCube.Web.Site.Cache.GetSiteBanner(strLanguage, 1);
            this.Title = MojoCube.Web.String.GetTitle(hlTitle.Text, MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage));

            if (Session["Member_UserID"] != null)
            {
                hlCart.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("CartAdd", strLanguage) + "?add=" + MojoCube.Api.Text.Security.EncryptString(dtMain.Rows[0]["pk_Product"].ToString());
                hlFavorite.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("FavoriteAdd", strLanguage) + "?add=" + MojoCube.Api.Text.Security.EncryptString(dtMain.Rows[0]["pk_Product"].ToString());
            }
            else
            {
                hlCart.NavigateUrl = "javascript:alert('请先登录商城账号')";
                hlFavorite.NavigateUrl = "javascript:alert('请先登录商城账号')";
            }
        }
    }

    #region 创建内容
    private string CreateContent()
    {
        StringBuilder sb = new StringBuilder();

        if (dtMain.Rows.Count > 0)
        {
            //增加点击数
            MojoCube.Web.Sql.AddClicks("Product_List", "pk_Product=" + dtMain.Rows[0]["pk_Product"].ToString(), int.Parse(dtMain.Rows[0]["Clicks"].ToString()));

            ViewState["pk_Product"] = dtMain.Rows[0]["pk_Product"].ToString();
            ViewState["CategoryID1"] = dtMain.Rows[0]["CategoryID1"].ToString();
            ViewState["CategoryID2"] = dtMain.Rows[0]["CategoryID2"].ToString();
            ViewState["IsComment"] = dtMain.Rows[0]["IsComment"].ToString();

            MojoCube.Web.Product.Category category = new MojoCube.Web.Product.Category();
            if (ViewState["CategoryID2"].ToString() != "0")
            {
                category.GetData(int.Parse(ViewState["CategoryID2"].ToString()));
            }
            else
            {
                category.GetData(int.Parse(ViewState["CategoryID1"].ToString()));
            }
            hlTitle.Text = category.CategoryName;

            ImageDiv.InnerHtml = CreateImageList(dtMain.Rows[0]["ImagePath"].ToString());

            sb.Append("<ul class=\"attribute\">");

            sb.Append("<li>产品价格：<span class=\"price\" style=\"font-size:18pt;\">" + MojoCube.Web.String.GetCurrency(decimal.Parse(dtMain.Rows[0]["Price"].ToString())) + "</span></li>");

            sb.Append("<li>产品编号：" + dtMain.Rows[0]["Number"].ToString() + "</li>");

            string[] attribute = dtMain.Rows[0]["Attribute"].ToString().Split('|');

            if (attribute.Length > 0)
            {
                for (int i = 0; i < attribute.Length; i++)
                {
                    if (attribute[i] != "")
                    {
                        sb.Append("<li>" + attribute[i] + "</li>");
                    }
                }
            }

            sb.Append("<li>浏览：" + dtMain.Rows[0]["Clicks"].ToString() + "</li>");
            sb.Append("<li>上架：" + DateTime.Parse(dtMain.Rows[0]["CreateDate"].ToString()).ToString("yyyy-MM-dd") + "</li>");
            sb.Append("<li>" + dtMain.Rows[0]["Subtitle"].ToString() + "</li>");
            sb.Append("</ul>");

            lblTitle.Text = dtMain.Rows[0]["ProductName"].ToString();

            AttributeDiv.InnerHtml = sb.ToString();

            sb.Clear();
            sb.Append(dtMain.Rows[0]["Description"].ToString());
        }

        return sb.ToString();
    }

    private string CreateImageList(string imgPath)
    {
        imgPath = "Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(imgPath);

        StringBuilder sb = new StringBuilder();

        DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select FilePath from Product_Image where fk_Product=" + ViewState["pk_Product"].ToString() + " and Visible=1 order by SortID asc").Tables[0];

        sb.Append("<ul class=\"slider__wrapper\">");
        sb.Append("<li data-responsive='' data-src='" + imgPath + "' data-sub-html='' class='slider__item real'><a><img src='" + imgPath + "'></a></li>");
        if (dt.Rows.Count > 0)
        {
            string imagePath = string.Empty;
            string imageTitle = string.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                imagePath = "Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["FilePath"].ToString());
                sb.Append("<li data-responsive='' data-src='" + imagePath + "' data-sub-html='' class='slider__item real'><a><img src='" + imagePath + "'></a></li>");
            }
        }
        sb.Append("</ul>");

        return sb.ToString();
    }
    #endregion

    #region 创建导航
    private string CreateNav()
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = new DataTable();

        dt = MojoCube.Web.Sql.SqlQueryDS("select * from Product_Category where Visible=1 and Language='" + strLanguage + "' order by SortID asc").Tables[0];

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

    #region  上下一篇
    private string CreatePN(DataTable dt1, DataTable dt2)
    {
        StringBuilder sb = new StringBuilder();

        //上一篇
        if (dt1.Rows.Count > 0)
        {
            sb.Append("<div class='prevBox'>上一个：<a title='" + dt1.Rows[0]["ProductName"].ToString() + "' href='" + MojoCube.Web.Site.Cache.GetUrlExtension("P-" + dt1.Rows[0]["PageName"].ToString(), strLanguage) + "'>" + dt1.Rows[0]["ProductName"].ToString() + "</a></div>");
        }

        //下一篇
        if (dt2.Rows.Count > 0)
        {
            sb.Append("<div class='nextBox'>下一个：<a title='" + dt2.Rows[0]["ProductName"].ToString() + "' href='" + MojoCube.Web.Site.Cache.GetUrlExtension("P-" + dt2.Rows[0]["PageName"].ToString(), strLanguage) + "'>" + dt2.Rows[0]["ProductName"].ToString() + "</a></div>");
        }

        return sb.ToString();
    }
    #endregion

    #region  创建评论
    private string CreateComment(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            sb.Append("<table style=\"width:100%\">");

            string img = string.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ImagePath"].ToString() != "")
                {
                    img = "Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["ImagePath"].ToString());
                }
                else
                {
                    img = "Admin/Images/user.png";
                }

                if (i == dt.Rows.Count - 1)
                {
                    sb.Append("<tr>");
                }
                else
                {
                    sb.Append("<tr class=\"comment-row\">");
                }
                sb.Append("<td style=\"width:100px;\" valign=\"top\">");
                sb.Append("<div class=\"comment-img\"><img src=\"" + img + "\" /></div>");
                sb.Append("<div class=\"comment-name\">*" + dt.Rows[i]["FirstName"].ToString() + "</div>");
                sb.Append("</td>");
                sb.Append("<td valign=\"top\">");
                sb.Append("<div class=\"comment-date\">");
                sb.Append(DateTime.Parse(dt.Rows[i]["CreateDate"].ToString()).ToString("yyyy年MM月dd日 HH:mm"));
                sb.Append("</div>");
                sb.Append(GetScore(dt.Rows[i]["Score"].ToString()));
                sb.Append("<div class=\"comment-content\">");
                sb.Append(dt.Rows[i]["Description"].ToString());
                sb.Append("</div>");
                if (dt.Rows[i]["Feedback"].ToString() != "")
                {
                    sb.Append("<div class=\"comment-feedback\">");
                    sb.Append("[商家回复] " + dt.Rows[i]["Feedback"].ToString());
                    sb.Append("</div>");
                }
                sb.Append("</td>");
                sb.Append("</tr>");
            }

            sb.Append("</table>");
        }

        return sb.ToString();
    }

    private string GetScore(string score)
    {
        string text = "";

        switch (score)
        {
            case "1":
                text = "<div class=\"comment-score\">★☆☆☆☆</div>";
                break;
            case "2":
                text = "<div class=\"comment-score\">★★☆☆☆</div>";
                break;
            case "3":
                text = "<div class=\"comment-score\">★★★☆☆</div>";
                break;
            case "4":
                text = "<div class=\"comment-score\">★★★★☆</div>";
                break;
            case "5":
                text = "<div class=\"comment-score\">★★★★★</div>";
                break;
        }

        return text;
    }
    #endregion
}