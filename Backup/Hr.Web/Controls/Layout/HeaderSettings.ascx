<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderSettings.ascx.cs"
    Inherits="Hr.Web.Controls.Layout.HeaderSettings" %>
<span><a href="#" class="header-settings"></a></span>
<script type="text/javascript">
    function OpenPasswordChangePopupDialog() {
        var oldPass = $('#<%= txtOldPassword.ClientID %>'),
			    newPass = $('#<%= txtNewPassword.ClientID %>'),
			    newRePass = $('#<%= txtReTypePassword.ClientID %>'),
			    allFields = $([]).add(oldPass).add(newPass).add(newRePass),
			    tips = $(".validateTips");

        function updateTips(t) {
            tips
				    .text(t)
				    .addClass("ui-state-highlight");
            setTimeout(function () {
                tips.removeClass("ui-state-highlight", 1500);
            }, 500
			        );
        }
        function checkLength(o, n, min, max) {
            if (o.val().length > max || o.val().length < min) {
                o.addClass("ui-state-error");
                updateTips("Length of " + n + " must be between " +
					    min + " and " + max + ".");
                return false;
            } else {
                return true;
            }
        }
        function checkRegexp(o, regexp, n) {
            if (!(regexp.test(o.val()))) {
                o.addClass("ui-state-error");
                updateTips(n);
                return false;
            } else {
                return true;
            }
        }
        $("#divPassChange").dialog('open');
        $("#divPassChange").dialog
            (
                {
                    title: 'Password Change',
                    height: 250,
                    width: 320,
                    modal: true,
                    zIndex: 10,
                    buttons: {
                        Save: function () {
                            var bValid = true;
                            allFields.removeClass("ui-state-error");

                            if (oldPass.val().length == 0) {
                                oldPass.addClass("ui-state-error");
                                updateTips("Old Password can not blank.");
                                return false;
                            }
                            //					            bValid = bValid && checkLength( oldPass, "Old Password", 1, 16 );	
                            bValid = bValid && checkLength(newPass, "New Password", 5, 16);
                            bValid = bValid && checkRegexp(newPass, /^([0-9a-zA-Z])+$/, "Password field only allow : a-z 0-9");
                            var oldP = $('input#<%= txtOldPassword.ClientID %>').val();
                            var newP = $('input#<%= txtNewPassword.ClientID %>').val();
                            if (bValid) {
                                if ($('input#<%= txtNewPassword.ClientID %>').val() === $('input#<%= txtReTypePassword.ClientID %>').val()) {
                                    //                                        alert('Successfully Saved');
                                    var refSourceString = jQuery.ajax
    	                                (
    	                                    {
    	                                        url: 'GridHelperClasses/DataHandler.ashx?CallMode=ChangePassword&OldPassword=' + oldP + '&NewPassword=' + newP,
    	                                        async: false
    	                                    }
                                        ).responseText;
                                    var splitedString = refSourceString.split(',');
                                    if (splitedString[0] == 'False') {
                                        oldPass.addClass("ui-state-error");
                                    }
                                    updateTips(splitedString[1]);
                                }
                                else {
                                    updateTips('The new passwords do not match');
                                    newPass.addClass("ui-state-error");
                                    newRePass.addClass("ui-state-error");
                                    return false;
                                }
                            }
                        },
                        Cancel: function () {
                            $(this).dialog("close");
                        }
                    },
                    close: function () {
                        allFields.val("").removeClass("ui-state-error");
                    }
                }
            );
    };
</script>
<div class="settings-panel">
    <div class="profile-pic">
    </div>
    <ul>
        <li>
            <%--<asp:HyperLink runat="server" Text="Changed Password" />--%>
            <a id="lblPasswordChange" href="#" class="logoutLink" onclick="OpenPasswordChangePopupDialog();">
                Change Password</a> </li>
        <li>
            <asp:LinkButton ID="lnkLogOut" runat="server" OnClick="lnkLogOut_Click" Visible="true">Log out</asp:LinkButton>
        </li>
    </ul>
</div>
<div id="divPassChange" style="display: none">
    <%--<uc1:PasswordChange ID="ucPasswordChange1" runat="server" />--%>
    <div class="totalDiv">
        <div class="divLeft280Px marginTop divleftmargin15">
            <p class="validateTips">
                All form fields are required.</p>
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <asp:Label ID="Label42" runat="server" CssClass="lblStyle">Old Password</asp:Label>
                </div>
                <div class="divtxtwidth145px">
                    <asp:TextBox ID="txtOldPassword" runat="server" CssClass="txtBoxLong" TextMode="Password"
                        autocomplete="off"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" ErrorMessage="Please Specify Old Password"
                            ControlToValidate="txtOldPassword" ValidationGroup="save">*</asp:RequiredFieldValidator>--%>
                </div>
            </div>
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <asp:Label ID="Label1" runat="server" CssClass="lblStyle">New Password</asp:Label>
                </div>
                <div class="divtxtwidth145px">
                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="txtBoxLong" TextMode="Password"
                        autocomplete="off"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ErrorMessage="Please Specify New Password"
                            ControlToValidate="txtNewPassword" ValidationGroup="save">*</asp:RequiredFieldValidator>--%>
                </div>
            </div>
            <div class="lblAndTxtStyle">
                <div class="divlblwidth100px bglbl">
                    <asp:Label ID="Label2" runat="server" CssClass="lblStyle">Re-type Password</asp:Label>
                </div>
                <div class="divtxtwidth145px">
                    <asp:TextBox ID="txtReTypePassword" runat="server" CssClass="txtBoxLong" TextMode="Password"
                        autocomplete="off"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvReTypePassword" runat="server" ErrorMessage="Please Re-Type New Password"
                            ControlToValidate="txtReTypePassword" ValidationGroup="save">*</asp:RequiredFieldValidator>--%>
                </div>
            </div>
            <%--<div class="lblAndTxtStyle">
                <div class="floatRight" style="margin-right:20px;">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" 
                        ValidationGroup="save" onclick="btnSave_Click" OnClientClick="if(!CheckNewPassword()) return false;"/>
                </div>
            </div>
                <div class="lblAndTxtStyle">
                    <asp:ValidationSummary ID="NewPasswordSave" runat="server" ValidationGroup="save" />
                    <asp:Label ID="lblMassage" runat="server" CssClass="lblStyle"></asp:Label>
                </div>--%>
        </div>
    </div>
</div>
<script type="text/javascript">
    $(function () {
        $(".header-settings").click(function () {
            $('.settings-panel').show();
        });
    })
    $(document).click(function (event) {
        if ($(event.target).closest('.settings-panel , .header-settings').get(0) == null) {
            $(".settings-panel").hide();
        }
    })
</script>
