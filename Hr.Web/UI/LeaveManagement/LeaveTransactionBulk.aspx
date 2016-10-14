<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaveTransactionBulk.aspx.cs"
    Inherits="Hr.Web.UI.LeaveManagement.LeaveTransactionBulk" Title="Lotus-12 :: Leave Transaction [Bulk]" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="empSearch2" TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmpList.ascx" TagName="empSearch2" TagPrefix="asl" %>
<%@ Register Src="~/Controls/SearchEmployee.ascx" TagName="empSearch2" TagPrefix="asl" %>
<%@ Register Src="~/Controls/PictureUpload.ascx" TagName="empSearch2" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/grdLeaveSummary.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/LeaveTransactions.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/ShiftRosterProcess.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/Cal_WHEmpList.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/EmployeeSelectionGrid.js") %> " type="text/javascript"></script>
    <%--    <script src="../GridScripts/grdLeaveSummary.js" type="text/javascript"></script>

    <script src="../GridScripts/LeaveTransactions.js" type="text/javascript"></script>

    <script src="../GridScripts/ShiftRosterProcess.js" type="text/javascript"></script>

    <script src="../GridScripts/Cal_WHEmpList.js" type="text/javascript"></script>

    <script src="../GridScripts/EmployeeSelectionGrid.js" type="text/javascript"></script>

    <script src='<%= ResolveUrl("../GridScripts/EmployeeBasicInfo_EmployeeEducationInfo.js") %>'
        type="text/javascript"></script>--%>
    <style type="text/css">
        #tabMarker.lblAndTxtStyle
        {
            font-family: 'Microsoft Sans Serif' ,Sans-Serif,Arial;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#divTab").tabs();
        });
    </script>
    <script type="text/javascript" src="jquery.js">
        
    </script>
    <script type="text/javascript">
        var $tabs;
        var selectedtab;
        $(document).ready(function () {
            $('#divTab, #tabAttManual2').tabs({
                select: function (event, ui) {
                    var fromDate = $("#ctl00_cphBody_txtFromDate").val();
                    var toDate = $("#ctl00_cphBody_txtToDate").val();
                    var str = "";
                    var Page = "ShiftRosterProcess";
                    var strBuffer = "";
                    var spName = "spShiftRosterProcess";
                    //alert('shaikat');
                    var retVal = jQuery.ajax
                                (
                                    {

                                        //         url: '../GridHelperClasses/DataHandler.ashx?CallMode=ManualProcessEmpList&SpName=' + spName + '&FromDate=' + fromDate + '&ToDate=' + toDate + '&Str=' + str + '&StrBuffer=' + strBuffer + '&Page=' + Page,
                                        async: false
                                    }
                                ).responseText
                    $("#ShowShiftRosterProcess").trigger("reloadGrid");
                }
            });

            $("#ctl00_cphBody_rdoSingle").live("click", function () {
                $("#empGrid").show();

            });
            $("#ctl00_cphBody_rdoBulk").live("click", function () {
                $("#empGrid").hide();

            });
            $("#ctl00_cphBody_btnProcess").click(function (e) {
                selectedtab = 1;
                // alert('ssss');
                var fromDate = $("#ctl00_cphBody_txtFromDate").val();
                var toDate = $("#ctl00_cphBody_txtToDate").val();
                var str = "";
                var Page = "ShiftRosterProcess";
                var strBuffer = "";
                var spName = "spShiftRosterProcess";
                //alert('shaikat');
                var retVal = jQuery.ajax
                                (
                                    {

                                        url: '../GridHelperClasses/DataHandler.ashx?CallMode=ManualProcessEmpList&SpName=' + spName + '&FromDate=' + fromDate + '&ToDate=' + toDate + '&Str=' + str + '&StrBuffer=' + strBuffer + '&Page=' + Page,
                                        async: false
                                    }
                                ).responseText
                $("#ShowShiftRosterProcess").trigger("reloadGrid");
                $tabs.tabs('select', selectedtab);
                return false;
            });


            $("#ctl00_cphBody_btnView").click(function (e) {
                //  alert('ssss');
                var fromDate = $("#ctl00_cphBody_txtFromDate").val();
                var Page = "LeaveTransaction";
                var LeaveYear = $("#ctl00_cphBody_ddlLeaveYear option:selected").val();
                var toDate = $("#ctl00_cphBody_txtToDate").val();
                var EmpCriteria = "";

                //var str = "WorkDate Between " + fromDate + " and " + toDate;
                var searchcriteria = "";
                var spName = "spGetEmpForLeaveTransaction";
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: '../GridHelperClasses/DataHandler.ashx?CallMode=ShowAllEmpForCalendar&SpName=' + spName + '&Page=' + Page + '&LeaveYear=' + LeaveYear + '&EmpCriteria=' + EmpCriteria,
                    	                async: false
                    	            }
                                ).responseText
                $("#grdComonApproval").trigger("reloadGrid");
                return false;
            });


            $("#ctl00_cphBody_rdoDeleteALL").click(function (e) {
                $('#ctl00_cphBody_chkUCDWDA').attr("checked", false);
                $('#ctl00_cphBody_chkUCDWDA').attr("disabled", true);
            });
            $("#ctl00_cphBody_rdoDeclaration").click(function (e) {
                $('#ctl00_cphBody_chkUCDWDA').attr("disabled", false);
            });




        });



        $(function () {
            $tabs = $("#divTab").tabs();
            $tabs.tabs('select', selectedtab);
        });
        
        
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="totalBody bgBody">
        <div class="mainBody">
            <div id="divTab" style="width: 99%; height: 550px; float: left; background-color: #FDF7EA;">
                <ul>
                    <li><a href="#tabPersonalInfo">Emp Selection</a></li>
                    <li><a href="#tabAttManual2">Info Entry</a></li>
                </ul>
                <div id="tabPersonalInfo" style="height: auto; border: none; width: 99%; background-color: #FDF7EA;">
                    <div style="width: 25%; float: left">
                        <br />
                        <div style="width: 99%; float: left">
                            <div class="divlblwidth100px bglbl">
                                <a>Leave Year</a>
                            </div>
                            <div class="div80Px" style="float: left;">
                                <asp:DropDownList ID="ddlLeaveYear" runat="server" CssClass="txtwidth178px txtWidth">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div style="width: 99%; float: left">
                            <div class="divlblwidth100px bglbl">
                                <a>Leave Rule</a>
                            </div>
                            <div class="div80Px" style="float: left;">
                                <asp:DropDownList ID="ddlLeaveRule" runat="server" CssClass="txtwidth178px txtWidth">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div style="height: auto">
                            <asl:ucEmployeeSearch ID="ucEmployeeSearchWHDeclaration" runat="server">
                            </asl:ucEmployeeSearch>
                        </div>
                        <div class="btnRight" style="float: right; padding-right: 20px">
                            <asp:Button ID="btnView" runat="server" CssClass="button" Text="View" />
                        </div>
                    </div>
                    <div id="empGrid" visible="false" style="width: 74%; height: 30px; float: left">
                        <div class="lblAndTxtStyle" style="width: 99%; float: left">
                            <div style="width: 99%; float: left">
                                <div style="width: 25%; float: left">
                                    <div class="divlblwidth60px bglbl">
                                        <a>Leave Type</a>
                                    </div>
                                    <div class="div80Px" style="float: left;">
                                        <asp:DropDownList ID="ddlLeaveType" runat="server" CssClass="txtwidth178px txtWidth">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div style="width: 25%; float: left">
                                    <div class="divlblwidth60px bglbl">
                                        <a>LeaveFrom</a>
                                    </div>
                                    <div class="div80Px" style="width: 40%; float: left;">
                                        <asp:TextBox ID="txtLeaveFrom" runat="server" CssClass="txtwidth178px txtWidth"></asp:TextBox>
                                    </div>
                                </div>
                                <div style="width: 25%; float: left">
                                    <div class="divlblwidth60px bglbl">
                                        <a>Leave To</a>
                                    </div>
                                    <div class="div80Px" style="width: 29%; float: left;">
                                        <asp:TextBox ID="txtLeaveTo" runat="server" CssClass="txtwidth178px txtWidth"></asp:TextBox>
                                    </div>
                                </div>
                                <div style="width: 25%; float: left">
                                    <div class="divlblwidth60px bglbl">
                                        <a>Days</a>
                                    </div>
                                    <div class="div80Px" style="width: 29%; float: left;">
                                        <asp:TextBox ID="txtDays" runat="server" CssClass="txtwidth178px txtWidth"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 99%; float: left">
                                <div style="width: 25%; float: left">
                                    <div class="divlblwidth60px bglbl">
                                        <a>Reason</a>
                                    </div>
                                    <div class="div80Px" style="width: 40%; float: left;">
                                        <asp:TextBox ID="txtReason" runat="server" CssClass="txtwidth178px txtWidth"></asp:TextBox>
                                    </div>
                                </div>
                                <div style="width: 25%; float: left">
                                    <div class="divlblwidth60px bglbl">
                                        <a>Avail Place</a>
                                    </div>
                                    <div class="div80Px" style="width: 29%; float: left;">
                                        <asp:TextBox ID="txtAvailPlace" runat="server" CssClass="txtwidth178px txtWidth"></asp:TextBox>
                                    </div>
                                </div>
                                <div style="width: 25%; float: left">
                                    <div class="divlblwidth60px bglbl">
                                        <a>Contact</a>
                                    </div>
                                    <div class="div80Px" style="width: 29%; float: left;">
                                        <asp:TextBox ID="txtAdditionalContact" runat="server" CssClass="txtwidth178px txtWidth"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle" style="width: 99%; float: left">
                            <div class="lblAndTxtStyle bglbl" style="width: 99%">
                                <a style="font-weight: 300">[Type For Search]</a>
                            </div>
                            <div style="width: 99%; float: left">
                                <asp:TextBox ID="txtSearched" runat="server" Width="79%">
                                </asp:TextBox>
                                <asp:DropDownList ID="ddlSelection" runat="server" Width="19%">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div style="width: 99%; height: 360px">
                            <asl:ucEmpList ID="ctrlEmpList" runat="server">
                            </asl:ucEmpList>
                        </div>
                    </div>
                </div>
                <div id="tabAttManual2" style="width: 95%; float: left">
                    <div class="ui-jqgrid">
                        <table id="ShowShiftRosterProcess">
                        </table>
                    </div>
                    <div id="ShowShiftRosterProcess_pager">
                    </div>
                </div>
            </div>
        </div>
        <div>
            <div class="MasterButton">
                <div class="btnRight" style="padding-top: 5px;">
                    <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClick="btnDelete_Click" />
                </div>
                <div class="btnRight" style="padding-top: 5px;">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click" />
                </div>
                <div class="btnRight" style="padding-top: 5px;">
                    <asp:Button ID="btnProcess" runat="server" CssClass="button" Text="Process" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
