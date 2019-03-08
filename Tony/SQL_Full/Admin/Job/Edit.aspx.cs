using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Job_Edit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MojoCube.Web.Sql.BindClass(ddlCategory, "Job_Category");

            MojoCube.Web.Sql.DropDownListBind(ddlType, "Sys_TypeID", "TypeName_CHS", "ID", "TableName='Job_List'", "ID", "asc");

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Job"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Job.List list = new MojoCube.Web.Job.List();
                list.GetData(int.Parse(ViewState["pk_Job"].ToString()));

                txtTitle.Text = list.Title;
                txtDescription.Text = list.Description;
                txtPageName.Text = list.PageName;
                txtSubtitle.Text = list.Subtitle;
                cbIssue.Checked = list.Issue;
                txtSEO_Title.Text = list.SEO_Title;
                txtSEO_Keyword.Text = list.SEO_Keyword;
                txtSEO_Description.Text = list.SEO_Description;

                txtDepartment.Text = list.Department;
                txtPosition.Text = list.Position;
                txtNumber.Text = list.Number;
                txtPlace.Text = list.Place;
                txtEducation.Text = list.Education;
                txtSex.Text = list.Sex;
                txtAge.Text = list.Age;
                txtExperiences.Text = list.Experiences;
                txtWages.Text = list.Wages;
                txtEndDate.Text = DateTime.Parse(list.EndDate).ToString("yyyy-MM-dd");

                if (list.CategoryID2 > 0)
                {
                    MojoCube.Web.Sql.ddlFindByValue(ddlCategory, list.CategoryID2.ToString());
                }
                else
                {
                    MojoCube.Web.Sql.ddlFindByValue(ddlCategory, list.CategoryID1.ToString());
                }

                MojoCube.Web.Sql.ddlFindByValue(ddlType, list.TypeID.ToString());

                this.Title = "招聘编辑：" + txtTitle.Text.Trim();
            }
            else
            {
                string parentId = "0";

                if (Request.QueryString["parentId"] != null)
                {
                    parentId = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["parentId"]);
                }

                MojoCube.Web.Sql.ddlFindByValue(ddlCategory, parentId);

                txtEndDate.Text = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");

                txtPageName.Text = MojoCube.Web.String.GetPageName();

                cbIssue.Checked = true;

                this.Title = "招聘编辑";
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtTitle.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写职位名称");
            return;
        }

        MojoCube.Web.Job.List list = new MojoCube.Web.Job.List();

        //修改
        if (ViewState["pk_Job"] != null)
        {
            list.GetData(int.Parse(ViewState["pk_Job"].ToString()));

            MojoCube.Web.Job.Category category = new MojoCube.Web.Job.Category();
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
            list.Department = txtDepartment.Text.Trim();
            list.Position = txtPosition.Text.Trim();
            list.Number = txtNumber.Text.Trim();
            list.Place = txtPlace.Text.Trim();
            list.Education = txtEducation.Text.Trim();
            list.Sex = txtSex.Text.Trim();
            list.Wages = txtWages.Text.Trim();
            list.Experiences = txtExperiences.Text.Trim();
            list.Age = txtAge.Text.Trim();
            list.Issue = cbIssue.Checked;
            list.SEO_Title = txtSEO_Title.Text.Trim();
            list.SEO_Keyword = txtSEO_Keyword.Text.Trim();
            list.SEO_Description = txtSEO_Description.Text.Trim();
            list.EndDate = txtEndDate.Text.Trim();
            list.ModifyDate = DateTime.Now.ToString();
            list.ModifyUserID = int.Parse(Session["UserID"].ToString());
            list.UpdateData(list.pk_Job);
        }
        //新增
        else
        {
            MojoCube.Web.Job.Category category = new MojoCube.Web.Job.Category();
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
            list.Department = txtDepartment.Text.Trim();
            list.Position = txtPosition.Text.Trim();
            list.Number = txtNumber.Text.Trim();
            list.Place = txtPlace.Text.Trim();
            list.Education = txtEducation.Text.Trim();
            list.Sex = txtSex.Text.Trim();
            list.Major = string.Empty;
            list.Wages = txtWages.Text.Trim();
            list.Experiences = txtExperiences.Text.Trim();
            list.Age = txtAge.Text.Trim();
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
            list.ImagePath = string.Empty;
            list.Issue = cbIssue.Checked;
            list.IsComment = false;
            list.IsRecommend = false;
            list.Clicks = 0;
            list.SortID = 0;
            list.TypeID = 0;
            list.StartDate = DateTime.Now.ToString();
            list.EndDate = txtEndDate.Text.Trim();
            list.CreateDate = DateTime.Now.ToString();
            list.CreateUserID = int.Parse(Session["UserID"].ToString());
            list.ModifyDate = DateTime.Now.ToString();
            list.ModifyUserID = 0;
            list.Language = MojoCube.Api.UI.Language.GetLanguage();
            ViewState["pk_Job"] = list.InsertData();
        }

        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
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