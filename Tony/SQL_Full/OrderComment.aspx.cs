using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;

public partial class OrderComment : MojoCube.Api.UI.WebPage
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

            MojoCube.Web.Order.List order = new MojoCube.Web.Order.List();
            order.GetData(int.Parse(ViewState["pk_Order"].ToString()));

            if (order.IsComment || order.fk_Member.ToString() != Session["Member_UserID"].ToString())
            {
                Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage));
            }

            lblOrderNumber.Text = order.OrderNumber;
            lblDescription.Text = order.Description;
            lblAmount.Text = MojoCube.Web.String.GetCurrency(order.Amount);

            GridBind();
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
        parameter.Add(MojoCube.Web.SqlHelper.CreateParameter("@fk_Order", ViewState["pk_Order"].ToString(), SqlDbType.NVarChar));
        dt = MojoCube.Web.SqlHelper.SqlQueryDS("select * from Order_Item where fk_Order=@fk_Order", parameter).Tables[0];

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
            ((Label)e.Row.FindControl("lblImage")).Text = "<a href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("P-" + ((Label)e.Row.FindControl("lblPageName")).Text, strLanguage) + "\"><img src='Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(((Label)e.Row.FindControl("lblImagePath")).Text) + "&w=200&h=200' style='width:120px;' /></a>";
            ((Label)e.Row.FindControl("lblPrice")).Text = decimal.Parse(((Label)e.Row.FindControl("lblPrice")).Text).ToString("N1");
        }
    }

    #endregion

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        MojoCube.Web.Order.List order = new MojoCube.Web.Order.List();
        order.GetData(int.Parse(ViewState["pk_Order"].ToString()));

        order.IsComment = true;
        order.UpdateData(order.pk_Order);

        if (GridView1.Rows.Count > 0)
        {
            MojoCube.Web.Member.List member = new MojoCube.Web.Member.List();
            member.GetData(int.Parse(Session["Member_UserID"].ToString()));

            MojoCube.Web.Comment.List list = new MojoCube.Web.Comment.List();

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((TextBox)GridView1.Rows[i].FindControl("txtComment")).Text.Trim() != "")
                {
                    list.Title = ((Label)GridView1.Rows[i].FindControl("lblTitle")).Text;
                    list.Subtitle = string.Empty;
                    list.Description = ((TextBox)GridView1.Rows[i].FindControl("txtComment")).Text.Trim();
                    list.Feedback = string.Empty;
                    list.Visual = string.Empty;
                    list.Author = member.LastName + member.FirstName;
                    list.Email = member.Email;
                    list.Phone = member.Phone1;
                    list.Address = member.Address;
                    list.Website = string.Empty;
                    list.IPAddress = MojoCube.Web.IP.Get();
                    list.Browser = MojoCube.Web.String.GetBrowserInfo();
                    list.Issue = true;
                    list.IsComment = false;
                    list.IsRecommend = false;
                    list.IsRead = false;
                    list.ReadDate = DateTime.Now.ToString();
                    list.Clicks = 0;
                    list.fk_ID = int.Parse(((Label)GridView1.Rows[i].FindControl("lblfkID")).Text);
                    list.SortID = 0;
                    list.TypeID = 1;
                    list.StatusID = 0;
                    list.Score = int.Parse(((DropDownList)GridView1.Rows[i].FindControl("ddlScore")).SelectedValue);
                    list.ScoreIn = list.Score;
                    list.CreateDate = DateTime.Now.ToString();
                    list.CreateUserID = member.pk_Member;
                    list.ModifyDate = DateTime.Now.ToString();
                    list.ModifyUserID = 0;
                    list.Language = MojoCube.Api.UI.Language.GetLanguage();
                    list.InsertData();
                }
            }
        }

        Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("OrderDetail", MojoCube.Api.UI.Language.GetLanguage()) + "?id=" + MojoCube.Api.Text.Security.EncryptString(ViewState["pk_Order"].ToString()));
    }
}