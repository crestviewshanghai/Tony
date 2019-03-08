using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Article_Category : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "List.aspx?active=" + Request.QueryString["active"];
            hlAdd.NavigateUrl = "CategoryEdit.aspx?active=" + Request.QueryString["active"];
            GridBind(null);
            this.Title = "文章分类列表";
        }
    }

    protected void lnbSearch_Click(object sender, EventArgs e)
    {
        string keyword = MojoCube.Api.Text.CheckSql.Filter(txtKeyword.Text.Trim());
        GridBind(" and CategoryName like '%" + keyword + "%'");
    }

    private void GridBind(string where)
    {
        MojoCube.Web.Sql treeGrid = new MojoCube.Web.Sql();
        treeGrid.TableName = "Article_Category";
        treeGrid.OrderByKey = "SortID";
        treeGrid.OrderByType = "asc,pk_Category asc";
        treeGrid.Where = "Language='" + MojoCube.Api.UI.Language.GetLanguage() + "'" + where;
        treeGrid.pk_ID = "pk_Category";
        treeGrid.ParentID = "ParentID";
        treeGrid.TreeGridBind(GridView1);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string id = MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);

            ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "CategoryEdit.aspx?id=" + id + "&active=" + Request.QueryString["active"];

            if (((Label)e.Row.FindControl("lblParentID")).Text == "0")
            {
                e.Row.CssClass = "parent";

                ((HyperLink)e.Row.FindControl("gvAdd")).Visible = true;
                ((HyperLink)e.Row.FindControl("gvAdd")).NavigateUrl = "CategoryEdit.aspx?parentId=" + id + "&active=" + Request.QueryString["active"];
            }

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
        MojoCube.Web.Article.Category category = new MojoCube.Web.Article.Category();
        int index = Convert.ToInt32(e.CommandArgument);
        //删除
        if (e.CommandName == "_delete")
        {
            category.DeleteData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));
        }
        //上移
        if (e.CommandName == "_up")
        {
            MojoCube.Web.Sql.SetSortID("Article_Category", "pk_Category", ((Label)GridView1.Rows[index].FindControl("lblID")).Text, -1);
        }
        //下移
        if (e.CommandName == "_down")
        {
            MojoCube.Web.Sql.SetSortID("Article_Category", "pk_Category", ((Label)GridView1.Rows[index].FindControl("lblID")).Text, 1);
        }
        GridBind(null);
    }
}