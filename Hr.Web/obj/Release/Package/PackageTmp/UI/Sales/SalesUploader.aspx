<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="SalesUploader.aspx.cs" Inherits="Hr.Web.UI.Sales.SalesUploader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/SalesUploadFromExcel.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/SalesMessage.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            try {
                $("input[id$='txtVoucherDate_nc']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), yearRange: '2007:2020' });
            }
            catch (e)
        { alert(e); }
        });

        function OpenSalesUploadPopupDialog() {
            //$("#grdEmailMessage").jqGrid('setGridParam', { postData: { filters: ''} }).trigger("reloadGrid");
            $("#grdErrorList").trigger("reloadGrid");
            $("#divErrorList").dialog('open');
            $("#divErrorList").dialog
               (
                    {
                        title: "Messages",
                        height: 360,
                        width: 650,
                        modal: true,
                        zIndex: 10
                    }
               )
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Sales Upload from Excel"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 42%; float: left">
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
            <div style="width: 50%; float: left">
                <asp:Label ID="UploadStatusLabel" runat="server" />
                <asp:Label ID="LengthLabel" runat="server" />
                <fieldset>
                    <legend><strong>Select a file to upload</strong></legend>
                    <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
                    <br />
                    <br />
                    <asp:Button ID="UploadButton" Text="Upload file" OnClick="UploadButton_Click" runat="server">
                    </asp:Button>
                </fieldset>
                <br />
                <br />
            </div>
            <div style="width: 100%; float: left">
                <div style="float: left; width: 99%;">
                    <table id="grdSalesUploadFromExcel">
                    </table>
                </div>
                <div id="grdSalesUploadFromExcel_pager">
                </div>
            </div>
            <div style="clear: both">
            </div>
            <div class="form-bottom">
                <div class="btnRight">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save"
                        OnClick="btnSave_Click" OnClientClick="CheckValidity();" />
                </div>
                <div class="btnRight">
                    <input type="submit" class="button" onclick="OpenSalesUploadPopupDialog(); return false;"
                        value="Log File" />
                </div>
            </div>
        </div>
        <div id="divErrorList" style="display: none">
            <div>
                <table id="grdErrorList">
                </table>
            </div>
            <div id="grdErrorList_pager">
            </div>
        </div>
    </div>
</asp:Content>
