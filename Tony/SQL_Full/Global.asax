<%@ Application Language="C#" %>

<script runat="server">

    void Application_AcquireRequestState(object sender, EventArgs e)
    {
        //语言设置
        MojoCube.Api.UI.Language.InitLanguage();

        //锁定IP
        if (MojoCube.Web.IP.IsBound(MojoCube.Api.UI.Language.GetLanguage()))
        {
            Response.Write("你的IP已被锁定！");
            Response.End();
        }
    }
       
</script>
