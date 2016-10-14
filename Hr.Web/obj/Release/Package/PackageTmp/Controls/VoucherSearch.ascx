<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VoucherSearch.ascx.cs" Inherits="Hr.Web.Controls.VoucherSearch" %>
<script type="text/javascript">
    $(document).ready(function () {
        try {
            $("input[id$='txtDateFrom']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), maxDate: 0 });
            $("input[id$='txtDateTo']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), maxDate: 0 });
        }
        catch (e)
        { alert(e); }
    });
</script>
<div>
    <div style="width: 50%; float: left">
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Date From</a>
            </div>
            <div class="div182Px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="txtwidth178px"></asp:TextBox>
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Date To</a>
            </div>
            <div class="div182Px">
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="txtwidth178px"></asp:TextBox>
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Voucher Type</a>
            </div>
            <div class="div182Px">
                <asp:DropDownList ID="ddlVoucherType" runat="server" CssClass="drpwidth180px">
                </asp:DropDownList>
            </div>
        </div>
       <%-- new drop down--%>
         <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Sales Officer</a>
            </div>
            <div class="div182Px">
                <asp:DropDownList ID="ddlSO" runat="server" CssClass="drpwidth180px">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div style="width: 50%; float: left">
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Voucher No.</a>
            </div>
            <div class="div182Px">
                <asp:TextBox ID="txtVoucherNo" runat="server" CssClass="txtwidth178px"></asp:TextBox>
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Pay/Recipient</a>
            </div>
            <div class="div182Px">
                <asp:TextBox ID="txtPayOrRecipient" runat="server" CssClass="txtwidth178px"></asp:TextBox>
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Voucher Description</a>
            </div>
            <div class="div182Px">
                <asp:TextBox ID="txtVoucherDescription" runat="server" CssClass="txtwidth178px"></asp:TextBox>
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Company</a>
            </div>
            <div class="div182Px">
                <asp:DropDownList ID="ddlCompany" runat="server" CssClass="drpwidth180px">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div style="clear:both"></div>
    <div style="width: 100%;">
        <div style="width: 45%; float: left">.
            <div class="hidePostOrNonPost" style="width: 33%; float: left">
                <asp:RadioButton GroupName="VoucherSearch" ID="rdoNonPosted" runat="server" Text="Non-Posted"
                    Checked="true" Visible="false" />
            </div>
            <div class="hidePostOrNonPost" style="width: 33%; float: left">
                <asp:RadioButton GroupName="VoucherSearch" ID="rdoPosted" runat="server" Text="Posted"  Visible="false" />
            </div>
        </div>
        <div style="width: 50%; float: left">
            <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search" />
        </div>
    </div>
</div>