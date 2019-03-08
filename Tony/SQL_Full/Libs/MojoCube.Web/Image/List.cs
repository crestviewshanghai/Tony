using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Image
{
    public class List
    {
        #region 公共属性
        int _pk_Image;
        public int pk_Image
        {
            get { return _pk_Image; }
            set { _pk_Image = value; }
        }
        int _fk_Category;
        public int fk_Category
        {
            get { return _fk_Category; }
            set { _fk_Category = value; }
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
        string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
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
                string sql = "select * from Image_List where pk_Image=@pk_Image";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Image", SqlDbType.Int));
                comm.Parameters["@pk_Image"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Image = Convert.ToInt32(dr["pk_Image"].ToString());
                    _fk_Category = Convert.ToInt32(dr["fk_Category"].ToString());
                    _FileName = dr["FileName"].ToString();
                    _FilePath = dr["FilePath"].ToString();
                    _FileType = dr["FileType"].ToString();
                    _FileSize = Convert.ToInt32(dr["FileSize"].ToString());
                    _Width = Convert.ToInt32(dr["Width"].ToString());
                    _Height = Convert.ToInt32(dr["Height"].ToString());
                    _Title = dr["Title"].ToString();
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
                string sql = "insert into Image_List(fk_Category,FileName,FilePath,FileType,FileSize,Width,Height,Title,CreateDate,CreateUserID,ModifyDate,ModifyUserID,Language) values (@fk_Category,@FileName,@FilePath,@FileType,@FileSize,@Width,@Height,@Title,@CreateDate,@CreateUserID,@ModifyDate,@ModifyUserID,@Language)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Category", SqlDbType.Int));
                comm.Parameters["@fk_Category"].Value = _fk_Category;
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
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 200));
                comm.Parameters["@Title"].Value = _Title;
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
                string sql = "update Image_List set fk_Category=@fk_Category,FileName=@FileName,FilePath=@FilePath,FileType=@FileType,FileSize=@FileSize,Width=@Width,Height=@Height,Title=@Title,CreateDate=@CreateDate,CreateUserID=@CreateUserID,ModifyDate=@ModifyDate,ModifyUserID=@ModifyUserID,Language=@Language where pk_Image=@pk_Image";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Category", SqlDbType.Int));
                comm.Parameters["@fk_Category"].Value = _fk_Category;
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
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 200));
                comm.Parameters["@Title"].Value = _Title;
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
                comm.Parameters.Add(new SqlParameter("@pk_Image", SqlDbType.Int));
                comm.Parameters["@pk_Image"].Value = id;
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
            Sql.SqlQuery("delete from Image_List where pk_Image=" + id);
        }

        #endregion
    }
}
