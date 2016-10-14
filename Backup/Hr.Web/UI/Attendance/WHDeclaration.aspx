<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="WHDeclaration.aspx.cs" Inherits="Hr.Web.UI.Attendance.WHDeclaration" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmpList.ascx" TagName="ucEmpList" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/Cal_WHEmpList.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/WHCalendar.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/Cal_EmpList.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        var $tabs;
        var selectedtab;
        $(document).ready(function () {
            $("input[id$='txtFromDate']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true
            , onSelect: function (selectedDate) {
                var fromDate = selectedDate;
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                if (toDate != "") {
                    var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowCalendar&FromDate=' + fromDate + '&ToDate=' + toDate,
                    	                async: false
                    	            }
                                ).responseText
                    $("#grdWHCalendar").trigger("reloadGrid");
                }
            }
            , defaultDate: new Date(), dateFormat: 'mm/dd/yy'
            });
            $("input[id$='txtToDate']").datepicker({
                showButtonPanel: true,
                changeMonth: true,
                changeYear: true,
                onSelect: function (selectedDate) {
                    var toDate = selectedDate;
                    var FromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                    if (FromDate != "") {
                        var retVal = jQuery.ajax
                        (
                         {
                             url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowCalendar&FromDate=' + FromDate + '&ToDate=' + toDate,
                             async: false
                         }
                        ).responseText;
                        $("#grdWHCalendar").trigger("reloadGrid");
                    }
                }
                , defaultDate: new Date(), dateFormat: 'mm/dd/yy'
            });
            $("#cphBody_cphInfbody_btnView").click(function (e) {
                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                var spName = "spGetEmpForSearch1";
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllEmpForCalendar&SpName=' + spName + '&FromDate=' + fromDate + '&ToDate='+ toDate,
                    	                async: false
                    	            }
                                ).responseText
                $("#grdCalendar").trigger("reloadGrid");
                return false;
            });
            $("#cphBody_cphInfbody_chkCalendar").click(function (e) {
                var status = $(this).is(':checked');
                var sessionVarName = "WHDeclaration_WHCalendarList";
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllSelectOrAllClearEmp&Status=' + status + '&SessionVarName=' + sessionVarName,
                        async: false
                    }
                ).responseText
                $("#grdWHCalendar").trigger("reloadGrid");
            });
            $("#cphBody_cphInfbody_btnSave").click(function (e) {
                var dayType = $("#cphBody_cphInfbody_ddlDayStatus option:selected").text();
                var remarks = $("#cphBody_cphInfbody_txtRemarks").val();
                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                var unCheckedDaysWillDeleteAutomatically = $('#cphBody_cphInfbody_chkUCDWDA').is(":checked");
                if (toDate == "") {
                    ShowMessageBox("HR", "Please select to date!");
                    return false;
                }
                if (dayType == "") {
                    ShowMessageBox("HR", "Please select day type!");
                    return false;
                }
                jQuery.ajax
                            (
                                {
                                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=Cal_SaveEmpListWithDayStatus&DayType=' + dayType + '&Remarks=' + remarks + '&FromDate=' + fromDate + '&ToDate=' + toDate + '&UnCheckedDaysWillDeleteAutomatically=' + unCheckedDaysWillDeleteAutomatically,
                                    async: false,
                                    success: function () { ShowMessageBox('Successful', 'Process saved successfully.') },
                                    error: function (xhr, status, error) {
                                        ShowMessageBox('Error', xhr.responseText);
                                    }
                                }
                            );
                $("#grdWHEmpList").trigger("reloadGrid");
                return false;
            });
            $("#cphBody_cphInfbody_rdoDeleteALL").click(function (e) {
                $('#cphBody_cphInfbody_chkUCDWDA').attr("checked", false);
                $('#cphBody_cphInfbody_chkUCDWDA').attr("disabled", true);
            });
            $("#cphBody_cphInfbody_rdoDeclaration").click(function (e) {
                $('#cphBody_cphInfbody_chkUCDWDA').attr("disabled", false);
            });
        });
        function SetWeekend(weekend, id) {
            var status = id.checked;
            var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=CheckOrUnCheckWeekend&Weekend=' + weekend + '&Status=' + status,
                    	                async: false
                    	            }
                                ).responseText
            $("#grdWHCalendar").trigger("reloadGrid");
            return false;
        }
        $(function () {
            $tabs = $("#divTab").tabs();
            $tabs.tabs('select', selectedtab);
            $("#divTab").bind("tabsselect", function (e, tab) {
                if (tab.index == 1) {
                    var dayType = $("#cphBody_cphInfbody_ddlDayStatus option:selected").text();
                    var remarks = $("#cphBody_cphInfbody_txtRemarks").val();
                    var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                    var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                    var unCheckedDaysWillDeleteAutomatically = $('#cphBody_cphInfbody_chkUCDWDA').is(":checked");
                    if (fromDate == "") {
                        ShowMessageBox("HR", "Please select from date!");
                        return false;
                    }
                    if (toDate == "") {
                        ShowMessageBox("HR", "Please select to date!");
                        return false;
                    }
                    if (dayType == "") {
                        ShowMessageBox("HR", "Please select day type!");
                        return false;
                    }
                    jQuery.ajax
                            (
                                {
                                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=Cal_ShowEmpListWithDayStatus&DayType=' + dayType + '&Remarks=' + remarks + '&FromDate=' + fromDate + '&ToDate=' + toDate + '&UnCheckedDaysWillDeleteAutomatically=' + unCheckedDaysWillDeleteAutomatically,
                                    async: false
                                }
                            );
                    $("#grdWHEmpList").trigger("reloadGrid");
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
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="txtwidth178px datePicker" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <asl:ucEmployeeSearch ID="ucEmployeeSearchWHDeclaration" runat="server"></asl:ucEmployeeSearch>
                <div style="float: right; text-align: center">
                    <asp:Button ID="btnView" runat="server" CssClass="button" Text="View" />
                </div>
            </div>
            <div id="divTab" style="width: 70%; float: left; padding-bottom: 10px;" onclick="return divTab_onclick()">
                <ul>
                    <li><a href="#tabStep1">Step-1</a></li>
                    <li><a href="#tabStep2">Step-2</a></li>
                </ul>
                <div id="tabStep1" style="width: 100%;">
                    <div>
                        <div style="width: 48%; float: left">
                            <div class="lblAndTxtStyle">
                                <div style="float: left" class="divlblwidth100px bglbl">
                                    <a>Day Status</a>
                                </div>
                                <div style="float: left; width: 150px">
                                    <asp:DropDownList ID="ddlDayStatus" runat="server" CssClass="drpwidth180px" AutoPostBack="false">
                                    </asp:DropDownList>
                                </div>
                                <div style="float: left">
                                    <asp:CheckBox ID="chkIsFake" Text="Is Fake" CssClass="fieldset-legend" runat="server" />
                                </div>
                            </div>
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth100px bglbl">
                                    <a>Remarks</a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtwidth178px" TextMode="MultiLine"
                                        MaxLength="100"></asp:TextBox>
                                </div>
                            </div>
                            <div style="float: left">
                                <a>
                                    <asp:CheckBox ID="chkSunday" runat="server" Text="Sun" onclick="SetWeekend('Sunday',this);" /></a>
                                <a>
                                    <asp:CheckBox ID="chkMonday" runat="server" Text="Mon" onclick="SetWeekend('Monday',this);" /></a>
                                <a>
                                    <asp:CheckBox ID="chkTuesday" runat="server" Text="Tue" onclick="SetWeekend('Tuesday',this);" /></a>
                                <a>
                                    <asp:CheckBox ID="chkWednesday" runat="server" Text="Wed" onclick="SetWeekend('Wednesday',this);" /></a>
                                <a>
                                    <asp:CheckBox ID="chkThursday" runat="server" Text="Thu" onclick="SetWeekend('Thursday',this);" /></a>
                                <a>
                                    <asp:CheckBox ID="chkFriday" runat="server" Text="Fri" onclick="SetWeekend('Friday',this);" /></a>
                                <a>
                                    <asp:CheckBox ID="chkSaturday" runat="server" Text="Sat" onclick="SetWeekend('Saturday',this);" /></a>
                            </div>
                            <div style="float: left">
                            </div>
                            <div class="lblAndTxtStyle">
                                <asp:CheckBox ID="chkUCDWDA" Text="Un Checked Days will Delete Automatically" CssClass="fieldset-legend"
                                    runat="server" />
                            </div>
                        </div>
                        <div style="width: 48%; float: left; margin-left: 5px">
                            <div style="width: 100%; height: auto; margin-top: 5px">
                                <div>
                                    <table id="grdWHCalendar">
                                    </table>
                                </div>
                                <div id="grdWHCalendar_pager">
                                </div>
                            </div>
                            <div style="margin-left: 0px; text-align: left; vertical-align: middle;">
                                <span class="lblStyle">Select All</span>
                                <asp:CheckBox ID="chkCalendar" Text="" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div style="clear: both">
                    </div>
                    <div style="width: 98%; float: left">
                        <asl:ucEmpList ID="ctrlEmpList" runat="server"></asl:ucEmpList>
                    </div>
                </div>
                <div id="tabStep2" style="width: 99%;">
                    <div>
                        <table id="grdWHEmpList">
                        </table>
                    </div>
                    <div id="grdWHEmpList_pager">
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
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save" />
            </div>
        </div>
    </div>
</asp:Content>
