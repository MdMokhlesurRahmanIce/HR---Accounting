<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="AttendanceManual.aspx.cs" Inherits="Hr.Web.UI.Attendance.AttendanceManual" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmpList.ascx" TagName="ucEmpList" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/AttManualEmpList.js") %> " type="text/javascript"></script>
    <script src="../../js/jquery.timeentry.js" type="text/javascript"></script>
    <link href="../../js/jquery.timeentry.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var $tabs;
        var selectedtab;
        $(document).ready(function () {
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
                var str = GetSearchStr();
                var spName = "spGetEmpForManualSearch";
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllEmpForManualAtt&SpName=' + spName + '&FromDate=' + fromDate + '&ToDate=' + toDate + '&Str=' + str,
                    	                async: false
                    	            }
                                ).responseText
                $("#grdCalendar").trigger("reloadGrid");
                return false;
            });
            $("#cphBody_cphInfbody_btnProcessOrReprocess").click(function (e) {
                var inTimeBuffer = "";
                var outTimeBuffer = "";
                var lunchInBuffer = "";
                var lunchOutBuffer = "";
                var Type = "Save"
                var currentUser = $("#cphBody_cphInfbody_hfCurrentUser").val();
                //alert($("#cphBody_cphInfbody_txtIntimeBuffer").is(":disabled"));
                if (!$("#cphBody_cphInfbody_txtIntimeBuffer").is(":disabled"))
                    inTimeBuffer = $("#cphBody_cphInfbody_txtIntimeBuffer").val();
                if (!$("#cphBody_cphInfbody_txtShiftOutTime").is(":disabled"))
                    outTimeBuffer = $("#cphBody_cphInfbody_txtShiftOutTime").val();
                if (!$("#cphBody_cphInfbody_txtLunchInBuffertime").is(":disabled"))
                    lunchInBuffer = $("#cphBody_cphInfbody_txtLunchInBuffertime").val();
                if (!$("#cphBody_cphInfbody_txtLunchOutBuffertime").is(":disabled"))
                    lunchOutBuffer = $("#cphBody_cphInfbody_txtLunchOutBuffertime").val();
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ManualAttProcess&CurrentUser=' + currentUser + '&InTimeBuffer=' + inTimeBuffer + '&OutTimeBuffer=' + outTimeBuffer + '&LunchInBuffer=' + lunchInBuffer + '&LunchOutBuffer=' + lunchOutBuffer+'&Type=' +Type,
                    	                async: false,
                    	                success: function () { ShowMessageBox('Successful', 'Record(s) Saved Successfully.') },
                    	                error: function (xhr, status, error) {
                    	                    ShowMessageBox('Error', xhr.responseText);
                    	                }
                    	            }
                                ).responseText
                $("#grdAttManual").trigger("reloadGrid");
                return false;
            });
            $("#cphBody_cphInfbody_btnDelete").click(function (e) {
                var inTimeBuffer = "";
                var outTimeBuffer = "";
                var lunchInBuffer = "";
                var lunchOutBuffer = "";
                var Type = "Delete"
                var currentUser = $("#cphBody_cphInfbody_hfCurrentUser").val();
                //alert($("#cphBody_cphInfbody_txtIntimeBuffer").is(":disabled"));
                if (!$("#cphBody_cphInfbody_txtIntimeBuffer").is(":disabled"))
                    inTimeBuffer = $("#cphBody_cphInfbody_txtIntimeBuffer").val();
                if (!$("#cphBody_cphInfbody_txtShiftOutTime").is(":disabled"))
                    outTimeBuffer = $("#cphBody_cphInfbody_txtShiftOutTime").val();
                if (!$("#cphBody_cphInfbody_txtLunchInBuffertime").is(":disabled"))
                    lunchInBuffer = $("#cphBody_cphInfbody_txtLunchInBuffertime").val();
                if (!$("#cphBody_cphInfbody_txtLunchOutBuffertime").is(":disabled"))
                    lunchOutBuffer = $("#cphBody_cphInfbody_txtLunchOutBuffertime").val();
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ManualAttProcess&CurrentUser=' + currentUser + '&InTimeBuffer=' + inTimeBuffer + '&OutTimeBuffer=' + outTimeBuffer + '&LunchInBuffer=' + lunchInBuffer + '&LunchOutBuffer=' + lunchOutBuffer + '&Type=' + Type,
                    	                async: false,
                    	                success: function () { ShowMessageBox('Successful', 'Record(s) Deleted Successfully.') },
                    	                error: function (xhr, status, error) {
                    	                    ShowMessageBox('Error', xhr.responseText);
                    	                }
                    	            }
                                ).responseText
                $("#grdAttManual").trigger("reloadGrid");
                return false;
            });

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
        });

        $(function () {
            $tabs = $("#divTab").tabs();
            $tabs.tabs('select', selectedtab);
            $("#divTab").bind("tabsselect", function (e, tab) {
                if (tab.index == 1) {
                    var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                    var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                    var remarks = $("#cphBody_cphInfbody_txtRemarks").val();
                    var str = GetSearchStr();
                    var strBuffer = GetBufferValue();
                    var spName = "spAttManual";
                    var retVal = jQuery.ajax
                                (
                                    {
                                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ManualProcessEmpList&SpName=' + spName + '&FromDate=' + fromDate + '&ToDate=' + toDate + '&Str=' + str + '&StrBuffer=' + strBuffer + '&Remarks=' + remarks,
                                        async: false
                                    }
                                ).responseText
                    $("#grdAttManual").trigger("reloadGrid");
                }
            });
        });

        function toggleLOut(ctrl) {
            if (ctrl.checked) {
                $("#cphBody_cphInfbody_txtMakeEarlyOut").val("");
                $("#cphBody_cphInfbody_txtWithOT").val("");
                $(".makeLunchOut").hide();
            }
            else {
                $(".makeLunchOut").show();
            }
        }
        function toggleShiftIntimeClick(ctrl) {
            $('#<%= txtIntimeBuffer.ClientID %>').attr("disabled", !ctrl.checked);
        }
        function toggleOutTimeClick(ctrl) {
            $('#<%= txtShiftOutTime.ClientID %>').attr("disabled", !ctrl.checked);
        }
        function toggleWithOTClick(ctrl) {
            $('#<%= txtWithOT.ClientID %>').attr("disabled", !ctrl.checked);
        }
        function toggleLateClick(ctrl) {
            $('#<%= txtMakeLate.ClientID %>').attr("disabled", !ctrl.checked);
        }
        function toggleEarlyOutClick(ctrl) {
            $('#<%= txtMakeEarlyOut.ClientID %>').attr("disabled", !ctrl.checked);
        }
        function toggleLunchInClick(ctrl) {
            $('#<%= txtLunchInBuffertime.ClientID %>').attr("disabled", !ctrl.checked);
        }
        function toggleLunchOutClick(ctrl) {
            $('#<%= txtLunchOutBuffertime.ClientID %>').attr("disabled", !ctrl.checked);
        }
        function GetSearchStr() {
            var str = '';

            if ($("#cphBody_cphInfbody_chkAll").is(":checked")) {
                str = "";
            }
            else {
                if ($("#cphBody_cphInfbody_chkInPunchMissing").is(":checked")) {
                    if (str == "")
                        str = str + " AND (  (( InTime Is NULL or InTime='''') and OutTime is NOT NULL and OutTime <>'''')"
                   
                }
                if ($("#cphBody_cphInfbody_chkOutPunchMissing").is(":checked")) {
                    if (str == "")
                        str = str + " AND (  (( OutTime Is NULL or OutTime='''') and InTime is NOT NULL and InTime <>'''')"
                    else
                        str = str + " OR (( OutTime Is NULL or OutTime='''') and InTime is NOT NULL and InTime <>'''')"
                }
                if ($("#cphBody_cphInfbody_chkTimeModification").is(":checked")) {
                    if (str == "")
                        str = str + " AND(  (DayStatus=''P'' OR DayStatus=''L'')"
                    else
                        str = str + " OR (DayStatus=''P'' OR DayStatus=''L'')"
                }
                if ($("#cphBody_cphInfbody_chkAbsentToPresent").is(":checked")) {
                    if (str == "")
                        str = str + " AND (  DayStatus=''A''"
                    else
                        str = str + " OR DayStatus=''A''"
                }
                if ($("#cphBody_cphInfbody_chkPresentToAbsent").is(":checked")) {
                    if (str == "")
                        str = str + " AND (  (DayStatus=''P'' OR DayStatus=''L'')"
                    else
                        str = str + " OR (DayStatus=''P'' OR DayStatus=''L'')"
                }
                if (str != "") {
                    str = str + " ) ";
                }
            }
            return str;
        }
        function GetBufferValue() {
            var str = "";
            var IsInTime = $("#cphBody_cphInfbody_ChkIntime").is(":checked");
            var IsOutTime = $("#cphBody_cphInfbody_chkOutTime").is(":checked");
            var IsLunchOut = $("#cphBody_cphInfbody_chkLunchOuttime").is(":checked");
            var IsLunchIn = $("#cphBody_cphInfbody_chkLunchIntime").is(":checked");
            
            var shiftInTime = $("#cphBody_cphInfbody_txtIntimeBuffer").val();
            var shiftOutTime = $("#cphBody_cphInfbody_txtShiftOutTime").val();
            var withOT = $("#cphBody_cphInfbody_txtWithOT").val();
            var makeEarlyOut = $("#cphBody_cphInfbody_txtMakeEarlyOut").val();
            var LunchOutTime = $("#cphBody_cphInfbody_txtLunchOutBuffertime").val();
            var makeLate = $("#cphBody_cphInfbody_txtMakeLate").val();
            var lunchInTime = $("#cphBody_cphInfbody_txtLunchInBuffertime").val();
            var wHExists = $("#cphBody_cphInfbody_chkDontInsertDataIfWHExists").is(":checked");
            var leaveExists = $("#cphBody_cphInfbody_chkDontInsertDataIfLeaveexists").is(":checked");
            var makeLunchOut = $("#cphBody_cphInfbody_chkMakeLOut").is(":checked");
            var overriteexistingPunch = $("#cphBody_cphInfbody_chkOverWriteExistingPunch").is(":checked");
            str = "shiftInTime," + shiftInTime + ",shiftOutTime," + shiftOutTime + ",withOT," + withOT + ",makeEarlyOut," + makeEarlyOut + ",LunchOutTime," + LunchOutTime + ",makeLate," + makeLate + ",lunchInTime," + lunchInTime + ",wHExists," + wHExists + ",leaveExists," + leaveExists + ",makeLunchOut," + makeLunchOut + ",overriteexistingPunch," + overriteexistingPunch + ",IsInTime," + IsInTime + ",IsOutTime," + IsOutTime + ",IsLunchOutTime," + IsLunchOut + ",IsLunchIn," + IsLunchIn; 
            return str;
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode == 46) return true;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
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
            <div id="divTab" style="width: 99%; float: left;" onclick="return divTab_onclick()">
                <ul>
                    <li><a href="#tabAttManual1">Attendance Manual-1</a></li>
                    <li><a href="#tabAttManual2">Attendance Manual-2</a></li>
                </ul>
                <div id="tabAttManual1" style="float: left; width: 100%">
                    <div style="width: 28%; float: left">
                        <div style="width: 50%; float: left">
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth100px">
                                    <a>From Date</a>
                                </div>
                            </div>
                            <div class="lblAndTxtStyle">
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtwidth80per" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div style="width: 50%; float: left">
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth100px">
                                    <a>To Date</a>
                                </div>
                            </div>
                            <div class="lblAndTxtStyle">
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="txtwidth80per datePicker" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <asl:ucEmployeeSearch ID="ctrlEmpSearch" runat="server"></asl:ucEmployeeSearch>
                        <div style="text-align: center; float: right; padding-right: 5px">
                            <asp:Button ID="btnView" runat="server" CssClass="button" Text="View" />
                        </div>
                        <div style="width: 100%; float: left">
                            <div style="width: 50%; float: left">
                                <div>
                                    <a>
                                        <asp:CheckBox ID="chkAll" Text="ALL" Checked="true" runat="server" /></a>
                                </div>
                                <div>
                                    <a>
                                        <asp:CheckBox ID="chkAbsentToPresent" Text="Absent Only" runat="server" /></a>
                                </div>
                                <div>
                                    <a>
                                        <asp:CheckBox ID="chkPresentToAbsent" Text="Present Only" runat="server" /></a>
                                </div>
                            </div>
                            <div style="width: 50%; float: left">
                                <div>
                                    <a>
                                        <asp:CheckBox ID="chkTimeModification" Text="Time Modification" runat="server" /></a>
                                </div>
                                <div>
                                    <a>
                                        <asp:CheckBox ID="chkInPunchMissing" Text="In Punch Missing" runat="server" /></a>
                                </div>
                                <div>
                                    <a>
                                        <asp:CheckBox ID="chkOutPunchMissing" Text="Out Punch Missing" runat="server" /></a>
                                </div>
                            </div>
                        </div>
                        <div style="width: 100%; float: left">
                            <div style="width: 50%; float: left">
                                <br />
                                <div style="width: 60%; float: left">
                                    <div class="lblAndTxtStyle">
                                        <a>Intime Buffer</a>
                                    </div>
                                    <div class="lblAndTxtStyle">
                                        <asp:TextBox ID="txtIntimeBuffer" runat="server" CssClass="txtwidth178px" Width="100%"
                                            onkeypress="return isNumberKey(event)" placeholder="Buffer time" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                                <div style="width: 60%; float: left">
                                    <div class="lblAndTxtStyle">
                                        <a>Lunch In Buffer</a>
                                    </div>
                                    <div class="lblAndTxtStyle">
                                        <asp:TextBox ID="txtLunchInBuffertime" runat="server" CssClass="txtwidth178px" Width="100%"
                                            onkeypress="return isNumberKey(event)" placeholder="Buffer time" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 30%; float: left">
                                <br />
                                <div class="lblAndTxtStyle">
                                    <a>Outtime Buffer</a>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <asp:TextBox ID="txtShiftOutTime" runat="server" CssClass="txtwidth178px" Width="100%"
                                        onkeypress="return isNumberKey(event)" placeholder="Buffer time" MaxLength="100"></asp:TextBox>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <a>Lunch Out Buffer</a>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <asp:TextBox ID="txtLunchOutBuffertime" runat="server" CssClass="txtwidth178px" Width="100%"
                                        onkeypress="return isNumberKey(event)" placeholder="Buffer time" MaxLength="100"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="width: 70%; float: left;">
                        <div style="width: 100%; float: left">
                            <div style="width: 60%; float: left">
                                <a style="float: left">Configure your Settings for manual attendance</a>
                                <div style="width: 100%; float: left">
                                    <div style="width: 25%; float: left">
                                        <div class="lblAndTxtStyle shiftintime">
                                            <a>
                                                <asp:CheckBox ID="ChkIntime" Text="In time" runat="server" onclick="toggleShiftIntimeClick(this);"
                                                    Checked="true" /></a>
                                        </div>
                                    </div>
                                    <div style="width: 25%; float: left">
                                        <div class="lblAndTxtStyle shiftouttime">
                                            <a>
                                                <asp:CheckBox ID="chkOutTime" Text="Out time" runat="server" onclick="toggleOutTimeClick(this);"
                                                    Checked="true" /></a>
                                        </div>
                                    </div>
                                    
                                    <div style="width: 25%; float: left">
                                        <div class="lblAndTxtStyle lunchouttime">
                                            <a>
                                                <asp:CheckBox ID="chkLunchOuttime" Text="Lunch out time" runat="server" onclick="toggleLunchOutClick(this);"
                                                    Checked="true" /></a>
                                        </div>
                                    </div>
                                    <div style="width: 25%; float: left">
                                        <div class="lblAndTxtStyle lunchintime">
                                            <a>
                                                <asp:CheckBox ID="chkLunchIntime" Text="Lunch in time" runat="server" onclick="toggleLunchInClick(this);"
                                                    Checked="true" /></a>
                                        </div>
                                    </div>
                                </div>
                                <div style="width: 100%; float: left">
                                    <div class="makeLunchOut" style="width: 25%; float: left">
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px bglbl" style="width: 50%">
                                                <a>With OT</a>
                                            </div>
                                            <div class="div80Px" style="width: 20%; float: left;">
                                                <asp:TextBox ID="txtWithOT" runat="server" CssClass="txtwidth40px "></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="width: 25%; float: left">
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px bglbl" style="width: 50%">
                                                <a>Make Late</a>
                                            </div>
                                            <div class="div80Px" style="width: 20%; float: left;">
                                                <asp:TextBox ID="txtMakeLate" runat="server" CssClass="txtwidth40px "></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="makeLunchOut" style="width: 25%; float: left">
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px bglbl" style="width: 50%">
                                                <a>Make EOut</a>
                                            </div>
                                            <div class="div80Px" style="width: 20%; float: left;">
                                                <asp:TextBox ID="txtMakeEarlyOut" runat="server" CssClass="txtwidth40px "></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="width: 25%; float: left">
                                        <div class="lblAndTxtStyle">
                                            <a>
                                                <asp:CheckBox ID="chkMakeLOut" Text="Make LOut" runat="server" onclick="toggleLOut(this);" /></a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 25%; float: left">
                                <div style="width: 90%; float: left">
                                    <div class="lblAndTxtStyle existingpunch">
                                        <a>
                                            <asp:CheckBox ID="chkOverWriteExistingPunch" Text="OverWrite existing punch" runat="server" /></a>
                                    </div>
                                </div>
                                <div style="width: 90%; float: left">
                                    <div class="lblAndTxtStyle wh">
                                        <a>
                                            <asp:CheckBox ID="chkDontInsertDataIfWHExists" Text="Don't Insert Data if W/H exists"
                                                runat="server" /></a>
                                    </div>
                                </div>
                                <div style="width: 90%; float: left">
                                    <div class="lblAndTxtStyle leave">
                                        <a>
                                            <asp:CheckBox ID="chkDontInsertDataIfLeaveexists" Text="Don't Insert Data if LV exists"
                                                runat="server" /></a>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 15%; float: left">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px bglbl" style="width: 97%">
                                        <a>Common Remarks</a>
                                    </div>
                                    <div>
                                        <asp:TextBox ID="txtRemarks" CssClass="txtwidth178px allowEnter" runat="server" TextMode="MultiLine">
                                        </asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asl:ucEmpList ID="ctrlEmpList" runat="server"></asl:ucEmpList>
                    </div>
                </div>
                <div id="tabAttManual2" style="width: 99%; float: left">
                    <div>
                        <table id="grdAttManual">
                        </table>
                    </div>
                    <div id="grdAttManual_pager">
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
                <asp:Button ID="btnProcessOrReprocess" runat="server" CssClass="button" Text="SAVE" />
            </div>
        </div>
        <asp:HiddenField ID="hfCurrentUser" runat="server" />
    </div>
</asp:Content>
