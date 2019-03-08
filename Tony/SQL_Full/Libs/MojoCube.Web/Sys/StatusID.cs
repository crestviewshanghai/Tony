using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Sys
{
    public class StatusID
    {
        #region 公共属性
        int _pk_StatusID;
        public int pk_StatusID
        {
            get { return _pk_StatusID; }
            set { _pk_StatusID = value; }
        }
        string _StatusName_CHS;
        public string StatusName_CHS
        {
            get { return _StatusName_CHS; }
            set { _StatusName_CHS = value; }
        }
        string _StatusName_CHT;
        public string StatusName_CHT
        {
            get { return _StatusName_CHT; }
            set { _StatusName_CHT = value; }
        }
        string _StatusName_EN;
        public string StatusName_EN
        {
            get { return _StatusName_EN; }
            set { _StatusName_EN = value; }
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
        /// 获取状态名称
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="statusID">状态ID</param>
        /// <param name="language">语言</param>
        public static string GetStatusName(string tableName, string statusID, string language)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select Visual,StatusName_" + language + " from Sys_StatusID where TableName=@TableName and ID=@ID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@TableName", SqlDbType.VarChar, 20));
                comm.Parameters["@TableName"].Value = tableName;
                comm.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                comm.Parameters["@ID"].Value = int.Parse(statusID);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["Visual"].ToString().Trim() != "")
                    {
                        return ("<span style=\"font-size:9pt; color:#fff; padding:2px 4px; border-radius:3px; background-color:" + dr["Visual"].ToString() + "\">" + dr["StatusName_" + language].ToString() + "</span>");
                    }
                    else
                    {
                        return dr["StatusName_" + language].ToString();
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
                string sql = "select Description_" + language + " from Sys_StatusID where TableName=@TableName and ID=@ID";
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
                string sql = "select Visual from Sys_StatusID where TableName=@TableName and ID=@ID";
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
                string sql = "select * from Sys_StatusID where pk_StatusID=@pk_StatusID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_StatusID", SqlDbType.Int));
                comm.Parameters["@pk_StatusID"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_StatusID = Convert.ToInt32(dr["pk_StatusID"].ToString());
                    _StatusName_CHS = dr["StatusName_CHS"].ToString();
                    _StatusName_CHT = dr["StatusName_CHT"].ToString();
                    _StatusName_EN = dr["StatusName_EN"].ToString();
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
                string sql = "insert into Sys_StatusID(StatusName_CHS,StatusName_CHT,StatusName_EN,ID,Visual,TableName,Description_CHS,Description_CHT,Description_EN) values (@StatusName_CHS,@StatusName_CHT,@StatusName_EN,@ID,@Visual,@TableName,@Description_CHS,@Description_CHT,@Description_EN)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@StatusName_CHS", SqlDbType.NVarChar, 20));
                comm.Parameters["@StatusName_CHS"].Value = _StatusName_CHS;
                comm.Parameters.Add(new SqlParameter("@StatusName_CHT", SqlDbType.NVarChar, 20));
                comm.Parameters["@StatusName_CHT"].Value = _StatusName_CHT;
                comm.Parameters.Add(new SqlParameter("@StatusName_EN", SqlDbType.NVarChar, 20));
                comm.Parameters["@StatusName_EN"].Value = _StatusName_EN;
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
                string sql = "update Sys_StatusID set StatusName_CHS=@StatusName_CHS,StatusName_CHT=@StatusName_CHT,StatusName_EN=@StatusName_EN,ID=@ID,Visual=@Visual,TableName=@TableName,Description_CHS=@Description_CHS,Description_CHT=@Description_CHT,Description_EN=@Description_EN where pk_StatusID=@pk_StatusID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@StatusName_CHS", SqlDbType.NVarChar, 20));
                comm.Parameters["@StatusName_CHS"].Value = _StatusName_CHS;
                comm.Parameters.Add(new SqlParameter("@StatusName_CHT", SqlDbType.NVarChar, 20));
                comm.Parameters["@StatusName_CHT"].Value = _StatusName_CHT;
                comm.Parameters.Add(new SqlParameter("@StatusName_EN", SqlDbType.NVarChar, 20));
                comm.Parameters["@StatusName_EN"].Value = _StatusName_EN;
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
                comm.Parameters.Add(new SqlParameter("@pk_StatusID", SqlDbType.Int));
                comm.Parameters["@pk_StatusID"].Value = id;
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
            Sql.SqlQuery("delete from Sys_StatusID where pk_StatusID=" + id);
        }

        #endregion
    }
}
