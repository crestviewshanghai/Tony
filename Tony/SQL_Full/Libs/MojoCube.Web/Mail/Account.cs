using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Mail
{
    public class Account
    {
        #region 公共属性
        int _pk_Account;
        public int pk_Account
        {
            get { return _pk_Account; }
            set { _pk_Account = value; }
        }
        string _AccountName;
        public string AccountName
        {
            get { return _AccountName; }
            set { _AccountName = value; }
        }
        string _DisplayName;
        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }
        string _PopHost;
        public string PopHost
        {
            get { return _PopHost; }
            set { _PopHost = value; }
        }
        int _Port;
        public int Port
        {
            get { return _Port; }
            set { _Port = value; }
        }
        bool _UseSSL;
        public bool UseSSL
        {
            get { return _UseSSL; }
            set { _UseSSL = value; }
        }
        string _SmtpHost;
        public string SmtpHost
        {
            get { return _SmtpHost; }
            set { _SmtpHost = value; }
        }
        int _SmtpPort;
        public int SmtpPort
        {
            get { return _SmtpPort; }
            set { _SmtpPort = value; }
        }
        string _LoginName;
        public string LoginName
        {
            get { return _LoginName; }
            set { _LoginName = value; }
        }
        string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        string _SmtpPwd;
        public string SmtpPwd
        {
            get { return _SmtpPwd; }
            set { _SmtpPwd = value; }
        }
        string _SmtpUser;
        public string SmtpUser
        {
            get { return _SmtpUser; }
            set { _SmtpUser = value; }
        }
        bool _SmtpUseSSL;
        public bool SmtpUseSSL
        {
            get { return _SmtpUseSSL; }
            set { _SmtpUseSSL = value; }
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
        string _Signature;
        public string Signature
        {
            get { return _Signature; }
            set { _Signature = value; }
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
                string sql = "select * from Mail_Account where pk_Account=@pk_Account";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Account", SqlDbType.Int));
                comm.Parameters["@pk_Account"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Account = Convert.ToInt32(dr["pk_Account"].ToString());
                    _AccountName = dr["AccountName"].ToString();
                    _DisplayName = dr["DisplayName"].ToString();
                    _PopHost = dr["PopHost"].ToString();
                    _Port = Convert.ToInt32(dr["Port"].ToString());
                    _UseSSL = Convert.ToBoolean(dr["UseSSL"].ToString());
                    _SmtpHost = dr["SmtpHost"].ToString();
                    _SmtpPort = Convert.ToInt32(dr["SmtpPort"].ToString());
                    _LoginName = dr["LoginName"].ToString();
                    _Password = dr["Password"].ToString();
                    _SmtpPwd = dr["SmtpPwd"].ToString();
                    _SmtpUser = dr["SmtpUser"].ToString();
                    _SmtpUseSSL = Convert.ToBoolean(dr["SmtpUseSSL"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _StatusID = Convert.ToInt32(dr["StatusID"].ToString());
                    _Signature = dr["Signature"].ToString();
                    _Remark = dr["Remark"].ToString();
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
        /// 根据Type ID获取字段值
        /// </summary>
        /// <param name="typeID">Type ID</param>
        public void GetDataTypeID(int typeID)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Mail_Account where TypeID=@TypeID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = typeID;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Account = Convert.ToInt32(dr["pk_Account"].ToString());
                    _AccountName = dr["AccountName"].ToString();
                    _DisplayName = dr["DisplayName"].ToString();
                    _PopHost = dr["PopHost"].ToString();
                    _Port = Convert.ToInt32(dr["Port"].ToString());
                    _UseSSL = Convert.ToBoolean(dr["UseSSL"].ToString());
                    _SmtpHost = dr["SmtpHost"].ToString();
                    _SmtpPort = Convert.ToInt32(dr["SmtpPort"].ToString());
                    _LoginName = dr["LoginName"].ToString();
                    _Password = dr["Password"].ToString();
                    _SmtpPwd = dr["SmtpPwd"].ToString();
                    _SmtpUser = dr["SmtpUser"].ToString();
                    _SmtpUseSSL = Convert.ToBoolean(dr["SmtpUseSSL"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _StatusID = Convert.ToInt32(dr["StatusID"].ToString());
                    _Signature = dr["Signature"].ToString();
                    _Remark = dr["Remark"].ToString();
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
                string sql = "insert into Mail_Account(AccountName,DisplayName,PopHost,Port,UseSSL,SmtpHost,SmtpPort,LoginName,Password,SmtpPwd,SmtpUser,SmtpUseSSL,TypeID,StatusID,Signature,Remark,CreateDate,CreateUserID,ModifyDate,ModifyUserID) values (@AccountName,@DisplayName,@PopHost,@Port,@UseSSL,@SmtpHost,@SmtpPort,@LoginName,@Password,@SmtpPwd,@SmtpUser,@SmtpUseSSL,@TypeID,@StatusID,@Signature,@Remark,@CreateDate,@CreateUserID,@ModifyDate,@ModifyUserID)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@AccountName", SqlDbType.NVarChar, 100));
                comm.Parameters["@AccountName"].Value = _AccountName;
                comm.Parameters.Add(new SqlParameter("@DisplayName", SqlDbType.NVarChar, 50));
                comm.Parameters["@DisplayName"].Value = _DisplayName;
                comm.Parameters.Add(new SqlParameter("@PopHost", SqlDbType.VarChar, 100));
                comm.Parameters["@PopHost"].Value = _PopHost;
                comm.Parameters.Add(new SqlParameter("@Port", SqlDbType.Int));
                comm.Parameters["@Port"].Value = _Port;
                comm.Parameters.Add(new SqlParameter("@UseSSL", SqlDbType.Bit));
                comm.Parameters["@UseSSL"].Value = _UseSSL;
                comm.Parameters.Add(new SqlParameter("@SmtpHost", SqlDbType.VarChar, 100));
                comm.Parameters["@SmtpHost"].Value = _SmtpHost;
                comm.Parameters.Add(new SqlParameter("@SmtpPort", SqlDbType.Int));
                comm.Parameters["@SmtpPort"].Value = _SmtpPort;
                comm.Parameters.Add(new SqlParameter("@LoginName", SqlDbType.VarChar, 100));
                comm.Parameters["@LoginName"].Value = _LoginName;
                comm.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 100));
                comm.Parameters["@Password"].Value = _Password;
                comm.Parameters.Add(new SqlParameter("@SmtpPwd", SqlDbType.VarChar, 100));
                comm.Parameters["@SmtpPwd"].Value = _SmtpPwd;
                comm.Parameters.Add(new SqlParameter("@SmtpUser", SqlDbType.VarChar, 100));
                comm.Parameters["@SmtpUser"].Value = _SmtpUser;
                comm.Parameters.Add(new SqlParameter("@SmtpUseSSL", SqlDbType.Bit));
                comm.Parameters["@SmtpUseSSL"].Value = _SmtpUseSSL;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@Signature", SqlDbType.NVarChar, 1000));
                comm.Parameters["@Signature"].Value = _Signature;
                comm.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 500));
                comm.Parameters["@Remark"].Value = _Remark;
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
                string sql = "update Mail_Account set AccountName=@AccountName,DisplayName=@DisplayName,PopHost=@PopHost,Port=@Port,UseSSL=@UseSSL,SmtpHost=@SmtpHost,SmtpPort=@SmtpPort,LoginName=@LoginName,Password=@Password,SmtpPwd=@SmtpPwd,SmtpUser=@SmtpUser,SmtpUseSSL=@SmtpUseSSL,TypeID=@TypeID,StatusID=@StatusID,Signature=@Signature,Remark=@Remark,CreateDate=@CreateDate,CreateUserID=@CreateUserID,ModifyDate=@ModifyDate,ModifyUserID=@ModifyUserID where pk_Account=@pk_Account";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@AccountName", SqlDbType.NVarChar, 100));
                comm.Parameters["@AccountName"].Value = _AccountName;
                comm.Parameters.Add(new SqlParameter("@DisplayName", SqlDbType.NVarChar, 50));
                comm.Parameters["@DisplayName"].Value = _DisplayName;
                comm.Parameters.Add(new SqlParameter("@PopHost", SqlDbType.VarChar, 100));
                comm.Parameters["@PopHost"].Value = _PopHost;
                comm.Parameters.Add(new SqlParameter("@Port", SqlDbType.Int));
                comm.Parameters["@Port"].Value = _Port;
                comm.Parameters.Add(new SqlParameter("@UseSSL", SqlDbType.Bit));
                comm.Parameters["@UseSSL"].Value = _UseSSL;
                comm.Parameters.Add(new SqlParameter("@SmtpHost", SqlDbType.VarChar, 100));
                comm.Parameters["@SmtpHost"].Value = _SmtpHost;
                comm.Parameters.Add(new SqlParameter("@SmtpPort", SqlDbType.Int));
                comm.Parameters["@SmtpPort"].Value = _SmtpPort;
                comm.Parameters.Add(new SqlParameter("@LoginName", SqlDbType.VarChar, 100));
                comm.Parameters["@LoginName"].Value = _LoginName;
                comm.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 100));
                comm.Parameters["@Password"].Value = _Password;
                comm.Parameters.Add(new SqlParameter("@SmtpPwd", SqlDbType.VarChar, 100));
                comm.Parameters["@SmtpPwd"].Value = _SmtpPwd;
                comm.Parameters.Add(new SqlParameter("@SmtpUser", SqlDbType.VarChar, 100));
                comm.Parameters["@SmtpUser"].Value = _SmtpUser;
                comm.Parameters.Add(new SqlParameter("@SmtpUseSSL", SqlDbType.Bit));
                comm.Parameters["@SmtpUseSSL"].Value = _SmtpUseSSL;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@Signature", SqlDbType.NVarChar, 1000));
                comm.Parameters["@Signature"].Value = _Signature;
                comm.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 500));
                comm.Parameters["@Remark"].Value = _Remark;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@CreateUserID", SqlDbType.Int));
                comm.Parameters["@CreateUserID"].Value = _CreateUserID;
                comm.Parameters.Add(new SqlParameter("@ModifyDate", SqlDbType.DateTime));
                comm.Parameters["@ModifyDate"].Value = _ModifyDate;
                comm.Parameters.Add(new SqlParameter("@ModifyUserID", SqlDbType.Int));
                comm.Parameters["@ModifyUserID"].Value = _ModifyUserID;
                comm.Parameters.Add(new SqlParameter("@pk_Account", SqlDbType.Int));
                comm.Parameters["@pk_Account"].Value = id;
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
            Sql.SqlQuery("delete from Mail_Account where pk_Account=" + id);
        }

        #endregion
    }
}
