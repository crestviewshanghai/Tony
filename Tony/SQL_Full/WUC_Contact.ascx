<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_Contact.ascx.cs" Inherits="WUC_Contact" %>

<div class="contactBox">
    <div class="titleBar">
        <h1>联系我们</h1>
        <span>/Contact us</span> 
        <asp:HyperLink ID="hlMore" runat="server" CssClass="rightMore">+More</asp:HyperLink>
    </div>
    <div id="ContactDiv" runat="server"></div>
</div>

<div class="btn-group dropup" style="margin-bottom: 15px;">
    <button type="button" class="btn btn-default btn-sm" data-toggle="dropdown" aria-expanded="false"
            style="line-height:13px;">
        &nbsp;&nbsp;&nbsp;&nbsp;友情链接&nbsp;&nbsp;&nbsp;&nbsp;
    </button>
    <button type="button" class="btn btn-default dropdown-toggle btn-sm" style="line-height:13px;">
        <span class="caret"></span><span class="sr-only">友情链接</span>
    </button>
    <ul id="LinkUL" runat="server" class="dropdown-menu" role="menu"></ul>
</div>