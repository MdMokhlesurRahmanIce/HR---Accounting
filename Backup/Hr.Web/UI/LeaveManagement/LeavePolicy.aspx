<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeavePolicy.aspx.cs"
    Inherits="Hr.Web.UI.LeaveManagement.LeavePolicy" Title="Lotus-12 :: Leave Policy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/grdLVBasedOnServicelength.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#cphBody_cphInfbody_chkLeaveCarryForword").click(function (e) {
                if ($("#cphBody_cphInfbody_chkLeaveCarryForword").is(":checked")) {
                    $("#cphBody_cphInfbody_txtYearlyMaxDays").attr("disabled", false);
                    $("#cphBody_cphInfbody_txtMaxAccumulation").attr("disabled", false);
                }
                else {
                    $("#cphBody_cphInfbody_txtYearlyMaxDays").val("");
                    $("#cphBody_cphInfbody_txtMaxAccumulation").val("");
                    $("#cphBody_cphInfbody_txtYearlyMaxDays").attr("disabled", true);
                    $("#cphBody_cphInfbody_txtMaxAccumulation").attr("disabled", true);
                }
            });
            $("#cphBody_cphInfbody_chkConsicutiveLimit").click(function (e) {
                if ($("#cphBody_cphInfbody_chkConsicutiveLimit").is(":checked")) {
                    $("#cphBody_cphInfbody_txtDays").attr("disabled", false);
                }
                else {
                    $("#cphBody_cphInfbody_txtDays").val("");
                    $("#cphBody_cphInfbody_txtDays").attr("disabled", true);
                }
            });
            $("#cphBody_cphInfbody_chkAllowHourlyLeave").click(function (e) {
                if ($("#cphBody_cphInfbody_chkAllowHourlyLeave").is(":checked")) {
                    $(".chkAdjustfromtotalLVBalance").show();
                }
                else {
                    $(".chkAdjustfromtotalLVBalance").hide();
                    $("#cphBody_cphInfbody_txtHours").val("");
                    $(".txtHours").hide();
                    $("#cphBody_cphInfbody_chkAdjustfromtotalLVBalance").attr("checked", false)
                }
            });
            $("#cphBody_cphInfbody_chkAdjustfromtotalLVBalance").click(function (e) {
                if ($("#cphBody_cphInfbody_chkAdjustfromtotalLVBalance").is(":checked")) {
                    $(".txtHours").show();
                }
                else {
                    $("#cphBody_cphInfbody_txtHours").val("");
                    $(".txtHours").hide();
                }
            });
            $("#cphBody_cphInfbody_rdoBasedOnWorkingDays").live("click", function () {
                $(".txtWorkingDays").show();
                $(".basedOnWorkingdays").show();
                $(".txtLeaveDays").show();
                $(".basedonserviceLength").hide();
            });
            $("#cphBody_cphInfbody_rdoFixedForALL").live("click", function () {
                $(".txtWorkingDays").hide();
                $(".basedOnWorkingdays").hide();
                $(".txtLeaveDays").show();
                $(".basedonserviceLength").hide();
            });
            $("#cphBody_cphInfbody_rdoProportionateForNew").live("click", function () {
                $(".txtWorkingDays").hide();
                $(".basedOnWorkingdays").hide();
                $(".txtLeaveDays").show();
                $(".basedonserviceLength").hide();
            });
            $(".basedonserviceLength").hide();
            $("#cphBody_cphInfbody_rdoBaseonServiceLength").live("click", function () {
                $(".txtWorkingDays").hide();
                $(".basedOnWorkingdays").hide();
                $(".txtLeaveDays").hide();
                $(".basedonserviceLength").show();
            });

        });
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode == 46) return true;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 90%; float: left">
                <br />
                <div style="width: 99%; float: left">
                    <div style="width: 50%; float: left">
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl">
                                <a>Leave Policy ID</a>
                            </div>
                            <div class="div80Px2" style="width: 36%;">
                                <asp:DropDownList ID="ddlLVPolicyId" runat="server" Style="visibility: visible;"
                                    CssClass="drpwidth157px" AutoPostBack="true" OnSelectedIndexChanged="ddlLVPolicyId_SelectedIndexChanged">
                                </asp:DropDownList>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtLeavePolicyID" runat="server" Style="visibility: visible;" CssClass="txtwidth155px">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div style="float: left;">
                                <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle " OnClick="btnNew_Click"
                                    ImageUrl="~/images/new 20X20.png" />
                                <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" />
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl">
                                <a>Leave Type</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtLeaveType" runat="server" Style="visibility: visible;" CssClass="txtwidth155px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl">
                                <a>Description</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="txtwidthDDL156px">
                                </asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div style="width: 99%; float: left">
                    <div style="width: 50%; float: left">
                        <fieldset style="border-color: #AED0EA; border-width: thin">
                            <legend style="font-size: 12px">Leave Days</legend>
                            <div class="lblAndTxtStyle">
                                <div style="width: 20%; float: left">
                                    <a>
                                        <asp:RadioButton GroupName="LeaveDays" ID="rdoFixedForALL" runat="server" Text="Fixed For ALL"
                                            Checked="true" />
                                    </a>
                                </div>
                                <div style="width: 25%; float: left">
                                    <a>
                                        <asp:RadioButton GroupName="LeaveDays" ID="rdoProportionateForNew" runat="server"
                                            Text="Proportionate For New" />
                                    </a>
                                </div>
                                <div style="width: 25%; float: left">
                                    <a>
                                        <asp:RadioButton GroupName="LeaveDays" ID="rdoBasedOnWorkingDays" runat="server"
                                            Text="Based On Working Days" />
                                    </a>
                                </div>
                                <div style="width: 25%; float: left">
                                    <a>
                                        <asp:RadioButton GroupName="LeaveDays" ID="rdoBaseonServiceLength" runat="server"
                                            Text="Base on Service Length" />
                                    </a>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div style="width: 50%; float: left">
                        <fieldset style="border-color: #AED0EA; border-width: thin">
                            <legend style="font-size: 12px">Countable Days</legend>
                            <div id="divWorkingDay" class="txtWorkingDays" style="display: none">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px2 bglbl">
                                        <a id="lavWorkingDays">Working Days</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="txtWorkingDays" runat="server" CssClass="txtwidth93px" onkeypress="return isNumberKey(event)"
                                            MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="txtLeaveDays">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px2 bglbl">
                                        <a>Leave Days</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="txtLeaveDays" runat="server" CssClass="txtwidth93px" onkeypress="return isNumberKey(event)"
                                            MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div style="float: left">
                                <div class="basedOnWorkingdays" style="display: none">
                                    <div style="float: left">
                                        <asp:CheckBox ID="chkAll" Text="ALL" CssClass="fieldset-legend" runat="server" />
                                    </div>
                                    <div style="float: left">
                                        <asp:CheckBox ID="chkP" Text="P" CssClass="fieldset-legend" runat="server" />
                                    </div>
                                    <div style="float: left">
                                        <asp:CheckBox ID="chkL" Text="L" CssClass="fieldset-legend" runat="server" />
                                    </div>
                                    <div style="float: left">
                                        <asp:CheckBox ID="chkW" Text="W" CssClass="fieldset-legend" runat="server" />
                                    </div>
                                    <div style="float: left">
                                        <asp:CheckBox ID="chkPW" Text="PW" CssClass="fieldset-legend" runat="server" />
                                    </div>
                                    <div style="float: left">
                                        <asp:CheckBox ID="chkLW" Text="LW" CssClass="fieldset-legend" runat="server" />
                                    </div>
                                    <div style="float: left">
                                        <asp:CheckBox ID="chkH" Text="H" CssClass="fieldset-legend" runat="server" />
                                    </div>
                                    <div style="float: left">
                                        <asp:CheckBox ID="chkPH" Text="PH" CssClass="fieldset-legend" runat="server" />
                                    </div>
                                    <div style="float: left">
                                        <asp:CheckBox ID="chkA" Text="A" CssClass="fieldset-legend" runat="server" />
                                    </div>
                                    <div style="float: left">
                                        <asp:CheckBox ID="chkLV" Text="LV" CssClass="fieldset-legend" runat="server" />
                                    </div>
                                </div>
                                <div class="basedonserviceLength" style="float: left; width: 99%;">
                                    <div style="float: left;" class="ui-jqgrid">
                                        <table id="grdLVBasedOnServiceLength">
                                        </table>
                                    </div>
                                    <div id="grdLVBasedOnServiceLength_pager">
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
                <div class="lblAndTxtStyle" style="float: left">
                    <div class="divlblwidth100px2 bglbl">
                        <a>Allocation Process</a>
                    </div>
                    <div class="div80Px">
                        <div style="width: 20%; float: left">
                            <a>
                                <asp:RadioButton GroupName="LeaveAllocationProcess" ID="rdoInstant" runat="server"
                                    Text="Instant" Checked="true" />
                            </a>
                        </div>
                        <div style="width: 50%; float: left">
                            <a>
                                <asp:RadioButton GroupName="LeaveAllocationProcess" ID="rdoEndofLeaveCalander" runat="server"
                                    Text="Proportionate" />
                            </a>
                        </div>
                    </div>
                </div>
                <div style="width: 99%; float: left">
                    <fieldset style="border-color: #AED0EA; border-width: thin">
                        <legend style="font-size: 12px">LV Cal. Depends on</legend>
                        <div class="lblAndTxtStyle">
                            <div class="div80Px">
                                <div style="width: 20%; float: left">
                                    <a>
                                        <asp:RadioButton GroupName="LVCalculationDependson" ID="rdoDOJ" runat="server" Text="DOJ"
                                            Checked="true" />
                                    </a>
                                </div>
                                <div style="width: 50%; float: left">
                                    <a>
                                        <asp:RadioButton GroupName="LVCalculationDependson" ID="rdoDOC" runat="server" Text="DOC" />
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle" style="width: 99%; float: left;">
                            <div class="divlblwidth100px2 bglbl">
                                <a>Start After</a>
                            </div>
                            <div>
                                <asp:TextBox ID="txtStartAfter" runat="server" Width="100px" onkeypress="return isNumberKey(event)"
                                    MaxLength="100"></asp:TextBox>
                                <a>Days</a>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <div style="width: 99%; float: left">
                    <div style="width: 50%; float: left">
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl">
                                <a>Calendar Type</a>
                            </div>
                            <div>
                                <div style="width: 50%; float: left">
                                    <a>
                                        <asp:RadioButton GroupName="CalendarType" ID="rdoEmployee" runat="server" Text="Employee"
                                            Checked="true" />
                                    </a>
                                </div>
                                <div style="width: 50%; float: left">
                                    <a>
                                        <asp:RadioButton GroupName="CalendarType" ID="rdoCompany" runat="server" Text="Company" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="width: 50%; float: left">
                    </div>
                </div>
                <div style="width: 99%; float: left">
                    <div style="width: 50%; float: left">
                        <fieldset style="border-color: #AED0EA; border-width: thin">
                            <legend style="font-size: 12px">Other Settings</legend>
                            <div class="lblAndTxtStyle">
                                <asp:CheckBox ID="chkAllowAdvanceLeave" Text="Allow Advance Leave" CssClass="fieldset-legend"
                                    runat="server" />
                            </div>
                            <div class="lblAndTxtStyle">
                                <asp:CheckBox ID="chkAllowPreecedingHW" Text="Allow only Preeceding Holiday/Weekend" CssClass="fieldset-legend"
                                    runat="server" />
                            </div>
                            <div class="lblAndTxtStyle">
                                <asp:CheckBox ID="chkAllowSucceedingHW" Text="Allow only Succeeding Holiday/Weekend" CssClass="fieldset-legend"
                                    runat="server" />
                            </div>
                             <div class="lblAndTxtStyle">
                                <asp:CheckBox ID="chkBothSideLeave" Text="Allow Both Side Leave of an Holiday/Weekend" CssClass="fieldset-legend"
                                    runat="server" />
                            </div>
                            <div class="lblAndTxtStyle">
                                <asp:CheckBox ID="chkAllowSandwitch" Text="Allow Sandwitch (Weekend-Leave-Weekend)" CssClass="fieldset-legend"
                                    runat="server" />
                            </div>
                            <div class="lblAndTxtStyle">
                                <asp:CheckBox ID="chkAllowHourlyLeave" Text="Allow Hourly Leave" CssClass="fieldset-legend"
                                    runat="server" />
                            </div>
                            <div class="lblAndTxtStyle chkAdjustfromtotalLVBalance" style="display: none">
                                <asp:CheckBox ID="chkAdjustfromtotalLVBalance" Text="Adjust from total LV Balance"
                                    CssClass="fieldset-legend" runat="server" />
                            </div>
                            <div class="lblAndTxtStyle txtHours" style="display: none">
                                <div style="float: left">
                                    <a>Every </a>
                                </div>
                                <div style="float: left; margin-left: 5px">
                                    <asp:TextBox ID="txtHours" runat="server" Style="width: 50%;" onkeypress="return isNumberKey(event)"
                                        MaxLength="5"></asp:TextBox>
                                </div>
                                <div style="float: left">
                                    <a>hours treat as 1 day leave</a></div>
                            </div>
                        </fieldset>
                    </div>
                    <div style="width: 50%; float: left">
                        <fieldset style="border-color: #AED0EA; border-width: thin">
                            <legend style="font-size: 12px">
                                <asp:CheckBox ID="chkLeaveCarryForword" Text="Leave Carry Forword" CssClass="fieldset-legend"
                                    runat="server" /></legend>
                            <div class="lblAndTxtStyle">
                                <a>Yearly Max Days</a>
                                <asp:TextBox ID="txtYearlyMaxDays" runat="server" CssClass="txtwidth93px" MaxLength="100"
                                    onkeypress="return isNumberKey(event)" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="lblAndTxtStyle">
                                <a>Max Accumulation</a>
                                <asp:TextBox ID="txtMaxAccumulation" runat="server" CssClass="txtwidth93px" MaxLength="100"
                                    onkeypress="return isNumberKey(event)" Enabled="false"></asp:TextBox>
                            </div>
                            <asp:CheckBox ID="chkConsicutiveLimit" Text="Consicutive Limit" runat="server" />
                            <div class="lblAndTxtStyle">
                                <a>Days</a>
                                <asp:TextBox ID="txtDays" runat="server" CssClass="txtwidth93px" MaxLength="100"
                                    onkeypress="return isNumberKey(event)" Enabled="false"></asp:TextBox>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <br />
        <br />
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save"
                    OnClick="btnSave_Click" OnClientClick="CheckValidity();" />
                &nbsp;&nbsp;
                <asp:Button ID="btnClear" runat="server" CssClass="button" Text="Cancel" OnClick="btnClear_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClick="btnDelete_Click"
                    Visible="true" OnClientClick="return confirm('Are you sure you want to delete this record?')" />
            </div>
        </div>
    </div>
    <script>
        $(function () {
            if (isPostBack)
                $(".form-wrapper select, .form-wrapper input:not(.btn-enable)").attr('disabled', true);
        })
        function enableControl() {
            $(".form-wrapper input, .form-wrapper select").removeAttr('disabled');
        }
    </script>
</asp:Content>
