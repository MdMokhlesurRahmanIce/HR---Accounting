<%@ Page Title="Education" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true"
    CodeBehind="EducationQualification.aspx.cs" Inherits="Hr.Web.UI.Setup.EducationQualification" EnableViewState="true"%>

<%@ Register Src="~/Controls/EducationQualification.ascx" TagName="EducationQualification" TagPrefix="st" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <st:EducationQualification ID="ctrlEducationQualification" runat="server">
    </st:EducationQualification>   
</asp:Content>
