using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Memo
{
    public class List
    {
        #region 公共属性
        int _pk_Memo;
        public int pk_Memo
        {
            get { return _pk_Memo; }
            set { _pk_Memo = value; }
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
        string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }
        string _FilePath;
        public string FilePath
        {
            get { return _FilePath; }
            set { _FilePath = value; }
        }
        string _UserList;
        public string UserList
        {
            get { return _UserList; }
            set { _UserList = value; }
        }
        string _DepartmentList;
        public string DepartmentList
        {
            get { return _DepartmentList; }
            set { _DepartmentList = value; }
        }
        string _RoleList;
        public string RoleList
        {
            get { return _RoleList; }
            set { _RoleList = value; }
        }
        string _Url;
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        bool _IsStar;
        public bool IsStar
        {
            get { return _IsStar; }
            set { _IsStar = value; }
        }
        string _Tags;
        public string Tags
        {
            get { return _Tags; }
            set { _Tags = value; }
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
                string sql = "select * from Memo_List where pk_Memo=@pk_Memo";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Memo", SqlDbType.Int));
                comm.Parameters["@pk_Memo"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Memo = Convert.ToInt32(dr["pk_Memo"].ToString());
                    _fk_User = Convert.ToInt32(dr["fk_User"].ToString());
                    _fk_Department = Convert.ToInt32(dr["fk_Department"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _StatusID = Convert.ToInt32(dr["StatusID"].ToString());
                    _Title = dr["Title"].ToString();
                    _Description = dr["Description"].ToString();
                    _ImagePath = dr["ImagePath"].ToString();
                    _FilePath = dr["FilePath"].ToString();
                    _UserList = dr["UserList"].ToString();
                    _DepartmentList = dr["DepartmentList"].ToString();
                    _RoleList = dr["RoleList"].ToString();
                    _Url = dr["Url"].ToString();
                    _IsStar = Convert.ToBoolean(dr["IsStar"].ToString());
                    _Tags = dr["Tags"].ToString();
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
                string sql = "insert into Memo_List(fk_User,fk_Department,TypeID,StatusID,Title,Description,ImagePath,FilePath,UserList,DepartmentList,RoleList,Url,IsStar,Tags,fk_Company,CreateUser,CreateDate,ModifyUser,ModifyDate) values (@fk_User,@fk_Department,@TypeID,@StatusID,@Title,@Description,@ImagePath,@FilePath,@UserList,@DepartmentList,@RoleList,@Url,@IsStar,@Tags,@fk_Company,@CreateUser,@CreateDate,@ModifyUser,@ModifyDate)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_User", SqlDbType.Int));
                comm.Parameters["@fk_User"].Value = _fk_User;
                comm.Parameters.Add(new SqlParameter("@fk_Department", SqlDbType.Int));
                comm.Parameters["@fk_Department"].Value = _fk_Department;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;
                comm.Parameters.Add(new SqlParameter("@FilePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@FilePath"].Value = _FilePath;
                comm.Parameters.Add(new SqlParameter("@UserList", SqlDbType.NVarChar, 1000));
                comm.Parameters["@UserList"].Value = _UserList;
                comm.Parameters.Add(new SqlParameter("@DepartmentList", SqlDbType.NVarChar, 1000));
                comm.Parameters["@DepartmentList"].Value = _DepartmentList;
                comm.Parameters.Add(new SqlParameter("@RoleList", SqlDbType.NVarChar, 1000));
                comm.Parameters["@RoleList"].Value = _RoleList;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@IsStar", SqlDbType.Bit));
                comm.Parameters["@IsStar"].Value = _IsStar;
                comm.Parameters.Add(new SqlParameter("@Tags", SqlDbType.NVarChar, 200));
                comm.Parameters["@Tags"].Value = _Tags;
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
                string sql = "update Memo_List set fk_User=@fk_User,fk_Department=@fk_Department,TypeID=@TypeID,StatusID=@StatusID,Title=@Title,Description=@Description,ImagePath=@ImagePath,FilePath=@FilePath,UserList=@UserList,DepartmentList=@DepartmentList,RoleList=@RoleList,Url=@Url,IsStar=@IsStar,Tags=@Tags,fk_Company=@fk_Company,CreateUser=@CreateUser,CreateDate=@CreateDate,ModifyUser=@ModifyUser,ModifyDate=@ModifyDate where pk_Memo=@pk_Memo";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_User", SqlDbType.Int));
                comm.Parameters["@fk_User"].Value = _fk_User;
                comm.Parameters.Add(new SqlParameter("@fk_Department", SqlDbType.Int));
                comm.Parameters["@fk_Department"].Value = _fk_Department;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;
                comm.Parameters.Add(new SqlParameter("@FilePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@FilePath"].Value = _FilePath;
                comm.Parameters.Add(new SqlParameter("@UserList", SqlDbType.NVarChar, 1000));
                comm.Parameters["@UserList"].Value = _UserList;
                comm.Parameters.Add(new SqlParameter("@DepartmentList", SqlDbType.NVarChar, 1000));
                comm.Parameters["@DepartmentList"].Value = _DepartmentList;
                comm.Parameters.Add(new SqlParameter("@RoleList", SqlDbType.NVarChar, 1000));
                comm.Parameters["@RoleList"].Value = _RoleList;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@IsStar", SqlDbType.Bit));
                comm.Parameters["@IsStar"].Value = _IsStar;
                comm.Parameters.Add(new SqlParameter("@Tags", SqlDbType.NVarChar, 200));
                comm.Parameters["@Tags"].Value = _Tags;
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
                comm.Parameters.Add(new SqlParameter("@pk_Memo", SqlDbType.Int));
                comm.Parameters["@pk_Memo"].Value = id;
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
            Sql.SqlQuery("delete from Memo_List where pk_Memo=" + id);
        }

        #endregion
    }
}
