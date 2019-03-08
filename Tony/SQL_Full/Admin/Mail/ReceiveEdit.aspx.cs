using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Mail_ReceiveEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                hlBack.NavigateUrl = "Receive.aspx?active=" + Request.QueryString["active"];

                MojoCube.Web.Sql.DropDownListBind(ddlAccount, "Mail_Account", "AccountName", "pk_Account", null, "AccountName", "asc");

                if (Request.QueryString["id"] != null)
                {
                    ViewState["pk_Receive"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                    MojoCube.Web.Mail.Receive receive = new MojoCube.Web.Mail.Receive();
                    receive.GetData(int.Parse(ViewState["pk_Receive"].ToString()));

                    MojoCube.Web.Sql.ddlFindByValue(ddlAccount, receive.fk_Account.ToString());
                    txtNickName.Text = receive.NickName;
                    txtEmail.Text = receive.Email;
                    txtContent.Text = receive.Remark;

                    this.Title = "通知编辑：" + txtEmail.Text.Trim();
                }
                else
                {
                    this.Title = "通知编辑";
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtEmail.Text.Trim() == "" || txtNickName.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写接收邮件和昵称");
            return;
        }

        MojoCube.Web.Mail.Receive receive = new MojoCube.Web.Mail.Receive();

        //修改
        if (ViewState["pk_Receive"] != null)
        {
            receive.GetData(int.Parse(ViewState["pk_Receive"].ToString()));
            receive.fk_Account = int.Parse(ddlAccount.SelectedValue);
            receive.NickName = txtNickName.Text.Trim();
            receive.Email = txtEmail.Text.Trim();
            receive.Remark = txtContent.Text.Trim();
            receive.ModifyDate = DateTime.Now.ToString();
            receive.ModifyUserID = int.Parse(Session["UserID"].ToString());
            receive.UpdateData(receive.pk_Receive);
        }
        //新增
        else
        {
            receive.fk_Account = int.Parse(ddlAccount.SelectedValue);
            receive.NickName = txtNickName.Text.Trim();
            receive.FirstName = string.Empty;
            receive.LastName = string.Empty;
            receive.Sex = 0;
            receive.Email = txtEmail.Text.Trim();
            receive.Power = 0;
            receive.TypeID = 0;
            receive.Remark = txtContent.Text.Trim();
            receive.CreateDate = DateTime.Now.ToString();
            receive.CreateUserID = int.Parse(Session["UserID"].ToString());
            receive.ModifyDate = DateTime.Now.ToString();
            receive.ModifyUserID = 0;
            receive.InsertData();
        }

        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Receive.aspx?active=" + Request.QueryString["active"]);
    }
}