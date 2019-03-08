using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Admin_Commons_Album : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["del"] != null)
            {
                MojoCube.Web.Image.List list = new MojoCube.Web.Image.List();
                list.DeleteData(int.Parse(Request.QueryString["del"]));
            }
            ViewState["OrderByKey"] = "pk_Image";
            ViewState["OrderByType"] = true;
            GridBind();
            CategoryBind();
            this.Title = "系统相册";
        }
    }

    protected void ddlCategory1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["CategoryID"] = ddlCategory1.SelectedValue;
        GridBind();
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
        pager.PageSize = 12;
        pager.ConnStr = MojoCube.Web.Connection.ConnString();
        pager.TableName = "Image_List";
        pager.strGetFields = "*";

        string where = "FileSize>0";

        if (ViewState["CategoryID"] != null && ViewState["CategoryID"].ToString() != "0")
        {
            where += " and fk_Category=" + ViewState["CategoryID"].ToString();
        }

        if (txtKeyword.Text.Trim() != "")
        {
            string keyword = MojoCube.Api.Text.CheckSql.Filter(txtKeyword.Text.Trim());
            where += " and (Title like '%" + keyword + "%')";
        }
        pager.where = where;
        pager.fldName = ViewState["OrderByKey"].ToString();
        pager.OrderType = (bool)ViewState["OrderByType"];

        ImageDiv.InnerHtml = CreateImage(pager.GetTable());
    }

    private string CreateImage(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            string imgPath = string.Empty;
            string imgUrl = string.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                imgPath = "../Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["FilePath"].ToString());

                imgUrl = Request.ApplicationPath + "/Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["FilePath"].ToString());
                imgUrl = imgUrl.Replace("//", "/");

                sb.Append("<div class=\"image-item\">");
                sb.Append("<div class=\"image-item-img\">");
                sb.Append("<a href=\"" + imgPath + "\" class=\"fancybox fancybox.image\" data-fancybox-group=\"gallery\" title=\"" + dt.Rows[i]["Title"].ToString() + "\"><img src=\"" + imgPath + "&w=200&h=200\" style=\"width:100px;\" /></a>");
                sb.Append("</div>");
                sb.Append("<div class=\"image-item-btn\">");
                sb.Append("<a href=\"javascript:InsertImage('" + imgUrl + "');\"><i class=\"fa fa-plus\"></i> 插入</a>");
                sb.Append("<a href=\"#\" class=\"del\" onclick=\"delImage(" + dt.Rows[i]["pk_Image"].ToString() + ");\"><i class=\"fa fa-remove\"></i> 删除</a>");
                sb.Append("</div>");
                sb.Append("</div>");
            }
        }

        return sb.ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        MojoCube.Api.File.Upload upload = new MojoCube.Api.File.Upload();
        upload.FilePath = "Image";
        upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
        upload.DoFileUpload(fuImage);

        if (upload.IsUpload)
        {
            MojoCube.Web.Image.List list = new MojoCube.Web.Image.List();
            list.fk_Category = int.Parse(ddlCategory2.SelectedValue);

            list.FileName = upload.OldFileName;
            list.FilePath = upload.OldFilePath;
            list.FileType = upload.FileType;
            list.FileSize = upload.FileSize;
            list.Width = 0;
            list.Height = 0;

            if (upload.IsImage())
            {
                System.Drawing.Image image = System.Drawing.Image.FromStream(fuImage.PostedFile.InputStream);
                list.Width = image.Width;
                list.Height = image.Height;
            }

            list.Title = txtTitle.Text.Trim();
            list.CreateDate = DateTime.Now.ToString();
            list.CreateUserID = int.Parse(Session["UserID"].ToString());
            list.ModifyDate = DateTime.Now.ToString();
            list.ModifyUserID = 0;
            list.Language = MojoCube.Api.UI.Language.GetLanguage();
            list.InsertData();

            GridBind();
        }
    }

    #region  分类

    private void CategoryBind()
    {
        DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Image_Category order by SortID asc").Tables[0];

        GridView1.DataSource = dt;
        GridView1.DataBind();

        MojoCube.Web.Sql.DropDownListBind(ddlCategory1, "Image_Category", "CategoryName", "pk_Category", "Visible=1", "SortID", "asc", new ListItem("全部图片", "0"));
        MojoCube.Web.Sql.DropDownListBind(ddlCategory2, "Image_Category", "CategoryName", "pk_Category", "Visible=1", "SortID", "asc", new ListItem("默认分类", "0"));
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtCategoryName.Text.Trim() != "")
        {
            MojoCube.Web.Image.Category category = new MojoCube.Web.Image.Category();
            category.CategoryName = txtCategoryName.Text.Trim();
            category.ParentID = 0;
            category.SortID = 0;
            category.Visible = true;
            category.CreateDate = DateTime.Now.ToString();
            category.CreateUserID = int.Parse(Session["UserID"].ToString());
            category.ModifyDate = DateTime.Now.ToString();
            category.ModifyUserID = 0;
            category.Language = MojoCube.Api.UI.Language.GetLanguage();
            category.InsertData();
            CategoryBind();
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            MojoCube.Web.String.ShowDel(e);
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        string[] list = { "gvUp", "gvDown", "gvSave", "gvDelete" };
        MojoCube.Api.UI.AdminGridView.SetDataRow(e, list);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        MojoCube.Web.Image.Category category = new MojoCube.Web.Image.Category();
        int index = Convert.ToInt32(e.CommandArgument);
        //保存
        if (e.CommandName == "_save")
        {
            category.GetData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));
            category.CategoryName = ((TextBox)GridView1.Rows[index].FindControl("txtCategoryNameGV")).Text;
            category.Visible = ((CheckBox)GridView1.Rows[index].FindControl("cbVisible")).Checked;
            category.UpdateData(category.pk_Category);
        }
        //删除
        if (e.CommandName == "_delete")
        {
            category.DeleteData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));
        }
        //上移
        if (e.CommandName == "_up")
        {
            MojoCube.Web.Sql.SetSortID("Image_Category", "pk_Category", ((Label)GridView1.Rows[index].FindControl("lblID")).Text, -1);
        }
        //下移
        if (e.CommandName == "_down")
        {
            MojoCube.Web.Sql.SetSortID("Image_Category", "pk_Category", ((Label)GridView1.Rows[index].FindControl("lblID")).Text, 1);
        }
        CategoryBind();
    }

    #endregion
}