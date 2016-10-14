<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="EmpOutOffOfficeEntry.aspx.cs" Inherits="Hr.Web.UI.Attendance.EmpOutOffOfficeEntry" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmpList.ascx" TagName="ucEmpList" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/OutOfOfficeEntry.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/src/jquery-ui-timepicker-addon.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        var $tabs;
        var selectedtab;
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
            $("input[id$='txtStartTime'], .timepicker").timepicker({
                ampm: true,
                hourGrid: 4,
                minuteGrid: 10,
                hourMin: 8,
                hourMax: 24
            });
            $("#cphBody_cphInfbody_btnView").click(function (e) {
                var spName = "spGetEmpForSearch1";
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
            $("#cphBody_cphInfbody_btnDefine").click(function (e) {
                selectedtab = 1;
                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                if (fromDate == "") {
                    ShowMessageBox('HR', "From date is required");
                    return false;
                }
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                if (toDate == "") {
                    ShowMessageBox('HR', "To date is required");
                    return false;
                }

                if ($("#cphBody_cphInfbody_chkShowExistingEntry").is(':checked')) {
                    var retVal = jQuery.ajax
                                (
                                    {
                                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowExistingOutOfOfficeEntry&FromDate=' + fromDate + '&ToDate=' + toDate,
                                        async: false
                                    }
                                ).responseText
                    $("#grdOutOfOfficeEntry").trigger("reloadGrid");
                    return false;
                }

                var startTime = $("#cphBody_cphInfbody_txtStartTime").val();
                var status = $("#cphBody_cphInfbody_chkSettime").is(':checked');
                if (status && startTime == "") {
                    ShowMessageBox('HR', "Start time is required");
                    return false;
                }
                var endTime = $("#cphBody_cphInfbody_txtEndTime").val();
                if (status && endTime == "") {
                    ShowMessageBox('HR', "End time is required");
                    return false;
                }
                var visit = $("#cphBody_cphInfbody_ddlVisitPlaceOrProject").val();
                var stayingArea = $("#cphBody_cphInfbody_txtStayingArea").val();
                var reason = $("#cphBody_cphInfbody_txtReason").val();
                var remarks = $("#cphBody_cphInfbody_txtRemarks").val();
                var currentUser = $("#cphBody_cphInfbody_hfCurrentUser").val();
                var retVal = jQuery.ajax
                                (
                                    {
                                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=OutOfOfficeEmpList&FromDate=' + fromDate + '&ToDate=' + toDate + '&StartTime=' + startTime + '&EndTime=' + endTime + '&Visit=' + visit + '&StayingArea=' + stayingArea + '&Reason=' + reason + '&Remarks=' + remarks + '&CurrentUser=' + currentUser,
                                        async: false
                                    }
                                ).responseText
                $("#grdOutOfOfficeEntry").trigger("reloadGrid");
                $tabs.tabs('select', selectedtab);
                return false;
            });

            $(function () {
                $tabs = $("#divTab").tabs();
                $tabs.tabs('select', selectedtab);
                $("#divTab").bind("tabsselect", function (e, tab) {
                    if (tab.index == 1) {
                        var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                        if (fromDate == "")
                            ShowMessageBox('HR', "From date is required");
                        var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                        if (toDate == "") {
                            ShowMessageBox('HR', "To date is required");
                            return false;
                        }
                        if ($("#cphBody_cphInfbody_chkShowExistingEntry").is(':checked')) {
                            var retVal = jQuery.ajax
                                (
                                    {
                                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowExistingOutOfOfficeEntry&FromDate=' + fromDate + '&ToDate=' + toDate,
                                        async: false
                                    }
                                ).responseText
                            $("#grdOutOfOfficeEntry").trigger("reloadGrid");
                            return true;
                        }
                        var startTime = $("#cphBody_cphInfbody_txtStartTime").val();
                        var status = $("#cphBody_cphInfbody_chkSettime").is(':checked');
                        if (status && startTime == "") {
                            ShowMessageBox('HR', "Start time is required");
                            return false;
                        }
                        var endTime = $("#cphBody_cphInfbody_txtEndTime").val();
                        if (status && endTime == "") {
                            ShowMessageBox('HR', "End time is required");
                            return false;
                        }
                        var visit = $("#cphBody_cphInfbody_ddlVisitPlaceOrProject").val();
                        var stayingArea = $("#cphBody_cphInfbody_txtStayingArea").val();
                        var reason = $("#cphBody_cphInfbody_txtReason").val();
                        var remarks = $("#cphBody_cphInfbody_txtRemarks").val();
                        var currentUser = $("#cphBody_cphInfbody_hfCurrentUser").val();
                        var retVal = jQuery.ajax
                                (
                                    {
                                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=OutOfOfficeEmpList&FromDate=' + fromDate + '&ToDate=' + toDate + '&StartTime=' + startTime + '&EndTime=' + endTime + '&Visit=' + visit + '&StayingArea=' + stayingArea + '&Reason=' + reason + '&Remarks=' + remarks + '&CurrentUser=' + currentUser,
                                        async: false
                                    }
                                ).responseText
                        $("#grdOutOfOfficeEntry").trigger("reloadGrid");
                    }
                });
            });

            $("#cphBody_cphInfbody_btnSave").click(function (e) {
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=SaveOutOfOfficeEntry',
                    	                async: false,
                    	                success: function () { ShowMessageBox('Successful', 'Process saved successfully.') },
                    	                error: function (xhr, status, error) {
                    	                    ShowMessageBox('Error', xhr.responseText);
                    	                }
                    	            }
                                ).responseText
                $("#grdOutOfOfficeEntry").trigger("reloadGrid");
                return false;
            });
            $("#<%= chkSettime.ClientID %>").click(function (e) {
                var status = $(this).is(':checked');
                if (status) {
                    $(".timeHide").show();
                }
                else {
                    $("#cphBody_cphInfbody_txtStartTime").val("");
                    $("#cphBody_cphInfbody_txtEndTime").val("");
                    $(".timeHide").hide();
                }
            });
        });
        $(function () {
            $tabs = $("#divTab").tabs();
            $tabs.tabs('select', selectedtab);
        });

    </script>
    <style type="text/css">
        #tabMarker .lblAndTxtStyle
        {
            font-family: 'Microsoft Sans Serif' ,Sans-Serif,Arial;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 28%; float: left">
                <div style="width: 85%; float: left">
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>From Date</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtwidth178px" Width="190px"
                                MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>To Date</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtToDate" runat="server" CssClass="txtwidth178px datepicker" Width="190px"
                                MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div style="float: right; text-align: center;">
                        <asp:CheckBox ID="chkSettime" CssClass="selectAll" Text="Set Time" runat="server" />
                    </div>
                    <div class="lblAndTxtStyle timeHide" style="display: none">
                        <div class="divlblwidth100px bglbl">
                            <a>Start Time</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtStartTime" runat="server" CssClass="txtwidth178px" Width="190px"
                                MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle timeHide" style="display: none">
                        <div class="divlblwidth100px bglbl">
                            <a>End Time</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtEndTime" runat="server" CssClass="txtwidth178px timepicker" Width="190px"
                                MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div style="width: 99%; float: left">
                    <asl:ucEmployeeSearch ID="ctrlEmpSearchOTAssignment" runat="server"></asl:ucEmployeeSearch>
                    <div style="text-align: center; float: right">
                        <asp:Button ID="btnView" runat="server" CssClass="button" Text="View" />
                    </div>
                </div>
            </div>
            <div id="divTab" style="width: 70%; float: left; padding-bottom: 10px;" onclick="return divTab_onclick()">
                <ul>
                    <li><a href="#tabStep1">Step-1</a></li>
                    <li><a href="#tabStep2">Step-2</a></li>
                </ul>
                <div id="tabStep1" style="width: 100%;">
                    <div>
                        <div style="width: 99%; float: left;">
                            <div style="width: 50%; float: left;">
                                <div style="width: 90%; float: left;">
                                    <div class="lblAndTxtStyle">
                                        <div class="divlblwidth100px bglbl">
                                            <a>Visit Place/Project</a>
                                        </div>
                                        <div class="div182Px">
                                            <asp:DropDownList ID="ddlVisitPlaceOrProject" runat="server" CssClass="drpwidth180px">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="lblAndTxtStyle">
                                        <div class="divlblwidth100px bglbl">
                                            <a>Staying Area</a>
                                        </div>
                                        <div class="div80Px">
                                            <asp:TextBox ID="txtStayingArea" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 50%; float: left;">
                                <div style="width: 99%; float: left;">
                                    <div class="lblAndTxtStyle">
                                        <div class="divlblwidth100px bglbl">
                                            <a>Reason</a>
                                        </div>
                                        <div class="div80Px">
                                            <asp:TextBox ID="txtReason" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="lblAndTxtStyle">
                                        <div class="divlblwidth100px bglbl">
                                            <a>Remarks</a>
                                        </div>
                                        <div class="div80Px">
                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>
                                        <asp:CheckBox ID="chkShowExistingEntry" CssClass="selectAll" Text="Existing Data Showing"
                                            runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="clear: both">
                    </div>
                    <div style="width: 98%">
                        <asl:ucEmpList ID="ctrlEmpList" runat="server"></asl:ucEmpList>
                    </div>
                </div>
                <div id="tabStep2" style="width: 98%;">
                    <div>
                        <table id="grdOutOfOfficeEntry">
                        </table>
                    </div>
                    <div id="grdOutOfOfficeEntry_pager">
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClick="btnDelete_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnDefine" runat="server" CssClass="button" Text="Define" />
            </div>
        </div>
        <asp:HiddenField ID="hfCurrentUser" runat="server" />
    </div>
</asp:Content>
