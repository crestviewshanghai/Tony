using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WUC_MobileMenu : System.Web.UI.UserControl
{
    public string strLanguage;
    protected string phoneNumber;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strLanguage = MojoCube.Api.UI.Language.GetLanguage();

            ShareDiv.InnerHtml = MojoCube.Web.Site.Cache.GetShare(strLanguage);

            phoneNumber = "tel:" + MojoCube.Web.Site.Cache.GetSiteContact(strLanguage);
        }
    }
}