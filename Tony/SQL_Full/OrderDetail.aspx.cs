using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;

public partial class OrderDetail : MojoCube.Api.UI.WebPage
{
    public string strLanguage;

    protected void Page_Init(object sender, EventArgs e)
    {
        strLanguage = MojoCube.Api.UI.Language.GetLanguage();

        MojoCube.Web.Member.List.ChkLogin();

        #region  动态添加head的标签
        MojoCube.Api.Html.Header header = new MojoCube.Api.Html.Header(this.Page);
        //Meta
        header.AddMeta("title", MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage));
        header.AddMeta("keywords", MojoCube.Web.Site.Cache.GetSiteKeyword(strLanguage));
        header.AddMeta("description", MojoCube.Web.Site.Cache.GetSiteDescription(strLanguage));
        //Link
        header.AddLiteral("<link rel=\"shortcut icon\" href=\"images/favicon.ico\" type=\"image/x-icon\" />");
        //CSS
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/bootstrap.css");
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/glide.css");
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/style.css");
        header.AddCSS("Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/online.css");
        //JS
        header.AddJS("JS/jquery.min.js");
        header.AddJS("JS/bootstrap.js");
        header.AddJS("JS/jquery.glide.js");
        #endregion
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage));
            }

            ViewState["pk_Order"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

            GridBind();
            HistoryInfo.InnerHtml = CreateHistory();
            WUC_MemberMenu.CssFocus = "id=\"\"";
            BannerDiv.InnerHtml = MojoCube.Web.Site.Cache.GetSiteBanner(strLanguage, 1);
            this.Title = MojoCube.Web.String.GetTitle(hlTitle.Text, MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage));
            hlProduct.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Product", strLanguage);
            hlOrder.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage);
        }
    }

    #region  GridView

    private void GridBind()
    {
        DataTable dt = new DataTable();

        ArrayList parameter = new ArrayList();
        parameter.Add(MojoCube.Web.SqlHelper.CreateParameter("@pk_Order", ViewState["pk_Order"].ToString(), SqlDbType.NVarChar));
        dt = MojoCube.Web.SqlHelper.SqlQueryDS("select * from Order_List where pk_Order=@pk_Order and fk_Member=" + Session["Member_UserID"].ToString() + " and IsDeleted=0", parameter).Tables[0];

        GridView1.DataSource = dt;
        GridView1.DataBind();

        if (GridView1.Rows.Count == 0)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((LinkButton)e.Row.FindControl("lnbDelete")).Text = "<img src=\"Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/delete.png\" alt=\"删除\" />";

            ((Label)e.Row.FindControl("lblOrderItem")).Text = CreateOrderItem(((Label)e.Row.FindControl("lblID")).Text);

            ((Label)e.Row.FindControl("lblAmount")).Text = MojoCube.Web.String.GetCurrency(decimal.Parse(((Label)e.Row.FindControl("lblAmount")).Text));

            if (((Label)e.Row.FindControl("lblRemark")).Text != "")
            {
                ((Label)e.Row.FindControl("lblRemark")).Text = "<div><img src=\"Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/remark.png\" style=\"width:20px; margin-top:5px;\" alt=\"备注\" title=\"" + ((Label)e.Row.FindControl("lblRemark")).Text + "\" /></div>";
            }

            ((HyperLink)e.Row.FindControl("hlOrder")).NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("OrderDetail", MojoCube.Api.UI.Language.GetLanguage()) + "?id=" + MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);

            switch (((Label)e.Row.FindControl("lblStatus")).Text)
            {
                case "0":   //新订单
                    {
                        ((HyperLink)e.Row.FindControl("hlPay")).Visible = true;
                        ((HyperLink)e.Row.FindControl("hlPay")).NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Pay", MojoCube.Api.UI.Language.GetLanguage()) + "?id=" + MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);
                        ((LinkButton)e.Row.FindControl("lnbCancel")).Visible = true;
                    }
                    break;
                case "2":   //已发货
                    {
                        ((HyperLink)e.Row.FindControl("hlExpress")).Visible = true;
                        ((LinkButton)e.Row.FindControl("lblComplete")).Visible = true;
                        ((HyperLink)e.Row.FindControl("hlExpress")).NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("OrderDetail", MojoCube.Api.UI.Language.GetLanguage()) + "?id=" + MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);
                    }
                    break;
                case "3":   //交易成功
                    {
                        ((HyperLink)e.Row.FindControl("hlExpress")).Visible = true;
                        ((HyperLink)e.Row.FindControl("hlComment")).Visible = true;
                        ((LinkButton)e.Row.FindControl("lnbDelete")).Visible = true;
                        ((HyperLink)e.Row.FindControl("hlExpress")).NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("OrderDetail", MojoCube.Api.UI.Language.GetLanguage()) + "?id=" + MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);

                        if (!((CheckBox)e.Row.FindControl("cbComment")).Checked)
                        {
                            ((HyperLink)e.Row.FindControl("hlComment")).NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("OrderComment", MojoCube.Api.UI.Language.GetLanguage()) + "?id=" + MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);
                        }
                        else
                        {
                            ((HyperLink)e.Row.FindControl("hlComment")).Text = "已评价";
                        }
                    }
                    break;
                case "4":   //交易关闭
                    {
                        ((LinkButton)e.Row.FindControl("lnbDelete")).Visible = true;
                    }
                    break;
            }

            ((Label)e.Row.FindControl("lblStatus")).Text = MojoCube.Web.Sys.StatusID.GetStatusName("Order_List", ((Label)e.Row.FindControl("lblStatus")).Text, "CHS");
        }
    }

    //创建订单产品
    private string CreateOrderItem(string orderId)
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Order_Item where fk_Order=" + orderId).Tables[0];

        if (dt.Rows.Count > 0)
        {
            string lastTD = string.Empty;

            sb.Append("<table class=\"orderTB3\" style=\"width:100%;\">");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == dt.Rows.Count - 1)
                {
                    lastTD = " style=\"border:0px;\"";
                }
                else
                {
                    lastTD = "";
                }
                sb.Append("<tr>");
                sb.Append("<td" + lastTD + " width=\"150px\">");
                sb.Append("<a href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("P-" + dt.Rows[i]["PageName"].ToString(), strLanguage) + "\"><img src='Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["ImagePath"].ToString()) + "&w=200&h=200' style='width:120px;' /></a>");
                sb.Append("</td>");
                sb.Append("<td" + lastTD + ">");
                sb.Append(dt.Rows[i]["Title"].ToString());
                sb.Append("</td>");
                sb.Append("<td" + lastTD + " width=\"80px\">");
                sb.Append(MojoCube.Web.String.GetCurrency(decimal.Parse(dt.Rows[i]["Price"].ToString())));
                sb.Append("</td>");
                sb.Append("<td" + lastTD + " width=\"80px\">");
                sb.Append(dt.Rows[i]["Qty"].ToString());
                sb.Append("</td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
        }

        return sb.ToString();
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        string[] list = { "lnbCancel", "lblComplete", "lnbDelete" };
        MojoCube.Api.UI.AdminGridView.SetDataRow(e, list);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);

        MojoCube.Web.Order.List order = new MojoCube.Web.Order.List();
        order.GetData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));

        //取消订单
        if (e.CommandName == "_cancel")
        {
            order.StatusID = 4;
            order.CancelDate = DateTime.Now.ToString();
        }

        //确认收货
        if (e.CommandName == "_complete")
        {
            order.StatusID = 3;
            order.EndDate = DateTime.Now.ToString();
        }

        //标记删除
        if (e.CommandName == "_delete")
        {
            order.IsDeleted = true;
        }

        order.UpdateData(order.pk_Order);
        Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Order", MojoCube.Api.UI.Language.GetLanguage()));
    }

    #endregion

    #region  订单记录

    private string CreateHistory()
    {
        MojoCube.Web.Order.List list = new MojoCube.Web.Order.List();
        list.GetData(int.Parse(ViewState["pk_Order"].ToString()));

        if (list.fk_Member.ToString() != Session["Member_UserID"].ToString())
        {
            Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage));
        }

        lblContactName.Text = list.CustomerName;
        lblAddress.Text = list.CustomerAddress;
        lblContactPhone.Text = list.CustomerPhone1;
        lblRemark.Text = list.Remark;

        StringBuilder sb = new StringBuilder();

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
}