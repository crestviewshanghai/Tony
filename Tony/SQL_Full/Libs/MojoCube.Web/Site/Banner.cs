using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Site
{
    public class Banner
    {
        #region 公共属性
        int _pk_Banner;
        public int pk_Banner
        {
            get { return _pk_Banner; }
            set { _pk_Banner = value; }
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
        string _Url;
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        string _Target;
        public string Target
        {
            get { return _Target; }
            set { _Target = value; }
        }
        int _TypeID;
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        string _FileName;
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }
        string _FilePath;
        public string FilePath
        {
            get { return _FilePath; }
            set { _FilePath = value; }
        }
        string _FileType;
        public string FileType
        {
            get { return _FileType; }
            set { _FileType = value; }
        }
        int _FileSize;
        public int FileSize
        {
            get { return _FileSize; }
            set { _FileSize = value; }
        }
        int _Width;
        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        int _Height;
        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
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
                string sql = "select * from Site_Banner where pk_Banner=@pk_Banner";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Banner", SqlDbType.Int));
                comm.Parameters["@pk_Banner"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Banner = Convert.ToInt32(dr["pk_Banner"].ToString());
                    _Title = dr["Title"].ToString();
                    _Description = dr["Description"].ToString();
                    _Url = dr["Url"].ToString();
                    _Target = dr["Target"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _FileName = dr["FileName"].ToString();
                    _FilePath = dr["FilePath"].ToString();
                    _FileType = dr["FileType"].ToString();
                    _FileSize = Convert.ToInt32(dr["FileSize"].ToString());
                    _Width = Convert.ToInt32(dr["Width"].ToString());
                    _Height = Convert.ToInt32(dr["Height"].ToString());
                    _SortID = Convert.ToInt32(dr["SortID"].ToString());
                    _Visible = Convert.ToBoolean(dr["Visible"].ToString());
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
                string sql = "insert into Site_Banner(Title,Description,Url,Target,TypeID,FileName,FilePath,FileType,FileSize,Width,Height,SortID,Visible,CreateDate,CreateUserID,ModifyDate,ModifyUserID,Language) values (@Title,@Description,@Url,@Target,@TypeID,@FileName,@FilePath,@FileType,@FileSize,@Width,@Height,@SortID,@Visible,@CreateDate,@CreateUserID,@ModifyDate,@ModifyUserID,@Language)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 50));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 200));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@Target", SqlDbType.VarChar, 10));
                comm.Parameters["@Target"].Value = _Target;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@FileName", SqlDbType.NVarChar, 100));
                comm.Parameters["@FileName"].Value = _FileName;
                comm.Parameters.Add(new SqlParameter("@FilePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@FilePath"].Value = _FilePath;
                comm.Parameters.Add(new SqlParameter("@FileType", SqlDbType.NVarChar, 10));
                comm.Parameters["@FileType"].Value = _FileType;
                comm.Parameters.Add(new SqlParameter("@FileSize", SqlDbType.Int));
                comm.Parameters["@FileSize"].Value = _FileSize;
                comm.Parameters.Add(new SqlParameter("@Width", SqlDbType.Int));
                comm.Parameters["@Width"].Value = _Width;
                comm.Parameters.Add(new SqlParameter("@Height", SqlDbType.Int));
                comm.Parameters["@Height"].Value = _Height;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@Visible", SqlDbType.Bit));
                comm.Parameters["@Visible"].Value = _Visible;
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
                string sql = "update Site_Banner set Title=@Title,Description=@Description,Url=@Url,Target=@Target,TypeID=@TypeID,FileName=@FileName,FilePath=@FilePath,FileType=@FileType,FileSize=@FileSize,Width=@Width,Height=@Height,SortID=@SortID,Visible=@Visible,CreateDate=@CreateDate,CreateUserID=@CreateUserID,ModifyDate=@ModifyDate,ModifyUserID=@ModifyUserID,Language=@Language where pk_Banner=@pk_Banner";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 50));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 200));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@Target", SqlDbType.VarChar, 10));
                comm.Parameters["@Target"].Value = _Target;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@FileName", SqlDbType.NVarChar, 100));
                comm.Parameters["@FileName"].Value = _FileName;
                comm.Parameters.Add(new SqlParameter("@FilePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@FilePath"].Value = _FilePath;
                comm.Parameters.Add(new SqlParameter("@FileType", SqlDbType.NVarChar, 10));
                comm.Parameters["@FileType"].Value = _FileType;
                comm.Parameters.Add(new SqlParameter("@FileSize", SqlDbType.Int));
                comm.Parameters["@FileSize"].Value = _FileSize;
                comm.Parameters.Add(new SqlParameter("@Width", SqlDbType.Int));
                comm.Parameters["@Width"].Value = _Width;
                comm.Parameters.Add(new SqlParameter("@Height", SqlDbType.Int));
                comm.Parameters["@Height"].Value = _Height;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@Visible", SqlDbType.Bit));
                comm.Parameters["@Visible"].Value = _Visible;
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
                comm.Parameters.Add(new SqlParameter("@pk_Banner", SqlDbType.Int));
                comm.Parameters["@pk_Banner"].Value = id;
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
            Sql.SqlQuery("delete from Site_Banner where pk_Banner=" + id);
        }

        #endregion
    }
}
