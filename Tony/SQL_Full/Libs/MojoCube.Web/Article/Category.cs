using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Article
{
    public class Category
    {
        #region 公共属性
        int _pk_Category;
        public int pk_Category
        {
            get { return _pk_Category; }
            set { _pk_Category = value; }
        }
        string _PageName;
        public string PageName
        {
            get { return _PageName; }
            set { _PageName = value; }
        }
        string _CategoryName;
        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }
        string _Subtitle;
        public string Subtitle
        {
            get { return _Subtitle; }
            set { _Subtitle = value; }
        }
        int _ParentID;
        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }
        int _SortID;
        public int SortID
        {
            get { return _SortID; }
            set { _SortID = value; }
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
        string _Url;
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
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
                string sql = "select * from Article_Category where pk_Category=@pk_Category";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Category", SqlDbType.Int));
                comm.Parameters["@pk_Category"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Category = Convert.ToInt32(dr["pk_Category"].ToString());
                    _PageName = dr["PageName"].ToString();
                    _CategoryName = dr["CategoryName"].ToString();
                    _Subtitle = dr["Subtitle"].ToString();
                    _ParentID = Convert.ToInt32(dr["ParentID"].ToString());
                    _SortID = Convert.ToInt32(dr["SortID"].ToString());
                    _Visible = Convert.ToBoolean(dr["Visible"].ToString());
                    _SEO_Title = dr["SEO_Title"].ToString();
                    _SEO_Keyword = dr["SEO_Keyword"].ToString();
                    _SEO_Description = dr["SEO_Description"].ToString();
                    _Url = dr["Url"].ToString();
                    _ImagePath = dr["ImagePath"].ToString();
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
        /// 获取字段值
        /// </summary>
        /// <param name="pageName">页面名称</param>
        public void GetData(string pageName)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Article_Category where PageName=@PageName";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@PageName", SqlDbType.NVarChar, 100));
                comm.Parameters["@PageName"].Value = pageName;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Category = Convert.ToInt32(dr["pk_Category"].ToString());
                    _PageName = dr["PageName"].ToString();
                    _CategoryName = dr["CategoryName"].ToString();
                    _Subtitle = dr["Subtitle"].ToString();
                    _ParentID = Convert.ToInt32(dr["ParentID"].ToString());
                    _SortID = Convert.ToInt32(dr["SortID"].ToString());
                    _Visible = Convert.ToBoolean(dr["Visible"].ToString());
                    _SEO_Title = dr["SEO_Title"].ToString();
                    _SEO_Keyword = dr["SEO_Keyword"].ToString();
                    _SEO_Description = dr["SEO_Description"].ToString();
                    _Url = dr["Url"].ToString();
                    _ImagePath = dr["ImagePath"].ToString();
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
                string sql = "insert into Article_Category(PageName,CategoryName,Subtitle,ParentID,SortID,Visible,SEO_Title,SEO_Keyword,SEO_Description,Url,ImagePath,CreateDate,CreateUserID,ModifyDate,ModifyUserID,Language) values (@PageName,@CategoryName,@Subtitle,@ParentID,@SortID,@Visible,@SEO_Title,@SEO_Keyword,@SEO_Description,@Url,@ImagePath,@CreateDate,@CreateUserID,@ModifyDate,@ModifyUserID,@Language)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@PageName", SqlDbType.NVarChar, 100));
                comm.Parameters["@PageName"].Value = _PageName;
                comm.Parameters.Add(new SqlParameter("@CategoryName", SqlDbType.NVarChar, 100));
                comm.Parameters["@CategoryName"].Value = _CategoryName;
                comm.Parameters.Add(new SqlParameter("@Subtitle", SqlDbType.NVarChar, 500));
                comm.Parameters["@Subtitle"].Value = _Subtitle;
                comm.Parameters.Add(new SqlParameter("@ParentID", SqlDbType.Int));
                comm.Parameters["@ParentID"].Value = _ParentID;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@Visible", SqlDbType.Bit));
                comm.Parameters["@Visible"].Value = _Visible;
                comm.Parameters.Add(new SqlParameter("@SEO_Title", SqlDbType.NVarChar, 250));
                comm.Parameters["@SEO_Title"].Value = _SEO_Title;
                comm.Parameters.Add(new SqlParameter("@SEO_Keyword", SqlDbType.NVarChar, 250));
                comm.Parameters["@SEO_Keyword"].Value = _SEO_Keyword;
                comm.Parameters.Add(new SqlParameter("@SEO_Description", SqlDbType.NVarChar, 1000));
                comm.Parameters["@SEO_Description"].Value = _SEO_Description;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;
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
                string sql = "update Article_Category set PageName=@PageName,CategoryName=@CategoryName,Subtitle=@Subtitle,ParentID=@ParentID,SortID=@SortID,Visible=@Visible,SEO_Title=@SEO_Title,SEO_Keyword=@SEO_Keyword,SEO_Description=@SEO_Description,Url=@Url,ImagePath=@ImagePath,CreateDate=@CreateDate,CreateUserID=@CreateUserID,ModifyDate=@ModifyDate,ModifyUserID=@ModifyUserID,Language=@Language where pk_Category=@pk_Category";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@PageName", SqlDbType.NVarChar, 100));
                comm.Parameters["@PageName"].Value = _PageName;
                comm.Parameters.Add(new SqlParameter("@CategoryName", SqlDbType.NVarChar, 100));
                comm.Parameters["@CategoryName"].Value = _CategoryName;
                comm.Parameters.Add(new SqlParameter("@Subtitle", SqlDbType.NVarChar, 500));
                comm.Parameters["@Subtitle"].Value = _Subtitle;
                comm.Parameters.Add(new SqlParameter("@ParentID", SqlDbType.Int));
                comm.Parameters["@ParentID"].Value = _ParentID;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@Visible", SqlDbType.Bit));
                comm.Parameters["@Visible"].Value = _Visible;
                comm.Parameters.Add(new SqlParameter("@SEO_Title", SqlDbType.NVarChar, 250));
                comm.Parameters["@SEO_Title"].Value = _SEO_Title;
                comm.Parameters.Add(new SqlParameter("@SEO_Keyword", SqlDbType.NVarChar, 250));
                comm.Parameters["@SEO_Keyword"].Value = _SEO_Keyword;
                comm.Parameters.Add(new SqlParameter("@SEO_Description", SqlDbType.NVarChar, 1000));
                comm.Parameters["@SEO_Description"].Value = _SEO_Description;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;
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
                comm.Parameters.Add(new SqlParameter("@pk_Category", SqlDbType.Int));
                comm.Parameters["@pk_Category"].Value = id;
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
            Sql.SqlQuery("delete from Article_Category where pk_Category=" + id);
        }

        #endregion
    }
}
