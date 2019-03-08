using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MojoCube.Api.UI
{
    public class Script
    {
        /// <summary>
        /// ִ��һ��JavaScript����
        /// </summary>
        /// <param name="page">WEB����ҳ</param>
        /// <param name="key">��ʾ�ű����Ψһ��</param>
        /// <param name="script">�ű�����</param>
        public static void RunScript(Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), "<script language = 'javascript'>" + script + "</script>");
        }

        //ִ��һ��������ʾ��Ϣ
        public static void ScriptMessage(Page page, string text)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), "<script language = 'javascript'>alert('" + text + "');</script>");
        }

        //��Ϣ��ʾ��
        public static void ShowAlert(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), "<script language = 'javascript'>ShowAlert('" + msg + "');</script>");
        }

        //������ʾ��
        public static void ShowError(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), "<script language = 'javascript'>ShowError('" + msg + "');</script>");
        }

        //������ʾ��
        public static void ShowWarning(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), "<script language = 'javascript'>ShowWarning('" + msg + "');</script>");
        }

        //�����ť�¼�ʱ��ʹ��ťdisabled
        public static void ButtonClickDisabled(Button button, Page page, string text)
        {
            button.Attributes["onclick"] = page.GetPostBackEventReference(button) + ";this.disabled=true;this.value='" + text + "';";
        }
        public static void ButtonClickDisabled(LinkButton button, Page page, string text)
        {
            button.Attributes["onclick"] = page.GetPostBackEventReference(button) + ";this.disabled=true;this.innerText='" + text + "';";
        }

        //��FCKEditor����ͼƬ����
        public static string OpenFCKWin(string url)
        {
            return ("javascript:var win=window.open('" + url + "','InsertImages','width=600,height=400,toolbar=0,location=0,directories=0,status=0,menuBar=0,scrollBars=yes,resizable=1');win.focus();");
        }
    }
}
