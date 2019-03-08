using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.SMS
{
    public class List
    {
        #region 公共属性
        int _pk_SMS;
        public int pk_SMS
        {
            get { return _pk_SMS; }
            set { _pk_SMS = value; }
        }
        string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        string _Subtitle;
        public string Subtitle
        {
            get { return _Subtitle; }
            set { _Subtitle = value; }
        }
        string _Contents;
        public string Contents
        {
            get { return _Contents; }
            set { _Contents = value; }
        }
        int _TypeID;
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        string _Gateway;
        public string Gateway
        {
            get { return _Gateway; }
            set { _Gateway = value; }
        }
        string _AppID;
        public string AppID
        {
            get { return _AppID; }
            set { _AppID = value; }
        }
        string _KeyCode;
        public string KeyCode
        {
            get { return _KeyCode; }
            set { _KeyCode = value; }
        }
        bool _Visible;
        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }
        int _SortID;
        public int SortID
        {
            get { return _SortID; }
            set { _SortID = value; }
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
                string sql = "select * from SMS_List where pk_SMS=@pk_SMS";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_SMS", SqlDbType.Int));
                comm.Parameters["@pk_SMS"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_SMS = Convert.ToInt32(dr["pk_SMS"].ToString());
                    _Title = dr["Title"].ToString();
                    _Subtitle = dr["Subtitle"].ToString();
                    _Contents = dr["Contents"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _Gateway = dr["Gateway"].ToString();
                    _AppID = dr["AppID"].ToString();
                    _KeyCode = dr["KeyCode"].ToString();
                    _Visible = Convert.ToBoolean(dr["Visible"].ToString());
                    _SortID = Convert.ToInt32(dr["SortID"].ToString());
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
        /// <param name="typeId">Type ID</param>
        public void GetDataByType(int typeId)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from SMS_List where TypeID=@TypeID and Visible=1";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = typeId;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_SMS = Convert.ToInt32(dr["pk_SMS"].ToString());
                    _Title = dr["Title"].ToString();
                    _Subtitle = dr["Subtitle"].ToString();
                    _Contents = dr["Contents"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _Gateway = dr["Gateway"].ToString();
                    _AppID = dr["AppID"].ToString();
                    _KeyCode = dr["KeyCode"].ToString();
                    _Visible = Convert.ToBoolean(dr["Visible"].ToString());
                    _SortID = Convert.ToInt32(dr["SortID"].ToString());
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
                string sql = "insert into SMS_List(Title,Subtitle,Contents,TypeID,Gateway,AppID,KeyCode,Visible,SortID,ImagePath,CreateDate,CreateUserID,ModifyDate,ModifyUserID) values (@Title,@Subtitle,@Contents,@TypeID,@Gateway,@AppID,@KeyCode,@Visible,@SortID,@ImagePath,@CreateDate,@CreateUserID,@ModifyDate,@ModifyUserID)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Subtitle", SqlDbType.NVarChar, 200));
                comm.Parameters["@Subtitle"].Value = _Subtitle;
                comm.Parameters.Add(new SqlParameter("@Contents", SqlDbType.NVarChar, 500));
                comm.Parameters["@Contents"].Value = _Contents;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Gateway", SqlDbType.NVarChar, 500));
                comm.Parameters["@Gateway"].Value = _Gateway;
                comm.Parameters.Add(new SqlParameter("@AppID", SqlDbType.NVarChar, 200));
                comm.Parameters["@AppID"].Value = _AppID;
                comm.Parameters.Add(new SqlParameter("@KeyCode", SqlDbType.NVarChar, 200));
                comm.Parameters["@KeyCode"].Value = _KeyCode;
                comm.Parameters.Add(new SqlParameter("@Visible", SqlDbType.Bit));
                comm.Parameters["@Visible"].Value = _Visible;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
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
                string sql = "update SMS_List set Title=@Title,Subtitle=@Subtitle,Contents=@Contents,TypeID=@TypeID,Gateway=@Gateway,AppID=@AppID,KeyCode=@KeyCode,Visible=@Visible,SortID=@SortID,ImagePath=@ImagePath,CreateDate=@CreateDate,CreateUserID=@CreateUserID,ModifyDate=@ModifyDate,ModifyUserID=@ModifyUserID where pk_SMS=@pk_SMS";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Subtitle", SqlDbType.NVarChar, 200));
                comm.Parameters["@Subtitle"].Value = _Subtitle;
                comm.Parameters.Add(new SqlParameter("@Contents", SqlDbType.NVarChar, 500));
                comm.Parameters["@Contents"].Value = _Contents;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Gateway", SqlDbType.NVarChar, 500));
                comm.Parameters["@Gateway"].Value = _Gateway;
                comm.Parameters.Add(new SqlParameter("@AppID", SqlDbType.NVarChar, 200));
                comm.Parameters["@AppID"].Value = _AppID;
                comm.Parameters.Add(new SqlParameter("@KeyCode", SqlDbType.NVarChar, 200));
                comm.Parameters["@KeyCode"].Value = _KeyCode;
                comm.Parameters.Add(new SqlParameter("@Visible", SqlDbType.Bit));
                comm.Parameters["@Visible"].Value = _Visible;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
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
                comm.Parameters.Add(new SqlParameter("@pk_SMS", SqlDbType.Int));
                comm.Parameters["@pk_SMS"].Value = id;
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
            Sql.SqlQuery("delete from SMS_List where pk_SMS=" + id);
        }

        #endregion
    }
}
