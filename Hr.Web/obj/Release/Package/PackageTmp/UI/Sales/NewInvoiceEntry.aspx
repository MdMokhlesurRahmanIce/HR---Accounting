<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="NewInvoiceEntry.aspx.cs" Inherits="Hr.Web.UI.Sales.NewInvoiceEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            try {
                $("input[id$='txtVoucherDate_nc']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), yearRange: '2007:2020' });
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


            var retVal = jQuery.ajax
            	        (
            	            {
            	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=GetCommissionAndVATPercent',
            	                async: false
            	            }
                        ).responseText
            var items = retVal.split(',');
            var commissionPercent = items[0];
            var VATPercent = items[1];
            var InventoryPercent = items[2];
            $("#<%= txtGrossSales.ClientID %>").keyup(function (event) {
                var inventory = 0;
                var vat = 0;
                var commission = 0;
                var grossSales = 0;
                if ($("#cphBody_cphInfbody_txtGrossSales").val() != "") {
                    grossSales = parseFloat($("#cphBody_cphInfbody_txtGrossSales").val());
                    commission = (grossSales * parseFloat(commissionPercent)) / 100;
                    $("#cphBody_cphInfbody_txtCommission").val(commission.toFixed(2));
                    vat = (grossSales * parseFloat(VATPercent)) / 100;
                    $("#cphBody_cphInfbody_txtVAT").val(vat.toFixed(2));
                    inventory = (grossSales * parseFloat(InventoryPercent)) / 100;
                    $("#cphBody_cphInfbody_txtCrAmount").val(inventory.toFixed(2))
                    //$("#cphBody_cphInfbody_txtGrossSales").val(inventory + commission + vat);
                }
                else {
                    $("#cphBody_cphInfbody_txtCommission").val(0);
                    $("#cphBody_cphInfbody_txtVAT").val(0);
                    $("#cphBody_cphInfbody_txtGrossSales").val(0);
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Create Receivable"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 49%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Voucher No.</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtVoucher" runat="server" CssClass="txtwidth178px" MaxLength="100"
                            Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle" style="width: 100%; margin-left: -4px">
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>SO</a>
                        </div>
                        <div class="div80Px" style="width: 54%">
                            <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                        </div>
                        <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle btn-enable ucBtnFind"
                            OnClick="btnFind_Click" ImageUrl="~/images/Search 20X20.png" />
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Sales Date</a>
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
                        <a>Gross Sales</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtGrossSales" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Inventory</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtCrAmount" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Commission</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtCommission" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>VAT</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtVAT" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>SO/JSO A\C</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtReceivableAmount" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>UNILEVER A\C COMM</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtUnileverComm" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>UNILEVER A\C FREE SALES</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtUnileverFreeSales" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
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
                <asp:Button ID="btnClear" runat="server" CssClass="button" Text="Cancel" Visible="true"
                    OnClick="btnClear_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnPreview" runat="server" CssClass="button" Text="Preview" Visible="true"
                    OnClick="btnPreview_Click" />
            </div>
        </div>
    </div>
</asp:Content>
