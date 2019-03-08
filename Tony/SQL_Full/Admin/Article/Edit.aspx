<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Admin_Article_Edit" %>

<%@ Register Src="Nav.ascx" TagName="Nav" TagPrefix="MojoCube" %>

<%@ Register Src="../Controls/CKeditor.ascx" TagName="CKeditor" TagPrefix="MojoCube" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            文章管理
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">文章管理</li>
          </ol>
        </section>

        <section class="content">
            <div class="row">
        
                <MojoCube:Nav id="Nav" runat="server" />
    
                <div class="col-md-9">
                
                  <div id="AlertDiv" runat="server"></div>

                  <div class="box box-primary">
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
                              <div class="form-group">
                                 <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control select2"></asp:DropDownList>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label10" runat="server" Text="标题"></asp:Label></label>
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <MojoCube:CKeditor id="txtDescription" runat="server" />
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label4" runat="server" Text="页面名称"></asp:Label></label>
                                <asp:TextBox ID="txtPageName" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label5" runat="server" Text="副标题"></asp:Label></label>
                                <asp:TextBox ID="txtSubtitle" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label6" runat="server" Text="发布"></asp:Label></label>
                                <asp:CheckBox ID="cbIssue" runat="server"></asp:CheckBox>
                              </div>
                              
                              <hr />
              
                              <div class="col-md-6" style="padding:0;">
                                <label><asp:Label ID="Label8" runat="server" Text="主图"></asp:Label></label>
                                <div class="showimg">
                                    <asp:Image ID="imgMain" runat="server" Width="250px" style="display:none"></asp:Image>
                                    <div class="showimg-del">
                                        <asp:LinkButton ID="lnbRemoveImage" runat="server" onclick="lnbRemoveImage_Click" OnClientClick="{return confirm('确定删除图片吗？');}" Visible="false"><span class="label label-danger"><i class="fa fa-remove"></i> 移除</span></asp:LinkButton>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="btn btn-default btn-file">
                                        <i class="fa fa-upload"></i> 上传主图
                                        <asp:FileUpload ID="fuImage" runat="server" onchange="ChkUploadImage(this,ctl00_cphMain_imgMain);"></asp:FileUpload>
                                    </div>
                                </div>
                              </div>

                            </div>
                        </div>
                        
                        <div class="tab-pane" id="seo">

                            <div class="box-body">

                                <div class="form-group">
                                <label><asp:Label ID="Label2" runat="server" Text="SEO标题"></asp:Label></label>
                                <asp:TextBox ID="txtSEO_Title" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                              
                                <div class="form-group">
                                <label><asp:Label ID="Label1" runat="server" Text="SEO关键字"></asp:Label></label>
                                <asp:TextBox ID="txtSEO_Keyword" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                <label><asp:Label ID="Label3" runat="server" Text="SEO描述"></asp:Label></label>
                                <asp:TextBox ID="txtSEO_Description" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                </div>

                            </div>
            
                        </div>
                  
                    </div>

                    <div class="box-footer">
                      <div class="pull-right">
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


