using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;
using System.Web.Security;
using System.Text.RegularExpressions;

public partial class Register : MojoCube.Api.UI.WebPage
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
            hlLogin.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Login", strLanguage);
            hlResend.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Resend", strLanguage);
            TermsDiv.InnerHtml = MojoCube.Web.Site.Cache.GetTerms(strLanguage);
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
        if (txtPhone.Text == "" || txtName.Text == "" || txtEmail.Text == "" || txtPassword1.Text.Trim() == "")
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "请填写完整");
            return;
        }

        if (!RegexPhone(txtPhone.Text.Trim()))
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "请输入正确的手机号");
            return;
        }

        if (txtPassword1.Text.Trim().Length < 6)
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "请输入至少6位密码");
            return;
        }

        if (txtPassword1.Text.Trim() != txtPassword2.Text.Trim())
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "两次密码不一致");
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

        MojoCube.Web.Member.List list = new MojoCube.Web.Member.List();

        if (!list.ChkUserName(txtPhone.Text.Trim()) && !list.ChkUserEmail(txtEmail.Text.Trim()))
        {
            list.UserName = txtPhone.Text.Trim();
            list.UserPass = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword1.Text.Trim(), "MD5").ToLower();
            list.NickName = string.Empty;
            list.FirstName = MojoCube.Web.String.GetChineseName(txtName.Text.Trim(), false);
            list.LastName = MojoCube.Web.String.GetChineseName(txtName.Text.Trim(), true);
            list.Sex = 0;
            list.Phone1 = txtPhone.Text.Trim();
            list.Phone2 = string.Empty;
            list.Mobile = txtPhone.Text.Trim();
            list.Fax = string.Empty;
            list.Country = string.Empty;
            list.CountryID = 0;
            list.Province = string.Empty;
            list.ProvinceID = 0;
            list.City = string.Empty;
            list.CityID = 0;
            list.Zip = string.Empty;
            list.Address = txtAddress.Text.Trim();
            list.Powers = string.Empty;
            list.Remark = string.Empty;
            list.Email = txtEmail.Text.Trim();
            list.IsLock = false;
            list.LastLogin = DateTime.Now.ToString();
            list.LastLoginIP = string.Empty;
            list.LoginTimes = 0;
            list.ImagePath = string.Empty;
            list.CreateDate = DateTime.Now.ToString();
            list.TypeID = 0;
            list.IsCheck = false;
            list.CheckDate = DateTime.Now.ToString();
            list.CheckCode = Guid.NewGuid().ToString();
            list.AboutMe = string.Empty;
            list.Clicks = 0;
            list.IsReceiveNews = false;
            list.IsPublic = false;
            list.IsLockBlog = false;
            list.Following = string.Empty;
            list.Followers = string.Empty;
            list.Question = string.Empty;
            list.Answer = string.Empty;
            list.Birthday = "1980-01-01 00:00:00";
            int userID = list.InsertData();

            SendMail(list.Email, list.CheckCode, list.FirstName, list.LastName, list.UserName);

            MojoCube.Web.Member.Message.Send("欢迎加入我们的会员！", "您好！这是一封系统消息，您不需要回复！祝您在我们的网站有个愉快的购物旅程！", 0, "admin", userID, list.UserName);

            btnSubmit.Enabled = false;
            btnReset.Enabled = false;
            MojoCube.Api.UI.Script.ScriptMessage(this, "恭喜您！您的账号已经创建成功，请到您的邮箱点击确认邮件完成注册！");
        }
        else
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "用户已经存在！");
        }
    }

    //获取手机正则
    private static bool RegexPhone(string text)
    {
        Regex regex = new Regex("^[0-9]{11,11}$");
        if (regex.IsMatch(text))
        {
            return true;
        }
        else
        {
            return false;
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

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Register", MojoCube.Api.UI.Language.GetLanguage()));
    }
}