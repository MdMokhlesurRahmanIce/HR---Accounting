<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PromotionIncrement.aspx.cs"
    Inherits="Hr.Web.UI.EmployeeBasicInfo.PromotionIncrement" Title="Lotus-12 :: Promotion Increment" %>

<%@ Register Src="~/Controls/SearchEmployee.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/IncrementGrid.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready
        (
            function () {
                $("input[id$='txtEffectiveDate']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true });
                $("input[id$='txtNextReviewDate'], .datepicker").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true });
                $("#cphBody_cphInfbody_rdoPromotion").live("click", function () {
                    $(".promotion").show();
                    $(".increment").hide();
                });
                $("#cphBody_cphInfbody_rdoIncrement").live("click", function () {
                    $(".promotion").hide();
                    $(".increment").show();
                });
                $("#cphBody_cphInfbody_rdoBoth").live("click", function () {
                    $(".promotion").show();
                    $(".increment").show();
                });
            }
        );
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 25%; float: left">
                <div style="width: 90%; border: #D7D7D7; float: left;">
                    <asl:ucEmployeeSearch ID="Header1" runat="server" />
                </div>
            </div>
            <div style="width: 74%; height: 99%; float: left">
                <div id="Div1" style="width: 99%; height: auto; float: left">
                    <div style="width: 20%; height: auto; float: left">
                        <fieldset id="garmentPicture" style="margin-left: 0px; height: 150px; width: 120px">
                            <div style="width: 120px; height: 150px">
                                <asp:Image ID="imgGarment" runat="server" Alt="" Height="150px" Width="120px" />
                            </div>
                            <div class="totalDiv">
                                <asp:Label ID="lblPictureNumber" CssClass="lblStyle" Style="padding-left: 55px" runat="server"></asp:Label>
                            </div>
                        </fieldset>
                    </div>
                    <div style="width: 40%; height: auto; float: left">
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl">
                                <a>Employee Name</a>
                            </div>
                            <div class="div80Px" style="float: left;">
                                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="txtwidth93px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl">
                                <a>Designation</a>
                            </div>
                            <div class="div80Px" style="float: left;">
                                <asp:TextBox ID="txtDesignation" runat="server" CssClass="txtwidth93px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl">
                                <a>Staff Category</a>
                            </div>
                            <div class="div80Px" style="float: left;">
                                <asp:TextBox ID="txtStaffCategory" runat="server" CssClass="txtwidth93px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl">
                                <a>DOJ</a>
                            </div>
                            <div class="div80Px" style="float: left;">
                                <asp:TextBox ID="txtDOJ" runat="server" CssClass="txtwidth93px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div style="width: 40%; height: auto; float: left">
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl">
                                <a>Salary Grade</a>
                            </div>
                            <div class="div80Px" style="float: left;">
                                <asp:TextBox ID="txtSalaryGrade" runat="server" CssClass="txtwidth93px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl">
                                <a>Step</a>
                            </div>
                            <div class="div80Px" style="float: left;">
                                <asp:TextBox ID="txtSalaryStep" runat="server" CssClass="txtwidth93px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl">
                                <a>Salary Rule</a>
                            </div>
                            <div class="div80Px" style="float: left;">
                                <asp:TextBox ID="txtSalaryRule" runat="server" CssClass="txtwidth93px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="width: 60%; height: auto; float: left">
                    <br />
                    <div style="width: 33%; float: left">
                        <a>
                            <asp:RadioButton GroupName="Type" ID="rdoPromotion" runat="server" Text="Promotion" />
                        </a>
                    </div>
                    <div style="width: 33%; float: left">
                        <a>
                            <asp:RadioButton GroupName="Type" ID="rdoIncrement" runat="server" Text="Increment" />
                        </a>
                    </div>
                    <div style="width: 33%; float: left">
                        <a>
                            <asp:RadioButton GroupName="Type" ID="rdoBoth" runat="server" Text="Both" Checked="true" />
                        </a>
                    </div>
                    <br />
                </div>
                <div style="width: 99%; height: auto; float: left">
                    <div class="promotion" style="width: 50%; height: auto; float: left">
                        <div style="width: 100%; float: left">
                            <div style="width: 80%; float: left">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px2 bglbl" style="width: 35%">
                                        <a>Promotion Type</a>
                                    </div>
                                    <div class="div80Px" style="float: left;">
                                        <asp:DropDownList ID="ddlPromotionType" runat="server" CssClass="txtwidth93px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px2 bglbl" style="width: 35%">
                                        <a>P. Effective date</a>
                                    </div>
                                    <div class="div80Px" style="float: left;">
                                        <asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="txtwidth93px"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px2 bglbl" style="width: 35%">
                                        <a>Remarks</a>
                                    </div>
                                    <div class="div80Px" style="float: left;">
                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtwidth93px"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px2 bglbl" style="width: 35%">
                                        <a>Next R.Date</a>
                                    </div>
                                    <div class="div80Px" style="float: left;">
                                        <asp:TextBox ID="txtNextReviewDate" runat="server" CssClass="txtwidth93px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                        </div>
                        <br />
                        <div id="divPromotion" style="float: left; width: 100%;" runat="server">
                            <asp:Panel ID="Panel1" runat="server">
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="increment" style="width: 50%; height: auto; float: left">
                        <div style="width: 100%; float: left">
                            <div style="width: 80%; float: left">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px2 bglbl" style="width: 35%">
                                        <a>Increment Type</a>
                                    </div>
                                    <div class="div80Px" style="float: left;">
                                        <asp:DropDownList ID="ddlIncrementType" runat="server" CssClass="txtwidth93px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px2 bglbl" style="width: 35%">
                                        <a>I. Effective date</a>
                                    </div>
                                    <div class="div80Px" style="float: left;">
                                        <asp:TextBox ID="txtIncrementEffectiveDate" runat="server" CssClass="txtwidth93px datepicker"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px2 bglbl" style="width: 35%">
                                        <a>Remarks</a>
                                    </div>
                                    <div class="div80Px" style="float: left;">
                                        <asp:TextBox ID="txtInrementRemarks" runat="server" CssClass="txtwidth93px"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px2 bglbl" style="width: 35%">
                                        <a>Next R.Date</a>
                                    </div>
                                    <div class="div80Px" style="float: left;">
                                        <asp:TextBox ID="txtIncrementNextReviewDate" runat="server" CssClass="txtwidth93px datepicker"></asp:TextBox>
                                    </div>
                                </div>
                                <a style="font-weight: 300">[Post Status]</a>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px2 bglbl" style="width: 35%">
                                        <a>Salary Grade</a>
                                    </div>
                                    <div class="div80Px" style="float: left;">
                                        <asp:DropDownList ID="ddlSalaryGrade" runat="server" CssClass="txtwidth93px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px2 bglbl" style="width: 35%">
                                        <a>Salary Step</a>
                                    </div>
                                    <div class="div80Px" style="float: left;">
                                        <asp:DropDownList ID="ddlSalaryStep" runat="server" CssClass="txtwidth93px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px2 bglbl" style="width: 35%">
                                        <a>Salary Rule</a>
                                    </div>
                                    <div class="div80Px" style="float: left;">
                                        <asp:DropDownList ID="ddlSalaryRule" runat="server" CssClass="txtwidth93px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <br />
                        </div>
                        <br />
                        <div style="float: left; width: 100%;">
                            <div style="float: left;" class="ui-jqgrid">
                                <table id="grdIncrement">
                                </table>
                            </div>
                            <div id="grdIncrement_pager">
                            </div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hfEmpKey" runat="server" />
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnClear" runat="server" CssClass="button" Text="Cancel" OnClick="btnClear_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClick="btnDelete_Click" Visible="false" />
            </div>
        </div>
    </div>
</asp:Content>
