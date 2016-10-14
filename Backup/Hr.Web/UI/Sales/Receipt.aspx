<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="Receipt.aspx.cs" Inherits="Hr.Web.UI.Sales.Receipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            try {
                $("input[id$='txtVoucherDate_nc']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), yearRange: '2007:2020' });
                $("input[id$='txtChequeDate']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date() });
                $("#<%= txtCashAmount.ClientID %>").keyup(function (event) {
                    //if ($("#cphBody_cphInfbody_txtCreditAmount").val() != "") {
                    Calculation();
                    // }
                });
                $("#<%= txtBankAmount.ClientID %>").keyup(function (event) {
                    //if ($("#cphBody_cphInfbody_txtCreditAmount").val() != "") {
                    Calculation();
                    //}
                });
                $("#cphInfbody_btnDelete").click(function () {
                    if ($("#cphInfbody_txtVoucher").val() != "****<< NEW >>****") {
                        ShowConfirmBox("Confirmation", "This will delete the voucher. Are you sure you want to continue?", "OkButtonClick", "CancelButtonClick");
                        return false;
                    }
                    else {
                        return false;
                    }
                });
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
        });
        function Calculation() {
            var cash = 0;
            var bank = 0;
            var receivableToUL = 0;
            var receivableToCoustomer = 0;
            var creditAmount = 0;
            if ($("#cphBody_cphInfbody_txtCashAmount").val() != "") {
                cash = parseFloat($("#cphBody_cphInfbody_txtCashAmount").val());
            }
            if ($("#cphBody_cphInfbody_txtBankAmount").val() != "") {
                bank = parseFloat($("#cphBody_cphInfbody_txtBankAmount").val());
            }
            $("#cphBody_cphInfbody_txtCreditAmount").val(cash + bank);

            ////            if ($("#cphBody_cphInfbody_txtReceivableToUL").val() != "") {
            ////                receivableToUL = parseFloat($("#cphBody_cphInfbody_txtReceivableToUL").val());
            ////            }
            //            if ($("#cphBody_cphInfbody_txtCreditAmount").val() != "") {
            //                creditAmount = parseFloat($("#cphBody_cphInfbody_txtCreditAmount").val());
            //            }
            //            $("#cphBody_cphInfbody_txtBalance").val(creditAmount - (cash + receivableToUL + receivableToCoustomer));
        }
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
                        <a>Voucher Date</a>
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
                        <a>Voucher No.</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtVoucher" runat="server" CssClass="txtwidth178px" MaxLength="100"
                            Enabled="false"></asp:TextBox>
                    </div>
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
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Cheque No.</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtChequeNo" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Cheque Date</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtChequeDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <a>Voucher Description</a>
                <div class="lblAndTxtStyle">
                    <asp:TextBox ID="txtVoucherDescription" runat="server" CssClass="txtwidth178px" TextMode="MultiLine"
                        MaxLength="500"></asp:TextBox>
                </div>
            </div>
            <div style="width: 49%; float: left">
                <div class="lblAndTxtStyle" style="width: 100%; margin-left: -4px">
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>SO</a>
                        </div>
                        <div class="div80Px" style="width: 54%">
                            <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                        </div>
                        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="btnImageStyle btn-enable ucBtnFind"
                            OnClick="btnFind_Click" ImageUrl="~/images/Search 20X20.png" />
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Due</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtBal" runat="server" CssClass="txtwidth178px" MaxLength="100"
                            Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Receipt From A\C</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlReceiptFromAC_nc" runat="server" Enabled="false" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Cr Amount</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtCreditAmount" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Cash Deposit</a>
                        </div>
                        <div class="div182Px">
                            <asp:DropDownList ID="ddlCashDebit_nc" runat="server" CssClass="drpwidth180px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Cash Amount</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtCashAmount" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Bank Deposit</a>
                        </div>
                        <div class="div182Px">
                            <asp:DropDownList ID="ddlBankDeposit_nc" runat="server" CssClass="drpwidth180px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Bank Amount</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtBankAmount" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hfEmpKey" runat="server" />
            <div class="clear">
            </div>
            <br />
            <br />
            <div class="form-bottom">
                <div class="btnRight">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save"
                        OnClick="btnSave_Click" OnClientClick="CheckValidity();" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnPreview" runat="server" CssClass="button" Text="Preview" Visible="true"
                        OnClick="btnPreview_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
