using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace MojoCube.Web.User
{
    public class Online
    {
        #region 公共属性
        int _pk_Online;
        public int pk_Online
        {
            get { return _pk_Online; }
            set { _pk_Online = value; }
        }
        int _fk_User;
        public int fk_User
        {
            get { return _fk_User; }
            set { _fk_User = value; }
        }
        string _SessionID;
        public string SessionID
        {
            get { return _SessionID; }
            set { _SessionID = value; }
        }
        string _IPAddress;
        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
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
        string _LoginTime;
        public string LoginTime
        {
            get { return _LoginTime; }
            set { _LoginTime = value; }
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
                string sql = "select * from User_Online where pk_Online=@pk_Online";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Online", SqlDbType.Int));
                comm.Parameters["@pk_Online"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Online = Convert.ToInt32(dr["pk_Online"].ToString());
                    _fk_User = Convert.ToInt32(dr["fk_User"].ToString());
                    _SessionID = dr["SessionID"].ToString();
                    _IPAddress = dr["IPAddress"].ToString();
                    _Browser = dr["Browser"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _LoginTime = dr["LoginTime"].ToString();
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
                string sql = "insert into User_Online(fk_User,SessionID,IPAddress,Browser,TypeID,LoginTime,fk_Company) values (@fk_User,@SessionID,@IPAddress,@Browser,@TypeID,@LoginTime,@fk_Company)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_User", SqlDbType.Int));
                comm.Parameters["@fk_User"].Value = _fk_User;
                comm.Parameters.Add(new SqlParameter("@SessionID", SqlDbType.NVarChar, 50));
                comm.Parameters["@SessionID"].Value = _SessionID;
                comm.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.NVarChar, 50));
                comm.Parameters["@IPAddress"].Value = _IPAddress;
                comm.Parameters.Add(new SqlParameter("@Browser", SqlDbType.NVarChar, 50));
                comm.Parameters["@Browser"].Value = _Browser;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@LoginTime", SqlDbType.DateTime));
                comm.Parameters["@LoginTime"].Value = _LoginTime;
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
        /// 加入在线
        /// </summary>
        /// <param name="type">0位手动登录，1位自动登录</param>
        public static void AddOnline(int type)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "insert into User_Online(fk_User,SessionID,IPAddress,Browser,TypeID,LoginTime,fk_Company) values (@fk_User,@SessionID,@IPAddress,@Browser,@TypeID,@LoginTime,@fk_Company)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_User", SqlDbType.Int));
                if (HttpContext.Current.Session["UserID"] != null)
                {
                    comm.Parameters["@fk_User"].Value = int.Parse(HttpContext.Current.Session["UserID"].ToString());
                }
                else
                {
                    comm.Parameters["@fk_User"].Value = 0;
                }
                comm.Parameters.Add(new SqlParameter("@SessionID", SqlDbType.NVarChar, 50));
                comm.Parameters["@SessionID"].Value = HttpContext.Current.Session.SessionID;
                comm.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.NVarChar, 50));
                comm.Parameters["@IPAddress"].Value = IP.Get();
                comm.Parameters.Add(new SqlParameter("@Browser", SqlDbType.NVarChar, 50));
                comm.Parameters["@Browser"].Value = String.GetBrowserInfo();
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = type;
                comm.Parameters.Add(new SqlParameter("@LoginTime", SqlDbType.DateTime));
                comm.Parameters["@LoginTime"].Value = DateTime.Now;
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
                string sql = "update User_Online set fk_User=@fk_User,SessionID=@SessionID,IPAddress=@IPAddress,Browser=@Browser,TypeID=@TypeID,LoginTime=@LoginTime,fk_Company=@fk_Company where pk_Online=@pk_Online";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_User", SqlDbType.Int));
                comm.Parameters["@fk_User"].Value = _fk_User;
                comm.Parameters.Add(new SqlParameter("@SessionID", SqlDbType.NVarChar, 50));
                comm.Parameters["@SessionID"].Value = _SessionID;
                comm.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.NVarChar, 50));
                comm.Parameters["@IPAddress"].Value = _IPAddress;
                comm.Parameters.Add(new SqlParameter("@Browser", SqlDbType.NVarChar, 50));
                comm.Parameters["@Browser"].Value = _Browser;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@LoginTime", SqlDbType.DateTime));
                comm.Parameters["@LoginTime"].Value = _LoginTime;
                comm.Parameters.Add(new SqlParameter("@fk_Company", SqlDbType.Int));
                comm.Parameters["@fk_Company"].Value = _fk_Company;
                comm.Parameters.Add(new SqlParameter("@pk_Online", SqlDbType.Int));
                comm.Parameters["@pk_Online"].Value = id;
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
            Sql.SqlQuery("delete from User_Online where pk_Online=" + id);
        }

        #endregion
    }
}
