using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Mail
{
    public class Receive
    {
        #region 公共属性
        int _pk_Receive;
        public int pk_Receive
        {
            get { return _pk_Receive; }
            set { _pk_Receive = value; }
        }
        int _fk_Account;
        public int fk_Account
        {
            get { return _fk_Account; }
            set { _fk_Account = value; }
        }
        string _NickName;
        public string NickName
        {
            get { return _NickName; }
            set { _NickName = value; }
        }
        string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        int _Sex;
        public int Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        int _Power;
        public int Power
        {
            get { return _Power; }
            set { _Power = value; }
        }
        int _TypeID;
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
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
                string sql = "select * from Mail_Receive where pk_Receive=@pk_Receive";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Receive", SqlDbType.Int));
                comm.Parameters["@pk_Receive"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Receive = Convert.ToInt32(dr["pk_Receive"].ToString());
                    _fk_Account = Convert.ToInt32(dr["fk_Account"].ToString());
                    _NickName = dr["NickName"].ToString();
                    _FirstName = dr["FirstName"].ToString();
                    _LastName = dr["LastName"].ToString();
                    _Sex = Convert.ToInt32(dr["Sex"].ToString());
                    _Email = dr["Email"].ToString();
                    _Power = Convert.ToInt32(dr["Power"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
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
        /// 获取接收邮件的地址
        /// </summary>
        /// <param name="accountID">账号ID</param>
        /// <returns></returns>
        public string GetEmailList(int accountID)
        {
            string list = string.Empty;
            DataTable dt = new DataTable();
            dt = Sql.SqlQueryDS("select * from Mail_Receive where fk_Account=" + accountID).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list += dt.Rows[i]["Email"].ToString() + ",";
            }
            if (list.Length > 1)
            {
                list = list.Substring(0, list.Length - 1);
            }
            return list;
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
                string sql = "insert into Mail_Receive(fk_Account,NickName,FirstName,LastName,Sex,Email,Power,TypeID,Remark,CreateDate,CreateUserID,ModifyDate,ModifyUserID) values (@fk_Account,@NickName,@FirstName,@LastName,@Sex,@Email,@Power,@TypeID,@Remark,@CreateDate,@CreateUserID,@ModifyDate,@ModifyUserID)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Account", SqlDbType.Int));
                comm.Parameters["@fk_Account"].Value = _fk_Account;
                comm.Parameters.Add(new SqlParameter("@NickName", SqlDbType.NVarChar, 50));
                comm.Parameters["@NickName"].Value = _NickName;
                comm.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 50));
                comm.Parameters["@FirstName"].Value = _FirstName;
                comm.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 50));
                comm.Parameters["@LastName"].Value = _LastName;
                comm.Parameters.Add(new SqlParameter("@Sex", SqlDbType.Int));
                comm.Parameters["@Sex"].Value = _Sex;
                comm.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 200));
                comm.Parameters["@Email"].Value = _Email;
                comm.Parameters.Add(new SqlParameter("@Power", SqlDbType.Int));
                comm.Parameters["@Power"].Value = _Power;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
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
                string sql = "update Mail_Receive set fk_Account=@fk_Account,NickName=@NickName,FirstName=@FirstName,LastName=@LastName,Sex=@Sex,Email=@Email,Power=@Power,TypeID=@TypeID,Remark=@Remark,CreateDate=@CreateDate,CreateUserID=@CreateUserID,ModifyDate=@ModifyDate,ModifyUserID=@ModifyUserID where pk_Receive=@pk_Receive";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Account", SqlDbType.Int));
                comm.Parameters["@fk_Account"].Value = _fk_Account;
                comm.Parameters.Add(new SqlParameter("@NickName", SqlDbType.NVarChar, 50));
                comm.Parameters["@NickName"].Value = _NickName;
                comm.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 50));
                comm.Parameters["@FirstName"].Value = _FirstName;
                comm.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 50));
                comm.Parameters["@LastName"].Value = _LastName;
                comm.Parameters.Add(new SqlParameter("@Sex", SqlDbType.Int));
                comm.Parameters["@Sex"].Value = _Sex;
                comm.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 200));
                comm.Parameters["@Email"].Value = _Email;
                comm.Parameters.Add(new SqlParameter("@Power", SqlDbType.Int));
                comm.Parameters["@Power"].Value = _Power;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
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
                comm.Parameters.Add(new SqlParameter("@pk_Receive", SqlDbType.Int));
                comm.Parameters["@pk_Receive"].Value = id;
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
            Sql.SqlQuery("delete from Mail_Receive where pk_Receive=" + id);
        }

        #endregion
    }
}
