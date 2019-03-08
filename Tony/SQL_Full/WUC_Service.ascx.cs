using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class WUC_Service : System.Web.UI.UserControl
{
    public string strLanguage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strLanguage = MojoCube.Api.UI.Language.GetLanguage();

            ServiceDiv.InnerHtml = GetService(strLanguage);

            ShareDiv.InnerHtml = MojoCube.Web.Site.Cache.GetShare(strLanguage);

            imgQR.ImageUrl = "DrawQR.aspx?data=" + HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.FilePath;
        }
    }

    /// <summary>
    /// 加入到网站缓存，减少数据库连接
    /// </summary>
    /// <param name="language">语言</param>
    /// <returns></returns>
    private string GetService(string language)
    {
        if (HttpRuntime.Cache["MojoCube_SiteService_" + language] == null)
        {
            HttpRuntime.Cache["MojoCube_SiteService_" + language] = CreateService();
        }
        return HttpRuntime.Cache["MojoCube_SiteService_" + language].ToString();
    }

    /// <summary>
    /// 创建客服
    /// </summary>
    /// <returns></returns>
    private string CreateService()
    {
        StringBuilder sb = new StringBuilder();

        if (bool.Parse(MojoCube.Web.Site.Cache.GetSiteService(strLanguage)))
        {
            DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Site_Service where Visible=1 and Language='" + strLanguage + "' order by SortID asc").Tables[0];

            if (dt.Rows.Count > 0)
            {
                sb.Append("<div class=\"msggroup\">");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append(dt.Rows[i]["Description"].ToString());
                    sb.Append("<br />");
                }
                sb.Append("</div>");
            }
        }
        else
        {
            sb.Append("<script>$('#cmsFloatPanel').hide();</script>");
        }

        return sb.ToString();
    }
}