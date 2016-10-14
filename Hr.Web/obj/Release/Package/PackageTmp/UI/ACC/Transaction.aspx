<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="Transaction.aspx.cs" Inherits="Hr.Web.UI.ACC.Transaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/Transaction.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[id$='txtFromDate']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { } });
            $("input[id$='txtToDate']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { } });
            $("#cphBody_cphInfbody_btnSearch").click(function (e) {
                var isPost = 0;
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
                if ($("#cphBody_cphInfbody_rdoPosted").is(":checked")) {
                    isPost = 1;
                }
                var retVal = jQuery.ajax
            	        (
            	            {
            	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=searchTransaction&FromDate=' + fromDate + '&ToDate=' + toDate + '&OrgKey=' + orgKey + '&IsPost=' + isPost,
            	                async: false
            	            }
                        ).responseText
                $("#grdTransaction").trigger("reloadGrid");
                return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Perioddical transaction"></asp:Label>
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
                <div class="hidePostOrNonPost" style="width: 33%; float: left">
                    <asp:RadioButton GroupName="VoucherSearch" ID="rdoNonPosted" runat="server" Text="Non-Posted" />
                </div>
                <div class="hidePostOrNonPost" style="width: 33%; float: left">
                    <asp:RadioButton GroupName="VoucherSearch" ID="rdoPosted" runat="server" Text="Posted"
                        Checked="true" />
                </div>
                <div style="width: 34%; margin-top: 50px">
                    <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search" />
                </div>
            </div>
            <div style="clear: both">
            </div>
            <br />
            <div style="width: 70%; height: auto; margin-top: 5px">
                <div>
                    <table id="grdTransaction">
                    </table>
                </div>
                <div id="grdTransaction_pager">
                </div>
            </div>
            <div style="clear: both">
            </div>
        </div>
        <br />
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnPrint" runat="server" CssClass="button" Text="Print" ValidationGroup="Print" OnClick="btnPrint_Click"
                    OnClientClick="CheckValidity();" />
            </div>
        </div>
    </div>
</asp:Content>
