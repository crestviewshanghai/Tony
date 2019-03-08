using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_User_Profile : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridBind();

            //用户信息
            MojoCube.Web.User.List list = new MojoCube.Web.User.List();
            list.GetData(int.Parse(Session["UserID"].ToString()));

            lblFullName.Text = list.FullName;

            txtName.Text = list.UserName;
            txtPhone1.Text = list.Phone1;
            txtNickName.Text = list.NickName;
            txtFullName.Text = list.FullName;
            txtEmail1.Text = list.Email1;
            txtAddress1.Text = list.Address1;
            txtEducation.Text = list.Education;
            txtSchool.Text = list.School;
            txtBankAccount.Text = list.BankAccount;
            txtIDNumber.Text = list.IDNumber;
            txtBirthday.Text = DateTime.Parse(list.Birthday).ToString("yyyy-MM-dd");
            txtNote.Text = list.Note;
            MojoCube.Web.Sql.ddlFindByValue(ddlSkin, list.Skin);
            MojoCube.Web.Sql.ddlFindByValue(ddlSex, list.Sex.ToString());

            if (list.ImagePath1 != "")
            {
                imgPortrait.ImageUrl = "~/Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(list.ImagePath1) + "&cut=200,200";
            }
            else
            {
                imgPortrait.ImageUrl = "~/Images/user.png";
            }

            //职位
            MojoCube.Web.User.Position position = new MojoCube.Web.User.Position();
            position.GetData(list.Position);
            lblPosition.Text = position.Title;

            //部门
            MojoCube.Web.User.Department department = new MojoCube.Web.User.Department();
            department.GetData(list.fk_Department);
            lblDepartment.Text = department.DepartmentName;

            lblEducation.Text = list.School + " " + list.Education;
            lblPhone.Text = list.Phone1;
            lblAddress.Text = list.Address1;
            lblNote.Text = list.Note;

            this.Title = "用户面板";
        }
    }

    #region  我的便签

    protected void ListPager_PageChanged(object sender, EventArgs e)
    {
        GridBind();
    }

    private void GridBind()
    {
        EmptyDiv.Visible = false;

        MojoCube.Api.UI.AdminPager pager = new MojoCube.Api.UI.AdminPager(ListPager);
        pager.PageSize = 5;
        pager.ConnStr = MojoCube.Web.Connection.ConnString();
        pager.TableName = "Memo_List";
        pager.strGetFields = "*";

        string where = "fk_User=" + Session["UserID"].ToString();

        pager.where = where;
        pager.fldName = "IsStar desc,ModifyDate";
        pager.OrderType = true;

        GridView1.DataSource = pager.GetTable();
        GridView1.DataBind();

        if (GridView1.Rows.Count == 0)
        {
            EmptyDiv.Visible = true;
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //是否星标
            if (((CheckBox)e.Row.FindControl("cbStar")).Checked)
            {
                ((LinkButton)e.Row.FindControl("gvStar")).Text = "<i class=\"fa fa-star text-yellow\"></i>";
            }

            ((HyperLink)e.Row.FindControl("gvEdit")).Attributes.Add("onclick", "editMemo('" + ((Label)e.Row.FindControl("lblID")).Text + "','" + ((Label)e.Row.FindControl("lblMemoTitle")).Text + "','" + ((Label)e.Row.FindControl("lblMemoDescription")).Text + "')");

            MojoCube.Web.String.ShowDel(e);
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        string[] list = { "gvStar", "gvDelete" };
        MojoCube.Api.UI.AdminGridView.SetDataRow(e, list);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        MojoCube.Web.Memo.List list = new MojoCube.Web.Memo.List();
        int index = Convert.ToInt32(e.CommandArgument);
        //标星
        if (e.CommandName == "_star")
        {
            list.GetData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));
            if (list.IsStar)
            {
                list.IsStar = false;
            }
            else
            {
                list.IsStar = true;
            }
            list.UpdateData(list.pk_Memo);
        }
        //删除
        if (e.CommandName == "_delete")
        {
            list.DeleteData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));
        }
        GridBind();
    }

    protected void lnbSaveMemo_Click(object sender, EventArgs e)
    {
        if (txtMemoContent.Text.Trim() != "")
        {
            MojoCube.Web.Memo.List list = new MojoCube.Web.Memo.List();

            //修改
            if (txtMemoID.Text.Trim() != "")
            {
                list.GetData(int.Parse(txtMemoID.Text.Trim()));

                if (list.fk_User == int.Parse(Session["UserID"].ToString()))
                {
                    list.Title = txtMemoTitle.Text.Trim();
                    list.Description = txtMemoContent.Text.Trim();
                    list.ModifyUser = int.Parse(Session["UserID"].ToString());
                    list.ModifyDate = DateTime.Now.ToString();
                    list.UpdateData(list.pk_Memo);
                }
            }
            //新增
            else
            {
                list.fk_User = int.Parse(Session["UserID"].ToString());
                list.fk_Department = int.Parse(Session["DepartmentID"].ToString());
                list.TypeID = 0;
                list.StatusID = 0;
                list.Title = txtMemoTitle.Text.Trim();
                list.Description = txtMemoContent.Text.Trim();
                list.ImagePath = string.Empty;
                list.FilePath = string.Empty;
                list.UserList = string.Empty;
                list.DepartmentList = string.Empty;
                list.RoleList = string.Empty;
                list.Url = string.Empty;
                list.IsStar = false;
                list.Tags = string.Empty;
                list.fk_Company = 0;
                list.CreateUser = int.Parse(Session["UserID"].ToString());
                list.CreateDate = DateTime.Now.ToString();
                list.ModifyUser = 0;
                list.ModifyDate = DateTime.Now.ToString();
                list.InsertData();
            }

            Response.Redirect("Profile.aspx");
        }
    }

    #endregion

    #region  个人设置

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtFullName.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写真实姓名");
            return;
        }

        MojoCube.Web.User.List list = new MojoCube.Web.User.List();

        //修改
        if (Session["UserID"] != null)
        {
            MojoCube.Api.File.Upload upload = new MojoCube.Api.File.Upload();
            upload.FilePath = "User/" + Session["UserID"].ToString();
            upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
            upload.DoFileUpload(fuPortrait);

            list.GetData(int.Parse(Session["UserID"].ToString()));

            if (txtPassword1.Text.Trim() != "")
            {
                if (txtPassword1.Text.Trim().Length < 6)
                {
                    AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请输入至少6位密码");
                    return;
                }

                if (txtPassword1.Text.Trim() != txtPassword2.Text.Trim())
                {
                    AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "两次输入密码不一致");
                    return;
                }

                list.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword1.Text.Trim(), "MD5").ToLower();
            }

            list.UserName = txtName.Text.Trim();
            list.NickName = txtNickName.Text.Trim();
            list.FullName = txtFullName.Text.Trim();
            list.FirstName = MojoCube.Web.String.GetChineseName(txtFullName.Text.Trim(), false);
            list.LastName = MojoCube.Web.String.GetChineseName(txtFullName.Text.Trim(), true);
            list.Phone1 = txtPhone1.Text.Trim();
            list.Email1 = txtEmail1.Text.Trim();
            list.Address1 = txtAddress1.Text.Trim();
            list.Education = txtEducation.Text.Trim();
            list.School = txtSchool.Text.Trim();
            list.BankAccount = txtBankAccount.Text.Trim();
            list.IDNumber = txtIDNumber.Text.Trim();
            list.Skin = ddlSkin.SelectedValue;
            list.Sex = int.Parse(ddlSex.SelectedValue);
            list.Birthday = txtBirthday.Text.Trim();
            list.Note = txtNote.Text.Trim();

            if (upload.IsUpload)
            {
                list.ImagePath1 = upload.OldFilePath;
            }

            list.ModifyUser = int.Parse(Session["UserID"].ToString());
            list.ModifyDate = DateTime.Now.ToString();
            list.UpdateData(list.pk_User);

            Response.Redirect("Profile.aspx");
        }
    }

    #endregion
}