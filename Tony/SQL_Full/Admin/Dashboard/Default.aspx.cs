using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;

public partial class Admin_Dashboard_Default : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        string strLanguage = MojoCube.Api.UI.Language.GetLanguage();

        #region  连接数据层
        StringBuilder strSql = new StringBuilder();
        //0：日志
        strSql.Append(" select count(pk_Log) as Counter from Site_Log where LogTime>='" + date + " 00:00:00' and LogTime<='" + date + " 23:59:59'");
        //1：订单
        strSql.Append(" select count(pk_Order) as Counter from Order_List where IsDeleted=0 and StatusID=0");
        //2：产品
        strSql.Append(" select count(pk_Product) as Counter from Product_List where Issue=1 and Language='" + strLanguage + "'");
        //3：留言
        strSql.Append(" select count(pk_Comment) as Counter from Comment_List where Issue=1 and StatusID=0");
        //4：点击率
        strSql.Append(" select top 5 Url,COUNT(Url) as Counter from Site_Log where LogTime>='" + date + " 00:00:00' and LogTime<='" + date + " 23:59:59' group by Url order by Counter desc");
        //5：我的便签
        strSql.Append(" select top 5 * from Memo_List where fk_User=" + Session["UserID"].ToString() + " order by IsStar desc,ModifyDate desc");

        DataSet ds = MojoCube.Web.Sql.SqlQueryDS(strSql.ToString());
        #endregion

        LogDiv.InnerHtml = CreateLog(ds.Tables[0]);
        OrderDiv.InnerHtml = CreateOrder(ds.Tables[1]);
        ProductDiv.InnerHtml = CreateProduct(ds.Tables[2]);
        CommentDiv.InnerHtml = CreateComment(ds.Tables[3]);
        ServerDiv.InnerHtml = GetServerInfo();
        DrawLine();
        DrawPie(ds.Tables[4]);
        MemoDiv.InnerHtml = CreateMemo(ds.Tables[5]);
    }

    #region  日志

    private string CreateLog(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            sb.Append("<h3>" + dt.Rows[0]["Counter"].ToString() + "</h3>");
        }
        else
        {
            sb.Append("<h3>0</h3>");
        }

        sb.Append("<p>今日浏览网站数</p>");

        return sb.ToString();
    }

    #endregion

    #region  订单

    private string CreateOrder(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            sb.Append("<h3>" + dt.Rows[0]["Counter"].ToString() + "</h3>");
        }
        else
        {
            sb.Append("<h3>0</h3>");
        }

        sb.Append("<p>新订单数</p>");

        return sb.ToString();
    }

    #endregion

    #region  产品

    private string CreateProduct(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            sb.Append("<h3>" + dt.Rows[0]["Counter"].ToString() + "</h3>");
        }
        else
        {
            sb.Append("<h3>0</h3>");
        }

        sb.Append("<p>产品总数</p>");

        return sb.ToString();
    }

    #endregion

    #region  留言

    private string CreateComment(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            sb.Append("<h3>" + dt.Rows[0]["Counter"].ToString() + "</h3>");
        }
        else
        {
            sb.Append("<h3>0</h3>");
        }

        sb.Append("<p>未处理留言</p>");

        return sb.ToString();
    }

    #endregion

    #region  服务器信息
    private string GetServerInfo()
    {
        string text = "";

        try
        {
            text += "<div style=\"padding:10px 20px 20px 20px; border-top:solid 1px #eee; line-height:1.8em; color:#666;\">";
            text += "<font>服务器OS：</font>" + Environment.OSVersion.ToString() + "<br />";
            text += "<font>CPU核心数：</font>" + Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS") + "个核心<br />";
            text += "<font>CPU类型：</font>" + Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER") + "<br />";
            text += "<font>IIS版本：</font>" + Request.ServerVariables["SERVER_SOFTWARE"] + "<br />";
            text += "<font>服务器名：</font>" + Server.MachineName + "<br />";
            text += "<font>服务器域名：</font>" + Request.ServerVariables["SERVER_NAME"] + "<br />";
            text += "<font>虚拟服务绝对路径：</font>" + Request.ServerVariables["APPL_PHYSICAL_PATH"] + "<br />";
            text += "<font>.Net版本：</font>" + ".NET CLR " + Environment.Version.ToString() + "<br />";
            text += "<font>脚本超时时间：</font>" + Server.ScriptTimeout.ToString() + "毫秒<br />";
            text += "<font>开机运行时长：</font>" + ((Double)System.Environment.TickCount / 3600000).ToString("N2") + "小时<br />";
            text += "<font>Session总数：</font>" + Session.Contents.Count.ToString() + "<br />";
            text += "<font>Application总数：</font>" + Application.Contents.Count.ToString() + "<br />";
            text += "<font>应用程序缓存总数：</font>" + Cache.Count.ToString() + "<br />";
            text += "<font>本页执行时间：</font>" + Server.ScriptTimeout.ToString() + "毫秒";
            text += "</div>";
        }
        catch
        { 
        
        }

        return text;
    }
    #endregion

    #region  点击率曲线图
    private void DrawLine()
    {
        ZedGraph1.Type = AnalyticsType.Line;
        ZedGraph1.Title = DateTime.Now.Year.ToString() + " . " + DateTime.Now.Month.ToString();
        ZedGraph1.XAxisTitle = "Date";
        ZedGraph1.YAxisTitle = "Clicks";
        ZedGraph1.ZGWidth = 800;
        ZedGraph1.ZGHeight = 250;
        ZedGraph1.IsChangeColor = false;
        ZedGraph.PointPairList ppl = new ZedGraph.PointPairList();

        DateTime current = DateTime.Now;
        int iMM = current.Month;

        DateTime start = new DateTime(current.Year, iMM, 1);
        DateTime end = new DateTime(current.Year, iMM, DateTime.DaysInMonth(current.Year, iMM));

        int iDays = (int)((TimeSpan)(end - start)).TotalDays + 1;

        ArrayList al = new ArrayList();
        int nowDay = DateTime.Now.Day;
        if (iMM != current.Month)
        {
            nowDay = iDays;
        }

        for (int i = 0; i < iDays; i++)
        {
            string where = string.Empty;
            string timeShort = start.AddDays(i).ToString("yyyy-MM-dd");
            where = "LogTime >='" + timeShort + " 00:00:00' and LogTime <='" + timeShort + " 23:59:59'";
            int iCount = MojoCube.Web.Sql.GetResultCount("Site_Log", where);

            double x = i;
            double y = (double)iCount;
            ppl.Add(x, y);
        }
        ZedGraph1.DataSource.Add(ppl);
        ZedGraph1.CurveNameList.Add("");
    }
    #endregion

    #region  点击率饼图
    private void DrawPie(DataTable dt)
    {
        ZedGraph2.Type = AnalyticsType.Pie;
        ZedGraph2.Title = string.Empty;
        ZedGraph2.ZGWidth = 550;
        ZedGraph2.ZGHeight = 250;
        ZedGraph2.IsChangeColor = true;

        if (dt.Rows.Count > 0)
        {
            string url = string.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                url = dt.Rows[i]["Url"].ToString();

                ZedGraph2.ScaleData.Add(double.Parse(dt.Rows[i]["Counter"].ToString()));
                ZedGraph2.NameList.Add(System.IO.Path.GetFileName(url));
            }
        }
    }
    #endregion

    #region  我的便签

    private string CreateMemo(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            MojoCube.Web.User.List user = new MojoCube.Web.User.List();
            user.GetData(int.Parse(Session["UserID"].ToString()));

            string userImage = "";

            if (user.ImagePath1 != "")
            {
                userImage = "../Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(user.ImagePath1);
            }
            else
            {
                userImage = "../Images/user.png";
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("<div class=\"item\" style=\"border-top:dashed 1px #eee; padding-top:10px;\">");
                sb.Append("<img src=\"" + userImage + "\" class=\"online\">");
                sb.Append("<p class=\"message\">");
                sb.Append("<a href=\"../User/Profile.aspx\" class=\"name\">");
                sb.Append("<small class=\"text-muted pull-right\"><i class=\"fa fa-clock-o\"></i> " + DateTime.Parse(dt.Rows[i]["ModifyDate"].ToString()).ToString("yyyy-MM-dd HH:mm") + "</small>");
                if (dt.Rows[i]["Title"].ToString() != "")
                {
                    sb.Append(dt.Rows[i]["Title"].ToString());
                }
                else
                {
                    sb.Append("无标题");
                }
                sb.Append("</a>");
                sb.Append(dt.Rows[i]["Description"].ToString());
                sb.Append("</p>");
                sb.Append("</div>");
            }
        }

        return sb.ToString();
    }

    protected void lnbSaveMemo_Click(object sender, EventArgs e)
    {
        if (txtMemoContent.Text.Trim() != "")
        {
            MojoCube.Web.Memo.List list = new MojoCube.Web.Memo.List();

            list.fk_User = int.Parse(Session["UserID"].ToString());
            list.fk_Department = int.Parse(Session["DepartmentID"].ToString());
            list.TypeID = 0;
            list.StatusID = 0;
            list.Title = string.Empty;
            list.Description = txtMemoContent.Text.Trim();
            list.ImagePath = string.Empty;
            list.FilePath = string.Empty;
            list.UserList = string.Empty;
            list.DepartmentList = string.Empty;
            list.RoleList = string.Empty;
            list.Url = string.Empty;
            list.IsStar = false;
            list.Tags = string.Empty;
            list.fk_Company = 0;
            list.CreateUser = int.Parse(Session["UserID"].ToString());
            list.CreateDate = DateTime.Now.ToString();
            list.ModifyUser = 0;
            list.ModifyDate = DateTime.Now.ToString();
            list.InsertData();
        }

        Response.Redirect("Default.aspx");
    }

    #endregion
}