<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="DemoPage.aspx.cs" Inherits="Hr.Web.UI.HRActivities.Attendance.DemoPage" %>


<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="ucEmployeesearch" TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmpList.ascx" TagName="ucEmpList" TagPrefix="asl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#cphBody_cphInfbody_btnView").click(function (e) {
                var spName = "spGetEmpForSeparation";
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
            $("input[id$='txtFromDate']").datepicker({
                showButtonPanel: true
                , changeMonth: true
                , changeYear: true
                , onSelect: function () { }
                , defaultDate: new Date()
                , dateFormat: 'mm/dd/yy'
                , onClose: function (dateText, inst) {
                    $("#cphBody_cphInfbody_txtToDate").val(dateText);
                }
            });
            $("input[id$='txtToDate']").datepicker({
                showButtonPanel: true
                , changeMonth: true
                , changeYear: true
                , onSelect: function () { }
                , defaultDate: new Date()
                , dateFormat: 'mm/dd/yy'
                , onClose: function (dateText, inst) {
                    var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                    if (new Date(dateText) < new Date(fromDate)) {
                        $("#cphBody_cphInfbody_txtToDate").val(fromDate);
                        ShowMessageBox("HR", "To date must be greater than or equal to from date!");
                    }
                }
            });
        });
    </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Absent Entry"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 28%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>From Date</a>
                    </div>
                    <div class="div80Px" style="width: 59%">
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>To Date</a>
                    </div>
                    <div class="div80Px" style="width: 59%">
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <asl:ucEmployeeSearch ID="ctrlEmpSearch" runat="server"></asl:ucEmployeeSearch>
                <div style="text-align: center; float: right; padding-right: 5px">
                    <asp:Button ID="btnView" runat="server" CssClass="button" Text="View" />
                </div>
            </div>
            <div style="width: 69%; float: left">
                <asl:ucEmpList ID="ctrlEmpList" runat="server"></asl:ucEmpList>
            </div>
            <div style="clear: both">
            </div>
            <div class="form-bottom" style="text-align: center">
                <div class="btnRight">
                    <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" Visible="false" />
                </div>
                <div class="btnRight">
                    <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete"  />
                </div>
                <div class="btnRight">
                    <asp:Button ID="btnSave" runat="server" CssClass="button"  Text="SAVE" />
                </div>
            </div>
        </div>
    </div>
  
</asp:Content>
