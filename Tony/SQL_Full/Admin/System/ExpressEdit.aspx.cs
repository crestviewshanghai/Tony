using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_System_ExpressEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "Express.aspx?active=" + Request.QueryString["active"];

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Express"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Sys.Express express = new MojoCube.Web.Sys.Express();
                express.GetData(int.Parse(ViewState["pk_Express"].ToString()));

                txtFullName.Text = express.FullName;
                txtShortName.Text = express.ShortName;
                txtWebsite.Text = express.Website;
                txtFreight.Text = express.Freight.ToString("N2");
                cbVisible.Checked = express.Visible;

                this.Title = "公司编辑：" + txtFullName.Text.Trim();
            }
            else
            {
                cbVisible.Checked = true;
                this.Title = "公司编辑";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtFullName.Text.Trim() == "" || txtShortName.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写公司名称和简称");
            return;
        }

        MojoCube.Web.Sys.Express express = new MojoCube.Web.Sys.Express();

        //修改
        if (ViewState["pk_Express"] != null)
        {
            express.GetData(int.Parse(ViewState["pk_Express"].ToString()));
            express.FullName = txtFullName.Text.Trim();
            express.ShortName = txtShortName.Text.Trim();
            express.Website = txtWebsite.Text.Trim();
            express.Freight = MojoCube.Web.String.ToDecimal(txtFreight.Text.Trim());
            express.Visible = cbVisible.Checked;
            express.UpdateData(express.pk_Express);
        }
        //新增
        else
        {
            express.FullName = txtFullName.Text.Trim();
            express.ShortName = txtShortName.Text.Trim();
            express.ImagePath = string.Empty;
            express.Website = txtWebsite.Text.Trim();
            express.Url = string.Empty;
            express.Freight = MojoCube.Web.String.ToDecimal(txtFreight.Text.Trim());
            express.Visible = cbVisible.Checked;
            express.InsertData();
        }

        Response.Redirect("Express.aspx?active=" + Request.QueryString["active"]);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Express.aspx?active=" + Request.QueryString["active"]);
    }
}