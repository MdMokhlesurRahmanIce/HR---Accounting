<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="AttendancePaymentInfo.aspx.cs" Inherits="Hr.Web.UI.Payroll.AttendancePaymentInfo" %>

<%@ Register Src="~/Controls/BasedOnSalaryCalculation.ascx" TagName="ucBasedOnSalaryCalculation"
    TagPrefix="gm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src='<%= ResolveUrl("~/GridScripts/AttPaymentRuleCriteria.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/GridScripts/AttPaymentInfo_PreApprovedLeaveType.js") %>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/GridScripts/AttPaymentRuleAmount.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/GridScripts/AttPaymentRule.js") %>' type="text/javascript"></script>
    <style type="text/css">
        div.GroupBoxContainer
        {
            border: 1px solid #CCCCCC;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            float: left;
            margin: 5px;
            width: 99%;
            padding-bottom: 5px;
            background-color: #E6E4DA;
        }
        div.GroupBoxTitlebar
        {
            -moz-border-bottom-colors: none;
            -moz-border-image: none;
            -moz-border-left-colors: none;
            -moz-border-right-colors: none;
            -moz-border-top-colors: none;
            background-color: #F8F7F6;
            border-color: #CBC7BD; /*rgba(0, 39, 121, 0.76) rgba(0, 39, 121, 0.76) -moz-use-text-color;*/
            border-style: solid solid none;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-width: 1px 1px medium;
            font-style: italic;
            height: 20px;
        }
        .TitlebarCaption
        {
            color: #974B24;
            font-size: .88em;
            font-weight: bold;
            margin-bottom: 0;
        }
        .marginLeft
        {
            margin-left: 5px;
        }
        .width
        {
            width: 95%;
        }
        #tabMarker .lblAndTxtStyle
        {
            font-family: 'Microsoft Sans Serif' ,Sans-Serif,Arial;
        }
    </style>
    <script type="text/javascript">
        var $tabs;
        var selectedtab;
        $(function () {
            $tabs = $("#divTab").tabs();
            $tabs.tabs('select', selectedtab);
        });
        $(document).ready(function () {
            $("#Formula").hide();
            $(".exclude").hide();
            $("#Days").hide();
            $(".payment").hide();
            $(".tmp5").show();
            $(".tmp6").show();
            $("#<%= rdoHours.ClientID %>").live("click", function () {
                $("#ForHour").show();
                $("#ForDays").hide();
            });
            $("#<%= rdoDays.ClientID %>").live("click", function () {
                $("#ForHour").hide();
                $("#ForDays").show();
            });
            $("#<%= rdoLate.ClientID %>").live("click", function () {
                $("#Late").show();
                $("#ForDays").show();
                $("#ForHour").hide();
                $("#AttBonus").hide();
                $("#cphBody_cphInfbody_lblLate").text("Late Will be Treated As");
                $("#cphBody_cphInfbody_lblTreatment").text("Late Treatment For");

            });
            $("#<%= rdoAbsenteeism.ClientID %>").live("click", function () {
                $("#Late").hide();
                $("#AttBonus").hide();
            });
            $("#<%= rdoEarlyOut.ClientID %>").live("click", function () {
                $("#Late").show();
                $("#ForDays").show();
                $("#ForHour").hide();
                $("#AttBonus").hide();
                $("#cphBody_cphInfbody_lblLate").text("Early Out Will be Treated As");
                $("#cphBody_cphInfbody_lblTreatment").text("Early Out Treatment For");
            });
            $("#<%= rdoLateAndEarlyOut.ClientID %>").live("click", function () {
                $("#Late").show();
                $("#ForDays").show();
                $("#ForHour").hide();
                $("#AttBonus").hide();
                $("#cphBody_cphInfbody_lblLate").text("Late And Early Out Will be Treated As");
                $("#cphBody_cphInfbody_lblTreatment").text("Late And Early Out Treatment For");
            });
            $("#<%= rdoAttBonus.ClientID %>").live("click", function () {
                $("#AttBonus").show();
                $("#Late").hide();
            });
            $("#<%= rdoHolidayBonus.ClientID %>").live("click", function () {
                $("#AttBonus").hide();
                $("#Late").hide();
            });
            $("#<%= btnAddNewCriteria.ClientID %>").live("click", function () {
                var $tabs;
                var selectedtab = 1;
                $tabs = $("#divTab").tabs();
                $tabs.tabs('select', selectedtab);
                return false;
            });
            $("#<%= btnAddNewPaymentAmount.ClientID %>").live("click", function () {
                var $tabs;
                var selectedtab = 2;
                $tabs = $("#divTab").tabs();
                $tabs.tabs('select', selectedtab);
                return false;
            });
            $("#<%= rdoWorking.ClientID %>").live("click", function () {
                $(".exclude").show();
                $("#Days").hide();
            });
            $("#<%= rdoCalendar.ClientID %>").live("click", function () {
                $(".exclude").hide();
                $("#Days").hide();
            });
            $("#<%= rdoFixed.ClientID %>").live("click", function () {
                $(".exclude").hide();
                $("#Days").show();
            });
            $("#<%= btnDefine.ClientID %>").live("click", function () {
                var paymentName = $("#cphBody_cphInfbody_txtPaymentName").val();
                var calculation = "";
                if (paymentName == "") {
                    ShowMessageBox("HR", "Please enter payment name!");
                    return false;
                }
                if ($("#cphBody_cphInfbody_ucSalaryRule_rdoFixed").is(":checked")) {
                    if ($("#cphBody_cphInfbody_ucSalaryRule_txtParentHeadAmount").val() == "") {
                        ShowMessageBox("HR", "Please enter payment name!");
                        return false;
                    }
                    calculation = $("#cphBody_cphInfbody_ucSalaryRule_txtParentHeadAmount").val();
                }
                if ($("#cphBody_cphInfbody_ucSalaryRule_rdoPercentage").is(":checked")) {
                    if ($("#cphBody_cphInfbody_ucSalaryRule_ddlParentHead").val() == "") {
                        ShowMessageBox("HR", "Please select salary head!");
                        return false;
                    }
                    if ($("#cphBody_cphInfbody_ucSalaryRule_txtParentHeadAmount").val() == "") {
                        ShowMessageBox("HR", "Please enter amount!");
                        return false;
                    }
                    calculation = $("#cphBody_cphInfbody_ucSalaryRule_txtParentHeadAmount").val() + " % of" + $("#cphBody_cphInfbody_ucSalaryRule_ddlParentHead option:selected").text();
                }
                if ($("#cphBody_cphInfbody_ucSalaryRule_rdoPartial").is(":checked")) {
                    if ($("#cphBody_cphInfbody_ucSalaryRule_ddlParentHead").val() == "") {
                        ShowMessageBox("HR", "Please select parent head!");
                        return false;
                    }
                    if ($("#cphBody_cphInfbody_ucSalaryRule_txtParentHeadAmount").val() == "") {
                        ShowMessageBox("HR", "Please enter parent amount!");
                        return false;
                    }
                    if ($("#cphBody_cphInfbody_ucSalaryRule_ddlPartialHead").val() == "") {
                        ShowMessageBox("HR", "Please select partial head!");
                        return false;
                    }
                    if ($("#cphBody_cphInfbody_ucSalaryRule_txtPartialHeadValue").val() == "") {
                        ShowMessageBox("HR", "Please enter partial amount!");
                        return false;
                    }
                    calculation = $("#cphBody_cphInfbody_ucSalaryRule_txtParentHeadAmount").val() + " % of" + $("#cphBody_cphInfbody_ucSalaryRule_ddlParentHead option:selected").text() + " or " + $("#cphBody_cphInfbody_ucSalaryRule_ddlPartialHead").val() + " % of" + $("#cphBody_cphInfbody_ucSalaryRule_txtPartialHeadValue option:selected").text();
                }
                if ($("#cphBody_cphInfbody_ucSalaryRule_rdoFixed1").is(":checked"))
                    calculation = calculation + ",it is fixed";
                else
                    calculation = calculation + ",it is proportionate";
                var reportHead = $("#cphBody_cphInfbody_ddlSalaryHead").val();
                if (reportHead == "") {
                    ShowMessageBox("HR", "Please select salary head!");
                    return false;
                }
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=DefinePaymentPolicy&PaymentName=' + paymentName + '&Calculation=' + calculation + '&ReportHead=' + reportHead,
                    	                async: false
                    	            }
                                ).responseText
                //$("#grdAttPaymentRuleAmount").trigger("reloadGrid");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
<%--        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Attendence Payment Information"></asp:Label>
        </div>--%>
        <div class="form-details">
            <div style="width: 30%; float: left">
                <div id="divPersonalInfo" class="GroupBoxContainer" style="margin: 0px;">
                    <div class="GroupBoxTitlebar">
                        <span class="TitlebarCaption">Attendance Payment Information:</span>
                    </div>
                    <div class="lblAndTxt100Pdiv marginLeft">
                        <asp:Label ID="lblAttPaymentName" runat="server" CssClass="lblStyle">Attendance Payment Name</asp:Label>
                    </div>
                    <div class="lblAndTxt100Pdiv marginLeft">
                        <div style="float: left; width: 80%">
                            <asp:TextBox ID="txtAttPaymentName" runat="server" CssClass="txt100P"></asp:TextBox>
                        </div>
                        <div style="float: left; margin-left: 5px;">
                            <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" />
                        </div>
                    </div>
                    <div class="lblAndTxt100Pdiv marginLeft">
                        <asp:Label ID="lblDescription" runat="server" CssClass="lblStyle">Description</asp:Label>
                    </div>
                    <div class="lblAndTxt100Pdiv marginLeft">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="txt100P" Width="95%" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <br />
                <div style="width:99%">
                    <div>
                        <table id="grdAttPaymentRule">
                        </table>
                    </div>
                    <div id="grdAttPaymentRule_pager">
                    </div>
                </div>
            </div>
            <div id="divTab" style="width: 69%; float: left; padding-bottom: 10px;" onclick="return divTab_onclick()">
                <ul>
                    <li><a href="#tabPaymentRule">Payment Rule</a></li>
                    <li><a href="#tabPaymentCriteria">Payment Criteria</a></li>
                    <li><a href="#tabPaymentPolices">Payment Police(s)</a></li>
                </ul>
                <div id="tabPaymentRule">
                    <div class="lblAndTxt100Pdiv">
                        <asp:Label ID="lblPayRuleName" runat="server" CssClass="lblStyle">Attendance Payment Rule Name</asp:Label>
                    </div>
                    <div class="lblAndTxt100Pdiv">
                        <asp:TextBox ID="txtAttPaymentRuleName" runat="server" CssClass="txt100P" Width="99%"></asp:TextBox>
                    </div>
                    <div style="width: 30%; float: left">
                        <div class="GroupBoxContainer" style="margin: 0px; height: 155px">
                            <div class="GroupBoxTitlebar">
                                <span class="TitlebarCaption">This Rule For:</span>
                            </div>
                            <div>
                                <asp:RadioButton GroupName="RuleFor" ID="rdoAbsenteeism" Font-Size="11px" runat="server"
                                    Text="Absenteeism Calculation" Checked="true" />
                            </div>
                            <div>
                                <asp:RadioButton GroupName="RuleFor" ID="rdoLate" Font-Size="11px" runat="server"
                                    Text="Late Calculation" />
                            </div>
                            <div>
                                <asp:RadioButton GroupName="RuleFor" ID="rdoEarlyOut" Font-Size="11px" runat="server"
                                    Text="Early Out Calculation" />
                            </div>
                            <div>
                                <asp:RadioButton GroupName="RuleFor" ID="rdoLateAndEarlyOut" Font-Size="11px" runat="server"
                                    Text="Late And Early Out Calculation" />
                            </div>
                            <div>
                                <asp:RadioButton GroupName="RuleFor" ID="rdoAttBonus" Font-Size="11px" runat="server"
                                    Text="Attendance Bonus Calculation" />
                            </div>
                            <div>
                                <asp:RadioButton GroupName="RuleFor" ID="rdoHolidayBonus" Font-Size="11px" runat="server"
                                    Text="Holiday Bonus Calculation" />
                            </div>
                        </div>
                    </div>
                    <div style="width: 69%; float: left; margin-left: 5px;">
                        <div class="GroupBoxContainer" style="margin: 0px; height: 155px">
                            <div class="GroupBoxTitlebar">
                                <span class="TitlebarCaption">Rule Setting:</span>
                            </div>
                            <%--Absenteeism Start--%>
                            <div style="margin-left: 5px">
                                Days in the Processed Month is Calculated
                            </div>
                            <div style="width: 20%; float: left">
                                <asp:RadioButton GroupName="RuleSetting" ID="rdoCalendar" Font-Size="11px" runat="server"
                                    Text="Calendar" Checked="true" />
                            </div>
                            <div style="width: 20%; float: left">
                                <asp:RadioButton GroupName="RuleSetting" ID="rdoWorking" Font-Size="11px" runat="server"
                                    Text="Working" />
                            </div>
                            <div style="width: 60%; float: left">
                                <div style="float: left; width: 30%">
                                    <asp:RadioButton GroupName="RuleSetting" ID="rdoFixed" Font-Size="11px" runat="server"
                                        Text="Days" />
                                </div>
                                <div id="Days" style="float: left; width: 50%">
                                    <asp:TextBox ID="txtDays" runat="server" CssClass="txt100P" Width="50%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="exclude">
                                <asp:CheckBox ID="chkExcludeWeekend" Text="Exclude Weekend" runat="server" />
                                <asp:CheckBox ID="chkExcludeHoliday" Text="Exclude Holiday" runat="server" />
                            </div>
                            <%--Absenteeism End--%>
                            <%--Late Start--%>
                            <div id="Late" style="margin-left: 5px; display: none">
                                <div style="float: left; width: 38%">
                                    <asp:Label ID="lblLate" runat="server" Text=""></asp:Label>
                                </div>
                                <div style="float: left; width: 50%">
                                    <div style="float: left; width: 30%">
                                        <asp:RadioButton GroupName="Late" ID="rdoDays" Font-Size="11px" runat="server" Text="Day(s)"
                                            Checked="true" />
                                    </div>
                                    <div style="float: left; width: 50%">
                                        <asp:RadioButton GroupName="Late" ID="rdoHours" Font-Size="11px" runat="server" Text="Hour(s)" />
                                    </div>
                                </div>
                                <div id="ForHour" style="display: none">
                                    <div style="float: left;">
                                        <asp:TextBox ID="txtMinute" runat="server" CssClass="txt100P" Width="50%"></asp:TextBox>
                                    </div>
                                    <div style="float: left;">
                                        Minimum fraction in hour.
                                    </div>
                                </div>
                                <div id="ForDays" style="display: none">
                                    <div style="float: left;">
                                        <asp:TextBox ID="txtLateDays" runat="server" CssClass="txt100P" Width="50%"></asp:TextBox>
                                    </div>
                                    <div style="float: left;">
                                        Days will be deduct
                                    </div>
                                    <div style="clear: both">
                                    </div>
                                    <div style="float: left; width: 35%">
                                        <asp:Label ID="lblTreatment" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div style="float: left; width: 50%">
                                        <div style="float: left; width: 50%">
                                            <asp:RadioButton GroupName="LateTransfer" ID="rdoConsecutiveLate" Font-Size="11px"
                                                runat="server" Text="Consecutive Late" Checked="true" />
                                        </div>
                                        <div style="float: left; width: 50%">
                                            <asp:RadioButton GroupName="LateTransfer" ID="rdoNoOfLate" Font-Size="11px" runat="server"
                                                Text="No Of Late" />
                                        </div>
                                    </div>
                                    <div>
                                        <div style="float: left;">
                                            <asp:TextBox ID="txtLateTransferDays" runat="server" CssClass="txt100P" Width="50%"></asp:TextBox>
                                        </div>
                                        <div style="float: left;">
                                            Day(s) Late Will be Effect in Salary.
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--Late End--%>
                            <%--Attendance Bonus Start--%>
                            <div id="AttBonus" style="display: none">
                                <asp:CheckBox ID="chkAttBonus" Text="DOJ and DOS must not be in salary process date range."
                                    runat="server" />
                            </div>
                            <%--Attendance Bonus Start--%>
                        </div>
                    </div>
                    <div style="clear: both">
                    </div>
                    <br />
                    <div>
                        <div style="float: left">
                            <a>Payment Criteria</a>
                        </div>
                        <div style="float: left; margin-left: 5px;">
                            <asp:LinkButton ID="btnAddNewCriteria" runat="server" Style="color: #974B24">(Add New Payment Criteria)</asp:LinkButton>
                        </div>
                        <asp:TextBox ID="txtPaymentCriteria" runat="server" CssClass="txtwidth178px allowEnter"
                            Width="99%" MaxLength="500" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div style="clear: both">
                    </div>
                    <br />
                    <div>
                        <div style="float: left">
                            <a>Payment Amount</a>
                        </div>
                        <div style="float: left; margin-left: 5px">
                            <asp:LinkButton ID="btnAddNewPaymentAmount" runat="server" Style="color: #974B24">(Add New Payment Amount)</asp:LinkButton>
                        </div>
                        <asp:TextBox ID="txtPaymentAmount" runat="server" CssClass="txtwidth178px allowEnter"
                            Width="99%" MaxLength="500" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
                <div id="tabPaymentCriteria">
                    <div style="width: 55%; float: left">
                        <div>
                            <table id="grdAttPaymentRuleCriteria">
                            </table>
                        </div>
                        <div id="grdAttPaymentRuleCriteria_pager">
                        </div>
                    </div>
                    <div id="PreApprovedLeaveType" style="width: 40%; float: left; margin-left: 30px;
                        display: none">
                        <div>
                            <table id="grdPreApprovedLeaveType">
                            </table>
                        </div>
                        <div id="grdPreApprovedLeaveType_pager">
                        </div>
                    </div>
                </div>
                <div id="tabPaymentPolices">
                    <div class="GroupBoxContainer" style="margin: 0px; width: 73%">
                        <div class="GroupBoxTitlebar">
                            <span class="TitlebarCaption"></span>
                        </div>
                        <div class="lblAndTxt100Pdiv marginLeft">
                            <asp:Label ID="lblPaymentName" runat="server" CssClass="lblStyle">Payment Name</asp:Label>
                        </div>
                        <div class="lblAndTxt100Pdiv marginLeft">
                            <asp:TextBox ID="txtPaymentName" runat="server" CssClass="txt100P" Width="93%"></asp:TextBox>
                        </div>
                        <gm:ucBasedOnSalaryCalculation ID="ucSalaryRule" runat="server"></gm:ucBasedOnSalaryCalculation>
                        <div style="width: 100%; float: left; margin-left: 5px">
                            <div style="width: 10px; height: 10px; background-color: Green; float: left">
                            </div>
                            <div style="width: 80%; float: left">
                                <a>&nbsp;&nbsp; This amount will be stored on the following head </a>
                            </div>
                            <div class="div182Px">
                                <asp:DropDownList ID="ddlSalaryHead" runat="server" CssClass="drpwidth180px" Width="70%">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="btnRight" style="margin-right: 5px">
                            <asp:Button ID="btnDefine" runat="server" CssClass="button" Text="Define" OnClick="btnDefine_Click" />
                        </div>
                    </div>
                    <div style="clear: both">
                    </div>
                    <br />
                    <div style="width: 97%; float: left">
                        <div>
                            <table id="grdAttPaymentRuleAmount">
                            </table>
                        </div>
                        <div id="grdAttPaymentRuleAmount_pager">
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both">
            </div>
            <br />
            <div class="form-bottom" style="text-align: center">
                <div class="btnRight">
                    <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" />
                </div>
                <div class="btnRight">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" />
                </div>
                <div class="btnRight">
                    <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
