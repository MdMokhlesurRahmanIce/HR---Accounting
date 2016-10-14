<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="DataCapture.aspx.cs" Inherits="Hr.Web.UI.ProductionDataCapture.DataCapture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/ProductionDataCapture/DataCaptureDynamicGrid.js") %> "
        type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[id$='txtCaptureDate']").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true
            , onClose: function (dateText, inst) {
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/ProductionDataCaptureDataHandler.ashx?CallMode=TodayEntryList&DateText=' + dateText,
                    	                async: false
                    	            }
                                ).responseText
                $("#grdProductionDataCapture").trigger("reloadGrid");
            }
            , defaultDate: new Date(), maxDate: 0, dateFormat: 'mm/dd/yy'
            });
            $("#cphBody_cphInfbody_btnAdd").click(function (e) {
                if ($("#cphBody_cphInfbody_ddlRateID").val() == "") {
                    ShowMessageBox("HR", "Please select Rate ID");
                    return false;
                }
                if ($("#cphBody_cphInfbody_txtEmpCode").val() == "") {
                    ShowMessageBox("HR", "Please select Employee Code!");
                    return false;
                }
                if ($("#cphBody_cphInfbody_txtQty").val() == "") {
                    ShowMessageBox("HR", "Please select Qty!");
                    return false;
                }
                var empCode = $("#cphBody_cphInfbody_txtEmpCode").val();
                var qty = $("#cphBody_cphInfbody_txtQty").val();
                var rateID = $("#cphBody_cphInfbody_ddlRateID").val();
                var rate = $("#cphBody_cphInfbody_txtRate").val();
                var captureDate = $("#cphBody_cphInfbody_txtCaptureDate").val();
                var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/ProductionDataCaptureDataHandler.ashx?CallMode=AddToGrid&EmpCode=' + empCode + '&Qty=' + qty + '&RateID=' + rateID + '&Rate=' + rate + '&CaptureDate=' + captureDate,
                    	                async: false
                    	            }
                                ).responseText
                $("#grdProductionDataCapture").trigger("reloadGrid");
                return false;
            });
        });
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="float: left; width: 33%">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Employee Code</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtEmpCode" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Qty</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtQty" runat="server" CssClass="txtwidth178px" MaxLength="100"
                            onkeypress="return isNumberKey(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Rate</a>
                    </div>
                    <div class="div80Px">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtRate" runat="server" CssClass="txtwidth178px" MaxLength="100"
                                    Enabled="false"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlRateID" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div style="float: left; width: 33%">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Rate ID</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlRateID" runat="server" CssClass="drpwidth180px" OnSelectedIndexChanged="ddlRateID_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Capture Date</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtCaptureDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add" />
                </div>
            </div>
            <div style="clear: both">
            </div>
            <div>
                <div>
                    <table id="grdProductionDataCapture">
                    </table>
                </div>
                <div id="grdProductionDataCapture_pager">
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
