using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Member
{
    public class Message
    {
        #region 公共属性
        int _pk_Message;
        public int pk_Message
        {
            get { return _pk_Message; }
            set { _pk_Message = value; }
        }
        string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        string _Contents;
        public string Contents
        {
            get { return _Contents; }
            set { _Contents = value; }
        }
        string _Link;
        public string Link
        {
            get { return _Link; }
            set { _Link = value; }
        }
        int _CreateUserID;
        public int CreateUserID
        {
            get { return _CreateUserID; }
            set { _CreateUserID = value; }
        }
        string _CreateUserName;
        public string CreateUserName
        {
            get { return _CreateUserName; }
            set { _CreateUserName = value; }
        }
        string _CreateDate;
        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        int _ReceiveUserID;
        public int ReceiveUserID
        {
            get { return _ReceiveUserID; }
            set { _ReceiveUserID = value; }
        }
        string _ReceiveUserName;
        public string ReceiveUserName
        {
            get { return _ReceiveUserName; }
            set { _ReceiveUserName = value; }
        }
        string _ReceiveDate;
        public string ReceiveDate
        {
            get { return _ReceiveDate; }
            set { _ReceiveDate = value; }
        }
        bool _IsRead;
        public bool IsRead
        {
            get { return _IsRead; }
            set { _IsRead = value; }
        }
        bool _IsDeleted;
        public bool IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }
        bool _IsAdminSend;
        public bool IsAdminSend
        {
            get { return _IsAdminSend; }
            set { _IsAdminSend = value; }
        }
        bool _IsAdminReceive;
        public bool IsAdminReceive
        {
            get { return _IsAdminReceive; }
            set { _IsAdminReceive = value; }
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
        bool _IsReply;
        public bool IsReply
        {
            get { return _IsReply; }
            set { _IsReply = value; }
        }
        int _ReplyID;
        public int ReplyID
        {
            get { return _ReplyID; }
            set { _ReplyID = value; }
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
                string sql = "select * from Member_Message where pk_Message=@pk_Message";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Message", SqlDbType.Int));
                comm.Parameters["@pk_Message"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Message = Convert.ToInt32(dr["pk_Message"].ToString());
                    _Title = dr["Title"].ToString();
                    _Contents = dr["Contents"].ToString();
                    _Link = dr["Link"].ToString();
                    _CreateUserID = Convert.ToInt32(dr["CreateUserID"].ToString());
                    _CreateUserName = dr["CreateUserName"].ToString();
                    _CreateDate = dr["CreateDate"].ToString();
                    _ReceiveUserID = Convert.ToInt32(dr["ReceiveUserID"].ToString());
                    _ReceiveUserName = dr["ReceiveUserName"].ToString();
                    _ReceiveDate = dr["ReceiveDate"].ToString();
                    _IsRead = Convert.ToBoolean(dr["IsRead"].ToString());
                    _IsDeleted = Convert.ToBoolean(dr["IsDeleted"].ToString());
                    _IsAdminSend = Convert.ToBoolean(dr["IsAdminSend"].ToString());
                    _IsAdminReceive = Convert.ToBoolean(dr["IsAdminReceive"].ToString());
                    _StatusID = Convert.ToInt32(dr["StatusID"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _IsReply = Convert.ToBoolean(dr["IsReply"].ToString());
                    _ReplyID = Convert.ToInt32(dr["ReplyID"].ToString());
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
                string sql = "insert into Member_Message(Title,Contents,Link,CreateUserID,CreateUserName,CreateDate,ReceiveUserID,ReceiveUserName,ReceiveDate,IsRead,IsDeleted,IsAdminSend,IsAdminReceive,StatusID,TypeID,IsReply,ReplyID) values (@Title,@Contents,@Link,@CreateUserID,@CreateUserName,@CreateDate,@ReceiveUserID,@ReceiveUserName,@ReceiveDate,@IsRead,@IsDeleted,@IsAdminSend,@IsAdminReceive,@StatusID,@TypeID,@IsReply,@ReplyID)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Contents", SqlDbType.NVarChar, -1));
                comm.Parameters["@Contents"].Value = _Contents;
                comm.Parameters.Add(new SqlParameter("@Link", SqlDbType.NVarChar, 200));
                comm.Parameters["@Link"].Value = _Link;
                comm.Parameters.Add(new SqlParameter("@CreateUserID", SqlDbType.Int));
                comm.Parameters["@CreateUserID"].Value = _CreateUserID;
                comm.Parameters.Add(new SqlParameter("@CreateUserName", SqlDbType.NVarChar, 50));
                comm.Parameters["@CreateUserName"].Value = _CreateUserName;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@ReceiveUserID", SqlDbType.Int));
                comm.Parameters["@ReceiveUserID"].Value = _ReceiveUserID;
                comm.Parameters.Add(new SqlParameter("@ReceiveUserName", SqlDbType.NVarChar, 50));
                comm.Parameters["@ReceiveUserName"].Value = _ReceiveUserName;
                comm.Parameters.Add(new SqlParameter("@ReceiveDate", SqlDbType.DateTime));
                comm.Parameters["@ReceiveDate"].Value = _ReceiveDate;
                comm.Parameters.Add(new SqlParameter("@IsRead", SqlDbType.Bit));
                comm.Parameters["@IsRead"].Value = _IsRead;
                comm.Parameters.Add(new SqlParameter("@IsDeleted", SqlDbType.Bit));
                comm.Parameters["@IsDeleted"].Value = _IsDeleted;
                comm.Parameters.Add(new SqlParameter("@IsAdminSend", SqlDbType.Bit));
                comm.Parameters["@IsAdminSend"].Value = _IsAdminSend;
                comm.Parameters.Add(new SqlParameter("@IsAdminReceive", SqlDbType.Bit));
                comm.Parameters["@IsAdminReceive"].Value = _IsAdminReceive;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@IsReply", SqlDbType.Bit));
                comm.Parameters["@IsReply"].Value = _IsReply;
                comm.Parameters.Add(new SqlParameter("@ReplyID", SqlDbType.Int));
                comm.Parameters["@ReplyID"].Value = _ReplyID;
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
                string sql = "update Member_Message set Title=@Title,Contents=@Contents,Link=@Link,CreateUserID=@CreateUserID,CreateUserName=@CreateUserName,CreateDate=@CreateDate,ReceiveUserID=@ReceiveUserID,ReceiveUserName=@ReceiveUserName,ReceiveDate=@ReceiveDate,IsRead=@IsRead,IsDeleted=@IsDeleted,IsAdminSend=@IsAdminSend,IsAdminReceive=@IsAdminReceive,StatusID=@StatusID,TypeID=@TypeID,IsReply=@IsReply,ReplyID=@ReplyID where pk_Message=@pk_Message";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Contents", SqlDbType.NVarChar, -1));
                comm.Parameters["@Contents"].Value = _Contents;
                comm.Parameters.Add(new SqlParameter("@Link", SqlDbType.NVarChar, 200));
                comm.Parameters["@Link"].Value = _Link;
                comm.Parameters.Add(new SqlParameter("@CreateUserID", SqlDbType.Int));
                comm.Parameters["@CreateUserID"].Value = _CreateUserID;
                comm.Parameters.Add(new SqlParameter("@CreateUserName", SqlDbType.NVarChar, 50));
                comm.Parameters["@CreateUserName"].Value = _CreateUserName;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@ReceiveUserID", SqlDbType.Int));
                comm.Parameters["@ReceiveUserID"].Value = _ReceiveUserID;
                comm.Parameters.Add(new SqlParameter("@ReceiveUserName", SqlDbType.NVarChar, 50));
                comm.Parameters["@ReceiveUserName"].Value = _ReceiveUserName;
                comm.Parameters.Add(new SqlParameter("@ReceiveDate", SqlDbType.DateTime));
                comm.Parameters["@ReceiveDate"].Value = _ReceiveDate;
                comm.Parameters.Add(new SqlParameter("@IsRead", SqlDbType.Bit));
                comm.Parameters["@IsRead"].Value = _IsRead;
                comm.Parameters.Add(new SqlParameter("@IsDeleted", SqlDbType.Bit));
                comm.Parameters["@IsDeleted"].Value = _IsDeleted;
                comm.Parameters.Add(new SqlParameter("@IsAdminSend", SqlDbType.Bit));
                comm.Parameters["@IsAdminSend"].Value = _IsAdminSend;
                comm.Parameters.Add(new SqlParameter("@IsAdminReceive", SqlDbType.Bit));
                comm.Parameters["@IsAdminReceive"].Value = _IsAdminReceive;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@IsReply", SqlDbType.Bit));
                comm.Parameters["@IsReply"].Value = _IsReply;
                comm.Parameters.Add(new SqlParameter("@ReplyID", SqlDbType.Int));
                comm.Parameters["@ReplyID"].Value = _ReplyID;
                comm.Parameters.Add(new SqlParameter("@pk_Message", SqlDbType.Int));
                comm.Parameters["@pk_Message"].Value = id;
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
            Sql.SqlQuery("delete from Member_Message where pk_Message=" + id);
        }

        /// <summary>
        /// 标记为已回复
        /// </summary>
        /// <param name="id">ID</param>
        public void MarkReply(int id)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update Member_Message set IsReply=@IsReply where pk_Message=" + id;
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@IsReply", SqlDbType.Bit));
                comm.Parameters["@IsReply"].Value = true;
                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 标记为已读
        /// </summary>
        /// <param name="id">ID</param>
        public void MarkRead(int id)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update Member_Message set IsRead=@IsRead,ReceiveDate=@ReceiveDate where pk_Message=" + id;
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@IsRead", SqlDbType.Bit));
                comm.Parameters["@IsRead"].Value = _IsRead;
                comm.Parameters.Add(new SqlParameter("@ReceiveDate", SqlDbType.DateTime));
                comm.Parameters["@ReceiveDate"].Value = DateTime.Now;
                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 标记为删除
        /// </summary>
        /// <param name="id">ID</param>
        public void MarkDeleted(int id)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update Member_Message set IsDeleted=@IsDeleted where pk_Message=" + id;
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@IsDeleted", SqlDbType.Bit));
                comm.Parameters["@IsDeleted"].Value = _IsDeleted;
                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 用于发送系统消息的静态方法
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="senderID">发送者ID</param>
        /// <param name="senderName">发送者名称</param>
        /// <param name="receiverID">接收者ID</param>
        /// <param name="receiverName">接收者名称</param>
        public static void Send(string title, string content, int senderID, string senderName, int receiverID, string receiverName)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "insert into Member_Message(Title,Contents,Link,CreateUserID,CreateUserName,CreateDate,ReceiveUserID,ReceiveUserName,ReceiveDate,IsRead,IsDeleted,IsAdminSend,IsAdminReceive,StatusID,TypeID,IsReply,ReplyID) values (@Title,@Contents,@Link,@CreateUserID,@CreateUserName,@CreateDate,@ReceiveUserID,@ReceiveUserName,@ReceiveDate,@IsRead,@IsDeleted,@IsAdminSend,@IsAdminReceive,@StatusID,@TypeID,@IsReply,@ReplyID)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = title;
                comm.Parameters.Add(new SqlParameter("@Contents", SqlDbType.NVarChar, -1));
                comm.Parameters["@Contents"].Value = content;
                comm.Parameters.Add(new SqlParameter("@Link", SqlDbType.NVarChar, 200));
                comm.Parameters["@Link"].Value = string.Empty;
                comm.Parameters.Add(new SqlParameter("@CreateUserID", SqlDbType.Int));
                comm.Parameters["@CreateUserID"].Value = senderID;
                comm.Parameters.Add(new SqlParameter("@CreateUserName", SqlDbType.NVarChar, 50));
                comm.Parameters["@CreateUserName"].Value = senderName;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = DateTime.Now;
                comm.Parameters.Add(new SqlParameter("@ReceiveUserID", SqlDbType.Int));
                comm.Parameters["@ReceiveUserID"].Value = receiverID;
                comm.Parameters.Add(new SqlParameter("@ReceiveUserName", SqlDbType.NVarChar, 50));
                comm.Parameters["@ReceiveUserName"].Value = receiverName;
                comm.Parameters.Add(new SqlParameter("@ReceiveDate", SqlDbType.DateTime));
                comm.Parameters["@ReceiveDate"].Value = DateTime.Now;
                comm.Parameters.Add(new SqlParameter("@IsRead", SqlDbType.Bit));
                comm.Parameters["@IsRead"].Value = false;
                comm.Parameters.Add(new SqlParameter("@IsDeleted", SqlDbType.Bit));
                comm.Parameters["@IsDeleted"].Value = false;
                comm.Parameters.Add(new SqlParameter("@IsAdminSend", SqlDbType.Bit));
                comm.Parameters["@IsAdminSend"].Value = true;
                comm.Parameters.Add(new SqlParameter("@IsAdminReceive", SqlDbType.Bit));
                comm.Parameters["@IsAdminReceive"].Value = true;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = 0;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = 0;
                comm.Parameters.Add(new SqlParameter("@IsReply", SqlDbType.Bit));
                comm.Parameters["@IsReply"].Value = false;
                comm.Parameters.Add(new SqlParameter("@ReplyID", SqlDbType.Int));
                comm.Parameters["@ReplyID"].Value = 0;
                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion
    }
}
