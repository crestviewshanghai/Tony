using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Mail_TemplateEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                hlBack.NavigateUrl = "Template.aspx?active=" + Request.QueryString["active"];

                MojoCube.Web.Sql.DropDownListBind(ddlAccount, "Mail_Account", "AccountName", "pk_Account", null, "AccountName", "asc");

                if (Request.QueryString["id"] != null)
                {
                    ViewState["pk_Template"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                    MojoCube.Web.Mail.Template template = new MojoCube.Web.Mail.Template();
                    template.GetData(int.Parse(ViewState["pk_Template"].ToString()));

                    MojoCube.Web.Sql.ddlFindByValue(ddlAccount, template.fk_Account.ToString());
                    txtTemplateName.Text = template.TemplateName;
                    txtSubject.Text = template.Subject;
                    txtContent.Text = template.Contents;
                    txtDescription.Text = template.Description;

                    this.Title = "模板编辑：" + txtTemplateName.Text.Trim();
                }
                else
                {
                    this.Title = "模板编辑";
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtTemplateName.Text.Trim() == "" || txtSubject.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写模板名称和邮件主题");
            return;
        }

        MojoCube.Web.Mail.Template template = new MojoCube.Web.Mail.Template();

        //修改
        if (ViewState["pk_Template"] != null)
        {
            template.GetData(int.Parse(ViewState["pk_Template"].ToString()));
            template.fk_Account = int.Parse(ddlAccount.SelectedValue);
            template.TemplateName = txtTemplateName.Text.Trim();
            template.Subject = txtSubject.Text.Trim();
            template.Contents = txtContent.Text.Trim();
            template.Description = txtDescription.Text.Trim();
            template.ModifyDate = DateTime.Now.ToString();
            template.ModifyUserID = int.Parse(Session["UserID"].ToString());
            template.UpdateData(template.pk_Template);
        }
        //新增
        else
        {
            template.fk_Account = int.Parse(ddlAccount.SelectedValue);
            template.TemplateName = txtTemplateName.Text.Trim();
            template.Subject = txtSubject.Text.Trim();
            template.Contents = txtContent.Text.Trim();
            template.Description = txtDescription.Text.Trim();
            template.CreateDate = DateTime.Now.ToString();
            template.CreateUserID = int.Parse(Session["UserID"].ToString());
            template.ModifyDate = DateTime.Now.ToString();
            template.ModifyUserID = 0;
            template.InsertData();
        }

        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Template.aspx?active=" + Request.QueryString["active"]);
    }
}