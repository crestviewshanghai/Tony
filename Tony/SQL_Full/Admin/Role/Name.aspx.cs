using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Admin_Role_Name : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlAdd.NavigateUrl = "NameEdit.aspx?active=" + Request.QueryString["active"];
            GridBind();
            this.Title = "角色列表";
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
        parameter.Add(MojoCube.Web.SqlHelper.CreateParameter("@RoleName_CHS", txtKeyword.Text.Trim(), SqlDbType.NVarChar));
        dt = MojoCube.Web.SqlHelper.SqlQueryDS("select * from Role_Name where RoleName_CHS like '%'+@RoleName_CHS+'%' order by PowerValue desc", parameter).Tables[0];

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string id = MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);

            ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "NameEdit.aspx?id=" + id + "&active=" + Request.QueryString["active"];

            ((HyperLink)e.Row.FindControl("gvSet")).NavigateUrl = "List.aspx?roleId=" + id + "&active=" + Request.QueryString["active"];

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
        MojoCube.Web.Role.Name name = new MojoCube.Web.Role.Name();
        int index = Convert.ToInt32(e.CommandArgument);
        //删除
        if (e.CommandName == "_delete")
        {
            name.DeleteData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));
        }
        GridBind();
    }
}