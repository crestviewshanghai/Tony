using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_User_DepartmentEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "Department.aspx?active=" + Request.QueryString["active"];

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Department"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.User.Department department = new MojoCube.Web.User.Department();
                department.GetData(int.Parse(ViewState["pk_Department"].ToString()));

                txtName.Text = department.DepartmentName;
                txtPhone1.Text = department.Phone1;
                txtFax.Text = department.Fax;
                txtEmail.Text = department.Email;
                txtAddress.Text = department.Address;
                txtSortID.Text = department.SortID.ToString();
                txtWorkTime.Text = department.Monday;

                this.Title = "部门编辑：" + txtName.Text.Trim();
            }
            else
            {
                this.Title = "部门编辑";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写名称");
            return;
        }

        MojoCube.Web.User.Department department = new MojoCube.Web.User.Department();

        //修改
        if (ViewState["pk_Department"] != null)
        {
            department.GetData(int.Parse(ViewState["pk_Department"].ToString()));

            department.DepartmentName = txtName.Text.Trim();
            department.Phone1 = txtPhone1.Text.Trim();
            department.Fax = txtFax.Text.Trim();
            department.Email = txtEmail.Text.Trim();
            department.Address = txtAddress.Text.Trim();
            department.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            department.ModifyUser = int.Parse(Session["UserID"].ToString());
            department.ModifyDate = DateTime.Now.ToString();
            department.Monday = txtWorkTime.Text.Trim();
            department.Tuesday = txtWorkTime.Text.Trim();
            department.Wednesday = txtWorkTime.Text.Trim();
            department.Thursday = txtWorkTime.Text.Trim();
            department.Friday = txtWorkTime.Text.Trim();
            department.UpdateData(department.pk_Department);
        }
        //新增
        else
        {
            department.DepartmentName = txtName.Text.Trim();
            department.Phone1 = txtPhone1.Text.Trim();
            department.Phone2 = string.Empty;
            department.Fax = txtFax.Text.Trim();
            department.Email = txtEmail.Text.Trim();
            department.Address = txtAddress.Text.Trim();
            if (Request.QueryString["parentId"] != null)
            {
                department.ParentID = int.Parse(MojoCube.Api.Text.Security.DecryptString(Request.QueryString["parentId"]));
                department.LevelID = 1;
            }
            else
            {
                department.ParentID = 0;
                department.LevelID = 0;
            }
            department.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            department.TypeID = 0;
            department.Province = 0;
            department.City = 0;
            department.County = 0;
            department.Zone = 0;
            department.Manager = 0;
            department.fk_Company = 0;
            department.CreateUser = int.Parse(Session["UserID"].ToString());
            department.CreateDate = DateTime.Now.ToString();
            department.ModifyUser = 0;
            department.ModifyDate = DateTime.Now.ToString();
            department.Monday = txtWorkTime.Text.Trim();
            department.Tuesday = txtWorkTime.Text.Trim();
            department.Wednesday = txtWorkTime.Text.Trim();
            department.Thursday = txtWorkTime.Text.Trim();
            department.Friday = txtWorkTime.Text.Trim();
            department.Saturday = string.Empty;
            department.Sunday = string.Empty;
            department.InsertData();
        }

        Response.Redirect("Department.aspx?active=" + Request.QueryString["active"]);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Department.aspx?active=" + Request.QueryString["active"]);
    }
}