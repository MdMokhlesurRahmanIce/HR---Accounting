<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="LeaveTransactionApproval.aspx.cs" Inherits="Hr.Web.UI.LeaveManagement.LeaveTransactionApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/DayLeaveApproval.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/HourlyLeaveApproval.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= chkForwarded.ClientID %>").click(function (e) {
                var status = $(this).is(':checked');
                var sessionVarName = "LeaveTransactionApproval_DayLeaveApproval";
                var checkbox = "chkForwarded";
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllSelectOrAllClearLeaveApproval&Status=' + status + '&SessionVarName=' + sessionVarName + '&Checkbox=' + checkbox,
                        async: false
                    }
                ).responseText
                $("#grdDayLeaveApproval").trigger("reloadGrid");
            });
            $("#<%= chkRecomended.ClientID %>").click(function (e) {
                var checkbox = "chkRecomended";
                var status = $(this).is(':checked');
                var sessionVarName = "LeaveTransactionApproval_DayLeaveApproval";
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllSelectOrAllClearLeaveApproval&Status=' + status + '&SessionVarName=' + sessionVarName + '&Checkbox=' + checkbox,
                        async: false
                    }
                ).responseText
                $("#grdDayLeaveApproval").trigger("reloadGrid");
            });
            $("#<%= chkApproved.ClientID %>").click(function (e) {
                var checkbox = "chkApproved";
                var status = $(this).is(':checked');
                var sessionVarName = "LeaveTransactionApproval_DayLeaveApproval";
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllSelectOrAllClearLeaveApproval&Status=' + status + '&SessionVarName=' + sessionVarName + '&Checkbox=' + checkbox,
                        async: false
                    }
                ).responseText
                $("#grdDayLeaveApproval").trigger("reloadGrid");
            });
            $("#<%= chkRejected.ClientID %>").click(function (e) {
                var checkbox = "chkRejected";
                var status = $(this).is(':checked');
                var sessionVarName = "LeaveTransactionApproval_DayLeaveApproval";
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllSelectOrAllClearLeaveApproval&Status=' + status + '&SessionVarName=' + sessionVarName + '&Checkbox=' + checkbox,
                        async: false
                    }
                ).responseText
                $("#grdDayLeaveApproval").trigger("reloadGrid");
            });
            $("#<%= chkHourlyForwarded.ClientID %>").click(function (e) {
                var status = $(this).is(':checked');
                var sessionVarName = "LeaveTransactionApproval_HourlyLeaveApproval";
                var checkbox = "chkHourlyForwarded";
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllSelectOrAllClearHourlyLeaveApproval&Status=' + status + '&SessionVarName=' + sessionVarName + '&Checkbox=' + checkbox,
                        async: false
                    }
                ).responseText
                $("#grdHourlyLeaveApproval").trigger("reloadGrid");
            });
            $("#<%= chkHourlyRecomended.ClientID %>").click(function (e) {
                var status = $(this).is(':checked');
                var sessionVarName = "LeaveTransactionApproval_HourlyLeaveApproval";
                var checkbox = "chkHourlyRecomended";
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllSelectOrAllClearHourlyLeaveApproval&Status=' + status + '&SessionVarName=' + sessionVarName + '&Checkbox=' + checkbox,
                        async: false
                    }
                ).responseText
                $("#grdHourlyLeaveApproval").trigger("reloadGrid");
            });
            $("#<%= chkHourlyApproved.ClientID %>").click(function (e) {
                var status = $(this).is(':checked');
                var sessionVarName = "LeaveTransactionApproval_HourlyLeaveApproval";
                var checkbox = "chkHourlyApproved";
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllSelectOrAllClearHourlyLeaveApproval&Status=' + status + '&SessionVarName=' + sessionVarName + '&Checkbox=' + checkbox,
                        async: false
                    }
                ).responseText
                $("#grdHourlyLeaveApproval").trigger("reloadGrid");
            });
            $("#<%= chkHourlyRejected.ClientID %>").click(function (e) {
                var status = $(this).is(':checked');
                var sessionVarName = "LeaveTransactionApproval_HourlyLeaveApproval";
                var checkbox = "chkHourlyRejected";
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllSelectOrAllClearHourlyLeaveApproval&Status=' + status + '&SessionVarName=' + sessionVarName + '&Checkbox=' + checkbox,
                        async: false
                    }
                ).responseText
                $("#grdHourlyLeaveApproval").trigger("reloadGrid");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div>
                <div>
                    <table id="grdDayLeaveApproval">
                    </table>
                </div>
                <div id="grdDayLeaveApproval_pager">
                </div>
            </div>
            <div class="lblStyle" style="float: right; margin-right: 2px;">
                <div>
                    <asp:CheckBox ID="chkForwarded" Text="Forwarded" runat="server" />
                    <asp:CheckBox ID="chkRecomended" Text="Recomended" runat="server" />
                    <asp:CheckBox ID="chkApproved" Text="Approved" runat="server" />
                    <asp:CheckBox ID="chkRejected" Text="Rejected" runat="server" />
                </div>
            </div>
            <br />
            <br />
            <div>
                <div>
                    <table id="grdHourlyLeaveApproval">
                    </table>
                </div>
                <div id="grdHourlyLeaveApproval_pager">
                </div>
            </div>
            <div class="lblStyle" style="float: right; margin-right: 2px;">
                <div>
                    <asp:CheckBox ID="chkHourlyForwarded" Text="Forwarded" runat="server" />
                    <asp:CheckBox ID="chkHourlyRecomended" Text="Recomended" runat="server" />
                    <asp:CheckBox ID="chkHourlyApproved" Text="Approved" runat="server" />
                    <asp:CheckBox ID="chkHourlyRejected" Text="Rejected" runat="server" />
                </div>
            </div>
        </div>
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
