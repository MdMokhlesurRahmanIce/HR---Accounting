<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSalaryInfo.ascx.cs"
    Inherits="Hr.Web.Controls.ucSalaryInfo" %>
<%@ Register Src="~/Controls/ucSalaryFormulaCalculation.ascx" TagName="ucSalaryFormula"
    TagPrefix="asl" %>
<script type="text/javascript">
    $(document).ready(function () {
        $("#cphBody_cphInfbody_ctrlSalaryInfo_ctrlSalaryFormula_btnCalculate").click(function (e) {
            var salaryRuleCode = $("#cphBody_cphInfbody_ctrlSalaryInfo_ctrlSalaryFormula_ddlSalaryRule").val();
            var flag = "1";
            var retVal = jQuery.ajax
                                	        (
                                	            {
                                	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=GetAllSalaryRuleCalculateFormula&SalaryRuleCode=' + salaryRuleCode + '&Flag=' + flag,
                                	                async: false
                                	            }
                                            ).responseText
            $("#grdSalaryInfoEntry").trigger("reloadGrid");
            return false;
        });
        $("#cphBody_cphInfbody_ctrlSalaryInfo_ctrlSalaryFormula_ddlSalaryRule").change(function () {
            var salaryRuleCode = $("#cphBody_cphInfbody_ctrlSalaryInfo_ctrlSalaryFormula_ddlSalaryRule").val();
            var retVal = jQuery.ajax
                            (
                                {
                                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=GetAllSalaryRuleCalculateFormula&SalaryRuleCode=' + salaryRuleCode,
                                    async: false
                                }
                            ).responseText
            $("#grdSalaryInfoEntry").trigger("reloadGrid");
            return false;
        });
    });
</script>
<div style="float: left; width: 55%">
    <div style="float: left; width: 80%">
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Bank</a>
            </div>
            <div class="div182Px">
                <asp:DropDownList ID="ddlBank" runat="server" CssClass="drpwidth180px" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Branch</a>
            </div>
            <div class="div182Px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlBank" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Acc No</a>
            </div>
            <div class="div80Px">
                <asp:TextBox ID="txtAccNo" runat="server" CssClass="txtwidth93px" MaxLength="100"></asp:TextBox>
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Phone</a>
            </div>
            <div class="div80Px">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="txtwidth93px" MaxLength="100"></asp:TextBox>
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Contact Person</a>
            </div>
            <div class="div80Px">
                <asp:TextBox ID="txtContactPerson" runat="server" CssClass="txtwidth93px" MaxLength="100"></asp:TextBox>
            </div>
        </div>
    </div>
</div>
<div style="float: left; width: 45%;">
    <asl:ucSalaryFormula ID="ctrlSalaryFormula" runat="server"></asl:ucSalaryFormula>
</div>
