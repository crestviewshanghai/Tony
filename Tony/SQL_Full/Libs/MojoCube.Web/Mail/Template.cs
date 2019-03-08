using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Mail
{
    public class Template
    {
        #region 公共属性
        int _pk_Template;
        public int pk_Template
        {
            get { return _pk_Template; }
            set { _pk_Template = value; }
        }
        int _fk_Account;
        public int fk_Account
        {
            get { return _fk_Account; }
            set { _fk_Account = value; }
        }
        string _TemplateName;
        public string TemplateName
        {
            get { return _TemplateName; }
            set { _TemplateName = value; }
        }
        string _Subject;
        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }
        string _Contents;
        public string Contents
        {
            get { return _Contents; }
            set { _Contents = value; }
        }
        string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        string _CreateDate;
        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        int _CreateUserID;
        public int CreateUserID
        {
            get { return _CreateUserID; }
            set { _CreateUserID = value; }
        }
        string _ModifyDate;
        public string ModifyDate
        {
            get { return _ModifyDate; }
            set { _ModifyDate = value; }
        }
        int _ModifyUserID;
        public int ModifyUserID
        {
            get { return _ModifyUserID; }
            set { _ModifyUserID = value; }
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
                string sql = "select * from Mail_Template where pk_Template=@pk_Template";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Template", SqlDbType.Int));
                comm.Parameters["@pk_Template"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Template = Convert.ToInt32(dr["pk_Template"].ToString());
                    _fk_Account = Convert.ToInt32(dr["fk_Account"].ToString());
                    _TemplateName = dr["TemplateName"].ToString();
                    _Subject = dr["Subject"].ToString();
                    _Contents = dr["Contents"].ToString();
                    _Description = dr["Description"].ToString();
                    _CreateDate = dr["CreateDate"].ToString();
                    _CreateUserID = Convert.ToInt32(dr["CreateUserID"].ToString());
                    _ModifyDate = dr["ModifyDate"].ToString();
                    if (dr["ModifyUserID"] != DBNull.Value)
                    {
                        _ModifyUserID = Convert.ToInt32(dr["ModifyUserID"].ToString());
                    }
                    else
                    {
                        _ModifyUserID = 0;
                    }
                }
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 根据Account ID获取字段值
        /// </summary>
        /// <param name="accountID">Account ID</param>
        public void GetDataAccountID(int accountID)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Mail_Template where fk_Account=@fk_Account";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Account", SqlDbType.Int));
                comm.Parameters["@fk_Account"].Value = accountID;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Template = Convert.ToInt32(dr["pk_Template"].ToString());
                    _fk_Account = Convert.ToInt32(dr["fk_Account"].ToString());
                    _TemplateName = dr["TemplateName"].ToString();
                    _Subject = dr["Subject"].ToString();
                    _Contents = dr["Contents"].ToString();
                    _Description = dr["Description"].ToString();
                    _CreateDate = dr["CreateDate"].ToString();
                    _CreateUserID = Convert.ToInt32(dr["CreateUserID"].ToString());
                    _ModifyDate = dr["ModifyDate"].ToString();
                    if (dr["ModifyUserID"] != DBNull.Value)
                    {
                        _ModifyUserID = Convert.ToInt32(dr["ModifyUserID"].ToString());
                    }
                    else
                    {
                        _ModifyUserID = 0;
                    }
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
                string sql = "insert into Mail_Template(fk_Account,TemplateName,Subject,Contents,Description,CreateDate,CreateUserID,ModifyDate,ModifyUserID) values (@fk_Account,@TemplateName,@Subject,@Contents,@Description,@CreateDate,@CreateUserID,@ModifyDate,@ModifyUserID)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Account", SqlDbType.Int));
                comm.Parameters["@fk_Account"].Value = _fk_Account;
                comm.Parameters.Add(new SqlParameter("@TemplateName", SqlDbType.NVarChar, 100));
                comm.Parameters["@TemplateName"].Value = _TemplateName;
                comm.Parameters.Add(new SqlParameter("@Subject", SqlDbType.NVarChar, 200));
                comm.Parameters["@Subject"].Value = _Subject;
                comm.Parameters.Add(new SqlParameter("@Contents", SqlDbType.NVarChar, -1));
                comm.Parameters["@Contents"].Value = _Contents;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@CreateUserID", SqlDbType.Int));
                comm.Parameters["@CreateUserID"].Value = _CreateUserID;
                comm.Parameters.Add(new SqlParameter("@ModifyDate", SqlDbType.DateTime));
                comm.Parameters["@ModifyDate"].Value = _ModifyDate;
                comm.Parameters.Add(new SqlParameter("@ModifyUserID", SqlDbType.Int));
                comm.Parameters["@ModifyUserID"].Value = _ModifyUserID;
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
                string sql = "update Mail_Template set fk_Account=@fk_Account,TemplateName=@TemplateName,Subject=@Subject,Contents=@Contents,Description=@Description,CreateDate=@CreateDate,CreateUserID=@CreateUserID,ModifyDate=@ModifyDate,ModifyUserID=@ModifyUserID where pk_Template=@pk_Template";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Account", SqlDbType.Int));
                comm.Parameters["@fk_Account"].Value = _fk_Account;
                comm.Parameters.Add(new SqlParameter("@TemplateName", SqlDbType.NVarChar, 100));
                comm.Parameters["@TemplateName"].Value = _TemplateName;
                comm.Parameters.Add(new SqlParameter("@Subject", SqlDbType.NVarChar, 200));
                comm.Parameters["@Subject"].Value = _Subject;
                comm.Parameters.Add(new SqlParameter("@Contents", SqlDbType.NVarChar, -1));
                comm.Parameters["@Contents"].Value = _Contents;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@CreateUserID", SqlDbType.Int));
                comm.Parameters["@CreateUserID"].Value = _CreateUserID;
                comm.Parameters.Add(new SqlParameter("@ModifyDate", SqlDbType.DateTime));
                comm.Parameters["@ModifyDate"].Value = _ModifyDate;
                comm.Parameters.Add(new SqlParameter("@ModifyUserID", SqlDbType.Int));
                comm.Parameters["@ModifyUserID"].Value = _ModifyUserID;
                comm.Parameters.Add(new SqlParameter("@pk_Template", SqlDbType.Int));
                comm.Parameters["@pk_Template"].Value = id;
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
            Sql.SqlQuery("delete from Mail_Template where pk_Template=" + id);
        }

        #endregion
    }
}
