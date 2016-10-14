<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="MaternityLeavePolicy.aspx.cs" Inherits="Hr.Web.UI.LeaveManagement.MaternityLeavePolicy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 50%; float: left">
                <div id="divMaternityLeave" class="GroupBoxContainer" style="margin: 0px;">
                    <div class="GroupBoxTitlebar">
                        <span class="TitlebarCaption">Maternity Leave Rule Define:</span>
                    </div>
                    <div style="margin-left: 5px">
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px" style="width: 20%">
                                <a>Rule Code</a>
                            </div>
                            <div class="div80Px">
                                <asp:DropDownList ID="ddlMaternityLeaveRuleKey" runat="server" Style="visibility: visible;"
                                    CssClass="drpwidth157px" AutoPostBack="true">
                                </asp:DropDownList>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtMaternityLeaveRule" runat="server" Style="visibility: hidden;"
                                        CssClass="txtwidth155px">
                                    </asp:TextBox>
                                </div>
                                <div>
                                    <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle " ImageUrl="~/images/new 20X20.png" />
                                    <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" />
                                </div>
                            </div>
                        </div>
                        <div>
                            <a>Address</a>
                            <asp:TextBox ID="txtPAddress" runat="server" CssClass="txtwidth178px allowEnter"
                                MaxLength="100" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div>
                            <div style="float: left; width: 33%">
                                <div>
                                    <a>.</a></div>
                                <div>
                                    <a>No Of Benefit</a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtNoOfBenefit" runat="server" CssClass="txtwidth155px">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div style="float: left; width: 33%">
                                <div>
                                    <a>.</a></div>
                                <div>
                                    <a>Total Days For Benefit</a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtTotalDaysForBenefit" runat="server" CssClass="txtwidth155px">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div style="float: left; width: 33%">
                                <div>
                                    <a>Min Days Gap Beteen </a>
                                </div>
                                <div>
                                    <a>two Benefit(if more than one)</a></div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtMinDaysGap" runat="server" CssClass="txtwidth155px">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div>
                            <div style="float: left; width: 18%;">
                                <div>
                                    <a>Benefit Days </a>
                                </div>
                                <div>
                                    <a>before EDD</a></div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtBenefitDaysBeforeEDD" runat="server" CssClass="txtwidth155px"
                                        Width="100%">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div style="float: left; width: 18%;">
                                <div>
                                    <a>Benefit Days </a>
                                </div>
                                <div>
                                    <a>after EDD</a></div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtBenefitDaysAfterEDD" runat="server" CssClass="txtwidth155px"
                                        Width="100%">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div style="float: left; width: 25%">
                                <div>
                                    <a>. </a>
                                </div>
                                <div>
                                    <a>Depends On</a></div>
                                <div class="div80Px">
                                    <asp:DropDownList ID="ddlDependsOn" runat="server" CssClass="drpwidth157px" Width="100%">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div style="float: left; width: 18%;">
                                <div>
                                    <a>.</a>
                                </div>
                                <div>
                                    <a>Calculated From</a></div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtCalculatedFrom" runat="server" CssClass="txtwidth155px" Width="100%">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div style="float: left; width: 20%;">
                                <div class="lblAndTxtStyle">
                                    <div>
                                        <a>.</a></div>
                                    <div class="div80Px">
                                        <div style="width: 100%; float: left">
                                            <a>
                                                <asp:RadioButton GroupName="CalculateFrom" ID="rdoYear" runat="server" Text="Year"
                                                    Checked="true" />
                                            </a>
                                        </div>
                                        <%--                                        <div style="width: 50%; float: left">--%>
                                        <a>
                                            <asp:RadioButton GroupName="CalculateFrom" ID="rdoMonth" runat="server" Text="Month" />
                                        </a>
                                        <%--                                        </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="div2" class="GroupBoxContainer" style="margin: 0px;">
                    <div class="GroupBoxTitlebar">
                        <span class="TitlebarCaption"></span>
                    </div>
                    <div>
                        <div style="float: left; width: 40%">
                            <div>
                                <a>Calculation Based On No Of Month</a></div>
                            <div>
                                <a>(0 Means depend on current salary)</a></div>
                        </div>
                        <div style="float: left; width: 20%">
                            <div class="div80Px">
                                <asp:TextBox ID="txtCalculationBasedOn" runat="server" CssClass="txtwidth155px" Width="100%">
                                </asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div style="width: 100%">
                        <div>
                            <a>.</a></div>
                        <div style="width: 50%">
                            <a>Consider Transaction Month(if yes check it)<asp:CheckBox ID="chkTransactionMonth"
                                Text="" runat="server" /></a>
                        </div>
                    </div>
                    <div style="width: 100%">
                        <div>
                            <a>.</a></div>
                        <div style="width: 50%">
                            <a>Consider Selected Months:</a>
                        </div>
                        <div>
                            <div style="float: left; width: 33%">
                                <a>
                                    <asp:RadioButton GroupName="SelectedMonth" ID="rdoSpecificHead" runat="server" Text="Specific Head"
                                        Checked="true" />
                                </a>
                            </div>
                            <div style="float: left; width: 33%">
                                <a>
                                    <asp:RadioButton GroupName="SelectedMonth" ID="rdoPaymentWithOT" runat="server" Text="Payment with OT" />
                                </a>
                            </div>
                            <div style="float: left; width: 33%">
                                <a>
                                    <asp:RadioButton GroupName="SelectedMonth" ID="rdoPaymentWithoutOT" runat="server"
                                        Text="Payment Without OT" />
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="div3" class="GroupBoxContainer" style="margin: 0px;">
                    <div class="GroupBoxTitlebar">
                        <span class="TitlebarCaption">Depends On</span>
                    </div>
                    <div style="float: left; width: 33%">
                        <a>
                            <asp:RadioButton GroupName="DependsOn" ID="rdoPresentDays" runat="server" Text="Preent Days"
                                Checked="true" />
                        </a>
                    </div>
                    <div style="float: left; width: 33%">
                        <a>
                            <asp:RadioButton GroupName="DependsOn" ID="rdoCurrentDays" runat="server" Text="Calendar Day" />
                        </a>
                    </div>
                    <div style="clear: both">
                    </div>
                    <div>
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
                    <div style="clear: both">
                    </div>
                    <a>
                        <asp:CheckBox ID="chkEDDInApproved" Text="Consider EDD In Approved" runat="server" />
                    </a><a>
                        <asp:CheckBox ID="chkSalaryHeadForCalculation" Text="Would like to define salary head for calculation"
                            runat="server" />
                    </a>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px" style="width: 20%">
                            <a>Reporting Head</a>
                        </div>
                        <div class="div80Px">
                            <asp:DropDownList ID="ddlReportingHead" runat="server" CssClass="drpwidth157px">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="width: 35%; float: left">
            <div id="div1" class="GroupBoxContainer" style="height: 300px">
                <div class="GroupBoxTitlebar">
                    <span class="TitlebarCaption">Payment Definition:</span>
                </div>
                <div style="float: left; width: 33%">
                    <a>
                        <asp:RadioButton GroupName="PaymentDefinition" ID="rdoFixed" runat="server" Text="Fixed"
                            Checked="true" />
                    </a>
                </div>
                <div style="float: left; width: 33%">
                    <a>
                        <asp:RadioButton GroupName="PaymentDefinition" ID="rdoPercentage" runat="server"
                            Text="Percentage" />
                    </a>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px" style="width: 20%">
                        <a>Head</a>
                    </div>
                    <div class="div80Px">
                        <asp:DropDownList ID="ddlHead" runat="server" CssClass="drpwidth157px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px" style="width: 20%">
                        <a>Amount</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="txtwidth155px" Width="68%">
                        </asp:TextBox>
                    </div>
                </div>
                <div style="width: 100%; text-align: center; margin-top: 200px">
                    <asp:Button ID="btnClear" runat="server" CssClass="button" Text="Clear" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnPolicy" runat="server" CssClass="button" Text="Policy" />
                </div>
            </div>
        </div>
        <div style="width: 35%; float: left">
            <div id="div4" class="GroupBoxContainer" style="height: 165px">
                <div class="GroupBoxTitlebar">
                    <span class="TitlebarCaption">Defined Policy:</span>
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save" />
                &nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" />
                &nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" Visible="true"
                    OnClientClick="return confirm('Are you sure you want to delete this record?')" />
            </div>
        </div>
    </div>
</asp:Content>
