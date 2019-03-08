<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_Product.ascx.cs" Inherits="WUC_Product" %>

<div class="bottomProductBox">
    <div class="titleBar">
        <h1>
            产品展示
        </h1>
        <span>PRODUCT SHOW</span><a id="bottomProductBtn1" class="bottomButton selectedBottomButton">推荐</a><a id="bottomProductBtn2" class="bottomButton">热销</a><a id="bottomProductBtn3" class="bottomButton">新品</a>
    </div>

    <div id="bottomProductList1" class="list">
        <div id="ProductList1" runat="server"></div>
    </div>
    
    <div id="bottomProductList2" class="list" style="display:none">
        <div id="ProductList2" runat="server"></div>
    </div>
    
    <div id="bottomProductList3" class="list" style="display:none">
        <div id="ProductList3" runat="server"></div>
    </div>
    
</div>