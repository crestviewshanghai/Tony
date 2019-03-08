using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SMS_Edit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "List.aspx?active=" + Request.QueryString["active"];

            MojoCube.Web.Sql.DropDownListBind(ddlType, "Sys_TypeID", "TypeName_CHS", "ID", "TableName='SMS_List'", "ID", "asc");

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_SMS"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.SMS.List list = new MojoCube.Web.SMS.List();
                list.GetData(int.Parse(ViewState["pk_SMS"].ToString()));

                txtTitle.Text = list.Title;
                txtSubtitle.Text = list.Subtitle;
                txtContents.Text = list.Contents;
                txtGateway.Text = list.Gateway;
                txtAppID.Text = list.AppID;
                txtKeyCode.Text = list.KeyCode;
                txtSortID.Text = list.SortID.ToString();
                cbVisible.Checked = list.Visible;

                MojoCube.Web.Sql.ddlFindByValue(ddlType, list.TypeID.ToString());

                this.Title = "接口编辑：" + txtTitle.Text.Trim();
            }
            else
            {
                this.Title = "接口编辑";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtTitle.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写标题");
            return;
        }

        MojoCube.Web.SMS.List list = new MojoCube.Web.SMS.List();

        //修改
        if (ViewState["pk_SMS"] != null)
        {
            list.GetData(int.Parse(ViewState["pk_SMS"].ToString()));
            list.Title = txtTitle.Text.Trim();
            list.Subtitle = txtSubtitle.Text.Trim();
            list.Contents = txtContents.Text.Trim();
            list.TypeID = int.Parse(ddlType.SelectedValue);
            list.Gateway = txtGateway.Text.Trim();
            list.AppID = txtAppID.Text.Trim();
            list.KeyCode = txtKeyCode.Text.Trim();
            list.Visible = cbVisible.Checked;
            list.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            list.ModifyDate = DateTime.Now.ToString();
            list.ModifyUserID = int.Parse(Session["UserID"].ToString());
            list.UpdateData(list.pk_SMS);
        }
        //新增
        else
        {
            list.Title = txtTitle.Text.Trim();
            list.Subtitle = txtSubtitle.Text.Trim();
            list.Contents = txtContents.Text.Trim();
            list.TypeID = int.Parse(ddlType.SelectedValue);
            list.Gateway = txtGateway.Text.Trim();
            list.AppID = txtAppID.Text.Trim();
            list.KeyCode = txtKeyCode.Text.Trim();
            list.Visible = cbVisible.Checked;
            list.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            list.ImagePath = string.Empty;
            list.CreateDate = DateTime.Now.ToString();
            list.CreateUserID = int.Parse(Session["UserID"].ToString());
            list.ModifyDate = DateTime.Now.ToString();
            list.ModifyUserID = 0;
            ViewState["pk_SMS"] = list.InsertData();
        }

        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("List.aspx?active=" + Request.QueryString["active"]);
    }
}