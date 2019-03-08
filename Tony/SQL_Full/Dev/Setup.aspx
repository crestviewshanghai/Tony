<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Setup.aspx.cs" Inherits="Dev_Setup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据库安装 - MojoCube 魔方动力</title>
    <meta name="robots" content="all" />
    <meta name="DC.title" content="MojoCube 魔方动力" />
    <meta name="author" content="MojoCube 魔方动力" />
    <meta name="copyright" content="MojoCube 魔方动力" />
    <meta name="keywords" content="MojoCube,魔方动力,McCMS,McCart,Mobile,CMS" />
    <meta name="description" content="MojoCube 魔方动力是开源的内容管理系统（McCMS）、购物车系统（McCart）、手机内容管理系统提供商，采用微软asp.net 2.0开发，数据库支持Mssql、Access。" />
    <link rel="shortcut icon" href="Images/favicon.ico" type="image/x-icon" />
    <link href="Style/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="MainBody">
   
    <div class="header">
        <div class="header-wrap">
            <div class="logo">
                <a href="http://www.mojocube.com/"><img src="Images/logo.png" alt="MojoCube 魔方动力" /></a>
            </div>
            <div class="header-right">

            </div>
        </div>
    </div>
    
    <div class="nav">
        <div id="nav-menu" class="nav-menu">
            <ul id="nav">
                <li class="focus"><a href="Default.aspx"><span>数据库安装</span></a></li>
            </ul>
        </div>
    </div>
    
    <div class="content-info">
        * 第一次配置数据库，请先在Web.Config配置数据库连接串。
    </div>
    
    <div class="content-wrap">
        
        <div class="content" style="height:380px;">
        
            <table>
                <tr>
                    <td>服务器名：</td>
                    <td>
                        <asp:TextBox ID="txtServer" runat="server" Width="800px"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>用户名：</td>
                    <td>
                        <asp:TextBox ID="txtUserID" runat="server" Width="800px"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>密 码：</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" Width="800px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>数据库名称：</td>
                    <td>
                        <asp:TextBox ID="txtDatabase" runat="server" Width="800px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>备份路径：</td>
                    <td>
                        <asp:TextBox ID="txtPath" runat="server" Width="800px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height:50px;"></td>
                    <td>
                        <asp:Button ID="btnCreate" runat="server" Text="创建" OnClick="btnCreate_Click" CssClass="btn_s" Font-Bold="true" />
                        <asp:Button ID="btnReset" runat="server" Text="刷新" OnClick="btnReset_Click" CssClass="btn_s" />
                    </td>
                </tr>
            </table>
        
        </div>
    
    </div> 

    </div>
    
    <div class="copyright">
        <span>&copy; 2016 MojoCube All Rights Reserved.</span>
    </div>

    </form>
</body>
</html>
