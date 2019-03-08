using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class WUC_Contact : System.Web.UI.UserControl
{
    public string strLanguage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strLanguage = MojoCube.Api.UI.Language.GetLanguage();

            ContactDiv.InnerHtml = MojoCube.Web.Site.Cache.GetContactUs(strLanguage);

            hlMore.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("Contact", strLanguage);

            LinkUL.InnerHtml = CreateLink();
        }
    }

    /// <summary>
    /// 加入到网站缓存，减少数据库连接
    /// </summary>
    /// <param name="language">语言</param>
    /// <returns></returns>
    private string GetLink(string language)
    {
        if (HttpRuntime.Cache["MojoCube_SiteLink_" + language] == null)
        {
            HttpRuntime.Cache["MojoCube_SiteLink_" + language] = CreateLink();
        }
        return HttpRuntime.Cache["MojoCube_SiteLink_" + language].ToString();
    }

    /// <summary>
    /// 创建链接
    /// </summary>
    /// <returns></returns>
    private string CreateLink()
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = MojoCube.Web.Sql.SqlQueryDS(" select Url,Title from Site_Link where TypeID=0 and Visible=1 and Language='" + strLanguage + "' order by SortID asc").Tables[0];

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("<li><a href=\"" + dt.Rows[i]["Url"].ToString() + "\" target=\"_blank\">" + dt.Rows[i]["Title"].ToString() + "</a></li>");
            }
        }

        return sb.ToString();
    }
}