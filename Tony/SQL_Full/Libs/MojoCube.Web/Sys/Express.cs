using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Sys
{
    public class Express
    {
        #region 公共属性
        int _pk_Express;
        public int pk_Express
        {
            get { return _pk_Express; }
            set { _pk_Express = value; }
        }
        string _FullName;
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }
        string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set { _ShortName = value; }
        }
        string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }
        string _Website;
        public string Website
        {
            get { return _Website; }
            set { _Website = value; }
        }
        string _Url;
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        decimal _Freight;
        public decimal Freight
        {
            get { return _Freight; }
            set { _Freight = value; }
        }
        bool _Visible;
        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
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
                string sql = "select * from Sys_Express where pk_Express=@pk_Express";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Express", SqlDbType.Int));
                comm.Parameters["@pk_Express"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Express = Convert.ToInt32(dr["pk_Express"].ToString());
                    _FullName = dr["FullName"].ToString();
                    _ShortName = dr["ShortName"].ToString();
                    _ImagePath = dr["ImagePath"].ToString();
                    _Website = dr["Website"].ToString();
                    _Url = dr["Url"].ToString();
                    _Freight = Convert.ToDecimal(dr["Freight"].ToString());
                    _Visible = Convert.ToBoolean(dr["Visible"].ToString());
                }
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获取字段值
        /// </summary>
        /// <param name="code">快递公司代码</param>
        public void GetData(string code)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Sys_Express where ShortName=@ShortName";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@ShortName", SqlDbType.NVarChar, 10));
                comm.Parameters["@ShortName"].Value = code;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Express = Convert.ToInt32(dr["pk_Express"].ToString());
                    _FullName = dr["FullName"].ToString();
                    _ShortName = dr["ShortName"].ToString();
                    _ImagePath = dr["ImagePath"].ToString();
                    _Website = dr["Website"].ToString();
                    _Url = dr["Url"].ToString();
                    _Freight = Convert.ToDecimal(dr["Freight"].ToString());
                    _Visible = Convert.ToBoolean(dr["Visible"].ToString());
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
                string sql = "insert into Sys_Express(FullName,ShortName,ImagePath,Website,Url,Freight,Visible) values (@FullName,@ShortName,@ImagePath,@Website,@Url,@Freight,@Visible)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@FullName", SqlDbType.NVarChar, 100));
                comm.Parameters["@FullName"].Value = _FullName;
                comm.Parameters.Add(new SqlParameter("@ShortName", SqlDbType.NVarChar, 10));
                comm.Parameters["@ShortName"].Value = _ShortName;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;
                comm.Parameters.Add(new SqlParameter("@Website", SqlDbType.NVarChar, 100));
                comm.Parameters["@Website"].Value = _Website;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@Freight", SqlDbType.Money));
                comm.Parameters["@Freight"].Value = _Freight;
                comm.Parameters.Add(new SqlParameter("@Visible", SqlDbType.Bit));
                comm.Parameters["@Visible"].Value = _Visible;
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
                string sql = "update Sys_Express set FullName=@FullName,ShortName=@ShortName,ImagePath=@ImagePath,Website=@Website,Url=@Url,Freight=@Freight,Visible=@Visible where pk_Express=@pk_Express";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@FullName", SqlDbType.NVarChar, 100));
                comm.Parameters["@FullName"].Value = _FullName;
                comm.Parameters.Add(new SqlParameter("@ShortName", SqlDbType.NVarChar, 10));
                comm.Parameters["@ShortName"].Value = _ShortName;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;
                comm.Parameters.Add(new SqlParameter("@Website", SqlDbType.NVarChar, 100));
                comm.Parameters["@Website"].Value = _Website;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@Freight", SqlDbType.Money));
                comm.Parameters["@Freight"].Value = _Freight;
                comm.Parameters.Add(new SqlParameter("@Visible", SqlDbType.Bit));
                comm.Parameters["@Visible"].Value = _Visible;
                comm.Parameters.Add(new SqlParameter("@pk_Express", SqlDbType.Int));
                comm.Parameters["@pk_Express"].Value = id;
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
            Sql.SqlQuery("delete from Sys_Express where pk_Express=" + id);
        }

        #endregion
    }
}
