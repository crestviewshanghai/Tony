using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Album_Edit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MojoCube.Web.Sql.BindClass(ddlCategory, "Album_Category");

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Album"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Album.List list = new MojoCube.Web.Album.List();
                list.GetData(int.Parse(ViewState["pk_Album"].ToString()));

                txtTitle.Text = list.Title;
                txtDescription.Text = list.Description;
                txtPageName.Text = list.PageName;
                txtSubtitle.Text = list.Subtitle;
                cbIssue.Checked = list.Issue;
                txtSEO_Title.Text = list.SEO_Title;
                txtSEO_Keyword.Text = list.SEO_Keyword;
                txtSEO_Description.Text = list.SEO_Description;

                if (list.CategoryID2 > 0)
                {
                    MojoCube.Web.Sql.ddlFindByValue(ddlCategory, list.CategoryID2.ToString());
                }
                else
                {
                    MojoCube.Web.Sql.ddlFindByValue(ddlCategory, list.CategoryID1.ToString());
                }

                if (list.ImagePath != "")
                {
                    SetImage(list.ImagePath);
                }

                ImageBind();

                this.Title = "相册编辑：" + txtTitle.Text.Trim();
            }
            else
            {
                string parentId = "0";

                if (Request.QueryString["parentId"] != null)
                {
                    parentId = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["parentId"]);
                }

                MojoCube.Web.Sql.ddlFindByValue(ddlCategory, parentId);

                txtPageName.Text = MojoCube.Web.String.GetPageName();
                cbIssue.Checked = true;

                this.Title = "相册编辑";
            }

            if (ddlCategory.SelectedValue != "0")
            {
                hlBack.NavigateUrl = "List.aspx?parentId=" + MojoCube.Api.Text.Security.EncryptString(ddlCategory.SelectedValue) + "&active=" + Request.QueryString["active"];
            }
            else
            {
                hlBack.NavigateUrl = "List.aspx?active=" + Request.QueryString["active"];
            }
        }
    }

    private void SetImage(string imgPath)
    {
        lnbRemoveImage.Visible = true;
        imgMain.Attributes.Add("style", "display:block");
        imgMain.ImageUrl = "~/Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(imgPath) + "&w=300&h=200";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtTitle.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写标题");
            return;
        }

        MojoCube.Api.File.Upload upload = new MojoCube.Api.File.Upload();
        upload.FilePath = "Album/" + txtPageName.Text.Trim();
        upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
        upload.DoFileUpload(fuImage);

        MojoCube.Web.Album.List list = new MojoCube.Web.Album.List();

        //修改
        if (ViewState["pk_Album"] != null)
        {
            list.GetData(int.Parse(ViewState["pk_Album"].ToString()));

            MojoCube.Web.Album.Category category = new MojoCube.Web.Album.Category();
            category.GetData(int.Parse(ddlCategory.SelectedValue));

            if (category.ParentID == 0)
            {
                list.CategoryID1 = category.pk_Category;
                list.CategoryID2 = 0;
            }
            else
            {
                list.CategoryID1 = category.ParentID;
                list.CategoryID2 = category.pk_Category;
            }

            list.Title = txtTitle.Text.Trim();
            list.PageName = txtPageName.Text.Trim();
            list.Subtitle = txtSubtitle.Text.Trim();
            list.Description = txtDescription.Text.Trim();
            list.Issue = cbIssue.Checked;
            list.SEO_Title = txtSEO_Title.Text.Trim();
            list.SEO_Keyword = txtSEO_Keyword.Text.Trim();
            list.SEO_Description = txtSEO_Description.Text.Trim();
            if (upload.IsUpload)
            {
                list.ImagePath = upload.OldFilePath;
                SetImage(list.ImagePath);
            }
            list.ModifyDate = DateTime.Now.ToString();
            list.ModifyUserID = int.Parse(Session["UserID"].ToString());
            list.UpdateData(list.pk_Album);
        }
        //新增
        else
        {
            MojoCube.Web.Album.Category category = new MojoCube.Web.Album.Category();
            category.GetData(int.Parse(ddlCategory.SelectedValue));

            if (category.ParentID == 0)
            {
                list.CategoryID1 = category.pk_Category;
                list.CategoryID2 = 0;
            }
            else
            {
                list.CategoryID1 = category.ParentID;
                list.CategoryID2 = category.pk_Category;
            }

            list.PageName = txtPageName.Text.Trim();
            list.Title = txtTitle.Text.Trim();
            list.Subtitle = txtSubtitle.Text.Trim();
            list.Description = txtDescription.Text.Trim();
            if (txtSEO_Title.Text.Trim() != "")
            {
                list.SEO_Title = txtSEO_Title.Text.Trim();
            }
            else
            {
                list.SEO_Title = txtTitle.Text.Trim();
            }
            list.SEO_Keyword = txtSEO_Keyword.Text.Trim();
            list.SEO_Description = txtSEO_Description.Text.Trim();
            list.Tags = string.Empty;
            list.Visual = string.Empty;
            if (upload.IsUpload)
            {
                list.ImagePath = upload.OldFilePath;
                SetImage(list.ImagePath);
            }
            else
            {
                list.ImagePath = string.Empty;
            }
            list.Issue = cbIssue.Checked;
            list.IsComment = false;
            list.IsRecommend = false;
            list.Clicks = 0;
            list.SortID = 0;
            list.TypeID = 0;
            list.Score = 0;
            list.ScoreIn = 0;
            list.StartDate = DateTime.Now.ToString();
            list.EndDate = DateTime.Now.ToString();
            list.CreateDate = DateTime.Now.ToString();
            list.CreateUserID = int.Parse(Session["UserID"].ToString());
            list.ModifyDate = DateTime.Now.ToString();
            list.ModifyUserID = 0;
            list.Language = MojoCube.Api.UI.Language.GetLanguage();
            ViewState["pk_Album"] = list.InsertData();
        }

        ImageBind();

        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
    }

    protected void lnbRemoveImage_Click(object sender, EventArgs e)
    {
        MojoCube.Web.Album.List list = new MojoCube.Web.Album.List();
        list.GetData(int.Parse(ViewState["pk_Album"].ToString()));
        list.ImagePath = string.Empty;
        list.UpdateData(list.pk_Album);
        imgMain.Attributes.Add("style", "display:none");
        lnbRemoveImage.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedValue != "0")
        {
            Response.Redirect("List.aspx?parentId=" + MojoCube.Api.Text.Security.EncryptString(ddlCategory.SelectedValue) + "&active=" + Request.QueryString["active"]);
        }
        else
        {
            Response.Redirect("List.aspx?active=" + Request.QueryString["active"]);
        }
    }

    #region  图片集

    private void ImageBind()
    {
        if (ViewState["pk_Album"] != null)
        {
            txtImageTitle.Text = "";
            txtImageSort.Text = "";
            btnUpload.Enabled = true;

            DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Album_Image where fk_Album=" + ViewState["pk_Album"].ToString() + " order by SortID asc,pk_Image asc").Tables[0];

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        MojoCube.Api.File.Upload upload = new MojoCube.Api.File.Upload();
        upload.FilePath = "Album/" + txtPageName.Text.Trim();
        upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
        upload.DoFileUpload(fuImageUpload);

        if (upload.IsUpload)
        {
            MojoCube.Web.Album.Image image = new MojoCube.Web.Album.Image();
            image.fk_Album = int.Parse(ViewState["pk_Album"].ToString());
            image.FileName = upload.OldFileName;
            image.FilePath = upload.OldFilePath;
            image.FileType = upload.FileType;
            image.FileSize = upload.FileSize;
            image.Width = 0;
            image.Height = 0;
            if (upload.IsImage())
            {
                System.Drawing.Image draw = System.Drawing.Image.FromStream(fuImageUpload.PostedFile.InputStream);
                image.Width = draw.Width;
                image.Height = draw.Height;
            }
            image.Title = txtImageTitle.Text.Trim();
            image.SortID = MojoCube.Web.String.ToInt(txtImageSort.Text.Trim());
            image.Visible = true;
            image.CreateDate = DateTime.Now.ToString();
            image.CreateUserID = int.Parse(Session["UserID"].ToString());
            image.ModifyDate = DateTime.Now.ToString();
            image.ModifyUserID = 0;
            image.Language = MojoCube.Api.UI.Language.GetLanguage();
            image.InsertData();
            ImageBind();
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((Label)e.Row.FindControl("lblThumbnail")).Text != "")
            {
                string imgPath = "../Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblThumbnail")).Text);
                ((Label)e.Row.FindControl("lblThumbnail")).Text = "<a href=\"" + imgPath + "\" class=\"fancybox fancybox.image\" data-fancybox-group=\"gallery\" title=\"" + ((TextBox)e.Row.FindControl("txtTitleGV")).Text + "\"><img src=\"" + imgPath + "&w=120&h=90\" style=\"height:25px;\" /></a>";
            }

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
        MojoCube.Web.Album.Image image = new MojoCube.Web.Album.Image();
        int index = Convert.ToInt32(e.CommandArgument);
        //保存
        if (e.CommandName == "_save")
        {
            image.GetData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));
            image.Title = ((TextBox)GridView1.Rows[index].FindControl("txtTitleGV")).Text;
            image.Visible = ((CheckBox)GridView1.Rows[index].FindControl("cbVisible")).Checked;
            image.UpdateData(image.pk_Image);
        }
        //删除
        if (e.CommandName == "_delete")
        {
            image.DeleteData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));
        }
        //上移
        if (e.CommandName == "_up")
        {
            MojoCube.Web.Sql.SetSortID("Album_Image", "pk_Image", ((Label)GridView1.Rows[index].FindControl("lblID")).Text, -1);
        }
        //下移
        if (e.CommandName == "_down")
        {
            MojoCube.Web.Sql.SetSortID("Album_Image", "pk_Image", ((Label)GridView1.Rows[index].FindControl("lblID")).Text, 1);
        }
        ImageBind();
        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
    }

    #endregion
}