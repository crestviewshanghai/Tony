using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Comment
{
    public class List
    {
        #region 公共属性
        int _pk_Comment;
        public int pk_Comment
        {
            get { return _pk_Comment; }
            set { _pk_Comment = value; }
        }
        string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        string _Subtitle;
        public string Subtitle
        {
            get { return _Subtitle; }
            set { _Subtitle = value; }
        }
        string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        string _Feedback;
        public string Feedback
        {
            get { return _Feedback; }
            set { _Feedback = value; }
        }
        string _Visual;
        public string Visual
        {
            get { return _Visual; }
            set { _Visual = value; }
        }
        string _Author;
        public string Author
        {
            get { return _Author; }
            set { _Author = value; }
        }
        string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        string _Website;
        public string Website
        {
            get { return _Website; }
            set { _Website = value; }
        }
        string _IPAddress;
        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
        }
        string _Browser;
        public string Browser
        {
            get { return _Browser; }
            set { _Browser = value; }
        }
        bool _Issue;
        public bool Issue
        {
            get { return _Issue; }
            set { _Issue = value; }
        }
        bool _IsComment;
        public bool IsComment
        {
            get { return _IsComment; }
            set { _IsComment = value; }
        }
        bool _IsRecommend;
        public bool IsRecommend
        {
            get { return _IsRecommend; }
            set { _IsRecommend = value; }
        }
        bool _IsRead;
        public bool IsRead
        {
            get { return _IsRead; }
            set { _IsRead = value; }
        }
        string _ReadDate;
        public string ReadDate
        {
            get { return _ReadDate; }
            set { _ReadDate = value; }
        }
        int _Clicks;
        public int Clicks
        {
            get { return _Clicks; }
            set { _Clicks = value; }
        }
        int _fk_ID;
        public int fk_ID
        {
            get { return _fk_ID; }
            set { _fk_ID = value; }
        }
        int _SortID;
        public int SortID
        {
            get { return _SortID; }
            set { _SortID = value; }
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
        int _Score;
        public int Score
        {
            get { return _Score; }
            set { _Score = value; }
        }
        int _ScoreIn;
        public int ScoreIn
        {
            get { return _ScoreIn; }
            set { _ScoreIn = value; }
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
        string _Language;
        public string Language
        {
            get { return _Language; }
            set { _Language = value; }
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
                string sql = "select * from Comment_List where pk_Comment=@pk_Comment";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Comment", SqlDbType.Int));
                comm.Parameters["@pk_Comment"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Comment = Convert.ToInt32(dr["pk_Comment"].ToString());
                    _Title = dr["Title"].ToString();
                    _Subtitle = dr["Subtitle"].ToString();
                    _Description = dr["Description"].ToString();
                    _Feedback = dr["Feedback"].ToString();
                    _Visual = dr["Visual"].ToString();
                    _Author = dr["Author"].ToString();
                    _Email = dr["Email"].ToString();
                    _Phone = dr["Phone"].ToString();
                    _Address = dr["Address"].ToString();
                    _Website = dr["Website"].ToString();
                    _IPAddress = dr["IPAddress"].ToString();
                    _Browser = dr["Browser"].ToString();
                    _Issue = Convert.ToBoolean(dr["Issue"].ToString());
                    _IsComment = Convert.ToBoolean(dr["IsComment"].ToString());
                    _IsRecommend = Convert.ToBoolean(dr["IsRecommend"].ToString());
                    _IsRead = Convert.ToBoolean(dr["IsRead"].ToString());
                    _ReadDate = dr["ReadDate"].ToString();
                    _Clicks = Convert.ToInt32(dr["Clicks"].ToString());
                    _fk_ID = Convert.ToInt32(dr["fk_ID"].ToString());
                    _SortID = Convert.ToInt32(dr["SortID"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _StatusID = Convert.ToInt32(dr["StatusID"].ToString());
                    _Score = Convert.ToInt32(dr["Score"].ToString());
                    _ScoreIn = Convert.ToInt32(dr["ScoreIn"].ToString());
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
                    _Language = dr["Language"].ToString();
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
                string sql = "insert into Comment_List(Title,Subtitle,Description,Feedback,Visual,Author,Email,Phone,Address,Website,IPAddress,Browser,Issue,IsComment,IsRecommend,IsRead,ReadDate,Clicks,fk_ID,SortID,TypeID,StatusID,Score,ScoreIn,CreateDate,CreateUserID,ModifyDate,ModifyUserID,Language) values (@Title,@Subtitle,@Description,@Feedback,@Visual,@Author,@Email,@Phone,@Address,@Website,@IPAddress,@Browser,@Issue,@IsComment,@IsRecommend,@IsRead,@ReadDate,@Clicks,@fk_ID,@SortID,@TypeID,@StatusID,@Score,@ScoreIn,@CreateDate,@CreateUserID,@ModifyDate,@ModifyUserID,@Language)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Subtitle", SqlDbType.NVarChar, 200));
                comm.Parameters["@Subtitle"].Value = _Subtitle;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@Feedback", SqlDbType.NVarChar, -1));
                comm.Parameters["@Feedback"].Value = _Feedback;
                comm.Parameters.Add(new SqlParameter("@Visual", SqlDbType.VarChar, 50));
                comm.Parameters["@Visual"].Value = _Visual;
                comm.Parameters.Add(new SqlParameter("@Author", SqlDbType.NVarChar, 20));
                comm.Parameters["@Author"].Value = _Author;
                comm.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 100));
                comm.Parameters["@Email"].Value = _Email;
                comm.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 50));
                comm.Parameters["@Phone"].Value = _Phone;
                comm.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 500));
                comm.Parameters["@Address"].Value = _Address;
                comm.Parameters.Add(new SqlParameter("@Website", SqlDbType.NVarChar, 100));
                comm.Parameters["@Website"].Value = _Website;
                comm.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.VarChar, 20));
                comm.Parameters["@IPAddress"].Value = _IPAddress;
                comm.Parameters.Add(new SqlParameter("@Browser", SqlDbType.NVarChar, 50));
                comm.Parameters["@Browser"].Value = _Browser;
                comm.Parameters.Add(new SqlParameter("@Issue", SqlDbType.Bit));
                comm.Parameters["@Issue"].Value = _Issue;
                comm.Parameters.Add(new SqlParameter("@IsComment", SqlDbType.Bit));
                comm.Parameters["@IsComment"].Value = _IsComment;
                comm.Parameters.Add(new SqlParameter("@IsRecommend", SqlDbType.Bit));
                comm.Parameters["@IsRecommend"].Value = _IsRecommend;
                comm.Parameters.Add(new SqlParameter("@IsRead", SqlDbType.Bit));
                comm.Parameters["@IsRead"].Value = _IsRead;
                comm.Parameters.Add(new SqlParameter("@ReadDate", SqlDbType.DateTime));
                comm.Parameters["@ReadDate"].Value = _ReadDate;
                comm.Parameters.Add(new SqlParameter("@Clicks", SqlDbType.Int));
                comm.Parameters["@Clicks"].Value = _Clicks;
                comm.Parameters.Add(new SqlParameter("@fk_ID", SqlDbType.Int));
                comm.Parameters["@fk_ID"].Value = _fk_ID;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@Score", SqlDbType.Int));
                comm.Parameters["@Score"].Value = _Score;
                comm.Parameters.Add(new SqlParameter("@ScoreIn", SqlDbType.Int));
                comm.Parameters["@ScoreIn"].Value = _ScoreIn;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@CreateUserID", SqlDbType.Int));
                comm.Parameters["@CreateUserID"].Value = _CreateUserID;
                comm.Parameters.Add(new SqlParameter("@ModifyDate", SqlDbType.DateTime));
                comm.Parameters["@ModifyDate"].Value = _ModifyDate;
                comm.Parameters.Add(new SqlParameter("@ModifyUserID", SqlDbType.Int));
                comm.Parameters["@ModifyUserID"].Value = _ModifyUserID;
                comm.Parameters.Add(new SqlParameter("@Language", SqlDbType.VarChar, 10));
                comm.Parameters["@Language"].Value = _Language;
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
                string sql = "update Comment_List set Title=@Title,Subtitle=@Subtitle,Description=@Description,Feedback=@Feedback,Visual=@Visual,Author=@Author,Email=@Email,Phone=@Phone,Address=@Address,Website=@Website,IPAddress=@IPAddress,Browser=@Browser,Issue=@Issue,IsComment=@IsComment,IsRecommend=@IsRecommend,IsRead=@IsRead,ReadDate=@ReadDate,Clicks=@Clicks,fk_ID=@fk_ID,SortID=@SortID,TypeID=@TypeID,StatusID=@StatusID,Score=@Score,ScoreIn=@ScoreIn,CreateDate=@CreateDate,CreateUserID=@CreateUserID,ModifyDate=@ModifyDate,ModifyUserID=@ModifyUserID,Language=@Language where pk_Comment=@pk_Comment";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Subtitle", SqlDbType.NVarChar, 200));
                comm.Parameters["@Subtitle"].Value = _Subtitle;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@Feedback", SqlDbType.NVarChar, -1));
                comm.Parameters["@Feedback"].Value = _Feedback;
                comm.Parameters.Add(new SqlParameter("@Visual", SqlDbType.VarChar, 50));
                comm.Parameters["@Visual"].Value = _Visual;
                comm.Parameters.Add(new SqlParameter("@Author", SqlDbType.NVarChar, 20));
                comm.Parameters["@Author"].Value = _Author;
                comm.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 100));
                comm.Parameters["@Email"].Value = _Email;
                comm.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 50));
                comm.Parameters["@Phone"].Value = _Phone;
                comm.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 500));
                comm.Parameters["@Address"].Value = _Address;
                comm.Parameters.Add(new SqlParameter("@Website", SqlDbType.NVarChar, 100));
                comm.Parameters["@Website"].Value = _Website;
                comm.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.VarChar, 20));
                comm.Parameters["@IPAddress"].Value = _IPAddress;
                comm.Parameters.Add(new SqlParameter("@Browser", SqlDbType.NVarChar, 50));
                comm.Parameters["@Browser"].Value = _Browser;
                comm.Parameters.Add(new SqlParameter("@Issue", SqlDbType.Bit));
                comm.Parameters["@Issue"].Value = _Issue;
                comm.Parameters.Add(new SqlParameter("@IsComment", SqlDbType.Bit));
                comm.Parameters["@IsComment"].Value = _IsComment;
                comm.Parameters.Add(new SqlParameter("@IsRecommend", SqlDbType.Bit));
                comm.Parameters["@IsRecommend"].Value = _IsRecommend;
                comm.Parameters.Add(new SqlParameter("@IsRead", SqlDbType.Bit));
                comm.Parameters["@IsRead"].Value = _IsRead;
                comm.Parameters.Add(new SqlParameter("@ReadDate", SqlDbType.DateTime));
                comm.Parameters["@ReadDate"].Value = _ReadDate;
                comm.Parameters.Add(new SqlParameter("@Clicks", SqlDbType.Int));
                comm.Parameters["@Clicks"].Value = _Clicks;
                comm.Parameters.Add(new SqlParameter("@fk_ID", SqlDbType.Int));
                comm.Parameters["@fk_ID"].Value = _fk_ID;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@Score", SqlDbType.Int));
                comm.Parameters["@Score"].Value = _Score;
                comm.Parameters.Add(new SqlParameter("@ScoreIn", SqlDbType.Int));
                comm.Parameters["@ScoreIn"].Value = _ScoreIn;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@CreateUserID", SqlDbType.Int));
                comm.Parameters["@CreateUserID"].Value = _CreateUserID;
                comm.Parameters.Add(new SqlParameter("@ModifyDate", SqlDbType.DateTime));
                comm.Parameters["@ModifyDate"].Value = _ModifyDate;
                comm.Parameters.Add(new SqlParameter("@ModifyUserID", SqlDbType.Int));
                comm.Parameters["@ModifyUserID"].Value = _ModifyUserID;
                comm.Parameters.Add(new SqlParameter("@Language", SqlDbType.VarChar, 10));
                comm.Parameters["@Language"].Value = _Language;
                comm.Parameters.Add(new SqlParameter("@pk_Comment", SqlDbType.Int));
                comm.Parameters["@pk_Comment"].Value = id;
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
            Sql.SqlQuery("delete from Comment_List where pk_Comment=" + id);
        }

        #endregion
    }
}
