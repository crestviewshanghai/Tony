<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="Message" %>

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

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

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
                            <asp:HyperLink ID="hlTitle" runat="server" Text="消息中心"></asp:HyperLink>
                        </span>
                    </div>
                </div>
                
                <div>
                
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" BorderWidth="0px" CssClass="gridview" OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated" OnRowCommand="GridView1_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="选">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("pk_Message") %>' Visible="False"></asp:Label>
                                    <asp:CheckBox ID="cbRead" runat="server" Checked='<%# Bind("IsRead") %>' Visible="False" />
                                    <asp:CheckBox ID="cbSelect" runat="server" Checked="true" />
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="标题">
                                <ItemTemplate>
                                    <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="200px" CssClass="titleTD" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="内容">
                                <ItemTemplate>
                                    <asp:Label ID="lblContents" runat="server" Text='<%# Bind("Contents") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="titleTD" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnbRead" runat="server" CommandName="_read"></asp:LinkButton>
                                    <asp:LinkButton ID="lnbDelete" runat="server" CommandName="_delete" OnClientClick="{return confirm('确定删除吗？');}"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
                
                <div style="padding:5px; background:#F7F8F3; border:solid 1px #eee; margin:20px 0;">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;&nbsp;<asp:LinkButton ID="lnbSelect1" runat="server" onclick="lnbSelect1_Click">全选</asp:LinkButton>
                                &nbsp;&nbsp;<asp:LinkButton ID="lnbSelect2" runat="server" onclick="lnbSelect2_Click">反选</asp:LinkButton>
                                &nbsp;&nbsp;<asp:LinkButton ID="lnbDelete" runat="server" onclick="lnbDelete_Click" OnClientClick="{return confirm('确定删除吗？');}">批量删除</asp:LinkButton>
                            </td>
                            <td style="width:100px; text-align:right;">
                                <asp:Button ID="btnRead" runat="server" Text="已读" CssClass="btn2" onclick="btnRead_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                    
                <div class="pager">
                    <webdiyer:AspNetPager id="ListPager" runat="server"></webdiyer:AspNetPager>
                </div>

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