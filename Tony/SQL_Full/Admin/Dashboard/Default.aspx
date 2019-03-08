<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Dashboard_Default" %>

<%@ Register Src="../Controls/ZedGraph.ascx" TagName="ZedGraph" TagPrefix="MojoCube" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            控制面板
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">控制面板</li>
          </ol>
        </section>

        <section class="content">

        <div class="row">
            <div class="col-lg-3 col-xs-6">
              <!-- 日志 -->
              <div class="small-box bg-aqua">
                <div id="LogDiv" runat="server" class="inner"></div>
                <div class="icon">
                  <i class="fa fa-clock-o"></i>
                </div>
                <a href="../Site/Log.aspx?active=25,29" class="small-box-footer">更多 <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- 产品 -->
              <div class="small-box bg-yellow">
                <div id="ProductDiv" runat="server" class="inner"></div>
                <div class="icon">
                  <i class="fa fa-cube"></i>
                </div>
                <a href="../Product/List.aspx?active=38,46" class="small-box-footer">更多 <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- 订单 -->
              <div class="small-box bg-green">
                <div id="OrderDiv" runat="server" class="inner"></div>
                <div class="icon">
                  <i class="fa fa-rmb"></i>
                </div>
                <a href="../Order/List.aspx?active=92,93" class="small-box-footer">更多 <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- 留言 -->
              <div class="small-box bg-red">
                <div id="CommentDiv" runat="server" class="inner"></div>
                <div class="icon">
                  <i class="fa fa-comments-o"></i>
                </div>
                <a href="../Comment/List.aspx?active=62,63" class="small-box-footer">更多 <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
          </div>

        <div class="row">

        <section class="col-lg-7 connectedSortable">

            <!-- 本月点击率 -->
            <div class="box">
                <div class="box-header">
                  <h3 class="box-title">本月点击率</h3>
                  <div class="pull-right box-tools">
                    <button class="btn btn-primary btn-sm" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-primary btn-sm" data-widget="remove"><i class="fa fa-times"></i></button>
                  </div>
                </div>
                <div class="box-body no-padding" style="text-align:center; border-top:solid 1px #eee; overflow:auto;">
                 
                    <MojoCube:ZedGraph id="ZedGraph1" runat="server" />

                </div>

             </div>
             
            <!-- 服务器信息 -->
            <div class="box">
                <div class="box-header">
                  <h3 class="box-title">服务器信息</h3>
                  <div class="pull-right box-tools">
                    <button class="btn btn-primary btn-sm" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-primary btn-sm" data-widget="remove"><i class="fa fa-times"></i></button>
                  </div>
                </div>

                <div id="ServerDiv" runat="server" class="box-body table-responsive no-padding"></div>

             </div>
             
        </section>

        <section class="col-lg-5 connectedSortable">

              <!-- 点击率Top 5 -->
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">点击率Top 5</h3>
                  <div class="pull-right box-tools">
                    <button class="btn btn-primary btn-sm" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-primary btn-sm" data-widget="remove"><i class="fa fa-times"></i></button>
                  </div>
                </div>
                <div class="box-body no-padding" style="text-align:center; border-top:solid 1px #eee; overflow:auto;">
                 
                    <MojoCube:ZedGraph id="ZedGraph2" runat="server" />

                </div>

              </div>
              
              <!-- 我的便签 -->
              <div class="box box-success">
                <div class="box-header">
                    <i class="fa fa-pencil"></i>
                    <h3 class="box-title">我的便签</h3>
                    <div class="pull-right box-tools">
                        <div class="btn-group">
                          <button class="btn btn-success btn-sm dropdown-toggle" data-toggle="dropdown"><i class="fa fa-bars"></i></button>
                          <ul class="dropdown-menu pull-right" role="menu">
                            <li><a href="../User/Profile.aspx">我的便签</a></li>
                          </ul>
                        </div>
                        <button class="btn btn-success btn-sm" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button class="btn btn-success btn-sm" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <div class="box-body chat" id="chat-box">

                    <div id="MemoDiv" runat="server"></div>

                </div>
                <div class="box-footer">
                    <div class="input-group">
                    <asp:TextBox ID="txtMemoContent" runat="server" CssClass="form-control" placeholder="便签内容"></asp:TextBox>
                    <div class="input-group-btn">
                        <asp:LinkButton ID="lnbSaveMemo" runat="server" CssClass="btn btn-success" onclick="lnbSaveMemo_Click"><i class="fa fa-plus"></i></asp:LinkButton>
                    </div>
                    </div>
                </div>

               </div>

            </section>

        </div>

    </section>

    </div>

</asp:Content>

