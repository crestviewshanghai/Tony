using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //用户名
        string userName = txtUserName.Text.ToLower().Trim();
        //密码
        string password = txtPassword.Text.Trim();
        //验证码
        string checkCode = txtCode.Text.Trim().ToLower();

        //判断是否存在用户名及验证码是否正确

        if (userName == "" || password == "" || checkCode == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("info", "请填写完整信息");
            return;
        }

        if (Session["CheckCode"] == null)
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请输入验证码");
            return;
        }

        if (Session["CheckCode"] != null && Session["CheckCode"].ToString().ToLower() != checkCode)
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "错误的验证码");
            return;
        }

        //MD5加密
        password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5").ToLower().Trim();

        MojoCube.Web.User.Login login = new MojoCube.Web.User.Login();

        if (login.IsUser(userName, password))
        {
            if (!login.IsLock)
            {
                MojoCube.Web.User.Login.UpdateLastLogin(login.pk_User.ToString());
                Session["UserID"] = login.pk_User.ToString();
                Session["UserName"] = login.UserName;
                Session["FullName"] = login.FullName;
                Session["RoleValue"] = login.RoleValue;
                Session["DepartmentID"] = login.fk_Department;
                if (cbRemember.Checked)
                {
                    MojoCube.Web.User.Login.SetLogin();
                }
                MojoCube.Web.User.Online.AddOnline(0);
                Response.Redirect("Dashboard/Default.aspx");
            }
            else
            {
                AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "账号被锁定");
            }
        }
        else
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "用户名或密码错误");
        }
    }
}