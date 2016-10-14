<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EducationQualification.ascx.cs"
    Inherits="Hr.Web.Controls.EducationQualification" %>
<script src="<%= ResolveUrl("~/gridscripts/Hr_EducationQualification.js") %> " type="text/javascript"></script>
<div class="form-wrapper">
    <div class="form-header">
        <asp:Label ID="lblFrmHeader" runat="server" Text="Educational Qualification"></asp:Label>
    </div>
    <div style="clear: both">
    </div>
    <div class="form-details">
        <div class="form-body" style="display: none;">
            <span>
                <asp:Label ID="lblEducationName" Style="padding: 0 42px 0 0;" CssClass="lblStyle"
                    runat="server" Text="Education Name"></asp:Label></span> <span>
                        <asp:TextBox ID="txtEducationName" runat="server" Width="180" Style="margin: 0 0 5px 0;"></asp:TextBox></span><br />
            <span>
                <asp:Label ID="lblEduShortName" Style="padding: 0 15px 0 0;" CssClass="lblStyle"
                    runat="server" Text="Education Short Name"></asp:Label></span> <span>
                        <asp:TextBox ID="txtEduShortName" runat="server" Width="180" Style="margin: 0 0 5px 0;"></asp:TextBox></span><br />
            <span>
                <asp:Label ID="lblEduLevel" Style="padding: 0 45px 0 0;" CssClass="lblStyle" runat="server"
                    Text="Education Level"></asp:Label></span> <span>
                        <asp:TextBox ID="txtEduLevel" runat="server" Width="180" Style="margin: 0 0 5px 0;"></asp:TextBox></span><br />
        </div>
        <div class="grid">
            <div>
                <table id="grdEducationQualification">
                </table>
            </div>
            <div id="grdEducationQualification_pager">
            </div>
        </div>
    </div>
    <div class="form-bottom">
        <div class="btnRight">
            <asp:Button ID="btnRefresh" runat="server" CssClass="button" Text="Refresh" OnClick="btnRefresh_Click" />
        </div>
        <div class="btnRight">
            <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
        <div class="btnRight">
            <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?')"
                OnClick="btnDelete_Click" />
        </div>
        <div class="btnRight">
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save"
                OnClick="btnSave_Click" />
        </div>
        <div class="clear">
        </div>
    </div>
</div>
