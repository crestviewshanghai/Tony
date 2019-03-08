using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class Admin_Download_List : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["OrderByKey"] = "pk_Download";
            ViewState["OrderByType"] = true;

            if (Request.QueryString["parentId"] != null)
            {
                ViewState["ParentID"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["parentId"]);

                MojoCube.Web.Download.Category category = new MojoCube.Web.Download.Category();
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
            this.Title = "下载列表";
        }
    }

    private string CreateCategory()
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Download_Category where Visible=1 and ParentID=" + ViewState["ParentID"].ToString() + " and Language='" + MojoCube.Api.UI.Language.GetLanguage() + "' order by SortID asc").Tables[0];

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
        pager.TableName = "Download_List";
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

            ((HyperLink)e.Row.FindControl("gvView")).NavigateUrl = "~/" + MojoCube.Web.Site.Cache.GetUrlExtension("D-" + ((Label)e.Row.FindControl("lblPageName")).Text, MojoCube.Api.UI.Language.GetLanguage());
            ((HyperLink)e.Row.FindControl("gvView")).Target = "_blank";

            ((Label)e.Row.FindControl("lblFileSize")).Text = MojoCube.Api.File.IO.FormatFileSize(((Label)e.Row.FindControl("lblFileSize")).Text);

            #region  文件格式

            string fileType = ((Label)e.Row.FindControl("lblFileType")).Text;

            if (fileType == "jpg" || fileType == "jpeg" || fileType == "gif" || fileType == "png" || fileType == "bmp")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetImage(((Label)e.Row.FindControl("lblFilePath")).Text, ((Label)e.Row.FindControl("lblTitle")).Text);
            }
            else if (fileType == "ai")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("ai");
            }
            else if (fileType == "apk")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("apk");
            }
            else if (fileType == "doc" || fileType == "docx")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("doc");
            }
            else if (fileType == "eml")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("eml");
            }
            else if (fileType == "html" || fileType == "htm" || fileType == "xml")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("html");
            }
            else if (fileType == "ics")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("ics");
            }
            else if (fileType == "iso")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("iso");
            }
            else if (fileType == "mdb")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("mdb");
            }
            else if (fileType == "mp3" || fileType == "wav" || fileType == "aac" || fileType == "asf" || fileType == "wma" || fileType == "ogg" || fileType == "ape")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("mp3");
            }
            else if (fileType == "pdf")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("pdf");
            }
            else if (fileType == "ppt")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("ppt");
            }
            else if (fileType == "psd")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("psd");
            }
            else if (fileType == "torrent")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("torrent");
            }
            else if (fileType == "txt")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("txt");
            }
            else if (fileType == "wmv" || fileType == "mp4" || fileType == "avi" || fileType == "rmvb" || fileType == "rm" || fileType == "mpg" || fileType == "3gp" || fileType == "mkv" || fileType == "vob" || fileType == "mov" || fileType == "flv" || fileType == "swf")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("wmv");
            }
            else if (fileType == "xls" || fileType == "xlsx")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("xls");
            }
            else if (fileType == "zip" || fileType == "rar")
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("zip");
            }
            else
            {
                ((Label)e.Row.FindControl("lblThumbnail")).Text = GetIcon("other");
            }

            #endregion

            MojoCube.Web.String.ShowDel(e);
        }
    }

    private string GetImage(string imgPath, string title)
    {
        imgPath = "../Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(imgPath);

        return "<a href=\"" + imgPath + "\" class=\"fancybox fancybox.image\" data-fancybox-group=\"gallery\" title=\"" + title + "\"><img src=\"" + imgPath + "&cut=50,50\" style=\"width:25px; height:25px;\" /></a>";
    }

    private string GetIcon(string typeName)
    {
        return "<img src=\"../Images/FileType/" + typeName + ".png\" style=\"width:25px;\" />";
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        MojoCube.Api.UI.AdminGridView.SetSortingRowCreated(e, (string)ViewState["OrderByKey"], (bool)ViewState["OrderByType"], GridView1);
        string[] list = { "gvDelete" };
        MojoCube.Api.UI.AdminGridView.SetDataRow(e, list);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        MojoCube.Web.Download.List list = new MojoCube.Web.Download.List();
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