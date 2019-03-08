<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Admin_Product_Edit" %>

<%@ Register Src="Nav.ascx" TagName="Nav" TagPrefix="MojoCube" %>

<%@ Register Src="../Controls/CKeditor.ascx" TagName="CKeditor" TagPrefix="MojoCube" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            产品管理
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">产品管理</li>
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
                      <li><a href="#image" data-toggle="tab">图片集</a></li>
                    </ul>

                    <div class="tab-content">

                        <div class="active tab-pane" id="info">
                            <div class="box-body">
                              <div class="form-group">
                                 <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control select2"></asp:DropDownList>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label10" runat="server" Text="产品名称"></asp:Label></label>
                                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <MojoCube:CKeditor id="txtDescription" runat="server" />
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label4" runat="server" Text="页面名称"></asp:Label></label>
                                <asp:TextBox ID="txtPageName" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label7" runat="server" Text="产品编号"></asp:Label></label>
                                <asp:TextBox ID="txtNumber" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label14" runat="server" Text="产品价格"></asp:Label></label>
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label9" runat="server" Text="产品属性"></asp:Label></label>
                                <small class="tips">多个属性用“|”隔开，如：价格：100|颜色：红色|尺码：30码...</small>
                                <asp:TextBox ID="txtAttribute" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label5" runat="server" Text="副标题"></asp:Label></label>
                                <asp:TextBox ID="txtSubtitle" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label6" runat="server" Text="发布"></asp:Label></label>
                                <asp:CheckBox ID="cbIssue" runat="server"></asp:CheckBox>
                                &nbsp;
                                <label><asp:Label ID="Label15" runat="server" Text="评论"></asp:Label></label>
                                <asp:CheckBox ID="cbComment" runat="server"></asp:CheckBox>
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
                            
                            <div class="box-footer">
                              <div class="pull-right">
                                <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                                <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="btn btn-default" onclick="btnCancel_Click"></asp:Button>
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
            
                            <div class="box-footer">
                              <div class="pull-right">
                                <asp:Button ID="Button1" runat="server" Text="保存" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                                <asp:Button ID="Button2" runat="server" Text="取消" CssClass="btn btn-default" onclick="btnCancel_Click"></asp:Button>
                              </div>
                            </div>

                        </div>
                  
                        <div class="tab-pane" id="image">

                            <div class="box-body">
                            
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" BorderWidth="0px" CssClass="table table-hover" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("pk_Image") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="id" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:Label ID="lblThumbnail" runat="server" Text='<%# Bind("FilePath") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="标题">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtTitleGV" runat="server" Text='<%# Bind("Title") %>' CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="排序">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSortID" runat="server" Text='<%# Bind("SortID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="显示">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbVisible" runat="server" Checked='<%# Bind("Visible") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="gvUp" runat="server" ToolTip="上移" CommandName="_up"><span class="label label-back"><i class="fa fa-arrow-up"></i> 上移</span></asp:LinkButton>
                                                <asp:LinkButton ID="gvDown" runat="server" ToolTip="下移" CommandName="_down"><span class="label label-back"><i class="fa fa-arrow-down"></i> 下移</span></asp:LinkButton>
                                                <asp:LinkButton ID="gvSave" runat="server" ToolTip="保存" CommandName="_save"><span class="label label-primary"><i class="fa fa-save"></i> 保存</span></asp:LinkButton>
                                                <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete"><span class="label label-danger"><i class="fa fa-remove"></i> 删除</span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                    
                            </div>

                            <div class="box-body">

                              <div class="form-group">
                                <label><asp:Label ID="Label11" runat="server" Text="标题"></asp:Label></label>
                                <asp:TextBox ID="txtImageTitle" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                              <div class="form-group">
                                <label><asp:Label ID="Label13" runat="server" Text="排序"></asp:Label></label>
                                <asp:TextBox ID="txtImageSort" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                              <div class="col-md-6" style="padding:0;">
                                <label><asp:Label ID="Label12" runat="server" Text="上传"></asp:Label></label>
                                <div class="form-group">
                                    <div class="btn btn-default btn-file">
                                        <i class="fa fa-upload"></i> 上传图片
                                        <asp:FileUpload ID="fuImageUpload" runat="server"></asp:FileUpload>
                                    </div>
                                </div>
                              </div>
                              
                            </div>
            
                            <div class="box-footer">
                              <div class="pull-right">
                                <asp:Button ID="btnUpload" runat="server" Text="上传" CssClass="btn btn-primary" onclick="btnUpload_Click" Enabled="false"></asp:Button>
                                <asp:Button ID="Button4" runat="server" Text="取消" CssClass="btn btn-default" onclick="btnCancel_Click"></asp:Button>
                              </div>
                            </div>

                        </div>
                  
                    </div>

                  </div>
                </div>

            </div>
        </section>

      </div>

</asp:Content>


