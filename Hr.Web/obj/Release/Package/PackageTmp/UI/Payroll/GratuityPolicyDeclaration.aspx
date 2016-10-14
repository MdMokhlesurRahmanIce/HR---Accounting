<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="GratuityPolicyDeclaration.aspx.cs" Inherits="Hr.Web.UI.Payroll.GratuityPolicyDeclaration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/GratuityGrid.js") %> " type="text/javascript"></script>
 <script type="text/javascript">
     $(document).ready(function () {
         $("input[id$='txtIncedientDate']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), dateFormat: 'mm/dd/yy' });
         $("input[id$='txtFirstLetterDate']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), dateFormat: 'mm/dd/yy' });
         $("input[id$='txtReplyDate']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), dateFormat: 'mm/dd/yy' });
         $("input[id$='txtSecondLetterDate']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), dateFormat: 'mm/dd/yy' });
         $("input[id$='txtSusFrom']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), dateFormat: 'mm/dd/yy' });
         $("input[id$='txtSusTo']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), dateFormat: 'mm/dd/yy' });
         $("input[id$='txtEffectiveDate']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), dateFormat: 'mm/dd/yy' });
         
             });
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 100%; height: auto; margin-top: 5px">
                <div style="float: left; width: 35%">
                    <div style="float: left; width: 100%">
                        
                        <div class="lblAndTxtStyle">
                            <br />
                            <div class="divlblwidth100px bglbl">
                                <a>Gratuity Rule Code</a>
                            </div>
                            <div class="div80Px" style="width: 24%;">
                                <asp:DropDownList ID="ddlBankName" runat="server" Style="visibility: visible;" CssClass="drpwidth157px"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtBankName" runat="server" Visible="false" CssClass="txtwidth155px">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div style="float: right; margin-left: 5px;">
                                <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png" />
                                <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" />
                            </div>
                        </div>
                      
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Description</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="txtwidth178px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Effective Date</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtHeadOffice" runat="server" CssClass="txtwidth178px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Eligible After</a>
                            </div>
                             <asp:DropDownList ID="DropDownList4" runat="server" Style="visibility: visible;" CssClass="drpwidth157px"
                                    AutoPostBack="true">
                             </asp:DropDownList>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>After Years</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" CssClass="txtwidth178px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Employee Category</a>
                            </div>
                             <asp:DropDownList ID="DropDownList5" runat="server" Style="visibility: visible;" CssClass="drpwidth157px"
                                    AutoPostBack="true">
                             </asp:DropDownList>
                        </div>
                       
                        
                    </div>
                </div>
                <div style="float: left; width: 65%;">
                    <a style="font-size: large; float: right">Policy Configure</a>
                    <div style="padding-left: 1px; float: left; width: 98%;">
                        <br />
                        <table id="grdGratuityPolicy">
                        </table>
                    </div>
                    <div id="grdGratuityPolicy_pager">
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <br />
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" />
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
