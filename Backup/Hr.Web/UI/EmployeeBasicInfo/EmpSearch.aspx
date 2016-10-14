<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="EmpSearch.aspx.cs" Inherits="Hr.Web.UI.EmployeeBasicInfo.EmpSearch" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="empSearch" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Search Employee"></asp:Label>
        </div>
        <div class="form-details">
            <asl:empSearch ID="ctrlEmpSearch" runat="server"></asl:empSearch>
        </div>
    </div>
</asp:Content>
