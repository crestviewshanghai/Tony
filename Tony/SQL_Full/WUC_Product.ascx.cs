using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class WUC_Product : System.Web.UI.UserControl
{
    public string strLanguage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strLanguage = MojoCube.Api.UI.Language.GetLanguage();

            #region  连接数据层
            StringBuilder strSql = new StringBuilder();
            //0：产品1
            strSql.Append(" select top 4 ProductName,PageName,ImagePath,Price from Product_List where Issue=1 and Language='" + strLanguage + "' order by newid()");
            //1：产品2
            strSql.Append(" select top 4 ProductName,PageName,ImagePath,Price from Product_List where Issue=1 and Language='" + strLanguage + "' order by newid()");
            //2：产品3
            strSql.Append(" select top 4 ProductName,PageName,ImagePath,Price from Product_List where Issue=1 and Language='" + strLanguage + "' order by newid()");

            DataSet ds = MojoCube.Web.Sql.SqlQueryDS(strSql.ToString());
            #endregion

            ProductList1.InnerHtml = CreateProduct(ds.Tables[0]);
            ProductList2.InnerHtml = CreateProduct(ds.Tables[1]);
            ProductList3.InnerHtml = CreateProduct(ds.Tables[2]);
        }
    }

    private string CreateProduct(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            string url = string.Empty;
            string title = string.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                url = MojoCube.Web.Site.Cache.GetUrlExtension("P-" + dt.Rows[i]["PageName"].ToString(), strLanguage);
                title = dt.Rows[i]["ProductName"].ToString();

                sb.Append("<div class=\"col-xs-6 col-sm-6 col-md-3 bottomProductImg\">");
                sb.Append("<img src=\"Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["ImagePath"].ToString()) + "&w=500&h=500\" alt=\"" + title + "\" />");
                sb.Append("<span>");
                sb.Append(title);
                sb.Append("<br /><font class=\"price\">" + MojoCube.Web.String.GetCurrency(decimal.Parse(dt.Rows[i]["Price"].ToString())) + "</font>");
                sb.Append("</span>");
                sb.Append("<a href=\"" + url + "\" title=\"" + title + "\">查看详情</a>");
                sb.Append("</div>");
            }
        }

        return sb.ToString();
    }
}