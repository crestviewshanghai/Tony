using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;

public partial class Admin_Order_Report : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //待付款
        lblOrderCount1.Text = MojoCube.Web.Sql.GetResultCount("Order_List", "StatusID=0").ToString();
        lblOrderAmount1.Text = MojoCube.Web.String.GetCurrency(MojoCube.Web.Sql.GetResultSum("Order_List", "Amount", "StatusID=0"));

        //待发货
        lblOrderCount2.Text = MojoCube.Web.Sql.GetResultCount("Order_List", "StatusID=1").ToString();
        lblOrderAmount2.Text = MojoCube.Web.String.GetCurrency(MojoCube.Web.Sql.GetResultSum("Order_List", "Amount", "StatusID=1"));

        //待收货
        lblOrderCount3.Text = MojoCube.Web.Sql.GetResultCount("Order_List", "StatusID=2").ToString();
        lblOrderAmount3.Text = MojoCube.Web.String.GetCurrency(MojoCube.Web.Sql.GetResultSum("Order_List", "Amount", "StatusID=2"));

        //已完成
        lblOrderCount4.Text = MojoCube.Web.Sql.GetResultCount("Order_List", "StatusID=3").ToString();
        lblOrderAmount4.Text = MojoCube.Web.String.GetCurrency(MojoCube.Web.Sql.GetResultSum("Order_List", "Amount", "StatusID=3"));

        DrawLine();
        DrawPie();

        if (!IsPostBack)
        {
            txtDate1.Text = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            txtDate2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            OrderListDiv.InnerHtml = CreateOrderList();

            txtDate3.Text = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            txtDate4.Text = DateTime.Now.ToString("yyyy-MM-dd");
            OrderLogDiv.InnerHtml = CreateOrderLog();
        }
    }

    #region  交易额曲线图
    private void DrawLine()
    {
        ZedGraph1.Type = AnalyticsType.Line;
        ZedGraph1.Title = DateTime.Now.Year.ToString() + " . " + DateTime.Now.Month.ToString();
        ZedGraph1.XAxisTitle = "Month";
        ZedGraph1.YAxisTitle = "Amount";
        ZedGraph1.ZGWidth = 780;
        ZedGraph1.ZGHeight = 250;
        ZedGraph1.IsChangeColor = false;
        ZedGraph.PointPairList ppl = new ZedGraph.PointPairList();

        DateTime current = DateTime.Now;
        ArrayList al = new ArrayList();

        for (int i = 0; i < 12; i++)
        {
            int iMM = i + 1;
            DateTime start = new DateTime(current.Year, iMM, 1);
            DateTime end = new DateTime(current.Year, iMM, DateTime.DaysInMonth(current.Year, iMM));

            string where = string.Empty;
            where = "StatusID>0 and StatusID<4 and CreateDate >='" + start.ToString("yyyy-MM-dd") + " 00:00:00' and CreateDate <='" + end.ToString("yyyy-MM-dd") + " 23:59:59'";
            decimal iCount = MojoCube.Web.Sql.GetResultSum("Order_List", "Amount", where);

            double x = i;
            double y = (double)iCount;
            ppl.Add(x, y);
        }
        ZedGraph1.DataSource.Add(ppl);
        ZedGraph1.CurveNameList.Add("");
    }
    #endregion

    #region  产品销量饼图
    private void DrawPie()
    {
        DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select top 5 COUNT(pk_Item) as Counter,Title from Order_Item group by Title order by Counter desc").Tables[0];

        ZedGraph2.Type = AnalyticsType.Pie;
        ZedGraph2.Title = string.Empty;
        ZedGraph2.ZGWidth = 550;
        ZedGraph2.ZGHeight = 250;
        ZedGraph2.IsChangeColor = true;

        if (dt.Rows.Count > 0)
        {
            string title = string.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                title = dt.Rows[i]["Title"].ToString();

                ZedGraph2.ScaleData.Add(double.Parse(dt.Rows[i]["Counter"].ToString()));
                ZedGraph2.NameList.Add(title);
            }
        }
    }
    #endregion

    #region  订单列表
    private string CreateOrderList()
    {
        DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Order_List where CreateDate >='" + txtDate1.Text.Trim() + " 00:00:00' and CreateDate <='" + txtDate2.Text.Trim() + " 23:59:59' order by CreateDate desc").Tables[0];

        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            lblOrderListCount.Text = dt.Rows.Count.ToString();

            sb.Append("<table class=\"table table-hover\">");
            sb.Append("<tr>");
            sb.Append("<th style=\"width:120px\">订单编号</th>");
            sb.Append("<th style=\"width:100px\">联系人</th>");
            sb.Append("<th style=\"width:100px\">联系电话</th>");
            sb.Append("<th>描述</th>");
            sb.Append("<th style=\"width:100px\">金额</th>");
            sb.Append("<th style=\"width:150px\">时间</th>");
            sb.Append("<th style=\"width:100px\">状态</th>");
            sb.Append("<th style=\"width:50px;\"></th>");
            sb.Append("</tr>");

            decimal amount = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["pk_Order"].ToString());
                amount += decimal.Parse(dt.Rows[i]["Amount"].ToString());

                sb.Append("<tr>");
                sb.Append("<td>" + dt.Rows[i]["OrderNumber"].ToString() + "</td>");
                sb.Append("<td>" + dt.Rows[i]["CustomerName"].ToString() + "</td>");
                sb.Append("<td>" + dt.Rows[i]["CustomerPhone1"].ToString() + "</td>");
                sb.Append("<td>" + dt.Rows[i]["Description"].ToString() + "</td>");
                sb.Append("<td>" + MojoCube.Web.String.GetCurrency(decimal.Parse(dt.Rows[i]["Amount"].ToString())) + "</td>");
                sb.Append("<td>" + DateTime.Parse(dt.Rows[i]["CreateDate"].ToString()).ToString("yyyy-MM-dd HH:mm") + "</td>");
                sb.Append("<td>" + MojoCube.Web.Sys.StatusID.GetStatusName("Order_List", dt.Rows[i]["StatusID"].ToString(), "CHS") + "</td>");
                sb.Append("<td><a href=\"Edit.aspx?id=" + id + "&active=92,93\"><span class=\"btn btn-default\" style=\"padding:2px 5px; font-size:9pt;\"><i class=\"fa fa-search\"></i> 查看</span></a></td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
            }

            sb.Append("</table>");

            lblOrderListAmount.Text = MojoCube.Web.String.GetCurrency(amount);
        }

        return sb.ToString();
    }

    protected void lnbSearch1_Click(object sender, EventArgs e)
    {
        OrderListDiv.InnerHtml = CreateOrderList();
    }
    #endregion

    #region  交易记录
    private string CreateOrderLog()
    {
        DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Order_Log where CreateDate >='" + txtDate3.Text.Trim() + " 00:00:00' and CreateDate <='" + txtDate4.Text.Trim() + " 23:59:59' order by CreateDate desc").Tables[0];

        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            lblOrderLogCount.Text = dt.Rows.Count.ToString();

            sb.Append("<table class=\"table table-hover\">");
            sb.Append("<tr>");
            sb.Append("<th style=\"width:120px\">订单编号</th>");
            sb.Append("<th>描述</th>");
            sb.Append("<th style=\"width:100px\">金额</th>");
            sb.Append("<th style=\"width:100px\">类型</th>");
            sb.Append("<th style=\"width:100px\">状态</th>");
            sb.Append("<th style=\"width:150px\">时间</th>");
            sb.Append("<th style=\"width:50px;\"></th>");
            sb.Append("</tr>");

            decimal amount = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = MojoCube.Api.Text.Security.EncryptString(dt.Rows[i]["fk_Order"].ToString());
                amount += decimal.Parse(dt.Rows[i]["Amount"].ToString());

                sb.Append("<tr>");
                sb.Append("<td>" + dt.Rows[i]["OrderNumber"].ToString() + "</td>");
                sb.Append("<td>" + dt.Rows[i]["Description"].ToString() + "</td>");
                sb.Append("<td>" + MojoCube.Web.String.GetCurrency(decimal.Parse(dt.Rows[i]["Amount"].ToString())) + "</td>");
                sb.Append("<td>" + dt.Rows[i]["ChannelType"].ToString() + "</td>");
                sb.Append("<td>" + dt.Rows[i]["TransName"].ToString() + "</td>");
                sb.Append("<td>" + DateTime.Parse(dt.Rows[i]["CreateDate"].ToString()).ToString("yyyy-MM-dd HH:mm") + "</td>");
                sb.Append("<td><a href=\"Edit.aspx?id=" + id + "&active=92,93\"><span class=\"btn btn-default\" style=\"padding:2px 5px; font-size:9pt;\"><i class=\"fa fa-search\"></i> 查看</span></a></td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
            }

            sb.Append("</table>");

            lblOrderLogAmount.Text = MojoCube.Web.String.GetCurrency(amount);
        }

        return sb.ToString();
    }

    protected void lnbSearch2_Click(object sender, EventArgs e)
    {
        OrderLogDiv.InnerHtml = CreateOrderLog();
    }
    #endregion
}