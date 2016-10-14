<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="ContactInfo.aspx.cs" Inherits="Hr.Web.UI.Setup.ContactInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/ContactList.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/ContactCategoryList.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/ContactSubCategoryList.js") %> " type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Contact Info"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 20%; float: left">
                <div>
                    <table id="grdContactList">
                    </table>
                </div>
                <div id="grdContactList_pager">
                </div>
            </div>
            <div style="width: 65%; float: left">
                <div style="width: 45%; float: left; margin-left: 10px">
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>ID</a>
                        </div>
                        <div class="div80Px" style="width: 57%">
                            <asp:TextBox ID="txtID" runat="server" Style="width: 75%;" MaxLength="100"></asp:TextBox>
                            <div style="float: right;">
                                <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle btn-enable" ImageUrl="~/images/new 20X20.png"
                                    OnClientClick="enableControl()" />
                                <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle btn-enable"
                                    OnClick="btnFind_Click" ImageUrl="~/images/Search 20X20.png" />
                            </div>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Name</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtName" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Card No/Code</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtCardNo" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Type</a>
                        </div>
                        <div class="div182Px">
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="drpwidth180px">
                            </asp:DropDownList>
                            <%--                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlType"
                                runat="server" ForeColor="Red" ErrorMessage="Type is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Contact Name</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtContactName" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>VAT Reg. No</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtVATRegNo" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Address</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="txtwidth178px" MaxLength="200"
                                TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div style="width: 50%; float: left">
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>VAT Status</a>
                        </div>
                        <div class="div182Px">
                            <asp:DropDownList ID="ddlVATStatus" runat="server" CssClass="drpwidth180px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlVATStatus"
                                runat="server" ForeColor="Red" ErrorMessage="VAT Status is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Country</a>
                        </div>
                        <div class="div182Px">
                            <asp:DropDownList ID="ddlCountry" runat="server" CssClass="drpwidth180px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlCountry"
                                runat="server" ForeColor="Red" ErrorMessage="Country is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Phone</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Fax</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtFax" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Mobile</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Note</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtNote" runat="server" CssClass="txtwidth178px" MaxLength="200"
                                TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div style="width: 15%; float: left">
                <div>
                    <table id="grdContactCategoryList">
                    </table>
                </div>
                <div id="grdContactCategoryList_pager">
                </div>
                <br />
                <div>
                    <table id="grdContactSubCategoryList">
                    </table>
                </div>
                <div id="grdContactSubCategoryList_pager">
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="form-bottom">
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
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save"
                    OnClick="btnSave_Click" OnClientClick="CheckValidity();" />
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            if (isPostBack)
                $(".form-wrapper select, .form-wrapper input:not(.btn-enable)").attr('disabled', true);
        })
        function enableControl() {
            $(".form-wrapper input, .form-wrapper select").removeAttr('disabled');
        }
    </script>
</asp:Content>
