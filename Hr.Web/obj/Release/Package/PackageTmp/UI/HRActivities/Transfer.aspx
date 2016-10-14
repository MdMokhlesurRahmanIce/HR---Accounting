<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs"
    Inherits="Hr.Web.UI.HRActivities.Transfer" Title="Lotus-12 :: Transfer" %>

<%@ Register Src="~/Controls/SearchEmployee.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/IncrementGrid.js") %> " type="text/javascript"></script>
    <script src="../../src/Test.js" type="text/javascript"></script>
    <link href="../../src/jquery.ptTimeSelect.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready
        (
            function () {
                $("input[id$='txtEffectiveDate']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true });
                $("input[id$='txtNextReviewDate']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true });
                $("input[id$='txtFromDate']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true });
                $("input[id$='txtToDate']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true });
                $(".tmp").hide();
                $("#cphBody_cphInfbody_rdoTemporary").live("click", function () {
                    $(".tmp").show();
                    $(".per").hide();
                });
                $("#cphBody_cphInfbody_rdoPerment").live("click", function () {
                    $(".tmp").hide();
                    $(".per").show();
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
                <div style="width: 80%; float: left">
                    <div style="width: 50%; float: left">
                        <br />
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl">
                                <a>Transfer Type</a>
                            </div>
                            <div class="div80Px" style="float: left;">
                                <asp:DropDownList ID="ddlTransferType" runat="server" CssClass="txtwidth93px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div style="width: 33%; float: left">
                            <a>
                                <asp:RadioButton GroupName="Transfer" ID="rdoPerment" runat="server" Text="Permanet"
                                    Checked="true" />
                            </a>
                        </div>
                        <div style="width: 33%; float: left">
                            <a>
                                <asp:RadioButton GroupName="Transfer" ID="rdoTemporary" runat="server" Text="Temporary" />
                            </a>
                        </div>
                        <div class="lblAndTxtStyle per">
                            <div class="divlblwidth100px2 bglbl">
                                <a>Effective date</a>
                            </div>
                            <div class="div80Px" style="width: 40%; float: left;">
                                <asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="txtwidth93px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle tmp" style="width: 40%; float: left;">
                            <div class="divlblwidth100px2 bglbl">
                                <a>From Date</a>
                            </div>
                            <div class="divlblwidth90per">
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="drpwidth99per" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle tmp" style="width: 40%; float: left">
                            <div class="divlblwidth100px2 bglbl">
                                <a>To Date</a>
                            </div>
                            <div class="divlblwidth90per">
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="drpwidth99per" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div style="width: 50%; float: left">
                        <br />
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl">
                                <a>Remarks</a>
                            </div>
                            <div class="div80Px" style="width: 40%; float: left;">
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl">
                                <a>Next Review Date</a>
                            </div>
                            <div class="div80Px" style="width: 40%; float: left;">
                                <asp:TextBox ID="txtNextReviewDate" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div id="divTransfer" style="float: left; width: 100%;" runat="server">
                        <asp:Panel ID="Panel1" runat="server">
                        </asp:Panel>
                    </div>
                </div>
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
        <asp:HiddenField ID="hfEmpKey" runat="server" />
    </div>
</asp:Content>
