<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Dev_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�����߹��� - MojoCube ħ������</title>    
    <meta name="robots" content="all" />
    <meta name="DC.title" content="MojoCube ħ������" />
    <meta name="author" content="MojoCube ħ������" />
    <meta name="copyright" content="MojoCube ħ������" />
    <meta name="keywords" content="MojoCube,ħ������,McCMS,McCart,Mobile,CMS" />
    <meta name="description" content="MojoCube ħ�������ǿ�Դ�����ݹ���ϵͳ��McCMS�������ﳵϵͳ��McCart�����ֻ����ݹ���ϵͳ�ṩ�̣�����΢��asp.net 2.0���������ݿ�֧��Mssql��Access��" />
    <link rel="shortcut icon" href="Images/favicon.ico" type="image/x-icon" />
    <link href="Style/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="MainBody">
   
    <div class="header">
        <div class="header-wrap">
            <div class="logo">
                <a href="http://www.mojocube.com/"><img src="Images/logo.png" alt="MojoCube ħ������" /></a>
            </div>
            <div class="header-right">

            </div>
        </div>
    </div>
    
    <div class="nav">
        <div id="nav-menu" class="nav-menu">
            <ul id="nav">
                <li class="focus"><a href="Default.aspx"><span>���ɺ�̨����</span></a></li>
                <li><a href="StringBuilder.aspx"><span>StringBuilder</span></a></li>
            </ul>
        </div>
    </div>
    
    <div class="content-info">
        * �������ݿ����ɾ�Ĵ��룬�Ӷ����Ч�ʣ����ٱ�д�ظ�����ĳ����ʡ�
    </div>
    
    <div class="content-wrap">
        
        <div class="content">
        
            <table>
                <tr>
                    <td>����������</td>
                    <td>
                        <asp:TextBox ID="txtServer" runat="server" Width="800px"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>�û�����</td>
                    <td>
                        <asp:TextBox ID="txtUser" runat="server" Width="800px"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>�� �룺</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" Width="800px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>���ݿ����ƣ�</td>
                    <td>
                        <asp:DropDownList ID="ddlDatabase" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDatabase_SelectedIndexChanged" Width="806px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>���ӱ�����</td>
                    <td>
                        <asp:DropDownList ID="ddlTableName" runat="server" Width="806px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>������ã�</td>
                    <td>
                        <asp:TextBox ID="txtUsing" runat="server" TextMode="MultiLine" Height="50px" Width="800px" onfocus="this.select()"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>��ɾ�Ĵ��룺</td>
                    <td>
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Height="300px" Width="800px" onfocus="this.select()"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>���ô��룺</td>
                    <td>
                        <asp:TextBox ID="txtCode" runat="server" TextMode="MultiLine" Height="300px" Width="800px" onfocus="this.select()"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnCreate" runat="server" Text="����" OnClick="btnCreate_Click" CssClass="btn_s" Font-Bold="true" />
                        <asp:Button ID="btnReset" runat="server" Text="ˢ��" OnClick="btnReset_Click" CssClass="btn_s" />
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