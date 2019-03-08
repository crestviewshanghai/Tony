using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_User_Edit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "List.aspx?active=" + Request.QueryString["active"];

            MojoCube.Web.Sql.DropDownListBind(ddlDepartment, "User_Department", "DepartmentName", "pk_Department", "fk_Company=0", "SortID", "asc");

            MojoCube.Web.Sql.DropDownListBind(ddlPosition, "User_Position", "Title", "pk_Position", "fk_Company=0", "SortID", "desc");

            MojoCube.Web.Sql.DropDownListBind(ddlRole, "Role_Name", "RoleName_CHS", "pk_Name", "fk_Company=0", "PowerValue", "desc");

            if (Request.QueryString["id"] != null)
            {
                EditDiv.Visible = true;

                ViewState["pk_User"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.User.List list = new MojoCube.Web.User.List();
                list.GetData(int.Parse(ViewState["pk_User"].ToString()));

                txtName.Text = list.UserName;
                txtPhone1.Text = list.Phone1;
                txtNickName.Text = list.NickName;
                txtFullName.Text = list.FullName;
                txtEmail1.Text = list.Email1;
                txtAddress1.Text = list.Address1;
                txtEducation.Text = list.Education;
                txtSchool.Text = list.School;
                txtBankAccount.Text = list.BankAccount;
                txtIDNumber.Text = list.IDNumber;
                MojoCube.Web.Sql.ddlFindByValue(ddlDepartment, list.fk_Department.ToString());
                MojoCube.Web.Sql.ddlFindByValue(ddlPosition, list.Position.ToString());
                MojoCube.Web.Sql.ddlFindByValue(ddlRole, list.RoleValue.ToString());
                txtWages.Text = list.Wages.ToString("N2");
                txtEntryTime.Text = DateTime.Parse(list.EntryTime).ToString("yyyy-MM-dd");
                txtBirthday.Text = DateTime.Parse(list.Birthday).ToString("yyyy-MM-dd");
                MojoCube.Web.Sql.ddlFindByValue(ddlSkin, list.Skin);
                MojoCube.Web.Sql.ddlFindByValue(ddlSex, list.Sex.ToString());

                if (list.ImagePath1 != "")
                {
                    imgPortrait.ImageUrl = "~/Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(list.ImagePath1) + "&cut=200,200";
                }
                else
                {
                    imgPortrait.ImageUrl = "~/Images/user.png";
                }

                this.Title = "用户编辑：" + txtName.Text.Trim();
            }
            else
            {
                txtBankAccount.Text = "（工行）";
                txtEntryTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.Title = "用户编辑";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写名称");
            return;
        }

        MojoCube.Web.User.List list = new MojoCube.Web.User.List();

        //修改
        if (ViewState["pk_User"] != null)
        {
            MojoCube.Api.File.Upload upload = new MojoCube.Api.File.Upload();
            upload.FilePath = "User/" + ViewState["pk_User"].ToString();
            upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
            upload.DoFileUpload(fuPortrait);

            list.GetData(int.Parse(ViewState["pk_User"].ToString()));

            if (cbResetPsw.Checked)
            {
                list.Password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5").ToLower();
            }

            list.fk_Department = int.Parse(ddlDepartment.SelectedValue);
            list.RoleValue = int.Parse(ddlRole.SelectedValue);
            list.RoleList = ddlRole.SelectedValue;
            list.Position = int.Parse(ddlPosition.SelectedValue);
            list.UserName = txtName.Text.Trim();
            list.NickName = txtNickName.Text.Trim();
            list.FullName = txtFullName.Text.Trim();
            list.FirstName = MojoCube.Web.String.GetChineseName(txtFullName.Text.Trim(), false);
            list.LastName = MojoCube.Web.String.GetChineseName(txtFullName.Text.Trim(), true);
            list.Phone1 = txtPhone1.Text.Trim();
            list.Email1 = txtEmail1.Text.Trim();
            list.Address1 = txtAddress1.Text.Trim();
            list.Birthday = txtBirthday.Text.Trim();
            list.Education = txtEducation.Text.Trim();
            list.School = txtSchool.Text.Trim();
            list.BankAccount = txtBankAccount.Text.Trim();
            list.IDNumber = txtIDNumber.Text.Trim();
            list.Wages = MojoCube.Web.String.ToDecimal(txtWages.Text.Trim());
            list.EntryTime = txtEntryTime.Text.Trim();
            list.Skin = ddlSkin.SelectedValue;
            list.Sex = int.Parse(ddlSex.SelectedValue);

            if (upload.IsUpload)
            {
                list.ImagePath1 = upload.OldFilePath;
            }

            list.ModifyUser = int.Parse(Session["UserID"].ToString());
            list.ModifyDate = DateTime.Now.ToString();
            list.UpdateData(list.pk_User);
        }
        //新增
        else
        {
            list.UserName = txtName.Text.Trim();
            list.Password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5").ToLower();
            list.TypeID = 0;
            list.fk_Department = int.Parse(ddlDepartment.SelectedValue);
            list.RoleValue = int.Parse(ddlRole.SelectedValue);
            list.RoleList = ddlRole.SelectedValue;
            list.Position = int.Parse(ddlPosition.SelectedValue);
            list.Number = string.Empty;
            list.Skin = ddlSkin.SelectedValue;
            list.Language = "CHS";
            list.IsLock = false;
            list.LastLoginIP = string.Empty;
            list.LastLoginTime = DateTime.Now.ToString();
            list.NickName = txtNickName.Text.Trim();
            list.FullName = txtFullName.Text.Trim();
            list.FirstName = MojoCube.Web.String.GetChineseName(txtFullName.Text.Trim(), false);
            list.MiddleName = string.Empty;
            list.LastName = MojoCube.Web.String.GetChineseName(txtFullName.Text.Trim(), true);
            list.Phone1 = txtPhone1.Text.Trim();
            list.Phone2 = string.Empty;
            list.Email1 = txtEmail1.Text.Trim();
            list.Email2 = string.Empty;
            list.Fax = string.Empty;
            list.Line = string.Empty;
            list.Wechat = string.Empty;
            list.QQ = string.Empty;
            list.Facebook = string.Empty;
            list.Twitter = string.Empty;
            list.Linkedin = string.Empty;
            list.ZipCode = string.Empty;
            list.Place = string.Empty;
            list.Address1 = txtAddress1.Text.Trim();
            list.Address2 = string.Empty;
            list.Province = 0;
            list.City = 0;
            list.County = 0;
            list.Zone = 0;
            list.Sex = int.Parse(ddlSex.SelectedValue);
            list.Height = 0;
            list.Weight = 0;
            list.Birthday = txtBirthday.Text.Trim();
            list.Education = txtEducation.Text.Trim();
            list.School = txtSchool.Text.Trim();
            list.ImagePath1 = string.Empty;
            list.ImagePath2 = string.Empty;
            list.IDCardPath = string.Empty;
            list.ResumePath = string.Empty;
            list.Wages = MojoCube.Web.String.ToDecimal(txtWages.Text.Trim());
            list.BankAccount = txtBankAccount.Text.Trim();
            list.IDNumber = txtIDNumber.Text.Trim();
            list.Source = string.Empty;
            list.Note = string.Empty;
            list.Remark = string.Empty;
            list.EntryTime = txtEntryTime.Text.Trim();
            list.IsQuit = false;
            list.QuitTime = DateTime.Now.ToString();
            list.fk_Company = 0;
            list.CreateUser = int.Parse(Session["UserID"].ToString());
            list.CreateDate = DateTime.Now.ToString();
            list.ModifyUser = 0;
            list.ModifyDate = DateTime.Now.ToString();
            list.InsertData();
        }

        Response.Redirect("List.aspx?active=" + Request.QueryString["active"]);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("List.aspx?active=" + Request.QueryString["active"]);
    }
}