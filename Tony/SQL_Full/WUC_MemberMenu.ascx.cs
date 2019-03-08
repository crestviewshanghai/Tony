using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class WUC_MemberMenu : System.Web.UI.UserControl
{
    public string CssFocus
    {
        get
        {
            return HiddenField1.Value;
        }
        set
        {
            HiddenField1.Value = value;
        }
    }

    public string strLanguage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strLanguage = MojoCube.Api.UI.Language.GetLanguage();
            Nav.InnerHtml = CreateNav().Replace(HiddenField1.Value, HiddenField1.Value + " class=\"firstSelected selected\"");
        }
    }

    #region 创建导航
    private string CreateNav()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("<ul id=\"firstpane\">");

        sb.Append("<li><a id=\"Menu1\" href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("Member", strLanguage) + "\">会员中心</a></li>");
        sb.Append("<li><a id=\"Menu2\" href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("Order", strLanguage) + "\">我的订单</a></li>");
        sb.Append("<li><a id=\"Menu3\" href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("Favorite", strLanguage) + "\">我的收藏</a></li>");
        sb.Append("<li><a id=\"Menu4\" href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("Message", strLanguage) + "\">消息中心</a></li>");
        sb.Append("<li><a id=\"Menu5\" href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("Setting", strLanguage) + "\">个人设置</a></li>");
        sb.Append("<li><a href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("Logout", strLanguage) + "\">登出账号</a></li>");

        sb.Append("</ul>");

        return sb.ToString();
    }
    #endregion
}