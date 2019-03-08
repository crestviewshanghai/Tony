using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.User
{
    public class Department
    {
        #region 公共属性
        int _pk_Department;
        public int pk_Department
        {
            get { return _pk_Department; }
            set { _pk_Department = value; }
        }
        string _DepartmentName;
        public string DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
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
        string _Fax;
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        int _ParentID;
        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }
        int _LevelID;
        public int LevelID
        {
            get { return _LevelID; }
            set { _LevelID = value; }
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
        int _Manager;
        public int Manager
        {
            get { return _Manager; }
            set { _Manager = value; }
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
        string _Monday;
        public string Monday
        {
            get { return _Monday; }
            set { _Monday = value; }
        }
        string _Tuesday;
        public string Tuesday
        {
            get { return _Tuesday; }
            set { _Tuesday = value; }
        }
        string _Wednesday;
        public string Wednesday
        {
            get { return _Wednesday; }
            set { _Wednesday = value; }
        }
        string _Thursday;
        public string Thursday
        {
            get { return _Thursday; }
            set { _Thursday = value; }
        }
        string _Friday;
        public string Friday
        {
            get { return _Friday; }
            set { _Friday = value; }
        }
        string _Saturday;
        public string Saturday
        {
            get { return _Saturday; }
            set { _Saturday = value; }
        }
        string _Sunday;
        public string Sunday
        {
            get { return _Sunday; }
            set { _Sunday = value; }
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
                string sql = "select * from User_Department where pk_Department=@pk_Department";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Department", SqlDbType.Int));
                comm.Parameters["@pk_Department"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Department = Convert.ToInt32(dr["pk_Department"].ToString());
                    _DepartmentName = dr["DepartmentName"].ToString();
                    _Phone1 = dr["Phone1"].ToString();
                    _Phone2 = dr["Phone2"].ToString();
                    _Fax = dr["Fax"].ToString();
                    _Email = dr["Email"].ToString();
                    _Address = dr["Address"].ToString();
                    _ParentID = Convert.ToInt32(dr["ParentID"].ToString());
                    _LevelID = Convert.ToInt32(dr["LevelID"].ToString());
                    _SortID = Convert.ToInt32(dr["SortID"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _Province = Convert.ToInt32(dr["Province"].ToString());
                    _City = Convert.ToInt32(dr["City"].ToString());
                    _County = Convert.ToInt32(dr["County"].ToString());
                    _Zone = Convert.ToInt32(dr["Zone"].ToString());
                    _Manager = Convert.ToInt32(dr["Manager"].ToString());
                    _fk_Company = Convert.ToInt32(dr["fk_Company"].ToString());
                    _CreateUser = Convert.ToInt32(dr["CreateUser"].ToString());
                    _CreateDate = dr["CreateDate"].ToString();
                    _ModifyUser = Convert.ToInt32(dr["ModifyUser"].ToString());
                    _ModifyDate = dr["ModifyDate"].ToString();
                    _Monday = dr["Monday"].ToString();
                    _Tuesday = dr["Tuesday"].ToString();
                    _Wednesday = dr["Wednesday"].ToString();
                    _Thursday = dr["Thursday"].ToString();
                    _Friday = dr["Friday"].ToString();
                    _Saturday = dr["Saturday"].ToString();
                    _Sunday = dr["Sunday"].ToString();
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
                string sql = "insert into User_Department(DepartmentName,Phone1,Phone2,Fax,Email,Address,ParentID,LevelID,SortID,TypeID,Province,City,County,Zone,Manager,fk_Company,CreateUser,CreateDate,ModifyUser,ModifyDate,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday) values (@DepartmentName,@Phone1,@Phone2,@Fax,@Email,@Address,@ParentID,@LevelID,@SortID,@TypeID,@Province,@City,@County,@Zone,@Manager,@fk_Company,@CreateUser,@CreateDate,@ModifyUser,@ModifyDate,@Monday,@Tuesday,@Wednesday,@Thursday,@Friday,@Saturday,@Sunday)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@DepartmentName", SqlDbType.NVarChar, 50));
                comm.Parameters["@DepartmentName"].Value = _DepartmentName;
                comm.Parameters.Add(new SqlParameter("@Phone1", SqlDbType.NVarChar, 50));
                comm.Parameters["@Phone1"].Value = _Phone1;
                comm.Parameters.Add(new SqlParameter("@Phone2", SqlDbType.NVarChar, 50));
                comm.Parameters["@Phone2"].Value = _Phone2;
                comm.Parameters.Add(new SqlParameter("@Fax", SqlDbType.NVarChar, 50));
                comm.Parameters["@Fax"].Value = _Fax;
                comm.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 100));
                comm.Parameters["@Email"].Value = _Email;
                comm.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 500));
                comm.Parameters["@Address"].Value = _Address;
                comm.Parameters.Add(new SqlParameter("@ParentID", SqlDbType.Int));
                comm.Parameters["@ParentID"].Value = _ParentID;
                comm.Parameters.Add(new SqlParameter("@LevelID", SqlDbType.Int));
                comm.Parameters["@LevelID"].Value = _LevelID;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Province", SqlDbType.Int));
                comm.Parameters["@Province"].Value = _Province;
                comm.Parameters.Add(new SqlParameter("@City", SqlDbType.Int));
                comm.Parameters["@City"].Value = _City;
                comm.Parameters.Add(new SqlParameter("@County", SqlDbType.Int));
                comm.Parameters["@County"].Value = _County;
                comm.Parameters.Add(new SqlParameter("@Zone", SqlDbType.Int));
                comm.Parameters["@Zone"].Value = _Zone;
                comm.Parameters.Add(new SqlParameter("@Manager", SqlDbType.Int));
                comm.Parameters["@Manager"].Value = _Manager;
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
                comm.Parameters.Add(new SqlParameter("@Monday", SqlDbType.NVarChar, 50));
                comm.Parameters["@Monday"].Value = _Monday;
                comm.Parameters.Add(new SqlParameter("@Tuesday", SqlDbType.NVarChar, 50));
                comm.Parameters["@Tuesday"].Value = _Tuesday;
                comm.Parameters.Add(new SqlParameter("@Wednesday", SqlDbType.NVarChar, 50));
                comm.Parameters["@Wednesday"].Value = _Wednesday;
                comm.Parameters.Add(new SqlParameter("@Thursday", SqlDbType.NVarChar, 50));
                comm.Parameters["@Thursday"].Value = _Thursday;
                comm.Parameters.Add(new SqlParameter("@Friday", SqlDbType.NVarChar, 50));
                comm.Parameters["@Friday"].Value = _Friday;
                comm.Parameters.Add(new SqlParameter("@Saturday", SqlDbType.NVarChar, 50));
                comm.Parameters["@Saturday"].Value = _Saturday;
                comm.Parameters.Add(new SqlParameter("@Sunday", SqlDbType.NVarChar, 50));
                comm.Parameters["@Sunday"].Value = _Sunday;
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
                string sql = "update User_Department set DepartmentName=@DepartmentName,Phone1=@Phone1,Phone2=@Phone2,Fax=@Fax,Email=@Email,Address=@Address,ParentID=@ParentID,LevelID=@LevelID,SortID=@SortID,TypeID=@TypeID,Province=@Province,City=@City,County=@County,Zone=@Zone,Manager=@Manager,fk_Company=@fk_Company,CreateUser=@CreateUser,CreateDate=@CreateDate,ModifyUser=@ModifyUser,ModifyDate=@ModifyDate,Monday=@Monday,Tuesday=@Tuesday,Wednesday=@Wednesday,Thursday=@Thursday,Friday=@Friday,Saturday=@Saturday,Sunday=@Sunday where pk_Department=@pk_Department";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@DepartmentName", SqlDbType.NVarChar, 50));
                comm.Parameters["@DepartmentName"].Value = _DepartmentName;
                comm.Parameters.Add(new SqlParameter("@Phone1", SqlDbType.NVarChar, 50));
                comm.Parameters["@Phone1"].Value = _Phone1;
                comm.Parameters.Add(new SqlParameter("@Phone2", SqlDbType.NVarChar, 50));
                comm.Parameters["@Phone2"].Value = _Phone2;
                comm.Parameters.Add(new SqlParameter("@Fax", SqlDbType.NVarChar, 50));
                comm.Parameters["@Fax"].Value = _Fax;
                comm.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 100));
                comm.Parameters["@Email"].Value = _Email;
                comm.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 500));
                comm.Parameters["@Address"].Value = _Address;
                comm.Parameters.Add(new SqlParameter("@ParentID", SqlDbType.Int));
                comm.Parameters["@ParentID"].Value = _ParentID;
                comm.Parameters.Add(new SqlParameter("@LevelID", SqlDbType.Int));
                comm.Parameters["@LevelID"].Value = _LevelID;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Province", SqlDbType.Int));
                comm.Parameters["@Province"].Value = _Province;
                comm.Parameters.Add(new SqlParameter("@City", SqlDbType.Int));
                comm.Parameters["@City"].Value = _City;
                comm.Parameters.Add(new SqlParameter("@County", SqlDbType.Int));
                comm.Parameters["@County"].Value = _County;
                comm.Parameters.Add(new SqlParameter("@Zone", SqlDbType.Int));
                comm.Parameters["@Zone"].Value = _Zone;
                comm.Parameters.Add(new SqlParameter("@Manager", SqlDbType.Int));
                comm.Parameters["@Manager"].Value = _Manager;
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
                comm.Parameters.Add(new SqlParameter("@Monday", SqlDbType.NVarChar, 50));
                comm.Parameters["@Monday"].Value = _Monday;
                comm.Parameters.Add(new SqlParameter("@Tuesday", SqlDbType.NVarChar, 50));
                comm.Parameters["@Tuesday"].Value = _Tuesday;
                comm.Parameters.Add(new SqlParameter("@Wednesday", SqlDbType.NVarChar, 50));
                comm.Parameters["@Wednesday"].Value = _Wednesday;
                comm.Parameters.Add(new SqlParameter("@Thursday", SqlDbType.NVarChar, 50));
                comm.Parameters["@Thursday"].Value = _Thursday;
                comm.Parameters.Add(new SqlParameter("@Friday", SqlDbType.NVarChar, 50));
                comm.Parameters["@Friday"].Value = _Friday;
                comm.Parameters.Add(new SqlParameter("@Saturday", SqlDbType.NVarChar, 50));
                comm.Parameters["@Saturday"].Value = _Saturday;
                comm.Parameters.Add(new SqlParameter("@Sunday", SqlDbType.NVarChar, 50));
                comm.Parameters["@Sunday"].Value = _Sunday;
                comm.Parameters.Add(new SqlParameter("@pk_Department", SqlDbType.Int));
                comm.Parameters["@pk_Department"].Value = id;
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
            Sql.SqlQuery("delete from User_Department where pk_Department=" + id);
        }

        #endregion
    }
}
