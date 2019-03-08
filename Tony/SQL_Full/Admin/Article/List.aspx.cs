using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class Admin_Article_List : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["OrderByKey"] = "pk_Article";
            ViewState["OrderByType"] = true;

            if (Request.QueryString["parentId"] != null)
            {
                ViewState["ParentID"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["parentId"]);

                MojoCube.Web.Article.Category category = new MojoCube.Web.Article.Category();
                category.GetData(int.Parse(ViewState["ParentID"].ToString()));

                lblTitle.Text = category.CategoryName;
            }
            else
            {
                ViewState["ParentID"] = "0";

                lblTitle.Text = "全部";
            }

            CategoryDiv.InnerHtml = CreateCategory();
            GridBind();
            this.Title = "文章列表";
        }
    }

    private string CreateCategory()
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Article_Category where Visible=1 and ParentID=" + ViewState["ParentID"].ToString() + " and Language='" + MojoCube.Api.UI.Language.GetLanguage() + "' order by SortID asc").Tables[0];

        string label = "label-back";

        sb.Append("<a href=\"List.aspx?parentId=" + MojoCube.Api.Text.Security.EncryptString(ViewState["ParentID"].ToString()) + "&active=" + Request.QueryString["active"] + "\" style='margin-right:10px;'><span class=\"label label-warning\">全部</span></a>");

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                label = "label-back";

                if (dt.Rows[i]["pk_Category"].ToString() == ViewState["ParentID"].ToString())
                {
                    label = "label-warning";
                }

                sb.Append("<a href=\"List.aspx?parentId=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["pk_Category"].ToString()) + "&active=" + Request.QueryString["active"] + "\" style='margin-right:10px;'><span class=\"label " + label + "\">" + dt.Rows[i]["CategoryName"].ToString() + "</span></a>");
            }
        }

        return sb.ToString();
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
        EmptyDiv.Visible = false;

        MojoCube.Api.UI.AdminPager pager = new MojoCube.Api.UI.AdminPager(ListPager);
        pager.PageSize = MojoCube.Web.String.PageSize();
        pager.ConnStr = MojoCube.Web.Connection.ConnString();
        pager.TableName = "Article_List";
        pager.strGetFields = "*";

        string where = "Language='" + MojoCube.Api.UI.Language.GetLanguage() + "'";

        if (txtKeyword.Text.Trim() != "")
        {
            string keyword = MojoCube.Api.Text.CheckSql.Filter(txtKeyword.Text.Trim());
            where += " and (Title like '%" + keyword + "%')";
        }

        if (ViewState["ParentID"].ToString() != "0")
        {
            where += " and (CategoryID1=" + ViewState["ParentID"].ToString() + " or CategoryID2=" + ViewState["ParentID"].ToString() + ")";
        }

        pager.where = where;
        pager.fldName = ViewState["OrderByKey"].ToString();
        pager.OrderType = (bool)ViewState["OrderByType"];

        GridView1.DataSource = pager.GetTable();
        GridView1.DataBind();

        if (GridView1.Rows.Count == 0)
        {
            EmptyDiv.Visible = true;
        }
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

            if (((Label)e.Row.FindControl("lblThumbnail")).Text != "")
            {
                string imgPath = "../Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblThumbnail")).Text);
                ((Label)e.Row.FindControl("lblThumbnail")).Text = "<a href=\"" + imgPath + "\" class=\"fancybox fancybox.image\" data-fancybox-group=\"gallery\" title=\"" + ((Label)e.Row.FindControl("lblTitle")).Text + "\"><img src=\"" + imgPath + "&w=120&h=90\" style=\"height:25px;\" /></a>";
            }

            ((HyperLink)e.Row.FindControl("gvView")).NavigateUrl = "~/" + MojoCube.Web.Site.Cache.GetUrlExtension("N-" + ((Label)e.Row.FindControl("lblPageName")).Text, MojoCube.Api.UI.Language.GetLanguage());
            ((HyperLink)e.Row.FindControl("gvView")).Target = "_blank";

            ((Label)e.Row.FindControl("lblTitle")).Text = MojoCube.Web.String.SubString(((Label)e.Row.FindControl("lblTitle")).Text, 40);

            MojoCube.Web.String.ShowDel(e);
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        MojoCube.Api.UI.AdminGridView.SetSortingRowCreated(e, (string)ViewState["OrderByKey"], (bool)ViewState["OrderByType"], GridView1);
        string[] list = { "gvDelete" };
        MojoCube.Api.UI.AdminGridView.SetDataRow(e, list);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        MojoCube.Web.Article.List list = new MojoCube.Web.Article.List();
        int index = 0;
        //删除
        if (e.CommandName == "_delete")
        {
            index = Convert.ToInt32(e.CommandArgument);
            list.DeleteData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));
        }
        GridBind();
    }
}