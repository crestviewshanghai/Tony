using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : MojoCube.Api.UI.WebPage
{
    public string strLanguage;
    private decimal total = 0;

    protected void Page_Init(object sender, EventArgs e)
    {
        strLanguage = MojoCube.Api.UI.Language.GetLanguage();

        MojoCube.Web.Member.List.ChkLogin(MojoCube.Web.Site.Cache.GetUrlExtension("Cart", strLanguage));

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

        this.Title = MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridBind();
            WUC_MemberMenu.CssFocus = "id=\"\"";
            BannerDiv.InnerHtml = MojoCube.Web.Site.Cache.GetSiteBanner(strLanguage, 1);
            this.Title = MojoCube.Web.String.GetTitle(hlTitle.Text, MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage));
            lblTotal.Text = MojoCube.Web.String.GetCurrency(total);
            hlProduct.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Product", strLanguage);
            hlOrder.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage);
        }
    }

    #region  GridView

    private void GridBind()
    {
        GridView1.DataSource = MojoCube.Web.Sql.SqlQueryDS("select * from View_Member_Cart where fk_Member=" + Session["Member_UserID"].ToString() + " and StatusID=0 order by CreateDate desc").Tables[0];
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
            ((Label)e.Row.FindControl("lblImage")).Text = "<a href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("P-" + ((Label)e.Row.FindControl("lblPageName")).Text, strLanguage) + "\"><img src='Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblImage")).Text) + "&w=200&h=200' style='width:120px;' /></a>";

            ((HyperLink)e.Row.FindControl("hlDelete")).NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("CartAdd", strLanguage) + "?del=" + MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);
            ((HyperLink)e.Row.FindControl("hlDelete")).Text = "<img src=\"Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/delete.png\" alt=\"删除\" />";
            ((LinkButton)e.Row.FindControl("lnbReduction")).Text = "<img src=\"Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/cart_reduction.jpg\" alt=\"-\" class=\"qty\" />";
            ((LinkButton)e.Row.FindControl("lnbPlus")).Text = "<img src=\"Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/cart_plus.jpg\" alt=\"+\" class=\"qty\" />";

            /////////////////////////////  Price
            ((Label)e.Row.FindControl("lblPrice")).Text = decimal.Parse(((Label)e.Row.FindControl("lblPrice")).Text).ToString("N1");
            ((Label)e.Row.FindControl("lblAmount")).Text = (decimal.Parse(((Label)e.Row.FindControl("lblPrice")).Text) * decimal.Parse(((TextBox)e.Row.FindControl("txtQty")).Text)).ToString("N1");
            total += decimal.Parse(((Label)e.Row.FindControl("lblAmount")).Text);
            /////////////////////////////  Price End
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        string[] list = { "lnbReduction", "lnbPlus" };
        MojoCube.Api.UI.AdminGridView.SetDataRow(e, list);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);

        MojoCube.Web.Member.Cart cart = new MojoCube.Web.Member.Cart();
        cart.GetData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));

        //减数量
        if (e.CommandName == "_reduction")
        {
            cart.Qty = cart.Qty - 1;
        }

        //加数量
        if (e.CommandName == "_plus")
        {
            cart.Qty = cart.Qty + 1;
        }

        if (cart.Qty > 0)
        {
            cart.UpdateData(cart.pk_Cart);
            Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Cart", MojoCube.Api.UI.Language.GetLanguage()));
        }
    }

    //全选
    protected void lnbSelect1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            ((CheckBox)GridView1.Rows[i].FindControl("cbSelect")).Checked = true;
        }
    }

    //反选
    protected void lnbSelect2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            ((CheckBox)GridView1.Rows[i].FindControl("cbSelect")).Checked = false;
        }
    }

    //删除
    protected void lnbDelete_Click(object sender, EventArgs e)
    {
        MojoCube.Web.Member.Cart cart = new MojoCube.Web.Member.Cart();

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (((CheckBox)GridView1.Rows[i].FindControl("cbSelect")).Checked)
            {
                cart.DeleteData(int.Parse(((Label)GridView1.Rows[i].FindControl("lblID")).Text));
            }
        }

        Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Cart", MojoCube.Api.UI.Language.GetLanguage()));
    }

    //改数量
    protected void txtQty_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = sender as TextBox;
        int index = (txt.NamingContainer as GridViewRow).RowIndex;

        MojoCube.Web.Member.Cart cart = new MojoCube.Web.Member.Cart();
        cart.GetData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));

        cart.Qty = int.Parse(((TextBox)GridView1.Rows[index].FindControl("txtQty")).Text);

        if (cart.Qty > 0)
        {
            cart.UpdateData(cart.pk_Cart);
            Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Cart", MojoCube.Api.UI.Language.GetLanguage()));
        }
    }

    #endregion

    protected void btnOrder_Click(object sender, EventArgs e)
    {
        string IDs = string.Empty;

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (((CheckBox)GridView1.Rows[i].FindControl("cbSelect")).Checked)
            {
                IDs += ((Label)GridView1.Rows[i].FindControl("lblID")).Text + ",";
            }
        }

        if (IDs.Length > 1)
        {
            IDs = IDs.Substring(0, IDs.Length - 1);
        }

        if (IDs.Length > 0)
        {
            Session["CartToOrder"] = IDs;
            Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("OrderConfirm", MojoCube.Api.UI.Language.GetLanguage()));
        }
    }
}