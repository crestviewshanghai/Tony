using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class Admin_Commons_Simple : System.Web.UI.MasterPage
{
    public string skin = "";
    public string skinCss = "";

    protected void Page_Init(object sender, EventArgs e)
    {
        MojoCube.Web.User.Login.ChkLogin();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //用户信息
            MojoCube.Web.User.List user = new MojoCube.Web.User.List();
            user.GetData(int.Parse(Session["UserID"].ToString()));

            ViewState["Skin"] = user.Skin;
        }

        this.Page.Title = "MojoCube";

        //界面皮肤
        skin = ViewState["Skin"].ToString();
        skinCss = "<link rel=\"stylesheet\" href=\"../Skins/dist/css/skins/skin-" + skin + ".min.css\" /><link rel=\"stylesheet\" href=\"../Skins/plugins/iCheck/flat/" + skin + ".css\" />";
    }
}
