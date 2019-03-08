using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Comment_Edit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "List.aspx?active=" + Request.QueryString["active"];

            MojoCube.Web.Sql.DropDownListBind(ddlStatus, "Sys_StatusID", "StatusName_CHS", "ID", "TableName='Comment_List'", "ID", "asc");

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Comment"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Comment.List list = new MojoCube.Web.Comment.List();
                list.GetData(int.Parse(ViewState["pk_Comment"].ToString()));

                lblTitle.Text = list.Title;
                lblFrom.Text = "创建：" + list.Author;
                lblDate.Text = list.CreateDate;
                lblDescription.Text = list.Description.Replace("\n", "<br/>");
                txtDescription.Text = list.Feedback;
                MojoCube.Web.Sql.ddlFindByValue(ddlStatus, list.StatusID.ToString());

                if (!list.IsRead)
                {
                    list.IsRead = true;
                    list.ReadDate = DateTime.Now.ToString();
                    list.UpdateData(list.pk_Comment);
                }

                this.Title = "留言编辑：" + lblTitle.Text.Trim();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        MojoCube.Web.Comment.List list = new MojoCube.Web.Comment.List();

        //修改
        if (ViewState["pk_Comment"] != null)
        {
            list.GetData(int.Parse(ViewState["pk_Comment"].ToString()));
            list.Feedback = txtDescription.Text.Trim();
            list.StatusID = int.Parse(ddlStatus.SelectedValue);
            list.ModifyDate = DateTime.Now.ToString();
            list.ModifyUserID = int.Parse(Session["UserID"].ToString());
            list.UpdateData(list.pk_Comment);
        }

        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("List.aspx?active=" + Request.QueryString["active"]);
    }
}