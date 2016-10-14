<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="AttendImport.aspx.cs" Inherits="Hr.Web.UI.Attendance.AttendImport" %>



<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/ValidDeviceData.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/DeviceRejectedData.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[id$='txtFromDate'], .date-picker").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, defaultDate: new Date(), maxDate: 0, dateFormat: 'mm/dd/yy',
                onSelect: function (selectedDate) {
                    var toDate = $("#cphBody_cphInfbody_txtToDate").val();
                    if (toDate == "") {
                        $("#cphBody_cphInfbody_txtToDate").val(selectedDate);
                    }
                }
            });

            $("#<%= btnSave.ClientID %>").click(function (e) {

                var retVal = jQuery.ajax
                (
            	            {
            	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=SaveValidData',
            	                async: false
            	            }
                        ).responseText
                ShowMessageBox("HR", "Device data save successfully.");
                return false;
            });
            $("#<%= btnImport.ClientID %>").click(function (e) {
                var fileExt = $("#cphBody_cphInfbody_ddlFileExtension").val();
                var filePath = $("#cphBody_cphInfbody_btnBrowse").val();
                //  alert('exten is ' + fileExt.toString());


                //    alert('Length is ' + filePath.length.toString());
                if (fileExt < 4) {

                    //    alert(filePath.length);
                    if (filePath.length <= 0) {


                        ShowMessageBox("HR", "Please Select Device File");
                        return false;
                    }
                    else {

                    }
                }
                var retVal = jQuery.ajax
                (
            	            {
            	            //  url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=SaveValidData',
            	            //   async: false
            	        }
                        ).responseText
                //ShowMessageBox("HR", "Device data save successfully.");
                // return false;
            });
            $("#<%= ddlFileExtension.ClientID %>").change(function (e) {
                var device = $("#cphBody_cphInfbody_ddlFileExtension").val();
                var retVal = jQuery.ajax
                (
            	            {
            	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=SelectUpLoadDevice&Device=' + device,
            	                async: false
            	            }
                        ).responseText
                if (retVal == "false") {
                    $(".browse").hide();
                }
                else {
                    $(".browse").show();
                }
                return false;
            });
        });      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="float: left; width: 30%">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>File extension</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlFileExtension" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="browse" style="float: left">
                    <asp:FileUpload ID="btnBrowse" runat="server" CssClass="fileUpload" size="57" /></div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Time Diff to Reject Data</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtTimeDiffToRejectData" runat="server" CssClass="txtwidth178px"
                            Text="60" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>From Date</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>To Date</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="txtwidth178px date-picker" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div style="float: right; padding-top: 10px; padding-right: 20px">
                    <asp:Button ID="btnImport" runat="server" CssClass="button" Text="View" Visible="true"
                        OnClick="btnImport_Click" />
                </div>
            </div>
            <div style="float: left; width: 70%">
                <div style="width: 100%; height: auto; margin-top: 5px">
                    <div>
                        <table id="grdValidDeviceData">
                        </table>
                    </div>
                    <div id="grdValidDeviceData_pager">
                    </div>
                </div>
                <div style="width: 100%; height: auto; margin-top: 5px">
                    <div>
                        <table id="grdValidRejectedData">
                        </table>
                    </div>
                    <div id="grdValidRejectedData_pager">
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="form-bottom" style="text-align: center">
            <div class="btnRight">
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnProcess" runat="server" CssClass="button" Text="Process" OnClick="btnProcess_Click" />
            </div>
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save"
                    OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
