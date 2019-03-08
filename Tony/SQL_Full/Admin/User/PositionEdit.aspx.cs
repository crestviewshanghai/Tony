using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_User_PositionEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "Position.aspx?active=" + Request.QueryString["active"];

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Position"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.User.Position position = new MojoCube.Web.User.Position();
                position.GetData(int.Parse(ViewState["pk_Position"].ToString()));

                txtName.Text = position.Title;
                txtLevelID.Text = position.LevelID.ToString();

                this.Title = "职位编辑：" + txtName.Text.Trim();
            }
            else
            {
                this.Title = "职位编辑";
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

        MojoCube.Web.User.Position position = new MojoCube.Web.User.Position();

        //修改
        if (ViewState["pk_Position"] != null)
        {
            position.GetData(int.Parse(ViewState["pk_Position"].ToString()));

            position.Title = txtName.Text.Trim();
            position.LevelID = MojoCube.Web.String.ToInt(txtLevelID.Text.Trim());
            position.ModifyUser = int.Parse(Session["UserID"].ToString());
            position.ModifyDate = DateTime.Now.ToString();
            position.UpdateData(position.pk_Position);
        }
        //新增
        else
        {
            position.Title = txtName.Text.Trim();
            position.ParentID = 0;
            position.LevelID = MojoCube.Web.String.ToInt(txtLevelID.Text.Trim());
            position.SortID = 0;
            position.fk_Company = 0;
            position.CreateUser = int.Parse(Session["UserID"].ToString());
            position.CreateDate = DateTime.Now.ToString();
            position.ModifyUser = 0;
            position.ModifyDate = DateTime.Now.ToString();
            position.InsertData();
        }

        Response.Redirect("Position.aspx?active=" + Request.QueryString["active"]);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Position.aspx?active=" + Request.QueryString["active"]);
    }
}