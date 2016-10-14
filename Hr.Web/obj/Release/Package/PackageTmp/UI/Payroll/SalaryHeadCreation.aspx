<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="SalaryHeadCreation.aspx.cs" Inherits="Hr.Web.UI.Payroll.SalaryHeadCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
<script src="<%= ResolveUrl("~/gridscripts/SalaryHead.js") %> " type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
 <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Salary Head"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 100%; height: auto; margin-top: 5px">
                <div>
                    <table id="grdSalaryHead">
                    </table>
                </div>
                <div id="grdSalaryHead_pager">
                </div>
            </div>
        </div>
         <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
