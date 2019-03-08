using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_System_MenuEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "Menu.aspx?active=" + Request.QueryString["active"];

            MojoCube.Web.Sql.DropDownListBind(ddlType, "Sys_TypeID", "TypeName_CHS", "ID", "TableName='Sys_Menu'", "ID", "asc");

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Menu"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Sys.Menu menu = new MojoCube.Web.Sys.Menu();
                menu.GetData(int.Parse(ViewState["pk_Menu"].ToString()));

                txtName.Text = menu.Name_CHS;
                txtIcon.Text = menu.Icon;
                txtUrl.Text = menu.Url;
                txtSortID.Text = menu.SortID.ToString();
                cbVisible.Checked = menu.Visible;
                txtTag.Text = menu.Tag_CHS;

                MojoCube.Web.Sql.ddlFindByValue(ddlType, menu.TypeID.ToString());

                this.Title = "菜单编辑：" + txtName.Text.Trim();
            }
            else
            {
                txtIcon.Text = "fa-circle-o";
                cbVisible.Checked = true;
                this.Title = "菜单编辑";
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

        MojoCube.Web.Sys.Menu menu = new MojoCube.Web.Sys.Menu();

        //修改
        if (ViewState["pk_Menu"] != null)
        {
            menu.GetData(int.Parse(ViewState["pk_Menu"].ToString()));
            menu.Name_CHS = txtName.Text.Trim();
            menu.Url = txtUrl.Text.Trim();
            menu.Icon = txtIcon.Text.Trim();
            menu.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            menu.TypeID = int.Parse(ddlType.SelectedValue);
            menu.Visible = cbVisible.Checked;
            menu.Tag_CHS = txtTag.Text.Trim();
            menu.UpdateData(menu.pk_Menu);
        }
        //新增
        else
        {
            if (Request.QueryString["parentId"] != null)
            {
                menu.ParentID = int.Parse(MojoCube.Api.Text.Security.DecryptString(Request.QueryString["parentId"]));
            }
            else
            {
                menu.ParentID = 0;
            }
            menu.Name_CHS = txtName.Text.Trim();
            menu.Name_CHT = string.Empty;
            menu.Name_EN = string.Empty;
            menu.Url = txtUrl.Text.Trim();
            menu.Icon = txtIcon.Text.Trim();
            menu.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            menu.LevelID = 0;
            menu.TypeID = int.Parse(ddlType.SelectedValue);
            menu.Visible = cbVisible.Checked;
            menu.Tag_CHS = txtTag.Text.Trim();
            menu.Tag_CHT = string.Empty;
            menu.Tag_EN = string.Empty;
            menu.InsertData();
        }

        Response.Redirect("Menu.aspx?active=" + Request.QueryString["active"]);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Menu.aspx?active=" + Request.QueryString["active"]);
    }
}