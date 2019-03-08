using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Role
{
    public class List
    {
        #region 公共属性
        int _pk_Role;
        public int pk_Role
        {
            get { return _pk_Role; }
            set { _pk_Role = value; }
        }
        int _fk_RoleName;
        public int fk_RoleName
        {
            get { return _fk_RoleName; }
            set { _fk_RoleName = value; }
        }
        int _fk_Menu;
        public int fk_Menu
        {
            get { return _fk_Menu; }
            set { _fk_Menu = value; }
        }
        bool _IsUse;
        public bool IsUse
        {
            get { return _IsUse; }
            set { _IsUse = value; }
        }
        bool _IsAdmin;
        public bool IsAdmin
        {
            get { return _IsAdmin; }
            set { _IsAdmin = value; }
        }
        string _PowerList;
        public string PowerList
        {
            get { return _PowerList; }
            set { _PowerList = value; }
        }
        int _fk_Company;
        public int fk_Company
        {
            get { return _fk_Company; }
            set { _fk_Company = value; }
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
                string sql = "select * from Role_List where pk_Role=@pk_Role";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Role", SqlDbType.Int));
                comm.Parameters["@pk_Role"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Role = Convert.ToInt32(dr["pk_Role"].ToString());
                    _fk_RoleName = Convert.ToInt32(dr["fk_RoleName"].ToString());
                    _fk_Menu = Convert.ToInt32(dr["fk_Menu"].ToString());
                    _IsUse = Convert.ToBoolean(dr["IsUse"].ToString());
                    _IsAdmin = Convert.ToBoolean(dr["IsAdmin"].ToString());
                    _PowerList = dr["PowerList"].ToString();
                    _fk_Company = Convert.ToInt32(dr["fk_Company"].ToString());
                }
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获取字段值
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="menuId">菜单ID</param>
        public void GetData(int roleId, int menuId)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Role_List where fk_RoleName=@fk_RoleName and fk_Menu=@fk_Menu";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_RoleName", SqlDbType.Int));
                comm.Parameters["@fk_RoleName"].Value = roleId;
                comm.Parameters.Add(new SqlParameter("@fk_Menu", SqlDbType.Int));
                comm.Parameters["@fk_Menu"].Value = menuId;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Role = Convert.ToInt32(dr["pk_Role"].ToString());
                    _fk_RoleName = Convert.ToInt32(dr["fk_RoleName"].ToString());
                    _fk_Menu = Convert.ToInt32(dr["fk_Menu"].ToString());
                    _IsUse = Convert.ToBoolean(dr["IsUse"].ToString());
                    _IsAdmin = Convert.ToBoolean(dr["IsAdmin"].ToString());
                    _PowerList = dr["PowerList"].ToString();
                    _fk_Company = Convert.ToInt32(dr["fk_Company"].ToString());
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
                string sql = "insert into Role_List(fk_RoleName,fk_Menu,IsUse,IsAdmin,PowerList,fk_Company) values (@fk_RoleName,@fk_Menu,@IsUse,@IsAdmin,@PowerList,@fk_Company)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_RoleName", SqlDbType.Int));
                comm.Parameters["@fk_RoleName"].Value = _fk_RoleName;
                comm.Parameters.Add(new SqlParameter("@fk_Menu", SqlDbType.Int));
                comm.Parameters["@fk_Menu"].Value = _fk_Menu;
                comm.Parameters.Add(new SqlParameter("@IsUse", SqlDbType.Bit));
                comm.Parameters["@IsUse"].Value = _IsUse;
                comm.Parameters.Add(new SqlParameter("@IsAdmin", SqlDbType.Bit));
                comm.Parameters["@IsAdmin"].Value = _IsAdmin;
                comm.Parameters.Add(new SqlParameter("@PowerList", SqlDbType.NVarChar, 500));
                comm.Parameters["@PowerList"].Value = _PowerList;
                comm.Parameters.Add(new SqlParameter("@fk_Company", SqlDbType.Int));
                comm.Parameters["@fk_Company"].Value = _fk_Company;
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
                string sql = "update Role_List set fk_RoleName=@fk_RoleName,fk_Menu=@fk_Menu,IsUse=@IsUse,IsAdmin=@IsAdmin,PowerList=@PowerList,fk_Company=@fk_Company where pk_Role=@pk_Role";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_RoleName", SqlDbType.Int));
                comm.Parameters["@fk_RoleName"].Value = _fk_RoleName;
                comm.Parameters.Add(new SqlParameter("@fk_Menu", SqlDbType.Int));
                comm.Parameters["@fk_Menu"].Value = _fk_Menu;
                comm.Parameters.Add(new SqlParameter("@IsUse", SqlDbType.Bit));
                comm.Parameters["@IsUse"].Value = _IsUse;
                comm.Parameters.Add(new SqlParameter("@IsAdmin", SqlDbType.Bit));
                comm.Parameters["@IsAdmin"].Value = _IsAdmin;
                comm.Parameters.Add(new SqlParameter("@PowerList", SqlDbType.NVarChar, 500));
                comm.Parameters["@PowerList"].Value = _PowerList;
                comm.Parameters.Add(new SqlParameter("@fk_Company", SqlDbType.Int));
                comm.Parameters["@fk_Company"].Value = _fk_Company;
                comm.Parameters.Add(new SqlParameter("@pk_Role", SqlDbType.Int));
                comm.Parameters["@pk_Role"].Value = id;
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
            Sql.SqlQuery("delete from Role_List where pk_Role=" + id);
        }

        #endregion
    }
}
