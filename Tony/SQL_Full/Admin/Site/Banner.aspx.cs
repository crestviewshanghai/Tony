using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Site_Banner : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlAdd.NavigateUrl = "BannerEdit.aspx?active=" + Request.QueryString["active"];
            ViewState["OrderByKey"] = "SortID";
            ViewState["OrderByType"] = false;
            GridBind();
            this.Title = "网站横幅";
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
        pager.TableName = "Site_Banner";
        pager.strGetFields = "*";

        string where = "Language='" + MojoCube.Api.UI.Language.GetLanguage() + "'";

        if (txtKeyword.Text.Trim() != "")
        {
            string keyword = MojoCube.Api.Text.CheckSql.Filter(txtKeyword.Text.Trim());
            where += " and (Title like '%" + keyword + "%')";
        }

        pager.where = where;
        pager.fldName = ViewState["OrderByKey"].ToString();
        pager.OrderType = (bool)ViewState["OrderByType"];

        GridView1.DataSource = pager.GetTable();
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string id = MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);

            ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "BannerEdit.aspx?id=" + id + "&active=" + Request.QueryString["active"];

            if (((Label)e.Row.FindControl("lblThumbnail")).Text != "")
            {
                string imgPath = "../Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblThumbnail")).Text);
                ((Label)e.Row.FindControl("lblThumbnail")).Text = "<a href=\"" + imgPath + "\" class=\"fancybox fancybox.image\" data-fancybox-group=\"gallery\" title=\"" + ((Label)e.Row.FindControl("lblTitle")).Text + "\"><img src=\"" + imgPath + "&w=120&h=90\" style=\"height:25px;\" /></a>";
            }

            MojoCube.Web.String.ShowDel(e);
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        MojoCube.Api.UI.AdminGridView.SetSortingRowCreated(e, (string)ViewState["OrderByKey"], (bool)ViewState["OrderByType"], GridView1);
        string[] list = { "gvUp", "gvDown", "gvDelete" };
        MojoCube.Api.UI.AdminGridView.SetDataRow(e, list);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        MojoCube.Web.Site.Banner banner = new MojoCube.Web.Site.Banner();
        int index = Convert.ToInt32(e.CommandArgument);
        //删除
        if (e.CommandName == "_delete")
        {
            banner.DeleteData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));
        }
        //上移
        if (e.CommandName == "_up")
        {
            MojoCube.Web.Sql.SetSortID("Site_Banner", "pk_Banner", ((Label)GridView1.Rows[index].FindControl("lblID")).Text, -1);
        }
        //下移
        if (e.CommandName == "_down")
        {
            MojoCube.Web.Sql.SetSortID("Site_Banner", "pk_Banner", ((Label)GridView1.Rows[index].FindControl("lblID")).Text, 1);
        }
        GridBind();
    }
}