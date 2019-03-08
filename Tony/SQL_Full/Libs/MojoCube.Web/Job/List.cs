using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Job
{
    public class List
    {
        #region 公共属性
        int _pk_Job;
        public int pk_Job
        {
            get { return _pk_Job; }
            set { _pk_Job = value; }
        }
        int _CategoryID1;
        public int CategoryID1
        {
            get { return _CategoryID1; }
            set { _CategoryID1 = value; }
        }
        int _CategoryID2;
        public int CategoryID2
        {
            get { return _CategoryID2; }
            set { _CategoryID2 = value; }
        }
        string _PageName;
        public string PageName
        {
            get { return _PageName; }
            set { _PageName = value; }
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
        string _Department;
        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }
        string _Position;
        public string Position
        {
            get { return _Position; }
            set { _Position = value; }
        }
        string _Number;
        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        string _Place;
        public string Place
        {
            get { return _Place; }
            set { _Place = value; }
        }
        string _Education;
        public string Education
        {
            get { return _Education; }
            set { _Education = value; }
        }
        string _Sex;
        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        string _Major;
        public string Major
        {
            get { return _Major; }
            set { _Major = value; }
        }
        string _Wages;
        public string Wages
        {
            get { return _Wages; }
            set { _Wages = value; }
        }
        string _Experiences;
        public string Experiences
        {
            get { return _Experiences; }
            set { _Experiences = value; }
        }
        string _Age;
        public string Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        string _SEO_Title;
        public string SEO_Title
        {
            get { return _SEO_Title; }
            set { _SEO_Title = value; }
        }
        string _SEO_Keyword;
        public string SEO_Keyword
        {
            get { return _SEO_Keyword; }
            set { _SEO_Keyword = value; }
        }
        string _SEO_Description;
        public string SEO_Description
        {
            get { return _SEO_Description; }
            set { _SEO_Description = value; }
        }
        string _Tags;
        public string Tags
        {
            get { return _Tags; }
            set { _Tags = value; }
        }
        string _Visual;
        public string Visual
        {
            get { return _Visual; }
            set { _Visual = value; }
        }
        string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
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
        int _Clicks;
        public int Clicks
        {
            get { return _Clicks; }
            set { _Clicks = value; }
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
        string _StartDate;
        public string StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }
        string _EndDate;
        public string EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
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
                string sql = "select * from Job_List where pk_Job=@pk_Job";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Job", SqlDbType.Int));
                comm.Parameters["@pk_Job"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Job = Convert.ToInt32(dr["pk_Job"].ToString());
                    _CategoryID1 = Convert.ToInt32(dr["CategoryID1"].ToString());
                    _CategoryID2 = Convert.ToInt32(dr["CategoryID2"].ToString());
                    _PageName = dr["PageName"].ToString();
                    _Title = dr["Title"].ToString();
                    _Subtitle = dr["Subtitle"].ToString();
                    _Description = dr["Description"].ToString();
                    _Department = dr["Department"].ToString();
                    _Position = dr["Position"].ToString();
                    _Number = dr["Number"].ToString();
                    _Place = dr["Place"].ToString();
                    _Education = dr["Education"].ToString();
                    _Sex = dr["Sex"].ToString();
                    _Major = dr["Major"].ToString();
                    _Wages = dr["Wages"].ToString();
                    _Experiences = dr["Experiences"].ToString();
                    _Age = dr["Age"].ToString();
                    _SEO_Title = dr["SEO_Title"].ToString();
                    _SEO_Keyword = dr["SEO_Keyword"].ToString();
                    _SEO_Description = dr["SEO_Description"].ToString();
                    _Tags = dr["Tags"].ToString();
                    _Visual = dr["Visual"].ToString();
                    _ImagePath = dr["ImagePath"].ToString();
                    _Issue = Convert.ToBoolean(dr["Issue"].ToString());
                    _IsComment = Convert.ToBoolean(dr["IsComment"].ToString());
                    _IsRecommend = Convert.ToBoolean(dr["IsRecommend"].ToString());
                    _Clicks = Convert.ToInt32(dr["Clicks"].ToString());
                    _SortID = Convert.ToInt32(dr["SortID"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _StartDate = dr["StartDate"].ToString();
                    _EndDate = dr["EndDate"].ToString();
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
                string sql = "insert into Job_List(CategoryID1,CategoryID2,PageName,Title,Subtitle,Description,Department,Position,Number,Place,Education,Sex,Major,Wages,Experiences,Age,SEO_Title,SEO_Keyword,SEO_Description,Tags,Visual,ImagePath,Issue,IsComment,IsRecommend,Clicks,SortID,TypeID,StartDate,EndDate,CreateDate,CreateUserID,ModifyDate,ModifyUserID,Language) values (@CategoryID1,@CategoryID2,@PageName,@Title,@Subtitle,@Description,@Department,@Position,@Number,@Place,@Education,@Sex,@Major,@Wages,@Experiences,@Age,@SEO_Title,@SEO_Keyword,@SEO_Description,@Tags,@Visual,@ImagePath,@Issue,@IsComment,@IsRecommend,@Clicks,@SortID,@TypeID,@StartDate,@EndDate,@CreateDate,@CreateUserID,@ModifyDate,@ModifyUserID,@Language)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@CategoryID1", SqlDbType.Int));
                comm.Parameters["@CategoryID1"].Value = _CategoryID1;
                comm.Parameters.Add(new SqlParameter("@CategoryID2", SqlDbType.Int));
                comm.Parameters["@CategoryID2"].Value = _CategoryID2;
                comm.Parameters.Add(new SqlParameter("@PageName", SqlDbType.NVarChar, 100));
                comm.Parameters["@PageName"].Value = _PageName;
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Subtitle", SqlDbType.NVarChar, 200));
                comm.Parameters["@Subtitle"].Value = _Subtitle;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@Department", SqlDbType.NVarChar, 50));
                comm.Parameters["@Department"].Value = _Department;
                comm.Parameters.Add(new SqlParameter("@Position", SqlDbType.NVarChar, 50));
                comm.Parameters["@Position"].Value = _Position;
                comm.Parameters.Add(new SqlParameter("@Number", SqlDbType.NVarChar, 50));
                comm.Parameters["@Number"].Value = _Number;
                comm.Parameters.Add(new SqlParameter("@Place", SqlDbType.NVarChar, 50));
                comm.Parameters["@Place"].Value = _Place;
                comm.Parameters.Add(new SqlParameter("@Education", SqlDbType.NVarChar, 50));
                comm.Parameters["@Education"].Value = _Education;
                comm.Parameters.Add(new SqlParameter("@Sex", SqlDbType.NVarChar, 50));
                comm.Parameters["@Sex"].Value = _Sex;
                comm.Parameters.Add(new SqlParameter("@Major", SqlDbType.NVarChar, 50));
                comm.Parameters["@Major"].Value = _Major;
                comm.Parameters.Add(new SqlParameter("@Wages", SqlDbType.NVarChar, 50));
                comm.Parameters["@Wages"].Value = _Wages;
                comm.Parameters.Add(new SqlParameter("@Experiences", SqlDbType.NVarChar, 50));
                comm.Parameters["@Experiences"].Value = _Experiences;
                comm.Parameters.Add(new SqlParameter("@Age", SqlDbType.NVarChar, 50));
                comm.Parameters["@Age"].Value = _Age;
                comm.Parameters.Add(new SqlParameter("@SEO_Title", SqlDbType.NVarChar, 250));
                comm.Parameters["@SEO_Title"].Value = _SEO_Title;
                comm.Parameters.Add(new SqlParameter("@SEO_Keyword", SqlDbType.NVarChar, 250));
                comm.Parameters["@SEO_Keyword"].Value = _SEO_Keyword;
                comm.Parameters.Add(new SqlParameter("@SEO_Description", SqlDbType.NVarChar, 1000));
                comm.Parameters["@SEO_Description"].Value = _SEO_Description;
                comm.Parameters.Add(new SqlParameter("@Tags", SqlDbType.NVarChar, 100));
                comm.Parameters["@Tags"].Value = _Tags;
                comm.Parameters.Add(new SqlParameter("@Visual", SqlDbType.VarChar, 50));
                comm.Parameters["@Visual"].Value = _Visual;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;
                comm.Parameters.Add(new SqlParameter("@Issue", SqlDbType.Bit));
                comm.Parameters["@Issue"].Value = _Issue;
                comm.Parameters.Add(new SqlParameter("@IsComment", SqlDbType.Bit));
                comm.Parameters["@IsComment"].Value = _IsComment;
                comm.Parameters.Add(new SqlParameter("@IsRecommend", SqlDbType.Bit));
                comm.Parameters["@IsRecommend"].Value = _IsRecommend;
                comm.Parameters.Add(new SqlParameter("@Clicks", SqlDbType.Int));
                comm.Parameters["@Clicks"].Value = _Clicks;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime));
                comm.Parameters["@StartDate"].Value = _StartDate;
                comm.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime));
                comm.Parameters["@EndDate"].Value = _EndDate;
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
                string sql = "update Job_List set CategoryID1=@CategoryID1,CategoryID2=@CategoryID2,PageName=@PageName,Title=@Title,Subtitle=@Subtitle,Description=@Description,Department=@Department,Position=@Position,Number=@Number,Place=@Place,Education=@Education,Sex=@Sex,Major=@Major,Wages=@Wages,Experiences=@Experiences,Age=@Age,SEO_Title=@SEO_Title,SEO_Keyword=@SEO_Keyword,SEO_Description=@SEO_Description,Tags=@Tags,Visual=@Visual,ImagePath=@ImagePath,Issue=@Issue,IsComment=@IsComment,IsRecommend=@IsRecommend,Clicks=@Clicks,SortID=@SortID,TypeID=@TypeID,StartDate=@StartDate,EndDate=@EndDate,CreateDate=@CreateDate,CreateUserID=@CreateUserID,ModifyDate=@ModifyDate,ModifyUserID=@ModifyUserID,Language=@Language where pk_Job=@pk_Job";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@CategoryID1", SqlDbType.Int));
                comm.Parameters["@CategoryID1"].Value = _CategoryID1;
                comm.Parameters.Add(new SqlParameter("@CategoryID2", SqlDbType.Int));
                comm.Parameters["@CategoryID2"].Value = _CategoryID2;
                comm.Parameters.Add(new SqlParameter("@PageName", SqlDbType.NVarChar, 100));
                comm.Parameters["@PageName"].Value = _PageName;
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Subtitle", SqlDbType.NVarChar, 200));
                comm.Parameters["@Subtitle"].Value = _Subtitle;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@Department", SqlDbType.NVarChar, 50));
                comm.Parameters["@Department"].Value = _Department;
                comm.Parameters.Add(new SqlParameter("@Position", SqlDbType.NVarChar, 50));
                comm.Parameters["@Position"].Value = _Position;
                comm.Parameters.Add(new SqlParameter("@Number", SqlDbType.NVarChar, 50));
                comm.Parameters["@Number"].Value = _Number;
                comm.Parameters.Add(new SqlParameter("@Place", SqlDbType.NVarChar, 50));
                comm.Parameters["@Place"].Value = _Place;
                comm.Parameters.Add(new SqlParameter("@Education", SqlDbType.NVarChar, 50));
                comm.Parameters["@Education"].Value = _Education;
                comm.Parameters.Add(new SqlParameter("@Sex", SqlDbType.NVarChar, 50));
                comm.Parameters["@Sex"].Value = _Sex;
                comm.Parameters.Add(new SqlParameter("@Major", SqlDbType.NVarChar, 50));
                comm.Parameters["@Major"].Value = _Major;
                comm.Parameters.Add(new SqlParameter("@Wages", SqlDbType.NVarChar, 50));
                comm.Parameters["@Wages"].Value = _Wages;
                comm.Parameters.Add(new SqlParameter("@Experiences", SqlDbType.NVarChar, 50));
                comm.Parameters["@Experiences"].Value = _Experiences;
                comm.Parameters.Add(new SqlParameter("@Age", SqlDbType.NVarChar, 50));
                comm.Parameters["@Age"].Value = _Age;
                comm.Parameters.Add(new SqlParameter("@SEO_Title", SqlDbType.NVarChar, 250));
                comm.Parameters["@SEO_Title"].Value = _SEO_Title;
                comm.Parameters.Add(new SqlParameter("@SEO_Keyword", SqlDbType.NVarChar, 250));
                comm.Parameters["@SEO_Keyword"].Value = _SEO_Keyword;
                comm.Parameters.Add(new SqlParameter("@SEO_Description", SqlDbType.NVarChar, 1000));
                comm.Parameters["@SEO_Description"].Value = _SEO_Description;
                comm.Parameters.Add(new SqlParameter("@Tags", SqlDbType.NVarChar, 100));
                comm.Parameters["@Tags"].Value = _Tags;
                comm.Parameters.Add(new SqlParameter("@Visual", SqlDbType.VarChar, 50));
                comm.Parameters["@Visual"].Value = _Visual;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;
                comm.Parameters.Add(new SqlParameter("@Issue", SqlDbType.Bit));
                comm.Parameters["@Issue"].Value = _Issue;
                comm.Parameters.Add(new SqlParameter("@IsComment", SqlDbType.Bit));
                comm.Parameters["@IsComment"].Value = _IsComment;
                comm.Parameters.Add(new SqlParameter("@IsRecommend", SqlDbType.Bit));
                comm.Parameters["@IsRecommend"].Value = _IsRecommend;
                comm.Parameters.Add(new SqlParameter("@Clicks", SqlDbType.Int));
                comm.Parameters["@Clicks"].Value = _Clicks;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime));
                comm.Parameters["@StartDate"].Value = _StartDate;
                comm.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime));
                comm.Parameters["@EndDate"].Value = _EndDate;
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
                comm.Parameters.Add(new SqlParameter("@pk_Job", SqlDbType.Int));
                comm.Parameters["@pk_Job"].Value = id;
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
            Sql.SqlQuery("delete from Job_List where pk_Job=" + id);
        }

        #endregion
    }
}
