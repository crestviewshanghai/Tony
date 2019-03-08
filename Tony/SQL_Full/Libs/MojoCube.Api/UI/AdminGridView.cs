using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI;

namespace MojoCube.Api.UI
{
    public class AdminGridView
    {
        //在Grid创建时进行表头格式设定
        public static void SetSortingRowCreated(GridViewRowEventArgs e, string strSortBy, bool strSortAscending, GridView GridView1)
        {
            if (e.Row != null && e.Row.RowType == DataControlRowType.Header)
            {
                string img1 = File.Function.GetRelativePath("Admin/Images/asc.gif");
                string img2 = File.Function.GetRelativePath("Admin/Images/desc.gif");

                string strOrder = (strSortAscending == false ? "<img src='" + img1 + "' />" : "<img src='" + img2 + "' />");

                for (int i = 0; i < GridView1.Columns.Count; i++)
                {
                    if (strSortBy == GridView1.Columns[i].SortExpression)
                    {
                        TableCell cell = e.Row.Cells[i];
                        Label lblSorted = new Label();
                        lblSorted.Text = strOrder;
                        cell.CssClass = "sort";
                        cell.Controls.Add(lblSorted);
                    }
                }
            }
        }
        //在Grid创建时进行CommandArgument赋值，对LinkButton有效
        public static void SetDataRow(GridViewRowEventArgs e, string[] controlList)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && controlList.Length > 0)
            {
                for (int i = 0; i < controlList.Length; i++)
                {
                    ((LinkButton)e.Row.FindControl(controlList[i].ToString())).CommandArgument = e.Row.RowIndex.ToString();
                }
            }
        }
        //创建GridView列的方法
        public static void AddGridColumn(GridView gridView, string dataField, string headerText, string headerStyle, string itemStyle)
        {
            BoundField bc = new BoundField();
            bc.DataField = dataField;
            bc.HeaderText = headerText;
            bc.HeaderStyle.CssClass = headerStyle;
            bc.ItemStyle.CssClass = itemStyle;
            gridView.Columns.Add(bc);
        }
    }
}
