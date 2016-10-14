<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="MaternityLeaveTransaction.aspx.cs" Inherits="Hr.Web.UI.LeaveManagement.MaternityLeaveTransaction" %>

<%@ Register Src="~/Controls/SearchEmployee.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
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
                <div id="div4" class="GroupBoxContainer" style="">
                    <div class="GroupBoxTitlebar">
                        <span class="TitlebarCaption">Personal Information:</span>
                    </div>
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
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px2 bglbl">
                                <a>Leave Rule</a>
                            </div>
                            <div class="div80Px" style="float: left;">
                                <asp:TextBox ID="txtLeaveRule" runat="server" CssClass="txtwidth93px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="trn" style="width: 100%; float: left">
                    <div id="div1" class="GroupBoxContainer">
                        <div class="GroupBoxTitlebar">
                            <span class="TitlebarCaption">Maternity Leave Transaction Info:</span>
                        </div>
                        <div>
                        <br />
                            <div style="float: left; width: 20%;">
                                <div>
                                    <a>From Date </a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtwidth155px" Width="100%">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div style="float: left; width: 20%;">
                                <div>
                                    <a>To Date </a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="txtwidth155px" Width="100%">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div style="float: left; width: 25%">
                                <div>
                                    <a>Total Days</a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtTotalDays" runat="server" CssClass="txtwidth155px" Width="100%">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div style="float: left; width: 18%;">
                                <div>
                                    <a>EDD Date</a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtEDDDate" runat="server" CssClass="txtwidth155px" Width="100%">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div>
                            <div style="width: 50%; float: left">
                            <br />
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px" style="width: 20%">
                                        <a>First Payment Mode</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="txtwidth155px" Width="40%">
                                        </asp:TextBox>
                                        <asp:TextBox ID="txtMaternityLeaveRule" runat="server" CssClass="txtwidth155px" Width="35%">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px" style="width: 20%">
                                        <a>Second Payment Mode</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="txtwidth155px" Width="40%">
                                        </asp:TextBox>
                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="txtwidth155px" Width="35%">
                                        </asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 50%; float: left">
                            <br />
                                <div id="div2" class="GroupBoxContainer" style="height: 100px">
                                    <div class="GroupBoxTitlebar">
                                        <span class="TitlebarCaption">Payment Details:</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <br />
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnClear" runat="server" CssClass="button" Text="Cancel" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" />
            </div>
        </div>
    </div>
</asp:Content>
