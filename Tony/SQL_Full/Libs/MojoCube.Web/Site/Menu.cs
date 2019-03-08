using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Site
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
        string _MenuName;
        public string MenuName
        {
            get { return _MenuName; }
            set { _MenuName = value; }
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
        int _TypeID;
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        string _Target;
        public string Target
        {
            get { return _Target; }
            set { _Target = value; }
        }
        bool _Visible;
        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
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
                string sql = "select * from Site_Menu where pk_Menu=@pk_Menu";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Menu", SqlDbType.Int));
                comm.Parameters["@pk_Menu"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Menu = Convert.ToInt32(dr["pk_Menu"].ToString());
                    _ParentID = Convert.ToInt32(dr["ParentID"].ToString());
                    _MenuName = dr["MenuName"].ToString();
                    _Url = dr["Url"].ToString();
                    _Icon = dr["Icon"].ToString();
                    _SortID = Convert.ToInt32(dr["SortID"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _Target = dr["Target"].ToString();
                    _Visible = Convert.ToBoolean(dr["Visible"].ToString());
                    _SEO_Title = dr["SEO_Title"].ToString();
                    _SEO_Keyword = dr["SEO_Keyword"].ToString();
                    _SEO_Description = dr["SEO_Description"].ToString();
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
                string sql = "insert into Site_Menu(ParentID,MenuName,Url,Icon,SortID,TypeID,Target,Visible,SEO_Title,SEO_Keyword,SEO_Description,Language) values (@ParentID,@MenuName,@Url,@Icon,@SortID,@TypeID,@Target,@Visible,@SEO_Title,@SEO_Keyword,@SEO_Description,@Language)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@ParentID", SqlDbType.Int));
                comm.Parameters["@ParentID"].Value = _ParentID;
                comm.Parameters.Add(new SqlParameter("@MenuName", SqlDbType.NVarChar, 50));
                comm.Parameters["@MenuName"].Value = _MenuName;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@Icon", SqlDbType.NVarChar, 50));
                comm.Parameters["@Icon"].Value = _Icon;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Target", SqlDbType.VarChar, 10));
                comm.Parameters["@Target"].Value = _Target;
                comm.Parameters.Add(new SqlParameter("@Visible", SqlDbType.Bit));
                comm.Parameters["@Visible"].Value = _Visible;
                comm.Parameters.Add(new SqlParameter("@SEO_Title", SqlDbType.NVarChar, 250));
                comm.Parameters["@SEO_Title"].Value = _SEO_Title;
                comm.Parameters.Add(new SqlParameter("@SEO_Keyword", SqlDbType.NVarChar, 250));
                comm.Parameters["@SEO_Keyword"].Value = _SEO_Keyword;
                comm.Parameters.Add(new SqlParameter("@SEO_Description", SqlDbType.NVarChar, 1000));
                comm.Parameters["@SEO_Description"].Value = _SEO_Description;
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
                string sql = "update Site_Menu set ParentID=@ParentID,MenuName=@MenuName,Url=@Url,Icon=@Icon,SortID=@SortID,TypeID=@TypeID,Target=@Target,Visible=@Visible,SEO_Title=@SEO_Title,SEO_Keyword=@SEO_Keyword,SEO_Description=@SEO_Description,Language=@Language where pk_Menu=@pk_Menu";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@ParentID", SqlDbType.Int));
                comm.Parameters["@ParentID"].Value = _ParentID;
                comm.Parameters.Add(new SqlParameter("@MenuName", SqlDbType.NVarChar, 50));
                comm.Parameters["@MenuName"].Value = _MenuName;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@Icon", SqlDbType.NVarChar, 50));
                comm.Parameters["@Icon"].Value = _Icon;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Target", SqlDbType.VarChar, 10));
                comm.Parameters["@Target"].Value = _Target;
                comm.Parameters.Add(new SqlParameter("@Visible", SqlDbType.Bit));
                comm.Parameters["@Visible"].Value = _Visible;
                comm.Parameters.Add(new SqlParameter("@SEO_Title", SqlDbType.NVarChar, 250));
                comm.Parameters["@SEO_Title"].Value = _SEO_Title;
                comm.Parameters.Add(new SqlParameter("@SEO_Keyword", SqlDbType.NVarChar, 250));
                comm.Parameters["@SEO_Keyword"].Value = _SEO_Keyword;
                comm.Parameters.Add(new SqlParameter("@SEO_Description", SqlDbType.NVarChar, 1000));
                comm.Parameters["@SEO_Description"].Value = _SEO_Description;
                comm.Parameters.Add(new SqlParameter("@Language", SqlDbType.VarChar, 10));
                comm.Parameters["@Language"].Value = _Language;
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
            Sql.SqlQuery("delete from Site_Menu where pk_Menu=" + id);
        }

        #endregion
    }
}
