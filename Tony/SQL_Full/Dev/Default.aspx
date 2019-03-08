<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Dev_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>开发者工具 - MojoCube 魔方动力</title>    
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
                <li class="focus"><a href="Default.aspx"><span>生成后台代码</span></a></li>
                <li><a href="StringBuilder.aspx"><span>StringBuilder</span></a></li>
            </ul>
        </div>
    </div>
    
    <div class="content-info">
        * 生成数据库的增删改代码，从而提高效率，减少编写重复代码的出错几率。
    </div>
    
    <div class="content-wrap">
        
        <div class="content">
        
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
                        <asp:TextBox ID="txtUser" runat="server" Width="800px"></asp:TextBox>
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
                        <asp:DropDownList ID="ddlDatabase" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDatabase_SelectedIndexChanged" Width="806px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>连接表名：</td>
                    <td>
                        <asp:DropDownList ID="ddlTableName" runat="server" Width="806px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>添加引用：</td>
                    <td>
                        <asp:TextBox ID="txtUsing" runat="server" TextMode="MultiLine" Height="50px" Width="800px" onfocus="this.select()"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>增删改代码：</td>
                    <td>
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Height="300px" Width="800px" onfocus="this.select()"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>调用代码：</td>
                    <td>
                        <asp:TextBox ID="txtCode" runat="server" TextMode="MultiLine" Height="300px" Width="800px" onfocus="this.select()"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnCreate" runat="server" Text="生成" OnClick="btnCreate_Click" CssClass="btn_s" Font-Bold="true" />
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