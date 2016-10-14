<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="ShiftRule.aspx.cs" Inherits="Hr.Web.UI.Attendance.ShiftRule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/ShiftRuleDetail.js") %> " type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Shift Rule"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 40%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Shift Rule Code</a>
                    </div>
                    <div class="div80Px">
                        <div style="width: 80%">
                            <asp:TextBox ID="txtShiftRuleCode" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                        </div>
                        <div style="float: left; margin-left: 5px;">
                            <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png" OnClick="btnNew_Click" />
                            <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" OnClick="btnFind_Click" />
                        </div>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Description</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="txtwidth178px allowEnter" TextMode="MultiLine" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="float: left; width: 40%">
                <div class="lblAndTxtStyle">
                    <asp:CheckBox ID="chkDefaultShiftRule" Text="Make it default shift rule" CssClass="fieldset-legend" Visible="false"
                        runat="server" />
                </div>
            </div>
            <div style="clear: both">
            </div>
            <div style="width: 100%; height: auto; margin-top: 5px">
                <div>
                    <table id="grdShiftRuleDetail">
                    </table>
                </div>
                <div id="grdShiftRuleDetail_pager">
                </div>
            </div>
        </div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?')" OnClick="btnDelete_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
