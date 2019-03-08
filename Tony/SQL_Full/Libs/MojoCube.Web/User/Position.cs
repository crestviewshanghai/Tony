using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.User
{
    public class Position
    {
        #region 公共属性
        int _pk_Position;
        public int pk_Position
        {
            get { return _pk_Position; }
            set { _pk_Position = value; }
        }
        string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
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
                string sql = "select * from User_Position where pk_Position=@pk_Position";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Position", SqlDbType.Int));
                comm.Parameters["@pk_Position"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Position = Convert.ToInt32(dr["pk_Position"].ToString());
                    _Title = dr["Title"].ToString();
                    _ParentID = Convert.ToInt32(dr["ParentID"].ToString());
                    _LevelID = Convert.ToInt32(dr["LevelID"].ToString());
                    _SortID = Convert.ToInt32(dr["SortID"].ToString());
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
                string sql = "insert into User_Position(Title,ParentID,LevelID,SortID,fk_Company,CreateUser,CreateDate,ModifyUser,ModifyDate) values (@Title,@ParentID,@LevelID,@SortID,@fk_Company,@CreateUser,@CreateDate,@ModifyUser,@ModifyDate)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@ParentID", SqlDbType.Int));
                comm.Parameters["@ParentID"].Value = _ParentID;
                comm.Parameters.Add(new SqlParameter("@LevelID", SqlDbType.Int));
                comm.Parameters["@LevelID"].Value = _LevelID;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
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
                string sql = "update User_Position set Title=@Title,ParentID=@ParentID,LevelID=@LevelID,SortID=@SortID,fk_Company=@fk_Company,CreateUser=@CreateUser,CreateDate=@CreateDate,ModifyUser=@ModifyUser,ModifyDate=@ModifyDate where pk_Position=@pk_Position";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@ParentID", SqlDbType.Int));
                comm.Parameters["@ParentID"].Value = _ParentID;
                comm.Parameters.Add(new SqlParameter("@LevelID", SqlDbType.Int));
                comm.Parameters["@LevelID"].Value = _LevelID;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
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
                comm.Parameters.Add(new SqlParameter("@pk_Position", SqlDbType.Int));
                comm.Parameters["@pk_Position"].Value = id;
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
            Sql.SqlQuery("delete from User_Position where pk_Position=" + id);
        }

        #endregion
    }
}
