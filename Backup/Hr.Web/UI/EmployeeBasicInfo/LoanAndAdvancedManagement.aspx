<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="LoanAndAdvancedManagement.aspx.cs" Inherits="Hr.Web.UI.EmployeeBasicInfo.LoanAndAdvancedManagement" %>

<%@ Register Src="~/Controls/SearchEmployee.ascx" TagName="empSearch2" TagPrefix="gm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <style type="text/css">
        .modal
        {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
        .loading
        {
            font-family: Arial;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
    </style>
    <script src="<%= ResolveUrl("~/gridscripts/Loan_EmpList.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/LoanProcess.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        var $tabs;
        var selectedtab;
        $(function () {
            $tabs = $("#divTab").tabs();
            $tabs.tabs('select', selectedtab);
        });
        $(document).ready(function () {
            $("input[id$='txtFirstInstallmentDate']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), maxDate: 0, dateFormat: 'mm/dd/yy' });
            if ($("#cphBody_cphInfbody_txtInterestRate").val() == "") {
                $("#interest").hide();
                $("#cphBody_cphInfbody_txtInterestCollectionInsNo").attr("disabled", true);
            }
            else {
                $("#interest").show();
                $("#cphBody_cphInfbody_txtInterestCollectionInsNo").attr("disabled", false);
            }
            $('#cphBody_cphInfbody_txtSearch').keyup(function (event) {
                var searchString = $(this).val();
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=SearchEmpList&SearchString=' + searchString,
                        async: false
                    }
                ).responseText;
                $("#grdEmployeeList").trigger("reloadGrid");
                var _empCode = $(this).val();
                employeeIdKeyup(event, _empCode);
            });
            $("#cphBody_cphInfbody_ddlLoanOrAdvanceReadjustment").change(function (e) {
                if ($(this).val() == "6") {
                    $(".amount").show();
                }
                else {
                    $(".amount").hide();
                }
            });
            $("#cphBody_cphInfbody_btnDefine").click(function (e) {
                var installment = "0";
                var monthly = "0";
                var amt = $("#cphBody_cphInfbody_txtCanctionAmount").val();
                var firstInstallmentDate = $("#cphBody_cphInfbody_txtFirstInstallmentDate").val();
                var monthInterval = $("#cphBody_cphInfbody_txtMonthInterval").val();
                var installmentOrAmount = $("#cphBody_cphInfbody_txtInstallmentOrMonthlyAmount").val();
                if ($("#cphBody_cphInfbody_rdoNoOfInstallment").is(":checked"))
                    installment = "1";
                if ($("#cphBody_cphInfbody_rdoMonthlyAmount").is(":checked"))
                    monthly = "1";
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=LoanDefination&Amt=' + amt + '&FirstInstallmentDate=' + firstInstallmentDate + '&MonthInterval=' + monthInterval + '&InstallmentOrAmount=' + installmentOrAmount + '&Installment=' + installment + '&Monthly=' + monthly,
                        async: false
                    }
                ).responseText;
                $("#grdLoanProcess").trigger("reloadGrid");
                return false
            });
        });
        function InterestRate() {
            if ($("#cphBody_cphInfbody_txtInterestRate").val() == "") {
                $("#interest").hide();
                $("#cphBody_cphInfbody_txtInterestCollectionInsNo").attr("disabled", true);
            }
            else {
                $("#interest").show();
                $("#cphBody_cphInfbody_txtInterestCollectionInsNo").attr("disabled", false);
            }
        }
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Loan And Advance Adjustment"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 23%; float: left; padding-right: 10px">
                <div>
                    <div style="float: left; width: 80%">
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="txtwidth178px" Width="95%" MaxLength="100"
                            AutoCompleteType="None"></asp:TextBox>
                    </div>
                    <div style="float: left; margin-left: 5px;">
                        <asp:ImageButton ID="btnNew1" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png" />
                        <asp:ImageButton ID="btnFind1" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" />
                    </div>
                    <div style="clear: both">
                    </div>
                    <div>
                        <div>
                            <table id="grdEmployeeList">
                            </table>
                        </div>
                        <div id="grdEmployee_pager">
                        </div>
                    </div>
                </div>
                <%--<gm:empSearch2 ID="ctrlEmpSearch2" runat="server"></gm:empSearch2>--%>
            </div>
            <div id="divTab" style="width: 75%; float: left; padding-bottom: 10px;" onclick="return divTab_onclick()">
                <ul>
                    <li><a href="#tabCommonInfoAndAdvanced">Common Info And Advance</a></li>
                    <li><a href="#tabAdvanceAdjustment">Advance Adjustment</a></li>
                </ul>
                <div id="tabCommonInfoAndAdvanced">
                    <div style="width: 40%; float: left">
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Loan/Adv. Code</a>
                            </div>
                            <div class="div80Px">
                                <div style="float: left; width: 70%">
                                    <asp:TextBox ID="txtLoanOrAdvanceCode" runat="server" CssClass="txtwidth178px" ReadOnly="true"
                                        MaxLength="100"></asp:TextBox>
                                </div>
                                <div style="float: left; margin-left: 5px;">
                                    <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png"
                                        OnClick="btnNew_Click" />
                                    <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png"
                                        OnClick="btnFind_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Loan Type</a>
                            </div>
                            <div class="div182Px">
                                <asp:DropDownList ID="ddlLoanType" runat="server" CssClass="drpwidth180px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Sanction Amount</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtCanctionAmount" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>First Installment Date</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtFirstInstallmentDate" runat="server" CssClass="txtwidth178px"
                                    MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Interest Rate</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtInterestRate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Reporting Head</a>
                            </div>
                            <div class="div182Px">
                                <asp:DropDownList ID="ddlReportingHead" runat="server" CssClass="drpwidth180px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Month Interval</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtMonthInterval" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div>
                            <div style="float: left; width: 35%">
                                <asp:RadioButton GroupName="Criteria" ID="rdoNoOfInstallment" Font-Size="11px" runat="server"
                                    Text="No Of Installment" Checked="true" />
                            </div>
                            <div style="float: left; width: 32%">
                                <asp:RadioButton GroupName="Criteria" ID="rdoMonthlyAmount" Font-Size="11px" runat="server"
                                    Text="Monthly Amount" />
                            </div>
                            <div class="div80Px" style="width: 31%">
                                <asp:TextBox ID="txtInstallmentOrMonthlyAmount" runat="server" CssClass="txtwidth178px"
                                    MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Interest Col. Ins. No</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtInterestCollectionInsNo" runat="server" CssClass="txtwidth178px"
                                    MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div id="interest">
                            <div style="float: left; width: 50%">
                                <asp:RadioButton GroupName="InterestType" ID="rdoSimpleInterest" Font-Size="11px"
                                    runat="server" Text="Simple Interest" Checked="true" />
                            </div>
                            <div style="float: left; width: 50%">
                                <asp:RadioButton GroupName="InterestType" ID="rdoComplexInterest" Font-Size="11px"
                                    runat="server" Text="Complex Interest" />
                            </div>
                        </div>
                    </div>
                    <div style="width: 40%; float: left">
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Employee Code</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtEmpCode" runat="server" CssClass="txtwidth178px" Enabled="false"
                                    MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Employee Name</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtEmpName" runat="server" CssClass="txtwidth178px" Enabled="false"
                                    MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Nick Name</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtNickName" runat="server" CssClass="txtwidth178px" Enabled="false"
                                    MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Date Of Joining</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtDateOfJoining" runat="server" CssClass="txtwidth178px" Enabled="false"
                                    MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Date Of Conformation</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtDateOfConformation" runat="server" CssClass="txtwidth178px" Enabled="false"
                                    MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Nationality</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtNationality" runat="server" CssClass="txtwidth178px" Enabled="false"
                                    MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Employee Status</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtEmpStatus" runat="server" CssClass="txtwidth178px" Enabled="false"
                                    MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Punch Card No</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtPunchCardNo" runat="server" CssClass="txtwidth178px" Enabled="false"
                                    MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>National ID Card</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtNationalIDCard" runat="server" CssClass="txtwidth178px" Enabled="false"
                                    MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div style="width: 20%; float: left">
                        <fieldset style="border-color: #E8E6DC; border-width: 2px; width: 150px; height: auto;">
                            <legend>Picture</legend>
                            <div style="text-align: center; vertical-align: middle;">
                                <asp:Image ID="imgPicture" runat="server" Style="max-height: 120px; max-width: 150px;" />
                            </div>
                        </fieldset>
                        <div style="margin-left: 50px; margin-top: 60px">
                            <asp:Button ID="btnDefine" runat="server" CssClass="button" Text="Define" />
                        </div>
                    </div>
                </div>
                <div id="tabAdvanceAdjustment">
                    <div style="width: 50%">
                        <div class="lblAndTxtStyle">
                            <div>
                                <a>Loan Or Advance Readjustment</a></div>
                            <div class="div182Px">
                                <asp:DropDownList ID="ddlLoanOrAdvanceReadjustment" runat="server" CssClass="drpwidth180px">
                                    <asp:ListItem Selected="True" Value="0" Text="Selection Criteria"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Adjust With Next"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Adjust Next With Current"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Adjust With Further Installment"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Adjust As a Installment"></asp:ListItem>
                                    <asp:ListItem Value="5" Text="Adjust All With Current"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="In Cash"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle amount" style="display: none">
                            <div>
                                <a>Amount</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtAmount" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div style="clear: both">
                    </div>
                    <div style="width: 96%">
                        <div>
                            <table id="grdLoanProcess">
                            </table>
                        </div>
                        <div id="grdLoanProcess_pager">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <br />
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" Visible="false" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClick="btnDelete_Click" />
            </div>
        </div>
    </div>
    <div class="loading" align="center">
        Loading. Please wait.<br />
        <br />
        <img src="loader.gif" alt="" />
    </div>
</asp:Content>
