<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Comment.aspx.cs" Inherits="Comment" %>

<%@ Register Src="WUC_Header.ascx" TagName="WUC_Header" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Menu.ascx" TagName="WUC_Menu" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Banner.ascx" TagName="WUC_Banner" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Footer.ascx" TagName="WUC_Footer" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_MobileMenu.ascx" TagName="WUC_MobileMenu" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Service.ascx" TagName="WUC_Service" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Article.ascx" TagName="WUC_Article" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Contact.ascx" TagName="WUC_Contact" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Product.ascx" TagName="WUC_Product" TagPrefix="MojoCube" %>

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
    
    <!-- Banner -->
    <MojoCube:WUC_Banner id="WUC_Banner" runat="server" />

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
                            <asp:HyperLink ID="hlTitle" runat="server" Text="在线留言"></asp:HyperLink>
                        </span>
                    </div>
                </div>
                <form id="ff" runat="server">
                <center>
                    <table cellpadding="3" cellspacing="5" class="reg">
                        <tr>
                            <td align="center" colspan="2">
                                <br />
                                感谢您光临我公司网站，如您有任何疑问请与我们留言，我们会在第一时间联系您！<br />
                                <br />
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
                                电话
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="easyui-validatebox" style="width:90%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                邮箱
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="easyui-validatebox" style="width:90%"></asp:TextBox>
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
                                标题
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="easyui-validatebox" style="width:90%"></asp:TextBox>
                                <span class="must">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                内容
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtContent" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" style="width:90%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                验证码
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCode" runat="server" CssClass="easyui-validatebox" style="width:30%;"></asp:TextBox>
                                <asp:HyperLink ID="hlChange" runat="server" ToolTip="看不清？点击换一张图片" NavigateUrl="javascript:ChangeImage();">
                                    <img id="CodeImage" src="Identify/CheckCode.aspx" style="height:33px; margin-top:-4px;" alt="" />
                                </asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="btn" onclick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" Text="重置" CssClass="btn" onclick="btnReset_Click" />
                            </td>
                        </tr>
                    </table>
                </center>
                </form>

                <!-- 产品展示 -->
                <MojoCube:WUC_Product id="WUC_Product" runat="server" />
                
            </div>
            <div class="col-xs-12 col-sm-4 col-md-3">
                <div class="navigationBox" id="classification">
                    <div class="classTitleBar">
                        导航栏目
                    </div>
                    <div class="list">
                        <ul id="firstpane" runat="server"></ul>
                    </div>
                    <div id="BannerDiv" runat="server" class="telBox"></div>
                </div>
                
                <!-- 新闻中心 -->
                <MojoCube:WUC_Article id="WUC_Article" runat="server" />
                
                <!-- 联系我们 -->
                <MojoCube:WUC_Contact id="WUC_Contact" runat="server" />

            </div>
        </div>
    </div>
    
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