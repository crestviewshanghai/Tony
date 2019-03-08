using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Mail_AccountEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "Account.aspx?active=" + Request.QueryString["active"];

            MojoCube.Web.Sql.DropDownListBind(ddlType, "Sys_TypeID", "TypeName_CHS", "ID", "TableName='Mail_Account'", "ID", "asc");

            MojoCube.Web.Sql.DropDownListBind(ddlStatus, "Sys_StatusID", "StatusName_CHS", "ID", "TableName='Mail_Account'", "ID", "asc");

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Account"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Mail.Account account = new MojoCube.Web.Mail.Account();
                account.GetData(int.Parse(ViewState["pk_Account"].ToString()));

                MojoCube.Web.Sql.ddlFindByValue(ddlType, account.TypeID.ToString());
                MojoCube.Web.Sql.ddlFindByValue(ddlStatus, account.StatusID.ToString());
                txtAccountName.Text = account.AccountName;
                txtDisplayName.Text = account.DisplayName;
                txtSmtpHost.Text = account.SmtpHost;
                txtSmtpPort.Text = account.SmtpPort.ToString();
                txtLoginName.Text = account.LoginName;
                txtPassword.Attributes.Add("value", MojoCube.Api.Text.Security.DecryptString(account.Password));
                txtNote.Text = account.Remark;

                this.Title = "账号编辑：" + txtAccountName.Text.Trim();
            }
            else
            {
                this.Title = "账号编辑";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtAccountName.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写名称");
            return;
        }

        MojoCube.Web.Mail.Account account = new MojoCube.Web.Mail.Account();

        //修改
        if (ViewState["pk_Account"] != null)
        {
            account.GetData(int.Parse(ViewState["pk_Account"].ToString()));

            account.TypeID = int.Parse(ddlType.SelectedValue);
            account.StatusID = int.Parse(ddlStatus.SelectedValue);
            account.AccountName = txtAccountName.Text.Trim();
            account.DisplayName = txtDisplayName.Text.Trim();
            account.SmtpHost = txtSmtpHost.Text.Trim();
            account.SmtpPort = MojoCube.Web.String.ToInt(txtSmtpPort.Text.Trim());
            account.LoginName = txtLoginName.Text.Trim();
            account.Password = MojoCube.Api.Text.Security.EncryptString(txtPassword.Text.Trim());
            account.SmtpPwd = MojoCube.Api.Text.Security.EncryptString(txtPassword.Text.Trim());
            account.SmtpUser = txtLoginName.Text.Trim();
            account.Remark = txtNote.Text.Trim();
            account.ModifyUserID = int.Parse(Session["UserID"].ToString());
            account.ModifyDate = DateTime.Now.ToString();
            account.UpdateData(account.pk_Account);
        }
        //新增
        else
        {
            account.TypeID = int.Parse(ddlType.SelectedValue);
            account.StatusID = int.Parse(ddlStatus.SelectedValue);
            account.AccountName = txtAccountName.Text.Trim();
            account.DisplayName = txtDisplayName.Text.Trim();
            account.PopHost = string.Empty;
            account.Port = 110;
            account.UseSSL = false;
            account.SmtpHost = txtSmtpHost.Text.Trim();
            account.SmtpPort = MojoCube.Web.String.ToInt(txtSmtpPort.Text.Trim());
            account.LoginName = txtLoginName.Text.Trim();
            account.Password = MojoCube.Api.Text.Security.EncryptString(txtPassword.Text.Trim());
            account.SmtpPwd = MojoCube.Api.Text.Security.EncryptString(txtPassword.Text.Trim());
            account.SmtpUser = txtLoginName.Text.Trim();
            account.SmtpUseSSL = false;
            account.Signature = string.Empty;
            account.Remark = txtNote.Text.Trim();
            account.CreateUserID = int.Parse(Session["UserID"].ToString());
            account.CreateDate = DateTime.Now.ToString();
            account.ModifyUserID = 0;
            account.ModifyDate = DateTime.Now.ToString();
            account.InsertData();
        }

        Response.Redirect("Account.aspx?active=" + Request.QueryString["active"]);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Account.aspx?active=" + Request.QueryString["active"]);
    }
}