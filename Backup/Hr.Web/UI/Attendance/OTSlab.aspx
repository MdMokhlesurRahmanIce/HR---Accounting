<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="OTSlab.aspx.cs" Inherits="Hr.Web.UI.Attendance.OTSlab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/OTSlab.js") %> " type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 41%">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>OT Slab ID</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtOTSlabID" runat="server" Style="width: 75%;" MaxLength="100"
                            ReadOnly="true"></asp:TextBox>
                        <div style="float: right; margin-left: 5px;">
                            <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png"
                                OnClick="btnNew_Click" />
                            <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png"
                                OnClick="btnFind_Click" />
                        </div>
                        <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidatoryy2"
                            ControlToValidate="txtOTSlabID" runat="server" ValidationGroup="Save" ForeColor="Red"
                            ErrorMessage="OT Slab ID is required">*</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div style="clear: both">
            </div>
            <div style="width: 100%; height: auto; margin-top: 5px">
                <div>
                    <table id="grdOTSlab">
                    </table>
                </div>
                <div id="grdOTSlab_pager">
                </div>
            </div>
        </div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save"
                    OnClick="btnSave_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?')"
                    OnClick="btnDelete_Click" />
            </div>
        </div>
    </div>
</asp:Content>
