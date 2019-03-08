using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderConfirm : MojoCube.Api.UI.WebPage
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
            MojoCube.Web.Member.List member = new MojoCube.Web.Member.List();
            member.GetData(int.Parse(Session["Member_UserID"].ToString()));

            txtContactName.Text = member.LastName + member.FirstName;
            txtAddress.Text = member.Address;
            txtContactPhone.Text = member.Phone1;
            ViewState["Email"] = member.Email;

            GridBind();
            WUC_MemberMenu.CssFocus = "id=\"\"";
            BannerDiv.InnerHtml = MojoCube.Web.Site.Cache.GetSiteBanner(strLanguage, 1);
            this.Title = MojoCube.Web.String.GetTitle(hlTitle.Text, MojoCube.Web.Site.Cache.GetSiteTitle(strLanguage));
            lblTotal.Text = MojoCube.Web.String.GetCurrency(total);
            ViewState["Total"] = total;
            hlProduct.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Product", strLanguage);
            hlOrder.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage);
        }
    }

    #region  GridView

    private void GridBind()
    {
        if (Session["CartToOrder"] != null)
        {
            GridView1.DataSource = MojoCube.Web.Sql.SqlQueryDS("select * from View_Member_Cart where fk_Member=" + Session["Member_UserID"].ToString() + " and StatusID=0 and pk_Cart in (" + Session["CartToOrder"].ToString() + ") order by CreateDate desc").Tables[0];
            GridView1.DataBind();
        }
        else
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
            Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("OrderConfirm", MojoCube.Api.UI.Language.GetLanguage()));
        }
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
            Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("OrderConfirm", MojoCube.Api.UI.Language.GetLanguage()));
        }
    }

    #endregion

    protected void btnOrder_Click(object sender, EventArgs e)
    {
        if (txtContactName.Text == "" || txtAddress.Text == "" || txtContactPhone.Text == "")
        {
            MojoCube.Api.UI.Script.ScriptMessage(this, "请填写完整收货信息");
            return;
        }

        #region  获取邮件信息

        //获取发送邮件账号
        MojoCube.Web.Mail.Account account = new MojoCube.Web.Mail.Account();
        account.GetDataTypeID(2);
        //获取邮件模板
        MojoCube.Web.Mail.Template template = new MojoCube.Web.Mail.Template();
        template.GetDataAccountID(account.pk_Account);
        string mailbody = template.Description;
        string templateInfo = string.Empty;
        //获取替代方法
        MojoCube.Web.ReplaceText replace = new MojoCube.Web.ReplaceText();
        string repeatText = replace.GetRepeat("<tr class=\"repeat\">", "</tr>", template.Description);

        #endregion

        #region  加入订单列表

        MojoCube.Web.Order.List list = new MojoCube.Web.Order.List();
        list.fk_Member = int.Parse(Session["Member_UserID"].ToString());
        list.fk_Express = 0;
        list.OrderNumber = MojoCube.Api.Text.Function.DateTimeString(true);
        list.TrackingNumber = string.Empty;
        list.CustomerName = txtContactName.Text.Trim();
        list.CustomerSex = 0;
        list.CustomerPhone1 = txtContactPhone.Text.Trim();
        list.CustomerPhone2 = string.Empty;
        list.CustomerQQ = string.Empty;
        list.CustomerEmail = ViewState["Email"].ToString();
        list.CustomerZip = string.Empty;
        list.CustomerAddress = txtAddress.Text.Trim();
        list.Description = string.Empty;
        list.Remark = txtRemark.Text.Trim();
        list.Note = string.Empty;
        list.TypeID = 0;
        list.Freight = 0;
        list.Premium = 0;
        list.Amount = (decimal)ViewState["Total"];
        list.Currency = 0;
        list.CreateDate = DateTime.Now.ToString();
        list.EndDate = DateTime.Now.ToString();
        list.fk_Payment = 0;
        list.PaymentDate = DateTime.Now.ToString();
        list.ShipmentDate = DateTime.Now.ToString();
        list.ShipperCode = string.Empty;
        list.LogisticCode = string.Empty;
        list.LogisticInfo = string.Empty;
        list.LastCheck = DateTime.Now.ToString();
        list.CancelDate = DateTime.Now.ToString();
        list.IsPublic = false;
        list.IsAssess = false;
        list.IsComment = false;
        list.Comments = string.Empty;
        list.StatusID = 0;
        list.IsDeleted = false;
        int orderId = list.InsertData();

        #endregion

        #region  加入订单产品

        MojoCube.Web.Order.Item item = new MojoCube.Web.Order.Item();
        item.fk_Order = orderId;

        string productList = string.Empty;

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            item.fk_ID = int.Parse(((Label)GridView1.Rows[i].FindControl("lblfkID")).Text);
            item.fk_Price = 0;
            item.TypeID = 0;
            item.Title = ((Label)GridView1.Rows[i].FindControl("lblProductName")).Text;
            item.ImagePath = ((Label)GridView1.Rows[i].FindControl("lblImagePath")).Text;
            item.PageName = ((Label)GridView1.Rows[i].FindControl("lblPageName")).Text;
            item.Price = decimal.Parse(((Label)GridView1.Rows[i].FindControl("lblPrice")).Text);
            item.Amount = decimal.Parse(((Label)GridView1.Rows[i].FindControl("lblAmount")).Text);
            item.Currency = 0;
            item.Qty = int.Parse(((TextBox)GridView1.Rows[i].FindControl("txtQty")).Text.Trim());
            item.Remark = string.Empty;
            item.StatusID = 0;
            item.CreateDate = DateTime.Now.ToString();
            item.InsertData();

            //邮件替换内容
            replace.ProductName = ((Label)GridView1.Rows[i].FindControl("lblProductName")).Text;
            replace.Price = ((Label)GridView1.Rows[i].FindControl("lblPrice")).Text;
            replace.Qty = ((TextBox)GridView1.Rows[i].FindControl("txtQty")).Text.Trim();
            replace.Amount = ((Label)GridView1.Rows[i].FindControl("lblAmount")).Text;
            templateInfo += replace.Replace(repeatText);

            //产品名称组合
            productList += ((Label)GridView1.Rows[i].FindControl("lblProductName")).Text + "×" + item.Qty.ToString() + ",";
        }

        if (productList.Length > 1)
        {
            productList = productList.Substring(0, productList.Length - 1);

            list.Description = productList;
            list.UpdateData(orderId);
        }

        #endregion

        #region  发送通知信息

        mailbody = mailbody.Replace(repeatText, templateInfo);
        replace.TrueName = list.CustomerName;
        replace.Total = ViewState["Total"].ToString();
        mailbody = replace.Replace(mailbody);

        MojoCube.Web.Mail.Receive receive = new MojoCube.Web.Mail.Receive();
        string mailList = receive.GetEmailList(account.pk_Account);

        if (account.SmtpPort == 25)
        {
            MojoCube.Api.Mail.Thread mail = new MojoCube.Api.Mail.Thread();
            mail.From = account.LoginName;
            mail.DisplayName = account.DisplayName;
            //给买家发送邮件
            mail.To = list.CustomerEmail;
            //CC给系统需要通知的人员
            if (mailList != "")
            {
                mail.CC = mailList;
            }
            mail.Subject = template.Subject;
            mail.Body = mailbody;
            mail.SmtpHost = account.SmtpHost;
            mail.Port = account.SmtpPort;
            mail.EnableSsl = false;
            mail.UserName = account.LoginName;
            mail.Password = MojoCube.Api.Text.Security.DecryptString(account.Password);
            mail.Send();
        }
        else
        {
            MojoCube.Api.Mail.WebMail mail = new MojoCube.Api.Mail.WebMail();
            mail.From = account.LoginName;
            mail.DisplayName = account.DisplayName;
            //给买家发送邮件
            mail.To = list.CustomerEmail;
            //CC给系统需要通知的人员
            if (mailList != "")
            {
                mail.CC = mailList;
            }
            mail.Subject = template.Subject;
            mail.Body = mailbody;
            mail.SmtpHost = account.SmtpHost;
            mail.Port = account.SmtpPort;
            mail.EnableSsl = true;
            mail.UserName = account.LoginName;
            mail.Password = MojoCube.Api.Text.Security.DecryptString(account.Password);
            mail.Send();
        }

        //发送短信通知
        //MojoCube.Web.SMS.Function.Send(0, 1, orderId);

        #endregion

        #region  下单成功重置

        MojoCube.Web.Sql.SqlQuery("update Member_Cart set StatusID=1 where fk_Member=" + Session["Member_UserID"].ToString() + " and StatusID=0 and pk_Cart in (" + Session["CartToOrder"].ToString() + ")");
        Session.Remove("CartToOrder");

        #endregion

        Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Pay", MojoCube.Api.UI.Language.GetLanguage()) + "?id=" + MojoCube.Api.Text.Security.EncryptString(orderId.ToString()));
    }
}