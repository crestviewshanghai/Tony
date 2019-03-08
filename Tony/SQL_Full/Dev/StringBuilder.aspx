<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StringBuilder.aspx.cs" Inherits="Dev_StringBuilder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
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
                <li><a href="Default.aspx"><span>生成后台代码</span></a></li>
                <li class="focus"><a href="StringBuilder.aspx"><span>StringBuilder</span></a></li>
            </ul>
        </div>
    </div>
    
    <div class="content-info">
        * 生成StringBuilder的代码，你可以直接在Dreamweaver编写HTML，或者在Sql Server上编写代码，在此均可生成所需的C#代码
    </div>
    
    <div class="content-wrap">
            
        <div class="content">
        
            <table>
                <tr>
                    <td>原始代码：<br/>(HTML)</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="250px" Width="800px" onfocus="this.select()"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>生成代码：</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Height="250px" Width="800px" onfocus="this.select()"></asp:TextBox>
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
