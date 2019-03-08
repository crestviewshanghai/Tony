using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Site_Cache : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridBind();
            this.Title = "网站缓存";
        }
    }

    protected void lnbSearch_Click(object sender, EventArgs e)
    {
        GridBind();
    }

    private void GridBind()
    {
        MojoCube.Web.Site.Cache cache = new MojoCube.Web.Site.Cache();
        DataSet ds = new DataSet();
        ds = cache.GetCacheDS();

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        dt.DefaultView.Sort = "CacheKey ASC";

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((Label)e.Row.FindControl("lblID")).Text = (e.Row.DataItemIndex + 1).ToString();
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
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "_delete")
        {
            MojoCube.Web.Site.Cache.RemoveCache(((Label)GridView1.Rows[index].FindControl("lblCacheKey")).Text);
        }
        GridBind();
    }

    protected void lnbDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].FindControl("cbSelect");
            if (cb.Checked == true)
            {
                MojoCube.Web.Site.Cache.RemoveCache(((Label)GridView1.Rows[i].FindControl("lblCacheKey")).Text);
            }
        }
        GridBind();
    }

    protected void lnbDelAll_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Session.Remove("MojoCube_Language");
        HttpContext.Current.Response.Cookies["MojoCube_Language"].Expires = DateTime.Now.AddDays(-1);

        MojoCube.Web.Site.Cache cache = new MojoCube.Web.Site.Cache();
        cache.RemoveAllCache();
        GridBind();
    }
}