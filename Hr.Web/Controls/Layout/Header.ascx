<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Hr.Web.Controls.Layout.HeaderTop" %>
<%@ Register Src="~/Controls/Layout/LoggedOnOrOff.ascx" TagName="LoggedOnOrOff" TagPrefix="st" %>
<%@ Register Src="~/Controls/Layout/CompanyLogo.ascx" TagName="CompanyLogo" TagPrefix="st" %>
<div class="global-header">
    <div class="logo">
        <st:CompanyLogo ID="ctrlCompanyLogo" runat="server" />
    </div>
    <div class="loggedon-panel">
        <st:LoggedOnOrOff ID="ctrlLoggedOnOrOff" runat="server" />
    </div>
</div>
<div class="clear"></div>
