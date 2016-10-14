<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerInfo.aspx.cs"
    Inherits="Hr.Web.UI.Payroll.CustomerInfo" Title="Lotus-12 :: Customer Info" %>

<%@ Register Src="~/Controls/SearchEmployee.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="../../src/Test.js" type="text/javascript"></script>
    <link href="../../src/jquery.ptTimeSelect.css" rel="stylesheet" type="text/css" />
    <script src="../../GridScripts/CustomerWisePerGrid.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 25%; float: left">
                <div id="divTest" class="lblAndTxtStyle" style="width: 99%; margin-left: -5px" runat="server">
                    <div class="divlblwidth100px2 bglbl" style="width: 35%">
                        <a>Fiscal Year</a>
                    </div>
                    <div>
                        <asp:DropDownList ID="ddlLeaveYear" Font-Size="12px" runat="server" CssClass="txtwidth50per">
                        </asp:DropDownList>
                    </div>
                </div>
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
                    <div style="width: 50%; height: auto; float: left">
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
                </div>
                
                <div style="float: left; width: 99%; height: auto">
                 <br />
                  <br />
                    <div class="ui-jqgrid">
                        <table id="grdEmpWisePer">
                        </table>
                    </div>
                    <div id="grdEmpWisePer_pager">
                    </div>
                </div>
            </div>
           
        </div>
        <div style="clear: both">
        </div>
        <br />
        <div class="form-bottom" style="text-align: center">
            
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click" />
            </div>
           
        </div>
        <asp:HiddenField ID="hfLeaveSubstitute" runat="server" />
        <asp:HiddenField ID="hfEmpKey" runat="server" />
    </div>
</asp:Content>
