<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CKEditor.ascx.cs" Inherits="Admin_Controls_CKEditor" %>

<asp:TextBox ID="CKEditor" runat="server" TextMode="MultiLine"></asp:TextBox>

<script src="../Controls/CKEditor/ckeditor.js"></script>

<script type="text/javascript">
    CKEDITOR.replace('ctl00_cphMain_txtContent_CKEditor', {
        width:'99.3%',
        height: '300px',
        skin: 'bootstrapck'
	});
</script>

<script type="text/javascript">
    CKEDITOR.replace('ctl00_cphMain_txtDescription_CKEditor', {
        width: '99.3%',
        height: '300px',
        skin: 'bootstrapck'
    });
</script>
