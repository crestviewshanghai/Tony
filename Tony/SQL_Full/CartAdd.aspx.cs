using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CartAdd : System.Web.UI.Page
{
    public string strLanguage;

    protected void Page_Init(object sender, EventArgs e)
    {
        strLanguage = MojoCube.Api.UI.Language.GetLanguage();

        MojoCube.Web.Member.List.ChkLogin(MojoCube.Web.Site.Cache.GetUrlExtension("Cart", strLanguage));
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["add"] != null)
            {
                int id = int.Parse(MojoCube.Api.Text.Security.DecryptString(Request.QueryString["add"]));

                if (!MojoCube.Web.Sql.IsExist("Member_Cart", "fk_ID", id, "fk_Member=" + Session["Member_UserID"].ToString() + " and StatusID=0"))
                {
                    MojoCube.Web.Member.Cart cart = new MojoCube.Web.Member.Cart();
                    cart.fk_Member = int.Parse(Session["Member_UserID"].ToString());
                    cart.TypeID = 0;
                    cart.StatusID = 0;
                    cart.fk_ID = id;
                    cart.Qty = 1;
                    cart.CreateDate = DateTime.Now.ToString();
                    cart.InsertData();
                }
            }
            else if (Request.QueryString["del"] != null)
            {
                int id = int.Parse(MojoCube.Api.Text.Security.DecryptString(Request.QueryString["del"]));

                if (MojoCube.Web.Sql.IsExist("Member_Cart", "pk_Cart", id, "fk_Member=" + Session["Member_UserID"].ToString()))
                {
                    MojoCube.Web.Member.Cart cart = new MojoCube.Web.Member.Cart();
                    cart.DeleteData(id);
                }
            }

            Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Cart", strLanguage));
        }
    }
}