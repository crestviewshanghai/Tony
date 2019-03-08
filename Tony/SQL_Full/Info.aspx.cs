using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["type"] != null)
            {
                switch (Request.QueryString["type"])
                {
                    case "0":
                        MojoCube.Web.Site.Config config = new MojoCube.Web.Site.Config();
                        config.GetData(1, MojoCube.Api.UI.Language.GetLanguage());

                        if (!config.IsSiteOpen)
                        {
                            lblInfo.Text = config.ClosedInfo;
                        }

                        break;
                }
            }

            this.Title = lblInfo.Text;
        }
    }
}