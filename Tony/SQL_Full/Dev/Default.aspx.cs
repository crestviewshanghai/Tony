using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;

public partial class Dev_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MojoCube.Api.Data.Sql sql = new MojoCube.Api.Data.Sql();
            sql.GetInfo(MojoCube.Web.Connection.ConnString());

            txtServer.Text = sql.Server;
            txtUser.Text = sql.UserID;
            txtPassword.Text = sql.Password;

            BindDatabaseDDL();
            BindTableNameDDL();
            txtUsing.Text = UsingString();
        }
    }

    protected void ddlDatabase_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTableNameDDL();
    }

    #region 绑定数据库
    private void BindDatabaseDDL()
    {
        ddlDatabase.Items.Clear();
        DataTable dt = GetDatabaseDS().Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ddlDatabase.Items.Insert(i, new ListItem(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["Name"].ToString()));
        }
    }

    protected DataSet GetDatabaseDS()
    {
        SqlConnection conn = new SqlConnection("server=" + txtServer.Text.Trim() + ";user id=" + txtUser.Text + ";password=" + txtPassword.Text + ";");
        DataSet ds = new DataSet();
        try
        {
            conn.Open();

            StringBuilder sb = new StringBuilder();

            sb.Append("Select Name FROM Master..SysDatabases order by Name");

            SqlDataAdapter da = new SqlDataAdapter(sb.ToString(), conn);
            da.Fill(ds);
        }
        finally
        {
            conn.Close();
        }
        return ds;
    }
    #endregion

    #region  绑定表名
    private void BindTableNameDDL()
    {
        ddlTableName.Items.Clear();
        DataTable dt = GetTableNameDS().Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ddlTableName.Items.Insert(i, new ListItem(dt.Rows[i]["TABLE_NAME"].ToString(), dt.Rows[i]["TABLE_NAME"].ToString()));
        }
    }

    protected DataSet GetTableNameDS()
    {
        SqlConnection conn = new SqlConnection("server=" + txtServer.Text.Trim() + ";user id=" + txtUser.Text + ";password=" + txtPassword.Text + ";database=" + ddlDatabase.SelectedItem.Text);
        DataSet ds = new DataSet();
        try
        {
            conn.Open();

            StringBuilder sb = new StringBuilder();

            sb.Append("select * from information_schema.tables where TABLE_TYPE='BASE TABLE' and TABLE_NAME<>'sysdiagrams' order by TABLE_NAME asc");

            SqlDataAdapter da = new SqlDataAdapter(sb.ToString(), conn);
            da.Fill(ds);
        }
        finally
        {
            conn.Close();
        }
        return ds;
    }
    #endregion

    private string UsingString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("using System.Data;\n");
        sb.Append("using System.Data.SqlClient;\n");
        return sb.ToString();
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        txtContent.Text = CreateString();
        txtCode.Text = CreateCallBack();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    #region  获取所有字段信息
    protected DataSet GetDS()
    {
        SqlConnection conn = new SqlConnection("server=" + txtServer.Text.Trim() + ";user id=" + txtUser.Text + ";password=" + txtPassword.Text + ";database=" + ddlDatabase.SelectedItem.Text);
        DataSet ds = new DataSet();
        try
        {
            conn.Open();

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT  c.name AS ColumnName, t2.name AS Type, c.max_length AS MaxLength, c.precision, c.scale, c.is_nullable AS Nullable,");
            sb.Append("t.name AS TableName ");
            sb.Append("FROM     sys.tables AS t INNER JOIN ");
            sb.Append("sys.columns AS c ON c.object_id = t.object_id INNER JOIN ");
            sb.Append("sys.systypes AS t2 ON c.user_type_id = t2.xusertype LEFT OUTER JOIN ");
            sb.Append("(SELECT  B.COLUMN_NAME, 1 AS P, B.TABLE_NAME ");
            sb.Append("FROM     INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS A INNER JOIN ");
            sb.Append("INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE AS B ON A.TABLE_NAME = B.TABLE_NAME AND ");
            sb.Append("A.CONSTRAINT_NAME = B.CONSTRAINT_NAME ");
            sb.Append("WHERE  (A.CONSTRAINT_TYPE = 'PRIMARY KEY')) AS P2 ON c.name = P2.COLUMN_NAME AND ");
            sb.Append("t.name = P2.TABLE_NAME ");
            sb.Append("WHERE  (t.is_ms_shipped = 0) AND (t.name <> 'sysdiagrams') ");
            sb.Append("ORDER BY tablename, c.column_id");

            SqlDataAdapter da = new SqlDataAdapter(sb.ToString(), conn);
            da.Fill(ds);
        }
        finally
        {
            conn.Close();
        }
        return ds;
    }
    #endregion

    private string CreateString()
    {
        StringBuilder sb = new StringBuilder();
        string pk_ID = "pk_ID";
        string ColumNnameList = string.Empty;

        DataTable dt = GetDS().Tables[0];
        DataView dv = new DataView(dt);
        dv.RowFilter = "TableName='" + ddlTableName.SelectedItem.Text + "'";
        DataTable dt_New = dv.ToTable();

        #region  公共属性
        sb.Append("#region 公共属性\n");
        if (dt_New.Rows.Count > 0)
        {
            string type = string.Empty;
            for (int i = 0; i < dt_New.Rows.Count; i++)
            {
                if (i == 0)
                {
                    pk_ID = dt_New.Rows[0]["ColumnName"].ToString();
                }
                else
                {
                    ColumNnameList += dt_New.Rows[i]["ColumnName"].ToString() + ",";
                }
                type = GetType(dt_New.Rows[i]["Type"].ToString());
                sb.Append(type + " _" + dt_New.Rows[i]["ColumnName"].ToString() + ";\n");
                sb.Append("public " + type + " " + dt_New.Rows[i]["ColumnName"].ToString() + "\n");
                sb.Append("{\n");
                sb.Append("get { return _" + dt_New.Rows[i]["ColumnName"].ToString() + "; }\n");
                sb.Append("set { _" + dt_New.Rows[i]["ColumnName"].ToString() + " = value; }\n");
                sb.Append("}\n");
            }
            if (ColumNnameList.Length > 0)
            {
                ColumNnameList = ColumNnameList.Substring(0, ColumNnameList.Length - 1);
            }
        }
        sb.Append("#endregion\n\n");
        #endregion

        #region  公共方法
        sb.Append("#region 公共方法\n\n");

        //////////////////////////////////////////////////////GetData///////////////////////////////////////////////////////////
        sb.Append("/// <summary>\n");
        sb.Append("/// 获取字段值\n");
        sb.Append("/// </summary>\n");
        sb.Append("/// <param name=\"id\">ID</param>\n");
        sb.Append("public void GetData(int id)\n");
        sb.Append("{\n");
        sb.Append("SqlConnection conn = new SqlConnection(Connection.ConnString());\n");
        sb.Append("try\n");
        sb.Append("{\n");
        sb.Append("conn.Open();\n");
        sb.Append("string sql = \"select * from " + ddlTableName.SelectedItem.Text + " where " + pk_ID + "=@" + pk_ID + "\";\n");
        sb.Append("SqlCommand comm = new SqlCommand(sql, conn);\n");
        sb.Append("comm.Parameters.Add(new SqlParameter(\"@" + pk_ID + "\", SqlDbType.Int));\n");
        sb.Append("comm.Parameters[\"@" + pk_ID + "\"].Value = id;\n");
        sb.Append("SqlDataReader dr = comm.ExecuteReader();\n");
        sb.Append("if (dr.Read())\n");
        sb.Append("{\n");
        if (dt_New.Rows.Count > 0)
        {
            for (int i = 0; i < dt_New.Rows.Count; i++)
            {
                if (dt_New.Rows[i]["ColumnName"].ToString() == "ModifyUserID")
                {
                    sb.Append("if (dr[\"ModifyUserID\"] != DBNull.Value)\n");
                    sb.Append("{\n");
                    sb.Append("_ModifyUserID = Convert.ToInt32(dr[\"ModifyUserID\"].ToString());\n");
                    sb.Append("}\n");
                    sb.Append("else\n");
                    sb.Append("{\n");
                    sb.Append("_ModifyUserID = 0;\n");
                    sb.Append("}\n");
                }
                else
                {
                    sb.Append(CreateDBSqlValue(dt_New.Rows[i]["Type"].ToString(), dt_New.Rows[i]["ColumnName"].ToString()) + "\n");
                }
            }
        }
        sb.Append("}\n");
        sb.Append("}\n");
        sb.Append("finally\n");
        sb.Append("{\n");
        sb.Append("conn.Close();\n");
        sb.Append("}\n");
        sb.Append("}\n\n");

        ///////////////////////////////////////////////////////InsertData//////////////////////////////////////////////////////////
        sb.Append("/// <summary>\n");
        sb.Append("/// 新增数据，返回ID\n");
        sb.Append("/// </summary>\n");
        sb.Append("/// <returns></returns>\n");
        sb.Append("public int InsertData()\n");
        sb.Append("{\n");
        sb.Append("SqlConnection conn = new SqlConnection(Connection.ConnString());\n");
        sb.Append("try\n");
        sb.Append("{\n");
        sb.Append("conn.Open();\n");
        sb.Append("string sql = \"insert into " + ddlTableName.SelectedItem.Text + "(" + ColumNnameList + ") values (" + SetInsertString(ColumNnameList) + ")\";\n");
        sb.Append("SqlCommand comm = new SqlCommand(sql, conn);\n");
        if (dt_New.Rows.Count > 0)
        {
            for (int i = 1; i < dt_New.Rows.Count; i++)
            {
                sb.Append(CreateSqlParameter(dt_New.Rows[i]["Type"].ToString(), dt_New.Rows[i]["ColumnName"].ToString(), dt_New.Rows[i]["MaxLength"].ToString()));
            }
        }
        sb.Append("comm.ExecuteNonQuery();\n");
        sb.Append("comm.CommandText = \"select @@identity\";\n");
        sb.Append("return Convert.ToInt32(comm.ExecuteScalar());\n");
        sb.Append("}\n");
        sb.Append("catch\n");
        sb.Append("{\n");
        sb.Append("return 0;\n");
        sb.Append("}\n");
        sb.Append("finally\n");
        sb.Append("{\n");
        sb.Append("conn.Close();\n");
        sb.Append("}\n");
        sb.Append("}\n\n");

        /////////////////////////////////////////////////////////UpdateData////////////////////////////////////////////////////////
        sb.Append("/// <summary>\n");
        sb.Append("/// 修改数据\n");
        sb.Append("/// </summary>\n");
        sb.Append("/// <param name=\"id\">ID</param>\n");
        sb.Append("public void UpdateData(int id)\n");
        sb.Append("{\n");
        sb.Append("SqlConnection conn = new SqlConnection(Connection.ConnString());\n");
        sb.Append("try\n");
        sb.Append("{\n");
        sb.Append("conn.Open();\n");
        sb.Append("string sql = \"update " + ddlTableName.SelectedItem.Text + " set " + SetUpdateString(ColumNnameList) + " where " + pk_ID + "=@" + pk_ID + "\";\n");
        sb.Append("SqlCommand comm = new SqlCommand(sql, conn);\n");
        if (dt_New.Rows.Count > 0)
        {
            for (int i = 1; i < dt_New.Rows.Count; i++)
            {
                sb.Append(CreateSqlParameter(dt_New.Rows[i]["Type"].ToString(), dt_New.Rows[i]["ColumnName"].ToString(), dt_New.Rows[i]["MaxLength"].ToString()));
            }
        }
        sb.Append("comm.Parameters.Add(new SqlParameter(\"@" + pk_ID + "\", SqlDbType.Int));\n");
        sb.Append("comm.Parameters[\"@" + pk_ID + "\"].Value = id;\n");
        sb.Append("comm.ExecuteNonQuery();\n");
        sb.Append("}\n");
        sb.Append("finally\n");
        sb.Append("{\n");
        sb.Append("conn.Close();\n");
        sb.Append("}\n");
        sb.Append("}\n\n");

        /////////////////////////////////////////////////////////DeleteData////////////////////////////////////////////////////////
        sb.Append("/// <summary>\n");
        sb.Append("/// 删除数据\n");
        sb.Append("/// </summary>\n");
        sb.Append("/// <param name=\"id\">ID</param>\n");
        sb.Append("public void DeleteData(int id)\n");
        sb.Append("{\n");
        sb.Append("Sql.SqlQuery(\"delete from " + ddlTableName.SelectedItem.Text + " where " + pk_ID + "=\" + id);\n");
        sb.Append("}\n\n");

        sb.Append("#endregion");
        #endregion

        return sb.ToString();
    }

    #region  生成字符串代码
    private string SetInsertString(string str)
    {
        StringBuilder sb = new StringBuilder();
        string[] column = str.Split(',');
        for (int i = 0; i < column.Length; i++)
        {
            sb.Append("@" + column[i] + ",");
        }
        str = sb.ToString();
        if (str.Length > 0)
        {
            str = str.Substring(0, str.Length - 1);
        }
        return str;
    }

    private string SetUpdateString(string str)
    {
        StringBuilder sb = new StringBuilder();
        string[] column = str.Split(',');
        for (int i = 0; i < column.Length; i++)
        {
            sb.Append(column[i] + "=@" + column[i] + ",");
        }
        str = sb.ToString();
        if (str.Length > 0)
        {
            str = str.Substring(0, str.Length - 1);
        }
        return str;
    }
    #endregion

    #region 根据类型生成不同的代码
    private string GetType(string type)
    {
        switch (type)
        {
            case "int":
                type = "int";
                break;
            case "nvarchar":
                type = "string";
                break;
            case "varchar":
                type = "string";
                break;
            case "bit":
                type = "bool";
                break;
            case "datetime":
                type = "string";
                break;
            case "decimal":
                type = "decimal";
                break;
            case "money":
                type = "decimal";
                break;
            default:
                type = "string";
                break;
        }
        return type;
    }

    private string GetTypeName(string type)
    {
        switch (type)
        {
            case "int":
                type = "Int";
                break;
            case "nvarchar":
                type = "NVarChar";
                break;
            case "varchar":
                type = "VarChar";
                break;
            case "bit":
                type = "Bit";
                break;
            case "datetime":
                type = "DateTime";
                break;
            case "decimal":
                type = "Decimal";
                break;
            case "money":
                type = "Money";
                break;
            default:
                type = "VarChar";
                break;
        }
        return type;
    }

    private string CreateDBSqlValue(string type, string cname)
    {
        switch (type)
        {
            case "int":
                type = "_" + cname + " = Convert.ToInt32(dr[\"" + cname + "\"].ToString());";
                break;
            case "nvarchar":
                type = "_" + cname + " = dr[\"" + cname + "\"].ToString();";
                break;
            case "varchar":
                type = "_" + cname + " = dr[\"" + cname + "\"].ToString();";
                break;
            case "bit":
                type = "_" + cname + " = Convert.ToBoolean(dr[\"" + cname + "\"].ToString());";
                break;
            case "datetime":
                type = "_" + cname + " = dr[\"" + cname + "\"].ToString();";
                break;
            case "decimal":
                type = "_" + cname + " = Convert.ToDecimal(dr[\"" + cname + "\"].ToString());";
                break;
            case "money":
                type = "_" + cname + " = Convert.ToDecimal(dr[\"" + cname + "\"].ToString());";
                break;
            default:
                type = "_" + cname + " = dr[\"" + cname + "\"].ToString();";
                break;
        }
        return type;
    }

    private string CreateSqlParameter(string type, string cname, string len)
    {
        StringBuilder sb = new StringBuilder();
        switch (type)
        {
            case "int":
                sb.Append("comm.Parameters.Add(new SqlParameter(\"@" + cname + "\", SqlDbType.Int));\n");
                break;
            case "nvarchar":
                if (len == "-1")
                {
                    len = "-2";
                }
                sb.Append("comm.Parameters.Add(new SqlParameter(\"@" + cname + "\", SqlDbType.NVarChar, " + (int.Parse(len) / 2).ToString() + "));\n");
                break;
            case "varchar":
                sb.Append("comm.Parameters.Add(new SqlParameter(\"@" + cname + "\", SqlDbType.VarChar, " + len + "));\n");
                break;
            case "bit":
                sb.Append("comm.Parameters.Add(new SqlParameter(\"@" + cname + "\", SqlDbType.Bit));\n");
                break;
            case "datetime":
                sb.Append("comm.Parameters.Add(new SqlParameter(\"@" + cname + "\", SqlDbType.DateTime));\n");
                break;
            case "decimal":
                sb.Append("comm.Parameters.Add(new SqlParameter(\"@" + cname + "\", SqlDbType.Decimal));\n");
                break;
            case "money":
                sb.Append("comm.Parameters.Add(new SqlParameter(\"@" + cname + "\", SqlDbType.Money));\n");
                break;
            default:
                sb.Append("comm.Parameters.Add(new SqlParameter(\"@" + cname + "\", SqlDbType.NVarChar, " + len + "));\n");
                break;
        }
        sb.Append("comm.Parameters[\"@" + cname + "\"].Value = _" + cname + ";\n");
        return sb.ToString();
    }
    #endregion

    #region  调用数据层函数
    private string CreateCallBack()
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = GetDS().Tables[0];
        DataView dv = new DataView(dt);
        dv.RowFilter = "TableName='" + ddlTableName.SelectedItem.Text + "'";
        DataTable dt_New = dv.ToTable();

        if (dt_New.Rows.Count > 0)
        {
            string name = "replaceText";
            if (ddlTableName.SelectedItem.Text.Split('_').Length > 1)
            {
                name = ddlTableName.SelectedItem.Text.Split('_')[1].ToLower();
            }
            string className = ddlTableName.SelectedItem.Text.Replace("_", ".");
            sb.Append("MojoCube.Web." + className + " " + name + " = new MojoCube.Web." + className + "();\n");
            for (int i = 1; i < dt_New.Rows.Count; i++)
            {
                sb.Append(name + "." + dt_New.Rows[i]["ColumnName"].ToString() + " = " + GetReplaceValue(dt_New.Rows[i]["Type"].ToString(), dt_New.Rows[i]["ColumnName"].ToString()) + ";\n");
            }
            sb.Append(name + ".InsertData();");
        }

        return sb.ToString();
    }
    private string GetReplaceValue(string type, string cname)
    {
        switch (type)
        {
            case "int":
                type = "0";
                break;
            case "nvarchar":
                type = "txt" + cname + ".Text.Trim()";
                break;
            case "varchar":
                type = "txt" + cname + ".Text.Trim()";
                break;
            case "bit":
                type = "false";
                break;
            case "datetime":
                type = "DateTime.Now.ToString()";
                break;
            case "decimal":
                type = "0";
                break;
            default:
                type = "txt" + cname + ".Text.Trim()";
                break;
        }
        if (cname == "CreateUserID")
        {
            type = "int.Parse(Session[\"Member_UserID\"].ToString())";
        }
        return type;
    }
    #endregion

}
