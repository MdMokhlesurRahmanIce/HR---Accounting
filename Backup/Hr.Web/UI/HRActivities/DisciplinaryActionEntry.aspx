<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="DisciplinaryActionEntry.aspx.cs" Inherits="Hr.Web.UI.HRActivities.DisciplinaryActionEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/DisciplinaryActionHistory.js") %> " type="text/javascript"></script>
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
                <div style="float: left; width: 50%">
                    <div style="float: left; width: 60%">
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Employee Code</a>
                            </div>
                             <asp:DropDownList ID="ddlEmpCode" runat="server" Style="visibility: visible;" CssClass="drpwidth157px"
                                    AutoPostBack="true">
                             </asp:DropDownList>
                        </div>
                        <div class="lblAndTxtStyle">
                            <br />
                            <div class="divlblwidth100px bglbl">
                                <a>Code No</a>
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
                                <a>HR Ref</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtHeadOffice" runat="server" CssClass="txtwidth178px">
                                </asp:TextBox>
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
                                <a>Incident Date</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtIncedientDate" runat="server" CssClass="txtwidth178px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Short Note</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtTelePhoneNo" runat="server" TextMode="MultiLine" CssClass="txtwidth178px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="divlblwidth100px bglbl">
                            <a>Law Section</a>
                        </div>
                        <div class="div80Px">
                             <div class="div80Px" style="width: 36%;">
                                <asp:DropDownList ID="DropDownList2" runat="server" Style="visibility: visible;"
                                    CssClass="drpwidth157px" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Law SubSection</a>
                            </div>
                            <div class="div80Px">
                                 <div class="div80Px" style="width: 36%;">
                                <asp:DropDownList ID="DropDownList3" runat="server" Style="visibility: visible;"
                                    CssClass="drpwidth157px" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            </div>
                        </div>
                        <br />
                        <div class="lblAndTxtStyle">
                            <br />
                            <div class="divlblwidth100px bglbl">
                                <a>Action Taken</a>
                            </div>
                            <div class="div80Px" style="width: 36%;">
                                <asp:DropDownList ID="DropDownList1" runat="server" Style="visibility: visible;"
                                    CssClass="drpwidth157px" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>First Letter Issue</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtFirstLetterDate" runat="server" CssClass="txtwidth178px">
                                </asp:TextBox>
                            </div>
                            <br />
                        </div>
                        <div style="float: left">
                            <div style="float: left">
                                <a>Browse the hard copy if any..</a>
                            </div>
                            <asp:FileUpload ID="btnBrowse" runat="server" />
                            <br />
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Reply Receive</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtReplyDate" runat="server" CssClass="txtwidth178px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div style="float: left">
                            <div style="float: left">
                                <a>Browse the hard copy if any..</a>
                            </div>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <br />
                        </div>
                         <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Second Letter</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtSecondLetterDate" runat="server" CssClass="txtwidth178px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div style="float: left">
                            <div style="float: left">
                                <a>Browse the hard copy if any..</a>
                            </div>
                            <asp:FileUpload ID="FileUpload2" runat="server" />
                            <br />
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Sus. From Date</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtSusFrom" runat="server" CssClass="txtwidth178px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Sus. To Date</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtSusTo" runat="server" CssClass="txtwidth178px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>EffectiveDate</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="txtwidth178px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Investigated By</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtContactPerson" runat="server" CssClass="txtwidth178px">
                                </asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="float: left; width: 50%;">
                    <a style="font-size: large; float: right">Disciplinary Action Register</a>
                    <div style="padding-left: 1px; float: left; width: 98%;">
                        <br />
                        <table id="grdDisciplinaryAction">
                        </table>
                    </div>
                    <div id="grdDisciplinaryAction_pager">
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
