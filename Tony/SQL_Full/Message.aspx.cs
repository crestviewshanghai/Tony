using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Message : MojoCube.Api.UI.WebPage
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
            WUC_MemberMenu.CssFocus = "id=\"Menu4\"";
            GridBind();
            BannerDiv.InnerHtml = MojoCube.Web.Site.Cache.GetSiteBanner(strLanguage, 1);
            this.Title = MojoCube.Web.String.GetTitle(hlTitle.Text, MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage));
        }
    }

    #region  GridView

    private void GridBind()
    {
        MojoCube.Api.UI.WebPager pager = new MojoCube.Api.UI.WebPager(ListPager);
        pager.Language = strLanguage;
        pager.ConnStr = MojoCube.Web.Connection.ConnString();
        pager.PageSize = MojoCube.Web.String.PageSize("message");
        pager.TableName = "Member_Message";
        pager.strGetFields = "*";
        pager.where = "ReceiveUserID=" + Session["Member_UserID"].ToString() + " and IsDeleted=0";
        pager.fldName = "CreateDate";
        pager.OrderType = true;
        ListPager.NumericButtonCount = MojoCube.Web.String.GetNumericButtonCount();
        ListPager.EnableUrlRewriting = true;

        ListPager.UrlRewritePattern = MojoCube.Web.Site.Cache.GetUrlExtension("Message", strLanguage) + "?page={0}";

        GridView1.DataSource = pager.GetTable();
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!((CheckBox)e.Row.FindControl("cbRead")).Checked)
            {
                ((LinkButton)e.Row.FindControl("lnbRead")).Text = "<img src=\"Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/read01.gif\" alt=\"设为已读\" />";
                ((Label)e.Row.FindControl("lblTitle")).Text = "<b style=\"color:#000;\">" + ((Label)e.Row.FindControl("lblTitle")).Text + "</b>";
                ((Label)e.Row.FindControl("lblContents")).Text = "<b style=\"color:#000;\">" + ((Label)e.Row.FindControl("lblContents")).Text + "</b>";
            }
            else
            {
                ((LinkButton)e.Row.FindControl("lnbRead")).Text = "<img src=\"Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/read02.gif\" alt=\"已读\" />";
            }

            ((LinkButton)e.Row.FindControl("lnbDelete")).Text = "<img src=\"Themes/" + MojoCube.Web.Site.Cache.GetSiteTheme(strLanguage) + "/delete.png\" alt=\"删除\" />";
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        string[] list = { "lnbRead", "lnbDelete" };
        MojoCube.Api.UI.AdminGridView.SetDataRow(e, list);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);

        MojoCube.Web.Member.Message message = new MojoCube.Web.Member.Message();
        message.GetData(int.Parse(((Label)GridView1.Rows[index].FindControl("lblID")).Text));

        //设为已读
        if (e.CommandName == "_read")
        {
            message.IsRead = true;
            message.ReceiveDate = DateTime.Now.ToString();
        }

        //标记删除
        if (e.CommandName == "_delete")
        {
            message.IsDeleted = true;
        }

        message.UpdateData(message.pk_Message);
        Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Message", MojoCube.Api.UI.Language.GetLanguage()));
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

    //删除（标记）
    protected void lnbDelete_Click(object sender, EventArgs e)
    {
        MojoCube.Web.Member.Message message = new MojoCube.Web.Member.Message();

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (((CheckBox)GridView1.Rows[i].FindControl("cbSelect")).Checked)
            {
                message.GetData(int.Parse(((Label)GridView1.Rows[i].FindControl("lblID")).Text));
                message.IsDeleted = true;
                message.UpdateData(message.pk_Message);
            }
        }

        Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Message", MojoCube.Api.UI.Language.GetLanguage()));
    }

    //设为已读
    protected void btnRead_Click(object sender, EventArgs e)
    {
        MojoCube.Web.Member.Message message = new MojoCube.Web.Member.Message();

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (((CheckBox)GridView1.Rows[i].FindControl("cbSelect")).Checked)
            {
                message.GetData(int.Parse(((Label)GridView1.Rows[i].FindControl("lblID")).Text));
                message.IsRead = true;
                message.ReceiveDate = DateTime.Now.ToString();
                message.UpdateData(message.pk_Message);
            }
        }

        Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Message", MojoCube.Api.UI.Language.GetLanguage()));
    }

    #endregion
}