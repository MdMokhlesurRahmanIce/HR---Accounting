<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="SalaryInfoEntry.aspx.cs" Inherits="Hr.Web.UI.Payroll.SalaryInfoEntry" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmpList.ascx" TagName="ucEmpList" TagPrefix="asl" %>
<%@ Register Src="~/Controls/ucSalaryFormulaCalculation.ascx" TagName="ucSalaryFormula"
    TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#cphBody_cphInfbody_btnView").click(function (e) {
                var spName = "spGetEmpForSalaryEntry";
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllEmpForCalendar&SpName=' + spName,
                    	                async: false
                    	            }
                                ).responseText
                $("#grdCalendar").trigger("reloadGrid");
                return false;
            });
            $("#cphBody_cphInfbody_ctrlSalaryFormula_btnCalculate").click(function (e) {
                var salaryRuleCode = $("#cphBody_cphInfbody_ctrlSalaryFormula_ddlSalaryRule").val();
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
            $("#cphBody_cphInfbody_ctrlSalaryFormula_ddlSalaryRule").change(function () {
                var salaryRuleCode = $("#cphBody_cphInfbody_ctrlSalaryFormula_ddlSalaryRule").val();
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 28%; float: left">
                <asl:ucEmployeeSearch ID="ctrlEmpSearchSalaryInfoEntry" runat="server"></asl:ucEmployeeSearch>
                <div style="float: right; text-align: center">
                    <asp:Button ID="btnView" runat="server" CssClass="button" Text="View" />
                </div>
            </div>
            <div style="width: 42%; float: left">
                <asl:ucEmpList ID="ctrlEmpList" runat="server"></asl:ucEmpList>
            </div>
            <div style="width: 28%; float: left; margin-left: 15px">
                <div id="Div1" style="width: 99%; height: auto; float: left; display:none">
                    <div style="width: 40%; height: auto; float: left">
                        <fieldset id="garmentPicture" style="margin-left: 0px; height: 130px; width: 100px">
                            <div style="width: 100px; height: 130px">
                                <asp:Image ID="imgGarment" runat="server" Alt="" Height="130px" Width="100px" />
                            </div>
                            <div class="totalDiv">
                                <asp:Label ID="lblPictureNumber" CssClass="lblStyle" Style="padding-left: 55px" runat="server"></asp:Label>
                            </div>
                        </fieldset>
                    </div>
                    <div style="width: 60%; height: auto; float: left">
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl" style="float: left; width: 40%">
                                <a>Name</a>
                            </div>
                            
                            <div style="float: left; width: 50%">
                                <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl" style="float: left; width: 40%">
                                <a>Designation</a>
                            </div>
                            <div style="float: left; width: 50%">
                                <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl" style="float: left; width: 40%">
                                <a>Staff Category</a>
                            </div>
                            <div style="float: left; width: 50%">
                                <asp:TextBox ID="txtStaffCategory" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl" style="float: left; width: 40%">
                                <a>DOJ</a>
                            </div>
                            <div style="float: left; width: 50%">
                                <asp:TextBox ID="txtDOJ" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl" style="float: left; width: 40%">
                                <a>Leave Rule</a>
                            </div>
                            <div style="float: left; width: 50%">
                                <asp:TextBox ID="txtLeaveRule" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <asl:ucSalaryFormula ID="ctrlSalaryFormula" runat="server"></asl:ucSalaryFormula>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" />
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
                <%--                <div style="float: left; margin: 10px 0px 0px 15px">
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
                </div>--%>
            </div>
        </div>
    </div>
</asp:Content>
