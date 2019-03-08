using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Role_List : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "Name.aspx?active=" + Request.QueryString["active"];

            if (Request.QueryString["roleId"] != null)
            {
                ViewState["pk_Name"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["roleId"]);

                MojoCube.Web.Role.Name name = new MojoCube.Web.Role.Name();
                name.GetData(int.Parse(ViewState["pk_Name"].ToString()));

                Label1.Text = Label2.Text = name.RoleName_CHS;
                this.Title = "角色管理：" + Label1.Text;
            }

            GridBind();
        }
    }

    private void GridBind()
    {
        MojoCube.Web.Sql treeGrid = new MojoCube.Web.Sql();
        treeGrid.TableName = "Sys_Menu";
        treeGrid.OrderByKey = "SortID";
        treeGrid.OrderByType = "asc,pk_Menu asc";
        treeGrid.Where = null;
        treeGrid.pk_ID = "pk_Menu";
        treeGrid.ParentID = "ParentID";
        treeGrid.TreeGridBind(GridView1);

        MojoCube.Web.Role.List list = new MojoCube.Web.Role.List();

        int roleId = int.Parse(ViewState["pk_Name"].ToString());

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            list.pk_Role = 0;

            int menuId = int.Parse(((Label)GridView1.Rows[i].FindControl("lblID")).Text);

            list.GetData(roleId, menuId);

            if (list.pk_Role > 0)
            {
                if (list.IsUse)
                {
                    ((CheckBox)GridView1.Rows[i].FindControl("cbUse")).Checked = true;
                }
                if (list.IsAdmin)
                {
                    ((CheckBox)GridView1.Rows[i].FindControl("cbAdmin")).Checked = true;
                }
            }
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((Label)e.Row.FindControl("lblParentID")).Text == "0")
            {
                e.Row.CssClass = "parent";
            }

            ((Label)e.Row.FindControl("lblType")).Text = MojoCube.Web.Sys.TypeID.GetTypeName("Sys_Menu", ((Label)e.Row.FindControl("lblType")).Text, "CHS");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        MojoCube.Web.Role.List list = new MojoCube.Web.Role.List();

        int roleId = int.Parse(ViewState["pk_Name"].ToString());

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            list.pk_Role = 0;

            int menuId = int.Parse(((Label)GridView1.Rows[i].FindControl("lblID")).Text);

            list.GetData(roleId, menuId);

            if (list.pk_Role > 0)
            {
                list.IsUse = ((CheckBox)GridView1.Rows[i].FindControl("cbUse")).Checked;
                list.IsAdmin = ((CheckBox)GridView1.Rows[i].FindControl("cbAdmin")).Checked;
                list.UpdateData(list.pk_Role);
            }
            else
            {
                list.fk_RoleName = roleId;
                list.fk_Menu = menuId;
                list.IsUse = ((CheckBox)GridView1.Rows[i].FindControl("cbUse")).Checked;
                list.IsAdmin = ((CheckBox)GridView1.Rows[i].FindControl("cbAdmin")).Checked;
                list.PowerList = "";
                list.fk_Company = 0;
                list.InsertData();
            }
        }

        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Name.aspx?active=" + Request.QueryString["active"]);
    }
}