<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="ReportPermission.aspx.cs" Inherits="Hr.Web.Reports.ReportPermission"
    Title="Report Permission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">

    <script src='<%= ResolveUrl("../GridScripts/Shoilee_Material_ReportPermission.js") %>'
        type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="totalBody bgBody border overflowHidden">
        <div class="mainBody">
            <div class="leftDiv40P">
                <%--<div class="lblAndTxt100Pdiv">
                    <asp:Label ID="Label1" runat="server" CssClass="lblStyle">User</asp:Label>
                </div>--%>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>User</a>
                    </div>
                    <div class="div80Px">
                        <asp:DropDownList ID="ddlUser" runat="server" CssClass="ddl90P" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div style="margin-left:10px">
                        <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select All" CssClass="cbStyle"
                           AutoPostBack="true" oncheckedchanged="chkSelectAll_CheckedChanged" />
                    </div>
                </div>
                <div class="lblAndTxt100Pdiv" style="width: 450px; height: 450px; margin-top: 10px">
                    <div>
                        <table id="grdReportpermission" runat="server">
                        </table>
                    </div>
                    <div id="grdReportPermission_pager">
                    </div>
                </div>
            </div>
            <div class="rightDiv60P">
            </div>
        </div>
        <div class="bottom">
            <div class="btnRight">
                <asp:Button ID="btnRefresh" runat="server" CssClass="button" Text="Refresh" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
    <div class="totalDiv" style="text-align: center">
        <asp:Label ID="lblErrorMassege" runat="server" Text="" CssClass="error divleftmargin15"
            Width="100%"></asp:Label>
    </div>
</asp:Content>
