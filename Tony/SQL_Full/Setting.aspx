<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Setting.aspx.cs" Inherits="Setting" %>

<%@ Register Src="WUC_Header.ascx" TagName="WUC_Header" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Menu.ascx" TagName="WUC_Menu" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Banner.ascx" TagName="WUC_Banner" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Footer.ascx" TagName="WUC_Footer" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_MobileMenu.ascx" TagName="WUC_MobileMenu" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Service.ascx" TagName="WUC_Service" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Article.ascx" TagName="WUC_Article" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Contact.ascx" TagName="WUC_Contact" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Product.ascx" TagName="WUC_Product" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_MemberMenu.ascx" TagName="WUC_MemberMenu" TagPrefix="MojoCube" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="applicable-device" content="pc,mobile" />
    <title></title>
</head>

<body>

    <!--[if lt IE 9]>
        <script src="JS/html5shiv.min.js" type="text/javascript"></script>
        <script src="JS/respond.min.js" type="text/javascript"></script>
    <![endif]-->
    
    <script type="text/javascript">
        function ChangeImage() {
            var now = new Date();
            var number = now.getSeconds();
            document.getElementById('CodeImage').src = "Identify/CheckCode.aspx?id=" + number;
        }
    </script>
         
    <header>

        <!-- LOGO、语言、搜索 -->
        <MojoCube:WUC_Header id="WUC_Header" runat="server" />
        
        <!-- 导航菜单 -->
        <MojoCube:WUC_Menu id="WUC_Menu" runat="server" />

    </header>
    
    <form id="form2" runat="server">
    <!-- 内容 -->
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-8 col-md-9" id="rightBox">
                <div class="positionBox">
                    <div class="titleBar">
                        <h1>当前位置</h1>
                        <span>
                            <a href="./">首页</a>
                             > 
                            <asp:HyperLink ID="hlTitle" runat="server" Text="个人设置"></asp:HyperLink>
                        </span>
                    </div>
                </div>
                <center>
                    <table cellpadding="3" cellspacing="5" class="reg">
                        <tr>
                            <td align="center" colspan="2">
                                <br />
                                <asp:Image ID="imgPortrait" runat="server" CssClass="memberpic"></asp:Image>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                头像
                            </td>
                            <td align="left">
                                <asp:FileUpload ID="fuPortrait" runat="server" style="width:90%"></asp:FileUpload>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                密码
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="easyui-validatebox" TextMode="Password" style="width:90%" placeholder="请输入密码"></asp:TextBox>
                                <span class="must">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                手机
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="easyui-validatebox" style="width:90%"></asp:TextBox>
                                <span class="must">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                姓名
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtName" runat="server" CssClass="easyui-validatebox" style="width:90%"></asp:TextBox>
                                <span class="must">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                邮箱
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="easyui-validatebox" style="width:90%"></asp:TextBox>
                                <span class="must">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                地址
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="easyui-validatebox" style="width:90%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                新密码
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPassword1" runat="server" CssClass="easyui-validatebox" TextMode="Password" style="width:90%" placeholder="不修改密码请留空"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                确认密码
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPassword2" runat="server" CssClass="easyui-validatebox" TextMode="Password" style="width:90%" placeholder="不修改密码请留空"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="btn1" onclick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnLogout" runat="server" Text="登出" CssClass="btn1" onclick="btnLogout_Click" />
                            </td>
                        </tr>
                    </table>
                </center>

                <!-- 产品展示 -->
                <MojoCube:WUC_Product id="WUC_Product" runat="server" />
                
            </div>
            <div class="col-xs-12 col-sm-4 col-md-3">
                <div class="navigationBox" id="classification">
                    <div class="classTitleBar">
                        导航栏目
                    </div>
                    
                    <!-- 会员导航 -->
                    <MojoCube:WUC_MemberMenu id="WUC_MemberMenu" runat="server" />

                    <div id="BannerDiv" runat="server" class="telBox"></div>
                </div>
                
                <!-- 新闻中心 -->
                <MojoCube:WUC_Article id="WUC_Article" runat="server" />
                
                <!-- 联系我们 -->
                <MojoCube:WUC_Contact id="WUC_Contact" runat="server" />

            </div>
        </div>
    </div>
    </form>
    
    <!-- 底部菜单、版权信息 -->
    <footer>
        <MojoCube:WUC_Footer id="WUC_Footer" runat="server" />
    </footer>
    
    <!--手机菜单-->
    <MojoCube:WUC_MobileMenu id="WUC_MobileMenu" runat="server" />

    <!--客服面板-->
    <MojoCube:WUC_Service id="WUC_Service" runat="server" />
    
</body>

</html>