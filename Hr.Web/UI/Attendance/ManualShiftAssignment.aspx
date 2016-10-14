<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="ManualShiftAssignment.aspx.cs" Inherits="Hr.Web.UI.Attendance.ManualShiftAssignment" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmpList.ascx" TagName="ucEmpList" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[id$='txtFromDate'], .datepicker").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), dateFormat: 'mm/dd/yy' });
            $("#cphBody_cphInfbody_rdoTemporary").live("click", function () {
                $(".tmp").show();
            });
            $("#cphBody_cphInfbody_rdoPerment").live("click", function () {
                $(".tmp").hide();
            });
            $("#cphBody_cphInfbody_btnView").click(function (e) {
                var spName = "spGetEmpManualShift";
                var FromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                var ToDate = $("#cphBody_cphInfbody_txtToDate").val();
                var retVal = jQuery.ajax
                        (
                            {
                                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllEmpForCalendar&SpName=' + spName + '&FromDate=' + FromDate + '&ToDate=' + ToDate,
                                async: false
                            }
                        ).responseText
                $("#grdCalendar").trigger("reloadGrid");
                return false;
            });
            $("#cphBody_cphInfbody_btnSave").click(function (e) {
                var strSearch = "";
                var shiftId = $("#cphBody_cphInfbody_ddlSelectShift").val();
                var isDelete = $("#cphBody_cphInfbody_chkIsDelete").is(":checked");
               // alert($("#cphBody_cphInfbody_rdoTemporary").is(":checked"));
                if ($("#cphBody_cphInfbody_rdoTemporary").is(":checked")) {
                    var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                   
                    if (shiftId == "") {
                        ShowMessageBox("HR", "Please select from ShiftID!");
                        return false;
                    }
                    var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                    if (fromDate == "") {
                        ShowMessageBox("HR", "Please select from date!");
                        return false;
                    }
                    if (toDate == "") {
                        ShowMessageBox("HR", "Please select to date!");
                        return false;
                    }
                    strSearch = fromDate + ",'" + toDate;
                }
                else {
                    strSearch = "";
                }
                jQuery.ajax
                            (
                                {
                                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ManualShiftAssign&FromDate=' + fromDate + '&ToDate=' + toDate + '&ShiftID=' + shiftId + '&IsDelete=' + isDelete,
                                    async: false,
                                    success: function () { ShowMessageBox('Successful', 'Process saved successfully.') },
                                    error: function (xhr, status, error) {
                                        ShowMessageBox('Error', xhr.responseText);
                                    }
                                }
                            );
                $("#grdCalendar").trigger("reloadGrid");
                return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 28%; float: left">
                <div style="width: 99%; float: left;">
                    <fieldset class="fieldset-panel">
                        <legend class="fieldset-legend">Type Of Information Transfer</legend>
                        <div style="width: 33%; float: left">
                            <a>
                                <asp:RadioButton GroupName="shiftType" ID="rdoSingleShift" runat="server" Text="Single Shift"
                                    Checked="true" />
                            </a>
                        </div>
                        <div style="width: 65%; float: left">
                            <a>
                                <asp:RadioButton GroupName="shiftType" ID="rdoMulitShift" runat="server" Text="Multiple Shift (SingleDay)" />
                            </a>
                        </div>
                        <div style="width: 33%; float: left">
                            <a>
                                <asp:RadioButton GroupName="ShiftTransfer" ID="rdoTemporary" runat="server" Text="Temporary"
                                    Checked="true" />
                            </a>
                        </div>
                        <div style="width: 33%; float: left">
                            <a>
                                <asp:RadioButton GroupName="ShiftTransfer" ID="rdoPerment" runat="server" Text="Permanet" />
                            </a>
                        </div>
                        <div>
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth100px bglbl">
                                    <a>From Date</a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                </div>
                            </div>
                            <div class="lblAndTxtStyle tmp">
                                <div class="divlblwidth100px bglbl">
                                    <a>To Date</a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="txtwidth178px datepicker" MaxLength="100"></asp:TextBox>
                                </div>
                            </div>
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth100px bglbl">
                                    <a>Select Shift</a>
                                </div>
                                <div class="div182Px">
                                    <asp:DropDownList ID="ddlSelectShift" runat="server" CssClass="drpwidth180px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="lblAndTxtStyle">
                                <a>
                                    <asp:CheckBox ID="chkIsDelete" Text="Existing Shift Delete Automatically" runat="server" />
                                </a>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <div style="clear: both">
                </div>
                <div style="float: left">
                    <asl:ucEmployeeSearch ID="ctrlEmpSearchOTAssignment" runat="server"></asl:ucEmployeeSearch>
                </div>
                <div style="float: right; text-align: center">
                    <asp:Button ID="btnView" runat="server" CssClass="button" Text="View" />
                </div>
            </div>
            <div style="width: 70%; float: left">
                <asl:ucEmpList ID="ctrlEmpList" runat="server"></asl:ucEmpList>
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
