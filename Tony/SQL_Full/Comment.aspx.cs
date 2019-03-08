using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;

public partial class Comment : MojoCube.Api.UI.WebPage
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
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            firstpane.InnerHtml = CreateNav();
            BannerDiv.InnerHtml = MojoCube.Web.Site.Cache.GetSiteBanner(strLanguage, 1);
        }
        this.Title = MojoCube.Web.String.GetTitle(hlTitle.Text, MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage));
    }

    #region 创建导航
    private string CreateNav()
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = new DataTable();

        ArrayList parameter = new ArrayList();
        parameter.Add(MojoCube.Web.SqlHelper.CreateParameter("@Url", "About", SqlDbType.NVarChar));
        dt = MojoCube.Web.SqlHelper.SqlQueryDS("select Url,MenuName from Site_Menu where ParentID=(select ParentID from Site_Menu where Url=@Url and TypeID=0 and ParentID>0 and Language='" + strLanguage + "') order by SortID asc", parameter).Tables[0];

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("<li>");
                sb.Append("<a class=\"biglink\" href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension(dt.Rows[i]["Url"].ToString(), strLanguage) + "\">" + dt.Rows[i]["MenuName"].ToString() + "</a><span class=\"menu_head\">+</span>");
                sb.Append("<ul class=\"left_snav_ul menu_body\"></ul>");
                sb.Append("</li>");
            }
        }

        return sb.ToString();
    }
    #endregion

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtTitle.Text == "" || txtName.Text == "" || txtPhone.Text.Trim() == "")
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "请填写完整");
            return;
        }

        //判断是否存在用户名及验证码是否正确
        if (Session["SiteCheckCode"] == null)
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "请填写验证码");
            return;
        }
        if (Session["SiteCheckCode"] != null && Session["SiteCheckCode"].ToString().ToLower() != txtCode.Text.Trim().ToLower())
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "验证码错误");
            return;
        }

        MojoCube.Web.Comment.List list = new MojoCube.Web.Comment.List();
        list.Title = txtTitle.Text.Trim();
        list.Subtitle = string.Empty;
        list.Description = CreateTemplate();
        list.Feedback = string.Empty;
        list.Visual = string.Empty;
        list.Author = txtName.Text.Trim();
        list.Email = txtEmail.Text.Trim();
        list.Phone = txtPhone.Text.Trim();
        list.Address = string.Empty;
        list.Website = string.Empty;
        list.IPAddress = MojoCube.Web.IP.Get();
        list.Browser = MojoCube.Web.String.GetBrowserInfo();
        list.Issue = true;
        list.IsComment = false;
        list.IsRecommend = false;
        list.IsRead = false;
        list.ReadDate = DateTime.Now.ToString();
        list.Clicks = 0;
        list.fk_ID = 0;
        list.SortID = 0;
        list.TypeID = 0;
        list.StatusID = 0;
        list.Score = 0;
        list.ScoreIn = 0;
        list.CreateDate = DateTime.Now.ToString();
        list.CreateUserID = 0;
        list.ModifyDate = DateTime.Now.ToString();
        list.ModifyUserID = 0;
        list.Language = MojoCube.Api.UI.Language.GetLanguage();
        list.InsertData();

        MojoCube.Api.UI.Script.ScriptMessage(this, "您的留言已提交，我们会尽快阅读！");
        btnSubmit.Enabled = false;
    }

    #region  创建模板
    private string CreateTemplate()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("<div>");
        sb.Append("<div style=\"padding:10px; background:#3C8DBC; color:#fff; font-family:'Microsoft YaHei'\">");
        sb.Append("网站留言");
        sb.Append("</div>");
        sb.Append("<table style=\"width:100%\">");
        sb.Append("<tr>");
        sb.Append("<td style=\"width:100px; padding:5px; background:#fff;\">");
        sb.Append("<b>留言标题：</b>");
        sb.Append("</td>");
        sb.Append("<td style=\"padding:5px; background:#fff;\">");
        sb.Append(txtTitle.Text.Trim());
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td style=\"width:100px; padding:5px; background:#eee;\">");
        sb.Append("<b>您的姓名：</b>");
        sb.Append("</td>");
        sb.Append("<td style=\"padding:5px; background:#eee;\">");
        sb.Append(txtName.Text.Trim());
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td style=\"width:100px; padding:5px; background:#fff;\">");
        sb.Append("<b>联系电话：</b>");
        sb.Append("</td>");
        sb.Append("<td style=\"padding:5px; background:#fff;\">");
        sb.Append(txtPhone.Text.Trim());
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td style=\"width:100px; padding:5px; background:#eee;\">");
        sb.Append("<b>电子邮箱：</b>");
        sb.Append("</td>");
        sb.Append("<td style=\"padding:5px; background:#eee;\">");
        sb.Append(txtEmail.Text.Trim());
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td style=\"width:100px; padding:5px; background:#fff;\">");
        sb.Append("<b>联系地址：</b>");
        sb.Append("</td>");
        sb.Append("<td style=\"padding:5px; background:#fff;\">");
        sb.Append(txtAddress.Text.Trim());
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td style=\"width:100px; padding:5px; background:#eee;\">");
        sb.Append("<b>留言内容：</b>");
        sb.Append("</td>");
        sb.Append("<td style=\"padding:5px; background:#eee;\">");
        sb.Append(txtContent.Text.Trim());
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td style=\"width:100px; padding:5px; background:#fff;\">");
        sb.Append("<b>系统语言：</b>");
        sb.Append("</td>");
        sb.Append("<td style=\"padding:5px; background:#fff;\">");
        sb.Append(MojoCube.Api.UI.Language.GetLanguage());
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("</table>");
        sb.Append("</div>");

        return sb.ToString();
    }
    #endregion

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Comment", MojoCube.Api.UI.Language.GetLanguage()));
    }
}