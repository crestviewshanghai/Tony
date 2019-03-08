using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace MojoCube.Web.User
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
        int _fk_User;
        public int fk_User
        {
            get { return _fk_User; }
            set { _fk_User = value; }
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
        string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        string _SessionID;
        public string SessionID
        {
            get { return _SessionID; }
            set { _SessionID = value; }
        }
        int _fk_Company;
        public int fk_Company
        {
            get { return _fk_Company; }
            set { _fk_Company = value; }
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
                string sql = "select * from User_Log where pk_Log=@pk_Log";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Log", SqlDbType.Int));
                comm.Parameters["@pk_Log"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Log = Convert.ToInt32(dr["pk_Log"].ToString());
                    _IPAddress = dr["IPAddress"].ToString();
                    _Url = dr["Url"].ToString();
                    _fk_User = Convert.ToInt32(dr["fk_User"].ToString());
                    _Browser = dr["Browser"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _LogTime = dr["LogTime"].ToString();
                    _Title = dr["Title"].ToString();
                    _Description = dr["Description"].ToString();
                    _SessionID = dr["SessionID"].ToString();
                    _fk_Company = Convert.ToInt32(dr["fk_Company"].ToString());
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
                string sql = "insert into User_Log(IPAddress,Url,fk_User,Browser,TypeID,LogTime,Title,Description,SessionID,fk_Company) values (@IPAddress,@Url,@fk_User,@Browser,@TypeID,@LogTime,@Title,@Description,@SessionID,@fk_Company)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.NVarChar, 50));
                comm.Parameters["@IPAddress"].Value = _IPAddress;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@fk_User", SqlDbType.Int));
                comm.Parameters["@fk_User"].Value = _fk_User;
                comm.Parameters.Add(new SqlParameter("@Browser", SqlDbType.NVarChar, 50));
                comm.Parameters["@Browser"].Value = _Browser;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@LogTime", SqlDbType.DateTime));
                comm.Parameters["@LogTime"].Value = _LogTime;
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@SessionID", SqlDbType.NVarChar, 50));
                comm.Parameters["@SessionID"].Value = _SessionID;
                comm.Parameters.Add(new SqlParameter("@fk_Company", SqlDbType.Int));
                comm.Parameters["@fk_Company"].Value = _fk_Company;
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
        /// 浏览记录
        /// </summary>
        /// <param name="title"></param>
        public static void AddLog(string title)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "insert into User_Log(IPAddress,Url,fk_User,Browser,TypeID,LogTime,Title,Description,SessionID,fk_Company) values (@IPAddress,@Url,@fk_User,@Browser,@TypeID,@LogTime,@Title,@Description,@SessionID,@fk_Company)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.NVarChar, 50));
                comm.Parameters["@IPAddress"].Value = IP.Get();
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = String.GetUrl(0);
                comm.Parameters.Add(new SqlParameter("@fk_User", SqlDbType.Int));
                if (HttpContext.Current.Session["UserID"] != null)
                {
                    comm.Parameters["@fk_User"].Value = int.Parse(HttpContext.Current.Session["UserID"].ToString());
                }
                else
                {
                    comm.Parameters["@fk_User"].Value = 0;
                }
                comm.Parameters.Add(new SqlParameter("@Browser", SqlDbType.NVarChar, 50));
                comm.Parameters["@Browser"].Value = String.GetBrowserInfo();
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = 0;
                comm.Parameters.Add(new SqlParameter("@LogTime", SqlDbType.DateTime));
                comm.Parameters["@LogTime"].Value = DateTime.Now; ;
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = title;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = HttpContext.Current.Request.ServerVariables.Get("HTTP_USER_AGENT");
                comm.Parameters.Add(new SqlParameter("@SessionID", SqlDbType.NVarChar, 50));
                comm.Parameters["@SessionID"].Value = HttpContext.Current.Session.SessionID;
                comm.Parameters.Add(new SqlParameter("@fk_Company", SqlDbType.Int));
                comm.Parameters["@fk_Company"].Value = 0;
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
                string sql = "update User_Log set IPAddress=@IPAddress,Url=@Url,fk_User=@fk_User,Browser=@Browser,TypeID=@TypeID,LogTime=@LogTime,Title=@Title,Description=@Description,SessionID=@SessionID,fk_Company=@fk_Company where pk_Log=@pk_Log";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.NVarChar, 50));
                comm.Parameters["@IPAddress"].Value = _IPAddress;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@fk_User", SqlDbType.Int));
                comm.Parameters["@fk_User"].Value = _fk_User;
                comm.Parameters.Add(new SqlParameter("@Browser", SqlDbType.NVarChar, 50));
                comm.Parameters["@Browser"].Value = _Browser;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@LogTime", SqlDbType.DateTime));
                comm.Parameters["@LogTime"].Value = _LogTime;
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@SessionID", SqlDbType.NVarChar, 50));
                comm.Parameters["@SessionID"].Value = _SessionID;
                comm.Parameters.Add(new SqlParameter("@fk_Company", SqlDbType.Int));
                comm.Parameters["@fk_Company"].Value = _fk_Company;
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
            Sql.SqlQuery("delete from User_Log where pk_Log=" + id);
        }

        #endregion
    }
}
