using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MojoCube.Web.User.Login.SetLogout();
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}