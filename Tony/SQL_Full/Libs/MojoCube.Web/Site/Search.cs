using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Site
{
    public class Search
    {
        #region 公共属性
        int _pk_Search;
        public int pk_Search
        {
            get { return _pk_Search; }
            set { _pk_Search = value; }
        }
        string _Keyword;
        public string Keyword
        {
            get { return _Keyword; }
            set { _Keyword = value; }
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
        int _Counts;
        public int Counts
        {
            get { return _Counts; }
            set { _Counts = value; }
        }
        string _Remark;
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        string _CreateDate;
        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
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
                string sql = "select * from Site_Search where pk_Search=@pk_Search";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Search", SqlDbType.Int));
                comm.Parameters["@pk_Search"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Search = Convert.ToInt32(dr["pk_Search"].ToString());
                    _Keyword = dr["Keyword"].ToString();
                    _IPAddress = dr["IPAddress"].ToString();
                    _Browser = dr["Browser"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _Counts = Convert.ToInt32(dr["Counts"].ToString());
                    _Remark = dr["Remark"].ToString();
                    _CreateDate = dr["CreateDate"].ToString();
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
                string sql = "insert into Site_Search(Keyword,IPAddress,Browser,TypeID,Counts,Remark,CreateDate) values (@Keyword,@IPAddress,@Browser,@TypeID,@Counts,@Remark,@CreateDate)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Keyword", SqlDbType.NVarChar, 500));
                comm.Parameters["@Keyword"].Value = _Keyword;
                comm.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.VarChar, 20));
                comm.Parameters["@IPAddress"].Value = _IPAddress;
                comm.Parameters.Add(new SqlParameter("@Browser", SqlDbType.VarChar, 20));
                comm.Parameters["@Browser"].Value = _Browser;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Counts", SqlDbType.Int));
                comm.Parameters["@Counts"].Value = _Counts;
                comm.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 500));
                comm.Parameters["@Remark"].Value = _Remark;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
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
        /// 新增数据
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="typeId">类型</param>
        public static void InsertData(string keyword, int typeId)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "insert into Site_Search(Keyword,IPAddress,Browser,TypeID,Counts,Remark,CreateDate) values (@Keyword,@IPAddress,@Browser,@TypeID,@Counts,@Remark,@CreateDate)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Keyword", SqlDbType.NVarChar, 500));
                comm.Parameters["@Keyword"].Value = keyword;
                comm.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.VarChar, 20));
                comm.Parameters["@IPAddress"].Value = IP.Get();
                comm.Parameters.Add(new SqlParameter("@Browser", SqlDbType.VarChar, 20));
                comm.Parameters["@Browser"].Value = String.GetBrowserInfo();
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = typeId;
                comm.Parameters.Add(new SqlParameter("@Counts", SqlDbType.Int));
                comm.Parameters["@Counts"].Value = 0;
                comm.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 500));
                comm.Parameters["@Remark"].Value = string.Empty;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = DateTime.Now;
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
                string sql = "update Site_Search set Keyword=@Keyword,IPAddress=@IPAddress,Browser=@Browser,TypeID=@TypeID,Counts=@Counts,Remark=@Remark,CreateDate=@CreateDate where pk_Search=@pk_Search";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Keyword", SqlDbType.NVarChar, 500));
                comm.Parameters["@Keyword"].Value = _Keyword;
                comm.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.VarChar, 20));
                comm.Parameters["@IPAddress"].Value = _IPAddress;
                comm.Parameters.Add(new SqlParameter("@Browser", SqlDbType.VarChar, 20));
                comm.Parameters["@Browser"].Value = _Browser;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Counts", SqlDbType.Int));
                comm.Parameters["@Counts"].Value = _Counts;
                comm.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 500));
                comm.Parameters["@Remark"].Value = _Remark;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@pk_Search", SqlDbType.Int));
                comm.Parameters["@pk_Search"].Value = id;
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
            Sql.SqlQuery("delete from Site_Search where pk_Search=" + id);
        }

        #endregion
    }
}
