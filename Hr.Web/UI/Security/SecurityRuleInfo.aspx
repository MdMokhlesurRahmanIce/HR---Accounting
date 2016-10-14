<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="SecurityRuleInfo.aspx.cs" Inherits="Hr.Web.UI.Security.SecurityRuleInfo"
    Title="Security Rule Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src='<%= ResolveUrl("~/GridScripts/MenuItem.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= cboApplication.ClientID %>").change(function (e) {
                var applicationID = $("#<%= cboApplication.ClientID %>").val();
                var retVal = jQuery.ajax
        	        (
        	            {
        	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=PopulateGrideWithMenu&ApplicationID=' + applicationID,
        	                async: false
        	            }
                    ).responseText;
                $("#cphBody_cphInfbody_grdMenuItem").trigger("reloadGrid");
                return false;
            });
            $("#<%= chkSelect.ClientID %>").click(function (e) {
                var chkOrUnchk = $(this).is(':checked');
                var retVal = jQuery.ajax
                            (
                                {
                                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllSelectCheckedOrUnchecked&ChkOrUnchk=' + chkOrUnchk,
                                    async: false
                                }
                            ).responseText
                $("#cphBody_cphInfbody_grdMenuItem").trigger("reloadGrid");
            });
            $("#<%= chkInsert.ClientID %>").click(function (e) {
                var chkOrUnchk = $(this).is(':checked');
                var retVal = jQuery.ajax
                            (
                                {
                                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllInsertCheckedOrUnchecked&ChkOrUnchk=' + chkOrUnchk,
                                    async: false
                                }
                            ).responseText
                $("#cphBody_cphInfbody_grdMenuItem").trigger("reloadGrid");
            });
            $("#<%= chkUpdate.ClientID %>").click(function (e) {
                var chkOrUnchk = $(this).is(':checked');
                var retVal = jQuery.ajax
                            (
                                {
                                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllUpdateCheckedOrUnchecked&ChkOrUnchk=' + chkOrUnchk,
                                    async: false
                                }
                            ).responseText
                $("#cphBody_cphInfbody_grdMenuItem").trigger("reloadGrid");
            });
            $("#<%= chkDelete.ClientID %>").click(function (e) {
                var chkOrUnchk = $(this).is(':checked');
                var retVal = jQuery.ajax
                            (
                                {
                                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllDeleteCheckedOrUnchecked&ChkOrUnchk=' + chkOrUnchk,
                                    async: false
                                }
                            ).responseText
                $("#cphBody_cphInfbody_grdMenuItem").trigger("reloadGrid");
            });
        });
        function GetApplicationID(applicationID) {
            //alert(applicationID);
            document.getElementById('<%= hfApplicationID.ClientID %>').value = applicationID;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Security Role"></asp:Label>
        </div>
        <div class="form-details">
            <div class="leftDiv25P">
                <div class="lblAndTxt100Pdiv">
                    <asp:Label ID="Label1" runat="server" CssClass="lblStyle">Role Code</asp:Label>
                </div>
                <div class="lblAndTxt100Pdiv">
                    <div style="float: left; width: 77%">
                        <asp:TextBox ID="txtSecurityRuleCode" runat="server" CssClass="txt100P"></asp:TextBox>
                    </div>
                    <div style="float: left; margin-left: 5px">
                        <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png"
                            OnClick="btnNew_Click" />
                        <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png"
                            OnClick="btnFind_Click" />
                    </div>
                </div>
                <div class="lblAndTxt100Pdiv">
                    <asp:Label ID="Label2" runat="server" CssClass="lblStyle">Role Name</asp:Label>
                </div>
                <div class="lblAndTxt100Pdiv">
                    <asp:TextBox ID="txtSecurityRuleName" runat="server" CssClass="txt90P"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSecurityRuleName"
                        ErrorMessage="Security Rule Name is Required" ValidationGroup="save" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                </div>
                <div class="lblAndTxt100Pdiv">
                    <asp:Label ID="lblApplication" runat="server" CssClass="lblStyle">Application</asp:Label>
                </div>
                <div class="lblAndTxt100Pdiv">
                    <asp:DropDownList ID="cboApplication" runat="server" CssClass="ddl90P">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cboApplication"
                        ErrorMessage="Company is Required" ValidationGroup="save" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="rightDiv75P" style="margin-top: 0px">
                <div class="lblStyle" style="float: right; margin-right: 2px;">
                    <div>
                        <asp:CheckBox ID="chkSelect" Text="Select All" runat="server" />
                        <asp:CheckBox ID="chkInsert" Text="Insert All" runat="server" />
                        <asp:CheckBox ID="chkUpdate" Text="Update All" runat="server" />
                        <asp:CheckBox ID="chkDelete" Text="Delete All" runat="server" />
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div>
                    <table id="grdMenuItem" runat="server">
                    </table>
                </div>
                <div id="grdMenuItem_pager">
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <br />
        <div class="form-bottom">
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
            <div class="btnRight">
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="button" OnClick="btnRefresh_Click" />
            </div>
        </div>
        <asp:HiddenField ID="hfApplicationID" runat="server" />
    </div>
</asp:Content>
