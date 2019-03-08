using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Admin_Site_Theme : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["OrderByKey"] = "pk_Log";
            ViewState["OrderByType"] = true;
            GridBind();
            this.Title = "网站主题";
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
        DataSet ds = new DataSet();
        string[] files = Directory.GetDirectories(Server.MapPath("../../Themes/"));
        ds = MojoCube.Api.File.IO.GetDirectoryDS(files);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        dt.DefaultView.Sort = "FileName ASC";

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //行数
            ((Label)e.Row.FindControl("lblID")).Text = (e.Row.DataItemIndex + 1).ToString();

            if (((Label)e.Row.FindControl("lblThumbnail")).Text != "")
            {
                string imgPath = "../../Themes/" + ((Label)e.Row.FindControl("lblThumbnail")).Text + "/preview.png";
                ((Label)e.Row.FindControl("lblThumbnail")).Text = "<a href=\"" + imgPath + "\" class=\"fancybox fancybox.image\" data-fancybox-group=\"gallery\" title=\"" + ((Label)e.Row.FindControl("lblFileName")).Text + "\"><img src=\"" + imgPath + "\" style=\"width:60px; border:solid 1px #eee; padding:1px;\" /></a>";
            }

            if (((Label)e.Row.FindControl("lblFileName")).Text == MojoCube.Web.Site.Cache.GetSiteTheme(MojoCube.Api.UI.Language.GetLanguage()))
            {
                ((Label)e.Row.FindControl("lblCurrent")).Text = "当前";
            }

            MojoCube.Web.String.ShowDel(e);
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        string[] list = { "gvApply", "gvDelete" };
        MojoCube.Api.UI.AdminGridView.SetDataRow(e, list);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        //apply
        if (e.CommandName == "_apply")
        {
            MojoCube.Web.Site.Config config = new MojoCube.Web.Site.Config();
            config.GetData(1, MojoCube.Api.UI.Language.GetLanguage());

            config.SiteTheme = ((Label)GridView1.Rows[index].FindControl("lblFileName")).Text;
            config.UpdateData(config.pk_Config);

            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "主题已修改成功");
        }
        //delete
        if (e.CommandName == "_delete")
        {
            string fileName = ((Label)GridView1.Rows[index].FindControl("lblFileName")).Text;
            bool IsDelete = MojoCube.Api.File.IO.DeleteDirectory(Server.MapPath("../../Themes/" + fileName));
            if (IsDelete)
            {
                AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "主题已删除成功");
            }
            else
            {
                AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "主题已删除失败");
            }
        }

        MojoCube.Web.Site.Cache cache = new MojoCube.Web.Site.Cache();
        cache.RemoveAllCache();
        GridBind();
    }
}