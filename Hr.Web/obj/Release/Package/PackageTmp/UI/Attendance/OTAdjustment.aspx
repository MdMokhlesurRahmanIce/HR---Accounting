<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="OTAdjustment.aspx.cs" Inherits="Hr.Web.UI.Attendance.OTAdjustment" %>

<%@ Register Src="~/Controls/ucEmpSearch.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmpList.ascx" TagName="ucEmpList" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#cphBody_cphInfbody_btnView").click(function (e) {
                var spName = "spGetEmpForSearch1";
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllEmpForCalendar&SpName=' + spName,
                    	                async: false
                    	            }
                                ).responseText
                $("#grdCalendar").trigger("reloadGrid");
                return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="OT Adjustment"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 31%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>From Date</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtwidth178px" Width="190px"
                            MaxLength="100"></asp:TextBox>
                        <!-- <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator13"
                            ControlToValidate="txtFromDate" runat="server" ForeColor="Red" ErrorMessage="From date is required"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>-->
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>To Date</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="txtwidth178px datePicker" Width="190px"
                            MaxLength="100"></asp:TextBox>
                        <!-- <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            ControlToValidate="txtToDate" runat="server" ForeColor="Red" ErrorMessage="To date is required"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>-->
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <asl:ucEmployeeSearch ID="ctrlEmpSearchOTAssignment" runat="server"></asl:ucEmployeeSearch>
                <div class="btnRight">
                    <asp:Button ID="btnView" runat="server" CssClass="button" Text="View" Style="float: right;" />
                </div>
            </div>
            <div style="width: 69%; float: left">
                <div>
                    <div style="width: 50%; float: left">
                        <fieldset class="fieldset-panel">
                            <legend class="fieldset-legend"></legend>
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth100px bglbl">
                                    <a>OT Adjustment Type</a>
                                </div>
                              
                            </div>
                            
                                    <div style="width: 50%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="OTAssignment" ID="rdoLower" runat="server" Text="Add"
                                                Checked="true" />
                                        </a>
                                    </div>
                                    <div style="width: 50%; float: left">
                                        <a>
                                            <asp:RadioButton GroupName="OTAssignment" ID="rdoHigher" runat="server" Text="Reduce" />
                                        </a>
                                    </div>
                           
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth100px bglbl">
                                    <a>OT Hour</a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtOTHour" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div style="width: 50%; float: left;">
                        <fieldset class="fieldset-panel">
                            <legend class="fieldset-legend">Settings</legend>
                            <div class="lblAndTxtStyle">
                                <asp:CheckBox ID="chkAssignOT" Text="Consider For Total OT" CssClass="fieldset-legend"
                                    runat="server" />
                            </div>
                            <div class="lblAndTxtStyle">
                                <asp:CheckBox ID="chkPunchOT" Text="Consider For Extra OT" CssClass="fieldset-legend"
                                    runat="server" />
                            </div>
                            
                        </fieldset>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <br />
                <asl:ucEmpList ID="ctrlEmpList" runat="server"></asl:ucEmpList>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save" />
            </div>
        </div>
        <div id="divCalendar" style="display: none">
            <div>
                <table id="grdWHEmpList">
                </table>
            </div>
            <div id="grdWHEmpList_pager">
            </div>
        </div>
    </div>
</asp:Content>
