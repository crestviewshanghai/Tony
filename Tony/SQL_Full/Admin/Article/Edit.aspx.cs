using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Article_Edit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MojoCube.Web.Sql.BindClass(ddlCategory, "Article_Category");

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Article"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Article.List list = new MojoCube.Web.Article.List();
                list.GetData(int.Parse(ViewState["pk_Article"].ToString()));

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

                this.Title = "文章编辑：" + txtTitle.Text.Trim();
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

                this.Title = "文章编辑";
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
        upload.FilePath = "Article/" + txtPageName.Text.Trim();
        upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
        upload.DoFileUpload(fuImage);

        MojoCube.Web.Article.List list = new MojoCube.Web.Article.List();

        //修改
        if (ViewState["pk_Article"] != null)
        {
            list.GetData(int.Parse(ViewState["pk_Article"].ToString()));

            MojoCube.Web.Article.Category category = new MojoCube.Web.Article.Category();
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
            list.UpdateData(list.pk_Article);
        }
        //新增
        else
        {
            MojoCube.Web.Article.Category category = new MojoCube.Web.Article.Category();
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
            list.Author = Session["UserName"].ToString();
            list.Source = string.Empty;
            list.SourceUrl = string.Empty;
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
            ViewState["pk_Article"] = list.InsertData();
        }

        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
    }

    protected void lnbRemoveImage_Click(object sender, EventArgs e)
    {
        MojoCube.Web.Article.List list = new MojoCube.Web.Article.List();
        list.GetData(int.Parse(ViewState["pk_Article"].ToString()));
        list.ImagePath = string.Empty;
        list.UpdateData(list.pk_Article);
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
}