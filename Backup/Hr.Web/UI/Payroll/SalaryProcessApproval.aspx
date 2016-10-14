<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="SalaryProcessApproval.aspx.cs" Inherits="Hr.Web.UI.Payroll.SalaryProcessApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/SalaryProcessApproval.js") %> " type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            
          
           
           
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div>
                <div>
                    <table id="SalaryProcessApproval">
                    </table>
                </div>
                <div id="SalaryProcessApproval_pager">
                </div>
            </div>
            <div class="lblStyle" style="float: right; margin-right: 2px;">
                <div>
                    <asp:CheckBox ID="chkForwarded" Text="Forwarded" runat="server" />
                    <asp:CheckBox ID="chkRecomended" Text="Recomended" runat="server" />
                    <asp:CheckBox ID="chkApproved" Text="Approved" runat="server" />
                    <asp:CheckBox ID="chkRejected" Text="Rejected" runat="server" />
                </div>
            </div>
            <br />
            <br />
           
        </div>
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
