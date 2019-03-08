using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace MojoCube.Api.UI
{
    public class DropDown
    {
        /// <summary>
        /// ��ֵ
        /// </summary>
        /// <param name="ddl">�����ؼ�</param>
        /// <param name="value">ֵ</param>
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
        /// ���ı�
        /// </summary>
        /// <param name="ddl">�����ؼ�</param>
        /// <param name="text">�ı�</param>
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
