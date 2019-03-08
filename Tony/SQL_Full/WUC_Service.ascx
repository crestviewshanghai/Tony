<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_Service.ascx.cs" Inherits="WUC_Service" %>

<div id="cmsFloatPanel">

    <div class="ctrolPanel">
        <a class="service" href="#"></a>
        <a class="message" href="#"></a>
        <a class="qrcode" href="#"></a>
        <asp:HyperLink ID="hlTop" runat="server" CssClass="arrow" NavigateUrl="#" ToolTip="返回顶部"></asp:HyperLink>
    </div>

    <div class="servicePanel">
        <div class="servicePanel-inner">
            <div class="serviceMsgPanel">
                <div class="serviceMsgPanel-hd"><a href="#"><span>关闭</span></a></div>
                <div id="ServiceDiv" runat="server" class="serviceMsgPanel-bd"></div>
                <div class="serviceMsgPanel-ft"></div>
            </div>
            <div class="arrowPanel">
                <div class="arrow02"></div>
            </div>
        </div>
    </div>

    <div class="messagePanel">
        <div class="messagePanel-inner">
            <div class="formPanel">

                <div class="formPanel-bd">
                    <div id="ShareDiv" runat="server"></div>
                    <a type="button" class="btn btn-default btn-xs" href="#" style="margin: 6px 0px 0px 10px;">关闭</a>
                </div>

            </div>
            <div class="arrowPanel">
                <div class="arrow01"></div>
                <div class="arrow02"></div>
            </div>
        </div>
    </div>

    <div class="qrcodePanel">
        <div class="qrcodePanel-inner">
            <div class="codePanel">
                <div class="codePanel-hd"><asp:Label ID="lblScan" runat="server" Text="用手机扫描二维码" style="float:left"></asp:Label><a href="#"><span>关闭</span></a></div>
                <div class="codePanel-bd">
                    <asp:Image ID="imgQR" runat="server" style="width:180px; height:180px;" />
                </div>
            </div>
            <div class="arrowPanel">
                <div class="arrow01"></div>
                <div class="arrow02"></div>
            </div>
        </div>
    </div>

</div>

<script type="text/javascript" src="js/online.js"></script>
