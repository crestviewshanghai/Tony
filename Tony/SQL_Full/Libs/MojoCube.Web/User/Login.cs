using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace MojoCube.Web.User
{
    public class Login
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
        /// 判断是否是合法用户
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public bool IsUser(string userName, string password)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from User_List where UserName=@UserName and Password=@Password";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 100));
                comm.Parameters["@UserName"].Value = userName;
                comm.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 100));
                comm.Parameters["@Password"].Value = password;
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
                    _fk_Company = Convert.ToInt32(dr["fk_Company"].ToString());
                    _CreateUser = Convert.ToInt32(dr["CreateUser"].ToString());
                    _CreateDate = dr["CreateDate"].ToString();
                    _ModifyUser = Convert.ToInt32(dr["ModifyUser"].ToString());
                    _ModifyDate = dr["ModifyDate"].ToString();

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
        /// 检查是否登录并具有权限
        /// </summary>
        public static void ChkLogin()
        {
            MojoCube.Web.User.Login.WriteSession();
            MojoCube.Web.User.Login.HasLogin();
            MojoCube.Web.User.Login.HasRole();
        }

        public static bool IsLogin()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["UserID"] != null && HttpContext.Current.Session["UserName"] != null)
            {
                SqlConnection conn = new SqlConnection(Connection.ConnString());
                try
                {
                    conn.Open();
                    string sql = "select pk_User,UserName from User_List where pk_User=@pk_User and UserName=@UserName";
                    SqlCommand comm = new SqlCommand(sql, conn);

                    comm.Parameters.Add(new SqlParameter("@pk_User", SqlDbType.Int));
                    comm.Parameters["@pk_User"].Value = int.Parse(HttpContext.Current.Session["UserID"].ToString());
                    comm.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 100));
                    comm.Parameters["@UserName"].Value = HttpContext.Current.Session["UserName"].ToString();

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

        public static void HasLogin()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["UserID"] != null && HttpContext.Current.Session["UserName"] != null)
            {
                SqlConnection conn = new SqlConnection(Connection.ConnString());
                try
                {
                    conn.Open();
                    string sql = "select pk_User,UserName,LastLoginIP from User_List where pk_User=@pk_User and UserName=@UserName";
                    SqlCommand comm = new SqlCommand(sql, conn);

                    comm.Parameters.Add(new SqlParameter("@pk_User", SqlDbType.Int));
                    comm.Parameters["@pk_User"].Value = int.Parse(HttpContext.Current.Session["UserID"].ToString());
                    comm.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 100));
                    comm.Parameters["@UserName"].Value = HttpContext.Current.Session["UserName"].ToString();

                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr["LastLoginIP"].ToString() == IP.Get()) //验证登陆IP是否为最后登陆（也就是防止使用账号在别处登陆）
                        {
                            return;
                        }
                        else
                        {
                            HttpContext.Current.Response.Redirect("~/Admin/Login.aspx");
                            HttpContext.Current.Response.End();
                        }
                        return;
                    }
                    else
                    {
                        HttpContext.Current.Response.Redirect("~/Admin/Login.aspx");
                        HttpContext.Current.Response.End();
                    }
                }
                catch
                {
                    HttpContext.Current.Response.Redirect("~/Admin/Login.aspx");
                    HttpContext.Current.Response.End();
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Admin/Login.aspx");
                HttpContext.Current.Response.End();
            }
        }

        public static void HasRole()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["RoleValue"] != null)
            {
                string pageUrl = HttpContext.Current.Request.Path.ToString().ToLower();

                string root = HttpContext.Current.Request.ApplicationPath.ToLower();

                if (root != "/")
                {
                    pageUrl = pageUrl.Replace(root, "");
                }

                SqlConnection conn = new SqlConnection(Connection.ConnString());
                try
                {
                    conn.Open();
                    string sql = "select * from View_Menu where fk_RoleName=" + HttpContext.Current.Session["RoleValue"].ToString() + " and Url='" + pageUrl + "' and IsUse=1";
                    SqlCommand comm = new SqlCommand(sql, conn);
                    SqlDataReader dr = comm.ExecuteReader();
                    if (!dr.Read())
                    {
                        HttpContext.Current.Response.Redirect("~/Admin/Commons/Info.aspx?type=1");
                        HttpContext.Current.Response.End();
                    }
                }
                catch
                {
                    HttpContext.Current.Response.Redirect("~/Admin/Commons/Info.aspx?type=1");
                    HttpContext.Current.Response.End();
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Admin/Commons/Info.aspx?type=1");
                HttpContext.Current.Response.End();
            }
        }

        #region  防止Session丢失
        public static void WriteSession()
        {
            if (HttpContext.Current.Session["UserID"] == null)
            {
                ChkCookies("UserID");
                ChkCookies("UserName");
                ChkCookies("FullName");
                ChkCookies("RoleValue");
                ChkCookies("DepartmentID");
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
            SetLogin("UserID");
            SetLogin("UserName");
            SetLogin("FullName");
            SetLogin("RoleValue");
            SetLogin("DepartmentID");
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
            SetLogout("UserID");
            SetLogout("UserName");
            SetLogout("FullName");
            SetLogout("RoleValue");
            SetLogout("DepartmentID");
        }
        public static void SetLogout(string name)
        {
            HttpContext.Current.Session.Remove(name);
            HttpContext.Current.Response.Cookies[name].Expires = DateTime.Now.AddDays(-1);
        }
        #endregion

        #region  记录最后登录IP和登录时间
        public static void UpdateLastLogin(string id)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update User_List set LastLoginIP=@LastLoginIP,LastLoginTime=@LastLoginTime where pk_User=@pk_User";
                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.Add(new SqlParameter("@LastLoginIP", SqlDbType.VarChar, 50));
                comm.Parameters["@LastLoginIP"].Value = IP.Get();
                comm.Parameters.Add(new SqlParameter("@LastLoginTime", SqlDbType.DateTime));
                comm.Parameters["@LastLoginTime"].Value = DateTime.Now;
                comm.Parameters.Add(new SqlParameter("@pk_User", SqlDbType.Int));
                comm.Parameters["@pk_User"].Value = int.Parse(id);

                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #endregion
    }
}
