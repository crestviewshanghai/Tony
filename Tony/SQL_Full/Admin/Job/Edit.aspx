<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Admin_Job_Edit" %>

<%@ Register Src="Nav.ascx" TagName="Nav" TagPrefix="MojoCube" %>

<%@ Register Src="../Controls/CKeditor.ascx" TagName="CKeditor" TagPrefix="MojoCube" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            招聘管理
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">招聘管理</li>
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
                                 <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control select2"></asp:DropDownList>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label10" runat="server" Text="职位名称"></asp:Label></label>
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label7" runat="server" Text="工作部门"></asp:Label></label>
                                <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label8" runat="server" Text="职位类别"></asp:Label></label>
                                <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label9" runat="server" Text="招聘人数"></asp:Label></label>
                                <asp:TextBox ID="txtNumber" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label11" runat="server" Text="工作地点"></asp:Label></label>
                                <asp:TextBox ID="txtPlace" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label12" runat="server" Text="学历要求"></asp:Label></label>
                                <asp:TextBox ID="txtEducation" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label13" runat="server" Text="性别要求"></asp:Label></label>
                                <asp:TextBox ID="txtSex" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label14" runat="server" Text="年龄要求"></asp:Label></label>
                                <asp:TextBox ID="txtAge" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label15" runat="server" Text="工作经验"></asp:Label></label>
                                <asp:TextBox ID="txtExperiences" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label16" runat="server" Text="薪资范围"></asp:Label></label>
                                <asp:TextBox ID="txtWages" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="form-group">
                                <label><asp:Label ID="Label17" runat="server" Text="截止日期"></asp:Label></label>
                                <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
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


