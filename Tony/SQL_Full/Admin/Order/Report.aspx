<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Admin_Order_Report" %>

<%@ Register Src="../Controls/ZedGraph.ascx" TagName="ZedGraph" TagPrefix="MojoCube" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            统计报表
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">统计报表</li>
          </ol>
        </section>

        <section class="content">

        <div class="row">

            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
                <asp:Label ID="lblOrderCount1" runat="server" CssClass="info-box-icon bg-yellow"></asp:Label>
                <div class="info-box-content">
                  <span class="info-box-text">待付款</span>
                  <asp:Label ID="lblOrderAmount1" runat="server" CssClass="info-box-number"></asp:Label>
                  <a href="List.aspx?active=92,93&statusId=0" class="small-box-footer">查看 <i class="fa fa-arrow-circle-right"></i></a>
                </div>
              </div>
            </div>

            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
                <asp:Label ID="lblOrderCount2" runat="server" CssClass="info-box-icon bg-red"></asp:Label>
                <div class="info-box-content">
                  <span class="info-box-text">待发货</span>
                  <asp:Label ID="lblOrderAmount2" runat="server" CssClass="info-box-number"></asp:Label>
                  <a href="List.aspx?active=92,93&statusId=1" class="small-box-footer">查看 <i class="fa fa-arrow-circle-right"></i></a>
                </div>
              </div>
            </div>

            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
                <asp:Label ID="lblOrderCount3" runat="server" CssClass="info-box-icon bg-aqua"></asp:Label>
                <div class="info-box-content">
                  <span class="info-box-text">待收货</span>
                  <asp:Label ID="lblOrderAmount3" runat="server" CssClass="info-box-number"></asp:Label>
                  <a href="List.aspx?active=92,93&statusId=2" class="small-box-footer">查看 <i class="fa fa-arrow-circle-right"></i></a>
                </div>
              </div>
            </div>
            
            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
                <asp:Label ID="lblOrderCount4" runat="server" CssClass="info-box-icon bg-green"></asp:Label>
                <div class="info-box-content">
                  <span class="info-box-text">已完成</span>
                  <asp:Label ID="lblOrderAmount4" runat="server" CssClass="info-box-number"></asp:Label>
                  <a href="List.aspx?active=92,93&statusId=3" class="small-box-footer">查看 <i class="fa fa-arrow-circle-right"></i></a>
                </div>
              </div>
            </div>
            
        </div>

        <div class="row">

        <section class="col-lg-7 connectedSortable">

            <!-- 本月点击率 -->
            <div class="box">
                <div class="box-header">
                  <h3 class="box-title">年度交易额</h3>
                  <div class="pull-right box-tools">
                    <button class="btn btn-primary btn-sm" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-primary btn-sm" data-widget="remove"><i class="fa fa-times"></i></button>
                  </div>
                </div>
                <div class="box-body no-padding" style="text-align:center; border-top:solid 1px #eee; overflow:auto;">
                 
                    <MojoCube:ZedGraph id="ZedGraph1" runat="server" />

                </div>

             </div>
             
        </section>

        <section class="col-lg-5 connectedSortable">

              <!-- 点击率Top 5 -->
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">产品销量Top 5</h3>
                  <div class="pull-right box-tools">
                    <button class="btn btn-primary btn-sm" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-primary btn-sm" data-widget="remove"><i class="fa fa-times"></i></button>
                  </div>
                </div>
                <div class="box-body no-padding" style="text-align:center; border-top:solid 1px #eee; overflow:auto;">
                 
                    <MojoCube:ZedGraph id="ZedGraph2" runat="server" />

                </div>

              </div>
              
            </section>

        </div>

        <div class="row">
        
            <div class="col-md-12">

                <!-- 订单列表 -->
                <div class="box">
                    <div class="box-header">
                      <h3 class="box-title">订单列表（共<asp:Label ID="lblOrderListCount" runat="server"></asp:Label>笔，金额 <asp:Label ID="lblOrderListAmount" runat="server"></asp:Label>）</h3>
                      <div class="pull-right box-tools">
                        <asp:TextBox ID="txtDate1" runat="server" CssClass="input-sm" style="border:solid 1px #ddd; width:120px;" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                        -
                        <asp:TextBox ID="txtDate2" runat="server" CssClass="input-sm" style="border:solid 1px #ddd; width:120px;" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                        <asp:LinkButton ID="lnbSearch1" runat="server" CssClass="btn btn-success btn-sm" onclick="lnbSearch1_Click"><i class="fa fa-search"></i></asp:LinkButton>
                        <button class="btn btn-primary btn-sm" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button class="btn btn-primary btn-sm" data-widget="remove"><i class="fa fa-times"></i></button>
                      </div>
                    </div>

                    <div id="OrderListDiv" runat="server" class="box-body table-responsive no-padding"></div>

                 </div>

             </div>

        </div>
        
        <div class="row">
        
            <div class="col-md-12">

                <!-- 交易记录 -->
                <div class="box">
                    <div class="box-header">
                      <h3 class="box-title">交易记录（共<asp:Label ID="lblOrderLogCount" runat="server"></asp:Label>笔，金额 <asp:Label ID="lblOrderLogAmount" runat="server"></asp:Label>）</h3>
                      <div class="pull-right box-tools">
                        <asp:TextBox ID="txtDate3" runat="server" CssClass="input-sm" style="border:solid 1px #ddd; width:120px;" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                        -
                        <asp:TextBox ID="txtDate4" runat="server" CssClass="input-sm" style="border:solid 1px #ddd; width:120px;" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                        <asp:LinkButton ID="lnbSearch2" runat="server" CssClass="btn btn-success btn-sm" onclick="lnbSearch2_Click"><i class="fa fa-search"></i></asp:LinkButton>
                        <button class="btn btn-primary btn-sm" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button class="btn btn-primary btn-sm" data-widget="remove"><i class="fa fa-times"></i></button>
                      </div>
                    </div>

                    <div id="OrderLogDiv" runat="server" class="box-body table-responsive no-padding"></div>

                 </div>

             </div>

        </div>

    </section>

    </div>

</asp:Content>

