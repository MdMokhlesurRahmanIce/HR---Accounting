<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLoggedOff.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Hr.Web.UI.Security.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script type="text/javascript">
        function capLock(e) {
            kc = e.keyCode ? e.keyCode : e.which;
            sk = e.shiftKey ? e.shiftKey : ((kc == 16) ? true : false);
            if (((kc >= 65 && kc <= 90) && !sk) || ((kc >= 97 && kc <= 122) && sk))
                document.getElementById('divCaps').innerHTML = 'Warning: Caps Lock is On!';
            else
                document.getElementById('divCaps').innerHTML = '';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="access-shell">
        <div class="access-header">
            <span>AB</span>C<span> ENTER</span>PRISE
        </div>
        <div class="access-body">
            <div id="tab-login">
                <div class="divMessage">
                    <asp:ValidationSummary ID="ValidationSummary1" CssClass="error" runat="server" ValidationGroup="login" />
                    <asp:Label ID="lblServerMsg" runat="server" Visible="false" Text="" CssClass="error"></asp:Label>
                </div>
                <div class="clear">
                    <div class="divStyleTxtAndDrpLogin">
                        <asp:TextBox CssClass="txtStyleLongLogin" ID="txtLoginName" runat="server" ValidationGroup="login"
                            placeholder="User Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoginName"
                            ErrorMessage="Please specify a username" ValidationGroup="login" ForeColor="Red"
                            SetFocusOnError="true">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="divStyleTxtAndDrpLogin">
                        <asp:TextBox CssClass="txtStyleLongLogin" ID="txtLoginPassword" runat="server" TextMode="Password"
                            placeholder="●●●●●●●●" autocomplete="off" ValidationGroup="login" onkeypress="capLock(event);"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLoginPassword"
                            ErrorMessage="Please specify a password" ValidationGroup="login" ForeColor="Red"
                            SetFocusOnError="true">*</asp:RequiredFieldValidator>
                    </div>
                    <div id='divCaps' style="color: Red; padding-top: 2px;">
                    </div>
                    <p>
                        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Connect"
                            ValidationGroup="login" CssClass="button" />
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
