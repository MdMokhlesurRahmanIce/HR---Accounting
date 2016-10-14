<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="MiscAllowDedEntry.aspx.cs" Inherits="Hr.Web.UI.Payroll.MiscAllowDedEntry" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmpList.ascx" TagName="ucEmpList" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/Misc_SalaryHead.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/DynamicallyCreateMiscAllowDed.js") %> "
        type="text/javascript"></script>
    <script type="text/javascript">
        var $tabs;
        var selectedtab;
        $(function () {
            $tabs = $("#divTab").tabs();
            $tabs.tabs('select', selectedtab);
            $("#divTab").bind("tabsselect", function (e, tab) {
                if (tab.index == 1) {
                    __doPostBack("SelectedTab_Test");
                }
            });
        });
        $(document).ready(function () {
            $("#cphBody_cphInfbody_btnView").click(function (e) {
                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                var spName = "spGetEmpForSearch1";
             
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllEmpForCalendar&SpName=' + spName + '&FromDate=' + fromDate + '&ToDate=' + toDate,
                    	                async: false
                    	            }
                                ).responseText
                $("#grdCalendar").trigger("reloadGrid");
                return false;
            });
            $("input[id$='txtFromDate'], .datePicker").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), dateFormat: 'mm/dd/yy' });
        });
    </script>
    <style type="text/css">
        #tabMarker .lblAndTxtStyle
        {
            font-family: 'Microsoft Sans Serif' ,Sans-Serif,Arial;
        }
    </style>
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
                <div class="lblAndTxtStyle" style="margin-left: -4px;">
                    <div class="divlblwidth100px bglbl">
                        <a>To Date</a>
                    </div>
                    <div class="div80Px" style="width: 59%">
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="txtwidth178px datePicker" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <asl:ucEmployeeSearch ID="ctrlMiscAllowDedEntry" runat="server"></asl:ucEmployeeSearch>
                <div style="text-align: center">
                    <asp:Button ID="btnView" runat="server" CssClass="button" Text="View" />
                </div>
            </div>
            <div id="divTab" style="width: 71%; float: left; padding-bottom: 10px;">
                <ul>
                    <li><a href="#tabStep1">Step-1</a></li>
                    <li><a href="#tabStep2">Step-2</a></li>
                </ul>
                <div id="tabStep1" style="width: 100%; float: left">
                    <div style="width: 58%; float: left">
                        <asl:ucEmpList ID="ctrlEmpList" runat="server"></asl:ucEmpList>
                    </div>
                    <div style="float: left; width: 40%;">
                        <div>
                       
                            <table id="grdMiscSalaryHead">
                            </table>
                        </div>
                        <div id="grdMiscSalaryHead_pager">
                        </div>
                    </div>
                </div>
                <div id="tabStep2" style="width: 98%;">
                    <div>
                        <div>
                            <table id="grdDynamicallyCreateMiscAllowDed" runat="server">
                            </table>
                        </div>
                        <div id="grdDynamicallyCreateMiscAllowDed_pager">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
