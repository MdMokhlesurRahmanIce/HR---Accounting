<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="TrialBalance.aspx.cs" Inherits="Hr.Web.UI.ACC.TrialBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/TrialBalance.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[id$='txtFromDate']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { } });
            $("input[id$='txtToDate']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { } });
            $("#cphBody_cphInfbody_btnSearch").click(function (e) {
                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                if (fromDate == "") {
                    ShowMessageBox("Accounting", "Please select from date!");
                    return false;
                }
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                if (toDate == "") {
                    ShowMessageBox("Accounting", "Please select to date!");
                    return false;
                }
                var orgKey = $("#cphBody_cphInfbody_ddlCompany").val();
                if (orgKey == "") {
                    ShowMessageBox("Accounting", "Please select company!");
                    return false;
                }
                var retVal = jQuery.ajax
                            	        (
                            	            {
                            	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=searchTB&FromDate=' + fromDate + '&ToDate=' + toDate + '&OrgKey=' + orgKey,
                            	                async: false
                            	            }
                                        ).responseText
                $("#grdSummaryBalance").trigger("reloadGrid");
                return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Trail Balance"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 50%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Company</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlCompany" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>From Date</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>To Date</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="width: 50%; float: left">
                <div style="width: 34%; margin-top: 50px">
                    <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search" />
                </div>
            </div>
            <div style="clear: both">
            </div>
            <br />
            <div style="width: 100%; height: auto; margin-top: 5px">
                <div>
                    <table id="grdSummaryBalance">
                    </table>
                </div>
                <div id="grdSummaryBalance_pager">
                </div>
            </div>
            <div style="clear: both">
            </div>
        </div>
        <br />
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnPrint" runat="server" CssClass="button" Text="Print" ValidationGroup="Print"
                    OnClick="btnPrint_Click" OnClientClick="CheckValidity();" />
            </div>
        </div>
    </div>
</asp:Content>
