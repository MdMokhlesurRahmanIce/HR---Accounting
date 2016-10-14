<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaveRule.aspx.cs"
    Inherits="Hr.Web.UI.LeaveManagement.LeaveRule" Title="Lotus-12 :: Leave Rule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/grdLeaveRuleDetails.js") %> " type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div class="divLP5" style="width: 40%; float: left; padding-left: 15">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Leave Rule ID</a>
                    </div>
                    <div class="div80Px" style="width: 36%;">
                        <asp:DropDownList ID="ddlLeaveRuleKey" runat="server" Style="visibility: visible;"
                            CssClass="drpwidth157px" AutoPostBack="true" OnSelectedIndexChanged="ddlLeaveRuleKey_SelectedIndexChanged">
                        </asp:DropDownList>
                        <div class="div80Px">
                            <asp:TextBox ID="txtLeaveRule" runat="server" Style="visibility: visible;" CssClass="txtwidth155px">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div style="float: left; margin-left: 5px;">
                        <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle " ImageUrl="~/images/new 20X20.png"
                            OnClick="btnNew_Click" />
                        <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" 
                            ImageUrl="~/images/Search 20X20.png"  />
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Description</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="txtwidth155px">
                        </asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Leave Policy ID</a>
                    </div>
                    <div class="div80Px" style="width: 36%;">
                        <asp:DropDownList ID="ddlLVPolicyId" runat="server" Style="visibility: visible;"
                            CssClass="drpwidth157px" AutoPostBack="true" OnSelectedIndexChanged="ddlLVPolicyId_SelectedIndexChanged">
                        </asp:DropDownList>
                        <a>(Select To Tagg Policy ID)</a>
                    </div>
                </div>
                <div style="width: 100%; float: left">
                    <div style="float: left; width: 99%;">
                        <table id="grdLeaveRuleDetails">
                        </table>
                    </div>
                    <div id="grdLeaveRuleDetails_pager">
                    </div>
                </div>
                <br />
                <br />
            </div>
            <div id="settings" style="width: 60%; float: left">
                <br />
            </div>
            <div style="width: 100%; float: left">
                <br />
            </div>
        </div>
        <div style="clear:both"></div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save"
                    OnClick="btnSave_Click" OnClientClick="CheckValidity();" />
                &nbsp;&nbsp;
                <asp:Button ID="btnClear" runat="server" CssClass="button" Text="Cancel" OnClick="btnClear_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClick="btnDelete_Click"
                    Visible="true" OnClientClick="return confirm('Are you sure you want to delete this record?')" />
            </div>
        </div>
    </div>
</asp:Content>
