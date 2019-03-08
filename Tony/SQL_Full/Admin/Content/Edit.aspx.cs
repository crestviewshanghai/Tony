using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Content_Edit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                hlBack.NavigateUrl = "List.aspx?active=" + Request.QueryString["active"];

                if (Request.QueryString["id"] != null)
                {
                    ViewState["pk_Content"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                    MojoCube.Web.Content.List list = new MojoCube.Web.Content.List();
                    list.GetData(int.Parse(ViewState["pk_Content"].ToString()));

                    txtTitle.Text = list.Title;
                    txtPageName.Text = list.PageName;
                    txtSubtitle.Text = list.Subtitle;
                    cbVisible.Checked = list.Visible;
                    txtDescription.Text = list.Description;
                    txtSEO_Title.Text = list.SEO_Title;
                    txtSEO_Keyword.Text = list.SEO_Keyword;
                    txtSEO_Description.Text = list.SEO_Description;

                    if (list.ImagePath != "")
                    {
                        SetImage(list.ImagePath);
                    }

                    this.Title = "内容编辑：" + txtTitle.Text.Trim();
                }
                else
                {
                    cbVisible.Checked = true;
                    this.Title = "内容编辑";
                }
            }
        }
    }

    private void SetImage(string imgPath)
    {
        lnbRemoveImage.Visible = true;
        imgMain.Attributes.Add("style", "display:block");
        imgMain.ImageUrl = "~/Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(imgPath) + "&w=400&h=300";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtTitle.Text.Trim() == "" || txtPageName.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写标题和页面名称");
            return;
        }

        MojoCube.Api.File.Upload upload = new MojoCube.Api.File.Upload();
        upload.FilePath = "Content";
        upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
        upload.DoFileUpload(fuImage);

        MojoCube.Web.Content.List list = new MojoCube.Web.Content.List();

        //修改
        if (ViewState["pk_Content"] != null)
        {
            list.GetData(int.Parse(ViewState["pk_Content"].ToString()));
            list.PageName = txtPageName.Text.Trim();
            list.Title = txtTitle.Text.Trim();
            list.Subtitle = txtSubtitle.Text.Trim();
            list.Description = txtDescription.Text.Trim();
            if (upload.IsUpload)
            {
                list.ImagePath = upload.OldFilePath;
                SetImage(list.ImagePath);
            }
            list.Visible = cbVisible.Checked;
            list.SEO_Title = txtSEO_Title.Text.Trim();
            list.SEO_Keyword = txtSEO_Keyword.Text.Trim();
            list.SEO_Description = txtSEO_Description.Text.Trim();
            list.ModifyDate = DateTime.Now.ToString();
            list.ModifyUserID = int.Parse(Session["UserID"].ToString());
            list.UpdateData(list.pk_Content);
        }
        //新增
        else
        {
            list.PageName = txtPageName.Text.Trim();
            list.Title = txtTitle.Text.Trim();
            list.Subtitle = txtSubtitle.Text.Trim();
            list.Description = txtDescription.Text.Trim();
            list.Visible = cbVisible.Checked;
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
            list.Clicks = 0;
            if (upload.IsUpload)
            {
                list.ImagePath = upload.OldFilePath;
                SetImage(list.ImagePath);
            }
            else
            {
                list.ImagePath = string.Empty;
            }
            list.CreateDate = DateTime.Now.ToString();
            list.CreateUserID = int.Parse(Session["UserID"].ToString());
            list.ModifyDate = DateTime.Now.ToString();
            list.ModifyUserID = 0;
            list.Language = MojoCube.Api.UI.Language.GetLanguage();
            ViewState["pk_Content"] = list.InsertData();
        }

        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
    }

    protected void lnbRemoveImage_Click(object sender, EventArgs e)
    {
        MojoCube.Web.Content.List list = new MojoCube.Web.Content.List();
        list.GetData(int.Parse(ViewState["pk_Content"].ToString()));
        list.ImagePath = string.Empty;
        list.UpdateData(list.pk_Content);
        imgMain.Attributes.Add("style", "display:none");
        lnbRemoveImage.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("List.aspx?active=" + Request.QueryString["active"]);
    }
}