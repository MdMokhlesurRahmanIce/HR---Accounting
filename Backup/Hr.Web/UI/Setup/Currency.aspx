<%@ Page Title="Currency" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="Currency.aspx.cs" Inherits="Hr.Web.UI.Setup.Currency" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src='<%= ResolveUrl("~/GridScripts/JSCurrency.js") %>' type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
   <div class="form-wrapper">
           <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Currency"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 100%; height: auto; margin-top: 5px">
                <div>
                    <table id="grdCurrency">
                    </table>
                </div>
                <div id="grdCurrency_pager">
                </div>
            </div>
        </div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save" OnClick="btnSave_Click"/>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
