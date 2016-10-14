<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="HouseKeepingEntry.aspx.cs" Inherits="Hr.Web.UI.SystemConfig.HouseKeepingEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src='<%= ResolveUrl("~/GridScripts/HKEntry.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= ddlEntityType.ClientID %>").change(function (e) {
                var entityKey = $("#<%= ddlEntityType.ClientID %>").val();
                $("#<%= txtHKName.ClientID %>").val('');
                $("#<%= txtShortName.ClientID %>").val('');
                $("#<%= txtDescription.ClientID %>").val('');
                $("#<%= txtAddress.ClientID %>").val('');
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ParentList&EntityKey=' + entityKey,
                    	                async: false
                    	            }
                                ).responseText
                //                alert(retVal);
                //                if (retVal == "0") {
                //                    $('.rightDiv75P').hide();
                //                    return false;
                //                }
                //                else {
                //                    $("#grdHKEntry").trigger("reloadGrid");
                //                    $('.rightDiv75P').show();
                //                    return false;
                //                }
                $("#grdHKEntry").trigger("reloadGrid");
                return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="HK Entry"></asp:Label>
        </div>
        <div class="form-details">
            <div class="leftDiv25P" style="width: 50%">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Entity Type</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlEntityType" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlEntityType"
                            runat="server" ForeColor="Red" ErrorMessage="EntityType is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>HK Name</a>
                    </div>
                    <div class="div80Px" style="width: 57%">
                        <asp:TextBox ID="txtHKName" runat="server" Style="width: 75%;" MaxLength="100"></asp:TextBox>
                        <div style="float: left;">
                            <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle btn-enable" ImageUrl="~/images/new 20X20.png"
                                OnClick="btnNew_Click" OnClientClick="enableControl()" />
                            <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle btn-enable"
                                ImageUrl="~/images/Search 20X20.png" OnClick="btnFind_Click" />
                        </div>
                        <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidatoryy2"
                            ControlToValidate="txtHKName" runat="server" ValidationGroup="Save" ForeColor="Red"
                            ErrorMessage="HK Name is required">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Short Name</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtShortName" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                        <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            ControlToValidate="txtShortName" runat="server" ValidationGroup="Save" ForeColor="Red"
                            ErrorMessage="Short Name is required">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Description</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="txtwidth178px" MaxLength="200"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Address</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="txtwidth178px" MaxLength="300"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <br />
            </div>
            <div class="rightDiv75P" style="width: 50%;">
                <div class="lblAndTxt100Pdiv" style="margin-top: 5px; width: 92%;">
                    <div>
                        <table id="grdHKEntry" style="width: 100%">
                        </table>
                    </div>
                    <div id="grdHKEntry_pager">
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnRefresh" runat="server" CssClass="button" Text="Refresh" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClick="btnDelete_Click"/>
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save"
                    OnClick="btnSave_Click" OnClientClick="CheckValidity();" />
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
    <script>
        $(function () {
            if (isPostBack)
                $(".form-wrapper select, .form-wrapper input:not(.btn-enable)").attr('disabled', true);
        })
        function enableControl() {
            $(".form-wrapper input, .form-wrapper select").removeAttr('disabled');
        }
    </script>
</asp:Content>
