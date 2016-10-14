<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="SearchOrEditVoucher.aspx.cs" Inherits="Hr.Web.UI.ACC.SearchOrEditVoucher" %>

<%@ Register Src="~/Controls/VoucherSearch.ascx" TagName="Voucher" TagPrefix="st" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/VoucherSearch.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#cphBody_cphInfbody_ctrlSearchVoucher_btnSearch").click(function (e) {
                if ($("#cphBody_cphInfbody_ctrlSearchVoucher_txtDateFrom").val() == "") {
                    ShowMessageBox("HR", "Please select from date!");
                    return false;
                }
                if ($("#cphBody_cphInfbody_ctrlSearchVoucher_txtDateTo").val() == "") {
                    ShowMessageBox("HR", "Please select to date!");
                    return false;
                }
                var searchStr = "";
                if ($("#cphBody_cphInfbody_ctrlSearchVoucher_txtDateFrom").val() != "") {
                    searchStr = "@FromDate='" + $("#cphBody_cphInfbody_ctrlSearchVoucher_txtDateFrom").val() + "'";
                }
                if ($("#cphBody_cphInfbody_ctrlSearchVoucher_txtDateTo").val() != "") {
                    searchStr = searchStr + ",@ToDate='" + $("#cphBody_cphInfbody_ctrlSearchVoucher_txtDateTo").val() + "'";
                }
                if ($("#cphBody_cphInfbody_ctrlSearchVoucher_ddlVoucherType").val() != "") {
                    searchStr = searchStr + ",@VoucherType=" + $("#cphBody_cphInfbody_ctrlSearchVoucher_ddlVoucherType").val();
                }
                if ($("#cphBody_cphInfbody_ctrlSearchVoucher_ddlSO").val() != "") {
                    searchStr = searchStr + ",@EmpKey=" + $("#cphBody_cphInfbody_ctrlSearchVoucher_ddlSO").val();
                }
                if ($("#cphBody_cphInfbody_ctrlSearchVoucher_txtVoucherNo").val() != "") {
                    searchStr = searchStr + ",@VoucherNo=" + $("#cphBody_cphInfbody_ctrlSearchVoucher_txtVoucherNo").val();
                }
                if ($("#cphBody_cphInfbody_ctrlSearchVoucher_txtPayOrRecipient").val() != "") {
                    searchStr = searchStr + ",@PayOrRecipient=" + $("#cphBody_cphInfbody_ctrlSearchVoucher_txtPayOrRecipient").val();
                }
                if ($("#cphBody_cphInfbody_ctrlSearchVoucher_txtVoucherDescription").val() != "") {
                    searchStr = searchStr + ",@VoucherDescription=" + $("#cphBody_cphInfbody_ctrlSearchVoucher_txtVoucherDescription").val();
                }
                if ($("#cphBody_cphInfbody_ctrlSearchVoucher_ddlCompany").val() != "") {
                    searchStr = searchStr + ",@OrgKey=" + $("#cphBody_cphInfbody_ctrlSearchVoucher_ddlCompany").val();
                }
                searchStr = searchStr + ",@IsPost=" + 3;
                var retVal = jQuery.ajax
            	        (
            	            {
            	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=searchVoucher&SearchStr=' + searchStr,
            	                async: false
            	            }
                        ).responseText
                $("#grdVoucherSearch").trigger("reloadGrid");
                return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Edit/Search Voucher"></asp:Label>
        </div>
        <div class="form-details">
            <st:Voucher ID="ctrlSearchVoucher" runat="server">
            </st:Voucher>
            <div style="clear: both">
            </div>
            <div style="width: 95%; margin-top: 5px">
                <div>
                    <table id="grdVoucherSearch">
                    </table>
                </div>
                <div id="grdVoucherSearch_pager">
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <br />
        <br />
    </div>
</asp:Content>
