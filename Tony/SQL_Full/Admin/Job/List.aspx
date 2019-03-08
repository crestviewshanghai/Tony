<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="Admin_Job_List" %>

<%@ Register Src="Nav.ascx" TagName="Nav" TagPrefix="MojoCube" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

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
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">
                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                  </h3>
                  <div class="box-tools">
                    <div class="input-group" style="width: 150px;">
                      <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm pull-right" placeholder="查找..."></asp:TextBox>
                      <div class="input-group-btn">
                        <asp:LinkButton ID="lnbSearch" runat="server" CssClass="btn btn-sm btn-default" onclick="lnbSearch_Click"><i class="fa fa-search"></i></asp:LinkButton>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="box-body no-padding">
                  <div class="mailbox-controls">
                      <div id="CategoryDiv" runat="server" style="padding-bottom:5px;"></div>
                  </div>
                  <div class="table-responsive mailbox-messages">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" BorderWidth="0px" CssClass="table table-hover table-striped" AllowSorting="True" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
                        <Columns>
                            <asp:TemplateField HeaderText="ID" SortExpression="pk_Job">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("pk_Job") %>'></asp:Label>
                                    <asp:Label ID="lblPageName" runat="server" Text='<%# Bind("PageName") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="id" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="职位名称">
                                <ItemTemplate>
                                    <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="mailbox-subject" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="创建">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreateDate" runat="server" Text='<%# Bind("CreateDate") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="mailbox-date" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发布">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbIssue" runat="server" Checked='<%# Bind("Issue") %>' Enabled="False" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:HyperLink ID="gvEdit" runat="server" ToolTip="修改"><span class="label label-primary"><i class="fa fa-edit"></i> 修改</span></asp:HyperLink>
                                    <asp:HyperLink ID="gvView" runat="server" ToolTip="查看"><span class="label label-primary"><i class="fa fa-search"></i> 查看</span></asp:HyperLink>
                                    <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete"><span class="label label-danger"><i class="fa fa-remove"></i> 删除</span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <div id="EmptyDiv" runat="server" visible="false" style="height:60px; text-align:center; padding:10px; overflow:auto; border-top:solid 1px #F4F4F4;">暂无数据</div>
                    
                  </div>
                </div>
                <div class="box-footer no-padding" style="margin-top:-20px;">
                  <div class="mailbox-controls">
                  
                    <div id="pager" style="background:#fff; border:0px; margin-top:0px; padding:2px;">
                       <webdiyer:AspNetPager ID="ListPager" runat="server" OnPageChanged="ListPager_PageChanged"></webdiyer:AspNetPager>
                    </div>
        
                  </div>
                </div>
              </div>
            </div>

          </div>

        </section>

      </div>
      
</asp:Content>


