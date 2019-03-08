using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Site_LinkEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "Link.aspx?active=" + Request.QueryString["active"];

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Link"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Site.Link link = new MojoCube.Web.Site.Link();
                link.GetData(int.Parse(ViewState["pk_Link"].ToString()));

                txtTitle.Text = link.Title;
                txtSortID.Text = link.SortID.ToString();
                txtUrl.Text = link.Url;
                cbVisible.Checked = link.Visible;

                this.Title = "链接编辑：" + txtTitle.Text.Trim();
            }
            else
            {
                cbVisible.Checked = true;
                this.Title = "链接编辑";
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

        MojoCube.Web.Site.Link link = new MojoCube.Web.Site.Link();

        //修改
        if (ViewState["pk_Link"] != null)
        {
            link.GetData(int.Parse(ViewState["pk_Link"].ToString()));
            link.Title = txtTitle.Text.Trim();
            link.Url = txtUrl.Text.Trim();
            link.Visible = cbVisible.Checked;
            link.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            link.ModifyDate = DateTime.Now.ToString();
            link.ModifyUserID = int.Parse(Session["UserID"].ToString());
            link.UpdateData(link.pk_Link);
        }
        //新增
        else
        {
            link.Title = txtTitle.Text.Trim();
            link.Description = string.Empty;
            link.Url = txtUrl.Text.Trim();
            link.Target = "_blank";
            link.TypeID = 0;
            link.ImagePath = string.Empty;
            link.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            link.Visible = cbVisible.Checked;
            link.CreateDate = DateTime.Now.ToString();
            link.CreateUserID = int.Parse(Session["UserID"].ToString());
            link.ModifyDate = DateTime.Now.ToString();
            link.ModifyUserID = 0;
            link.Language = MojoCube.Api.UI.Language.GetLanguage();
            ViewState["pk_Link"] = link.InsertData();
        }

        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Link.aspx?active=" + Request.QueryString["active"]);
    }
}