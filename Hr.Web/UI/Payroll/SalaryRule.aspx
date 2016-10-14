<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="SalaryRule.aspx.cs" Inherits="Hr.Web.UI.Payroll.SalaryRule" %>

<%@ Register Src="~/Controls/BasedOnSalaryCalculation.ascx" TagName="ucBasedOnSalaryCalculation"
    TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/SalaryRule.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            ControlEvents()
        });
        function ControlEvents() {

            $('#<%= txtApprovalDate.ClientID %>').attr("disabled", true);
            $('#<%= txtApproveBy_nc.ClientID %>').attr("disabled", true);
            $("input[id$='txtApprovalDate']").datepicker({
                showButtonPanel: true,
                changeMonth: true,
                changeYear: true
            });
            $("#cphBody_cphInfbody_ucSalaryRule_rdoFormula").click(function (e) {
                var salaryHead = $("#cphBody_cphInfbody_ucSalaryRule_ddlSalaryHead option:selected").text();
                if (salaryHead == "") {
                    ShowMessageBox("HR", "Salary head is required.");
                    return false;
                }
                salaryHead = salaryHead + " = ";
                $("#cphBody_cphInfbody_ucSalaryRule_txtFormulaEditor").val(salaryHead);
            });
            $("#cphBody_cphInfbody_ucSalaryRule_rdoPartial").click(function (e) {
                var salaryHead = $("#cphBody_cphInfbody_ucSalaryRule_ddlSalaryHead option:selected").text();
                if (salaryHead == "") {
                    ShowMessageBox("HR", "Salary head is required.");
                    return false;
                }
            });
            $("#cphBody_cphInfbody_ucSalaryRule_rdoPercentage").click(function (e) {
                var salaryHead = $("#cphBody_cphInfbody_ucSalaryRule_ddlSalaryHead option:selected").text();
                if (salaryHead == "") {
                    ShowMessageBox("HR", "Salary head is required.");
                    return false;
                }
            });
            $("#cphBody_cphInfbody_ucSalaryRule_rdoFixed").click(function (e) {
                var salaryHead = $("#cphBody_cphInfbody_ucSalaryRule_ddlSalaryHead option:selected").text();
                if (salaryHead == "") {
                    ShowMessageBox("HR", "Salary head is required.");
                    return false;
                }
            });
            $("#cphBody_cphInfbody_ucSalaryRule_ddlSalaryHead").change(function () {
                if ($("#cphBody_cphInfbody_ucSalaryRule_rdoFormula").is(":checked")) {
                    var salaryHead = $("#cphBody_cphInfbody_ucSalaryRule_ddlSalaryHead option:selected").text();
                    salaryHead = salaryHead + " = ";
                    $("#cphBody_cphInfbody_ucSalaryRule_txtFormulaEditor").val(salaryHead);
                }
                $(".tmp5").show();
                $(".tmp6").show();
            });
            $("#cphBody_cphInfbody_ucSalaryRule_ddlParentHead").change(function () {
                if ($("#cphBody_cphInfbody_ucSalaryRule_rdoFormula").is(":checked")) {
                    var salaryHead = $("#cphBody_cphInfbody_ucSalaryRule_ddlParentHead option:selected").text();
                    var formula = $("#cphBody_cphInfbody_ucSalaryRule_txtFormulaEditor").val();
                    formula = formula + "@" + salaryHead + "@";
                    $("#cphBody_cphInfbody_ucSalaryRule_txtFormulaEditor").val(formula);
                }
            });
            $("#cphBody_cphInfbody_btnDefine").click(function (e) {
                var strValue = "";
                var salaryHead = $("#cphBody_cphInfbody_ucSalaryRule_ddlSalaryHead").val();
                if (salaryHead == "") {
                    ShowMessageBox("HR", "Salary head is required.");
                    return false;
                }
                var isFixed = $("#cphBody_cphInfbody_ucSalaryRule_rdoFixed1").is(":checked");

                if ($("#cphBody_cphInfbody_ucSalaryRule_rdoFixed").is(":checked")) {
                    var amount = $("#cphBody_cphInfbody_ucSalaryRule_txtParentHeadAmount").val();
                    if (amount == "") {
                        ShowMessageBox("HR", "Amount is required.");
                        return false;
                    }
                    strValue = "Fixed," + salaryHead + "," + isFixed + "," + amount;
                }

                if ($("#cphBody_cphInfbody_ucSalaryRule_rdoPercentage").is(":checked")) {

                    var amount = $("#cphBody_cphInfbody_ucSalaryRule_txtParentHeadAmount").val();
                    var parentHead = $("#cphBody_cphInfbody_ucSalaryRule_ddlParentHead option:selected").text();
                    if (amount == "") {
                        ShowMessageBox("HR", "Amount is required.");
                        return false;
                    }
                    if (parentHead == "") {
                        ShowMessageBox("HR", "Parent head is required.");
                        return false;
                    }
                    strValue = "Percentage," + salaryHead + "," + isFixed + "," + amount + "," + parentHead;
                }

                if ($("#cphBody_cphInfbody_ucSalaryRule_rdoPartial").is(":checked")) {

                    var amount = $("#cphBody_cphInfbody_ucSalaryRule_txtParentHeadAmount").val();
                    var parentHead = $("#cphBody_cphInfbody_ucSalaryRule_ddlParentHead option:selected").text();
                    var partialHead = $("#cphBody_cphInfbody_ucSalaryRule_ddlPartialHead option:selected").text();
                    var partialHeadValue = $("#cphBody_cphInfbody_ucSalaryRule_txtPartialHeadValue").val();
                    var isHigher = $("#cphBody_cphInfbody_ucSalaryRule_rdoHigher").is(":checked")
                    if (amount == "") {
                        ShowMessageBox("HR", "Amount is required.");
                        return false;
                    }
                    if (parentHead == "") {
                        ShowMessageBox("HR", "Parent head is required.");
                        return false;
                    }
                    if (partialHeadValue == "") {
                        ShowMessageBox("HR", "Partail head amount is required.");
                        return false;
                    }
                    strValue = "Partial," + salaryHead + "," + isFixed + "," + amount + "," + parentHead + "," + partialHead + "," + partialHeadValue + "," + isHigher;
                }

                if ($("#cphBody_cphInfbody_ucSalaryRule_rdoFormula").is(":checked")) {

                    var formula = $("#cphBody_cphInfbody_ucSalaryRule_txtFormulaEditor").val();
                    if (formula == "") {
                        ShowMessageBox("HR", "Please Create Formula.");
                        return false;
                    }
                    strValue = "Formula," + salaryHead + "," + isFixed + "," + formula;
                }
                strValue = strValue.replace("+", "%2B");
                var retVal = jQuery.ajax
                        (
                            {
                                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=SalaryRule&StrValue=' + strValue,
                                async: false
                            }
                       ).responseText
                $("#grdSalaryRule").trigger("reloadGrid");
                $(".tmp5").hide();
                $(".tmp6").hide();
                $("#cphBody_cphInfbody_ucSalaryRule_ddlSalaryHead").val("");
                return false;
            });
        }
        function toggleapproveclick(ctrl) {
            $('#<%= txtApprovalDate.ClientID %>').attr("disabled", !ctrl.checked);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
<%--        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Salary Rule"></asp:Label>
        </div>--%>
        <div class="form-details">
            <div style="width: 34%; float: left; background-color: #EBE9ED; border: 1px solid rgb(215, 215, 215);
                overflow: auto">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Salary Rule ID</a>
                    </div>
                    <div class="div80Px">
                        <div style="float: left; width: 80%">
                            <asp:TextBox ID="txtSalaryRuleID" runat="server" CssClass="txtwidth178px" ReadOnly="true"
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
                <asl:ucBasedOnSalaryCalculation ID="ucSalaryRule" runat="server"></asl:ucBasedOnSalaryCalculation>
                <div style="clear: both">
                </div>
                <br />
                <div style="text-align: center">
                    <asp:Button ID="btnDefine" runat="server" CssClass="button" Text="Define" />
                </div>
                <br />
            </div>
            <div style="width: 65%; float: left; margin-left: 5px">
                <div>
                    <table id="grdSalaryRule">
                    </table>
                </div>
                <div id="grdSalaryRule_pager">
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClick="btnDelete_Click"
                    OnClientClick="return confirm('Are you sure you want to delete this record?')" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save"
                    OnClick="btnSave_Click" />
            </div>
            <div>
                <div style="float: left; margin: 6px 0px 0px 0px">
                    <asp:CheckBox ID="chkApproved" runat="server" Text="Approved" CssClass="cbStyle"
                        onclick="toggleapproveclick(this);" />
                </div>
                <div style="float: left; margin: 10px 0px 0px 15px">
                    <a>Approval Date</a>
                </div>
                <div style="float: left; margin: 6px 0px 0px 6px">
                    <asp:TextBox ID="txtApprovalDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                </div>
                <div style="float: left; margin: 10px 0px 0px 15px">
                    <a>Approve By</a>
                </div>
                <div style="float: left; margin: 6px 0px 0px 6px">
                    <asp:TextBox ID="txtApproveBy_nc" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
