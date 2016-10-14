<%@ Control Language="C#"  AutoEventWireup="true" CodeBehind="EmpAttachmentInfo.ascx.cs"
    Inherits="Hr.Web.Controls.EmpAttachmentInfo" %>
<script src="<%= ResolveUrl("~/GridScripts/HRM_EmpFileAttach.js") %>" type="text/javascript"></script>
<asp:HiddenField ID="hfEmpFileKey" Value="0" runat="server" />

<div style="width: 50%; float: left">
    <div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <asp:Label ID="Label1" Text="File" runat="server" /></div>
            <div class="div182Px">
                <asp:FileUpload ID="fuAttachment" runat="server" />
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <asp:Label ID="Label2" Text="Attachment Name" runat="server" /></div>
            <div class="div182Px">
                <asp:TextBox ID="txtFileName" runat="server" CssClass="txtwidth178px" />
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <asp:Label ID="Label3" Text="Attach Date" runat="server" /></div>
            <div class="div182Px">
                <asp:TextBox runat="server" ID="txtDate" ReadOnly="true" CssClass="txtwidth178px" />
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <asp:Label ID="Label4" Text="Attachment Description" runat="server" /></div>
            <div class="div182Px">
                <asp:TextBox runat="server" CssClass="txtwidth178px allowEnter" ID="txtDescription" TextMode="MultiLine" />
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
    <div style="float: right; margin-right:40px;">
        <asp:Button ID="btnAdd" CssClass="button ef-add" runat="server" Text="Add" OnClick="btnAdd_Click"
            ValidationGroup="attachment" />
        <asp:Button ID="btnUpdate" CssClass="button ef-update" Visible="false" runat="server"
            ValidationGroup="attachment" Text="Update" OnClick="btnUpdate_Click" />
    </div>
    <div class="clear">
    </div>
</div>
<div style="width: 50%; float: right">
    <table id="grdEmpFile">
    </table>
    <div id="grdEmpFile_pager">
    </div>
</div>
