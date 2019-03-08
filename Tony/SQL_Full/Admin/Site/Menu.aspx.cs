using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Site_Menu : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlAdd.NavigateUrl = "MenuEdit.aspx?active=" + Request.QueryString["active"];
            GridBind(null);
            this.Title = "导航列表";
        }
    }

    protected void lnbSearch_Click(object sender, EventArgs e)
    {
        string keyword = MojoCube.Api.Text.CheckSql.Filter(txtKeyword.Text.Trim());
        GridBind(" and MenuName like '%" + keyword + "%'");
    }

    private void GridBind(string where)
    {
        MojoCube.Web.Sql treeGrid = new MojoCube.Web.Sql();
        treeGrid.TableName = "Site_Menu";
        treeGrid.OrderByKey = "TypeID";
        treeGrid.OrderByType = "asc,SortID asc,pk_Menu asc";
        treeGrid.Where = "Language='" + MojoCube.Api.UI.Language.GetLanguage() + "'" + where;
        treeGrid.pk_ID = "pk_Menu";
        treeGrid.ParentID = "ParentID";
        treeGrid.TreeGridBind(GridView1);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string id = MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);

            ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "MenuEdit.aspx?id=" + id + "&active=" + Request.QueryString["active"];

            if (((Label)e.Row.FindControl("lblParentID")).Text == "0")
            {
                e.Row.CssClass = "parent";

                ((HyperLink)e.Row.FindControl("gvAdd")).Visible = true;
                ((HyperLink)e.Row.FindControl("gvAdd")).NavigateUrl = "MenuEdit.aspx?parentId=" + id + "&active=" + Request.QueryString["active"];
            }

            ((Label)e.Row.FindControl("lblType")).Text = MojoCube.Web.Sys.TypeID.GetTypeName("Site_Menu", ((Label)e.Row.FindControl("lblType")).Text, "CHS");

            MojoCube.Web.String.ShowDel(e);
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        string[] list = { "gvUp", "gvDown", "gvDelete" };
        MojoCube.Api.UI.AdminGridView.SetDataRow(e, list);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        MojoCube.Web.Site.Menu menu = new MojoCube.Web.Site.Menu();
        int index = Convert.ToInt32(e.CommandArgument);
        //删除
        if (e.CommandName == "_delete")
        {
            menu.DeleteData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));
        }
        //上移
        if (e.CommandName == "_up")
        {
            MojoCube.Web.Sql.SetSortID("Site_Menu", "pk_Menu", ((Label)GridView1.Rows[index].FindControl("lblID")).Text, -1);
        }
        //下移
        if (e.CommandName == "_down")
        {
            MojoCube.Web.Sql.SetSortID("Site_Menu", "pk_Menu", ((Label)GridView1.Rows[index].FindControl("lblID")).Text, 1);
        }
        GridBind(null);
    }
}