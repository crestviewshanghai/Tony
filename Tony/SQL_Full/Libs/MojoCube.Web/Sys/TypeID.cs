using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Sys
{
    public class TypeID
    {
        #region 公共属性
        int _pk_TypeID;
        public int pk_TypeID
        {
            get { return _pk_TypeID; }
            set { _pk_TypeID = value; }
        }
        string _TypeName_CHS;
        public string TypeName_CHS
        {
            get { return _TypeName_CHS; }
            set { _TypeName_CHS = value; }
        }
        string _TypeName_CHT;
        public string TypeName_CHT
        {
            get { return _TypeName_CHT; }
            set { _TypeName_CHT = value; }
        }
        string _TypeName_EN;
        public string TypeName_EN
        {
            get { return _TypeName_EN; }
            set { _TypeName_EN = value; }
        }
        int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        string _Visual;
        public string Visual
        {
            get { return _Visual; }
            set { _Visual = value; }
        }
        string _TableName;
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
        string _Description_CHS;
        public string Description_CHS
        {
            get { return _Description_CHS; }
            set { _Description_CHS = value; }
        }
        string _Description_CHT;
        public string Description_CHT
        {
            get { return _Description_CHT; }
            set { _Description_CHT = value; }
        }
        string _Description_EN;
        public string Description_EN
        {
            get { return _Description_EN; }
            set { _Description_EN = value; }
        }
        #endregion

        #region 公共方法

        /// <summary>
        /// 获取类型名称
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="typeID">类型ID</param>
        /// <param name="language">语言</param>
        public static string GetTypeName(string tableName, string typeID, string language)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select Visual,TypeName_" + language + " from Sys_TypeID where TableName=@TableName and ID=@ID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@TableName", SqlDbType.VarChar, 20));
                comm.Parameters["@TableName"].Value = tableName;
                comm.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                comm.Parameters["@ID"].Value = int.Parse(typeID);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["Visual"].ToString().Trim() != "")
                    {
                        return ("<span style=\"color:" + dr["Visual"].ToString() + "\">" + dr["TypeName_" + language].ToString() + "</span>");
                    }
                    else
                    {
                        return dr["TypeName_" + language].ToString();
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获取描述内容
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="typeID">类型ID</param>
        /// <param name="language">语言</param>
        /// <returns></returns>
        public static string GetDescription(string tableName, string typeID, string language)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select Description_" + language + " from Sys_TypeID where TableName=@TableName and ID=@ID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@TableName", SqlDbType.VarChar, 20));
                comm.Parameters["@TableName"].Value = tableName;
                comm.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                comm.Parameters["@ID"].Value = int.Parse(typeID);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    return dr["Description_" + language].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获取视觉效果
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="typeID">类型ID</param>
        /// <returns></returns>
        public static string GetVisual(string tableName, string typeID)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select Visual from Sys_TypeID where TableName=@TableName and ID=@ID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@TableName", SqlDbType.VarChar, 20));
                comm.Parameters["@TableName"].Value = tableName;
                comm.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                comm.Parameters["@ID"].Value = int.Parse(typeID);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    return dr["Visual"].ToString();
                }
                else
                {
                    return string.Empty;
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
        /// <param name="id">ID</param>
        public void GetData(int id)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Sys_TypeID where pk_TypeID=@pk_TypeID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_TypeID", SqlDbType.Int));
                comm.Parameters["@pk_TypeID"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_TypeID = Convert.ToInt32(dr["pk_TypeID"].ToString());
                    _TypeName_CHS = dr["TypeName_CHS"].ToString();
                    _TypeName_CHT = dr["TypeName_CHT"].ToString();
                    _TypeName_EN = dr["TypeName_EN"].ToString();
                    _ID = Convert.ToInt32(dr["ID"].ToString());
                    _Visual = dr["Visual"].ToString();
                    _TableName = dr["TableName"].ToString();
                    _Description_CHS = dr["Description_CHS"].ToString();
                    _Description_CHT = dr["Description_CHT"].ToString();
                    _Description_EN = dr["Description_EN"].ToString();
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
                string sql = "insert into Sys_TypeID(TypeName_CHS,TypeName_CHT,TypeName_EN,ID,Visual,TableName,Description_CHS,Description_CHT,Description_EN) values (@TypeName_CHS,@TypeName_CHT,@TypeName_EN,@ID,@Visual,@TableName,@Description_CHS,@Description_CHT,@Description_EN)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@TypeName_CHS", SqlDbType.NVarChar, 20));
                comm.Parameters["@TypeName_CHS"].Value = _TypeName_CHS;
                comm.Parameters.Add(new SqlParameter("@TypeName_CHT", SqlDbType.NVarChar, 20));
                comm.Parameters["@TypeName_CHT"].Value = _TypeName_CHT;
                comm.Parameters.Add(new SqlParameter("@TypeName_EN", SqlDbType.NVarChar, 20));
                comm.Parameters["@TypeName_EN"].Value = _TypeName_EN;
                comm.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                comm.Parameters["@ID"].Value = _ID;
                comm.Parameters.Add(new SqlParameter("@Visual", SqlDbType.VarChar, 10));
                comm.Parameters["@Visual"].Value = _Visual;
                comm.Parameters.Add(new SqlParameter("@TableName", SqlDbType.VarChar, 20));
                comm.Parameters["@TableName"].Value = _TableName;
                comm.Parameters.Add(new SqlParameter("@Description_CHS", SqlDbType.NVarChar, 1000));
                comm.Parameters["@Description_CHS"].Value = _Description_CHS;
                comm.Parameters.Add(new SqlParameter("@Description_CHT", SqlDbType.NVarChar, 1000));
                comm.Parameters["@Description_CHT"].Value = _Description_CHT;
                comm.Parameters.Add(new SqlParameter("@Description_EN", SqlDbType.NVarChar, 1000));
                comm.Parameters["@Description_EN"].Value = _Description_EN;
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
                string sql = "update Sys_TypeID set TypeName_CHS=@TypeName_CHS,TypeName_CHT=@TypeName_CHT,TypeName_EN=@TypeName_EN,ID=@ID,Visual=@Visual,TableName=@TableName,Description_CHS=@Description_CHS,Description_CHT=@Description_CHT,Description_EN=@Description_EN where pk_TypeID=@pk_TypeID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@TypeName_CHS", SqlDbType.NVarChar, 20));
                comm.Parameters["@TypeName_CHS"].Value = _TypeName_CHS;
                comm.Parameters.Add(new SqlParameter("@TypeName_CHT", SqlDbType.NVarChar, 20));
                comm.Parameters["@TypeName_CHT"].Value = _TypeName_CHT;
                comm.Parameters.Add(new SqlParameter("@TypeName_EN", SqlDbType.NVarChar, 20));
                comm.Parameters["@TypeName_EN"].Value = _TypeName_EN;
                comm.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                comm.Parameters["@ID"].Value = _ID;
                comm.Parameters.Add(new SqlParameter("@Visual", SqlDbType.VarChar, 10));
                comm.Parameters["@Visual"].Value = _Visual;
                comm.Parameters.Add(new SqlParameter("@TableName", SqlDbType.VarChar, 20));
                comm.Parameters["@TableName"].Value = _TableName;
                comm.Parameters.Add(new SqlParameter("@Description_CHS", SqlDbType.NVarChar, 1000));
                comm.Parameters["@Description_CHS"].Value = _Description_CHS;
                comm.Parameters.Add(new SqlParameter("@Description_CHT", SqlDbType.NVarChar, 1000));
                comm.Parameters["@Description_CHT"].Value = _Description_CHT;
                comm.Parameters.Add(new SqlParameter("@Description_EN", SqlDbType.NVarChar, 1000));
                comm.Parameters["@Description_EN"].Value = _Description_EN;
                comm.Parameters.Add(new SqlParameter("@pk_TypeID", SqlDbType.Int));
                comm.Parameters["@pk_TypeID"].Value = id;
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
            Sql.SqlQuery("delete from Sys_TypeID where pk_TypeID=" + id);
        }

        #endregion
    }
}
