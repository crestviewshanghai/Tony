using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Admin_System_Status : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlAdd.NavigateUrl = "StatusEdit.aspx?active=" + Request.QueryString["active"];
            GridBind();
            this.Title = "状态列表";
        }
    }

    protected void lnbSearch_Click(object sender, EventArgs e)
    {
        GridBind();
    }

    private void GridBind()
    {
        DataTable dt = new DataTable();

        ArrayList parameter = new ArrayList();
        parameter.Add(MojoCube.Web.SqlHelper.CreateParameter("@StatusName_CHS", txtKeyword.Text.Trim(), SqlDbType.NVarChar));
        dt = MojoCube.Web.SqlHelper.SqlQueryDS("select * from Sys_StatusID where StatusName_CHS like '%'+@StatusName_CHS+'%' order by TableName asc,ID asc", parameter).Tables[0];

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string id = MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);

            ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "StatusEdit.aspx?id=" + id + "&active=" + Request.QueryString["active"];

            MojoCube.Web.String.ShowDel(e);
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        string[] list = { "gvDelete" };
        MojoCube.Api.UI.AdminGridView.SetDataRow(e, list);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        MojoCube.Web.Sys.StatusID statusId = new MojoCube.Web.Sys.StatusID();
        int index = Convert.ToInt32(e.CommandArgument);
        //删除
        if (e.CommandName == "_delete")
        {
            statusId.DeleteData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));
        }
        GridBind();
    }
}