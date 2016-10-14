<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="COA.aspx.cs" Inherits="Hr.Web.UI.ACC.COA" %>
<%@ Register Src="~/Controls/ucCOA.ascx" TagName="ucCOA" TagPrefix="ACC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Chart of Accounts (COA)"></asp:Label>
        </div>
        <div class="form-details" >
            <div style="display:block">
                <ACC:ucCOA ID="ucAccHeadDefinition" runat="server">
                </ACC:ucCOA>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
