<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="OTAssignmentApproval.aspx.cs" Inherits="Hr.Web.UI.Attendance.OTAssignmentApproval" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/OTAssignmentApproval.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[id$='txtFromDate'], .datepicker").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), dateFormat: 'dd/mm/yy' });

            $("#cphBody_cphInfbody_btnView").click(function (e) {
                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                if (fromDate == "") {
                    ShowMessageBox("HR", "Please select from date!");
                    return false;
                }
                if (toDate == "") {
                    ShowMessageBox("HR", "Please select to date!");
                    return false;
                }
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=OTAssignList&FromDate=' + fromDate + '&ToDate=' + toDate,
                    	                async: false
                    	            }
                                ).responseText
                $("#grdOTAssignmentApproval").trigger("reloadGrid");
                return false;
            });
            $("#cphBody_cphInfbody_btnApprove").click(function (e) {
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ApproveORUnApprovedOTAssignment',
                    	                async: false,
                    	                success: function () { ShowMessageBox('Successful', 'Process saved successfully.') },
                    	                error: function (xhr, status, error) {
                    	                    ShowMessageBox('Error', xhr.responseText);
                    	                }
                    	            }
                                ).responseText
                return false;
            });
            $("#<%= chkOTAssignment.ClientID %>").click(function (e) {
                var status = $(this).is(':checked');
                var sessionVarName = "OTAssignmentApproval_OTAssignmentList";
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllSelectOrAllClearEmp&Status=' + status + '&SessionVarName=' + sessionVarName,
                        async: false
                    }
                ).responseText
                $("#grdOTAssignmentApproval").trigger("reloadGrid");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="OT Assignment Approval"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 28%; float: left">
                <div class="lblAndTxtStyle" style="margin-left: -4px">
                    <div class="divlblwidth100px bglbl">
                        <a>From Date</a>
                    </div>
                    <div class="div80Px"  style="width:59%">
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtwidth178px"
                            MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle" style="margin-left: -4px">
                    <div class="divlblwidth100px bglbl">
                        <a>To Date</a>
                    </div>
                    <div class="div80Px"  style="width:59%">
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="txtwidth178px datepicker"
                            MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <asl:ucEmployeeSearch ID="ctrlEmpSearchOTAssignment" runat="server"></asl:ucEmployeeSearch>
                <div style=" float:right; text-align:center">
                    <asp:Button ID="btnView" runat="server" CssClass="button" Text="View"/>
                </div>
            </div>
            <div style="width: 71%; float: left">
                <div>
                    <table id="grdOTAssignmentApproval">
                    </table>
                </div>
                <div id="grdOTAssignmentApproval_pager">
                </div>
                <div style="margin-left: 0px; text-align: left; vertical-align: middle;">
                    <span class="lblStyle">Select All</span>
                    <asp:CheckBox ID="chkOTAssignment" CssClass="selectAll" Text="" runat="server" />
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnApprove" runat="server" CssClass="button" Text="Approve/UnApproved"
                    ValidationGroup="Save" />
            </div>
        </div>
    </div>
</asp:Content>
