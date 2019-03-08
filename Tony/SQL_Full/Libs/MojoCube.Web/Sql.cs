using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;

namespace MojoCube.Web
{
    public class Sql
    {
        #region  定义属性
        string _TableName;
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
        string _OrderByKey;
        public string OrderByKey
        {
            get { return _OrderByKey; }
            set { _OrderByKey = value; }
        }
        string _OrderByType;
        public string OrderByType
        {
            get { return _OrderByType; }
            set { _OrderByType = value; }
        }
        string _Where;
        public string Where
        {
            get { return _Where; }
            set { _Where = value; }
        }
        string _pk_ID;
        public string pk_ID
        {
            get { return _pk_ID; }
            set { _pk_ID = value; }
        }
        string _ParentID;
        public string ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }
        #endregion

        #region  sql操作
        //多表查询  
        //如： 
        //StringBuilder sb = new StringBuilder(); sb.Append("update tableName set username='baidu' where pk_ID=1"); sb.Append(" update tableName set username='google' where pk_ID=2");
        //SqlQuery(sb.ToString());
        public static void SqlQuery(string strSql)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                SqlCommand comm = new SqlCommand();
                comm.Transaction = trans;
                comm.Connection = conn;
                comm.CommandText = strSql;
                comm.ExecuteNonQuery();
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }
        //返回数据集DataSet：ds.Tables[0]、ds.Tables[1]...
        public static DataSet SqlQueryDS(string strSql)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter();
                comm.CommandText = strSql;
                da.SelectCommand = comm;
                da.Fill(ds);
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }
        #endregion

        #region  统计记录条数
        public static int GetResultCount(string tabeName, string where)
        {
            int i = -1;
            string sql = "SELECT Count(*) as counts FROM " + tabeName;
            if (where != null && where.Trim().Length > 0)
                sql += " WHERE " + where;
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = null;
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    i = Int32.Parse(dr["counts"].ToString());
                }
            }
            finally
            {
                conn.Close();
            }
            return i;
        }
        #endregion

        #region  统计字段总值
        public static decimal GetResultSum(string tabeName, string column, string where)
        {
            decimal value = 0;
            string sql = "SELECT SUM(" + column + ") as value FROM " + tabeName;
            if (where != null && where.Trim().Length > 0)
                sql += " WHERE " + where;
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = null;
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    value = MojoCube.Web.String.ToDecimal(dr["value"].ToString());
                }
            }
            finally
            {
                conn.Close();
            }
            return value;
        }
        #endregion

        #region  增加点击数
        public static void AddClicks(string tableName, string where, int clicks)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update " + tableName + " set Clicks=@Clicks where " + where;
                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.Add(new SqlParameter("@Clicks", SqlDbType.Int));
                comm.Parameters["@Clicks"].Value = clicks + 1;

                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region  无极下拉分类
        public static void BindClass(DropDownList ddlCategory, string tableName)
        {
            ddlCategory.Items.Insert(0, new ListItem("不限分类", "0"));

            DataTable dt = new DataTable();
            dt = MojoCube.Web.Sql.SqlQueryDS("select * from " + tableName + " where ParentID=0 and Language='" + MojoCube.Api.UI.Language.GetLanguage() + "' and Visible=1 order by SortID asc").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem li = new ListItem();
                li.Text = "╋" + dt.Rows[i]["CategoryName"].ToString();
                li.Value = dt.Rows[i]["pk_Category"].ToString();
                ddlCategory.Items.Add(li);
                BindChild(ddlCategory, dt.Rows[i]["pk_Category"].ToString(), "├──", tableName);
            }
        }

        public static void BindChild(DropDownList ddlCategory, string ParentID, string separator, string tableName)
        {
            DataTable dt = new DataTable();
            dt = MojoCube.Web.Sql.SqlQueryDS("select * from " + tableName + " where ParentID=" + ParentID + " and Visible=1").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem li = new ListItem();
                li.Text = separator + dt.Rows[i]["CategoryName"].ToString();
                li.Value = dt.Rows[i]["pk_Category"].ToString();
                ddlCategory.Items.Add(li);
                string separator_ = separator + "───";
                BindChild(ddlCategory, dt.Rows[i]["pk_Category"].ToString(), separator_, tableName);
            }
        }
        #endregion

        #region  绑定下拉数据
        /// <summary>
        /// 绑定下拉数据
        /// </summary>
        /// <param name="ddlList">对象控件</param>
        /// <param name="tableName">表名</param>
        /// <param name="dataText">Text数据字段</param>
        /// <param name="dataValue">Value数据字段</param>
        /// <param name="where">查询条件</param>
        /// <param name="orderByKey">排序字段</param>
        /// <param name="orderByType">排序类型</param>
        public static void DropDownListBind(DropDownList ddlList, string tableName, string dataText, string dataValue, string where, string orderByKey, string orderByType)
        {
            if (where != null)
            {
                ddlList.DataSource = SqlQueryDS("select * from " + tableName + " where " + where + " order by " + orderByKey + " " + orderByType);
            }
            else
            {
                ddlList.DataSource = SqlQueryDS("select * from " + tableName + " order by " + orderByKey + " " + orderByType);
            }
            ddlList.DataTextField = dataText;
            ddlList.DataValueField = dataValue;
            ddlList.DataBind();
        }

        public static void DropDownListBind(DropDownList ddlList, string tableName, string dataText, string dataValue, string where, string orderByKey, string orderByType, ListItem listItem)
        {
            if (where != null)
            {
                ddlList.DataSource = SqlQueryDS("select * from " + tableName + " where " + where + " order by " + orderByKey + " " + orderByType);
            }
            else
            {
                ddlList.DataSource = SqlQueryDS("select * from " + tableName + " order by " + orderByKey + " " + orderByType);
            }
            ddlList.DataTextField = dataText;
            ddlList.DataValueField = dataValue;
            ddlList.DataBind();
            if (listItem != null) ddlList.Items.Insert(0, listItem);
        }

        public static void DropDownListBind(DropDownList ddlList, string tableName, string dataText, string dataValue, string where, string orderByKey, string orderByType, ListItem listItem, int iSpace)
        {
            string space = "　";
            for (int i = 0; i < iSpace; i++)
            {
                space += space;
            }
            if (where != null)
            {
                ddlList.DataSource = SqlQueryDS("select *,convert(nvarchar,'" + space + "')+" + dataText + " as newData from " + tableName + " where " + where + " order by " + orderByKey + " " + orderByType);
            }
            else
            {
                ddlList.DataSource = SqlQueryDS("select *,convert(nvarchar,'" + space + "')+" + dataText + " as newData from " + tableName + " order by " + orderByKey + " " + orderByType);
            }
            ddlList.DataTextField = "newData";
            ddlList.DataValueField = dataValue;
            ddlList.DataBind();
            if (listItem != null) ddlList.Items.Insert(0, listItem);
        }

        public static void ddlFindByValue(DropDownList ddl, string value)
        {
            try
            {
                ddl.SelectedIndex = -1;
                ddl.Items.FindByValue(value).Selected = true;
            }
            catch
            { }
        }

        public static void ddlFindByText(DropDownList ddl, string text)
        {
            try
            {
                ddl.SelectedIndex = -1;
                ddl.Items.FindByText(text).Selected = true;
            }
            catch
            { }
        }
        #endregion

        #region  绑定树形列表
        public void TreeGridBind(GridView gridView)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            if (_Where != null)
            {
                ds = SqlQueryDS("select * from " + _TableName + " where " + _Where + " order by " + _OrderByKey + " " + _OrderByType);
            }
            else
            {
                ds = SqlQueryDS("select * from " + _TableName + " order by " + _OrderByKey + " " + _OrderByType);
            }
            dt = ds.Tables[0].Clone();
            dt = CreateForest(ds, dt);

            gridView.AllowPaging = false;
            gridView.DataSource = dt;
            gridView.DataBind();
        }
        public DataTable CreateForest(DataSet CreateForestDS, DataTable CreateForestDT)
        {
            foreach (DataRow Row in CreateForestDS.Tables[0].Select(_ParentID + "=0"))
            {
                CreateTree(Convert.ToInt32(Row[_pk_ID]), CreateForestDS, CreateForestDT);
            }
            return CreateForestDT;
        }
        public DataTable CreateTree(int pkID, DataSet CreateTreeDS, DataTable CreateTreeDT)
        {
            foreach (DataRow Row in CreateTreeDS.Tables[0].Select(pk_ID + "=" + pkID))
            {
                if (Convert.ToInt32(Row[_ParentID]) == 0)
                {
                    CreateTreeDT.Rows.Add(Row.ItemArray);
                }

                foreach (DataRow Row2 in CreateTreeDS.Tables[0].Select(_ParentID + "=" + pkID))
                {
                    CreateTreeDT.Rows.Add(Row2.ItemArray);
                    CreateTree(Convert.ToInt32(Row2[_pk_ID]), CreateTreeDS, CreateTreeDT);
                }
            }
            return CreateTreeDT;
        }
        #endregion

        #region  设置排序ID
        public static void SetSortID(string tableName, string pkID, string id, int sortID)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update " + tableName + " set SortID=(select SortID from " + tableName + " where " + pkID + "=" + id + ")+" + sortID.ToString() + " where " + pkID + "=" + id;
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        public void SetSortID(string id, string sortID)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update " + _TableName + " set SortID=" + sortID + " where " + _pk_ID + "=" + id;
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region  检查是否存在相同数据
        public static bool IsExist(string tableName, string columnName, string value)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select " + columnName + " from " + tableName + " where " + columnName + "=@" + columnName;
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@" + columnName, SqlDbType.NVarChar));
                comm.Parameters["@" + columnName].Value = value;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool IsExist(string tableName, string columnName, string value, string where)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select " + columnName + " from " + tableName + " where " + where + " and " + columnName + "=@" + columnName;
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@" + columnName, SqlDbType.NVarChar));
                comm.Parameters["@" + columnName].Value = value;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool IsExist(string tableName, string columnName, int value)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select " + columnName + " from " + tableName + " where " + columnName + "=@" + columnName;
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@" + columnName, SqlDbType.Int));
                comm.Parameters["@" + columnName].Value = value;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool IsExist(string tableName, string columnName, int value, string where)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select " + columnName + " from " + tableName + " where " + where + " and " + columnName + "=@" + columnName;
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@" + columnName, SqlDbType.Int));
                comm.Parameters["@" + columnName].Value = value;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }
}
