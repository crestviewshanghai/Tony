using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Dev_Setup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MojoCube.Api.Data.Sql sql = new MojoCube.Api.Data.Sql();
            sql.GetInfo(MojoCube.Web.Connection.ConnString());

            txtServer.Text = sql.Server;
            txtUserID.Text = sql.UserID;
            txtPassword.Text = sql.Password;
            txtDatabase.Text = sql.Database;
            txtPath.Text = Server.MapPath("~/Data/Backup/McCMS_V3.bak");
        }
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        MojoCube.Api.Data.Sql sql = new MojoCube.Api.Data.Sql();
        sql.Connect = "server=" + txtServer.Text.Trim() + ";user id=" + txtUserID.Text.Trim() + ";password=" + txtPassword.Text.Trim() + ";";
        sql.Database = txtDatabase.Text.Trim();
        sql.CreateDB();
        sql.Connect = "server=" + txtServer.Text.Trim() + ";user id=" + txtUserID.Text.Trim() + ";password=" + txtPassword.Text.Trim() + ";database=" + txtDatabase.Text.Trim() + ";";
        sql.RestoreDB(txtPath.Text.Trim());
        Response.Redirect("../");
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Setup.aspx");
    }
}
