<%@ Control Language="C#"  AutoEventWireup="true" CodeBehind="EmpHistory.ascx.cs"
    Inherits="Hr.Web.Controls.EmpHistory" %>
<script src="<%= ResolveUrl("~/GridScripts/HRM_EmpEmployment.js") %>" type="text/javascript"></script>
<asp:HiddenField ID="hfEmpHistKey" runat="server" />

<div class="clear">
</div>
<div>
    <table id="grdEmpHist">
    </table>
    <div id="grdEmpHist_pager">
    </div>
</div>
