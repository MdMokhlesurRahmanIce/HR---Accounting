<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="BonusPolicyDeclaration.aspx.cs" Inherits="Hr.Web.UI.HRActivities.BonusPolicyDeclaration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/BonusPolicyConfig.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 100%; height: auto; margin-top: 5px">
                <div style="float: left; width: 40%">
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Bonus Code</a>
                        </div>
                        <div class="div80Px" style="width: 53%">
                            <asp:TextBox ID="txtBonusCode" runat="server" CssClass="drpwidth180px">
                            </asp:TextBox>
                        </div>
                        <div style="float: right; margin-left: 5px;">
                            <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png"
                                OnClick="btnNew_Click" />
                            <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" OnClick="btnFind_Click" />
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Bonus Name</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtBonusName" runat="server" CssClass="drpwidth180px">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Bonus Type</a>
                        </div>
                        <div class="div80Px">
                            <asp:DropDownList ID="ddlBonusType" runat="server" Style="visibility: visible;" CssClass="drpwidth180px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Description</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="txtwidth178px">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Avail From</a>
                        </div>
                        <div class="div80Px">
                            <asp:DropDownList ID="ddlAvailFrom" runat="server" Style="visibility: visible;" CssClass="drpwidth180px">
                                <asp:ListItem Value1="0" Text="DOJ"></asp:ListItem>
                                <asp:ListItem Value1="1" Text="DOC"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>After Days</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtAfterDays" runat="server" CssClass="txtwidth178px">
                            </asp:TextBox>
                        </div>
                    </div>
                </div>
                <div style="float: left; width: 60%;">
                    <div style="padding-left: 1px; float: left; width: 98%;">
                        <table id="grdBonusPolicy">
                        </table>
                    </div>
                    <div id="grdBonusPolicy_pager">
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <br />
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClick="btnDelete_Click"/>
            </div>
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save"
                    OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
