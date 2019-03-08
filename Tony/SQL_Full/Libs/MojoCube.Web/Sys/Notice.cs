using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Sys
{
    public class Notice
    {
        #region 公共属性
        int _pk_Notice;
        public int pk_Notice
        {
            get { return _pk_Notice; }
            set { _pk_Notice = value; }
        }
        int _TypeID;
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        int _StatusID;
        public int StatusID
        {
            get { return _StatusID; }
            set { _StatusID = value; }
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
        int _RoleValue;
        public int RoleValue
        {
            get { return _RoleValue; }
            set { _RoleValue = value; }
        }
        string _Url;
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        int _CreateUser;
        public int CreateUser
        {
            get { return _CreateUser; }
            set { _CreateUser = value; }
        }
        string _CreateDate;
        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        int _ModifyUser;
        public int ModifyUser
        {
            get { return _ModifyUser; }
            set { _ModifyUser = value; }
        }
        string _ModifyDate;
        public string ModifyDate
        {
            get { return _ModifyDate; }
            set { _ModifyDate = value; }
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
                string sql = "select * from Sys_Notice where pk_Notice=@pk_Notice";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Notice", SqlDbType.Int));
                comm.Parameters["@pk_Notice"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Notice = Convert.ToInt32(dr["pk_Notice"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _StatusID = Convert.ToInt32(dr["StatusID"].ToString());
                    _Title = dr["Title"].ToString();
                    _Description = dr["Description"].ToString();
                    _RoleValue = Convert.ToInt32(dr["RoleValue"].ToString());
                    _Url = dr["Url"].ToString();
                    _CreateUser = Convert.ToInt32(dr["CreateUser"].ToString());
                    _CreateDate = dr["CreateDate"].ToString();
                    _ModifyUser = Convert.ToInt32(dr["ModifyUser"].ToString());
                    _ModifyDate = dr["ModifyDate"].ToString();
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
                string sql = "insert into Sys_Notice(TypeID,StatusID,Title,Description,RoleValue,Url,CreateUser,CreateDate,ModifyUser,ModifyDate) values (@TypeID,@StatusID,@Title,@Description,@RoleValue,@Url,@CreateUser,@CreateDate,@ModifyUser,@ModifyDate)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@RoleValue", SqlDbType.Int));
                comm.Parameters["@RoleValue"].Value = _RoleValue;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@CreateUser", SqlDbType.Int));
                comm.Parameters["@CreateUser"].Value = _CreateUser;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@ModifyUser", SqlDbType.Int));
                comm.Parameters["@ModifyUser"].Value = _ModifyUser;
                comm.Parameters.Add(new SqlParameter("@ModifyDate", SqlDbType.DateTime));
                comm.Parameters["@ModifyDate"].Value = _ModifyDate;
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
                string sql = "update Sys_Notice set TypeID=@TypeID,StatusID=@StatusID,Title=@Title,Description=@Description,RoleValue=@RoleValue,Url=@Url,CreateUser=@CreateUser,CreateDate=@CreateDate,ModifyUser=@ModifyUser,ModifyDate=@ModifyDate where pk_Notice=@pk_Notice";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@RoleValue", SqlDbType.Int));
                comm.Parameters["@RoleValue"].Value = _RoleValue;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@CreateUser", SqlDbType.Int));
                comm.Parameters["@CreateUser"].Value = _CreateUser;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@ModifyUser", SqlDbType.Int));
                comm.Parameters["@ModifyUser"].Value = _ModifyUser;
                comm.Parameters.Add(new SqlParameter("@ModifyDate", SqlDbType.DateTime));
                comm.Parameters["@ModifyDate"].Value = _ModifyDate;
                comm.Parameters.Add(new SqlParameter("@pk_Notice", SqlDbType.Int));
                comm.Parameters["@pk_Notice"].Value = id;
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
            Sql.SqlQuery("delete from Sys_Notice where pk_Notice=" + id);
        }

        #endregion
    }
}
