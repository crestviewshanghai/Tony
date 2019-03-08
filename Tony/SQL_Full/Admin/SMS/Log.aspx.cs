using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SMS_Log : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["OrderByKey"] = "pk_Log";
            ViewState["OrderByType"] = true;
            GridBind();
            this.Title = "短信记录";
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
        pager.TableName = "View_SMS_Log";
        pager.strGetFields = "*";
        if (txtKeyword.Text.Trim() != "")
        {
            string keyword = MojoCube.Api.Text.CheckSql.Filter(txtKeyword.Text.Trim());
            pager.where = "FullName like '%" + keyword + "%'";
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
            ((Label)e.Row.FindControl("lblType")).Text = MojoCube.Web.Sys.TypeID.GetTypeName("SMS_List", ((Label)e.Row.FindControl("lblType")).Text, "CHS");

            MojoCube.Web.String.ShowDel(e);
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        MojoCube.Api.UI.AdminGridView.SetSortingRowCreated(e, (string)ViewState["OrderByKey"], (bool)ViewState["OrderByType"], GridView1);
        string[] list = { "gvResend", "gvDelete" };
        MojoCube.Api.UI.AdminGridView.SetDataRow(e, list);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = 0;
        //重发
        if (e.CommandName == "_resend")
        {
            index = Convert.ToInt32(e.CommandArgument);

            //发送短信
            MojoCube.Web.SMS.Function.Send(int.Parse(((Label)GridView1.Rows[index].FindControl("lblTypeID")).Text), int.Parse(((Label)GridView1.Rows[index].FindControl("lblUserID")).Text), int.Parse(((Label)GridView1.Rows[index].FindControl("lblfk_ID")).Text));
        }
        //删除
        if (e.CommandName == "_delete")
        {
            MojoCube.Web.SMS.Log log = new MojoCube.Web.SMS.Log();
            index = Convert.ToInt32(e.CommandArgument);
            log.DeleteData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));
        }
        GridBind();
    }
}