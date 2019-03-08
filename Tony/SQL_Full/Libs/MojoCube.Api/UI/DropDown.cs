using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace MojoCube.Api.UI
{
    public class DropDown
    {
        /// <summary>
        /// 绑定值
        /// </summary>
        /// <param name="ddl">下拉控件</param>
        /// <param name="value">值</param>
        public static void ddlFindByValue(DropDownList ddl, string value)
        {
            try
            {
                ddl.SelectedIndex = -1;
                ddl.Items.FindByValue(value).Selected = true;
            }
            catch { }
        }

        /// <summary>
        /// 绑定文本
        /// </summary>
        /// <param name="ddl">下拉控件</param>
        /// <param name="text">文本</param>
        public static void ddlFindByText(DropDownList ddl, string text)
        {
            try
            {
                ddl.SelectedIndex = -1;
                ddl.Items.FindByText(text).Selected = true;
            }
            catch { }
        }
    }
}
