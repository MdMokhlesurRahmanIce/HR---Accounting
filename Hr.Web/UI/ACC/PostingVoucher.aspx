<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="PostingVoucher.aspx.cs" Inherits="Hr.Web.UI.ACC.PostingVoucher" %>

<%@ Register Src="~/Controls/VoucherSearch.ascx" TagName="Voucher" TagPrefix="st" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/VoucherPosting.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".hidePostOrNonPost").hide();
            //            $("#cphInfbody_ctrlVoucher_rdoNonPosted").hide();
            $("#cphBody_cphInfbody_ctrlVoucher_btnSearch").click(function (e) {
                if ($("#cphBody_cphInfbody_ctrlVoucher_txtDateFrom").val() == "") {
                    ShowMessageBox("HR", "Please select from date!");
                    return false;
                }
                if ($("#cphBody_cphInfbody_ctrlSearchVoucher_txtDateTo").val() == "") {
                    ShowMessageBox("HR", "Please select to date!");
                    return false;
                }
                var searchStr = "";
                if ($("#cphBody_cphInfbody_ctrlVoucher_txtDateFrom").val() != "") {
                    searchStr = "@FromDate='" + $("#cphBody_cphInfbody_ctrlVoucher_txtDateFrom").val() + "'";
                }
                if ($("#cphBody_cphInfbody_ctrlVoucher_txtDateTo").val() != "") {
                    searchStr = searchStr + ",@ToDate='" + $("#cphBody_cphInfbody_ctrlVoucher_txtDateTo").val() + "'";
                }
                if ($("#cphBody_cphInfbody_ctrlVoucher_ddlVoucherType").val() != "") {
                    searchStr = searchStr + ",@VoucherType=" + $("#cphBody_cphInfbody_ctrlVoucher_ddlVoucherType").val();
                }
                if ($("#cphBody_cphInfbody_ctrlVoucher_txtVoucherNo").val() != "") {
                    searchStr = searchStr + ",@VoucherNo='" + $("#cphBody_cphInfbody_ctrlVoucher_txtVoucherNo").val() + "'";
                }
                if ($("#cphBody_cphInfbody_ctrlVoucher_txtPayOrRecipient").val() != "") {
                    searchStr = searchStr + ",@PayOrRecipient=" + $("#cphBody_cphInfbody_ctrlVoucher_txtPayOrRecipient").val();
                }
                if ($("#cphBody_cphInfbody_ctrlVoucher_txtVoucherDescription").val() != "") {
                    searchStr = searchStr + ",@VoucherDescription=" + $("#cphBody_cphInfbody_ctrlVoucher_txtVoucherDescription").val();
                }
                if ($("#cphBody_cphInfbody_ctrlVoucher_ddlCompany").val() != "") {
                    searchStr = searchStr + ",@OrgKey=" + $("#cphBody_cphInfbody_ctrlVoucher_ddlCompany").val();
                }
                var retVal = jQuery.ajax
            	        (
            	            {
            	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=searchPostingVoucher&SearchStr=' + searchStr,
            	                async: false
            	            }
                        ).responseText
                $("#grdVoucherPosting").trigger("reloadGrid");
                return false;
            });
            $("#cphBody_cphInfbody_chkApproveOrUnapprove").click(function (e) {
                var status = $(this).is(':checked');
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllSelectOrAllClearGridChecknbox&Status=' + status,
                        async: false
                    }
                ).responseText
                $("#grdVoucherPosting").trigger("reloadGrid");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Posting Voucher"></asp:Label>
        </div>
        <div class="form-details">
            <st:Voucher ID="ctrlVoucher" runat="server">
            </st:Voucher>
            <div style="clear: both">
            </div>
            <div style="width: 95%; margin-top: 5px">
                <div style="margin-left: 0px; text-align: left; vertical-align: middle;">
                    <span class="lblStyle">Select All</span>
                    <asp:CheckBox ID="chkApproveOrUnapprove" Text="" runat="server" />
                </div>
                <div>
                    <table id="grdVoucherPosting">
                    </table>
                </div>
                <div id="grdVoucherPosting_pager">
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnPost" runat="server" CssClass="button" Text="Post"
                    OnClick="btnPost_Click" />
            </div>
        </div>
    </div>
</asp:Content>
