<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaveTransaction.aspx.cs"
    Inherits="Hr.Web.UI.LeaveManagement.LeaveTransaction" Title="Lotus-12 :: Leave Transaction" %>

<%@ Register Src="~/Controls/SearchEmployee.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/grdLeaveSummary.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/LeaveTransactions.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/LV_HourlyLeaveTrans.js") %> " type="text/javascript"></script>
    <script src="../../src/Test.js" type="text/javascript"></script>
    <link href="../../src/jquery.ptTimeSelect.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready
        (
            function () {
                HourlyLeave();
                $("input[id$='txtLeaveFrom']").datepicker({
                    ampm: true,
                    hourGrid: 4,
                    minuteGrid: 10,
                    hourMin: 8,
                    hourMax: 24,
                    showButtonPanel: true,
                    changeMonth: true,
                    changeYear: true,
                    dateFormat: 'mm/dd/yy',
                    onClose: function (dateText, inst) {
                        var toDateTextBox = $('#cphBody_cphInfbody_txtLeaveTo');
                        var fromDate = new Date(dateText);
                        if (toDateTextBox.val() != '') {
                            var toDate = new Date(toDateTextBox.val());
                            var days = (toDate - fromDate) / (1000 * 60 * 60 * 24)
                            $('#cphBody_cphInfbody_txtDays').val(days + 1)
                        }
                    }
                });
                $("input[id$='txtLeaveTo']").datepicker({
                    ampm: true,
                    hourGrid: 4,
                    minuteGrid: 10,
                    hourMin: 8,
                    hourMax: 24,
                    showButtonPanel: true,
                    changeMonth: true,
                    changeYear: true,
                    dateFormat: 'mm/dd/yy',
                    onClose: function (dateText, inst) {
                        var fromDateTextBox = $('#cphBody_cphInfbody_txtLeaveFrom');
                        var toDate = new Date(dateText);
                        if (fromDateTextBox.val() != '') {
                            var fromDate = new Date(fromDateTextBox.val());
                            var days = (toDate - fromDate) / (1000 * 60 * 60 * 24);
                            $('#cphBody_cphInfbody_txtDays').val(days + 1);
                        }
                    }
                });
                $("input[id$='txtWorkDate']").datepicker({
                    ampm: true,
                    hourGrid: 4,
                    minuteGrid: 10,
                    hourMin: 8,
                    hourMax: 24,
                    showButtonPanel: true,
                    changeMonth: true,
                    changeYear: true,
                    dateFormat: 'mm/dd/yy'
                });
                $("input[id$='txtFrom']").timepicker({
                    ampm: true,
                    hourGrid: 4,
                    minuteGrid: 10,
                    hourMin: 8,
                    hourMax: 24,
                    onClose: function (dateText, inst) {
                        var to = $('#cphBody_cphInfbody_txtTo').val();
                        var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/LV_DataHandler.ashx?CallMode=LV_SetHour&DateText=' + dateText + '&To=' + to,
                    	                async: false
                    	            }
                                ).responseText
                        if (retVal != "") {
                            $('#cphBody_cphInfbody_txtLeaveHours').val(retVal);
                        }
                        else {
                            $('#cphBody_cphInfbody_txtLeaveHours').val("");
                        }
                    }
                });
                $("input[id$='txtTo']").timepicker({
                    ampm: true,
                    hourGrid: 4,
                    minuteGrid: 10,
                    hourMin: 8,
                    hourMax: 24,
                    onClose: function (dateText, inst) {
                        var to = dateText;
                        dateText = $('#cphBody_cphInfbody_txtFrom').val();
                        var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/LV_DataHandler.ashx?CallMode=LV_SetHour&DateText=' + dateText + '&To=' + to,
                    	                async: false
                    	            }
                                ).responseText
                        if (retVal != "") {
                            $('#cphBody_cphInfbody_txtLeaveHours').val(retVal);
                        }
                        else {
                            $('#cphBody_cphInfbody_txtLeaveHours').val("");
                        }
                    }
                });
                //accordion
                $(function () {
                    var fixScroll = function (event, ui) {
                        $(event.target).find('ui-accordion-content-active').css('overflow', 'visible');
                    }
                    $('#container').accordion({
                        header: "h3",
                        create: fixScroll,
                        change: fixScroll
                    });
                });
                //end accordion
                $("#cphBody_cphInfbody_chkHourlyLeave").click(function (e) {
                    HourlyLeave();
                    $("#cphBody_cphInfbody_ddlLeaveType").val("");
                    $("#cphBody_cphInfbody_txtReason").val("");
                    $("#cphBody_cphInfbody_txtAvailPlace").val("");
                    $("#cphBody_cphInfbody_txtAdditionalContact").val("");
                });
            }
        );
        function HourlyLeave() {
            if ($("#cphBody_cphInfbody_chkHourlyLeave").is(":checked")) {
                $("#cphBody_cphInfbody_txtLeaveFrom").val("");
                $("#cphBody_cphInfbody_txtLeaveTo").val("");
                $("#cphBody_cphInfbody_txtDays").val("");
                $(".showdays").hide();
                $(".showHour").show();
            }
            else {
                $("#cphBody_cphInfbody_txtWorkDate").val("");
                $("#cphBody_cphInfbody_txtFrom").val("");
                $("#cphBody_cphInfbody_txtTo").val("");
                $("#cphBody_cphInfbody_txtLeaveHours").val("");
                $(".showdays").show();
                $(".showHour").hide();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="width: 25%; float: left">
                <div id="divTest" class="lblAndTxtStyle" style="width: 99%; margin-left: -5px" runat="server">
                    <div class="divlblwidth100px2 bglbl" style="width: 35%">
                        <a>Leave Year</a>
                    </div>
                    <div>
                        <asp:DropDownList ID="ddlLeaveYear" Font-Size="12px" runat="server" CssClass="txtwidth50per">
                        </asp:DropDownList>
                    </div>
                </div>
                <div style="width: 90%; border: #D7D7D7; float: left;">
                    <asl:ucEmployeeSearch ID="Header1" runat="server" />
                </div>
                <div id="leaveFromHome" runat="server">
                    Welcome to Leave Application Form!
                    <br />
                    <br />
                    <div style="width: 90%;">
                        <div id="container">
                            <div id="expand" style="text-align: right">
                                <img src="/images/plus.gif" />
                                Expand All</div>
                            <h3 class="headline">
                                <a href="#">Leave Application Process</a></h3>
                            <div class="accordion">
                                <div style="width: 90%;">
                                    <a>Traveling  of a Leave Request:</a>
                                    <br />
                                    <br />
                                    <a>Leave apply from user end--> Submitted to Supervisor by the system--> Approve/Rejection
                                        By Supervisor--> if approved then Submitted to HR by the system--> Confirmation
                                        By HR--> Finally Done!</a>
                                    <br />
                                    <br />
                                    <a>Please follow the related instructions (If needed)</a>
                                </div>
                            </div>
                            <h3 class="headline">
                                <a href="#">Tips!</a></h3>
                            <div class="accordion">
                            <a>Application Procedure:</a>
                                    <br />
                                    <br />
                                    <a>1. Select The Specific Leave Type.</a><br />
                                    <a>2. Select from date & to date.</a><br />
                                    <a>3. Days will calculated by System (as per company policy).</a><br />
                                    <a>3. Fill up Leave Reason, Leave Availing Place & Contact no during Lave.</a><br />
                                    <a>4. Pick up your leave Substitute if any.</a><br />
                                    <a>5. Finally Save the Leave!</a>
                                    <br />
                                    <br />
                                  
                            </div>
                            <br />
                            <br />
                             <a>** If you have any further queries, please contact with your HR Department. For any System Related Information/Opinion, Please submit to "info@ast-bd.com"</a><br /> <br />
                             <a>Thanks for your nice co-operation!</a><br /> <br /><br /> <br />

                              <a>Developed by: Advanced Software Technology</a>
                
                        </div>
                        <div style="clear: both">
                        </div>
                    </div>
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
                    <div style="width: 50%; float: left">
                        <div style="width: 50%; float: left">
                            <asp:CheckBox ID="chkHourlyLeave" Text="Hourly Leave" CssClass="fieldset-legend"
                                runat="server" />
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth45per bglbl">
                                    <a>Leave Type</a>
                                </div>
                                <div>
                                    <asp:DropDownList ID="ddlLeaveType" runat="server" CssClass="txtwidth50per">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="showdays">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth45per bglbl">
                                        <a>LeaveFrom</a>
                                    </div>
                                    <div>
                                        <asp:TextBox ID="txtLeaveFrom" runat="server" CssClass="txtwidth50per"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth45per bglbl">
                                        <a>Leave To</a>
                                    </div>
                                    <div>
                                        <asp:TextBox ID="txtLeaveTo" runat="server" CssClass="txtwidth50per"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth45per bglbl">
                                        <a>Days</a>
                                    </div>
                                    <div>
                                        <asp:TextBox ID="txtDays" runat="server" CssClass="txtwidth50per"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div style="display: none" class="showHour">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth45per bglbl">
                                        <a>Work Date</a>
                                    </div>
                                    <div>
                                        <asp:TextBox ID="txtWorkDate" runat="server" CssClass="txtwidth50per" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth45per bglbl">
                                        <a>From</a>
                                    </div>
                                    <div>
                                        <asp:TextBox ID="txtFrom" runat="server" CssClass="txtwidth50per" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth45per bglbl">
                                        <a>To</a>
                                    </div>
                                    <div>
                                        <asp:TextBox ID="txtTo" runat="server" CssClass="txtwidth50per" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth45per bglbl">
                                        <a>Leave Hours</a>
                                    </div>
                                    <div>
                                        <asp:TextBox ID="txtLeaveHours" runat="server" CssClass="txtwidth50per" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div style="width: 50%; float: left">
                            <br />
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth45per bglbl">
                                    <a>Reason</a>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtReason" runat="server" CssClass="txtwidth50per"></asp:TextBox>
                                </div>
                            </div>
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth45per bglbl">
                                    <a>Avail Place</a>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtAvailPlace" runat="server" CssClass="txtwidth50per"></asp:TextBox>
                                </div>
                            </div>
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth45per bglbl">
                                    <a>Contact</a>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtAdditionalContact" runat="server" CssClass="txtwidth50per"></asp:TextBox>
                                </div>
                            </div>
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth45per bglbl">
                                    <a>Leave Substitute</a>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtLeaveSubstitute" runat="server" CssClass="txtwidth50per"></asp:TextBox>
                                </div>
                            </div>
                            <div style="float: left;">
                                <asp:ImageButton ID="btnFindSupervisor" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png"
                                    OnClick="btnFindSupervisor_Click" />
                            </div>
                        </div>
                    </div>
                    <div style="float: left; width: 49%;" class="showdays">
                        <br />
                        <div style="float: left;" class="ui-jqgrid">
                            <table id="grdLeaveTransacton">
                            </table>
                        </div>
                        <div id="grdLeaveTransacton_pager">
                        </div>
                        <asp:HiddenField ID="hidSelectedRow" runat="server" />
                    </div>
                    <div style="float: left; width: 49%; display: none" class="showHour">
                        <br />
                        <div style="float: left;" class="ui-jqgrid">
                            <table id="grdHourlyLeaveTransacton">
                            </table>
                        </div>
                        <div id="grdHourlyLeaveTransacton_pager">
                        </div>
                    </div>
                    <br />
                    <div style="float: left; width: 100%;">
                        <div style="float: left;" class="ui-jqgrid">
                            <table id="grdLeaveSummary">
                            </table>
                        </div>
                        <div id="grdLeaveSummary_pager">
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
                <asp:Button ID="btnClear" runat="server" CssClass="button" Text="Cancel" OnClick="btnClear_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClick="btnDelete_Click" />
            </div>
        </div>
        <asp:HiddenField ID="hfLeaveSubstitute" runat="server" />
    </div>
</asp:Content>
