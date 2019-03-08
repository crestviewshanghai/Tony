using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Site_MenuEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "Menu.aspx?active=" + Request.QueryString["active"];

            MojoCube.Web.Sql.DropDownListBind(ddlType, "Sys_TypeID", "TypeName_CHS", "ID", "TableName='Site_Menu'", "ID", "asc");

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Menu"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Site.Menu menu = new MojoCube.Web.Site.Menu();
                menu.GetData(int.Parse(ViewState["pk_Menu"].ToString()));

                txtName.Text = menu.MenuName;
                txtUrl.Text = menu.Url;
                txtSortID.Text = menu.SortID.ToString();
                cbVisible.Checked = menu.Visible;

                MojoCube.Web.Sql.ddlFindByValue(ddlType, menu.TypeID.ToString());

                this.Title = "导航编辑：" + txtName.Text.Trim();
            }
            else
            {
                cbVisible.Checked = true;
                this.Title = "导航编辑";
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

        MojoCube.Web.Site.Menu menu = new MojoCube.Web.Site.Menu();

        //修改
        if (ViewState["pk_Menu"] != null)
        {
            menu.GetData(int.Parse(ViewState["pk_Menu"].ToString()));
            menu.MenuName = txtName.Text.Trim();
            menu.Url = txtUrl.Text.Trim();
            menu.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            menu.TypeID = int.Parse(ddlType.SelectedValue);
            menu.Visible = cbVisible.Checked;
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
            menu.MenuName = txtName.Text.Trim();
            menu.Url = txtUrl.Text.Trim();
            menu.Icon = string.Empty;
            menu.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            menu.TypeID = int.Parse(ddlType.SelectedValue);
            menu.Visible = cbVisible.Checked;
            menu.Target = "_self";
            menu.SEO_Title = string.Empty;
            menu.SEO_Keyword = string.Empty;
            menu.SEO_Description = string.Empty;
            menu.Language = MojoCube.Api.UI.Language.GetLanguage();
            menu.InsertData();
        }

        Response.Redirect("Menu.aspx?active=" + Request.QueryString["active"]);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Menu.aspx?active=" + Request.QueryString["active"]);
    }
}