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

public partial class Login : MojoCube.Api.UI.WebPage
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
            hlRegister.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Register", strLanguage);
            hlForgot.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Forgot", strLanguage);
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
        MemberLogin(txtPhone.Text.Trim(), txtPassword.Text.Trim());
    }

    private void MemberLogin(string userName, string passWord)
    {
        if (txtPhone.Text == "" || txtPassword.Text.Trim() == "")
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "请填写手机号和密码");
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

        if (userName != "" && passWord != "")
        {
            MojoCube.Web.Member.List user = new MojoCube.Web.Member.List();

            passWord = FormsAuthentication.HashPasswordForStoringInConfigFile(passWord, "MD5").ToLower().Trim();
            if (user.IsUser(userName, passWord) && !user.IsLock)
            {
                //更新用户数据
                user.SetLoginSession();
                user.LastLoginIP = MojoCube.Web.IP.Get();
                user.UpdateLastLogin(user.pk_Member);

                //记住登录信息
                MojoCube.Web.Member.List.SetLogin();

                //加入在线用户
                MojoCube.Web.Member.Online online = new MojoCube.Web.Member.Online();
                online.fk_Member = user.pk_Member;
                online.SessionID = Session.SessionID;
                online.IPAddress = MojoCube.Web.IP.Get();
                online.Browser = MojoCube.Web.String.GetBrowser();
                online.TypeID = 0;
                online.LoginTime = DateTime.Now.ToString();
                online.InsertData();

                if (Request.QueryString["url"] != null && Request.QueryString["url"] != "")
                {
                    Response.Redirect(Request.QueryString["url"]);
                }
                else
                {
                    Response.Redirect(MojoCube.Api.File.Function.GetRelativePath(MojoCube.Web.Site.Cache.GetUrlExtension("Member", MojoCube.Api.UI.Language.GetLanguage())));
                }
                Response.End();
            }
            else
            {
                MojoCube.Api.UI.Script.ScriptMessage(this, "错误的手机号或密码");
            }
        }
        else
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "错误的手机号或密码");
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Login", MojoCube.Api.UI.Language.GetLanguage()));
    }
}