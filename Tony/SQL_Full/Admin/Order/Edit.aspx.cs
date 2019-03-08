using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Text;

public partial class Admin_Order_Edit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "List.aspx?active=" + Request.QueryString["active"];

            MojoCube.Web.Sql.DropDownListBind(ddlStatus, "Sys_StatusID", "StatusName_CHS", "ID", "TableName='Order_List'", "ID", "asc");

            MojoCube.Web.Sql.DropDownListBind(ddlExpress, "Sys_Express", "FullName", "ShortName", "Visible=1", "FullName", "asc", new ListItem("--请选择物流公司--", ""));

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Order"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Order.List list = new MojoCube.Web.Order.List();
                list.GetData(int.Parse(ViewState["pk_Order"].ToString()));

                lblTitle.Text = "订单编号：" + list.OrderNumber;
                lblDate.Text = "下单日期：" + list.CreateDate;
                lblDescription.Text = CreateOrderInfo(list);

                txtAmount.Text = list.Amount.ToString("N2");
                txtLogisticCode.Text = list.LogisticCode;
                txtNumber.Text = list.OrderNumber;
                txtNote.Text = list.Note;

                MojoCube.Web.Sql.ddlFindByValue(ddlStatus, list.StatusID.ToString());
                MojoCube.Web.Sql.ddlFindByValue(ddlExpress, list.ShipperCode.ToString());

                lblHistory.Text = CreateHistory(list);

                if (list.Comments != "")
                {
                    lblComments.Text += "<hr/>" + list.Comments.Replace("\n", "<br/>");
                }

                this.Title = "订单编辑：" + lblTitle.Text;

                if (list.IsComment)
                {
                    lblTitle.Text += "（已评价）";
                }
            }
            else
            {
                this.Title = "订单编辑";
            }
        }
    }

    #region  订单信息

    private string CreateOrderInfo(MojoCube.Web.Order.List list)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("<div>");
        sb.Append("<div style=\"padding:10px; background:#3C8DBC; color:#fff; font-family:'Microsoft YaHei'\">");
        sb.Append("订单信息");
        sb.Append("</div>");
        sb.Append("<table style=\"width:100%\">");
        sb.Append("<tr>");
        sb.Append("<td style=\"width:100px; padding:5px; background:#fff;\">");
        sb.Append("<b>订单描述：</b>");
        sb.Append("</td>");
        sb.Append("<td style=\"padding:5px; background:#fff;\">");
        sb.Append(list.Description);
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td style=\"width:100px; padding:5px; background:#eee;\">");
        sb.Append("<b>订单金额：</b>");
        sb.Append("</td>");
        sb.Append("<td style=\"padding:5px; background:#eee;\">");
        sb.Append(MojoCube.Web.String.GetCurrency(list.Amount));
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td style=\"width:100px; padding:5px; background:#fff;\">");
        sb.Append("<b>联系人：</b>");
        sb.Append("</td>");
        sb.Append("<td style=\"padding:5px; background:#fff;\">");
        sb.Append(list.CustomerName);
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td style=\"width:100px; padding:5px; background:#eee;\">");
        sb.Append("<b>联系电话：</b>");
        sb.Append("</td>");
        sb.Append("<td style=\"padding:5px; background:#eee;\">");
        sb.Append(list.CustomerPhone1);
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td style=\"width:100px; padding:5px; background:#fff;\">");
        sb.Append("<b>联系地址：</b>");
        sb.Append("</td>");
        sb.Append("<td style=\"padding:5px; background:#fff;\">");
        sb.Append(list.CustomerAddress);
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td style=\"width:100px; padding:5px; background:#eee;\">");
        sb.Append("<b>订单备注：</b>");
        sb.Append("</td>");
        sb.Append("<td style=\"padding:5px; background:#eee;\">");
        sb.Append(list.Remark);
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("</table>");
        sb.Append("</div>");

        sb.Append(CreateOrderItem(list.pk_Order.ToString()));

        return sb.ToString();
    }

    //创建订单产品
    private string CreateOrderItem(string orderId)
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Order_Item where fk_Order=" + orderId).Tables[0];

        if (dt.Rows.Count > 0)
        {
            string tdCss = string.Empty;

            sb.Append("<table class=\"orderTB3\" style=\"width:100%;\">");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tdCss = " style=\"border:solid 1px #eee; text-align:center\"";

                sb.Append("<tr>");
                sb.Append("<td" + tdCss + " width=\"150px;\">");
                sb.Append("<a href=\"../../" + MojoCube.Web.Site.Cache.GetUrlExtension("P-" + dt.Rows[i]["PageName"].ToString(), "zh-cn") + "\" target=\"_blank\"><img src='../../Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["ImagePath"].ToString()) + "&w=200&h=200' style='width:80px;' /></a>");
                sb.Append("</td>");
                sb.Append("<td" + tdCss + ">");
                sb.Append(dt.Rows[i]["Title"].ToString());
                sb.Append("</td>");
                sb.Append("<td" + tdCss + " width=\"100px\">");
                sb.Append(MojoCube.Web.String.GetCurrency(decimal.Parse(dt.Rows[i]["Price"].ToString())));
                sb.Append("</td>");
                sb.Append("<td" + tdCss + " width=\"100px\">");
                sb.Append(dt.Rows[i]["Qty"].ToString());
                sb.Append("</td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
        }

        return sb.ToString();
    }

    #endregion

    #region  历史纪录

    private string CreateHistory(MojoCube.Web.Order.List list)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("<br/>");
        sb.Append("<span style=\"font-size:8pt; color:#999; margin-left:3px;\">[" + DateTime.Parse(list.CreateDate).ToString("yyyy-MM-dd HH:mm") + "]</span> 创建订单，订单编号【" + list.OrderNumber + "】<br/>");

        if (list.fk_Payment > 0)
        {
            MojoCube.Web.Payment.List payment = new MojoCube.Web.Payment.List();
            payment.GetData(list.fk_Payment);
            sb.Append("<span style=\"font-size:8pt; color:#999; margin-left:3px;\">[" + DateTime.Parse(list.PaymentDate).ToString("yyyy-MM-dd HH:mm") + "]</span> 付款成功，【" + payment.Title + "】<br/>");
        }

        if (list.ShipperCode != "")
        {
            MojoCube.Web.Sys.Express express = new MojoCube.Web.Sys.Express();
            express.GetData(list.ShipperCode);
            sb.Append("<span style=\"font-size:8pt; color:#999; margin-left:3px;\">[" + DateTime.Parse(list.ShipmentDate).ToString("yyyy-MM-dd HH:mm") + "]</span> 已发货，" + express.FullName + "，运单号【" + list.LogisticCode + "】<br/>");

            DataTable dt = new DataTable();
            if (Session["LogisticCode_" + list.LogisticCode] != null)
            {
                dt = (DataTable)Session["LogisticCode_" + list.LogisticCode];
            }
            else
            {
                dt = MojoCube.Web.Express.Function.GetLogisticDT(list.ShipperCode, list.LogisticCode);
                Session["LogisticCode_" + list.LogisticCode] = dt;
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<span style=\"font-size:8pt; color:#999; margin-left:3px;\">[" + DateTime.Parse(dt.Rows[i]["Time"].ToString()).ToString("yyyy-MM-dd HH:mm") + "]</span> " + dt.Rows[i]["Content"].ToString() + "<br/>");
                }
            }
        }

        if (list.StatusID == 3)
        {
            sb.Append("<span style=\"font-size:8pt; color:#999; margin-left:3px;\">[" + DateTime.Parse(list.EndDate).ToString("yyyy-MM-dd HH:mm") + "]</span> 交易成功<br/>");
        }

        if (list.StatusID == 4)
        {
            sb.Append("<span style=\"font-size:8pt; color:#999; margin-left:3px;\">[" + DateTime.Parse(list.CancelDate).ToString("yyyy-MM-dd HH:mm") + "]</span> 交易关闭<br/>");
        }

        return sb.ToString();
    }

    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtAmount.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写金额");
            return;
        }

        MojoCube.Web.Order.List list = new MojoCube.Web.Order.List();

        //修改
        if (ViewState["pk_Order"] != null)
        {
            list.GetData(int.Parse(ViewState["pk_Order"].ToString()));

            if (list.StatusID != int.Parse(ddlStatus.SelectedValue))
            {
                string dateString = "<span style=\"font-size:8pt; color:#999; margin-left:3px;\">[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "]</span>";
                list.StatusID = int.Parse(ddlStatus.SelectedValue);
                list.Comments += Session["FullName"].ToString() + dateString + "：将状态改为【" + ddlStatus.SelectedItem.Text + "】\n";
            }
            if (list.ShipperCode != ddlExpress.SelectedValue)
            {
                list.ShipperCode = ddlExpress.SelectedValue;
                list.ShipmentDate = DateTime.Now.ToString();
                list.LogisticCode = txtLogisticCode.Text.Trim();
            }
            if (list.StatusID == 3)
            {
                list.EndDate = DateTime.Now.ToString();
            }
            if (list.StatusID == 4)
            {
                list.CancelDate = DateTime.Now.ToString();
            }
            list.Amount = MojoCube.Web.String.ToDecimal(txtAmount.Text.Trim());
            list.OrderNumber = txtNumber.Text.Trim();
            list.Note = txtNote.Text.Trim();
            list.UpdateData(list.pk_Order);
        }

        AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("List.aspx?active=" + Request.QueryString["active"]);
    }
}