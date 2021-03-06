﻿<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="CategoryEdit.aspx.cs" Inherits="Admin_Article_CategoryEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            文章分类
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">文章分类</li>
          </ol>
        </section>

        <section class="content">
        
          <div id="AlertDiv" runat="server"></div>

          <div class="row">
            <div class="col-xs-12">
              <div class="nav-tabs-custom">

                <div class="box-header with-border">
                  <h3 class="box-title">
                      <asp:HyperLink ID="hlBack" runat="server"><span class="label label-back"><i class="fa fa-chevron-left"></i> 返回</span></asp:HyperLink>
                  </h3>
                </div>

                <ul class="nav nav-tabs">
                  <li class="active"><a href="#info" data-toggle="tab">基本信息</a></li>
                  <li><a href="#seo" data-toggle="tab">SEO信息</a></li>
                </ul>
                <div class="tab-content">
                  
                  <div class="active tab-pane" id="info">
                  
                  <div class="box-body">

                      <div class="row">
                            
                        <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label3" runat="server" Text="分类名称"></asp:Label></label>
                            <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                  
                        <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label4" runat="server" Text="页面名称"></asp:Label></label>
                            <asp:TextBox ID="txtPageName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                  
                        <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label6" runat="server" Text="排序"></asp:Label></label>
                            <asp:TextBox ID="txtSortID" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                  
                        <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label1" runat="server" Text="显示"></asp:Label></label>
                            <br />
                            <asp:CheckBox ID="cbVisible" runat="server"></asp:CheckBox>
                        </div>
                  
                      </div>
                        
                    </div>
                    
                  </div>

                  <div class="tab-pane" id="seo">

                    <div class="box-body">
                      <div class="row">

                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label10" runat="server" Text="SEO标题"></asp:Label></label>
                            <asp:TextBox ID="txtSEO_Title" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                  
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label11" runat="server" Text="SEO关键字"></asp:Label></label>
                            <asp:TextBox ID="txtSEO_Keyword" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                  
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label12" runat="server" Text="SEO描述"></asp:Label></label>
                            <asp:TextBox ID="txtSEO_Description" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                          </div>
                  
                      </div>

                    </div>
            
                  </div>
                  
                  <div class="box-footer">
                      <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                      <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="btn btn-default" onclick="btnCancel_Click"></asp:Button>
                  </div>

                </div>
              </div>
            </div>
          </div>

        </section>

      </div>

</asp:Content>


