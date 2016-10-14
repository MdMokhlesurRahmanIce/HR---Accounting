<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="EnterNewAccountPayable.aspx.cs" Inherits="Hr.Web.UI.Purchase.EnterNewAccountPayable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            try {
                $("input[id$='txtVoucherDate_nc']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), yearRange: '2007:2020' });
                $("#cphInfbody_btnSave").click(function () {
                    var retVal = jQuery.ajax
            	        (
            	            {
            	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=CheckTransaction',
            	                async: false
            	            }
                        ).responseText
                    if (retVal == "0") {
                        ShowMessageBox("HR", "To complete the transaction you should need to select account head from grid!");
                        return false;
                    }
                });
            }
            catch (e)
        { alert(e); }
            var bal = 0;
            bal = parseFloat($("#cphBody_cphInfbody_txtBal_nc").val());
            $("#<%= txtDrAmount.ClientID %>").keyup(function (event) {
                var Dr = 0;
                if ($("#cphBody_cphInfbody_txtDrAmount").val() != "")
                    Dr = parseFloat($("#cphBody_cphInfbody_txtDrAmount").val());
                $("#cphBody_cphInfbody_txtBal_nc").val(bal - Dr);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Receipt"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 49%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Voucher No.</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtVoucher" runat="server" CssClass="txtwidth178px" Style="width: 89%;"
                            MaxLength="100" Enabled="false"></asp:TextBox>
                        <div style="float: right; margin-left: 0px;">
                            <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle btn-enable" ImageUrl="~/images/new 20X20.png"
                                OnClick="btnNew_Click" OnClientClick="enableControl()" Visible="true" />
                        </div>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Supplier</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlRecipient_nc" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                    <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                        ControlToValidate="ddlRecipient_nc" runat="server" ValidationGroup="Save" ForeColor="Red"
                        ErrorMessage="Recipient is required">*</asp:RequiredFieldValidator>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Receive Date</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtVoucherDate_nc" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                    <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        ControlToValidate="txtVoucherDate_nc" runat="server" ValidationGroup="Save" ForeColor="Red"
                        ErrorMessage="Voucher Date is required">*</asp:RequiredFieldValidator>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Company</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlCompany_nc" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                    <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                        ControlToValidate="ddlCompany_nc" runat="server" ValidationGroup="Save" ForeColor="Red"
                        ErrorMessage="Company is required">*</asp:RequiredFieldValidator>
                </div>
                <a>Voucher Description</a>
                <div class="lblAndTxtStyle">
                    <asp:TextBox ID="txtVoucherDescription" runat="server" CssClass="txtwidth178px" TextMode="MultiLine"
                        MaxLength="500"></asp:TextBox>
                </div>
            </div>
            <div style="width: 49%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Receive To</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlDebit_nc" runat="server" Enabled="false" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                    <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                        ControlToValidate="ddlDebit_nc" runat="server" ValidationGroup="Save" ForeColor="Red"
                        ErrorMessage="Debit A\C is required">*</asp:RequiredFieldValidator>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Amount</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtDrAmount" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Balance</a>
                    </div>
                    <div class="div80Px">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtBal_nc" runat="server" CssClass="txtwidth178px" MaxLength="100"
                                    Enabled="false"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlRecipient_nc" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <br />
        <br />
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save"
                    OnClick="btnSave_Click" OnClientClick="CheckValidity();" />
                &nbsp;&nbsp;
                <asp:Button ID="btnClear" runat="server" CssClass="button" Text="Cancel" Visible="true"
                    OnClick="btnClear_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnPreview" runat="server" CssClass="button" Text="Preview" Visible="true"
                    OnClick="btnPreview_Click" />
            </div>
        </div>
    </div>
</asp:Content>
