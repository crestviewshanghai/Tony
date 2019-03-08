using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FavoriteAdd : System.Web.UI.Page
{
    public string strLanguage;

    protected void Page_Init(object sender, EventArgs e)
    {
        strLanguage = MojoCube.Api.UI.Language.GetLanguage();

        MojoCube.Web.Member.List.ChkLogin(MojoCube.Web.Site.Cache.GetUrlExtension("Favorite", strLanguage));
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["add"] != null)
            {
                int id = int.Parse(MojoCube.Api.Text.Security.DecryptString(Request.QueryString["add"]));

                if (!MojoCube.Web.Sql.IsExist("Member_Favorite", "fk_ID", id, "fk_Member=" + Session["Member_UserID"].ToString()))
                {
                    MojoCube.Web.Member.Favorite favorite = new MojoCube.Web.Member.Favorite();
                    favorite.fk_Member = int.Parse(Session["Member_UserID"].ToString());
                    favorite.TypeID = 0;
                    favorite.fk_ID = id;
                    favorite.Title = string.Empty;
                    favorite.Remark = string.Empty;
                    favorite.Url = string.Empty;
                    favorite.CreateDate = DateTime.Now.ToString();
                    favorite.InsertData();
                }
            }
            else if (Request.QueryString["del"] != null)
            {
                int id = int.Parse(MojoCube.Api.Text.Security.DecryptString(Request.QueryString["del"]));

                if (MojoCube.Web.Sql.IsExist("Member_Favorite", "pk_Favorite", id, "fk_Member=" + Session["Member_UserID"].ToString()))
                {
                    MojoCube.Web.Member.Favorite favorite = new MojoCube.Web.Member.Favorite();
                    favorite.DeleteData(id);
                }
            }

            Response.Redirect(MojoCube.Web.Site.Cache.GetUrlExtension("Favorite", strLanguage));
        }
    }
}