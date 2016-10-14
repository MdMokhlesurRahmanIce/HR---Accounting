<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="GroupInformation.aspx.cs" Inherits="Hr.Web.UI.Security.GroupInformation"
    Title="Group Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src='<%= ResolveUrl("~/GridScripts/SecurityRule.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/GridScripts/UserGroup.js") %>' type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
    <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Group Information"></asp:Label>
        </div>
        <div class="form-details">
            <div class="leftDiv25P">
                <div class="lblAndTxt100Pdiv">
                    <asp:Label ID="Label1" runat="server" CssClass="lblStyle">Group Code</asp:Label>
                </div>
                <div class="lblAndTxt100Pdiv">
                    <div style="float: left; width: 76%">
                        <asp:TextBox ID="txtGroupCode" runat="server" CssClass="txt100P"></asp:TextBox>
                    </div>
                    <div style="float: left; margin-left: 5px;">
                        <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png"
                            OnClick="btnNew_Click" />
                        <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png"
                            OnClick="btnFind_Click" />
                    </div>
                </div>
                <div class="lblAndTxt100Pdiv" style="margin-top: 3px;">
                    <asp:Label ID="Label2" runat="server" CssClass="lblStyle">Group Name</asp:Label>
                </div>
                <div class="lblAndTxt100Pdiv">
                    <asp:TextBox ID="txtGroupName" runat="server" CssClass="txt90P"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtGroupName"
                        ErrorMessage="Group Name is Required" ValidationGroup="save" ForeColor="Red"
                        SetFocusOnError="true">*</asp:RequiredFieldValidator>
                </div>
                <div style="clear:both"></div>
                <br />
                <div class="lblAndTxt100Pdiv" style="width: 92%; height: 180px;">
                    <div>
                        <table id="grdSecurityRule">
                        </table>
                    </div>
                    <div id="grdSecurityRule_pager">
                    </div>
                </div>
            </div>
            <div class="rightDiv75P">
                <div class="lblAndTxt100Pdiv" style="margin-top: 5px; width: 92%">
                    <div>
                        <table id="grdUserGroup">
                        </table>
                    </div>
                    <div id="grdUserGroup_pager">
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnRefresh" runat="server" CssClass="button" Text="Refresh" OnClick="btnRefresh_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?')"
                    OnClick="btnDelete_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save"
                    OnClick="btnSave_Click" OnClientClick="CheckValidity();" />
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
