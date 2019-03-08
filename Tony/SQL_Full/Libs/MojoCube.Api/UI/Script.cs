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
        /// 执行一条JavaScript函数
        /// </summary>
        /// <param name="page">WEB窗体页</param>
        /// <param name="key">标示脚本块的唯一键</param>
        /// <param name="script">脚本内容</param>
        public static void RunScript(Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), "<script language = 'javascript'>" + script + "</script>");
        }

        //执行一条返回提示信息
        public static void ScriptMessage(Page page, string text)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), "<script language = 'javascript'>alert('" + text + "');</script>");
        }

        //消息提示框
        public static void ShowAlert(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), "<script language = 'javascript'>ShowAlert('" + msg + "');</script>");
        }

        //错误提示框
        public static void ShowError(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), "<script language = 'javascript'>ShowError('" + msg + "');</script>");
        }

        //警告提示框
        public static void ShowWarning(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), "<script language = 'javascript'>ShowWarning('" + msg + "');</script>");
        }

        //点击按钮事件时，使按钮disabled
        public static void ButtonClickDisabled(Button button, Page page, string text)
        {
            button.Attributes["onclick"] = page.GetPostBackEventReference(button) + ";this.disabled=true;this.value='" + text + "';";
        }
        public static void ButtonClickDisabled(LinkButton button, Page page, string text)
        {
            button.Attributes["onclick"] = page.GetPostBackEventReference(button) + ";this.disabled=true;this.innerText='" + text + "';";
        }

        //打开FCKEditor插入图片窗口
        public static string OpenFCKWin(string url)
        {
            return ("javascript:var win=window.open('" + url + "','InsertImages','width=600,height=400,toolbar=0,location=0,directories=0,status=0,menuBar=0,scrollBars=yes,resizable=1');win.focus();");
        }
    }
}
