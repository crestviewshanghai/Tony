using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Download_Edit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MojoCube.Web.Sql.BindClass(ddlCategory, "Download_Category");

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Download"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Download.List list = new MojoCube.Web.Download.List();
                list.GetData(int.Parse(ViewState["pk_Download"].ToString()));

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

                if (list.FilePath != "")
                {
                    SetImage(list.FileType, list.FilePath);
                }

                this.Title = "下载编辑：" + txtTitle.Text.Trim();
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

                this.Title = "下载编辑";
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

    #region  设置图片

    private void SetImage(string fileType, string filePath)
    {
        lnbRemoveFile.Visible = true;
        imgMain.Visible = true;

        if (fileType == "jpg" || fileType == "jpeg" || fileType == "gif" || fileType == "png" || fileType == "bmp")
        {
            imgMain.ImageUrl = "../Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(filePath) + "&w=400&h=300";
        }
        else if (fileType == "ai")
        {
            imgMain.ImageUrl = GetIcon("ai");
        }
        else if (fileType == "apk")
        {
            imgMain.ImageUrl = GetIcon("apk");
        }
        else if (fileType == "doc" || fileType == "docx")
        {
            imgMain.ImageUrl = GetIcon("doc");
        }
        else if (fileType == "eml")
        {
            imgMain.ImageUrl = GetIcon("eml");
        }
        else if (fileType == "html" || fileType == "htm" || fileType == "xml")
        {
            imgMain.ImageUrl = GetIcon("html");
        }
        else if (fileType == "ics")
        {
            imgMain.ImageUrl = GetIcon("ics");
        }
        else if (fileType == "iso")
        {
            imgMain.ImageUrl = GetIcon("iso");
        }
        else if (fileType == "mdb")
        {
            imgMain.ImageUrl = GetIcon("mdb");
        }
        else if (fileType == "mp3" || fileType == "wav" || fileType == "aac" || fileType == "asf" || fileType == "wma" || fileType == "ogg" || fileType == "ape")
        {
            imgMain.ImageUrl = GetIcon("mp3");
        }
        else if (fileType == "pdf")
        {
            imgMain.ImageUrl = GetIcon("pdf");
        }
        else if (fileType == "ppt")
        {
            imgMain.ImageUrl = GetIcon("ppt");
        }
        else if (fileType == "psd")
        {
            imgMain.ImageUrl = GetIcon("psd");
        }
        else if (fileType == "torrent")
        {
            imgMain.ImageUrl = GetIcon("torrent");
        }
        else if (fileType == "txt")
        {
            imgMain.ImageUrl = GetIcon("txt");
        }
        else if (fileType == "wmv" || fileType == "mp4" || fileType == "avi" || fileType == "rmvb" || fileType == "rm" || fileType == "mpg" || fileType == "3gp" || fileType == "mkv" || fileType == "vob" || fileType == "mov" || fileType == "flv" || fileType == "swf")
        {
            imgMain.ImageUrl = GetIcon("wmv");
        }
        else if (fileType == "xls" || fileType == "xlsx")
        {
            imgMain.ImageUrl = GetIcon("xls");
        }
        else if (fileType == "zip" || fileType == "rar")
        {
            imgMain.ImageUrl = GetIcon("zip");
        }
        else
        {
            imgMain.ImageUrl = GetIcon("other");
        }
    }

    private string GetIcon(string typeName)
    {
        imgMain.Width = 200;
        return "../Images/FileType/" + typeName + ".png";
    }

    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtTitle.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写标题");
            return;
        }

        MojoCube.Api.File.Upload upload = new MojoCube.Api.File.Upload();
        upload.FilePath = "Download/" + txtPageName.Text.Trim();
        upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
        upload.DoFileUpload(fuFile);

        MojoCube.Web.Download.List list = new MojoCube.Web.Download.List();

        //修改
        if (ViewState["pk_Download"] != null)
        {
            list.GetData(int.Parse(ViewState["pk_Download"].ToString()));

            MojoCube.Web.Download.Category category = new MojoCube.Web.Download.Category();
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
                list.FileName = upload.OldFileName;
                list.FilePath = upload.OldFilePath;
                list.FileType = upload.FileType;
                list.FileSize = upload.FileSize;
                SetImage(list.FileType, list.FilePath);
            }
            list.ModifyDate = DateTime.Now.ToString();
            list.ModifyUserID = int.Parse(Session["UserID"].ToString());
            list.UpdateData(list.pk_Download);
        }
        //新增
        else
        {
            MojoCube.Web.Download.Category category = new MojoCube.Web.Download.Category();
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
            list.Author = string.Empty;
            list.Source = string.Empty;
            list.SourceUrl = string.Empty;
            list.ImagePath = string.Empty;
            if (upload.IsUpload)
            {
                list.FileName = upload.OldFileName;
                list.FilePath = upload.OldFilePath;
                list.FileType = upload.FileType;
                list.FileSize = upload.FileSize;
                SetImage(list.FileType, list.FilePath);
            }
            else
            {
                list.FileName = string.Empty;
                list.FilePath = string.Empty;
                list.FileType = string.Empty;
                list.FileSize = 0;
            }
            list.Version = string.Empty;
            list.Issue = cbIssue.Checked;
            list.IsComment = false;
            list.IsRecommend = false;
            list.Clicks = 0;
            list.Downloads = 0;
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
            ViewState["pk_Download"] = list.InsertData();
        }

        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
    }

    protected void lnbRemoveFile_Click(object sender, EventArgs e)
    {
        MojoCube.Web.Download.List list = new MojoCube.Web.Download.List();
        list.GetData(int.Parse(ViewState["pk_Download"].ToString()));
        list.FileName = string.Empty;
        list.FilePath = string.Empty;
        list.FileType = string.Empty;
        list.FileSize = 0;
        list.UpdateData(list.pk_Download);
        imgMain.Visible = false;
        lnbRemoveFile.Visible = false;
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