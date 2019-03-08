using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web;

namespace MojoCube.Web.Member
{
    public class List
    {
        #region 公共属性
        int _pk_Member;
        public int pk_Member
        {
            get { return _pk_Member; }
            set { _pk_Member = value; }
        }
        string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        string _UserPass;
        public string UserPass
        {
            get { return _UserPass; }
            set { _UserPass = value; }
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
        string _Phone1;
        public string Phone1
        {
            get { return _Phone1; }
            set { _Phone1 = value; }
        }
        string _Phone2;
        public string Phone2
        {
            get { return _Phone2; }
            set { _Phone2 = value; }
        }
        string _Mobile;
        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }
        string _Fax;
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        string _Country;
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
        int _CountryID;
        public int CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
        string _Province;
        public string Province
        {
            get { return _Province; }
            set { _Province = value; }
        }
        int _ProvinceID;
        public int ProvinceID
        {
            get { return _ProvinceID; }
            set { _ProvinceID = value; }
        }
        string _City;
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        int _CityID;
        public int CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }
        string _Zip;
        public string Zip
        {
            get { return _Zip; }
            set { _Zip = value; }
        }
        string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        string _Powers;
        public string Powers
        {
            get { return _Powers; }
            set { _Powers = value; }
        }
        string _Remark;
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        bool _IsLock;
        public bool IsLock
        {
            get { return _IsLock; }
            set { _IsLock = value; }
        }
        string _LastLogin;
        public string LastLogin
        {
            get { return _LastLogin; }
            set { _LastLogin = value; }
        }
        string _LastLoginIP;
        public string LastLoginIP
        {
            get { return _LastLoginIP; }
            set { _LastLoginIP = value; }
        }
        int _LoginTimes;
        public int LoginTimes
        {
            get { return _LoginTimes; }
            set { _LoginTimes = value; }
        }
        string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }
        string _CreateDate;
        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        int _TypeID;
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        bool _IsCheck;
        public bool IsCheck
        {
            get { return _IsCheck; }
            set { _IsCheck = value; }
        }
        string _CheckDate;
        public string CheckDate
        {
            get { return _CheckDate; }
            set { _CheckDate = value; }
        }
        string _CheckCode;
        public string CheckCode
        {
            get { return _CheckCode; }
            set { _CheckCode = value; }
        }
        string _AboutMe;
        public string AboutMe
        {
            get { return _AboutMe; }
            set { _AboutMe = value; }
        }
        int _Clicks;
        public int Clicks
        {
            get { return _Clicks; }
            set { _Clicks = value; }
        }
        bool _IsReceiveNews;
        public bool IsReceiveNews
        {
            get { return _IsReceiveNews; }
            set { _IsReceiveNews = value; }
        }
        bool _IsPublic;
        public bool IsPublic
        {
            get { return _IsPublic; }
            set { _IsPublic = value; }
        }
        bool _IsLockBlog;
        public bool IsLockBlog
        {
            get { return _IsLockBlog; }
            set { _IsLockBlog = value; }
        }
        string _Following;
        public string Following
        {
            get { return _Following; }
            set { _Following = value; }
        }
        string _Followers;
        public string Followers
        {
            get { return _Followers; }
            set { _Followers = value; }
        }
        string _Question;
        public string Question
        {
            get { return _Question; }
            set { _Question = value; }
        }
        string _Answer;
        public string Answer
        {
            get { return _Answer; }
            set { _Answer = value; }
        }
        string _Birthday;
        public string Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
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
                string sql = "select * from Member_List where pk_Member=@pk_Member";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Member", SqlDbType.Int));
                comm.Parameters["@pk_Member"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Member = Convert.ToInt32(dr["pk_Member"].ToString());
                    _UserName = dr["UserName"].ToString();
                    _UserPass = dr["UserPass"].ToString();
                    _NickName = dr["NickName"].ToString();
                    _FirstName = dr["FirstName"].ToString();
                    _LastName = dr["LastName"].ToString();
                    _Sex = Convert.ToInt32(dr["Sex"].ToString());
                    _Phone1 = dr["Phone1"].ToString();
                    _Phone2 = dr["Phone2"].ToString();
                    _Mobile = dr["Mobile"].ToString();
                    _Fax = dr["Fax"].ToString();
                    _Country = dr["Country"].ToString();
                    _CountryID = Convert.ToInt32(dr["CountryID"].ToString());
                    _Province = dr["Province"].ToString();
                    _ProvinceID = Convert.ToInt32(dr["ProvinceID"].ToString());
                    _City = dr["City"].ToString();
                    _CityID = Convert.ToInt32(dr["CityID"].ToString());
                    _Zip = dr["Zip"].ToString();
                    _Address = dr["Address"].ToString();
                    _Powers = dr["Powers"].ToString();
                    _Remark = dr["Remark"].ToString();
                    _Email = dr["Email"].ToString();
                    _IsLock = Convert.ToBoolean(dr["IsLock"].ToString());
                    _LastLogin = dr["LastLogin"].ToString();
                    _LastLoginIP = dr["LastLoginIP"].ToString();
                    _LoginTimes = Convert.ToInt32(dr["LoginTimes"].ToString());
                    _ImagePath = dr["ImagePath"].ToString();
                    _CreateDate = dr["CreateDate"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _IsCheck = Convert.ToBoolean(dr["IsCheck"].ToString());
                    _CheckDate = dr["CheckDate"].ToString();
                    _CheckCode = dr["CheckCode"].ToString();
                    _AboutMe = dr["AboutMe"].ToString();
                    _Clicks = Convert.ToInt32(dr["Clicks"].ToString());
                    _IsReceiveNews = Convert.ToBoolean(dr["IsReceiveNews"].ToString());
                    _IsPublic = Convert.ToBoolean(dr["IsPublic"].ToString());
                    _IsLockBlog = Convert.ToBoolean(dr["IsLockBlog"].ToString());
                    _Following = dr["Following"].ToString();
                    _Followers = dr["Followers"].ToString();
                    _Question = dr["Question"].ToString();
                    _Answer = dr["Answer"].ToString();
                    _Birthday = dr["Birthday"].ToString();
                }
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 根据用户名获取字段值
        /// </summary>
        /// <param name="username">用户名</param>
        public void GetData(string username)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Member_List where UserName=@UserName";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 100));
                comm.Parameters["@UserName"].Value = username;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Member = Convert.ToInt32(dr["pk_Member"].ToString());
                    _UserName = dr["UserName"].ToString();
                    _UserPass = dr["UserPass"].ToString();
                    _NickName = dr["NickName"].ToString();
                    _FirstName = dr["FirstName"].ToString();
                    _LastName = dr["LastName"].ToString();
                    _Sex = Convert.ToInt32(dr["Sex"].ToString());
                    _Phone1 = dr["Phone1"].ToString();
                    _Phone2 = dr["Phone2"].ToString();
                    _Mobile = dr["Mobile"].ToString();
                    _Fax = dr["Fax"].ToString();
                    _Country = dr["Country"].ToString();
                    _CountryID = Convert.ToInt32(dr["CountryID"].ToString());
                    _Province = dr["Province"].ToString();
                    _ProvinceID = Convert.ToInt32(dr["ProvinceID"].ToString());
                    _City = dr["City"].ToString();
                    _CityID = Convert.ToInt32(dr["CityID"].ToString());
                    _Zip = dr["Zip"].ToString();
                    _Address = dr["Address"].ToString();
                    _Powers = dr["Powers"].ToString();
                    _Remark = dr["Remark"].ToString();
                    _Email = dr["Email"].ToString();
                    _IsLock = Convert.ToBoolean(dr["IsLock"].ToString());
                    _LastLogin = dr["LastLogin"].ToString();
                    _LastLoginIP = dr["LastLoginIP"].ToString();
                    _LoginTimes = Convert.ToInt32(dr["LoginTimes"].ToString());
                    _ImagePath = dr["ImagePath"].ToString();
                    _CreateDate = dr["CreateDate"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _IsCheck = Convert.ToBoolean(dr["IsCheck"].ToString());
                    _CheckDate = dr["CheckDate"].ToString();
                    _CheckCode = dr["CheckCode"].ToString();
                    _AboutMe = dr["AboutMe"].ToString();
                    _Clicks = Convert.ToInt32(dr["Clicks"].ToString());
                    _IsReceiveNews = Convert.ToBoolean(dr["IsReceiveNews"].ToString());
                    _IsPublic = Convert.ToBoolean(dr["IsPublic"].ToString());
                    _IsLockBlog = Convert.ToBoolean(dr["IsLockBlog"].ToString());
                    _Following = dr["Following"].ToString();
                    _Followers = dr["Followers"].ToString();
                    _Birthday = dr["Birthday"].ToString();
                }
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 根据邮箱地址获取字段值
        /// </summary>
        /// <param name="email">邮箱地址</param>
        public void GetDataEmail(string email)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Member_List where Email=@Email";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 200));
                comm.Parameters["@Email"].Value = email;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Member = Convert.ToInt32(dr["pk_Member"].ToString());
                    _UserName = dr["UserName"].ToString();
                    _UserPass = dr["UserPass"].ToString();
                    _NickName = dr["NickName"].ToString();
                    _FirstName = dr["FirstName"].ToString();
                    _LastName = dr["LastName"].ToString();
                    _Sex = Convert.ToInt32(dr["Sex"].ToString());
                    _Phone1 = dr["Phone1"].ToString();
                    _Phone2 = dr["Phone2"].ToString();
                    _Mobile = dr["Mobile"].ToString();
                    _Fax = dr["Fax"].ToString();
                    _Country = dr["Country"].ToString();
                    _CountryID = Convert.ToInt32(dr["CountryID"].ToString());
                    _Province = dr["Province"].ToString();
                    _ProvinceID = Convert.ToInt32(dr["ProvinceID"].ToString());
                    _City = dr["City"].ToString();
                    _CityID = Convert.ToInt32(dr["CityID"].ToString());
                    _Zip = dr["Zip"].ToString();
                    _Address = dr["Address"].ToString();
                    _Powers = dr["Powers"].ToString();
                    _Remark = dr["Remark"].ToString();
                    _Email = dr["Email"].ToString();
                    _IsLock = Convert.ToBoolean(dr["IsLock"].ToString());
                    _LastLogin = dr["LastLogin"].ToString();
                    _LastLoginIP = dr["LastLoginIP"].ToString();
                    _LoginTimes = Convert.ToInt32(dr["LoginTimes"].ToString());
                    _ImagePath = dr["ImagePath"].ToString();
                    _CreateDate = dr["CreateDate"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _IsCheck = Convert.ToBoolean(dr["IsCheck"].ToString());
                    _CheckDate = dr["CheckDate"].ToString();
                    _CheckCode = dr["CheckCode"].ToString();
                    _AboutMe = dr["AboutMe"].ToString();
                    _Clicks = Convert.ToInt32(dr["Clicks"].ToString());
                    _IsReceiveNews = Convert.ToBoolean(dr["IsReceiveNews"].ToString());
                    _IsPublic = Convert.ToBoolean(dr["IsPublic"].ToString());
                    _IsLockBlog = Convert.ToBoolean(dr["IsLockBlog"].ToString());
                    _Following = dr["Following"].ToString();
                    _Followers = dr["Followers"].ToString();
                    _Birthday = dr["Birthday"].ToString();
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
                string sql = "insert into Member_List(UserName,UserPass,NickName,FirstName,LastName,Sex,Phone1,Phone2,Mobile,Fax,Country,CountryID,Province,ProvinceID,City,CityID,Zip,Address,Powers,Remark,Email,IsLock,LastLogin,LastLoginIP,LoginTimes,ImagePath,CreateDate,TypeID,IsCheck,CheckDate,CheckCode,AboutMe,Clicks,IsReceiveNews,IsPublic,IsLockBlog,Following,Followers,Question,Answer,Birthday) values (@UserName,@UserPass,@NickName,@FirstName,@LastName,@Sex,@Phone1,@Phone2,@Mobile,@Fax,@Country,@CountryID,@Province,@ProvinceID,@City,@CityID,@Zip,@Address,@Powers,@Remark,@Email,@IsLock,@LastLogin,@LastLoginIP,@LoginTimes,@ImagePath,@CreateDate,@TypeID,@IsCheck,@CheckDate,@CheckCode,@AboutMe,@Clicks,@IsReceiveNews,@IsPublic,@IsLockBlog,@Following,@Followers,@Question,@Answer,@Birthday)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 50));
                comm.Parameters["@UserName"].Value = _UserName;
                comm.Parameters.Add(new SqlParameter("@UserPass", SqlDbType.NVarChar, 100));
                comm.Parameters["@UserPass"].Value = _UserPass;
                comm.Parameters.Add(new SqlParameter("@NickName", SqlDbType.NVarChar, 50));
                comm.Parameters["@NickName"].Value = _NickName;
                comm.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 50));
                comm.Parameters["@FirstName"].Value = _FirstName;
                comm.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 50));
                comm.Parameters["@LastName"].Value = _LastName;
                comm.Parameters.Add(new SqlParameter("@Sex", SqlDbType.Int));
                comm.Parameters["@Sex"].Value = _Sex;
                comm.Parameters.Add(new SqlParameter("@Phone1", SqlDbType.NVarChar, 50));
                comm.Parameters["@Phone1"].Value = _Phone1;
                comm.Parameters.Add(new SqlParameter("@Phone2", SqlDbType.NVarChar, 50));
                comm.Parameters["@Phone2"].Value = _Phone2;
                comm.Parameters.Add(new SqlParameter("@Mobile", SqlDbType.NVarChar, 50));
                comm.Parameters["@Mobile"].Value = _Mobile;
                comm.Parameters.Add(new SqlParameter("@Fax", SqlDbType.NVarChar, 50));
                comm.Parameters["@Fax"].Value = _Fax;
                comm.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar, 100));
                comm.Parameters["@Country"].Value = _Country;
                comm.Parameters.Add(new SqlParameter("@CountryID", SqlDbType.Int));
                comm.Parameters["@CountryID"].Value = _CountryID;
                comm.Parameters.Add(new SqlParameter("@Province", SqlDbType.NVarChar, 100));
                comm.Parameters["@Province"].Value = _Province;
                comm.Parameters.Add(new SqlParameter("@ProvinceID", SqlDbType.Int));
                comm.Parameters["@ProvinceID"].Value = _ProvinceID;
                comm.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 100));
                comm.Parameters["@City"].Value = _City;
                comm.Parameters.Add(new SqlParameter("@CityID", SqlDbType.Int));
                comm.Parameters["@CityID"].Value = _CityID;
                comm.Parameters.Add(new SqlParameter("@Zip", SqlDbType.NVarChar, 50));
                comm.Parameters["@Zip"].Value = _Zip;
                comm.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 200));
                comm.Parameters["@Address"].Value = _Address;
                comm.Parameters.Add(new SqlParameter("@Powers", SqlDbType.NVarChar, 100));
                comm.Parameters["@Powers"].Value = _Powers;
                comm.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 200));
                comm.Parameters["@Remark"].Value = _Remark;
                comm.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 200));
                comm.Parameters["@Email"].Value = _Email;
                comm.Parameters.Add(new SqlParameter("@IsLock", SqlDbType.Bit));
                comm.Parameters["@IsLock"].Value = _IsLock;
                comm.Parameters.Add(new SqlParameter("@LastLogin", SqlDbType.DateTime));
                comm.Parameters["@LastLogin"].Value = _LastLogin;
                comm.Parameters.Add(new SqlParameter("@LastLoginIP", SqlDbType.NVarChar, 50));
                comm.Parameters["@LastLoginIP"].Value = _LastLoginIP;
                comm.Parameters.Add(new SqlParameter("@LoginTimes", SqlDbType.Int));
                comm.Parameters["@LoginTimes"].Value = _LoginTimes;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@IsCheck", SqlDbType.Bit));
                comm.Parameters["@IsCheck"].Value = _IsCheck;
                comm.Parameters.Add(new SqlParameter("@CheckDate", SqlDbType.DateTime));
                comm.Parameters["@CheckDate"].Value = _CheckDate;
                comm.Parameters.Add(new SqlParameter("@CheckCode", SqlDbType.NVarChar, 100));
                comm.Parameters["@CheckCode"].Value = _CheckCode;
                comm.Parameters.Add(new SqlParameter("@AboutMe", SqlDbType.NVarChar, -1));
                comm.Parameters["@AboutMe"].Value = _AboutMe;
                comm.Parameters.Add(new SqlParameter("@Clicks", SqlDbType.Int));
                comm.Parameters["@Clicks"].Value = _Clicks;
                comm.Parameters.Add(new SqlParameter("@IsReceiveNews", SqlDbType.Bit));
                comm.Parameters["@IsReceiveNews"].Value = _IsReceiveNews;
                comm.Parameters.Add(new SqlParameter("@IsPublic", SqlDbType.Bit));
                comm.Parameters["@IsPublic"].Value = _IsPublic;
                comm.Parameters.Add(new SqlParameter("@IsLockBlog", SqlDbType.Bit));
                comm.Parameters["@IsLockBlog"].Value = _IsLockBlog;
                comm.Parameters.Add(new SqlParameter("@Following", SqlDbType.NVarChar, -1));
                comm.Parameters["@Following"].Value = _Following;
                comm.Parameters.Add(new SqlParameter("@Followers", SqlDbType.NVarChar, -1));
                comm.Parameters["@Followers"].Value = _Followers;
                comm.Parameters.Add(new SqlParameter("@Question", SqlDbType.NVarChar, 200));
                comm.Parameters["@Question"].Value = _Question;
                comm.Parameters.Add(new SqlParameter("@Answer", SqlDbType.NVarChar, 200));
                comm.Parameters["@Answer"].Value = _Answer;
                comm.Parameters.Add(new SqlParameter("@Birthday", SqlDbType.DateTime));
                comm.Parameters["@Birthday"].Value = _Birthday;
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
                string sql = "update Member_List set UserName=@UserName,UserPass=@UserPass,NickName=@NickName,FirstName=@FirstName,LastName=@LastName,Sex=@Sex,Phone1=@Phone1,Phone2=@Phone2,Mobile=@Mobile,Fax=@Fax,Country=@Country,CountryID=@CountryID,Province=@Province,ProvinceID=@ProvinceID,City=@City,CityID=@CityID,Zip=@Zip,Address=@Address,Powers=@Powers,Remark=@Remark,Email=@Email,IsLock=@IsLock,LastLogin=@LastLogin,LastLoginIP=@LastLoginIP,LoginTimes=@LoginTimes,ImagePath=@ImagePath,CreateDate=@CreateDate,TypeID=@TypeID,IsCheck=@IsCheck,CheckDate=@CheckDate,CheckCode=@CheckCode,AboutMe=@AboutMe,Clicks=@Clicks,IsReceiveNews=@IsReceiveNews,IsPublic=@IsPublic,IsLockBlog=@IsLockBlog,Following=@Following,Followers=@Followers,Question=@Question,Answer=@Answer,Birthday=@Birthday where pk_Member=@pk_Member";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 50));
                comm.Parameters["@UserName"].Value = _UserName;
                comm.Parameters.Add(new SqlParameter("@UserPass", SqlDbType.NVarChar, 100));
                comm.Parameters["@UserPass"].Value = _UserPass;
                comm.Parameters.Add(new SqlParameter("@NickName", SqlDbType.NVarChar, 50));
                comm.Parameters["@NickName"].Value = _NickName;
                comm.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 50));
                comm.Parameters["@FirstName"].Value = _FirstName;
                comm.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 50));
                comm.Parameters["@LastName"].Value = _LastName;
                comm.Parameters.Add(new SqlParameter("@Sex", SqlDbType.Int));
                comm.Parameters["@Sex"].Value = _Sex;
                comm.Parameters.Add(new SqlParameter("@Phone1", SqlDbType.NVarChar, 50));
                comm.Parameters["@Phone1"].Value = _Phone1;
                comm.Parameters.Add(new SqlParameter("@Phone2", SqlDbType.NVarChar, 50));
                comm.Parameters["@Phone2"].Value = _Phone2;
                comm.Parameters.Add(new SqlParameter("@Mobile", SqlDbType.NVarChar, 50));
                comm.Parameters["@Mobile"].Value = _Mobile;
                comm.Parameters.Add(new SqlParameter("@Fax", SqlDbType.NVarChar, 50));
                comm.Parameters["@Fax"].Value = _Fax;
                comm.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar, 100));
                comm.Parameters["@Country"].Value = _Country;
                comm.Parameters.Add(new SqlParameter("@CountryID", SqlDbType.Int));
                comm.Parameters["@CountryID"].Value = _CountryID;
                comm.Parameters.Add(new SqlParameter("@Province", SqlDbType.NVarChar, 100));
                comm.Parameters["@Province"].Value = _Province;
                comm.Parameters.Add(new SqlParameter("@ProvinceID", SqlDbType.Int));
                comm.Parameters["@ProvinceID"].Value = _ProvinceID;
                comm.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 100));
                comm.Parameters["@City"].Value = _City;
                comm.Parameters.Add(new SqlParameter("@CityID", SqlDbType.Int));
                comm.Parameters["@CityID"].Value = _CityID;
                comm.Parameters.Add(new SqlParameter("@Zip", SqlDbType.NVarChar, 50));
                comm.Parameters["@Zip"].Value = _Zip;
                comm.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 200));
                comm.Parameters["@Address"].Value = _Address;
                comm.Parameters.Add(new SqlParameter("@Powers", SqlDbType.NVarChar, 100));
                comm.Parameters["@Powers"].Value = _Powers;
                comm.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 200));
                comm.Parameters["@Remark"].Value = _Remark;
                comm.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 200));
                comm.Parameters["@Email"].Value = _Email;
                comm.Parameters.Add(new SqlParameter("@IsLock", SqlDbType.Bit));
                comm.Parameters["@IsLock"].Value = _IsLock;
                comm.Parameters.Add(new SqlParameter("@LastLogin", SqlDbType.DateTime));
                comm.Parameters["@LastLogin"].Value = _LastLogin;
                comm.Parameters.Add(new SqlParameter("@LastLoginIP", SqlDbType.NVarChar, 50));
                comm.Parameters["@LastLoginIP"].Value = _LastLoginIP;
                comm.Parameters.Add(new SqlParameter("@LoginTimes", SqlDbType.Int));
                comm.Parameters["@LoginTimes"].Value = _LoginTimes;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@IsCheck", SqlDbType.Bit));
                comm.Parameters["@IsCheck"].Value = _IsCheck;
                comm.Parameters.Add(new SqlParameter("@CheckDate", SqlDbType.DateTime));
                comm.Parameters["@CheckDate"].Value = _CheckDate;
                comm.Parameters.Add(new SqlParameter("@CheckCode", SqlDbType.NVarChar, 100));
                comm.Parameters["@CheckCode"].Value = _CheckCode;
                comm.Parameters.Add(new SqlParameter("@AboutMe", SqlDbType.NVarChar, -1));
                comm.Parameters["@AboutMe"].Value = _AboutMe;
                comm.Parameters.Add(new SqlParameter("@Clicks", SqlDbType.Int));
                comm.Parameters["@Clicks"].Value = _Clicks;
                comm.Parameters.Add(new SqlParameter("@IsReceiveNews", SqlDbType.Bit));
                comm.Parameters["@IsReceiveNews"].Value = _IsReceiveNews;
                comm.Parameters.Add(new SqlParameter("@IsPublic", SqlDbType.Bit));
                comm.Parameters["@IsPublic"].Value = _IsPublic;
                comm.Parameters.Add(new SqlParameter("@IsLockBlog", SqlDbType.Bit));
                comm.Parameters["@IsLockBlog"].Value = _IsLockBlog;
                comm.Parameters.Add(new SqlParameter("@Following", SqlDbType.NVarChar, -1));
                comm.Parameters["@Following"].Value = _Following;
                comm.Parameters.Add(new SqlParameter("@Followers", SqlDbType.NVarChar, -1));
                comm.Parameters["@Followers"].Value = _Followers;
                comm.Parameters.Add(new SqlParameter("@Question", SqlDbType.NVarChar, 200));
                comm.Parameters["@Question"].Value = _Question;
                comm.Parameters.Add(new SqlParameter("@Answer", SqlDbType.NVarChar, 200));
                comm.Parameters["@Answer"].Value = _Answer;
                comm.Parameters.Add(new SqlParameter("@Birthday", SqlDbType.DateTime));
                comm.Parameters["@Birthday"].Value = _Birthday;
                comm.Parameters.Add(new SqlParameter("@pk_Member", SqlDbType.Int));
                comm.Parameters["@pk_Member"].Value = id;
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
            Sql.SqlQuery("delete from Member_List where pk_Member=" + id);
        }

        /// <summary>
        /// 检查用户名和电子邮箱是否符合
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="email">电子邮箱</param>
        /// <returns></returns>
        public bool ChkUser(string username, string email)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Member_List where UserName=@UserName and Email=@Email";
                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 100));
                comm.Parameters["@UserName"].Value = username;
                comm.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 200));
                comm.Parameters["@Email"].Value = email;

                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 检查用户名是否已经存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public bool ChkUserName(string username)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Member_List where UserName=@UserName";
                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 100));
                comm.Parameters["@UserName"].Value = username;

                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 检查邮箱地址是否已经存在
        /// </summary>
        /// <param name="email">邮箱地址</param>
        /// <returns></returns>
        public bool ChkUserEmail(string email)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Member_List where Email=@Email";
                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 200));
                comm.Parameters["@Email"].Value = email;

                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 根据ID修改密码
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="newPass">新密码</param>
        public void UpdateMember_UserPass(int id, string newPass)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update Member_List set UserPass=@UserPass where pk_Member=@pk_Member";
                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.Add(new SqlParameter("@pk_Member", SqlDbType.Int));
                comm.Parameters["@pk_Member"].Value = id;
                comm.Parameters.Add(new SqlParameter("@UserPass", SqlDbType.NVarChar, 100));
                comm.Parameters["@UserPass"].Value = newPass;

                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 根据邮箱地址修改密码
        /// </summary>
        /// <param name="email">邮箱地址</param>
        /// <param name="newPass">新密码</param>
        public void UpdateMember_UserPass(string email, string newPass)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update Member_List set UserPass=@UserPass where Email=@Email";
                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 200));
                comm.Parameters["@Email"].Value = email;
                comm.Parameters.Add(new SqlParameter("@UserPass", SqlDbType.NVarChar, 100));
                comm.Parameters["@UserPass"].Value = newPass;

                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 更新最后一次登录信息
        /// </summary>
        /// <param name="id">ID</param>
        public void UpdateLastLogin(int id)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update Member_List set LastLogin=@LastLogin,LastLoginIP=@LastLoginIP,LoginTimes=@LoginTimes where pk_Member=@pk_Member";
                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.Add(new SqlParameter("@pk_Member", SqlDbType.Int));
                comm.Parameters["@pk_Member"].Value = id;
                comm.Parameters.Add(new SqlParameter("@LastLogin", SqlDbType.DateTime));
                comm.Parameters["@LastLogin"].Value = DateTime.Now;
                comm.Parameters.Add(new SqlParameter("@LastLoginIP", SqlDbType.NVarChar, 50));
                comm.Parameters["@LastLoginIP"].Value = _LastLoginIP;
                comm.Parameters.Add(new SqlParameter("@LoginTimes", SqlDbType.Int));
                comm.Parameters["@LoginTimes"].Value = _LoginTimes + 1;

                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 更新用户头像
        /// </summary>
        /// <param name="id">ID</param>
        public void UpdateMember_UserImagePath(int id)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update Member_List set ImagePath=@ImagePath where pk_Member=@pk_Member";
                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.Add(new SqlParameter("@pk_Member", SqlDbType.Int));
                comm.Parameters["@pk_Member"].Value = id;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;

                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 是否锁定用户
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="isLock">是否锁定</param>
        public void UpdateMember_UserIsLock(int id, bool isLock)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update Member_List set IsLock=@IsLock where pk_Member=@pk_Member";
                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.Add(new SqlParameter("@pk_Member", SqlDbType.Int));
                comm.Parameters["@pk_Member"].Value = id;
                comm.Parameters.Add(new SqlParameter("@IsLock", SqlDbType.Bit));
                comm.Parameters["@IsLock"].Value = isLock;

                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 用户注册时，确认了邮件之后解除锁定
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="code">确认码</param>
        public void UpdateMember_CheckCode(string username, string code)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update Member_List set IsCheck=@IsCheck,IsLock=@IsLock,CheckDate=@CheckDate where UserName=@UserName and CheckCode=@CheckCode";
                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.Add(new SqlParameter("@IsCheck", SqlDbType.Bit));
                comm.Parameters["@IsCheck"].Value = true;
                comm.Parameters.Add(new SqlParameter("@IsLock", SqlDbType.Bit));
                comm.Parameters["@IsLock"].Value = false;
                comm.Parameters.Add(new SqlParameter("@CheckDate", SqlDbType.DateTime));
                comm.Parameters["@CheckDate"].Value = DateTime.Now;
                comm.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 50));
                comm.Parameters["@UserName"].Value = username;
                comm.Parameters.Add(new SqlParameter("@CheckCode", SqlDbType.NVarChar, 100));
                comm.Parameters["@CheckCode"].Value = code;

                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 是否锁定用户博客
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="isLock">是否锁定</param>
        public void UpdateMember_UserIsLockBlog(int id, bool isLock)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update Member_List set IsLockBlog=@IsLockBlog where pk_Member=@pk_Member";
                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.Add(new SqlParameter("@pk_Member", SqlDbType.Int));
                comm.Parameters["@pk_Member"].Value = id;
                comm.Parameters.Add(new SqlParameter("@IsLockBlog", SqlDbType.Bit));
                comm.Parameters["@IsLockBlog"].Value = isLock;

                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 更新关注
        /// </summary>
        /// <param name="id">ID</param>
        public void UpdateMember_Following(int id)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update Member_List set Following=@Following where pk_Member=@pk_Member";
                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.Add(new SqlParameter("@pk_Member", SqlDbType.Int));
                comm.Parameters["@pk_Member"].Value = id;
                comm.Parameters.Add(new SqlParameter("@Following", SqlDbType.NVarChar, -1));
                comm.Parameters["@Following"].Value = _Following;

                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 更新粉丝
        /// </summary>
        /// <param name="id">ID</param>
        public void UpdateMember_Followers(int id)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update Member_List set Followers=@Followers where pk_Member=@pk_Member";
                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.Add(new SqlParameter("@pk_Member", SqlDbType.Int));
                comm.Parameters["@pk_Member"].Value = id;
                comm.Parameters.Add(new SqlParameter("@Followers", SqlDbType.NVarChar, -1));
                comm.Parameters["@Followers"].Value = _Followers;

                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        #region  登录权限相关

        /// <summary>
        /// 检查是否登录并具有权限
        /// </summary>
        public static void ChkLogin()
        {
            if (!IsLogin())
            {
                HttpContext.Current.Response.Redirect(Site.Cache.GetUrlExtension("~/Default", "zh-cn"));
                HttpContext.Current.Response.End();
            }
        }

        /// <summary>
        /// 检查是否登录并具有权限
        /// </summary>
        /// <param name="url">需要返回的URL</param>
        public static void ChkLogin(string url)
        {
            if (!IsLogin())
            {
                HttpContext.Current.Response.Redirect(Site.Cache.GetUrlExtension("~/Login", "zh-cn") + "?url=" + url);
                HttpContext.Current.Response.End();
            }
        }

        //判断用户是否登录
        public static bool IsLogin()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["Member_UserID"] != null && HttpContext.Current.Session["Member_UserName"] != null)
            {
                SqlConnection conn = new SqlConnection(Connection.ConnString());
                try
                {
                    conn.Open();
                    string sql = "select * from Member_List where IsLock=0 and pk_Member=" + HttpContext.Current.Session["Member_UserID"].ToString() + " and UserName='" + HttpContext.Current.Session["Member_UserName"].ToString() + "'";
                    SqlCommand comm = new SqlCommand(sql, conn);
                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                return false;
            }
        }

        //判断用户是否用户
        public bool IsUser(string userName, string passWord)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Member_List where UserName=@UserName and UserPass=@UserPass";
                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 50));
                comm.Parameters["@UserName"].Value = userName;
                comm.Parameters.Add(new SqlParameter("@UserPass", SqlDbType.NVarChar, 200));
                comm.Parameters["@UserPass"].Value = passWord;

                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Member = Convert.ToInt32(dr["pk_Member"].ToString());
                    _UserName = dr["UserName"].ToString();
                    _UserPass = dr["UserPass"].ToString();
                    _NickName = dr["NickName"].ToString();
                    _FirstName = dr["FirstName"].ToString();
                    _LastName = dr["LastName"].ToString();
                    _Sex = Convert.ToInt32(dr["Sex"].ToString());
                    _Phone1 = dr["Phone1"].ToString();
                    _Phone2 = dr["Phone2"].ToString();
                    _Mobile = dr["Mobile"].ToString();
                    _Fax = dr["Fax"].ToString();
                    _Country = dr["Country"].ToString();
                    _CountryID = Convert.ToInt32(dr["CountryID"].ToString());
                    _Province = dr["Province"].ToString();
                    _ProvinceID = Convert.ToInt32(dr["ProvinceID"].ToString());
                    _City = dr["City"].ToString();
                    _CityID = Convert.ToInt32(dr["CityID"].ToString());
                    _Zip = dr["Zip"].ToString();
                    _Address = dr["Address"].ToString();
                    _Powers = dr["Powers"].ToString();
                    _Remark = dr["Remark"].ToString();
                    _Email = dr["Email"].ToString();
                    _IsLock = Convert.ToBoolean(dr["IsLock"].ToString());
                    _LastLogin = dr["LastLogin"].ToString();
                    _LastLoginIP = dr["LastLoginIP"].ToString();
                    _LoginTimes = Convert.ToInt32(dr["LoginTimes"].ToString());
                    _ImagePath = dr["ImagePath"].ToString();
                    _CreateDate = dr["CreateDate"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _IsCheck = Convert.ToBoolean(dr["IsCheck"].ToString());
                    _CheckDate = dr["CheckDate"].ToString();
                    _CheckCode = dr["CheckCode"].ToString();
                    _AboutMe = dr["AboutMe"].ToString();
                    _Clicks = Convert.ToInt32(dr["Clicks"].ToString());
                    _IsReceiveNews = Convert.ToBoolean(dr["IsReceiveNews"].ToString());
                    _IsPublic = Convert.ToBoolean(dr["IsPublic"].ToString());
                    _IsLockBlog = Convert.ToBoolean(dr["IsLockBlog"].ToString());
                    _Following = dr["Following"].ToString();
                    _Followers = dr["Followers"].ToString();
                    _Birthday = dr["Birthday"].ToString();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        #region  防止Session丢失
        public static void WriteSession()
        {
            if (HttpContext.Current.Session["Member_UserID"] == null)
            {
                ChkCookies("Member_UserID");
                ChkCookies("Member_UserName");
                ChkCookies("Member_UserFirstName");
                ChkCookies("Member_UserLastName");
                ChkCookies("Member_UserLastLogin");
                ChkCookies("Member_UserImagePath");
                ChkCookies("Member_UserTypeID");
            }
        }
        public static void ChkCookies(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                HttpContext.Current.Session[name] = HttpContext.Current.Request.Cookies[name].Value;
            }
        }
        #endregion

        #region  登陆系统时写Session和Cookies
        public static void SetLogin()
        {
            SetLogin("Member_UserID");
            SetLogin("Member_UserName");
            SetLogin("Member_UserFirstName");
            SetLogin("Member_UserLastName");
            SetLogin("Member_UserLastLogin");
            SetLogin("Member_UserImagePath");
            SetLogin("Member_UserTypeID");
        }
        public static void SetLogin(string name)
        {
            HttpContext.Current.Response.Cookies[name].Value = HttpContext.Current.Session[name].ToString();
            HttpContext.Current.Response.Cookies[name].Expires = DateTime.Now.AddMonths(1);
        }
        #endregion

        #region  退出系统时清除Session和Cookies
        public static void SetLogout()
        {
            SetLogout("Member_UserID");
            SetLogout("Member_UserName");
            SetLogout("Member_UserFirstName");
            SetLogout("Member_UserLastName");
            SetLogout("Member_UserLastLogin");
            SetLogout("Member_UserImagePath");
            SetLogout("Member_UserTypeID");
        }
        public static void SetLogout(string name)
        {
            HttpContext.Current.Session.Remove(name);
            HttpContext.Current.Response.Cookies[name].Expires = DateTime.Now.AddDays(-1);
        }
        #endregion

        //设置登录后的Session
        public void SetLoginSession()
        {
            HttpContext.Current.Session["Member_UserID"] = pk_Member;
            HttpContext.Current.Session["Member_UserName"] = UserName;
            HttpContext.Current.Session["Member_UserFirstName"] = FirstName;
            HttpContext.Current.Session["Member_UserLastName"] = LastName;
            HttpContext.Current.Session["Member_UserLastLogin"] = LastLogin;
            HttpContext.Current.Session["Member_UserImagePath"] = ImagePath;
            HttpContext.Current.Session["Member_UserTypeID"] = TypeID;
        }

        //退出清空Session
        public static void RemoveSession()
        {
            HttpContext.Current.Session.Remove("Member_UserID");
            HttpContext.Current.Session.Remove("Member_UserName");
            HttpContext.Current.Session.Remove("Member_UserFirstName");
            HttpContext.Current.Session.Remove("Member_UserLastName");
            HttpContext.Current.Session.Remove("Member_UserLastLogin");
            HttpContext.Current.Session.Remove("Member_UserImagePath");
            HttpContext.Current.Session.Remove("Member_UserTypeID");
        }
        #endregion

        #endregion
    }
}
