using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Sys
{
    public class Menu
    {
        #region 公共属性
        int _pk_Menu;
        public int pk_Menu
        {
            get { return _pk_Menu; }
            set { _pk_Menu = value; }
        }
        int _ParentID;
        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }
        string _Name_CHS;
        public string Name_CHS
        {
            get { return _Name_CHS; }
            set { _Name_CHS = value; }
        }
        string _Name_CHT;
        public string Name_CHT
        {
            get { return _Name_CHT; }
            set { _Name_CHT = value; }
        }
        string _Name_EN;
        public string Name_EN
        {
            get { return _Name_EN; }
            set { _Name_EN = value; }
        }
        string _Url;
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        string _Icon;
        public string Icon
        {
            get { return _Icon; }
            set { _Icon = value; }
        }
        int _SortID;
        public int SortID
        {
            get { return _SortID; }
            set { _SortID = value; }
        }
        int _LevelID;
        public int LevelID
        {
            get { return _LevelID; }
            set { _LevelID = value; }
        }
        int _TypeID;
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        bool _Visible;
        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }
        string _Tag_CHS;
        public string Tag_CHS
        {
            get { return _Tag_CHS; }
            set { _Tag_CHS = value; }
        }
        string _Tag_CHT;
        public string Tag_CHT
        {
            get { return _Tag_CHT; }
            set { _Tag_CHT = value; }
        }
        string _Tag_EN;
        public string Tag_EN
        {
            get { return _Tag_EN; }
            set { _Tag_EN = value; }
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
                string sql = "select * from Sys_Menu where pk_Menu=@pk_Menu";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Menu", SqlDbType.Int));
                comm.Parameters["@pk_Menu"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Menu = Convert.ToInt32(dr["pk_Menu"].ToString());
                    _ParentID = Convert.ToInt32(dr["ParentID"].ToString());
                    _Name_CHS = dr["Name_CHS"].ToString();
                    _Name_CHT = dr["Name_CHT"].ToString();
                    _Name_EN = dr["Name_EN"].ToString();
                    _Url = dr["Url"].ToString();
                    _Icon = dr["Icon"].ToString();
                    _SortID = Convert.ToInt32(dr["SortID"].ToString());
                    _LevelID = Convert.ToInt32(dr["LevelID"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _Visible = Convert.ToBoolean(dr["Visible"].ToString());
                    _Tag_CHS = dr["Tag_CHS"].ToString();
                    _Tag_CHT = dr["Tag_CHT"].ToString();
                    _Tag_EN = dr["Tag_EN"].ToString();
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
                string sql = "insert into Sys_Menu(ParentID,Name_CHS,Name_CHT,Name_EN,Url,Icon,SortID,LevelID,TypeID,Visible,Tag_CHS,Tag_CHT,Tag_EN) values (@ParentID,@Name_CHS,@Name_CHT,@Name_EN,@Url,@Icon,@SortID,@LevelID,@TypeID,@Visible,@Tag_CHS,@Tag_CHT,@Tag_EN)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@ParentID", SqlDbType.Int));
                comm.Parameters["@ParentID"].Value = _ParentID;
                comm.Parameters.Add(new SqlParameter("@Name_CHS", SqlDbType.NVarChar, 50));
                comm.Parameters["@Name_CHS"].Value = _Name_CHS;
                comm.Parameters.Add(new SqlParameter("@Name_CHT", SqlDbType.NVarChar, 50));
                comm.Parameters["@Name_CHT"].Value = _Name_CHT;
                comm.Parameters.Add(new SqlParameter("@Name_EN", SqlDbType.NVarChar, 50));
                comm.Parameters["@Name_EN"].Value = _Name_EN;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@Icon", SqlDbType.NVarChar, 50));
                comm.Parameters["@Icon"].Value = _Icon;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@LevelID", SqlDbType.Int));
                comm.Parameters["@LevelID"].Value = _LevelID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Visible", SqlDbType.Bit));
                comm.Parameters["@Visible"].Value = _Visible;
                comm.Parameters.Add(new SqlParameter("@Tag_CHS", SqlDbType.NVarChar, 200));
                comm.Parameters["@Tag_CHS"].Value = _Tag_CHS;
                comm.Parameters.Add(new SqlParameter("@Tag_CHT", SqlDbType.NVarChar, 200));
                comm.Parameters["@Tag_CHT"].Value = _Tag_CHT;
                comm.Parameters.Add(new SqlParameter("@Tag_EN", SqlDbType.NVarChar, 200));
                comm.Parameters["@Tag_EN"].Value = _Tag_EN;
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
                string sql = "update Sys_Menu set ParentID=@ParentID,Name_CHS=@Name_CHS,Name_CHT=@Name_CHT,Name_EN=@Name_EN,Url=@Url,Icon=@Icon,SortID=@SortID,LevelID=@LevelID,TypeID=@TypeID,Visible=@Visible,Tag_CHS=@Tag_CHS,Tag_CHT=@Tag_CHT,Tag_EN=@Tag_EN where pk_Menu=@pk_Menu";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@ParentID", SqlDbType.Int));
                comm.Parameters["@ParentID"].Value = _ParentID;
                comm.Parameters.Add(new SqlParameter("@Name_CHS", SqlDbType.NVarChar, 50));
                comm.Parameters["@Name_CHS"].Value = _Name_CHS;
                comm.Parameters.Add(new SqlParameter("@Name_CHT", SqlDbType.NVarChar, 50));
                comm.Parameters["@Name_CHT"].Value = _Name_CHT;
                comm.Parameters.Add(new SqlParameter("@Name_EN", SqlDbType.NVarChar, 50));
                comm.Parameters["@Name_EN"].Value = _Name_EN;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@Icon", SqlDbType.NVarChar, 50));
                comm.Parameters["@Icon"].Value = _Icon;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@LevelID", SqlDbType.Int));
                comm.Parameters["@LevelID"].Value = _LevelID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Visible", SqlDbType.Bit));
                comm.Parameters["@Visible"].Value = _Visible;
                comm.Parameters.Add(new SqlParameter("@Tag_CHS", SqlDbType.NVarChar, 200));
                comm.Parameters["@Tag_CHS"].Value = _Tag_CHS;
                comm.Parameters.Add(new SqlParameter("@Tag_CHT", SqlDbType.NVarChar, 200));
                comm.Parameters["@Tag_CHT"].Value = _Tag_CHT;
                comm.Parameters.Add(new SqlParameter("@Tag_EN", SqlDbType.NVarChar, 200));
                comm.Parameters["@Tag_EN"].Value = _Tag_EN;
                comm.Parameters.Add(new SqlParameter("@pk_Menu", SqlDbType.Int));
                comm.Parameters["@pk_Menu"].Value = id;
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
            Sql.SqlQuery("delete from Sys_Menu where pk_Menu=" + id);
        }

        #endregion
    }
}
