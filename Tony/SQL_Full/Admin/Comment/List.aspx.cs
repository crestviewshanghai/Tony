using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class Admin_Comment_List : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["typeId"] != null)
            {
                if (Request.QueryString["typeId"] == "-1")
                {
                    Session.Remove("CommentTypeID");
                }
                else
                {
                    Session["CommentTypeID"] = Request.QueryString["typeId"];
                }
            }
            lblType.Text = CreateType();
            ViewState["OrderByKey"] = "pk_Comment";
            ViewState["OrderByType"] = true;
            GridBind();
            this.Title = "留言列表";
        }
    }

    private string CreateType()
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Sys_TypeID where TableName='Comment_List' order by ID asc").Tables[0];

        if (dt.Rows.Count > 0)
        {
            string label = "label-back";

            if (Session["CommentTypeID"] == null)
            {
                label = "label-warning";
            }

            sb.Append("<a href=\"List.aspx?active=" + Request.QueryString["active"] + "&typeId=-1\" style='margin-right:10px;'><span class=\"label " + label + "\">全部</span></a>");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                label = "label-back";

                if (Session["CommentTypeID"] != null && Session["CommentTypeID"].ToString() == dt.Rows[i]["ID"].ToString())
                {
                    label = "label-warning";
                }

                sb.Append("<a href=\"List.aspx?active=" + Request.QueryString["active"] + "&typeId=" + dt.Rows[i]["ID"].ToString() + "\" style='margin-right:10px;'><span class=\"label " + label + "\">" + dt.Rows[i]["TypeName_CHS"].ToString() + "</span></a>");
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
        MojoCube.Api.UI.AdminPager pager = new MojoCube.Api.UI.AdminPager(ListPager);
        pager.PageSize = MojoCube.Web.String.PageSize();
        pager.ConnStr = MojoCube.Web.Connection.ConnString();
        pager.TableName = "Comment_List";
        pager.strGetFields = "*";

        string where = "Issue=1";
        
        if (txtKeyword.Text.Trim() != "")
        {
            string keyword = MojoCube.Api.Text.CheckSql.Filter(txtKeyword.Text.Trim());
            where += " and (Title like '%" + keyword + "%' or Author like '%" + keyword + "%' or Phone like '%" + keyword + "%' or IPAddress like '%" + keyword + "%')";
        }

        if (Session["CommentTypeID"] != null)
        {
            where += " and TypeID=" + Session["CommentTypeID"].ToString();
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
            string id = MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);

            ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "Edit.aspx?id=" + id + "&active=" + Request.QueryString["active"];

            //是否已读
            if (!((CheckBox)e.Row.FindControl("cbRead")).Checked)
            {
                ((Label)e.Row.FindControl("lblTitle")).Text = "<b>" + ((Label)e.Row.FindControl("lblTitle")).Text + "</b>";
            }

            ((Label)e.Row.FindControl("lblType")).Text = MojoCube.Web.Sys.TypeID.GetTypeName("Comment_List", ((Label)e.Row.FindControl("lblType")).Text, "CHS");

            ((Label)e.Row.FindControl("lblStatus")).Text = MojoCube.Web.Sys.StatusID.GetStatusName("Comment_List", ((Label)e.Row.FindControl("lblStatus")).Text, "CHS");

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
        MojoCube.Web.Comment.List list = new MojoCube.Web.Comment.List();
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