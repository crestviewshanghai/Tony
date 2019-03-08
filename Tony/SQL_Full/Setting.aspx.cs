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

public partial class Setting : MojoCube.Api.UI.WebPage
{
    public string strLanguage;

    protected void Page_Init(object sender, EventArgs e)
    {
        strLanguage = MojoCube.Api.UI.Language.GetLanguage();

        MojoCube.Web.Member.List.ChkLogin();

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
            WUC_MemberMenu.CssFocus = "id=\"Menu5\"";
            BannerDiv.InnerHtml = MojoCube.Web.Site.Cache.GetSiteBanner(strLanguage, 1);

            MojoCube.Web.Member.List list = new MojoCube.Web.Member.List();
            list.GetData(int.Parse(Session["Member_UserID"].ToString()));

            txtPhone.Text = list.Phone1;
            txtName.Text = list.LastName + list.FirstName;
            txtEmail.Text = list.Email;
            txtAddress.Text = list.Address;
            imgPortrait.ImageUrl = "Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(Session["Member_UserImagePath"].ToString());
        }
        this.Title = MojoCube.Web.String.GetTitle(hlTitle.Text, MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage));
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtPhone.Text == "" || txtName.Text == "" || txtEmail.Text == "" || txtPassword.Text.Trim() == "")
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "请填写完整");
            return;
        }

        if (!RegexPhone(txtPhone.Text.Trim()))
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "请输入正确的手机号");
            return;
        }

        if (txtPassword1.Text.Trim() != "" && txtPassword1.Text.Trim().Length < 6)
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "请输入至少6位密码");
            return;
        }

        if (txtPassword1.Text.Trim() != txtPassword2.Text.Trim())
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "两次密码不一致");
            return;
        }

        MojoCube.Web.Member.List list = new MojoCube.Web.Member.List();
        list.GetData(int.Parse(Session["Member_UserID"].ToString()));

        if (list.ChkUserName(txtPhone.Text.Trim()) && list.Phone1 != txtPhone.Text.Trim())
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "手机号已存在！");
            return;
        }

        if (list.ChkUserEmail(txtEmail.Text.Trim()) && list.Email != txtEmail.Text.Trim())
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "邮件已存在！");
            return;
        }

        if (list.IsUser(txtPhone.Text.Trim(), FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5").ToLower().Trim()) && !list.IsLock)
        {
            list.UserName = txtPhone.Text.Trim();
            list.Address = txtAddress.Text.Trim();
            list.FirstName = MojoCube.Web.String.GetChineseName(txtName.Text.Trim(), false);
            list.LastName = MojoCube.Web.String.GetChineseName(txtName.Text.Trim(), true);
            list.Phone1 = txtPhone.Text.Trim();
            list.Email = txtEmail.Text.Trim();
            if (txtPassword1.Text.Trim() != "")
            {
                list.UserPass = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword1.Text.Trim(), "MD5").ToLower();
            }

            MojoCube.Api.File.Upload upload = new MojoCube.Api.File.Upload();
            upload.FilePath = "Member/" + list.pk_Member;
            upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
            upload.DoFileUpload(fuPortrait);

            if (upload.IsUpload)
            {
                list.ImagePath = upload.OldFilePath;
                Session["Member_UserImagePath"] = list.ImagePath;
                imgPortrait.ImageUrl = "Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(Session["Member_UserImagePath"].ToString());
            }

            list.UpdateData(list.pk_Member);
            MojoCube.Api.UI.Script.ScriptMessage(this, "修改成功！");
        }
        else
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "密码错误！");
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

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Logout", MojoCube.Api.UI.Language.GetLanguage()));
    }
}