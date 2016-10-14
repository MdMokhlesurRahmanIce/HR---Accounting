<%@ Page Title="Fiscal Year" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="FiscalYear.aspx.cs" Inherits="Hr.Web.UI.Setup.FiscalYear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
<script src="<%= ResolveUrl("~/gridscripts/FiscalYear.js") %> " type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
   <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 100%; height: auto; margin-top: 5px">
                <div>
                    <table id="grdFiscalYear" runat="server">
                    </table>
                </div>
                <div id="grdFiscalYear_pager">
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
