<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="LoanType.aspx.cs" Inherits="Hr.Web.UI.Payroll.LoanType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 100%; height: auto; margin-top: 5px">
                <div style="float: left; width: 40%">
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Loan Type</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtLoanType" runat="server" CssClass="txtwidth93px" Style="width: 80%;"
                                MaxLength="100"></asp:TextBox>
                            <div style="float: right; margin-left: 5px;">
                                <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png" OnClick="btnNew_Click" />
                                <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png" OnClick="btnFind_Click" />
                            </div>
                            <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                ControlToValidate="txtLoanType" runat="server" ValidationGroup="Save" ForeColor="Red"
                                ErrorMessage="Loan Type is required">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                   
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Description</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="txtwidth93px" MaxLength="200"
                                TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Maximum Perchentage</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtMaximumPercenttage" runat="server" CssClass="txtwidth93px" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                     <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Salary Head</a>
                        </div>
                        <div class="div182Px">
                        <asp:DropDownList ID="ddlSalaryHead" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                    </div>
                </div>
               
            </div>
        </div>
        <div style="clear:both">
        </div>
        <br />
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete"/>
            </div>
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" OnClick="btnCancel_Click"/>
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
