using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_Member_Edit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "List.aspx?active=" + Request.QueryString["active"];

            if (Request.QueryString["id"] != null)
            {
                EditDiv.Visible = true;

                ViewState["pk_Member"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Member.List list = new MojoCube.Web.Member.List();
                list.GetData(int.Parse(ViewState["pk_Member"].ToString()));

                txtName.Text = list.UserName;
                txtPhone.Text = list.Phone1;
                txtLastName.Text = list.LastName;
                txtFirstName.Text = list.FirstName;
                txtEmail.Text = list.Email;
                txtAddress.Text = list.Address;
                txtBirthday.Text = DateTime.Parse(list.Birthday).ToString("yyyy-MM-dd");
                MojoCube.Web.Sql.ddlFindByValue(ddlSex, list.Sex.ToString());

                if (list.ImagePath != "")
                {
                    imgPortrait.ImageUrl = "../Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(list.ImagePath) + "&cut=200,200";
                }
                else
                {
                    imgPortrait.ImageUrl = "../Images/user.png";
                }

                this.Title = "会员编辑：" + txtName.Text.Trim();
            }
            else
            {
                txtBirthday.Text = "1980-01-01";
                this.Title = "会员编辑";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写用户名");
            return;
        }

        MojoCube.Web.Member.List list = new MojoCube.Web.Member.List();

        //修改
        if (ViewState["pk_Member"] != null)
        {
            MojoCube.Api.File.Upload upload = new MojoCube.Api.File.Upload();
            upload.FilePath = "Member/" + ViewState["pk_Member"].ToString();
            upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
            upload.DoFileUpload(fuPortrait);

            list.GetData(int.Parse(ViewState["pk_Member"].ToString()));

            if (cbResetPsw.Checked)
            {
                list.UserPass = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5").ToLower();
            }

            list.UserName = txtName.Text.Trim();
            list.FirstName = txtFirstName.Text.Trim();
            list.LastName = txtLastName.Text.Trim();
            list.Phone1 = txtPhone.Text.Trim();
            list.Mobile = txtPhone.Text.Trim();
            list.Email = txtEmail.Text.Trim();
            list.Address = txtAddress.Text.Trim();
            list.Birthday = txtBirthday.Text.Trim() + " 00:00:00";
            list.Sex = int.Parse(ddlSex.SelectedValue);

            if (upload.IsUpload)
            {
                list.ImagePath = upload.OldFilePath;
            }

            list.UpdateData(list.pk_Member);
        }
        //新增
        else
        {
            list.UserName = txtPhone.Text.Trim();
            list.UserPass = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5").ToLower();
            list.NickName = string.Empty;
            list.FirstName = txtFirstName.Text.Trim();
            list.LastName = txtLastName.Text.Trim();
            list.Sex = int.Parse(ddlSex.SelectedValue);
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
            list.IsCheck = true;
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
            list.Birthday = txtBirthday.Text.Trim() + " 00:00:00";
            list.InsertData();
        }

        Response.Redirect("List.aspx?active=" + Request.QueryString["active"]);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("List.aspx?active=" + Request.QueryString["active"]);
    }
}