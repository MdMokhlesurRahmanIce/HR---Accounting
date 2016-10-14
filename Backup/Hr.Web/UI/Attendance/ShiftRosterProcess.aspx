<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="ShiftRosterProcess.aspx.cs" Inherits="Hr.Web.UI.Attendance.ShiftRosterProcess" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmpList.ascx" TagName="ucEmpList" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/ShiftRosterProcess.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        var $tabs;
        var selectedtab;
        $(document).ready(function () {
            $("input[id$='txtFromDate'], .datepicker").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), dateFormat: 'mm/dd/yy' });
            $("#cphBody_cphInfbody_btnView").click(function (e) {
                var spName = "spGetRosterEmp";
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllEmpForCalendar&SpName=' + spName,
                    	                async: false
                    	            }
                                ).responseText
                $("#grdCalendar").trigger("reloadGrid");
                return false;
            });
            $("#cphBody_cphInfbody_btnSave").click(function (e) {

                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                var ActionFlag = "Save";
                jQuery.ajax
                            (
                                {
                                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShiftRosterProcessSave&FromDate=' + fromDate + '&ToDate=' + toDate + '&Action=' + ActionFlag,
                                    async: false,
                                    success: function () { ShowMessageBox('Successful', 'Shift Roster Info Saved Successfully.') },
                                    error: function (xhr, status, error) {
                                        ShowMessageBox('Error', xhr.responseText);
                                    }
                                }
                            );
                $("#grdShiftRosterProcess").trigger("reloadGrid");
                return false;
            });
            $("#cphBody_cphInfbody_btnDelete").click(function (e) {

                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                
                jQuery.ajax
                            (
                                {
                                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShiftRosterProcessSave&FromDate=' + fromDate + '&ToDate=' + toDate ,
                                    async: false,
                                    success: function () { ShowMessageBox('Successful', 'Shift Roster Info Deleted Successfully.') },
                                    error: function (xhr, status, error) {
                                        ShowMessageBox('Error', xhr.responseText);
                                    }
                                }
                            );
                $("#grdShiftRosterProcess").trigger("reloadGrid");
                return false;
            });
        });
        $(function () {
            $tabs = $("#divTab").tabs();
            $tabs.tabs('select', selectedtab);
            $("#divTab").bind("tabsselect", function (e, tab) {
                if (tab.index == 1) {
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
                    jQuery.ajax
                            (
                                {
                                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShiftRoster2&FromDate=' + fromDate + '&ToDate=' + toDate,
                                    async: false
                                }
                            );
                    $("#grdShiftRosterProcess").trigger("reloadGrid");
                }
            });
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
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="txtwidth178px datepicker" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <asl:ucEmployeeSearch ID="ctrlEmpSearchOTAssignment" runat="server"></asl:ucEmployeeSearch>
                <div style=" float: right; text-align: center">
                    <asp:Button ID="btnView" runat="server" CssClass="button" Text="View" />
                </div>
            </div>
            <div id="divTab" style="width: 71%; float: left; padding-bottom: 10px;" onclick="return divTab_onclick()">
                <ul>
                    <li><a href="#tabStep1">Step-1</a></li>
                    <li><a href="#tabStep2">Step-2</a></li>
                </ul>
                <div id="tabStep1" style="width: 98%;">
                    <asl:ucEmpList ID="ctrlEmpList" runat="server"></asl:ucEmpList>
                </div>
                <div id="tabStep2" style="width: 98%;">
                    <div>
                        <table id="grdShiftRosterProcess">
                        </table>
                    </div>
                    <div id="grdShiftRosterProcess_pager">
                    </div>
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
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save" />
            </div>
        </div>
    </div>
</asp:Content>
