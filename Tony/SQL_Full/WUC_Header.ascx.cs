using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class WUC_Header : System.Web.UI.UserControl
{
    public string strLanguage;
    protected string searchProduct;
    protected string searchNews;
    protected string strAlert;
    protected string strSearch;
    protected string searchType;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strLanguage = MojoCube.Api.UI.Language.GetLanguage();

            hlLogo.Text = "<img src='Files/" + MojoCube.Web.Site.Cache.GetSiteLogo(strLanguage) + "' alt='" + MojoCube.Web.Site.Cache.GetSiteName(strLanguage) + "' />";
            hlLogo.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Default", strLanguage);

            lblSiteName.Text = MojoCube.Web.Site.Cache.GetSiteName(strLanguage);

            searchType = MojoCube.Web.Site.Cache.GetSearchType(strLanguage);
            searchProduct = MojoCube.Api.File.Function.GetRelativePath(MojoCube.Web.Site.Cache.GetUrlExtension("Product", strLanguage));
            searchNews = MojoCube.Api.File.Function.GetRelativePath(MojoCube.Web.Site.Cache.GetUrlExtension("Article", strLanguage));

            strAlert = "请输入关键字";

            if (Request.QueryString["q"] != null)
            {
                strSearch = Request.QueryString["q"];
            }

            //网站公告
            string notify = MojoCube.Web.Site.Cache.GetSiteNotify(strLanguage);
            if (notify != "")
            {
                NotifyDiv.Visible = true;
                lblNotify.Text = notify;
            }

            hlUser.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Login", strLanguage);
            hlCart.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Cart", strLanguage);

            MojoCube.Web.Member.List.WriteSession();

            if (Session["Member_UserID"] != null)
            {
                hlCart.Text = "<span class=\"glyphicon glyphicon-shopping-cart\"></span> 购物车（" + MojoCube.Web.Sql.GetResultCount("Member_Cart", "fk_Member=" + Session["Member_UserID"].ToString() + " and StatusID=0") + "）";

                hlUser.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Member", strLanguage);

                string img = "Admin/Images/user.png";
                if (Session["Member_UserImagePath"].ToString() != "")
                {
                    img = "Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(Session["Member_UserImagePath"].ToString());
                }
                hlUser.Text = "<img src=\"" + img + "\" class=\"toppic\" />您好，" + Session["Member_UserLastName"].ToString() + Session["Member_UserFirstName"].ToString();
            }
            else
            {
                hlCart.Text = "<span class=\"glyphicon glyphicon-shopping-cart\"></span> 购物车";
            }
        }
    }
}