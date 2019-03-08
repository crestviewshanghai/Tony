using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Payment_Edit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "List.aspx?active=" + Request.QueryString["active"];

            MojoCube.Web.Sql.DropDownListBind(ddlType, "Sys_TypeID", "TypeName_CHS", "ID", "TableName='Payment_List'", "ID", "asc");

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Payment"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Payment.List list = new MojoCube.Web.Payment.List();
                list.GetData(int.Parse(ViewState["pk_Payment"].ToString()));

                txtTitle.Text = list.Title;
                txtSubtitle.Text = list.Subtitle;
                txtGateway.Text = list.Gateway;
                txtService.Text = list.Service;
                txtAccount.Text = list.Account;
                txtAppID.Text = list.AppID;
                txtSecret.Text = list.Secret;
                txtPartnerID.Text = list.PartnerID;
                txtKeyCode.Text = list.KeyCode;
                txtSignType.Text = list.SignType;
                txtInputCharset.Text = list.InputCharset;
                txtCurrency.Text = list.Currency;
                txtRate.Text = list.Rate.ToString();
                txtSortID.Text = list.SortID.ToString();
                cbVisible.Checked = list.Visible;

                MojoCube.Web.Sql.ddlFindByValue(ddlType, list.TypeID.ToString());

                if (list.ImagePath != "")
                {
                    SetImage(list.ImagePath);
                }

                this.Title = "支付编辑：" + txtTitle.Text.Trim();
            }
            else
            {
                this.Title = "支付编辑";
            }
        }
    }

    private void SetImage(string imgPath)
    {
        lnbRemoveImage.Visible = true;
        imgMain.Attributes.Add("style", "display:block");
        imgMain.ImageUrl = "~/Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(imgPath) + "&w=150&h=150";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtTitle.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写标题");
            return;
        }

        MojoCube.Api.File.Upload upload = new MojoCube.Api.File.Upload();
        upload.FilePath = "Payment";
        upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
        upload.DoFileUpload(fuImage);

        MojoCube.Web.Payment.List list = new MojoCube.Web.Payment.List();

        //修改
        if (ViewState["pk_Payment"] != null)
        {
            list.GetData(int.Parse(ViewState["pk_Payment"].ToString()));
            list.Title = txtTitle.Text.Trim();
            list.Subtitle = txtSubtitle.Text.Trim();
            list.TypeID = int.Parse(ddlType.SelectedValue);
            list.Gateway = txtGateway.Text.Trim();
            list.Service = txtService.Text.Trim();
            list.Account = txtAccount.Text.Trim();
            list.AppID = txtAppID.Text.Trim();
            list.Secret = txtSecret.Text.Trim();
            list.PartnerID = txtPartnerID.Text.Trim();
            list.KeyCode = txtKeyCode.Text.Trim();
            list.SignType = txtSignType.Text.Trim();
            list.InputCharset = txtInputCharset.Text.Trim();
            list.Currency = txtCurrency.Text.Trim();
            list.Rate = MojoCube.Web.String.ToDecimal(txtRate.Text.Trim());
            list.Visible = cbVisible.Checked;
            list.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            if (upload.IsUpload)
            {
                list.ImagePath = upload.OldFilePath;
                SetImage(list.ImagePath);
            }
            list.ModifyDate = DateTime.Now.ToString();
            list.ModifyUserID = int.Parse(Session["UserID"].ToString());
            list.UpdateData(list.pk_Payment);
        }
        //新增
        else
        {
            list.Title = txtTitle.Text.Trim();
            list.Subtitle = txtSubtitle.Text.Trim();
            list.TypeID = int.Parse(ddlType.SelectedValue);
            list.Gateway = txtGateway.Text.Trim();
            list.Service = txtService.Text.Trim();
            list.Account = txtAccount.Text.Trim();
            list.AppID = txtAppID.Text.Trim();
            list.Secret = txtSecret.Text.Trim();
            list.PartnerID = txtPartnerID.Text.Trim();
            list.KeyCode = txtKeyCode.Text.Trim();
            list.SignType = txtSignType.Text.Trim();
            list.InputCharset = txtInputCharset.Text.Trim();
            list.Description = string.Empty;
            list.Currency = txtCurrency.Text.Trim();
            list.Rate = MojoCube.Web.String.ToDecimal(txtRate.Text.Trim());
            list.Visible = cbVisible.Checked;
            list.SortID = MojoCube.Web.String.ToInt(txtSortID.Text.Trim());
            if (upload.IsUpload)
            {
                list.ImagePath = upload.OldFilePath;
                SetImage(list.ImagePath);
            }
            else
            {
                list.ImagePath = string.Empty;
            }
            list.CreateDate = DateTime.Now.ToString();
            list.CreateUserID = int.Parse(Session["UserID"].ToString());
            list.ModifyDate = DateTime.Now.ToString();
            list.ModifyUserID = 0;
            ViewState["pk_Payment"] = list.InsertData();
        }

        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
    }

    protected void lnbRemoveImage_Click(object sender, EventArgs e)
    {
        MojoCube.Web.Payment.List list = new MojoCube.Web.Payment.List();
        list.GetData(int.Parse(ViewState["pk_Payment"].ToString()));
        list.ImagePath = string.Empty;
        list.UpdateData(list.pk_Payment);
        imgMain.Attributes.Add("style", "display:none");
        lnbRemoveImage.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("List.aspx?active=" + Request.QueryString["active"]);
    }
}