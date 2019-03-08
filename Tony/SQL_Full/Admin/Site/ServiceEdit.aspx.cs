using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Site_ServiceEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "Service.aspx?active=" + Request.QueryString["active"];

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Service"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Site.Service service = new MojoCube.Web.Site.Service();
                service.GetData(int.Parse(ViewState["pk_Service"].ToString()));

                txtTitle.Text = service.Title;
                txtDescription.Text = service.Description;
                txtSortID.Text = service.SortID.ToString();
                cbVisible.Checked = service.Visible;

                this.Title = "客服编辑：" + txtTitle.Text.Trim();
            }
            else
            {
                cbVisible.Checked = true;
                this.Title = "客服编辑";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtTitle.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写标题");
            return;
        }

        MojoCube.Web.Site.Service service = new MojoCube.Web.Site.Service();

        //修改
        if (ViewState["pk_Service"] != null)
        {
            service.GetData(int.Parse(ViewState["pk_Service"].ToString()));
            service.Title = txtTitle.Text.Trim();
            service.Description = txtDescription.Text.Trim();
            service.Visible = cbVisible.Checked;
            service.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            service.ModifyDate = DateTime.Now.ToString();
            service.ModifyUserID = int.Parse(Session["UserID"].ToString());
            service.UpdateData(service.pk_Service);
        }
        //新增
        else
        {
            service.Title = txtTitle.Text.Trim();
            service.Description = txtDescription.Text.Trim();
            service.Visible = cbVisible.Checked;
            service.StartTime = DateTime.Now.ToString();
            service.EndTime = DateTime.Now.ToString();
            service.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            service.CreateDate = DateTime.Now.ToString();
            service.CreateUserID = int.Parse(Session["UserID"].ToString());
            service.ModifyDate = DateTime.Now.ToString();
            service.ModifyUserID = 0;
            service.Language = MojoCube.Api.UI.Language.GetLanguage();
            ViewState["pk_Service"] = service.InsertData();
        }

        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Service.aspx?active=" + Request.QueryString["active"]);
    }
}