<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="ApprovalOfManualEntry.aspx.cs" Inherits="Hr.Web.UI.Attendance.ApprovalOfManualEntry" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/ApprovalOfManualEntry.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[id$='txtFromDate']").datepicker({
                showButtonPanel: true
                , changeMonth: true
                , changeYear: true
                , onSelect: function () { }
                , defaultDate: new Date()
                , dateFormat: 'mm/dd/yy'
                , onClose: function (dateText, inst) {
                    $("#cphBody_cphInfbody_txtToDate").val(dateText);
                }
            });
            $("input[id$='txtToDate']").datepicker({
                showButtonPanel: true
                , changeMonth: true
                , changeYear: true
                , onSelect: function () { }
                , defaultDate: new Date()
                , dateFormat: 'mm/dd/yy'
                , onClose: function (dateText, inst) {
                    var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                    if (new Date(dateText) < new Date(fromDate)) {
                        $("#cphBody_cphInfbody_txtToDate").val(fromDate);
                        ShowMessageBox("HR", "To date must be greater than or equal to from date!");
                    }
                }
            });

            $("#cphBody_cphInfbody_btnView").click(function (e) {
                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
               
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ApprovalOfManualEntry&FromDate=' + fromDate + '&ToDate=' + toDate,
                    	                async: false
                    	            }
                                ).responseText
                $("#grdApprovalOfManualEntry").trigger("reloadGrid");
                return false;
            });
            $("#cphBody_cphInfbody_chkApprovalOfManualEntry").click(function (e) {
                var status = $(this).is(':checked');
                var sessionVarName = "ApprovalOfManualEntry_UserList";
                var sessionVarNameSubGrid = "ApprovalOfManualEntry_AttManualList";
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllSelectOrAllClearUserWiseEmp&Status=' + status + '&SessionVarName=' + sessionVarName + '&SessionVarNameSubGrid=' + sessionVarNameSubGrid,
                        async: false
                    }
                ).responseText
                $("#grdApprovalOfManualEntry").trigger("reloadGrid");
            });
            $("#cphBody_cphInfbody_btnApprove").click(function (e) {
                var currentUser = $("#cphBody_cphInfbody_hfCurrentUser").val();
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ApproveAttManual&CurrentUser=' + currentUser,
                    	                async: false,
                    	                success: function () { ShowMessageBox('Successful', 'Process saved successfully.') },
                    	                error: function (xhr, status, error) {
                    	                    ShowMessageBox('Error', xhr.responseText);
                    	                }
                    	            }
                                ).responseText
                return false;
            });
            $(".ucEmp").hide();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 28%; float: left">
                <div class="lblAndTxtStyle" style="margin-left: -4px">
                    <div class="divlblwidth100px bglbl">
                        <a>From Date</a>
                    </div>
                    <div class="div80Px" style="width: 59%">
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle" style="margin-left: -4px">
                    <div class="divlblwidth100px bglbl">
                        <a>To Date</a>
                    </div>
                    <div class="div80Px" style="width: 59%">
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <asl:ucEmployeeSearch ID="ctrlEmpSearchApprovalOfManualEntry" runat="server"></asl:ucEmployeeSearch>
                <div class="lblAndTxtStyle" style="width: 100%; margin-left: -4px">
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Employee Name</a>
                        </div>
                        <div class="div80Px" style="width: 54%">
                            <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                        </div>
                        <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle btn-enable ucBtnFind"
                            OnClick="btnFind_Click" ImageUrl="~/images/Search 20X20.png" />
                    </div>
                </div>
                <div style=" float:right; text-align : center">
                    <asp:Button ID="btnView" runat="server" CssClass="button" Text="View" />
                </div>
            </div>
            <div style="width: 70%; float: left">
                <div>
                    <table id="grdApprovalOfManualEntry">
                    </table>
                </div>
                <div id="grdApprovalOfManualEntry_pager">
                </div>
                <div style="margin-left: 0px; text-align: left; vertical-align: middle;">
                    <span class="lblStyle">Select All</span>
                    <asp:CheckBox ID="chkApprovalOfManualEntry" CssClass="selectAll" Text="" runat="server" />
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
                <asp:Button ID="btnApprove" runat="server" CssClass="button" Text="Approve" />
            </div>
        </div>
        <asp:HiddenField ID="hfCurrentUser" runat="server" />
    </div>
</asp:Content>
