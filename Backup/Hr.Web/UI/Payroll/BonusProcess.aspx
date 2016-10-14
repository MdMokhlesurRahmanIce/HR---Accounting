<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="BonusProcess.aspx.cs" Inherits="Hr.Web.UI.Payroll.BonusProcess" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="empSearch" TagPrefix="ast" %>
<%@ Register Src="~/Controls/EmpList.ascx" TagName="ucEmpList" TagPrefix="ast" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/BonusProcessDetail.js") %> " type="text/javascript"></script>
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
    <script type="text/javascript">

        $(document).ready
        (
            function () {
                $("input[id$='txtCuOfDate']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true });

            }

        );     
    </script>
    <script type="text/javascript">
        var $tabs;
        var selectedtab;
        function ViewData(headerText) {
            selectedtab = 1;
            SecondTab();
            $tabs.tabs('select', selectedtab);
            return false;
        }
        function SecondTab() {
            var Cause = $("#cphBody_cphInfbody_ddlCause").val();
            var Remarks = $("#cphBody_cphInfbody_txtRemarks").val();
            var Action = $("#cphBody_cphInfbody_ddlAction").val();
            var EffectedDate = $("#cphBody_cphInfbody_txtEffectiveDate").val();
            var Note = $("#cphBody_cphInfbody_txtNote").val();

            if (Cause == "") {
                ShowMessageBox("HR", "Please Select Cause!");
                return false;
            }
            if (Action == "") {
                ShowMessageBox("HR", "Please Select Action!");
                return false;
            }
            if (EffectedDate == "") {
                ShowMessageBox("HR", "Please Select Effective Date!");
                return false;
            }
            jQuery.ajax
                            (
                                {

                                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=SeparationProcess&Cause=' + Cause + '&Remarks=' + Remarks + '&Action=' + Action + '&EffectedDate=' + EffectedDate + '&Note=' + Note,
                                    async: false
                                }
                            );
            $("#grdSeparation").trigger("reloadGrid");
        }
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
            $("#cphBody_cphInfbody_btnSave").click(function (e) {
                jQuery.ajax
                            (
                                {
                                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=SeparationDataSave',
                                    async: false,
                                    success: function () { ShowMessageBox('Successful', 'Data Saved Successfully.') },
                                    error: function (xhr, status, error) {
                                        ShowMessageBox('Error', xhr.responseText);
                                    }
                                }
                            );
                $("#grdSeparation").trigger("reloadGrid");
                return false;
            });
        });
        $(function () {
            $tabs = $("#divTab").tabs();
            $tabs.tabs('select', selectedtab);
            $("#divTab").bind("tabsselect", function (e, tab) {
                if (tab.index == 1) {
                    SecondTab();
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 28%; float: left">
                <div class="lblAndTxtStyle" style="width: 99%; float: left">
                    <div class="divlblwidth100px bglbl">
                        <a>Bonus Rule Name</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlBonusRuleName" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle" style="width: 99%; float: left">
                    <div class="divlblwidth100px bglbl">
                        <a>Cut Of Date</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtCuOfDate" runat="server" CssClass="drpwidth180px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Year</a>
                    </div>
                    <div class="div182Px" style="float: left;">
                        <asp:DropDownList ID="ddlyearno" runat="server" OnSelectedIndexChanged="ddlyearno_SelectedIndexChanged"
                            AutoPostBack="true" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Month</a>
                    </div>
                    <div class="div182Px" style="float: left">
                        <asp:DropDownList ID="ddlMonthNo" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
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
            <div id="divTab" style="width: 71%; float: left;" onclick="return divTab_onclick()">
                <br />
                <ul>
                    <li><a href="#tabPersonalInfo">Emp Selection</a></li>
                    <li><a href="#tabOfficialInfo">Details Info</a></li>
                </ul>
                <div id="tabPersonalInfo" style="width: 99%">
                    <ast:ucEmpList ID="ctrlEmpList" runat="server"></ast:ucEmpList>
                </div>
                <div id="tabOfficialInfo" style="width: 100%" onclick="return divTab_onclick()">
                    <div>
                        <div>
                            <table id="grdBonusProcessDetail" style="width: 95%; float: left">
                            </table>
                        </div>
                        <div id="grdBonusProcessDetail_pager">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" />
            </div>
            <div class="btnRight">
                <button type="button" class="button" onclick="javascript:ViewData('Separation');">
                    Process</button>
            </div>
        </div>
    </div>
</asp:Content>
