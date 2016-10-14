<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="Ledger.aspx.cs" Inherits="Hr.Web.UI.ACC.Ledger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/Ledger.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[id$='txtFromDate']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { } });
            $("input[id$='txtToDate']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { } });
            $("#cphBody_cphInfbody_btnSearch").click(function (e) {
                ClearControls();
                var fromDate = $("#cphBody_cphInfbody_txtFromDate").val();
                if (fromDate == "") {
                    ShowMessageBox("HR", "Please select from date!");
                    return false;
                }
                var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                if (toDate == "") {
                    ShowMessageBox("HR", "Please select to date!");
                    return false;
                }
                var orgKey = $("#cphBody_cphInfbody_ddlCompany").val();
                if (orgKey == "") {
                    ShowMessageBox("HR", "Please select company!");
                    return false;
                }
                var head = $("#cphBody_cphInfbody_ddlAccountHead").val();
                if (head == "") {
                    ShowMessageBox("HR", "Please select Account Head!");
                    return false;
                }
                var retVal = jQuery.ajax
                            	        (
                            	            {
                            	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=searchLedger&FromDate=' + fromDate + '&ToDate=' + toDate + '&OrgKey=' + orgKey + '&Head=' + head,
                            	                async: false
                            	            }
                                        ).responseText
                if (retVal != "") {
                    var items = retVal.split(",");
                    if (parseFloat(items[0]) < 0) {
                        $("#cphBody_cphInfbody_txtOpCr").val(Math.abs(parseFloat(items[0])));
                        $("#cphBody_cphInfbody_txtOpDr").val("0.00");
                    }
                    else {
                        $("#cphBody_cphInfbody_txtOpDr").val(items[0]);
                        $("#cphBody_cphInfbody_txtOpCr").val("0.00");
                    }
                    if (parseFloat(items[1]) < 0) {
                        $("#cphBody_cphInfbody_txtPCr").val(Math.abs(parseFloat(items[1])));
                        $("#cphBody_cphInfbody_txtPDr").val("0.00");
                    }
                    else {
                        $("#cphBody_cphInfbody_txtPDr").val(items[1]);
                        $("#cphBody_cphInfbody_txtPCr").val("0.00");
                    }
                    if (parseFloat(items[2]) < 0) {
                        $("#cphBody_cphInfbody_txtCCr").val(Math.abs(parseFloat(items[2])));
                        $("#cphBody_cphInfbody_txtCDr").val("0.00");
                    }
                    else {
                        $("#cphBody_cphInfbody_txtCDr").val(items[2]);
                        $("#cphBody_cphInfbody_txtCCr").val("0.00");
                    }
                }
                $("#grdLedger").trigger("reloadGrid");
                return false;
            });
        });
        function ClearControls() {
            $("#cphBody_cphInfbody_txtOpDr").val('');
            $("#cphBody_cphInfbody_txtOpCr").val('');
            $("#cphBody_cphInfbody_txtPDr").val('');
            $("#cphBody_cphInfbody_txtPCr").val('');
            $("#cphBody_cphInfbody_txtCDr").val('');
            $("#cphBody_cphInfbody_txtCCr").val('');
        }
    </script>
    <style type="text/css">
        .aling
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="General ledger"></asp:Label>
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
                        <a>Account Head</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlAccountHead" runat="server" CssClass="drpwidth180px">
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
            <div style="width: 30%; float: left;">
                <div style="width: 100%; margin-top: 50px">
                    <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search" />
                </div>
            </div>
            <div style="width: 98%;">
                <div style="width: 100%">
                    <div style="width: 65%; float: left">
                        .
                    </div>
                    <div style="width: 35%; float: left">
                        <div style="width: 30%; float: left; font-size: 13px">
                            Opening Balance</div>
                        <div style="width: 32%; float: left">
                            <asp:TextBox ID="txtOpDr" runat="server" CssClass="txtwidth178px aling" MaxLength="100"></asp:TextBox>
                        </div>
                        <div style="width: 31%; float: left">
                            <asp:TextBox ID="txtOpCr" runat="server" CssClass="txtwidth178px aling" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both">
            </div>
            <div style="width: 95.5%; height: auto; margin-top: 5px">
                <div>
                    <table id="grdLedger">
                    </table>
                </div>
                <div id="grdLedger_pager">
                </div>
            </div>
            <br />
            <div style="width: 98%;">
                <div style="width: 100%">
                    <div style="width: 65%; float: left">
                        .
                    </div>
                    <div style="width: 35%; float: left">
                        <div style="width: 30%; float: left; font-size: 13px">
                            Periodical Balance</div>
                        <div style="width: 32%; float: left">
                            <asp:TextBox ID="txtPDr" runat="server" CssClass="txtwidth178px aling" MaxLength="100"></asp:TextBox>
                        </div>
                        <div style="width: 31%; float: left">
                            <asp:TextBox ID="txtPCr" runat="server" CssClass="txtwidth178px aling" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 98%;">
                <div style="width: 100%">
                    <div style="width: 65%; float: left">
                        .
                    </div>
                    <div style="width: 35%; float: left">
                        <div style="width: 30%; float: left; font-size: 13px">
                            Closing Balance</div>
                        <div style="width: 32%; float: left">
                            <asp:TextBox ID="txtCDr" runat="server" CssClass="txtwidth178px aling" MaxLength="100"></asp:TextBox>
                        </div>
                        <div style="width: 31%; float: left">
                            <asp:TextBox ID="txtCCr" runat="server" CssClass="txtwidth178px aling" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
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
