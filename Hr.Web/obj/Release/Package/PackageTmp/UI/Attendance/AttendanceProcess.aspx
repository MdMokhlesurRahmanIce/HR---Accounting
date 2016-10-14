<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="AttendanceProcess.aspx.cs" Inherits="Hr.Web.UI.Attendance.AttendanceProcess" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmpList.ascx" TagName="ucEmpList" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/DailyAttendece.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        var $tabs;
        var selectedtab;
        $(document).ready(function () {
            $("#cphBody_cphInfbody_btnView").click(function (e) {
                var spName = "spGetEmpForSearch1";
                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllEmpForCalendar&SpName=' + spName + '&FromDate=' + fromDate + '&ToDate=' + toDate,
                    	                async: false
                    	            }
                                ).responseText
                $("#grdCalendar").trigger("reloadGrid");
                return false;
            });
            //accordion
            $(function () {
                var fixScroll = function (event, ui) {
                    $(event.target).find('ui-accordion-content-active').css('overflow', 'visible');
                }
                $('#container').accordion({
                    header: "h3",
                    create: fixScroll,
                    change: fixScroll
                });
                //end accordion
            });

            $("#cphBody_cphInfbody_btnProcessOrReprocess").click(function (e) {
                if ($("#cphBody_cphInfbody_txtFromDate").val() == "") {
                    ShowMessageBox("HR", "Please select from date!");
                    return false;
                }
                if ($("#cphBody_cphInfbody_txtToDate").val() == "") {
                    ShowMessageBox("HR", "Please select to date!");
                    return false;
                }
                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	            //  url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllEmpForAttProcessForRowData1&FromDate=' + fromDate + '&ToDate=' + toDate,
                    	            //   async: false
                    	        }
                                ).responseText
                $("#grdCalendar").trigger("reloadGrid");
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
            $("input[id$='txtLastProcessdate']").datepicker({
                showButtonPanel: true
                , changeMonth: true
                , changeYear: true
                , onSelect: function () { }
                , defaultDate: new Date()
                , dateFormat: 'mm/dd/yy'
                , onSelect: function (selectedDate) {
                    var workdate = selectedDate;


                    var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=GetAttnSummary&Workdate=' + workdate,
                    	                async: false
                    	            }
                                ).responseText;
                    	            document.getElementById("<%= txtSummary.ClientID %>").value = retVal
                    

                }
            , defaultDate: new Date(), dateFormat: 'mm/dd/yy'
            });
        });
        $(function () {
            $tabs = $("#divTab").tabs();
            $tabs.tabs('select', selectedtab);
            $("#divTab").bind("tabsselect", function (e, tab) {
                if (tab.index == 1) {
                    if ($("#cphBody_cphInfbody_txtFromDate").val() == "") {
                        ShowMessageBox("HR", "Please select from date!");
                        return false;
                    }
                    if ($("#cphBody_cphInfbody_txtToDate").val() == "") {
                        ShowMessageBox("HR", "Please select to date!");
                        return false;
                    }
                    if ($("#cphBody_cphInfbody_ucAttendance_ddlCompany").val() == "") {
                        ShowMessageBox("HR", "Please select Company!");
                        return false;
                    }
                    var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                    var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                    var str = GetSettings();
                    var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllEmpForAttProcessForRowData&FromDate=' + fromDate + '&ToDate=' + toDate +'&Str='+ str,
                    	                async: false
                    	            }
                                ).responseText
                    $("#grdDailyAttendance").trigger("reloadGrid");
                }
            });
            function GetSettings() {
                var str = "";
                var IsPWP = $("#cphBody_cphInfbody_rdoPresent").is(":checked");
                var IsPWW = $("#cphBody_cphInfbody_rdoWeekend").is(":checked");
                var IsPW = $("#cphBody_cphInfbody_rdoPW").is(":checked");

                var IsPHP = $("#cphBody_cphInfbody_rdoPinHoliday").is(":checked");
                var IsPHH = $("#cphBody_cphInfbody_rdoHoliday").is(":checked");
                var IsPH = $("#cphBody_cphInfbody_rdoPH").is(":checked");


                var IsPLVP = $("#cphBody_cphInfbody_rdoPifLeave").is(":checked");
                var IsPLVLV = $("#cphBody_cphInfbody_rdoLVonly").is(":checked");
                var IsPLV = $("#cphBody_cphInfbody_rdoPLV").is(":checked");

                var IsSingleP = $("#cphBody_cphInfbody_rdoSingleAbsent").is(":checked");
                var IsSingleA = $("#cphBody_cphInfbody_rdoSinglePresent").is(":checked");


                str = "PWP," + IsPWP + ",PWW," + IsPWW + ",PW," + IsPW + ",PHP," + IsPHP + ",PHH," + IsPHH + ",PH," + IsPH + ",PLVP," + IsPLVP + ",PLVLV," + IsPLVLV + ",PLV," + IsPLV + ",SingleP," + IsSingleP + ",SingleA," + IsSingleA;
                return str;
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div id="divTab" style="width: 99%; float: left;" onclick="return divTab_onclick()">
                <ul>
                    <li><a href="#tabStep1">Step-1</a></li>
                    <li><a href="#tabStep2">Step-2</a></li>
                </ul>
                <div id="tabStep1" style="width: 99%; float: left">
                    <div style="width: 28%; float: left">
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>From Date</a>
                            </div>
                            <div class="div80Px" style="width: 59%">
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>To Date</a>
                            </div>
                            <div class="div80Px" style="width: 59%">
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <asl:ucEmployeeSearch ID="ctrlEmpSearch" runat="server"></asl:ucEmployeeSearch>
                        <div style="text-align: right">
                            <asp:Button ID="btnView" runat="server" CssClass="button" Text="View" />
                        </div>
                        <div id="container">
                            <h3 class="headline">
                                <a href="#">Settings</a></h3>
                            <div class="accordion">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px bglbl" style="width: 48%; float: left; padding-left: 0px">
                                        <a>If Present in a weekend: </a>
                                    </div>
                                    <div style="width: 13%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="PresentWeekend" ID="rdoPresent" runat="server" Text="P" />
                                        </a>
                                    </div>
                                    <div style="width: 15%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="PresentWeekend" ID="rdoWeekend" runat="server" Text="W" />
                                        </a>
                                    </div>
                                    <div style="width: 20%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="PresentWeekend" ID="rdoPW" runat="server" Text="PW" Checked="true" />
                                        </a>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px bglbl" style="width: 48%; float: left; padding-left: 0px">
                                        <a>If Present in a Holiday: </a>
                                    </div>
                                    <div style="width: 13%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="PresentHoliday" ID="rdoPinHoliday" runat="server" Text="P" />
                                        </a>
                                    </div>
                                    <div style="width: 15%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="PresentHoliday" ID="rdoHoliday" runat="server" Text="H" />
                                        </a>
                                    </div>
                                    <div style="width: 20%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="PresentHoliday" ID="rdPH" runat="server" Text="PH" Checked="true" />
                                        </a>
                                    </div>
                                </div>
                                 <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px bglbl" style="width: 48%; float: left; padding-left: 0px">
                                        <a>If in Leave but Present: </a>
                                    </div>
                                    <div style="width: 13%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="PresentLeave" ID="rdoPifLeave" runat="server" Text="P" />
                                        </a>
                                    </div>
                                    <div style="width: 15%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="PresentLeave" ID="rdoLVonly" runat="server" Text="LV" />
                                        </a>
                                    </div>
                                    <div style="width: 20%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="PresentLeave" ID="rdoPLV" runat="server" Text="PLV" Checked="true" />
                                        </a>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px bglbl" style="width: 48%; float: left; padding-left: 0px">
                                        <a>Single Punch treated as: </a>
                                    </div>
                                    <div style="width: 25%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="singlepunch" ID="rdoSingleAbsent" runat="server" Text="Absent" />
                                        </a>
                                    </div>
                                    <div style="width: 25%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="singlepunch" ID="rdoSinglePresent" runat="server" Text="Present"
                                                Checked="true" />
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <h3 class="headline">
                                <a href="#">Advance Options</a></h3>
                            <div class="accordion">
                            </div>
                        </div>
                    </div>
                    <div style="width: 72%; float: left">
                        <asl:ucEmpList ID="ctrlEmpList" runat="server"></asl:ucEmpList>
                        <div style="width: 99%; float: left">
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth100px" style="width: 12%; float: left">
                                    <a>Last Processed on</a>
                                </div>
                                <div class="div80Px"  style="width: 12%; float: left">
                                    <asp:TextBox ID="txtLastProcessdate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                </div>
                                <div class="div80Px"  style="width: 75%; float: left; padding-left: 1px">
                                    <asp:TextBox ID="txtSummary" runat="server" CssClass="txtwidth178px" Width="99%" MaxLength="100"
                                        Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tabStep2" style="width: 99%; float: left">
                    <%--                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal">--%>
                    <div>
                        <div>
                            <table id="grdDailyAttendance">
                            </table>
                        </div>
                        <div id="grdDailyAttence_pager">
                        </div>
                    </div>
                    <%--                    </asp:Panel>--%>
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
                <asp:Button ID="btnProcessOrReprocess" runat="server" CssClass="button" Text="SAVE"
                    OnClick="btnProcessSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
