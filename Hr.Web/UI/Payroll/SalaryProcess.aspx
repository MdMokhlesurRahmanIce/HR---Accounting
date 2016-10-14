<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="SalaryProcess.aspx.cs" Inherits="Hr.Web.UI.Payroll.SalaryProcess" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmpList.ascx" TagName="ucEmpList" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/DailyAttendece.js") %> " type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/GridScripts/SalaryProcessGrid.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
        var $tabs;
        var selectedtab;
        $(document).ready(function () {
            $("#cphBody_cphInfbody_btnView").click(function (e) {
                var spName = "spGetEmpForSalaryProcess";
                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                var LockStatus = $("#cphBody_cphInfbody_txtLock").val();

                if (LockStatus == "Lock") {
                    ShowMessageBox("HR", "Salary Process For This Month is Locked by Admin!");
                    return false;
                }
                if (fromDate == "") {
                    ShowMessageBox("HR", "Please select Year-Month or Specific Date!");
                    return false;
                }
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
            $(".weekly").hide();
            $(".daily").hide();
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
            });
            //end accordion
            $("#cphBody_cphInfbody_ddlMonthNo").change(function (e) {

                var YearNo = $("#cphBody_cphInfbody_ddlyearno").val();
                var MonthNo = $("#cphBody_cphInfbody_ddlMonthNo").val();
                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=GetFromDateAndToDate&YearNo=' + YearNo + '&MonthNo=' + MonthNo,
                    	                async: false
                    	            }
                                ).responseText
                var item = retVal.split(',');
                document.getElementById("<%= txtFromDate.ClientID %>").value = item[0];
                document.getElementById("<%= txtToDate.ClientID %>").value = item[1];
                document.getElementById("<%= txtLock.ClientID %>").value = item[2];

            });
            $(function () {
                $tabs = $("#divTab").tabs();
                $tabs.tabs('select', selectedtab);
                $("#divTab").bind("tabsselect", function (e, tab) {
                    if (tab.index == 1) {
                        var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                        var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                        var LockStatus = $("#cphBody_cphInfbody_txtLock").val();

                        if (LockStatus == "Lock") {
                            ShowMessageBox("HR", "Salary Process For This Month is Locked by Admin!");
                            return false;
                        }
                        if (fromDate == "") {
                            ShowMessageBox("HR", "Please select Year-Month or Specific Date!");
                            return false;
                        }

                    }
                });
            });
            $(function () {
                $tabs = $("#divTab").tabs();
                $tabs.tabs('select', selectedtab);
                $("#divTab").bind("tabsselect", function (e, tab) {
                    if (tab.index == 2) {
                        var YearNo = $("#cphBody_cphInfbody_ddlyearno").val();
                        var MonthNo = $("#cphBody_cphInfbody_ddlMonthNo").val();
                        var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                        var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                        var LockStatus = $("#cphBody_cphInfbody_txtLock").val();

                        if (LockStatus == "Lock") {
                            ShowMessageBox("HR", "Salary Process For This Month is Locked by Admin!");
                            return false;
                        }
                        var spName = 'spTempEmpListForSalaryForLoad';
                        if (fromDate == "") {
                            ShowMessageBox("HR", "Please select Year-Month or Specific Date!");
                            return false;
                        }

                        var retVal = jQuery.ajax
                                (
                                    {
                                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=SalaryProcess&SpName=' + spName + '&YearNo=' + YearNo + '&MonthNo=' + MonthNo + '&FromDate=' + fromDate + '&ToDate=' + toDate,
                                        async: false
                                    }
                                ).responseText
                        $("#grdSalaryProcess").trigger("reloadGrid");
                    }
                });
            });
            $("#cphBody_cphInfbody_Save").click(function (e) {
                var spName = 'insertSalaryProcess';
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=SalaryProcessSave&spName=' + spName,
                    	                async: false,
                    	                success: function () { ShowMessageBox('Salary Process', 'Processed Data Saved Successfully.') },
                    	                error: function (xhr, status, error) {
                    	                    ShowMessageBox('Error', xhr.responseText);
                    	                }
                    	            }
                                ).responseText

                $("#grdSalaryProcess").trigger("reloadGrid");
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

            $("input[id$='txtWorkDate']").datepicker({
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
//        $(function () {
//            $tabs = $("#divTab").tabs();
//            $tabs.tabs('select', selectedtab);
//            $("#divTab").bind("tabsselect", function (e, tab) {
//             
//            });
//        });

 $(function () {
            $tabs = $("#divTab").tabs();
            $tabs.tabs('select', selectedtab);
            $("#divTab").bind("tabsselect", function (e, tab) {
             if(tab.index==3){
             var spName = 'spTempEmpListForSalaryForLoad'
             var retval = jQuery.ajax
                  (
                    {
                      url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=SalaryProcess&SpName=' + spName + '&EmpCode=' + EmpCode,
                                        async: false
                    }
                  ).responseText
                 $("#grdSalaryProcess").trigger("reloadGrid");                     
                  
            }
             
            });
        });




        $("#cphBody_cphInfbody_rdoMonthly").live("click", function () {
            $(".monthly").show();
            $(".weekly").hide();
            $(".daily").hide();
        });
        $("#cphBody_cphInfbody_rdoWeekly").live("click", function () {
            $(".monthly").hide();
            $(".weekly").show();
            $(".daily").hide();
        });
        $("#cphBody_cphInfbody_rdoDaily").live("click", function () {
            $(".monthly").hide();
            $(".weekly").hide();
            $(".daily").show();
        });
 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div id="divTab" style="width: 99%; float: left;" onclick="return divTab_onclick()">
                <ul>
                    <li><a href="#tabStep1">Config</a></li>
                    <li><a href="#tabStep2">Selection</a></li>
                    <li><a href="#tabStep3">Process</a></li>
                </ul>
                <div id="tabStep1" style="width: 99%; float: left">
                    <div style="width: 99%; float: left">
                        <div id="container">
                            <div id="expand" style="text-align: right">
                                <img src="/images/plus.gif" />
                                Expand All</div>
                            <h3 class="headline">
                                <a href="#">Salary Processing Type</a></h3>
                            <div class="accordion">
                                <div style="width: 50%; float: left">
                                    <br />
                                    <div class="lblAndTxtStyle">
                                        <div class="divlblwidth100px2">
                                            <a>Salary Type</a>
                                        </div>
                                    </div>
                                    <br />
                                    <div style="width: 33%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="ShiftTransfer" ID="rdoMonthly" runat="server" Text="Monthly"
                                                Checked="true" />
                                        </a>
                                    </div>
                                    <div style="width: 33%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="ShiftTransfer" ID="rdoWeekly" runat="server" Text="Weekly" />
                                        </a>
                                    </div>
                                    <div style="width: 33%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="ShiftTransfer" ID="rdoDaily" runat="server" Text="Daily" />
                                        </a>
                                    </div>
                                    <br />
                                    <div style="width: 60%; float: left">
                                        <br />
                                        <div class="lblAndTxtStyle monthly">
                                            <div class="divlblwidth100px2 bglbl">
                                                <a>Year</a>
                                            </div>
                                            <div class="div80Px" style="float: left;">
                                                <asp:DropDownList ID="ddlyearno" runat="server" OnSelectedIndexChanged="ddlyearno_SelectedIndexChanged"
                                                    AutoPostBack="true" CssClass="txtwidth93px">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle monthly">
                                            <div class="divlblwidth100px2 bglbl">
                                                <a>Month</a>
                                            </div>
                                            <div class="div80Px" style="float: left">
                                                <asp:DropDownList ID="ddlMonthNo" runat="server" CssClass="txtwidth93px">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                         <div class="div80Px" style="width: 59%; visibility:hidden  ">
                                                <asp:TextBox ID="txtLock" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                            </div>
                                        <div class="lblAndTxtStyle weekly">
                                            <div class="divlblwidth100px bglbl">
                                                <a>From Date</a>
                                            </div>
                                            <div class="div80Px" style="width: 59%">
                                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle weekly">
                                            <div class="divlblwidth100px bglbl">
                                                <a>To Date</a>
                                            </div>
                                            <div class="div80Px" style="width: 59%">
                                                <asp:TextBox ID="txtToDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle daily">
                                            <div class="divlblwidth100px bglbl">
                                                <a>Work Date</a>
                                            </div>
                                            <div class="div80Px" style="width: 59%">
                                                <asp:TextBox ID="txtWorkDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <h3 class="headline">
                                <a href="#">Configuration</a></h3>
                            <div class="accordion">
                                <div class="lblAndTxtStyle">
                                    <asp:CheckBox ID="chkPF" Text="Attendance Based Salary" onclick="togglePFclick(this);"
                                        runat="server" />
                                </div>
                                <div class="lblAndTxtStyle">
                                    <asp:CheckBox ID="CheckBox1" Text="Include Attendance Bonus" onclick="togglePFclick(this);"
                                        runat="server" />
                                </div>
                                <div class="lblAndTxtStyle">
                                    <asp:CheckBox ID="CheckBox2" Text="Include Uploaded data from Excel" onclick="togglePFclick(this);"
                                        runat="server" />
                                </div>
                                <div class="lblAndTxtStyle">
                                    <asp:CheckBox ID="CheckBox3" Text="Include Attendane Related Allowance / Deductions"
                                        onclick="togglePFclick(this);" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                    </div>
                </div>
                <div id="tabStep2">
                    <div style="width: 100%">
                        <div style="width: 28%; float: left">
                            <asl:ucEmployeeSearch ID="ctrlEmpSearch" runat="server"></asl:ucEmployeeSearch>
                            <div style="text-align: center">
                                <asp:Button ID="btnView" runat="server" CssClass="button" Text="View" />
                            </div>
                        </div>
                        <div style="width: 72%; float: left">
                            <asl:ucEmpList ID="ctrlEmpList" runat="server"></asl:ucEmpList>
                        </div>
                    </div>
                </div>
                <div id="tabStep3" style="width: 99%; float: left">
                    <div style="padding-left: 15px; float: left; width: 95%;">
                        <table id="grdSalaryProcess">
                        </table>
                    </div>
                    <div id="grdSalaryProcess_pager">
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
                <asp:Button ID="Save" runat="server" CssClass="button" Text="SAVE" />
            </div>
        </div>
    </div>
</asp:Content>
