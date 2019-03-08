using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Member
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
        int _fk_Member;
        public int fk_Member
        {
            get { return _fk_Member; }
            set { _fk_Member = value; }
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
                string sql = "select * from Member_Online where pk_Online=@pk_Online";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Online", SqlDbType.Int));
                comm.Parameters["@pk_Online"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Online = Convert.ToInt32(dr["pk_Online"].ToString());
                    _fk_Member = Convert.ToInt32(dr["fk_Member"].ToString());
                    _SessionID = dr["SessionID"].ToString();
                    _IPAddress = dr["IPAddress"].ToString();
                    _Browser = dr["Browser"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _LoginTime = dr["LoginTime"].ToString();
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
                string sql = "insert into Member_Online(fk_Member,SessionID,IPAddress,Browser,TypeID,LoginTime) values (@fk_Member,@SessionID,@IPAddress,@Browser,@TypeID,@LoginTime)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Member", SqlDbType.Int));
                comm.Parameters["@fk_Member"].Value = _fk_Member;
                comm.Parameters.Add(new SqlParameter("@SessionID", SqlDbType.VarChar, 50));
                comm.Parameters["@SessionID"].Value = _SessionID;
                comm.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.VarChar, 20));
                comm.Parameters["@IPAddress"].Value = _IPAddress;
                comm.Parameters.Add(new SqlParameter("@Browser", SqlDbType.VarChar, 20));
                comm.Parameters["@Browser"].Value = _Browser;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@LoginTime", SqlDbType.DateTime));
                comm.Parameters["@LoginTime"].Value = _LoginTime;
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
        /// 修改数据
        /// </summary>
        /// <param name="id">ID</param>
        public void UpdateData(int id)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update Member_Online set fk_Member=@fk_Member,SessionID=@SessionID,IPAddress=@IPAddress,Browser=@Browser,TypeID=@TypeID,LoginTime=@LoginTime where pk_Online=@pk_Online";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Member", SqlDbType.Int));
                comm.Parameters["@fk_Member"].Value = _fk_Member;
                comm.Parameters.Add(new SqlParameter("@SessionID", SqlDbType.VarChar, 50));
                comm.Parameters["@SessionID"].Value = _SessionID;
                comm.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.VarChar, 20));
                comm.Parameters["@IPAddress"].Value = _IPAddress;
                comm.Parameters.Add(new SqlParameter("@Browser", SqlDbType.VarChar, 20));
                comm.Parameters["@Browser"].Value = _Browser;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@LoginTime", SqlDbType.DateTime));
                comm.Parameters["@LoginTime"].Value = _LoginTime;
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
            Sql.SqlQuery("delete from Member_Online where pk_Online=" + id);
        }

        #endregion
    }
}
