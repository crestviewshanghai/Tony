using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Site_BannerEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "Banner.aspx?active=" + Request.QueryString["active"];

            MojoCube.Web.Sql.DropDownListBind(ddlType, "Sys_TypeID", "TypeName_CHS", "ID", "TableName='Site_Banner'", "ID", "asc");

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Banner"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Site.Banner banner = new MojoCube.Web.Site.Banner();
                banner.GetData(int.Parse(ViewState["pk_Banner"].ToString()));

                txtTitle.Text = banner.Title;
                txtDescription.Text = banner.Description;
                txtSortID.Text = banner.SortID.ToString();
                txtUrl.Text = banner.Url;
                cbVisible.Checked = banner.Visible;

                MojoCube.Web.Sql.ddlFindByValue(ddlType, banner.TypeID.ToString());

                if (banner.FilePath != "")
                {
                    SetImage(banner.FilePath);
                }

                this.Title = "横幅编辑：" + txtTitle.Text.Trim();
            }
            else
            {
                cbVisible.Checked = true;
                this.Title = "横幅编辑";
            }
        }
    }

    private void SetImage(string imgPath)
    {
        lnbRemoveImage.Visible = true;
        imgBanner.Attributes.Add("style", "display:block");
        imgBanner.ImageUrl = "~/Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(imgPath) + "&w=400&h=300";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtTitle.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写标题");
            return;
        }

        MojoCube.Api.File.Upload upload = new MojoCube.Api.File.Upload();
        upload.FilePath = "Site/Banner";
        upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
        upload.DoFileUpload(fuBanner);

        MojoCube.Web.Site.Banner banner = new MojoCube.Web.Site.Banner();

        //修改
        if (ViewState["pk_Banner"] != null)
        {
            banner.GetData(int.Parse(ViewState["pk_Banner"].ToString()));
            banner.Title = txtTitle.Text.Trim();
            banner.Description = txtDescription.Text.Trim();
            banner.Url = txtUrl.Text.Trim();
            banner.TypeID = int.Parse(ddlType.SelectedValue);
            banner.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            banner.Visible = cbVisible.Checked;
            banner.ModifyDate = DateTime.Now.ToString();
            banner.ModifyUserID = int.Parse(Session["UserID"].ToString());

            if (upload.IsUpload)
            {
                banner.FileName = upload.OldFileName;
                banner.FilePath = upload.OldFilePath;
                banner.FileType = upload.FileType;
                banner.FileSize = upload.FileSize;

                if (upload.IsImage())
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(fuBanner.PostedFile.InputStream);
                    banner.Width = image.Width;
                    banner.Height = image.Height;
                }

                SetImage(banner.FilePath);
            }

            banner.UpdateData(banner.pk_Banner);
        }
        //新增
        else
        {
            banner.Title = txtTitle.Text.Trim();
            banner.Description = txtDescription.Text.Trim();
            banner.Url = txtUrl.Text.Trim();
            banner.Target = "_blank";
            banner.TypeID = int.Parse(ddlType.SelectedValue);

            if (upload.IsUpload)
            {
                banner.FileName = upload.OldFileName;
                banner.FilePath = upload.OldFilePath;
                banner.FileType = upload.FileType;
                banner.FileSize = upload.FileSize;

                if (upload.IsImage())
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(fuBanner.PostedFile.InputStream);
                    banner.Width = image.Width;
                    banner.Height = image.Height;
                }

                SetImage(banner.FilePath);
            }
            else 
            {
                banner.FileName = string.Empty;
                banner.FilePath = string.Empty;
                banner.FileType = string.Empty;
                banner.FileSize = 0;
                banner.Width = 0;
                banner.Height = 0;
            }

            banner.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            banner.Visible = cbVisible.Checked;
            banner.CreateDate = DateTime.Now.ToString();
            banner.CreateUserID = int.Parse(Session["UserID"].ToString());
            banner.ModifyDate = DateTime.Now.ToString();
            banner.ModifyUserID = 0;
            banner.Language = MojoCube.Api.UI.Language.GetLanguage();
            ViewState["pk_Banner"] = banner.InsertData();
        }

        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
    }

    protected void lnbRemoveImage_Click(object sender, EventArgs e)
    {
        MojoCube.Web.Site.Banner banner = new MojoCube.Web.Site.Banner();
        banner.GetData(int.Parse(ViewState["pk_Banner"].ToString()));
        banner.FilePath = string.Empty;
        banner.UpdateData(banner.pk_Banner);
        imgBanner.Attributes.Add("style", "display:none");
        lnbRemoveImage.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Banner.aspx?active=" + Request.QueryString["active"]);
    }
}