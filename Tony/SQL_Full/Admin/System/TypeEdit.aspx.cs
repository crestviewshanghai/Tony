using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_System_TypeEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "Type.aspx?active=" + Request.QueryString["active"];

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_TypeID"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Sys.TypeID typeId = new MojoCube.Web.Sys.TypeID();
                typeId.GetData(int.Parse(ViewState["pk_TypeID"].ToString()));

                txtName.Text = typeId.TypeName_CHS;
                txtID.Text = typeId.ID.ToString();
                txtTableName.Text = typeId.TableName;
                txtVisual.Text = typeId.Visual;
                txtDescription.Text = typeId.Description_CHS;

                this.Title = "类型编辑：" + txtName.Text.Trim();
            }
            else
            {
                this.Title = "类型编辑";
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

        MojoCube.Web.Sys.TypeID typeId = new MojoCube.Web.Sys.TypeID();

        //修改
        if (ViewState["pk_TypeID"] != null)
        {
            typeId.GetData(int.Parse(ViewState["pk_TypeID"].ToString()));

            typeId.TypeName_CHS = txtName.Text.Trim();
            typeId.ID = MojoCube.Web.String.ToInt(txtID.Text.Trim());
            typeId.Visual = txtVisual.Text.Trim();
            typeId.TableName = txtTableName.Text.Trim();
            typeId.Description_CHS = txtDescription.Text.Trim();
            typeId.UpdateData(typeId.pk_TypeID);
        }
        //新增
        else
        {
            typeId.TypeName_CHS = txtName.Text.Trim();
            typeId.TypeName_CHT = string.Empty;
            typeId.TypeName_EN = string.Empty;
            typeId.ID = MojoCube.Web.String.ToInt(txtID.Text.Trim());
            typeId.Visual = txtVisual.Text.Trim();
            typeId.TableName = txtTableName.Text.Trim();
            typeId.Description_CHS = txtDescription.Text.Trim();
            typeId.Description_CHT = string.Empty;
            typeId.Description_EN = string.Empty;
            typeId.InsertData();
        }

        Response.Redirect("Type.aspx?active=" + Request.QueryString["active"]);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Type.aspx?active=" + Request.QueryString["active"]);
    }
}