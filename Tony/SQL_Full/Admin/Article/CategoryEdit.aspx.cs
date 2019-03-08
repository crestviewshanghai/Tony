using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Article_CategoryEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "Category.aspx?active=" + Request.QueryString["active"];

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Category"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Article.Category category = new MojoCube.Web.Article.Category();
                category.GetData(int.Parse(ViewState["pk_Category"].ToString()));

                txtPageName.Text = category.PageName;
                txtCategoryName.Text = category.CategoryName;
                txtSortID.Text = category.SortID.ToString();
                cbVisible.Checked = category.Visible;
                txtSEO_Title.Text = category.SEO_Title;
                txtSEO_Keyword.Text = category.SEO_Keyword;
                txtSEO_Description.Text = category.SEO_Description;

                this.Title = "文章分类编辑：" + txtCategoryName.Text.Trim();
            }
            else
            {
                txtPageName.Text = MojoCube.Web.String.GetPageName();
                cbVisible.Checked = true;
                this.Title = "文章分类编辑";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtCategoryName.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写名称");
            return;
        }

        MojoCube.Web.Article.Category category = new MojoCube.Web.Article.Category();

        //修改
        if (ViewState["pk_Category"] != null)
        {
            category.GetData(int.Parse(ViewState["pk_Category"].ToString()));
            category.PageName = txtPageName.Text.Trim();
            category.CategoryName = txtCategoryName.Text.Trim();
            category.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            category.Visible = cbVisible.Checked;
            category.SEO_Title = txtSEO_Title.Text.Trim();
            category.SEO_Keyword = txtSEO_Keyword.Text.Trim();
            category.SEO_Description = txtSEO_Description.Text.Trim();
            category.ModifyDate = DateTime.Now.ToString();
            category.ModifyUserID = int.Parse(Session["UserID"].ToString());
            category.UpdateData(category.pk_Category);
        }
        //新增
        else
        {
            if (Request.QueryString["parentId"] != null)
            {
                category.ParentID = int.Parse(MojoCube.Api.Text.Security.DecryptString(Request.QueryString["parentId"]));
            }
            else
            {
                category.ParentID = 0;
            }
            category.PageName = txtPageName.Text.Trim();
            category.CategoryName = txtCategoryName.Text.Trim();
            category.Subtitle = string.Empty;
            category.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            category.Visible = cbVisible.Checked;
            category.SEO_Title = txtSEO_Title.Text.Trim();
            category.SEO_Keyword = txtSEO_Keyword.Text.Trim();
            category.SEO_Description = txtSEO_Description.Text.Trim();
            category.Url = string.Empty;
            category.ImagePath = string.Empty;
            category.CreateDate = DateTime.Now.ToString();
            category.CreateUserID = int.Parse(Session["UserID"].ToString());
            category.ModifyDate = DateTime.Now.ToString();
            category.ModifyUserID = 0;
            category.Language = MojoCube.Api.UI.Language.GetLanguage();
            ViewState["pk_Category"] = category.InsertData();
        }

        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Category.aspx?active=" + Request.QueryString["active"]);
    }
}