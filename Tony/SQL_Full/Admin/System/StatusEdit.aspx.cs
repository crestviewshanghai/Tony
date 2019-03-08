using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_System_StatusEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "Status.aspx?active=" + Request.QueryString["active"];

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_StatusID"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Sys.StatusID statusId = new MojoCube.Web.Sys.StatusID();
                statusId.GetData(int.Parse(ViewState["pk_StatusID"].ToString()));

                txtName.Text = statusId.StatusName_CHS;
                txtID.Text = statusId.ID.ToString();
                txtTableName.Text = statusId.TableName;
                txtVisual.Text = statusId.Visual;

                this.Title = "状态编辑：" + txtName.Text.Trim();
            }
            else
            {
                this.Title = "状态编辑";
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

        MojoCube.Web.Sys.StatusID statusId = new MojoCube.Web.Sys.StatusID();

        //修改
        if (ViewState["pk_StatusID"] != null)
        {
            statusId.GetData(int.Parse(ViewState["pk_StatusID"].ToString()));

            statusId.StatusName_CHS = txtName.Text.Trim();
            statusId.ID = MojoCube.Web.String.ToInt(txtID.Text.Trim());
            statusId.Visual = txtVisual.Text.Trim();
            statusId.TableName = txtTableName.Text.Trim();
            statusId.UpdateData(statusId.pk_StatusID);
        }
        //新增
        else
        {
            statusId.StatusName_CHS = txtName.Text.Trim();
            statusId.StatusName_CHT = string.Empty;
            statusId.StatusName_EN = string.Empty;
            statusId.ID = MojoCube.Web.String.ToInt(txtID.Text.Trim());
            statusId.Visual = txtVisual.Text.Trim();
            statusId.TableName = txtTableName.Text.Trim();
            statusId.Description_CHS = string.Empty;
            statusId.Description_CHT = string.Empty;
            statusId.Description_EN = string.Empty;
            statusId.InsertData();
        }

        Response.Redirect("Status.aspx?active=" + Request.QueryString["active"]);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Status.aspx?active=" + Request.QueryString["active"]);
    }
}