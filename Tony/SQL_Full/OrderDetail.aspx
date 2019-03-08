<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderDetail.aspx.cs" Inherits="OrderDetail" %>

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
                            <asp:HyperLink ID="hlTitle" runat="server" Text="订单详情"></asp:HyperLink>
                        </span>
                    </div>
                </div>
                <div>
                    
                    <asp:Panel ID="Panel1" runat="server">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" Width="100%" BorderWidth="0px" OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated" OnRowCommand="GridView1_RowCommand">
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("pk_Order") %>' Visible="false"></asp:Label>
                                    <asp:CheckBox ID="cbComment" runat="server" Checked='<%# Bind("IsComment") %>' Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    
                                    <table class="orderTB">
                                        <tr>
                                            <td>
                                                <table class="orderTB1">
                                                    <tr>
                                                        <td style="width:10px; height:40px;">
                                                        </td>
                                                        <td>
                                                            <b><asp:Label ID="lblCreateDate" runat="server" Text='<%# String.Format("{0:yyyy-MM-dd}",DataBinder.Eval(Container.DataItem,"CreateDate")) %>'></asp:Label></b>
                                                            订单编号：<asp:Label ID="lblOrderNumber" runat="server" Text='<%# Bind("OrderNumber") %>'></asp:Label>
                                                        </td>
                                                        <td style="width:50px;">
                                                            <asp:LinkButton ID="lnbDelete" runat="server" CommandName="_delete" OnClientClick="{return confirm('确定删除吗？');}" Visible="false"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table class="orderTB2">
                                                    <tr>
                                                        <td style="text-align:left; border:0px;">
                                                            <asp:Label ID="lblOrderItem" runat="server"></asp:Label>
                                                        </td>
                                                        <td style="width:120px; padding:20px 0px" valign="top">
                                                            <b><asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label></b>
                                                        </td>
                                                        <td style="width:120px; padding:20px 0px; line-height:22px;" valign="top">
                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("StatusID") %>' ForeColor="Black"></asp:Label><br />
                                                            <asp:HyperLink ID="hlOrder" runat="server">订单详情</asp:HyperLink><br />
                                                            <asp:HyperLink ID="hlExpress" runat="server" Visible="false">查看物流</asp:HyperLink>
                                                            <div>
                                                                <asp:HyperLink ID="hlPay" runat="server" Visible="false"><span class="order-pay">付款</span></asp:HyperLink>
                                                                <asp:LinkButton ID="lnbCancel" runat="server" CommandName="_cancel" Visible="false" OnClientClick="{return confirm('确定取消该订单吗？');}"><span class="order-cancel">取消</span></asp:LinkButton>
                                                                <asp:LinkButton ID="lblComplete" runat="server" CommandName="_complete" Visible="false" OnClientClick="{return confirm('确定收货吗？');}"><span class="order-complete">收货</span></asp:LinkButton>
                                                            </div>
                                                            <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                                                        </td>
                                                        <td style="width:120px; padding:20px 0px" valign="top">
                                                            <asp:HyperLink ID="hlComment" runat="server" Visible="false">评价</asp:HyperLink>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    
                    <div style="padding:5px 10px; background:#F7F8F3; border:solid 1px #eee; margin:20px 0; line-height:1.8em;">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    联 系 人：<asp:Label ID="lblContactName" runat="server"></asp:Label><br />
                                    收货地址：<asp:Label ID="lblAddress" runat="server"></asp:Label><br />
                                    联系电话：<asp:Label ID="lblContactPhone" runat="server"></asp:Label><br />
                                    订单备注：<asp:Label ID="lblRemark" runat="server"></asp:Label>
                                </td>
                                <td style="width:100px; text-align:right;">
                                    <input id="btnBack" type="button" value="返回" onclick="javascript:history.back();" class="btn2" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    
                    <div style="padding:5px 10px; background:#F7F8F3; border:solid 1px #eee; margin:20px 0; line-height:1.8em;">
                        <h4>订单记录</h4>
                        <div id="HistoryInfo" runat="server"></div>
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