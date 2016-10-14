<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="Rate.aspx.cs" Inherits="Hr.Web.UI.ProductionDataCapture.Rate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/ProductionDataCapture/RateDynamicGrid.js") %> "
        type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Rate"></asp:Label>
        </div>
        <div class="form-details">
            <div>
                <div>
                    <table id="grdRate">
                    </table>
                </div>
                <div id="grdRate_pager">
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
