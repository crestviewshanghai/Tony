<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="Config.aspx.cs" Inherits="Admin_Site_Config" %>

<%@ Register Src="../Controls/CKeditor.ascx" TagName="CKeditor" TagPrefix="MojoCube" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            网站设置
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">网站设置</li>
          </ol>
        </section>

        <section class="content">
        
          <div id="AlertDiv" runat="server"></div>

          <div class="row">
            <div class="col-xs-12">
              <div class="nav-tabs-custom">
                <ul class="nav nav-tabs">
                  <li class="active"><a href="#info" data-toggle="tab">网站信息</a></li>
                  <li><a href="#settings" data-toggle="tab">网站配置</a></li>
                  <li><a href="#image" data-toggle="tab">水印设置</a></li>
                  <li><a href="#seo" data-toggle="tab">SEO信息</a></li>
                  <li><a href="#copyright" data-toggle="tab">版权信息</a></li>
                  <li><a href="#contact" data-toggle="tab">联系我们</a></li>
                  <li><a href="#code" data-toggle="tab">代码管理</a></li>
                  <li><a href="#notify" data-toggle="tab">网站公告</a></li>
                  <li><a href="#terms" data-toggle="tab">注册条款</a></li>
                </ul>
                <div class="tab-content">
                  
                  <div class="active tab-pane" id="info">
                  
                  <div class="box-body">

                      <div class="row">
                            
                        <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label3" runat="server" Text="网站名称"></asp:Label></label>
                            <asp:TextBox ID="txtSiteName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                  
                        <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label4" runat="server" Text="网站标题"></asp:Label></label>
                            <asp:TextBox ID="txtSiteTitle" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                  
                        <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label6" runat="server" Text="网站域名"></asp:Label></label>
                            <asp:TextBox ID="txtSiteUrl" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                  
                        <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label7" runat="server" Text="联系电话"></asp:Label></label>
                            <asp:TextBox ID="txtSiteContact" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                  
                      </div>
                        
                      <div class="row">
              
                          <hr />
              
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label5" runat="server" Text="网站Logo"></asp:Label></label>
                            <div class="showimg"><asp:Image ID="imgLogo" runat="server"></asp:Image></div>
                            <div class="form-group">
                                <div class="btn btn-default btn-file">
                                    <i class="fa fa-upload"></i> 上传Logo
                                    <asp:FileUpload ID="fuLogo" runat="server" onchange="ChkUploadImage(this,ctl00_cphMain_imgLogo);"></asp:FileUpload>
                                </div>
                            </div>
                          </div>
                  
                      </div>

                    </div>
                    
                  </div>

                  <div class="tab-pane" id="settings">

                    <div class="box-body">
                      <div class="row">
                      
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label15" runat="server" Text="扩展名"></asp:Label></label>
                            <asp:DropDownList ID="ddlExtension" runat="server" CssClass="form-control select2">
                                <asp:ListItem Value="aspx">.aspx</asp:ListItem>
                                <asp:ListItem Value="asp">.asp</asp:ListItem>
                                <asp:ListItem Value="action">.action</asp:ListItem>
                                <asp:ListItem Value="cgi">.cgi</asp:ListItem>
                                <asp:ListItem Value="htm">.htm</asp:ListItem>
                                <asp:ListItem Value="html">.html</asp:ListItem>
                                <asp:ListItem Value="jsp">.jsp</asp:ListItem>
                                <asp:ListItem Value="php">.php</asp:ListItem>
                                <asp:ListItem Value="shtml">.shtml</asp:ListItem>
                            </asp:DropDownList>
                          </div>
                  
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label1" runat="server" Text="搜索类型"></asp:Label></label>
                            <asp:DropDownList ID="ddlSearchType" runat="server" CssClass="form-control select2">
                                <asp:ListItem Value="0">搜索产品</asp:ListItem>
                                <asp:ListItem Value="1">搜索文章</asp:ListItem>
                            </asp:DropDownList>
                          </div>
                  
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label2" runat="server" Text="网站状态"></asp:Label></label>
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control select2">
                                <asp:ListItem Value="1">正常访问</asp:ListItem>
                                <asp:ListItem Value="0">关闭网站</asp:ListItem>
                            </asp:DropDownList>
                          </div>
                  
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label13" runat="server" Text="流量统计"></asp:Label></label>
                            <asp:DropDownList ID="ddlCounter" runat="server" CssClass="form-control select2">
                                <asp:ListItem Value="1">开启统计</asp:ListItem>
                                <asp:ListItem Value="0">关闭统计</asp:ListItem>
                            </asp:DropDownList>
                          </div>
                  
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label14" runat="server" Text="锁定IP"></asp:Label></label>
                            <asp:DropDownList ID="ddlBoundIP" runat="server" CssClass="form-control select2">
                                <asp:ListItem Value="0">关闭锁定</asp:ListItem>
                                <asp:ListItem Value="1">开启锁定</asp:ListItem>
                            </asp:DropDownList>
                          </div>
                  
                          <div class="col-md-6 form-group">
                              <label><asp:Label ID="Label16" runat="server" Text="IP地址"></asp:Label></label>
                              <small class="tips">多个IP用“|”隔开，被锁定的IP将不能访问网站</small>
                              <asp:TextBox ID="txtBoundIP" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                  
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label30" runat="server" Text="网站客服"></asp:Label></label>
                            <asp:DropDownList ID="ddlService" runat="server" CssClass="form-control select2">
                                <asp:ListItem Value="1">开启客服</asp:ListItem>
                                <asp:ListItem Value="0">关闭客服</asp:ListItem>
                            </asp:DropDownList>
                          </div>
                  
                          <div class="col-md-6 form-group">
                              <label><asp:Label ID="Label31" runat="server" Text="文章标题限制"></asp:Label></label>
                              <asp:TextBox ID="txtArticleTitleLength" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                  
                          <div class="col-md-6 form-group">
                              <asp:Button ID="btnSiteMap" runat="server" Text="生成网站地图" CssClass="btn btn-primary" onclick="btnSiteMap_Click"></asp:Button>
                          </div>
                  
                          <div class="col-md-6 form-group">
                              <asp:Button ID="btnReset" runat="server" Text="恢复出厂设置" CssClass="btn btn-danger" onclick="btnReset_Click" OnClientClick="{return confirm('恢复出厂设置，网站数据将被清空（包括导航、文章、产品、相册、会员、订单等等），确定恢复吗？');}"></asp:Button>
                          </div>
                  
                      </div>

                    </div>
            
                  </div>
                  
                  <div class="tab-pane" id="image">

                    <div class="box-body">
                      <div class="row">
                      
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label8" runat="server" Text="显示水印"></asp:Label></label>
                            <asp:DropDownList ID="ddlShowWM" runat="server" CssClass="form-control select2">
                                <asp:ListItem Value="0">关闭水印</asp:ListItem>
                                <asp:ListItem Value="1">开启水印</asp:ListItem>
                            </asp:DropDownList>
                          </div>
                  
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label9" runat="server" Text="水印模式"></asp:Label></label>
                            <asp:DropDownList ID="ddlModeWM" runat="server" CssClass="form-control select2">
                                <asp:ListItem Value="0">文字模式</asp:ListItem>
                                <asp:ListItem Value="1">图片模式</asp:ListItem>
                            </asp:DropDownList>
                          </div>
                  
                          <div class="col-md-6 form-group">
                              <label><asp:Label ID="Label17" runat="server" Text="水印文字"></asp:Label></label>
                              <asp:TextBox ID="txtShowWM" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                  
                          <div class="col-md-6 form-group">
                              <label><asp:Label ID="Label18" runat="server" Text="限制宽高"></asp:Label></label>
                              <small class="tips">大于设置的宽或高才会显示水印，形式为“宽|高”</small>
                              <asp:TextBox ID="txtShowWH" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                  
                          <div class="col-md-6 form-group">
                              <label><asp:Label ID="Label19" runat="server" Text="字体大小"></asp:Label></label>
                              <small class="tips">形式为“字体|大小”</small>
                              <asp:TextBox ID="txtShowFS" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                  
                          <div class="col-md-6 form-group">
                              <label><asp:Label ID="Label20" runat="server" Text="边距"></asp:Label></label>
                              <small class="tips">形式为“底|右”</small>
                              <asp:TextBox ID="txtPadding" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                  
                          <div class="col-md-6 form-group">
                              <label><asp:Label ID="Label21" runat="server" Text="RGB"></asp:Label></label>
                              <small class="tips">形式为“R|G|B”</small>
                              <asp:TextBox ID="txtRGB" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                  
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label22" runat="server" Text="位置"></asp:Label></label>
                            <asp:DropDownList ID="ddlSize" runat="server" CssClass="form-control select2">
                                <asp:ListItem Value="0">居中</asp:ListItem>
                                <asp:ListItem Value="1">左上</asp:ListItem>
                                <asp:ListItem Value="2">右上</asp:ListItem>
                                <asp:ListItem Value="3">左下</asp:ListItem>
                                <asp:ListItem Value="4">右下</asp:ListItem>
                            </asp:DropDownList>
                          </div>
                  
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label23" runat="server" Text="旋转"></asp:Label></label>
                            <asp:DropDownList ID="ddlRotate" runat="server" CssClass="form-control select2">
                                <asp:ListItem Value="0">正常</asp:ListItem>
                                <asp:ListItem Value="-30">30&#176;</asp:ListItem>
                                <asp:ListItem Value="-45">45&#176;</asp:ListItem>
                                <asp:ListItem Value="-60">60&#176;</asp:ListItem>
                                <asp:ListItem Value="-90">90&#176;</asp:ListItem>
                                <asp:ListItem Value="-180">180&#176;</asp:ListItem>
                            </asp:DropDownList>
                          </div>
                  
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label24" runat="server" Text="透明度"></asp:Label></label>
                            <asp:DropDownList ID="ddlAlpha" runat="server" CssClass="form-control select2">
                                <asp:ListItem Value="250">100%</asp:ListItem>
                                <asp:ListItem Value="200">80%</asp:ListItem>
                                <asp:ListItem Value="150">60%</asp:ListItem>
                                <asp:ListItem Value="100">40%</asp:ListItem>
                                <asp:ListItem Value="50">20%</asp:ListItem>
                                <asp:ListItem Value="0">0</asp:ListItem>
                            </asp:DropDownList>
                          </div>
                  
                      </div>
                      
                      <div class="row">
              
                          <hr />
              
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label25" runat="server" Text="水印图片"></asp:Label></label>
                            <div class="showimg"><asp:Image ID="imgWM" runat="server"></asp:Image></div>
                            <div class="form-group">
                                <div class="btn btn-default btn-file">
                                    <i class="fa fa-upload"></i> 上传图片
                                    <asp:FileUpload ID="fuWM" runat="server"></asp:FileUpload>
                                </div>
                            </div>
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
                  
                  <div class="tab-pane" id="copyright">

                    <div class="box-body">
                      <div class="row">

                        <MojoCube:CKeditor id="txtContent" runat="server" />

                      </div>

                    </div>
            
                  </div>
                  
                  <div class="tab-pane" id="contact">

                    <div class="box-body">
                      <div class="row">

                        <MojoCube:CKeditor id="txtDescription" runat="server" />

                      </div>

                    </div>
            
                  </div>
                  
                  <div class="tab-pane" id="code">
                  
                  <div class="box-body">

                      <div class="row">
                            
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label26" runat="server" Text="统计代码"></asp:Label></label>
                            <asp:TextBox ID="txtStatisticsCode" runat="server" CssClass="form-control" TextMode="MultiLine" Height="200px"></asp:TextBox>
                          </div>
                  
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label27" runat="server" Text="分享代码"></asp:Label></label>
                            <asp:TextBox ID="txtShareCode" runat="server" CssClass="form-control" TextMode="MultiLine" Height="200px"></asp:TextBox>
                          </div>
                  
                      </div>
                        
                    </div>
                    
                  </div>
                  
                  <div class="tab-pane" id="notify">
                  
                  <div class="box-body">

                      <div class="row">
                            
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label28" runat="server" Text="网站公告"></asp:Label></label>
                            <asp:TextBox ID="txtNotify" runat="server" CssClass="form-control" TextMode="MultiLine" Height="200px"></asp:TextBox>
                          </div>
                  
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label29" runat="server" Text="关闭信息"></asp:Label></label>
                            <asp:TextBox ID="txtClosedInfo" runat="server" CssClass="form-control" TextMode="MultiLine" Height="200px"></asp:TextBox>
                          </div>
                  
                      </div>
                        
                    </div>
                    
                  </div>
                  
                  <div class="tab-pane" id="terms">
                  
                  <div class="box-body">

                      <div class="row">
                            
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label32" runat="server" Text="注册条款"></asp:Label></label>
                            <asp:TextBox ID="txtTerms" runat="server" CssClass="form-control" TextMode="MultiLine" Height="200px"></asp:TextBox>
                          </div>
                  
                      </div>
                        
                    </div>
                    
                  </div>

                  <div class="box-footer">
                      <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                  </div>

                </div>
              </div>
            </div>
          </div>

        </section>

      </div>
      
</asp:Content>


