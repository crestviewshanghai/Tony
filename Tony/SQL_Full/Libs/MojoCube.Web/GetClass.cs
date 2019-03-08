using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;

namespace MojoCube.Web
{
    /// <summary>
    /// 无级分类
    /// </summary>
    public class GetClass
    {
        #region  公共属性

        public DataTable ClassDT;
        public string TableName = "";
        public string Where = "";

        #endregion

        #region  公共方法

        #region  绑定表
        public void BindClass()
        {
            ClassDT = new DataTable();
            ClassDT.Columns.Add("Indent");
            ClassDT.Columns.Add("pk_Category");
            ClassDT.Columns.Add("ParentID");
            ClassDT.Columns.Add("LevelID");
            ClassDT.Columns.Add("CategoryName");
            ClassDT.Columns.Add("IndexID");
            ClassDT.Columns.Add("Visible", typeof(bool));
            ClassDT.Columns.Add("SortID");

            DataTable dt = new DataTable();
            dt = Sql.SqlQueryDS("select * from " + TableName + " where ParentID=0" + Where).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = ClassDT.NewRow();

                dr["Indent"] = "╋";
                dr["pk_Category"] = dt.Rows[i]["pk_Category"].ToString();
                dr["ParentID"] = dt.Rows[i]["ParentID"].ToString();
                dr["LevelID"] = dt.Rows[i]["LevelID"].ToString();
                dr["CategoryName"] = dt.Rows[i]["CategoryName"].ToString();
                dr["IndexID"] = dt.Rows[i]["IndexID"].ToString();
                dr["Visible"] = dt.Rows[i]["Visible"].ToString();
                dr["SortID"] = dt.Rows[i]["SortID"].ToString();
                ClassDT.Rows.Add(dr);

                BindChild(dt.Rows[i]["pk_Category"].ToString(), "├──");
            }
        }

        public void BindChild(string ParentID, string separator)
        {
            DataTable dt = new DataTable();
            dt = Sql.SqlQueryDS("select * from " + TableName + " where ParentID=" + ParentID).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = ClassDT.NewRow();

                dr["Indent"] = separator;
                dr["pk_Category"] = dt.Rows[i]["pk_Category"].ToString();
                dr["ParentID"] = dt.Rows[i]["ParentID"].ToString();
                dr["LevelID"] = dt.Rows[i]["LevelID"].ToString();
                dr["CategoryName"] = dt.Rows[i]["CategoryName"].ToString();
                dr["IndexID"] = dt.Rows[i]["IndexID"].ToString();
                dr["Visible"] = dt.Rows[i]["Visible"].ToString();
                dr["SortID"] = dt.Rows[i]["SortID"].ToString();
                ClassDT.Rows.Add(dr);

                string separator_ = separator + "───";
                BindChild(dt.Rows[i]["pk_Category"].ToString(), separator_);
            }
        }
        #endregion

        #region  绑定下拉
        public void BindClass(DropDownList ddl)
        {
            DataTable dt = new DataTable();
            dt = Sql.SqlQueryDS("select * from " + TableName + " where ParentID=0" + Where).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem li = new ListItem();
                li.Text = "╋" + dt.Rows[i]["CategoryName"].ToString();
                li.Value = dt.Rows[i]["pk_Category"].ToString();
                ddl.Items.Add(li);
                BindChild(dt.Rows[i]["pk_Category"].ToString(), "├──", ddl);
            }
        }

        public void BindChild(string ParentID, string separator, DropDownList ddl)
        {
            DataTable dt = new DataTable();
            dt = Sql.SqlQueryDS("select * from " + TableName + " where ParentID=" + ParentID).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem li = new ListItem();
                li.Text = separator + dt.Rows[i]["CategoryName"].ToString();
                li.Value = dt.Rows[i]["pk_Category"].ToString();
                ddl.Items.Add(li);
                string separator_ = separator + "───";
                BindChild(dt.Rows[i]["pk_Category"].ToString(), separator_, ddl);
            }
        }
        #endregion

        #endregion
    }
}
