using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SMS_List : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlAdd.NavigateUrl = "Edit.aspx?active=" + Request.QueryString["active"];
            ViewState["OrderByKey"] = "SortID";
            ViewState["OrderByType"] = false;
            GridBind();
            this.Title = "短信接口";
        }
    }

    protected void lnbSearch_Click(object sender, EventArgs e)
    {
        GridBind();
    }

    protected void ListPager_PageChanged(object sender, EventArgs e)
    {
        GridBind();
    }

    private void GridBind()
    {
        MojoCube.Api.UI.AdminPager pager = new MojoCube.Api.UI.AdminPager(ListPager);
        pager.PageSize = MojoCube.Web.String.PageSize();
        pager.ConnStr = MojoCube.Web.Connection.ConnString();
        pager.TableName = "SMS_List";
        pager.strGetFields = "*";
        if (txtKeyword.Text.Trim() != "")
        {
            string keyword = MojoCube.Api.Text.CheckSql.Filter(txtKeyword.Text.Trim());
            pager.where = "Title like '%" + keyword + "%'";
        }
        pager.fldName = ViewState["OrderByKey"].ToString();
        pager.OrderType = (bool)ViewState["OrderByType"];

        GridView1.DataSource = pager.GetTable();
        GridView1.DataBind();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sPage = e.SortExpression;
        if (ViewState["OrderByKey"].ToString() == sPage)
        {
            if ((bool)ViewState["OrderByType"])
                ViewState["OrderByType"] = false;
            else
                ViewState["OrderByType"] = true;
        }
        else
        {
            ViewState["OrderByKey"] = e.SortExpression;
        }
        GridBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string id = MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);

            ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "Edit.aspx?id=" + id + "&active=" + Request.QueryString["active"];

            ((Label)e.Row.FindControl("lblType")).Text = MojoCube.Web.Sys.TypeID.GetTypeName("SMS_List", ((Label)e.Row.FindControl("lblType")).Text, "CHS");

            MojoCube.Web.String.ShowDel(e);
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        MojoCube.Api.UI.AdminGridView.SetSortingRowCreated(e, (string)ViewState["OrderByKey"], (bool)ViewState["OrderByType"], GridView1);
        string[] list = { "gvUp", "gvDown", "gvDelete" };
        MojoCube.Api.UI.AdminGridView.SetDataRow(e, list);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        MojoCube.Web.SMS.List list = new MojoCube.Web.SMS.List();
        int index = 0;
        //删除
        if (e.CommandName == "_delete")
        {
            index = Convert.ToInt32(e.CommandArgument);
            list.DeleteData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));
        }
        //上移
        if (e.CommandName == "_up")
        {
            index = Convert.ToInt32(e.CommandArgument);
            MojoCube.Web.Sql.SetSortID("SMS_List", "pk_SMS", ((Label)GridView1.Rows[index].FindControl("lblID")).Text, -1);
        }
        //下移
        if (e.CommandName == "_down")
        {
            index = Convert.ToInt32(e.CommandArgument);
            MojoCube.Web.Sql.SetSortID("SMS_List", "pk_SMS", ((Label)GridView1.Rows[index].FindControl("lblID")).Text, 1);
        }
        GridBind();
    }
}