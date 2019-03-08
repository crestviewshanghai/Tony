using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Role
{
    public class Name
    {
        #region 公共属性
        int _pk_Name;
        public int pk_Name
        {
            get { return _pk_Name; }
            set { _pk_Name = value; }
        }
        string _RoleName_CHS;
        public string RoleName_CHS
        {
            get { return _RoleName_CHS; }
            set { _RoleName_CHS = value; }
        }
        string _RoleName_CHT;
        public string RoleName_CHT
        {
            get { return _RoleName_CHT; }
            set { _RoleName_CHT = value; }
        }
        string _RoleName_EN;
        public string RoleName_EN
        {
            get { return _RoleName_EN; }
            set { _RoleName_EN = value; }
        }
        int _PowerValue;
        public int PowerValue
        {
            get { return _PowerValue; }
            set { _PowerValue = value; }
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
                string sql = "select * from Role_Name where pk_Name=@pk_Name";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Name", SqlDbType.Int));
                comm.Parameters["@pk_Name"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Name = Convert.ToInt32(dr["pk_Name"].ToString());
                    _RoleName_CHS = dr["RoleName_CHS"].ToString();
                    _RoleName_CHT = dr["RoleName_CHT"].ToString();
                    _RoleName_EN = dr["RoleName_EN"].ToString();
                    _PowerValue = Convert.ToInt32(dr["PowerValue"].ToString());
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
                string sql = "insert into Role_Name(RoleName_CHS,RoleName_CHT,RoleName_EN,PowerValue,fk_Company) values (@RoleName_CHS,@RoleName_CHT,@RoleName_EN,@PowerValue,@fk_Company)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@RoleName_CHS", SqlDbType.NVarChar, 50));
                comm.Parameters["@RoleName_CHS"].Value = _RoleName_CHS;
                comm.Parameters.Add(new SqlParameter("@RoleName_CHT", SqlDbType.NVarChar, 50));
                comm.Parameters["@RoleName_CHT"].Value = _RoleName_CHT;
                comm.Parameters.Add(new SqlParameter("@RoleName_EN", SqlDbType.NVarChar, 50));
                comm.Parameters["@RoleName_EN"].Value = _RoleName_EN;
                comm.Parameters.Add(new SqlParameter("@PowerValue", SqlDbType.Int));
                comm.Parameters["@PowerValue"].Value = _PowerValue;
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
        /// 修改数据
        /// </summary>
        /// <param name="id">ID</param>
        public void UpdateData(int id)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update Role_Name set RoleName_CHS=@RoleName_CHS,RoleName_CHT=@RoleName_CHT,RoleName_EN=@RoleName_EN,PowerValue=@PowerValue,fk_Company=@fk_Company where pk_Name=@pk_Name";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@RoleName_CHS", SqlDbType.NVarChar, 50));
                comm.Parameters["@RoleName_CHS"].Value = _RoleName_CHS;
                comm.Parameters.Add(new SqlParameter("@RoleName_CHT", SqlDbType.NVarChar, 50));
                comm.Parameters["@RoleName_CHT"].Value = _RoleName_CHT;
                comm.Parameters.Add(new SqlParameter("@RoleName_EN", SqlDbType.NVarChar, 50));
                comm.Parameters["@RoleName_EN"].Value = _RoleName_EN;
                comm.Parameters.Add(new SqlParameter("@PowerValue", SqlDbType.Int));
                comm.Parameters["@PowerValue"].Value = _PowerValue;
                comm.Parameters.Add(new SqlParameter("@fk_Company", SqlDbType.Int));
                comm.Parameters["@fk_Company"].Value = _fk_Company;
                comm.Parameters.Add(new SqlParameter("@pk_Name", SqlDbType.Int));
                comm.Parameters["@pk_Name"].Value = id;
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
            Sql.SqlQuery("delete from Role_Name where pk_Name=" + id);
        }

        #endregion
    }
}
