using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Commons_Info : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] != null)
        {
            switch (Request.QueryString["type"])
            { 
                case "1":
                    lblInfo.Text = "对不起，您没有权限操作，请重新登录<br/><a href=\"../Login.aspx\">点击登录</a>";
                    break;
            }
        }
    }
}