<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="PDFViewer.aspx.cs" Inherits="Hr.Web.PDFViewer1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
<iframe runat="server" id="iframepdf" height="900" width="100%" src="PDFViewer.ashx"> </iframe>
</asp:Content>
