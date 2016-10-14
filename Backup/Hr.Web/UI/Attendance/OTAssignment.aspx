<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="OTAssignment.aspx.cs" Inherits="Hr.Web.UI.Attendance.OTAssignment" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmpList.ascx" TagName="ucEmpList" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#cphBody_cphInfbody_btnView").click(function (e) {
                var spName = "spGetEmpForSearch1";
                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllEmpForCalendar&SpName=' + spName + '&FromDate='+fromDate + '&ToDate=' + toDate,
                    	                async: false
                    	            }
                                ).responseText
                $("#grdCalendar").trigger("reloadGrid");
                return false;
            });
            $(document).ready(function () {
                $("input[id$='txtFromDate'], .datepicker").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), dateFormat: 'dd/mm/yy' });
            });
            $("#cphBody_cphInfbody_btnSave").click(function (e) {
                var OTType = $("#cphBody_cphInfbody_ddlAssignOTType").val();
                var OTHour = $("#cphBody_cphInfbody_txtOTHour").val();
                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                var chkAssignOT = $("#cphBody_cphInfbody_chkAssignOT").is(":checked");
                var chkPunchOT = $("#cphBody_cphInfbody_chkPunchOT").is(":checked");
                var isLower = $("#cphBody_cphInfbody_rdoLower").is(":checked");
                var isHigher = $("#cphBody_cphInfbody_rdoHigher").is(":checked");
                if (fromDate == "") {
                    ShowMessageBox("HR", "Please select from date!");
                    return false;
                }
                if (toDate == "") {
                    ShowMessageBox("HR", "Please select to date!");
                    return false;
                }
                if (OTType == "") {
                    ShowMessageBox("HR", "Please select day type!");
                    return false;
                }
                jQuery.ajax
                            (
                                {
                                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=SaveEmpListWithAssignOT&OTType=' + OTType + '&OTHour=' + OTHour + '&FromDate=' + fromDate + '&ToDate=' + toDate + '&chkAssignOT=' + chkAssignOT + '&chkPunchOT=' + chkPunchOT + '&isLower=' + isLower + '&isHigher=' + isHigher,
                                    async: false,
                                    success: function () { ShowMessageBox('Successful', 'Process save completed successfully.') },
                                    error: function (xhr, status, error) {
                                        ShowMessageBox('Error', xhr.responseText);
                                    }
                                }
                            );
                return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 28%; float: left">
                <div class="lblAndTxtStyle" style="margin-left: -4px">
                    <div class="divlblwidth100px bglbl">
                        <a>From Date</a>
                    </div>
                    <div class="div80Px" style="width: 59%">
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle" style="margin-left: -4px">
                    <div class="divlblwidth100px bglbl">
                        <a>To Date</a>
                    </div>
                    <div class="div80Px" style="width: 59%">
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="txtwidth178px datepicker" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <asl:ucEmployeeSearch ID="ctrlEmpSearchOTAssignment" runat="server"></asl:ucEmployeeSearch>
                <div style=" float: right; text-align: center">
                    <asp:Button ID="btnView" runat="server" CssClass="button" Text="View" />
                </div>
            </div>
            <div style="width: 70%; float: left">
                <div>
                    <div style="width: 40%; float: left">
                        <fieldset class="fieldset-panel">
                            <legend class="fieldset-legend">Assign Type</legend>
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth100px bglbl">
                                    <a>OT Assign Type</a>
                                </div>
                                <div class="div182Px">
                                    <asp:DropDownList ID="ddlAssignOTType" runat="server" CssClass="drpwidth180px" Width="91%">
                                        <asp:ListItem Value="0" Text="Total OT" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Extra OT"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth100px bglbl">
                                    <a>OT Hour</a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtOTHour" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div style="width: 50%; float: left;">
                        <fieldset class="fieldset-panel">
                            <legend class="fieldset-legend">Policy Settings</legend>
                            <div class="lblAndTxtStyle">
                                <a>
                                    <asp:RadioButton GroupName="OTPriority" ID="rdoOnlyAssignOT" CssClass="fieldset-legend"
                                        runat="server" Text="Consider Only Assign OT" Checked="true" />
                                </a>
                            </div>
                            <div class="lblAndTxtStyle">
                                <a>
                                    <asp:RadioButton GroupName="OTPriority" ID="rdoOnlyPunchOT" CssClass="fieldset-legend"
                                        runat="server" Text="Consider Only Punch OT (if both)" Checked="true" />
                                </a>
                            </div>
                            <div class="lblAndTxtStyle">
                                <a>
                                    <asp:RadioButton GroupName="OTPriority" ID="rdoConditional" CssClass="fieldset-legend"
                                        runat="server" Text="Conditional" Checked="true" />
                                </a>
                            </div>
                            <div>
                                <div style="width: 40%; float: left">
                                    <a>Consider Which is</a>
                                </div>
                                <div style="width: 60%; float: left">
                                    <div style="width: 50%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="OTAssignment" ID="rdoLower" runat="server" Text="Lower"
                                                Checked="true" />
                                        </a>
                                    </div>
                                    <div style="width: 50%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="OTAssignment" ID="rdoHigher" runat="server" Text="Higher" />
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div style="width: 98%">
                    <asl:ucEmpList ID="ctrlEmpList" runat="server"></asl:ucEmpList>
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
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save" />
            </div>
        </div>
    </div>
</asp:Content>
