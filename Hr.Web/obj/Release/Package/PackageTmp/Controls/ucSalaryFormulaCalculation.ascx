<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSalaryFormulaCalculation.ascx.cs"
    Inherits="Hr.Web.Controls.ucSalaryFormulaCalculation" %>
<script src="<%= ResolveUrl("~/gridscripts/SalaryInfoEntry.js") %> " type="text/javascript"></script>
<div style=" width: 340px">
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Salary Grade</a>
        </div>
        <div class="div182Px">
            <asp:DropDownList ID="ddlSalaryGrade" runat="server" CssClass="drpwidth180px">
            </asp:DropDownList>
        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Salary Step</a>
        </div>
        <div class="div182Px">
            <asp:DropDownList ID="ddlSalaryStep" runat="server" CssClass="drpwidth180px">
            </asp:DropDownList>
        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Salary Rule</a>
        </div>
        <div class="div182Px">
            <asp:DropDownList ID="ddlSalaryRule" runat="server" CssClass="drpwidth180px">
            </asp:DropDownList>
        </div>
    </div>
    <div style="clear: both">
    </div>
    <div class="lblAndTxtStyle">
        <div style="float: left; width: 350px">
            <table id="grdSalaryInfoEntry">
            </table>
        </div>
        <div id="grdSalaryInfoEntry_pager">
        </div>
    </div>
    <br />
    <div style="text-align: center; float: right">
        <asp:Button ID="btnCalculate" runat="server" CssClass="button" Text="Calculate" />
    </div>
</div>
