using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class Admin_Product_Nav : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["parentId"] != null)
            {
                hlAdd.NavigateUrl = "Edit.aspx?parentId=" + Request.QueryString["parentId"] + "&active=" + Request.QueryString["active"];
                ViewState["ParentID"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["parentId"]);
            }
            else
            {
                hlAdd.NavigateUrl = "Edit.aspx?active=" + Request.QueryString["active"];
                ViewState["ParentID"] = "";
            }

            hlCategory.NavigateUrl = "Category.aspx?active=" + Request.QueryString["active"];

            NavDiv.InnerHtml = CreateNav();
        }
    }

    private string CreateNav()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("<ul class=\"nav nav-pills nav-stacked\">");
        if (ViewState["ParentID"].ToString() != "")
        {
            sb.Append("<li><a href=\"List.aspx?&active=" + Request.QueryString["active"] + "\"><i class=\"fa fa-circle-o\"></i> 全部</a></li>");
        }
        else
        {
            sb.Append("<li class=\"active\"><a href=\"List.aspx?&active=" + Request.QueryString["active"] + "\"><i class=\"fa fa-circle-o\"></i> 全部</a></li>");
        }
        DataTable dt = new DataTable();
        dt = MojoCube.Web.Sql.SqlQueryDS("select * from Product_Category where Visible=1 and ParentID=0 and Language='" + MojoCube.Api.UI.Language.GetLanguage() + "' order by SortID asc").Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["pk_Category"].ToString() == ViewState["ParentID"].ToString())
            {
                sb.Append("<li class=\"active\"><a href=\"List.aspx?parentId=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["pk_Category"].ToString()) + "&active=" + Request.QueryString["active"] + "\"><i class=\"fa fa-circle-o\"></i> " + dt.Rows[i]["CategoryName"].ToString() + GetChildCount(dt.Rows[i]["pk_Category"].ToString()) + "</a></li>");
            }
            else
            {
                sb.Append("<li><a href=\"List.aspx?parentId=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["pk_Category"].ToString()) + "&active=" + Request.QueryString["active"] + "\"><i class=\"fa fa-circle-o\"></i> " + dt.Rows[i]["CategoryName"].ToString() + GetChildCount(dt.Rows[i]["pk_Category"].ToString()) + "</a></li>");
            }
        }

        sb.Append("</ul>");

        return sb.ToString();
    }

    private string GetChildCount(string parentId)
    {
        string text = "";

        int count = MojoCube.Web.Sql.GetResultCount("Product_Category", "ParentID=" + parentId + " and Visible=1 and Language='" + MojoCube.Api.UI.Language.GetLanguage() + "'");

        if (count > 0)
        {
            text = " <span class=\"label label-primary pull-right\">" + count.ToString() + "</span>";
        }

        return text;
    }
}