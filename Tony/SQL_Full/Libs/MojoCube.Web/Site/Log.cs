using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Site
{
    public class Log
    {
        #region 公共属性
        int _pk_Log;
        public int pk_Log
        {
            get { return _pk_Log; }
            set { _pk_Log = value; }
        }
        string _IPAddress;
        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
        }
        string _Url;
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        int _MemberID;
        public int MemberID
        {
            get { return _MemberID; }
            set { _MemberID = value; }
        }
        string _Browser;
        public string Browser
        {
            get { return _Browser; }
            set { _Browser = value; }
        }
        int _TypeID;
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        string _LogTime;
        public string LogTime
        {
            get { return _LogTime; }
            set { _LogTime = value; }
        }
        string _Language;
        public string Language
        {
            get { return _Language; }
            set { _Language = value; }
        }
        #endregion

        #region 公共方法

        /// <summary>
        /// 获取字段值
        /// </summary>
        /// <param name="id">ID</param>
        public void GetData(int id)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Site_Log where pk_Log=@pk_Log";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Log", SqlDbType.Int));
                comm.Parameters["@pk_Log"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Log = Convert.ToInt32(dr["pk_Log"].ToString());
                    _IPAddress = dr["IPAddress"].ToString();
                    _Url = dr["Url"].ToString();
                    _MemberID = Convert.ToInt32(dr["MemberID"].ToString());
                    _Browser = dr["Browser"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _LogTime = dr["LogTime"].ToString();
                    _Language = dr["Language"].ToString();
                }
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 新增数据，返回ID
        /// </summary>
        /// <returns></returns>
        public int InsertData()
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "insert into Site_Log(IPAddress,Url,MemberID,Browser,TypeID,LogTime,Language) values (@IPAddress,@Url,@MemberID,@Browser,@TypeID,@LogTime,@Language)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.VarChar, 20));
                comm.Parameters["@IPAddress"].Value = _IPAddress;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 100));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@MemberID", SqlDbType.Int));
                comm.Parameters["@MemberID"].Value = _MemberID;
                comm.Parameters.Add(new SqlParameter("@Browser", SqlDbType.NVarChar, 50));
                comm.Parameters["@Browser"].Value = _Browser;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@LogTime", SqlDbType.DateTime));
                comm.Parameters["@LogTime"].Value = _LogTime;
                comm.Parameters.Add(new SqlParameter("@Language", SqlDbType.VarChar, 10));
                comm.Parameters["@Language"].Value = _Language;
                comm.ExecuteNonQuery();
                comm.CommandText = "select @@identity";
                return Convert.ToInt32(comm.ExecuteScalar());
            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 记录日志信息
        /// </summary>
        /// <returns></returns>
        /// <param name="language">Language</param>
        public static void InsertData(string language)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "insert into Site_Log(IPAddress,Url,MemberID,Browser,TypeID,LogTime,Language) values (@IPAddress,@Url,@MemberID,@Browser,@TypeID,@LogTime,@Language)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.VarChar, 20));
                comm.Parameters["@IPAddress"].Value = IP.Get();
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 100));
                comm.Parameters["@Url"].Value = System.Web.HttpContext.Current.Request.Path.ToString();
                comm.Parameters.Add(new SqlParameter("@MemberID", SqlDbType.Int));
                comm.Parameters["@MemberID"].Value = 0;
                comm.Parameters.Add(new SqlParameter("@Browser", SqlDbType.NVarChar, 50));
                comm.Parameters["@Browser"].Value = String.GetBrowserInfo();
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = 0;
                comm.Parameters.Add(new SqlParameter("@LogTime", SqlDbType.DateTime));
                comm.Parameters["@LogTime"].Value = DateTime.Now;
                comm.Parameters.Add(new SqlParameter("@Language", SqlDbType.VarChar, 10));
                comm.Parameters["@Language"].Value = language;
                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="id">ID</param>
        public void UpdateData(int id)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update Site_Log set IPAddress=@IPAddress,Url=@Url,MemberID=@MemberID,Browser=@Browser,TypeID=@TypeID,LogTime=@LogTime,Language=@Language where pk_Log=@pk_Log";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.VarChar, 20));
                comm.Parameters["@IPAddress"].Value = _IPAddress;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 100));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@MemberID", SqlDbType.Int));
                comm.Parameters["@MemberID"].Value = _MemberID;
                comm.Parameters.Add(new SqlParameter("@Browser", SqlDbType.NVarChar, 50));
                comm.Parameters["@Browser"].Value = _Browser;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@LogTime", SqlDbType.DateTime));
                comm.Parameters["@LogTime"].Value = _LogTime;
                comm.Parameters.Add(new SqlParameter("@Language", SqlDbType.VarChar, 10));
                comm.Parameters["@Language"].Value = _Language;
                comm.Parameters.Add(new SqlParameter("@pk_Log", SqlDbType.Int));
                comm.Parameters["@pk_Log"].Value = id;
                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">ID</param>
        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Site_Log where pk_Log=" + id);
        }

        #endregion
    }
}
