<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrinterSetup.aspx.cs" Inherits="Hr.Web.Reports.PrinterSetup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <base target="_self" />
</head>
<body height="300px">
    <form id="form1" runat="server">
    <div class="headerDiv">
    </div>
    <div class="pageLogin">
        <div id="divLoginUpper">
            <div class="divLoginContent">
                <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <span class="lblChkBox">Select Printer</span>
                        </div>
                        <div class="divtxtwidth145px">
                            <div>
                                <asp:DropDownList CssClass="txtwidth132px" ID="ddlPrinterName" runat="server"
                                    ValidationGroup="login">
                                </asp:DropDownList>
                                <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPrinterName"
                                    ErrorMessage="Please specify a username" ValidationGroup="login" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
            </div>
            <%--<div class="divLoginContent">
                <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <span class="lblChkBox">No of Copies</span>
                        </div>
                        <div class="divtxtwidth145px">
                            <div>
                                <asp:TextBox ID="txtNoofCopies" runat="server" CssClass="txtwidth132px" ValidationGroup="login"></asp:TextBox>
                                <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNoofCopies"
                                    ErrorMessage="Please specify a username" ValidationGroup="login" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
            </div>--%>
            <div class="divLoginContent">
                <fieldset class="fsPadding5px fs">
                    <legend><span class="lblChkBox">Print Range</span> </legend>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <asp:RadioButton ID="rbAllPages" runat="server" Text="All Pages" GroupName="PrintRange" style="font-size:12px"/>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <asp:RadioButton ID="rbCurrentPage" runat="server" Text="Current Pages" GroupName="PrintRange" style="font-size:12px"/>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <asp:RadioButton ID="RadioButton1" runat="server" Text="From Page" GroupName="PrintRange" style="font-size:12px"/>
                        </div>
                        <div class="divtxtwidth145px">
                            <div>
                                <asp:TextBox ID="txtFromPage" runat="server" CssClass="txtwidth132px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <span class="lblChkBox">To</span>
                        </div>
                        <div class="divtxtwidth145px">
                            <div>
                                <asp:TextBox ID="txtToPage" runat="server" CssClass="txtwidth132px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <div style="height:10px;"></div>
                <div class="divLoginLower">
                    <div class="divStylebtnLoginLeft">
                        <asp:Button CssClass="btnStyleLongLogin" ID="btnOk" runat="server" Text="Ok" ValidationGroup="login"
                            OnClick="btnOk_Click" />
                    </div>
                    <div class="divStylebtnLoginRight">
                        <asp:Button CssClass="btnStyleLongLogin" ID="btnCancel" runat="server" Text="Cancel"
                            OnClientClick="javascript:window.close();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
