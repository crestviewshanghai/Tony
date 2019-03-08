using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Member
{
    public class Mail
    {
        #region 公共属性
        int _pk_Mail;
        public int pk_Mail
        {
            get { return _pk_Mail; }
            set { _pk_Mail = value; }
        }
        int _fk_Account;
        public int fk_Account
        {
            get { return _fk_Account; }
            set { _fk_Account = value; }
        }
        int _fk_Template;
        public int fk_Template
        {
            get { return _fk_Template; }
            set { _fk_Template = value; }
        }
        int _fk_Member;
        public int fk_Member
        {
            get { return _fk_Member; }
            set { _fk_Member = value; }
        }
        string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        string _CC;
        public string CC
        {
            get { return _CC; }
            set { _CC = value; }
        }
        string _Bcc;
        public string Bcc
        {
            get { return _Bcc; }
            set { _Bcc = value; }
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
        string _ReceiveName;
        public string ReceiveName
        {
            get { return _ReceiveName; }
            set { _ReceiveName = value; }
        }
        int _StatusID;
        public int StatusID
        {
            get { return _StatusID; }
            set { _StatusID = value; }
        }
        int _TypeID;
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        bool _IsSend;
        public bool IsSend
        {
            get { return _IsSend; }
            set { _IsSend = value; }
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
                string sql = "select * from Member_Mail where pk_Mail=@pk_Mail";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Mail", SqlDbType.Int));
                comm.Parameters["@pk_Mail"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Mail = Convert.ToInt32(dr["pk_Mail"].ToString());
                    _fk_Account = Convert.ToInt32(dr["fk_Account"].ToString());
                    _fk_Template = Convert.ToInt32(dr["fk_Template"].ToString());
                    _fk_Member = Convert.ToInt32(dr["fk_Member"].ToString());
                    _Email = dr["Email"].ToString();
                    _CC = dr["CC"].ToString();
                    _Bcc = dr["Bcc"].ToString();
                    _Subject = dr["Subject"].ToString();
                    _Contents = dr["Contents"].ToString();
                    _ReceiveName = dr["ReceiveName"].ToString();
                    _StatusID = Convert.ToInt32(dr["StatusID"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _IsSend = Convert.ToBoolean(dr["IsSend"].ToString());
                    _CreateDate = dr["CreateDate"].ToString();
                    _CreateUserID = Convert.ToInt32(dr["CreateUserID"].ToString());
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
                string sql = "insert into Member_Mail(fk_Account,fk_Template,fk_Member,Email,CC,Bcc,Subject,Contents,ReceiveName,StatusID,TypeID,IsSend,CreateDate,CreateUserID) values (@fk_Account,@fk_Template,@fk_Member,@Email,@CC,@Bcc,@Subject,@Contents,@ReceiveName,@StatusID,@TypeID,@IsSend,@CreateDate,@CreateUserID)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Account", SqlDbType.Int));
                comm.Parameters["@fk_Account"].Value = _fk_Account;
                comm.Parameters.Add(new SqlParameter("@fk_Template", SqlDbType.Int));
                comm.Parameters["@fk_Template"].Value = _fk_Template;
                comm.Parameters.Add(new SqlParameter("@fk_Member", SqlDbType.Int));
                comm.Parameters["@fk_Member"].Value = _fk_Member;
                comm.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 200));
                comm.Parameters["@Email"].Value = _Email;
                comm.Parameters.Add(new SqlParameter("@CC", SqlDbType.NVarChar, -1));
                comm.Parameters["@CC"].Value = _CC;
                comm.Parameters.Add(new SqlParameter("@Bcc", SqlDbType.NVarChar, -1));
                comm.Parameters["@Bcc"].Value = _Bcc;
                comm.Parameters.Add(new SqlParameter("@Subject", SqlDbType.NVarChar, 200));
                comm.Parameters["@Subject"].Value = _Subject;
                comm.Parameters.Add(new SqlParameter("@Contents", SqlDbType.NVarChar, -1));
                comm.Parameters["@Contents"].Value = _Contents;
                comm.Parameters.Add(new SqlParameter("@ReceiveName", SqlDbType.NVarChar, 50));
                comm.Parameters["@ReceiveName"].Value = _ReceiveName;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@IsSend", SqlDbType.Bit));
                comm.Parameters["@IsSend"].Value = _IsSend;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@CreateUserID", SqlDbType.Int));
                comm.Parameters["@CreateUserID"].Value = _CreateUserID;
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
                string sql = "update Member_Mail set fk_Account=@fk_Account,fk_Template=@fk_Template,fk_Member=@fk_Member,Email=@Email,CC=@CC,Bcc=@Bcc,Subject=@Subject,Contents=@Contents,ReceiveName=@ReceiveName,StatusID=@StatusID,TypeID=@TypeID,IsSend=@IsSend,CreateDate=@CreateDate,CreateUserID=@CreateUserID where pk_Mail=@pk_Mail";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Account", SqlDbType.Int));
                comm.Parameters["@fk_Account"].Value = _fk_Account;
                comm.Parameters.Add(new SqlParameter("@fk_Template", SqlDbType.Int));
                comm.Parameters["@fk_Template"].Value = _fk_Template;
                comm.Parameters.Add(new SqlParameter("@fk_Member", SqlDbType.Int));
                comm.Parameters["@fk_Member"].Value = _fk_Member;
                comm.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 200));
                comm.Parameters["@Email"].Value = _Email;
                comm.Parameters.Add(new SqlParameter("@CC", SqlDbType.NVarChar, -1));
                comm.Parameters["@CC"].Value = _CC;
                comm.Parameters.Add(new SqlParameter("@Bcc", SqlDbType.NVarChar, -1));
                comm.Parameters["@Bcc"].Value = _Bcc;
                comm.Parameters.Add(new SqlParameter("@Subject", SqlDbType.NVarChar, 200));
                comm.Parameters["@Subject"].Value = _Subject;
                comm.Parameters.Add(new SqlParameter("@Contents", SqlDbType.NVarChar, -1));
                comm.Parameters["@Contents"].Value = _Contents;
                comm.Parameters.Add(new SqlParameter("@ReceiveName", SqlDbType.NVarChar, 50));
                comm.Parameters["@ReceiveName"].Value = _ReceiveName;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@IsSend", SqlDbType.Bit));
                comm.Parameters["@IsSend"].Value = _IsSend;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@CreateUserID", SqlDbType.Int));
                comm.Parameters["@CreateUserID"].Value = _CreateUserID;
                comm.Parameters.Add(new SqlParameter("@pk_Mail", SqlDbType.Int));
                comm.Parameters["@pk_Mail"].Value = id;
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
            Sql.SqlQuery("delete from Member_Mail where pk_Mail=" + id);
        }

        #endregion
    }
}
