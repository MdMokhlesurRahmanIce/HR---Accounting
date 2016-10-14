<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="CompanyPolicies.aspx.cs" Inherits="Hr.Web.UI.Setup.CompanyPolicies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
<script src="<%= ResolveUrl("~/GridScripts/CompanyPoliciesFileAttached.js") %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Company Policies"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 35%; float: left">
                <div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Company</a>
                        </div>
                        <div class="div182Px">
                            <asp:DropDownList ID="ddlCompany" runat="server" CssClass="drpwidth180px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlCompany"
                                runat="server" ForeColor="Red" ErrorMessage="Company is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>File</a>
                        </div>
                        <div class="div182Px">
                            <asp:FileUpload ID="fuAttachment" runat="server" />
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Attachment Name</a></div>
                        <div class="div182Px">
                            <asp:TextBox ID="txtFileName" runat="server" CssClass="txtwidth178px" />
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Attach Date</a></div>
                        <div class="div182Px">
                            <asp:TextBox runat="server" ID="txtDate" ReadOnly="true" CssClass="txtwidth178px" />
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Attachment Description</a></div>
                        <div class="div182Px">
                            <asp:TextBox runat="server" CssClass="txtwidth178px allowEnter" ID="txtDescription"
                                TextMode="MultiLine" />
                        </div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div style="float: right; margin-right: 40px;">
                    <asp:Button ID="btnAdd" CssClass="button ef-add" runat="server" Text="Add" OnClick="btnAdd_Click" ValidationGroup="attachment" />
                    <asp:Button ID="btnUpdate" CssClass="button ef-update" Visible="false" runat="server"
                        ValidationGroup="attachment" Text="Update" />
                </div>
                <div class="clear">
                </div>
            </div>
            <div style="width: 50%; float: right">
                <table id="grdCompanyPoliciesFile">
                </table>
                <div id="grdCompanyPoliciesFile_pager">
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfPolicyFileKey" Value="0" runat="server" />
</asp:Content>
