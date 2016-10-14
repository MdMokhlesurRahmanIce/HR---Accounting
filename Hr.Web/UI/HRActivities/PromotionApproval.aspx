<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="PromotionApproval.aspx.cs" Inherits="Hr.Web.UI.EmployeeBasicInfo.PromotionApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src='<%= ResolveUrl("~/GridScripts/PromotionApprovalEmpList.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= chkApprovalOfPromotion.ClientID %>").click(function (e) {
                var status = $(this).is(':checked');
                var sessionVarName = "PromotionApproval_PromotionEmpList";
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllSelectOrAllClearEmp&Status=' + status + '&SessionVarName=' + sessionVarName,
                        async: false
                    }
                ).responseText
                    $("#grdEmpPromotionApproval").trigger("reloadGrid");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="float: left; width: 100%;">
                <div>
                    <table id="grdEmpPromotionApproval">
                    </table>
                </div>
                <div id="grdEmpPromotionApproval_pager">
                </div>
                <div style="margin-left: 0px; text-align: left; vertical-align: middle;">
                    <span class="lblStyle">Select All</span>
                    <asp:CheckBox ID="chkApprovalOfPromotion" CssClass="selectAll" Text="" runat="server" />
                </div>
            </div>
            <div>
                <div style="float: left; width: 20%">
                    <asp:CheckBox ID="chkApproved" CssClass="selectAll" Text="Approved" runat="server" />
                </div>
                <div style="float: left; width: 20%">
                    <asp:CheckBox ID="chkReject" CssClass="selectAll" Text="Reject" runat="server" />
                </div>
            </div>
        </div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClientClick="CheckValidity();" />
            </div>
        </div>
        <div style="clear: both">
        </div>
        <br />
    </div>
</asp:Content>
