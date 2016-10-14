<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="Voucher.aspx.cs" Inherits="Hr.Web.UI.ACC.Voucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/Voucher.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            try {
                $("input[id$='txtVoucherDate_nc']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), yearRange: '2007:2020' });
                $("input[id$='txtChequeDate']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date() });
                $("#cphBody_cphInfbody_ddlVoucherType_nc").change(function () {
                    var type = $("#cphBody_cphInfbody_ddlVoucherType_nc option:selected").text();
                    if (type == "BP" || type == "BR") {
                        $("#cphBody_cphInfbody_txtChequeNo").attr("disabled", false);
                        $("#cphBody_cphInfbody_txtChequeDate").attr("disabled", false);
                    }
                    else {
                        $("#cphBody_cphInfbody_txtChequeNo").attr("disabled", true);
                        $("#cphBody_cphInfbody_txtChequeDate").attr("disabled", true);
                    }
                });
                $("#cphBody_cphInfbody_btnDelete").click(function () {
                    if ($("#cphBody_cphInfbody_txtVoucher").val() != "****<< NEW >>****") {
                        ShowConfirmBox("Confirmation", "This will delete the voucher. Are you sure you want to continue?", "OkButtonClick", "CancelButtonClick");
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                $("#cphBody_cphInfbody_btnSave").click(function () {
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

                $("#cphBody_cphInfbody_btnAddOrEdit").click(function () {
                    var drHead = $("#cphBody_cphInfbody_ddlDebit").val();
                    var drAmount = $("#cphBody_cphInfbody_txtDrAmount").val();
                    var crHead = $("#cphBody_cphInfbody_ddlCredit").val();
                    var crAmount = $("#cphBody_cphInfbody_txtCreditAmount").val();
                    var retVal = jQuery.ajax
            	        (
            	            {
            	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AddOrEditVoucher&drHead=' + drHead + '&drAmount=' + drAmount + '&crHead=' + crHead + '&crAmount=' + crAmount,
            	                async: false
            	            }
                        ).responseText
                    $("#grdPFVoucher").trigger("reloadGrid");
                    return false;
                });
            }
            catch (e)
        { alert(e); }
        });
        function CancelButtonClick() {
            return false;
        }
        function OkButtonClick() {
            __doPostBack("vou_delete");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Voucher"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 49%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Voucher Type</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlVoucherType_nc" runat="server" CssClass="drpwidth180px"
                            OnSelectedIndexChanged="ddlVoucherType_nc_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                        ControlToValidate="ddlVoucherType_nc" runat="server" ValidationGroup="Save" ForeColor="Red"
                        ErrorMessage="Voucher Type is required">*</asp:RequiredFieldValidator>
                </div>
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
                        <asp:TextBox ID="txtVoucher" runat="server" CssClass="txtwidth178px" Style="width: 89%;"
                            MaxLength="100" Enabled="false"></asp:TextBox>
                        <div style="float: right; margin-left: 0px;">
                            <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle btn-enable" ImageUrl="~/images/new 20X20.png"
                                OnClick="btnNew_Click" OnClientClick="enableControl()" Visible="false" />
                            <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle btn-enable"
                                OnClick="btnFind_Click" ImageUrl="~/images/Search 20X20.png" />
                        </div>
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
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Payee/Recipient</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtPayeeOrRecipient" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
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
                        <a>Debit A\C</a>
                    </div>
                    <div class="div182Px">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlDebit" runat="server" CssClass="drpwidth180px">
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlVoucherType_nc" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Dr Amount</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtDrAmount" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Credit A\C</a>
                    </div>
                    <div class="div182Px">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlCredit" runat="server" CssClass="drpwidth180px">
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlVoucherType_nc" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Cr Amount</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtCreditAmount" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div style="width: 100%; text-align: right">
                    <asp:Button ID="btnAddOrEdit" runat="server" CssClass="button" Text="Add/Edit" />
                </div>
                <div style="clear: both">
                </div>
                <br />
                <div>
                    <table id="grdPFVoucher">
                    </table>
                </div>
                <div id="grdPFVoucher_pager">
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
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" Visible="true"
                    OnClick="btnDelete_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnPreview" runat="server" CssClass="button" Text="Preview" Visible="true"
                    OnClick="btnPreview_Click" />
            </div>
        </div>
    </div>
</asp:Content>
