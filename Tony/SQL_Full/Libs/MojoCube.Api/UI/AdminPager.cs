using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web;

namespace MojoCube.Api.UI
{
    public class AdminPager
    {
        private Wuqi.Webdiyer.AspNetPager _Pager;

        #region  定义属性
        int _PageSize;
        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }
        string _ConnStr;
        public string ConnStr
        {
            get { return _ConnStr; }
            set { _ConnStr = value; }
        }
        int _CurrentPageIndex;
        public int CurrentPageIndex
        {
            get { return _CurrentPageIndex; }
            set { _CurrentPageIndex = value; }
        }
        private string _TableName;
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
        private string _strGetFields;
        public string strGetFields
        {
            get { return _strGetFields; }
            set { _strGetFields = value; }
        }
        private string _fldName;
        public string fldName
        {
            get { return _fldName; }
            set { _fldName = value; }
        }
        private string _where;
        public string where
        {
            get { return _where; }
            set { _where = value; }
        }
        private bool _OrderType;
        public bool OrderType
        {
            get { return _OrderType; }
            set { _OrderType = value; }
        }
        #endregion

        public AdminPager(Wuqi.Webdiyer.AspNetPager Pager)
        {
            string img1 = File.Function.GetRelativePath("Admin/Images/first.gif");
            string img2 = File.Function.GetRelativePath("Admin/Images/last.gif");
            string img3 = File.Function.GetRelativePath("Admin/Images/next.gif");
            string img4 = File.Function.GetRelativePath("Admin/Images/prev.gif");

            _Pager = Pager;
            _Pager.FirstPageText = "<span class=btnLink title='首页'><img src='" + img1 + "' /></span>";
            _Pager.LastPageText = "<span class=btnLink title='尾页'><img src='" + img2 + "' /></span>";
            _Pager.NextPageText = "<span class=btnLink title='下一页'><img src='" + img3 + "' /></span>";
            _Pager.NumericButtonTextFormatString = "<span class=Pager>{0}</span>";
            _Pager.PrevPageText = "<span class=btnLink title='上一页'><img src='" + img4 + "' /></span>";
            _Pager.SubmitButtonText = "GO";
            _Pager.CustomInfoClass = "CustomInfo";
            _Pager.CssClass = "Pager";
            _Pager.SubmitButtonClass = "PagerBtn";
            //_Pager.InputBoxClass = "PagerInput";
            _Pager.CurrentPageButtonClass = "CurrentPage";
            _Pager.ShowCustomInfoSection = Wuqi.Webdiyer.ShowCustomInfoSection.Left;
            //_Pager.ShowInputBox = Wuqi.Webdiyer.ShowInputBox.Always;
            _Pager.AlwaysShow = true;
            _Pager.UrlPaging = false;

            string mypage = Text.RegexClass.ChkInt(HttpContext.Current.Request.QueryString["page"]);
            if (mypage != "0")
            {
                _CurrentPageIndex = Convert.ToInt32(mypage);
            }
            else
            {
                _CurrentPageIndex = _Pager.CurrentPageIndex;
            }

            if (_where == null)
            {
                _where = "";
            }
        }

        #region  存储过程
        public DataTable GetTable()
        {
            DataSet DS = new DataSet();
            SqlConnection conn = new SqlConnection(ConnStr);
            SqlDataAdapter da = new SqlDataAdapter("pagination3", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@pageindex", SqlDbType.Int, 4);
            da.SelectCommand.Parameters["@pageindex"].Value = _CurrentPageIndex;
            da.SelectCommand.Parameters.Add("@pagesize", SqlDbType.Int, 4);
            da.SelectCommand.Parameters["@pagesize"].Value = _PageSize;
            da.SelectCommand.Parameters.Add("@docount", SqlDbType.Bit);
            da.SelectCommand.Parameters["@docount"].Value = 0;
            da.SelectCommand.Parameters.Add("@tblName", SqlDbType.VarChar, 100);
            da.SelectCommand.Parameters["@tblName"].Value = _TableName;
            da.SelectCommand.Parameters.Add("@strGetFields", SqlDbType.VarChar, 500);
            da.SelectCommand.Parameters["@strGetFields"].Value = strGetFields;
            da.SelectCommand.Parameters.Add("@fldName", SqlDbType.VarChar, 100);
            da.SelectCommand.Parameters["@fldName"].Value = _fldName;
            da.SelectCommand.Parameters.Add("@strWhere", SqlDbType.VarChar, 1500);
            da.SelectCommand.Parameters["@strWhere"].Value = _where;
            da.SelectCommand.Parameters.Add("@OrderType", SqlDbType.Bit);
            da.SelectCommand.Parameters["@OrderType"].Value = _OrderType;
            try
            {
                conn.Open();
                da.Fill(DS, "pagination3");
                da.Dispose();
            }
            finally
            {
                conn.Close();
            }

            SetPagerInfo();

            return DS.Tables[0];
        }

        public int GetRecordCount()
        {
            int RecordCount = 0;

            SqlConnection conn = new SqlConnection(ConnStr);
            SqlCommand cmd = new SqlCommand("pagination3", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageIndex", SqlDbType.Int, 4);
            cmd.Parameters["@PageIndex"].Value = 1;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int, 4);
            cmd.Parameters["@PageSize"].Value = _Pager.PageSize;
            cmd.Parameters.Add("@doCount", SqlDbType.Bit);
            cmd.Parameters["@doCount"].Value = 1;
            cmd.Parameters.Add("@tblName", SqlDbType.VarChar, 100);
            cmd.Parameters["@tblName"].Value = _TableName;
            cmd.Parameters.Add("@strGetFields", SqlDbType.VarChar, 500);
            cmd.Parameters["@strGetFields"].Value = _fldName;
            cmd.Parameters.Add("@fldName", SqlDbType.VarChar, 100);
            cmd.Parameters["@fldName"].Value = _fldName;
            cmd.Parameters.Add("@strWhere", SqlDbType.VarChar, 1500);
            cmd.Parameters["@strWhere"].Value = _where;
            try
            {
                conn.Open();
                RecordCount = (int)cmd.ExecuteScalar();
            }
            finally
            {
                conn.Close();
            }

            return RecordCount;
        }
        #endregion

        //是否显示有多少页
        public bool ShowCustomInfo = true;

        public void SetPagerInfo()
        {
            _Pager.RecordCount = GetRecordCount();
            _Pager.PageSize = _PageSize;

            if (ShowCustomInfo)
            {
                _Pager.CustomInfoHTML = "<div class='cleft'>共<span>" + _Pager.RecordCount + "</span>条 | 每页<span>" + _Pager.PageSize + "</span>条 | 共<span>" + _Pager.PageCount + "</span>页</div>";
            }
        }
    }
}
