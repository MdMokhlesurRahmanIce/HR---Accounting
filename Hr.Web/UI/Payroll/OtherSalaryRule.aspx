<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="OtherSalaryRule.aspx.cs" Inherits="Hr.Web.UI.Payroll.OtherSalaryRule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src='<%= ResolveUrl("~/GridScripts/HourWisePayment.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/GridScripts/ShiftInfo.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/GridScripts/LeaveTypeSelection.js") %>' type="text/javascript"></script>
    <script type="text/javascript" src="<%# ResolveUrl("~/src/jquery-ui-timepicker-addon.js") %>"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".Percentage").hide();
            $(".Calculative").hide();
            $(".HourWise").hide();
            $(".exclude").hide();
            //$(".specificLeave").hide();
            //$("#cphBody_cphInfbody_Leave").hide();
            $("#Days").hide();
            $("#<%= rdoFixed.ClientID %>").live("click", function () {
                $(".Percentage").hide();

            });
            if ($("#cphBody_cphInfbody_chkHourWisePayment").is(":checked"))
                $(".HourWise").show();

            $("#<%= ddlFixedPerDay.ClientID %>").live("click", function () {
                if ($("#cphBody_cphInfbody_rdoInGeneral").is(":checked")) {
                    $(".Calculative").show();
                    $("#Days").hide();
                }
                if ($("#cphBody_cphInfbody_rdoPersonalAttn").is(":checked")) {
                    $(".Calculative").hide();
                    $("#Days").hide();
                }
            });
            $("#<%= rdoCalculative.ClientID %>").live("click", function () {
                if ($("#cphBody_cphInfbody_rdoPersonalAttn").is(":checked")) {
                    $(".Calculative").show();
                    $("#Days").hide();
                }
                if ($("#cphBody_cphInfbody_rdoInGeneral").is(":checked")) {
                    $(".Calculative").hide();
                }
            });

            $("#<%= rdoPercentage.ClientID %>").live("click", function () {
                $(".Percentage").show();

            });

            $("#<%= rdoPersonalAttn.ClientID %>").live("click", function () {

                $(".perAtt").show();
                if ($("#cphBody_cphInfbody_chkHourWisePayment").is(":checked")) {
                    $(".criteria").hide();
                    $(".HourWise").show();
                }
                else {
                    $(".criteria").show();
                    $(".Percentage").hide();
                    $(".Calculative").hide();
                    $(".exclude").hide();
                    $(".HourWise").hide();
                }
                $(".HourWiseDiv").show();
                $(".HourWisePayment").show();
            });
            $("#<%= rdoInGeneral.ClientID %>").live("click", function () {

                $(".perAtt").hide();
                $(".HourWiseDiv").hide();
                $("#cphBody_cphInfbody_specificLeave").hide();
                $("#cphBody_cphInfbody_Leave").hide();
            });
            $("#<%= chkSpecificLeaveType.ClientID %>").live("click", function () {
                if ($("#cphBody_cphInfbody_chkSpecificLeaveType").is(":checked")) {

                    $("#cphBody_cphInfbody_Leave").show();
                }
                else { $("#cphBody_cphInfbody_Leave").hide(); }
            });
            $("#<%= chkLV.ClientID %>").live("click", function () {
                if ($("#cphBody_cphInfbody_chkLV").is(":checked")) {
                    $("#cphBody_cphInfbody_specificLeave").show();
                }
                else {
                    $("#cphBody_cphInfbody_specificLeave").hide();
                    $("#cphBody_cphInfbody_Leave").hide();
                }
            });
            $("#<%= rdoCalendar.ClientID %>").live("click", function () {
                $("#Days").hide();
                $(".exclude").hide();
            });
            $("#<%= rdoWorking.ClientID %>").live("click", function () {
                $("#Days").hide();
                $(".exclude").show();
            });
            $("#<%= rdoFixed1.ClientID %>").live("click", function () {
                $("#Days").show();
                $(".exclude").hide();
            });
            $("#<%= chkHourWisePayment.ClientID %>").live("click", function () {
                if ($("#cphBody_cphInfbody_chkHourWisePayment").is(":checked")) {
                    $(".criteria1").hide();
                    $(".criteria2").hide();
                    $(".criteria").hide();
                    $(".HourWise").show();
                }
                else {
                    $(".criteria1").show();
                    $(".criteria2").show();
                    $(".criteria").show();
                    $(".Percentage").hide();
                    $(".Calculative").hide();
                    $(".exclude").hide();
                    $(".HourWise").hide();
                }
            });
            $("#<%= chkConsiderspecificShift.ClientID %>").live("click", function () {
                if ($("#cphBody_cphInfbody_chkConsiderspecificShift").is(":checked")) {
                    $("#cphBody_cphInfbody_shift").show();
                }
                else {
                    $("#cphBody_cphInfbody_shift").hide();
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Other Salary Rule"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 35%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Other Salary Rule Name</a>
                    </div>
                    <div class="div80Px">
                        <div style="float: left; width: 80%">
                            <asp:TextBox ID="txtOtherSalaryRuleName" runat="server" CssClass="txtwidth178px"
                                MaxLength="100"></asp:TextBox>
                        </div>
                        <div style="float: left; margin-left: 5px;">
                            <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png" />
                            <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png"
                                OnClick="btnFind_Click" />
                        </div>
                    </div>
                </div>
                <div style="margin-left: 5px">
                    <a>Description</a>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="txtwidth178px allowEnter"
                        MaxLength="300" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="TypeOfRule">
                    <div style="width: 45%; float: left">
                        <asp:RadioButton GroupName="TypeOfRule" ID="rdoPersonalAttn" Font-Size="11px" runat="server"
                            Text="Personal Attendnace Based" Checked="true" />
                    </div>
                    <div style="width: 55%; float: left">
                        <asp:RadioButton GroupName="TypeOfRule" ID="rdoInGeneral" Font-Size="11px" runat="server"
                            Text="In General (Non Attendnace Based)" />
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Reporting Salary Head</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlSalaryHead" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle perAtt">
                    <div class="divlblwidth100px bglbl">
                        <a>Considerable Day Status</a>
                    </div>
                    <div style="float: left">
                        <a>
                            <asp:CheckBox ID="chkP" runat="server" Text="P" /></a> <a>
                                <asp:CheckBox ID="chkL" runat="server" Text="L" /></a> <a>
                                    <asp:CheckBox ID="chkA" runat="server" Text="A" /></a> <a>
                                        <asp:CheckBox ID="chkLV" runat="server" Text="LV" /></a> <a>
                                            <asp:CheckBox ID="chkW" runat="server" Text="W" /></a> <a>
                                                <asp:CheckBox ID="chkPW" runat="server" Text="PW" /></a>
                        <a>
                            <asp:CheckBox ID="chkLW" runat="server" Text="LW" /></a> <a>
                                <asp:CheckBox ID="chkH" runat="server" Text="H" /></a> <a>
                                    <asp:CheckBox ID="chkPH" runat="server" Text="PH" /></a> <a>
                                        <asp:CheckBox ID="chkLH" runat="server" Text="LH" /></a>
                    </div>
                </div>
                <div id="specificLeave" runat="server">
                    <a>
                        <asp:CheckBox ID="chkSpecificLeaveType" runat="server" Text="Consider Only Specific Leave Type" /></a></div>
                <div class="lblAndTxtStyle criteria1">
                    <div class="divlblwidth100px bglbl">
                        <a>Amount is </a>
                    </div>
                    <div class="criteria">
                        <div style="width: 15%; float: left">
                            <asp:RadioButton GroupName="Criteria" ID="rdoFixed" Font-Size="11px" runat="server"
                                Text="Fixed" Checked="true" />
                        </div>
                        <div style="width: 20%; float: left">
                            <asp:RadioButton GroupName="Criteria" ID="rdoPercentage" Font-Size="11px" runat="server"
                                Text="Percentage" />
                        </div>
                    </div>
                </div>
                <div class="criteria2">
                    <div class="lblAndTxtStyle Percentage">
                        <div class="divlblwidth100px bglbl">
                            <a>Salary Head</a>
                        </div>
                        <div class="div182Px">
                            <asp:DropDownList ID="ddlSalaryHead1" runat="server" CssClass="drpwidth180px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle ">
                        <div class="divlblwidth100px bglbl">
                            <a>Fixed / Per Value</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtAmount" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="lblAndTxtStyle criteria">
                    <div class="divlblwidth100px bglbl">
                        <a>Consider As </a>
                    </div>
                    <div style="float: left; width: 30%">
                        <asp:RadioButton GroupName="amoCal" ID="ddlFixedPerDay" Font-Size="11px" runat="server"
                            Text="Per Day Value" Checked="true" />
                    </div>
                    <div style="float: left; width: 30%">
                        <asp:RadioButton GroupName="amoCal" ID="rdoCalculative" Font-Size="11px" runat="server"
                            Text="Monthly Value" />
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div class="Calculative criteria">
                    <div style="margin-left: 5px">
                        <a>Divisible Factor</a>
                    </div>
                    <div style="width: 20%; float: left">
                        <asp:RadioButton GroupName="DivisibleFactor" ID="rdoCalendar" Font-Size="11px" runat="server"
                            Text="Calendar" Checked="true" />
                    </div>
                    <div style="width: 20%; float: left">
                        <asp:RadioButton GroupName="DivisibleFactor" ID="rdoWorking" Font-Size="11px" runat="server"
                            Text="Working" />
                    </div>
                    <div style="width: 60%; float: left">
                        <div style="float: left; width: 30%">
                            <asp:RadioButton GroupName="DivisibleFactor" ID="rdoFixed1" Font-Size="11px" runat="server"
                                Text="Days" />
                        </div>
                        <div id="Days" style="float: left; width: 50%">
                            <asp:TextBox ID="txtDays" runat="server" CssClass="txt100P" Width="50%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="exclude">
                        <a>
                            <asp:CheckBox ID="chkExcludeWeekend" Text="Exclude Weekend" runat="server" /></a>
                        <a>
                            <asp:CheckBox ID="chkExcludeHoliday" Text="Exclude Holiday" runat="server" /></a>
                    </div>
                </div>
            </div>
            <div style="width: 20%; float: left; margin-left: 10px">
                <a>
                    <asp:CheckBox ID="chkConsiderspecificShift" Text="Consider Specific Shift" runat="server" /></a>
                <div id="shift" runat="server" style="display: none">
                    <div>
                        <table id="grdShiftInfo">
                        </table>
                    </div>
                    <div id="grdShiftInfo_pager">
                    </div>
                </div>
                <div id="Leave" runat="server" style="display: none">
                    <br />
                    <div>
                        <table id="LeaveTypeSelection">
                        </table>
                    </div>
                    <div id="LeaveTypeSelection_pager">
                    </div>
                </div>
            </div>
            <div class="HourWiseDiv" style="width: 40%; float: left; margin-left: 5px">
                <div class="HourWisePayment">
                    <a>
                        <asp:CheckBox ID="chkHourWisePayment" Text="Hour Wise Payment" runat="server" /></a>
                </div>
                <div style="clear: both">
                </div>
                <div class="HourWise">
                    <div>
                        <table id="grdHourWisePayment">
                        </table>
                    </div>
                    <div id="grdHourWisePayment_pager">
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" />
            </div>
        </div>
    </div>
</asp:Content>
