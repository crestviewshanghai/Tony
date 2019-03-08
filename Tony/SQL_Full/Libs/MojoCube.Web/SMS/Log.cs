using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.SMS
{
    public class Log
    {
        #region 公共属性
        int _pk_Log;
        public int pk_Log
        {
            get { return _pk_Log; }
            set { _pk_Log = value; }
        }
        int _fk_User;
        public int fk_User
        {
            get { return _fk_User; }
            set { _fk_User = value; }
        }
        int _fk_Department;
        public int fk_Department
        {
            get { return _fk_Department; }
            set { _fk_Department = value; }
        }
        int _fk_SMS;
        public int fk_SMS
        {
            get { return _fk_SMS; }
            set { _fk_SMS = value; }
        }
        string _TableName;
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
        int _fk_ID;
        public int fk_ID
        {
            get { return _fk_ID; }
            set { _fk_ID = value; }
        }
        int _TypeID;
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        string _Contents;
        public string Contents
        {
            get { return _Contents; }
            set { _Contents = value; }
        }
        string _Reason;
        public string Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }
        string _SID;
        public string SID
        {
            get { return _SID; }
            set { _SID = value; }
        }
        int _Fee;
        public int Fee
        {
            get { return _Fee; }
            set { _Fee = value; }
        }
        int _Counts;
        public int Counts
        {
            get { return _Counts; }
            set { _Counts = value; }
        }
        int _Code;
        public int Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        string _Result;
        public string Result
        {
            get { return _Result; }
            set { _Result = value; }
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
                string sql = "select * from SMS_Log where pk_Log=@pk_Log";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Log", SqlDbType.Int));
                comm.Parameters["@pk_Log"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Log = Convert.ToInt32(dr["pk_Log"].ToString());
                    _fk_User = Convert.ToInt32(dr["fk_User"].ToString());
                    _fk_Department = Convert.ToInt32(dr["fk_Department"].ToString());
                    _fk_SMS = Convert.ToInt32(dr["fk_SMS"].ToString());
                    _TableName = dr["TableName"].ToString();
                    _fk_ID = Convert.ToInt32(dr["fk_ID"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _Phone = dr["Phone"].ToString();
                    _Contents = dr["Contents"].ToString();
                    _Reason = dr["Reason"].ToString();
                    _SID = dr["SID"].ToString();
                    _Fee = Convert.ToInt32(dr["Fee"].ToString());
                    _Counts = Convert.ToInt32(dr["Counts"].ToString());
                    _Code = Convert.ToInt32(dr["Code"].ToString());
                    _Result = dr["Result"].ToString();
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
                string sql = "insert into SMS_Log(fk_User,fk_Department,fk_SMS,TableName,fk_ID,TypeID,Phone,Contents,Reason,SID,Fee,Counts,Code,Result,CreateDate) values (@fk_User,@fk_Department,@fk_SMS,@TableName,@fk_ID,@TypeID,@Phone,@Contents,@Reason,@SID,@Fee,@Counts,@Code,@Result,@CreateDate)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_User", SqlDbType.Int));
                comm.Parameters["@fk_User"].Value = _fk_User;
                comm.Parameters.Add(new SqlParameter("@fk_Department", SqlDbType.Int));
                comm.Parameters["@fk_Department"].Value = _fk_Department;
                comm.Parameters.Add(new SqlParameter("@fk_SMS", SqlDbType.Int));
                comm.Parameters["@fk_SMS"].Value = _fk_SMS;
                comm.Parameters.Add(new SqlParameter("@TableName", SqlDbType.VarChar, 30));
                comm.Parameters["@TableName"].Value = _TableName;
                comm.Parameters.Add(new SqlParameter("@fk_ID", SqlDbType.Int));
                comm.Parameters["@fk_ID"].Value = _fk_ID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 50));
                comm.Parameters["@Phone"].Value = _Phone;
                comm.Parameters.Add(new SqlParameter("@Contents", SqlDbType.NVarChar, 500));
                comm.Parameters["@Contents"].Value = _Contents;
                comm.Parameters.Add(new SqlParameter("@Reason", SqlDbType.NVarChar, 50));
                comm.Parameters["@Reason"].Value = _Reason;
                comm.Parameters.Add(new SqlParameter("@SID", SqlDbType.NVarChar, 50));
                comm.Parameters["@SID"].Value = _SID;
                comm.Parameters.Add(new SqlParameter("@Fee", SqlDbType.Int));
                comm.Parameters["@Fee"].Value = _Fee;
                comm.Parameters.Add(new SqlParameter("@Counts", SqlDbType.Int));
                comm.Parameters["@Counts"].Value = _Counts;
                comm.Parameters.Add(new SqlParameter("@Code", SqlDbType.Int));
                comm.Parameters["@Code"].Value = _Code;
                comm.Parameters.Add(new SqlParameter("@Result", SqlDbType.NVarChar, 500));
                comm.Parameters["@Result"].Value = _Result;
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
        /// 修改数据
        /// </summary>
        /// <param name="id">ID</param>
        public void UpdateData(int id)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update SMS_Log set fk_User=@fk_User,fk_Department=@fk_Department,fk_SMS=@fk_SMS,TableName=@TableName,fk_ID=@fk_ID,TypeID=@TypeID,Phone=@Phone,Contents=@Contents,Reason=@Reason,SID=@SID,Fee=@Fee,Counts=@Counts,Code=@Code,Result=@Result,CreateDate=@CreateDate where pk_Log=@pk_Log";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_User", SqlDbType.Int));
                comm.Parameters["@fk_User"].Value = _fk_User;
                comm.Parameters.Add(new SqlParameter("@fk_Department", SqlDbType.Int));
                comm.Parameters["@fk_Department"].Value = _fk_Department;
                comm.Parameters.Add(new SqlParameter("@fk_SMS", SqlDbType.Int));
                comm.Parameters["@fk_SMS"].Value = _fk_SMS;
                comm.Parameters.Add(new SqlParameter("@TableName", SqlDbType.VarChar, 30));
                comm.Parameters["@TableName"].Value = _TableName;
                comm.Parameters.Add(new SqlParameter("@fk_ID", SqlDbType.Int));
                comm.Parameters["@fk_ID"].Value = _fk_ID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 50));
                comm.Parameters["@Phone"].Value = _Phone;
                comm.Parameters.Add(new SqlParameter("@Contents", SqlDbType.NVarChar, 500));
                comm.Parameters["@Contents"].Value = _Contents;
                comm.Parameters.Add(new SqlParameter("@Reason", SqlDbType.NVarChar, 50));
                comm.Parameters["@Reason"].Value = _Reason;
                comm.Parameters.Add(new SqlParameter("@SID", SqlDbType.NVarChar, 50));
                comm.Parameters["@SID"].Value = _SID;
                comm.Parameters.Add(new SqlParameter("@Fee", SqlDbType.Int));
                comm.Parameters["@Fee"].Value = _Fee;
                comm.Parameters.Add(new SqlParameter("@Counts", SqlDbType.Int));
                comm.Parameters["@Counts"].Value = _Counts;
                comm.Parameters.Add(new SqlParameter("@Code", SqlDbType.Int));
                comm.Parameters["@Code"].Value = _Code;
                comm.Parameters.Add(new SqlParameter("@Result", SqlDbType.NVarChar, 500));
                comm.Parameters["@Result"].Value = _Result;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@pk_Log", SqlDbType.Int));
                comm.Parameters["@pk_Log"].Value = id;
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
            Sql.SqlQuery("delete from SMS_Log where pk_Log=" + id);
        }

        #endregion
    }
}
