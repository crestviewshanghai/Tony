<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_Header.ascx.cs" Inherits="WUC_Header" %>

<script type="text/javascript">

    function keydownsearch(evt) {
        if (document.getElementById('queryTxt') != null) {
            evt = (evt) ? evt : ((window.event) ? window.event : "")
            keyCode = evt.keyCode ? evt.keyCode : (evt.which ? evt.which : evt.charCode);
            if (keyCode == 13) {
                Search_Submit();
                return false;
            }
        }
    }

    function Search_Submit() {
        if (document.getElementById('queryTxt').value != '') {
            var searchType = '<%=searchType%>';
            if (searchType == 0) {
                window.location.href = '<%=searchProduct%>?q=' + encodeURI(document.getElementById('queryTxt').value);
            }
            else {
                window.location.href = '<%=searchNews%>?q=' + encodeURI(document.getElementById('queryTxt').value);
            }
        }
        else {
            alert('<%=strAlert%>');
        }
    }

</script>
  
<div id="NotifyDiv" runat="server" visible="false" style="padding:5px 10px; text-align:center; background:#FFFF85; z-index:10; position:relative; top:0px; border-bottom:solid 1px #FFA466; cursor:pointer;" onclick="this.style.display='none'">
    <asp:Label ID="lblNotify" runat="server" style="font-size:11pt; color:#000; font-weight:700;"></asp:Label>
</div>
  
<div class="topBox">
    <div class="borderBottom">
        <div class="container">
            <div class="row">
                <div class="welcomeBox">
                    <asp:Label ID="lblSiteName" runat="server"></asp:Label>
                </div>
                <div class="languageBox">
                    <asp:HyperLink ID="hlCart" runat="server" CssClass="highlight"></asp:HyperLink>
                    <asp:HyperLink ID="hlUser" runat="server"><span class="glyphicon glyphicon-user"></span> 登录/注册</asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-7 col-md-8 logo">
                <asp:HyperLink ID="hlLogo" runat="server"></asp:HyperLink>
            </div>
            <div class="col-xs-12 col-sm-5 col-md-4 pad">
                <div class="searchBox">
                    <input type="text" id="queryTxt" name="queryTxt" onkeydown="keydownsearch(event);" placeholder="请输入关键字" value='<%=strSearch%>' />
                    <a href="javascript:Search_Submit();" type="button">搜 索</a>
                </div>
            </div>
        </div>
    </div>
</div>