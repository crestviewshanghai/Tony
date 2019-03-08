using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Role_NameEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "Name.aspx?active=" + Request.QueryString["active"];

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Name"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Role.Name name = new MojoCube.Web.Role.Name();
                name.GetData(int.Parse(ViewState["pk_Name"].ToString()));

                txtName.Text = name.RoleName_CHS;
                txtPowerValue.Text = name.PowerValue.ToString();

                this.Title = "角色编辑：" + txtName.Text.Trim();
            }
            else
            {
                this.Title = "角色编辑";
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

        MojoCube.Web.Role.Name name = new MojoCube.Web.Role.Name();

        //修改
        if (ViewState["pk_Name"] != null)
        {
            name.GetData(int.Parse(ViewState["pk_Name"].ToString()));

            name.RoleName_CHS = txtName.Text.Trim();
            name.PowerValue = MojoCube.Web.String.ToInt(txtPowerValue.Text.Trim());
            name.UpdateData(name.pk_Name);
        }
        //新增
        else
        {
            name.RoleName_CHS = txtName.Text.Trim();
            name.RoleName_CHT = string.Empty;
            name.RoleName_EN = string.Empty;
            name.PowerValue = MojoCube.Web.String.ToInt(txtPowerValue.Text.Trim());
            name.fk_Company = 0;
            name.InsertData();
        }

        Response.Redirect("Name.aspx?active=" + Request.QueryString["active"]);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Name.aspx?active=" + Request.QueryString["active"]);
    }
}