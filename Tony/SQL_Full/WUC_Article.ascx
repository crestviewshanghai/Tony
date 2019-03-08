<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_Article.ascx.cs" Inherits="WUC_Article" %>

<div class="newsBox leftNews">
    <div class="titleBar">
        <h1>新闻中心</h1>
        <span>/News center</span> 
        <asp:HyperLink ID="hlMore" runat="server" CssClass="rightMore">+More</asp:HyperLink>
    </div>
    <ul id="ArticleUL" runat="server" class="newsList"></ul>
</div>
                