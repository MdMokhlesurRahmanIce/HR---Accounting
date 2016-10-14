<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="EmployeeInfoComonApproval.aspx.cs" Inherits="Hr.Web.UI.EmployeeBasicInfo.EmployeeInfoComonApproval" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="empSearch" TagPrefix="ast" %>
<%@ Register Src="~/Controls/EmpList.ascx" TagName="ucEmpList" TagPrefix="ast" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/GridScripts/EmpRelatedApproval.js" ) %>" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= chkEmp.ClientID %>").click(function (e) {
                var status = $(this).is(':checked');
                var sessionVarName = "EmployeeInfoComonApproval_EmpList";
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllSelectOrAllClearEmp&Status=' + status + '&SessionVarName=' + sessionVarName,
                        async: false
                    }
                ).responseText
                $("#grdEmpRelatedApproval").trigger("reloadGrid");
            });

            $("input[id$='txtFromDate']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), maxDate: 0, dateFormat: 'mm/dd/yy' });
            $("input[id$='txtToDate']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), maxDate: 0, dateFormat: 'mm/dd/yy' });
            $("#cphBody_cphInfbody_btnView").click(function (e) {
                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                var selectionCritaria = $("#cphBody_cphInfbody_ddlApprovalList").val();
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowEmpRelatedApproval&FromDate=' + fromDate + '&ToDate=' + toDate + '&SelectionCritaria=' + selectionCritaria,
                    	                async: false
                    	            }
                                ).responseText
                $("#grdEmpRelatedApproval").trigger("reloadGrid");
                if (selectionCritaria == "1") {
                    jQuery("#grdEmpRelatedApproval").jqGrid('hideCol', ["DOS"]);
                    jQuery("#grdEmpRelatedApproval").jqGrid('hideCol', ["SeparationAction"]);
                    jQuery("#grdEmpRelatedApproval").jqGrid('hideCol', ["SeparationCause"]);
                    jQuery("#grdEmpRelatedApproval").jqGrid('hideCol', ["OfficialRemarks"]);
                    jQuery("#grdEmpRelatedApproval").jqGrid('hideCol', ["RejoiningDate"]);
                }
                else {
                    jQuery("#grdEmpRelatedApproval").jqGrid('showCol', ["DOS"]);
                    jQuery("#grdEmpRelatedApproval").jqGrid('showCol', ["SeparationAction"]);
                    jQuery("#grdEmpRelatedApproval").jqGrid('showCol', ["SeparationCause"]);
                    jQuery("#grdEmpRelatedApproval").jqGrid('showCol', ["OfficialRemarks"]);
                    jQuery("#grdEmpRelatedApproval").jqGrid('hideCol', ["RejoiningDate"]);
                }
                if (selectionCritaria == "2") {
                    jQuery("#grdEmpRelatedApproval").jqGrid('showCol', ["RejoiningDate"]);
                }
                return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 30%; float: left">
                <div class="lblAndTxtStyle" style="width: 99%; float: left">
                    <div class="divlblwidth100px bglbl">
                        <a>From Date</a>
                    </div>
                    <div class="div80Px" style="width: 52%; float: left;">
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="drpwidth180px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle" style="width: 99%; float: left">
                    <div class="divlblwidth100px bglbl">
                        <a>To Date</a>
                    </div>
                    <div class="div80Px" style="width: 52%; float: left;">
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="drpwidth180px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div style="height: auto">
                    <ast:empSearch ID="ucEmployeeSearch" runat="server"></ast:empSearch>
                </div>
                <div class="btnRight" style="float: right; padding-right: 20px">
                    <asp:Button ID="btnView" runat="server" CssClass="button" Text="View" />
                </div>
            </div>
            <div style="width: 69%; float: left">
                <div class="lblAndTxtStyle" style="width: 100%; float: left">
                   
                    <div style="width: 99%; float: left">
                        <div class="div182Px" style="width: 40%; float: left">
                            <asp:DropDownList ID="ddlApprovalList" runat="server"  CssClass="drpwidth180px">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div>
                    <div>
                        <table id="grdEmpRelatedApproval">
                        </table>
                    </div>
                    <div id="grdEmpRelatedApproval_pager">
                    </div>
                </div>
                <div style="margin-left: 0px; text-align: left; vertical-align: middle;">
                    <span class="lblStyle">Select All</span>
                    <asp:CheckBox ID="chkEmp" CssClass="selectAll" Text="" runat="server" />
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight"">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
