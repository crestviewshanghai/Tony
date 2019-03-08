using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Order : MojoCube.Api.UI.WebPage
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
            if (Request.QueryString["status"] != null)
            {
                ViewState["StatusID"] = MojoCube.Web.String.ToInt(Request.QueryString["status"]);
                StatusDiv.InnerHtml = CreateStatus().Replace("<li class=\"current\">", "<li>").Replace("id=\"li" + ViewState["StatusID"].ToString() + "\"", "class=\"current\"");
            }
            else
            {
                StatusDiv.InnerHtml = CreateStatus();
            }
            GridBind();
            WUC_MemberMenu.CssFocus = "id=\"Menu2\"";
            BannerDiv.InnerHtml = MojoCube.Web.Site.Cache.GetSiteBanner(strLanguage, 1);
            hlProduct.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Product", strLanguage);
            hlOrder.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage);
        }
        this.Title = MojoCube.Web.String.GetTitle(hlTitle.Text, MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage));
    }

    #region  查询订单

    private string CreateStatus()
    {
        StringBuilder sb = new StringBuilder();

        string orderUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage);

        sb.Append("<ul>");
        sb.Append("<li class=\"current\"><a href=\"" + orderUrl + "\">全部订单<small>|</small></a></li>");
        sb.Append("<li id=\"li0\"><a href=\"" + orderUrl + "?status=0\">待付款" + GetOrderStatus(0) + "<small>|</small></a></li>");
        sb.Append("<li id=\"li1\"><a href=\"" + orderUrl + "?status=1\">待发货" + GetOrderStatus(1) + "<small>|</small></a></li>");
        sb.Append("<li id=\"li2\"><a href=\"" + orderUrl + "?status=2\">待收货" + GetOrderStatus(2) + "<small>|</small></a></li>");
        sb.Append("<li id=\"li3\"><a href=\"" + orderUrl + "?status=3\">待评价" + GetOrderStatus(3) + "</a></li>");
        sb.Append("</ul>");

        return sb.ToString();
    }

    private string GetOrderStatus(int statusId)
    {
        string text = string.Empty;

        int count = MojoCube.Web.Sql.GetResultCount("Order_List", "fk_Member=" + Session["Member_UserID"].ToString() + " and IsDeleted=0 and IsComment=0 and StatusID=" + statusId);

        if (count > 0)
        {
            text = "（<b class=\"price\">" + count.ToString() + "</b>）";
        }

        return text;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GridBind();
    }

    #endregion

    #region  GridView

    private void GridBind()
    {
        MojoCube.Api.UI.WebPager pager = new MojoCube.Api.UI.WebPager(ListPager);
        pager.Language = strLanguage;
        pager.ConnStr = MojoCube.Web.Connection.ConnString();
        pager.PageSize = MojoCube.Web.String.PageSize("order");
        pager.TableName = "Order_List";
        pager.strGetFields = "*";

        string where = string.Empty;

        if (ViewState["StatusID"] != null)
        {
            where = "fk_Member=" + Session["Member_UserID"].ToString() + " and IsDeleted=0 and IsComment=0 and StatusID=" + ViewState["StatusID"].ToString();
        }
        else
        {
            where = "fk_Member=" + Session["Member_UserID"].ToString() + " and IsDeleted=0";
        }

        if (txtKeyword.Text.Trim() != null)
        {
            where += " and (OrderNumber like '%" + txtKeyword.Text.Trim() + "%' or Description like '%" + txtKeyword.Text.Trim() + "%')";
        }

        pager.where = where;
        pager.fldName = "CreateDate";
        pager.OrderType = true;
        ListPager.NumericButtonCount = MojoCube.Web.String.GetNumericButtonCount();
        ListPager.EnableUrlRewriting = true;

        ListPager.UrlRewritePattern = MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage) + "?status=%status%&page={0}";

        GridView1.DataSource = pager.GetTable();
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
                        ((CheckBox)e.Row.FindControl("cbSelect")).Checked = true;
                        ((CheckBox)e.Row.FindControl("cbSelect")).Enabled = true;
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
                        ((CheckBox)e.Row.FindControl("cbSelect")).Checked = true;
                        ((CheckBox)e.Row.FindControl("cbSelect")).Enabled = true;
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

    //全选
    protected void lnbSelect1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (((Label)GridView1.Rows[i].FindControl("lblStatus")).Text == "交易成功" || ((Label)GridView1.Rows[i].FindControl("lblStatus")).Text == "交易关闭")
            {
                ((CheckBox)GridView1.Rows[i].FindControl("cbSelect")).Checked = true;
            }
        }
    }

    //反选
    protected void lnbSelect2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (((Label)GridView1.Rows[i].FindControl("lblStatus")).Text == "交易成功" || ((Label)GridView1.Rows[i].FindControl("lblStatus")).Text == "交易关闭")
            {
                ((CheckBox)GridView1.Rows[i].FindControl("cbSelect")).Checked = false;
            }
        }
    }

    //删除
    protected void lnbDelete_Click(object sender, EventArgs e)
    {
        MojoCube.Web.Order.List order = new MojoCube.Web.Order.List();

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (((CheckBox)GridView1.Rows[i].FindControl("cbSelect")).Checked)
            {
                order.GetData(int.Parse(((Label)GridView1.Rows[i].FindControl("lblID")).Text));
                order.IsDeleted = true;
                order.UpdateData(order.pk_Order);
            }
        }

        Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Order", MojoCube.Api.UI.Language.GetLanguage()));
    }

    #endregion

    protected void btnBuy_Click(object sender, EventArgs e)
    {
        Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Product", MojoCube.Api.UI.Language.GetLanguage()));
    }
}