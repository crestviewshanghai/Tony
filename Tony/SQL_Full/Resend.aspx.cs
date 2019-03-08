using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;

public partial class Resend : MojoCube.Api.UI.WebPage
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
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

        MojoCube.Web.Member.List user = new MojoCube.Web.Member.List();
        if (user.ChkUser(txtPhone.Text.Trim(), txtEmail.Text.Trim()) && !user.IsCheck)
        {
            user.GetData(txtPhone.Text.Trim());
            SendMail(user.Email, user.CheckCode, user.FirstName, user.LastName, user.UserName);
            MojoCube.Api.UI.Script.ScriptMessage(this, "确认邮件已经发送，请查收邮箱！");
        }
        else if (user.pk_Member > 0 && user.IsCheck)
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "您的账号已经确认，请登录！");
        }
        else
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "该手机号没有被注册！");
        }
    }

    //发送邮件
    private void SendMail(string mailto, string code, string firstName, string lastName, string userName)
    {
        MojoCube.Web.Mail.Account account = new MojoCube.Web.Mail.Account();
        account.GetDataTypeID(0);

        MojoCube.Web.Mail.Template template = new MojoCube.Web.Mail.Template();
        template.GetDataAccountID(account.pk_Account);

        if (account.SmtpPort == 25)
        {
            MojoCube.Api.Mail.Thread mail = new MojoCube.Api.Mail.Thread();
            mail.From = account.LoginName;
            mail.DisplayName = account.DisplayName;
            mail.To = mailto;
            mail.Subject = template.Subject;
            mail.Body = ReplaceMailBody(template.Description, code, firstName, lastName, userName);
            mail.SmtpHost = account.SmtpHost;
            mail.Port = account.SmtpPort;
            mail.EnableSsl = false;
            mail.UserName = account.LoginName;
            mail.Password = MojoCube.Api.Text.Security.DecryptString(account.Password);
            mail.Send();
        }
        else
        {
            MojoCube.Api.Mail.WebMail mail = new MojoCube.Api.Mail.WebMail();
            mail.From = account.LoginName;
            mail.DisplayName = account.DisplayName;
            mail.To = mailto;
            mail.Subject = template.Subject;
            mail.Body = ReplaceMailBody(template.Description, code, firstName, lastName, userName);
            mail.SmtpHost = account.SmtpHost;
            mail.Port = account.SmtpPort;
            mail.EnableSsl = true;
            mail.UserName = account.LoginName;
            mail.Password = MojoCube.Api.Text.Security.DecryptString(account.Password);
            mail.Send();
        }
    }

    //替换邮件内容
    private string ReplaceMailBody(string mailbody, string code, string firstName, string lastName, string userName)
    {
        MojoCube.Web.ReplaceText replace = new MojoCube.Web.ReplaceText();
        replace.FirstName = firstName;
        replace.LastName = lastName;
        replace.UserName = userName;
        replace.CheckCode = code;
        return replace.Replace(mailbody);
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Login", MojoCube.Api.UI.Language.GetLanguage()));
    }
}