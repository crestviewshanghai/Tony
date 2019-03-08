<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderComment.aspx.cs" Inherits="OrderComment" %>

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
                            <asp:HyperLink ID="hlTitle" runat="server" Text="评价"></asp:HyperLink>
                        </span>
                    </div>
                </div>
                <div>
                    
                    <asp:Panel ID="Panel1" runat="server">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" BorderWidth="0px" CssClass="gridview" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("pk_Item") %>' Visible="False"></asp:Label>
                                    <asp:Label ID="lblfkID" runat="server" Text='<%# Bind("fk_ID") %>' Visible="False"></asp:Label>
                                    <asp:Label ID="lblPageName" runat="server" Text='<%# Bind("PageName") %>' Visible="False"></asp:Label>
                                    <asp:Label ID="lblImagePath" runat="server" Text='<%# Bind("ImagePath") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblImage" runat="server" Text='<%# Bind("ImagePath") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="名称">
                                <ItemTemplate>
                                    <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="200px" CssClass="titleTD" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="单价">
                                <ItemTemplate>
                                    <span class="price" style="font-size:11pt;">¥</span> <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>' CssClass="price" style="font-size:11pt;"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="星级">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlScore" runat="server">
                                        <asp:ListItem Value="5">★★★★★</asp:ListItem>
                                        <asp:ListItem Value="4">★★★★☆</asp:ListItem>
                                        <asp:ListItem Value="3">★★★☆☆</asp:ListItem>
                                        <asp:ListItem Value="2">★★☆☆☆</asp:ListItem>
                                        <asp:ListItem Value="1">★☆☆☆☆</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="评价">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Rows="5" style="width:90%;"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    
                    <div style="padding:5px 10px; background:#F7F8F3; border:solid 1px #eee; margin:20px 0; line-height:1.8em;">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    订单编号：<asp:Label ID="lblOrderNumber" runat="server"></asp:Label><br />
                                    订单描述：<asp:Label ID="lblDescription" runat="server"></asp:Label><br />
                                    订单金额：<asp:Label ID="lblAmount" runat="server" CssClass="price" style="font-size:12pt; font-weight:700;"></asp:Label>
                                </td>
                                <td style="width:100px; text-align:right;">
                                    <asp:Button ID="btnSubmit" runat="server" Text="提交评价" CssClass="btn2" onclick="btnSubmit_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    
                    </asp:Panel>
                    
                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                        <div class="cart-empty">
                            <div class="cart-empty-div">
                                <img src="images/cart-empty.png" alt="" />
                            </div>
                            <br />
                            <span class="cart-empty-span1">您的订单还是空荡荡的</span>
                            <br /><br />
                            <asp:HyperLink ID="hlProduct" runat="server"><span class="cart-empty-span2">去挑选</span></asp:HyperLink>
                            <asp:HyperLink ID="hlOrder" runat="server"><span class="cart-empty-span3">查订单</span></asp:HyperLink>
                        </div>
                    </asp:Panel>
          
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