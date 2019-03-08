using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_User_History : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["OrderByKey"] = "CreateDate";
            ViewState["OrderByType"] = true;
            GridBind();
            this.Title = "历史记录";
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
        pager.TableName = "View_MyHistory";
        pager.strGetFields = "*";

        string where = "fk_User=" + Session["UserID"].ToString() + " and TypeID=0";

        if (txtKeyword.Text.Trim() != "")
        {
            string keyword = MojoCube.Api.Text.CheckSql.Filter(txtKeyword.Text.Trim());
            where += " and (Title like '%" + keyword + "%')";
        }

        pager.where = where;
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
            ((HyperLink)e.Row.FindControl("gvView")).NavigateUrl = "../../" + ((Label)e.Row.FindControl("lblUrl")).Text;
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        MojoCube.Api.UI.AdminGridView.SetSortingRowCreated(e, (string)ViewState["OrderByKey"], (bool)ViewState["OrderByType"], GridView1);
    }
}