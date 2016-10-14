<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="UserInformation.aspx.cs"
    Inherits="Hr.Web.UI.Security.UserInformation" Title="User Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src='<%= ResolveUrl("~/GridScripts/UserGroupList.js") %>' type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="User Information"></asp:Label>
        </div>
        <div class="form-details">
            <div class="leftDiv40P" style="float: left;">
                <div class="lblAndTxt100Pdiv">
                    <asp:Label ID="lblCompany" runat="server" CssClass="lblStyle">User Code</asp:Label>
                </div>
                <div class="lblAndTxt100Pdiv">
                    <div style="float: left; width: 80%">
                        <asp:TextBox ID="txtUserCode" runat="server" CssClass="txt100P" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div style="float: left; margin-left: 5px;">
                        <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png"
                            OnClick="btnNew_Click" />
                        <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png"
                            OnClick="btnFind_Click" />
                    </div>
                </div>
                <div class="lblAndTxt100Pdiv">
                    <asp:Label ID="Label1" runat="server" CssClass="lblStyle">Employee Name</asp:Label>
                </div>
                <div class="lblAndTxt100Pdiv">
                    <div style="float: left; width: 88%">
                        <asp:DropDownList ID="ddlEmpCode" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                        <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                            ControlToValidate="ddlEmpCode" runat="server" ForeColor="Red" ErrorMessage="Employee Code is required"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </div>
                    <div style="float: left;">
                        <asp:ImageButton ID="btnEmpFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" OnClick="btnEmpFind_Click" />
                    </div>
                </div>
                <div class="lblAndTxt100Pdiv">
                    <asp:Label ID="Label4" runat="server" CssClass="lblStyle">Display Name</asp:Label>
                </div>
                <div class="lblAndTxt100Pdiv">
                    <asp:TextBox ID="txtName" runat="server" CssClass="txt90P"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtName"
                        ErrorMessage="Name is Required" ValidationGroup="save" SetFocusOnError="true"
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div class="lblAndTxt100Pdiv">
                    <asp:Label ID="Label5" runat="server" CssClass="lblStyle">Username</asp:Label>
                </div>
                <div class="lblAndTxt100Pdiv">
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="txt90P"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                        ErrorMessage="User Name is Required" ValidationGroup="save" SetFocusOnError="true"
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div class="lblAndTxt100Pdiv">
                    <div class="leftDiv50P">
                        <asp:Label ID="Label6" runat="server" CssClass="lblStyle">Password</asp:Label>
                    </div>
                    <div class="leftDiv50P">
                        <asp:Label ID="Label11" runat="server" CssClass="lblStyle">Retype Password</asp:Label>
                    </div>
                </div>
                <div class="lblAndTxt100Pdiv">
                    <div class="leftDiv50P">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="txt90P" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                            ErrorMessage="Password is Required" ValidationGroup="save" SetFocusOnError="true"
                            ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="leftDiv50P" style="margin-left: 1px;">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="txt90P" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword"
                            ErrorMessage="Confirm Password is Required" ValidationGroup="save" SetFocusOnError="true"
                            ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                </div>

            </div>
            <div style="float: left; width: 50%">
                <fieldset style="border-color: #BBBBBB; border-width: 1px">
                    <legend style="font-size: 12px">User Category</legend>
                    <div class="lblAndTxt100Pdiv">
                        <div class="leftDiv50P">
                            <asp:CheckBox ID="chkAdminUser" runat="server" CssClass="cbStyle" />
                            <asp:Label ID="Label9" runat="server" CssClass="lblStyle">Admin User</asp:Label>
                        </div>
                        <div class="leftDiv50P">
                            <asp:CheckBox ID="chkActiveUser" runat="server" CssClass="cbStyle" />
                            <asp:Label ID="Label10" runat="server" CssClass="lblStyle">Active User</asp:Label>
                        </div>
                    </div>
                </fieldset>
                <div style="clear: both">
                </div>
                <div style="width: 100%; height: auto; margin-top: 5px">
                    <div>
                        <table id="grdUserGroupList">
                        </table>
                    </div>
                    <div id="grdUserGroupList_pager">
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
        </div>
    </div>
</asp:Content>
