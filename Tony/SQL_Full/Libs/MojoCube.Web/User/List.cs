using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.User
{
    public class List
    {
        #region 公共属性
        int _pk_User;
        public int pk_User
        {
            get { return _pk_User; }
            set { _pk_User = value; }
        }
        string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        int _TypeID;
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        int _fk_Department;
        public int fk_Department
        {
            get { return _fk_Department; }
            set { _fk_Department = value; }
        }
        int _RoleValue;
        public int RoleValue
        {
            get { return _RoleValue; }
            set { _RoleValue = value; }
        }
        string _RoleList;
        public string RoleList
        {
            get { return _RoleList; }
            set { _RoleList = value; }
        }
        int _Position;
        public int Position
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
        string _Skin;
        public string Skin
        {
            get { return _Skin; }
            set { _Skin = value; }
        }
        string _Language;
        public string Language
        {
            get { return _Language; }
            set { _Language = value; }
        }
        bool _IsLock;
        public bool IsLock
        {
            get { return _IsLock; }
            set { _IsLock = value; }
        }
        string _LastLoginIP;
        public string LastLoginIP
        {
            get { return _LastLoginIP; }
            set { _LastLoginIP = value; }
        }
        string _LastLoginTime;
        public string LastLoginTime
        {
            get { return _LastLoginTime; }
            set { _LastLoginTime = value; }
        }
        string _NickName;
        public string NickName
        {
            get { return _NickName; }
            set { _NickName = value; }
        }
        string _FullName;
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }
        string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        string _MiddleName;
        public string MiddleName
        {
            get { return _MiddleName; }
            set { _MiddleName = value; }
        }
        string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
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
        string _Email1;
        public string Email1
        {
            get { return _Email1; }
            set { _Email1 = value; }
        }
        string _Email2;
        public string Email2
        {
            get { return _Email2; }
            set { _Email2 = value; }
        }
        string _Fax;
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        string _Line;
        public string Line
        {
            get { return _Line; }
            set { _Line = value; }
        }
        string _Wechat;
        public string Wechat
        {
            get { return _Wechat; }
            set { _Wechat = value; }
        }
        string _QQ;
        public string QQ
        {
            get { return _QQ; }
            set { _QQ = value; }
        }
        string _Facebook;
        public string Facebook
        {
            get { return _Facebook; }
            set { _Facebook = value; }
        }
        string _Twitter;
        public string Twitter
        {
            get { return _Twitter; }
            set { _Twitter = value; }
        }
        string _Linkedin;
        public string Linkedin
        {
            get { return _Linkedin; }
            set { _Linkedin = value; }
        }
        string _ZipCode;
        public string ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }
        string _Place;
        public string Place
        {
            get { return _Place; }
            set { _Place = value; }
        }
        string _Address1;
        public string Address1
        {
            get { return _Address1; }
            set { _Address1 = value; }
        }
        string _Address2;
        public string Address2
        {
            get { return _Address2; }
            set { _Address2 = value; }
        }
        int _Province;
        public int Province
        {
            get { return _Province; }
            set { _Province = value; }
        }
        int _City;
        public int City
        {
            get { return _City; }
            set { _City = value; }
        }
        int _County;
        public int County
        {
            get { return _County; }
            set { _County = value; }
        }
        int _Zone;
        public int Zone
        {
            get { return _Zone; }
            set { _Zone = value; }
        }
        int _Sex;
        public int Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        int _Height;
        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        int _Weight;
        public int Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
        string _Birthday;
        public string Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }
        string _Education;
        public string Education
        {
            get { return _Education; }
            set { _Education = value; }
        }
        string _School;
        public string School
        {
            get { return _School; }
            set { _School = value; }
        }
        string _ImagePath1;
        public string ImagePath1
        {
            get { return _ImagePath1; }
            set { _ImagePath1 = value; }
        }
        string _ImagePath2;
        public string ImagePath2
        {
            get { return _ImagePath2; }
            set { _ImagePath2 = value; }
        }
        string _IDCardPath;
        public string IDCardPath
        {
            get { return _IDCardPath; }
            set { _IDCardPath = value; }
        }
        string _ResumePath;
        public string ResumePath
        {
            get { return _ResumePath; }
            set { _ResumePath = value; }
        }
        decimal _Wages;
        public decimal Wages
        {
            get { return _Wages; }
            set { _Wages = value; }
        }
        string _BankAccount;
        public string BankAccount
        {
            get { return _BankAccount; }
            set { _BankAccount = value; }
        }
        string _IDNumber;
        public string IDNumber
        {
            get { return _IDNumber; }
            set { _IDNumber = value; }
        }
        string _Source;
        public string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }
        string _Note;
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
        string _Remark;
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        string _EntryTime;
        public string EntryTime
        {
            get { return _EntryTime; }
            set { _EntryTime = value; }
        }
        bool _IsQuit;
        public bool IsQuit
        {
            get { return _IsQuit; }
            set { _IsQuit = value; }
        }
        string _QuitTime;
        public string QuitTime
        {
            get { return _QuitTime; }
            set { _QuitTime = value; }
        }
        int _ShowHistory;
        public int ShowHistory
        {
            get { return _ShowHistory; }
            set { _ShowHistory = value; }
        }
        int _fk_Company;
        public int fk_Company
        {
            get { return _fk_Company; }
            set { _fk_Company = value; }
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
                string sql = "select * from User_List where pk_User=@pk_User";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_User", SqlDbType.Int));
                comm.Parameters["@pk_User"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_User = Convert.ToInt32(dr["pk_User"].ToString());
                    _UserName = dr["UserName"].ToString();
                    _Password = dr["Password"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _fk_Department = Convert.ToInt32(dr["fk_Department"].ToString());
                    _RoleValue = Convert.ToInt32(dr["RoleValue"].ToString());
                    _RoleList = dr["RoleList"].ToString();
                    _Position = Convert.ToInt32(dr["Position"].ToString());
                    _Number = dr["Number"].ToString();
                    _Skin = dr["Skin"].ToString();
                    _Language = dr["Language"].ToString();
                    _IsLock = Convert.ToBoolean(dr["IsLock"].ToString());
                    _LastLoginIP = dr["LastLoginIP"].ToString();
                    _LastLoginTime = dr["LastLoginTime"].ToString();
                    _NickName = dr["NickName"].ToString();
                    _FullName = dr["FullName"].ToString();
                    _FirstName = dr["FirstName"].ToString();
                    _MiddleName = dr["MiddleName"].ToString();
                    _LastName = dr["LastName"].ToString();
                    _Phone1 = dr["Phone1"].ToString();
                    _Phone2 = dr["Phone2"].ToString();
                    _Email1 = dr["Email1"].ToString();
                    _Email2 = dr["Email2"].ToString();
                    _Fax = dr["Fax"].ToString();
                    _Line = dr["Line"].ToString();
                    _Wechat = dr["Wechat"].ToString();
                    _QQ = dr["QQ"].ToString();
                    _Facebook = dr["Facebook"].ToString();
                    _Twitter = dr["Twitter"].ToString();
                    _Linkedin = dr["Linkedin"].ToString();
                    _ZipCode = dr["ZipCode"].ToString();
                    _Place = dr["Place"].ToString();
                    _Address1 = dr["Address1"].ToString();
                    _Address2 = dr["Address2"].ToString();
                    _Province = Convert.ToInt32(dr["Province"].ToString());
                    _City = Convert.ToInt32(dr["City"].ToString());
                    _County = Convert.ToInt32(dr["County"].ToString());
                    _Zone = Convert.ToInt32(dr["Zone"].ToString());
                    _Sex = Convert.ToInt32(dr["Sex"].ToString());
                    _Height = Convert.ToInt32(dr["Height"].ToString());
                    _Weight = Convert.ToInt32(dr["Weight"].ToString());
                    _Birthday = dr["Birthday"].ToString();
                    _Education = dr["Education"].ToString();
                    _School = dr["School"].ToString();
                    _ImagePath1 = dr["ImagePath1"].ToString();
                    _ImagePath2 = dr["ImagePath2"].ToString();
                    _IDCardPath = dr["IDCardPath"].ToString();
                    _ResumePath = dr["ResumePath"].ToString();
                    _Wages = Convert.ToDecimal(dr["Wages"].ToString());
                    _BankAccount = dr["BankAccount"].ToString();
                    _IDNumber = dr["IDNumber"].ToString();
                    _Source = dr["Source"].ToString();
                    _Note = dr["Note"].ToString();
                    _Remark = dr["Remark"].ToString();
                    _EntryTime = dr["EntryTime"].ToString();
                    _IsQuit = Convert.ToBoolean(dr["IsQuit"].ToString());
                    _QuitTime = dr["QuitTime"].ToString();
                    _ShowHistory = Convert.ToInt32(dr["ShowHistory"].ToString());
                    _fk_Company = Convert.ToInt32(dr["fk_Company"].ToString());
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
                string sql = "insert into User_List(UserName,Password,TypeID,fk_Department,RoleValue,RoleList,Position,Number,Skin,Language,IsLock,LastLoginIP,LastLoginTime,NickName,FullName,FirstName,MiddleName,LastName,Phone1,Phone2,Email1,Email2,Fax,Line,Wechat,QQ,Facebook,Twitter,Linkedin,ZipCode,Place,Address1,Address2,Province,City,County,Zone,Sex,Height,Weight,Birthday,Education,School,ImagePath1,ImagePath2,IDCardPath,ResumePath,Wages,BankAccount,IDNumber,Source,Note,Remark,EntryTime,IsQuit,QuitTime,fk_Company,CreateUser,CreateDate,ModifyUser,ModifyDate) values (@UserName,@Password,@TypeID,@fk_Department,@RoleValue,@RoleList,@Position,@Number,@Skin,@Language,@IsLock,@LastLoginIP,@LastLoginTime,@NickName,@FullName,@FirstName,@MiddleName,@LastName,@Phone1,@Phone2,@Email1,@Email2,@Fax,@Line,@Wechat,@QQ,@Facebook,@Twitter,@Linkedin,@ZipCode,@Place,@Address1,@Address2,@Province,@City,@County,@Zone,@Sex,@Height,@Weight,@Birthday,@Education,@School,@ImagePath1,@ImagePath2,@IDCardPath,@ResumePath,@Wages,@BankAccount,@IDNumber,@Source,@Note,@Remark,@EntryTime,@IsQuit,@QuitTime,@fk_Company,@CreateUser,@CreateDate,@ModifyUser,@ModifyDate)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 100));
                comm.Parameters["@UserName"].Value = _UserName;
                comm.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 100));
                comm.Parameters["@Password"].Value = _Password;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@fk_Department", SqlDbType.Int));
                comm.Parameters["@fk_Department"].Value = _fk_Department;
                comm.Parameters.Add(new SqlParameter("@RoleValue", SqlDbType.Int));
                comm.Parameters["@RoleValue"].Value = _RoleValue;
                comm.Parameters.Add(new SqlParameter("@RoleList", SqlDbType.NVarChar, 200));
                comm.Parameters["@RoleList"].Value = _RoleList;
                comm.Parameters.Add(new SqlParameter("@Position", SqlDbType.Int));
                comm.Parameters["@Position"].Value = _Position;
                comm.Parameters.Add(new SqlParameter("@Number", SqlDbType.NVarChar, 50));
                comm.Parameters["@Number"].Value = _Number;
                comm.Parameters.Add(new SqlParameter("@Skin", SqlDbType.NVarChar, 50));
                comm.Parameters["@Skin"].Value = _Skin;
                comm.Parameters.Add(new SqlParameter("@Language", SqlDbType.VarChar, 10));
                comm.Parameters["@Language"].Value = _Language;
                comm.Parameters.Add(new SqlParameter("@IsLock", SqlDbType.Bit));
                comm.Parameters["@IsLock"].Value = _IsLock;
                comm.Parameters.Add(new SqlParameter("@LastLoginIP", SqlDbType.NVarChar, 50));
                comm.Parameters["@LastLoginIP"].Value = _LastLoginIP;
                comm.Parameters.Add(new SqlParameter("@LastLoginTime", SqlDbType.DateTime));
                comm.Parameters["@LastLoginTime"].Value = _LastLoginTime;
                comm.Parameters.Add(new SqlParameter("@NickName", SqlDbType.NVarChar, 50));
                comm.Parameters["@NickName"].Value = _NickName;
                comm.Parameters.Add(new SqlParameter("@FullName", SqlDbType.NVarChar, 50));
                comm.Parameters["@FullName"].Value = _FullName;
                comm.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 50));
                comm.Parameters["@FirstName"].Value = _FirstName;
                comm.Parameters.Add(new SqlParameter("@MiddleName", SqlDbType.NVarChar, 50));
                comm.Parameters["@MiddleName"].Value = _MiddleName;
                comm.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 50));
                comm.Parameters["@LastName"].Value = _LastName;
                comm.Parameters.Add(new SqlParameter("@Phone1", SqlDbType.NVarChar, 50));
                comm.Parameters["@Phone1"].Value = _Phone1;
                comm.Parameters.Add(new SqlParameter("@Phone2", SqlDbType.NVarChar, 50));
                comm.Parameters["@Phone2"].Value = _Phone2;
                comm.Parameters.Add(new SqlParameter("@Email1", SqlDbType.NVarChar, 100));
                comm.Parameters["@Email1"].Value = _Email1;
                comm.Parameters.Add(new SqlParameter("@Email2", SqlDbType.NVarChar, 100));
                comm.Parameters["@Email2"].Value = _Email2;
                comm.Parameters.Add(new SqlParameter("@Fax", SqlDbType.NVarChar, 50));
                comm.Parameters["@Fax"].Value = _Fax;
                comm.Parameters.Add(new SqlParameter("@Line", SqlDbType.NVarChar, 50));
                comm.Parameters["@Line"].Value = _Line;
                comm.Parameters.Add(new SqlParameter("@Wechat", SqlDbType.NVarChar, 50));
                comm.Parameters["@Wechat"].Value = _Wechat;
                comm.Parameters.Add(new SqlParameter("@QQ", SqlDbType.NVarChar, 50));
                comm.Parameters["@QQ"].Value = _QQ;
                comm.Parameters.Add(new SqlParameter("@Facebook", SqlDbType.NVarChar, 50));
                comm.Parameters["@Facebook"].Value = _Facebook;
                comm.Parameters.Add(new SqlParameter("@Twitter", SqlDbType.NVarChar, 50));
                comm.Parameters["@Twitter"].Value = _Twitter;
                comm.Parameters.Add(new SqlParameter("@Linkedin", SqlDbType.NVarChar, 50));
                comm.Parameters["@Linkedin"].Value = _Linkedin;
                comm.Parameters.Add(new SqlParameter("@ZipCode", SqlDbType.NVarChar, 50));
                comm.Parameters["@ZipCode"].Value = _ZipCode;
                comm.Parameters.Add(new SqlParameter("@Place", SqlDbType.NVarChar, 50));
                comm.Parameters["@Place"].Value = _Place;
                comm.Parameters.Add(new SqlParameter("@Address1", SqlDbType.NVarChar, 500));
                comm.Parameters["@Address1"].Value = _Address1;
                comm.Parameters.Add(new SqlParameter("@Address2", SqlDbType.NVarChar, 500));
                comm.Parameters["@Address2"].Value = _Address2;
                comm.Parameters.Add(new SqlParameter("@Province", SqlDbType.Int));
                comm.Parameters["@Province"].Value = _Province;
                comm.Parameters.Add(new SqlParameter("@City", SqlDbType.Int));
                comm.Parameters["@City"].Value = _City;
                comm.Parameters.Add(new SqlParameter("@County", SqlDbType.Int));
                comm.Parameters["@County"].Value = _County;
                comm.Parameters.Add(new SqlParameter("@Zone", SqlDbType.Int));
                comm.Parameters["@Zone"].Value = _Zone;
                comm.Parameters.Add(new SqlParameter("@Sex", SqlDbType.Int));
                comm.Parameters["@Sex"].Value = _Sex;
                comm.Parameters.Add(new SqlParameter("@Height", SqlDbType.Int));
                comm.Parameters["@Height"].Value = _Height;
                comm.Parameters.Add(new SqlParameter("@Weight", SqlDbType.Int));
                comm.Parameters["@Weight"].Value = _Weight;
                comm.Parameters.Add(new SqlParameter("@Birthday", SqlDbType.DateTime));
                comm.Parameters["@Birthday"].Value = _Birthday;
                comm.Parameters.Add(new SqlParameter("@Education", SqlDbType.NVarChar, 50));
                comm.Parameters["@Education"].Value = _Education;
                comm.Parameters.Add(new SqlParameter("@School", SqlDbType.NVarChar, 50));
                comm.Parameters["@School"].Value = _School;
                comm.Parameters.Add(new SqlParameter("@ImagePath1", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath1"].Value = _ImagePath1;
                comm.Parameters.Add(new SqlParameter("@ImagePath2", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath2"].Value = _ImagePath2;
                comm.Parameters.Add(new SqlParameter("@IDCardPath", SqlDbType.NVarChar, 200));
                comm.Parameters["@IDCardPath"].Value = _IDCardPath;
                comm.Parameters.Add(new SqlParameter("@ResumePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ResumePath"].Value = _ResumePath;
                comm.Parameters.Add(new SqlParameter("@Wages", SqlDbType.Decimal));
                comm.Parameters["@Wages"].Value = _Wages;
                comm.Parameters.Add(new SqlParameter("@BankAccount", SqlDbType.NVarChar, 100));
                comm.Parameters["@BankAccount"].Value = _BankAccount;
                comm.Parameters.Add(new SqlParameter("@IDNumber", SqlDbType.NVarChar, 50));
                comm.Parameters["@IDNumber"].Value = _IDNumber;
                comm.Parameters.Add(new SqlParameter("@Source", SqlDbType.NVarChar, 100));
                comm.Parameters["@Source"].Value = _Source;
                comm.Parameters.Add(new SqlParameter("@Note", SqlDbType.NVarChar, 500));
                comm.Parameters["@Note"].Value = _Note;
                comm.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 500));
                comm.Parameters["@Remark"].Value = _Remark;
                comm.Parameters.Add(new SqlParameter("@EntryTime", SqlDbType.DateTime));
                comm.Parameters["@EntryTime"].Value = _EntryTime;
                comm.Parameters.Add(new SqlParameter("@IsQuit", SqlDbType.Bit));
                comm.Parameters["@IsQuit"].Value = _IsQuit;
                comm.Parameters.Add(new SqlParameter("@QuitTime", SqlDbType.DateTime));
                comm.Parameters["@QuitTime"].Value = _QuitTime;
                comm.Parameters.Add(new SqlParameter("@fk_Company", SqlDbType.Int));
                comm.Parameters["@fk_Company"].Value = _fk_Company;
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
                string sql = "update User_List set UserName=@UserName,Password=@Password,TypeID=@TypeID,fk_Department=@fk_Department,RoleValue=@RoleValue,RoleList=@RoleList,Position=@Position,Number=@Number,Skin=@Skin,Language=@Language,IsLock=@IsLock,LastLoginIP=@LastLoginIP,LastLoginTime=@LastLoginTime,NickName=@NickName,FullName=@FullName,FirstName=@FirstName,MiddleName=@MiddleName,LastName=@LastName,Phone1=@Phone1,Phone2=@Phone2,Email1=@Email1,Email2=@Email2,Fax=@Fax,Line=@Line,Wechat=@Wechat,QQ=@QQ,Facebook=@Facebook,Twitter=@Twitter,Linkedin=@Linkedin,ZipCode=@ZipCode,Place=@Place,Address1=@Address1,Address2=@Address2,Province=@Province,City=@City,County=@County,Zone=@Zone,Sex=@Sex,Height=@Height,Weight=@Weight,Birthday=@Birthday,Education=@Education,School=@School,ImagePath1=@ImagePath1,ImagePath2=@ImagePath2,IDCardPath=@IDCardPath,ResumePath=@ResumePath,Wages=@Wages,BankAccount=@BankAccount,IDNumber=@IDNumber,Source=@Source,Note=@Note,Remark=@Remark,EntryTime=@EntryTime,IsQuit=@IsQuit,QuitTime=@QuitTime,fk_Company=@fk_Company,CreateUser=@CreateUser,CreateDate=@CreateDate,ModifyUser=@ModifyUser,ModifyDate=@ModifyDate where pk_User=@pk_User";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 100));
                comm.Parameters["@UserName"].Value = _UserName;
                comm.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 100));
                comm.Parameters["@Password"].Value = _Password;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@fk_Department", SqlDbType.Int));
                comm.Parameters["@fk_Department"].Value = _fk_Department;
                comm.Parameters.Add(new SqlParameter("@RoleValue", SqlDbType.Int));
                comm.Parameters["@RoleValue"].Value = _RoleValue;
                comm.Parameters.Add(new SqlParameter("@RoleList", SqlDbType.NVarChar, 200));
                comm.Parameters["@RoleList"].Value = _RoleList;
                comm.Parameters.Add(new SqlParameter("@Position", SqlDbType.Int));
                comm.Parameters["@Position"].Value = _Position;
                comm.Parameters.Add(new SqlParameter("@Number", SqlDbType.NVarChar, 50));
                comm.Parameters["@Number"].Value = _Number;
                comm.Parameters.Add(new SqlParameter("@Skin", SqlDbType.NVarChar, 50));
                comm.Parameters["@Skin"].Value = _Skin;
                comm.Parameters.Add(new SqlParameter("@Language", SqlDbType.VarChar, 10));
                comm.Parameters["@Language"].Value = _Language;
                comm.Parameters.Add(new SqlParameter("@IsLock", SqlDbType.Bit));
                comm.Parameters["@IsLock"].Value = _IsLock;
                comm.Parameters.Add(new SqlParameter("@LastLoginIP", SqlDbType.NVarChar, 50));
                comm.Parameters["@LastLoginIP"].Value = _LastLoginIP;
                comm.Parameters.Add(new SqlParameter("@LastLoginTime", SqlDbType.DateTime));
                comm.Parameters["@LastLoginTime"].Value = _LastLoginTime;
                comm.Parameters.Add(new SqlParameter("@NickName", SqlDbType.NVarChar, 50));
                comm.Parameters["@NickName"].Value = _NickName;
                comm.Parameters.Add(new SqlParameter("@FullName", SqlDbType.NVarChar, 50));
                comm.Parameters["@FullName"].Value = _FullName;
                comm.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 50));
                comm.Parameters["@FirstName"].Value = _FirstName;
                comm.Parameters.Add(new SqlParameter("@MiddleName", SqlDbType.NVarChar, 50));
                comm.Parameters["@MiddleName"].Value = _MiddleName;
                comm.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 50));
                comm.Parameters["@LastName"].Value = _LastName;
                comm.Parameters.Add(new SqlParameter("@Phone1", SqlDbType.NVarChar, 50));
                comm.Parameters["@Phone1"].Value = _Phone1;
                comm.Parameters.Add(new SqlParameter("@Phone2", SqlDbType.NVarChar, 50));
                comm.Parameters["@Phone2"].Value = _Phone2;
                comm.Parameters.Add(new SqlParameter("@Email1", SqlDbType.NVarChar, 100));
                comm.Parameters["@Email1"].Value = _Email1;
                comm.Parameters.Add(new SqlParameter("@Email2", SqlDbType.NVarChar, 100));
                comm.Parameters["@Email2"].Value = _Email2;
                comm.Parameters.Add(new SqlParameter("@Fax", SqlDbType.NVarChar, 50));
                comm.Parameters["@Fax"].Value = _Fax;
                comm.Parameters.Add(new SqlParameter("@Line", SqlDbType.NVarChar, 50));
                comm.Parameters["@Line"].Value = _Line;
                comm.Parameters.Add(new SqlParameter("@Wechat", SqlDbType.NVarChar, 50));
                comm.Parameters["@Wechat"].Value = _Wechat;
                comm.Parameters.Add(new SqlParameter("@QQ", SqlDbType.NVarChar, 50));
                comm.Parameters["@QQ"].Value = _QQ;
                comm.Parameters.Add(new SqlParameter("@Facebook", SqlDbType.NVarChar, 50));
                comm.Parameters["@Facebook"].Value = _Facebook;
                comm.Parameters.Add(new SqlParameter("@Twitter", SqlDbType.NVarChar, 50));
                comm.Parameters["@Twitter"].Value = _Twitter;
                comm.Parameters.Add(new SqlParameter("@Linkedin", SqlDbType.NVarChar, 50));
                comm.Parameters["@Linkedin"].Value = _Linkedin;
                comm.Parameters.Add(new SqlParameter("@ZipCode", SqlDbType.NVarChar, 50));
                comm.Parameters["@ZipCode"].Value = _ZipCode;
                comm.Parameters.Add(new SqlParameter("@Place", SqlDbType.NVarChar, 50));
                comm.Parameters["@Place"].Value = _Place;
                comm.Parameters.Add(new SqlParameter("@Address1", SqlDbType.NVarChar, 500));
                comm.Parameters["@Address1"].Value = _Address1;
                comm.Parameters.Add(new SqlParameter("@Address2", SqlDbType.NVarChar, 500));
                comm.Parameters["@Address2"].Value = _Address2;
                comm.Parameters.Add(new SqlParameter("@Province", SqlDbType.Int));
                comm.Parameters["@Province"].Value = _Province;
                comm.Parameters.Add(new SqlParameter("@City", SqlDbType.Int));
                comm.Parameters["@City"].Value = _City;
                comm.Parameters.Add(new SqlParameter("@County", SqlDbType.Int));
                comm.Parameters["@County"].Value = _County;
                comm.Parameters.Add(new SqlParameter("@Zone", SqlDbType.Int));
                comm.Parameters["@Zone"].Value = _Zone;
                comm.Parameters.Add(new SqlParameter("@Sex", SqlDbType.Int));
                comm.Parameters["@Sex"].Value = _Sex;
                comm.Parameters.Add(new SqlParameter("@Height", SqlDbType.Int));
                comm.Parameters["@Height"].Value = _Height;
                comm.Parameters.Add(new SqlParameter("@Weight", SqlDbType.Int));
                comm.Parameters["@Weight"].Value = _Weight;
                comm.Parameters.Add(new SqlParameter("@Birthday", SqlDbType.DateTime));
                comm.Parameters["@Birthday"].Value = _Birthday;
                comm.Parameters.Add(new SqlParameter("@Education", SqlDbType.NVarChar, 50));
                comm.Parameters["@Education"].Value = _Education;
                comm.Parameters.Add(new SqlParameter("@School", SqlDbType.NVarChar, 50));
                comm.Parameters["@School"].Value = _School;
                comm.Parameters.Add(new SqlParameter("@ImagePath1", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath1"].Value = _ImagePath1;
                comm.Parameters.Add(new SqlParameter("@ImagePath2", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath2"].Value = _ImagePath2;
                comm.Parameters.Add(new SqlParameter("@IDCardPath", SqlDbType.NVarChar, 200));
                comm.Parameters["@IDCardPath"].Value = _IDCardPath;
                comm.Parameters.Add(new SqlParameter("@ResumePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ResumePath"].Value = _ResumePath;
                comm.Parameters.Add(new SqlParameter("@Wages", SqlDbType.Decimal));
                comm.Parameters["@Wages"].Value = _Wages;
                comm.Parameters.Add(new SqlParameter("@BankAccount", SqlDbType.NVarChar, 100));
                comm.Parameters["@BankAccount"].Value = _BankAccount;
                comm.Parameters.Add(new SqlParameter("@IDNumber", SqlDbType.NVarChar, 50));
                comm.Parameters["@IDNumber"].Value = _IDNumber;
                comm.Parameters.Add(new SqlParameter("@Source", SqlDbType.NVarChar, 100));
                comm.Parameters["@Source"].Value = _Source;
                comm.Parameters.Add(new SqlParameter("@Note", SqlDbType.NVarChar, 500));
                comm.Parameters["@Note"].Value = _Note;
                comm.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 500));
                comm.Parameters["@Remark"].Value = _Remark;
                comm.Parameters.Add(new SqlParameter("@EntryTime", SqlDbType.DateTime));
                comm.Parameters["@EntryTime"].Value = _EntryTime;
                comm.Parameters.Add(new SqlParameter("@IsQuit", SqlDbType.Bit));
                comm.Parameters["@IsQuit"].Value = _IsQuit;
                comm.Parameters.Add(new SqlParameter("@QuitTime", SqlDbType.DateTime));
                comm.Parameters["@QuitTime"].Value = _QuitTime;
                comm.Parameters.Add(new SqlParameter("@fk_Company", SqlDbType.Int));
                comm.Parameters["@fk_Company"].Value = _fk_Company;
                comm.Parameters.Add(new SqlParameter("@CreateUser", SqlDbType.Int));
                comm.Parameters["@CreateUser"].Value = _CreateUser;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@ModifyUser", SqlDbType.Int));
                comm.Parameters["@ModifyUser"].Value = _ModifyUser;
                comm.Parameters.Add(new SqlParameter("@ModifyDate", SqlDbType.DateTime));
                comm.Parameters["@ModifyDate"].Value = _ModifyDate;
                comm.Parameters.Add(new SqlParameter("@pk_User", SqlDbType.Int));
                comm.Parameters["@pk_User"].Value = id;
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
            Sql.SqlQuery("delete from User_List where pk_User=" + id);
        }

        #endregion
    }
}
