<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="UploadFromExcelForSalaryProcess.aspx.cs" Inherits="Hr.Web.UI.Payroll.UploadFromExcelForSalaryProcess" %>


<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/UploadSalaryValidData.js") %> " type="text/javascript"></script>
    
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
           
        });      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div style="float: left; width: 30%">
               <a style="font-size: 14"> Browse the excel file that contains the Salary Info to Upload:</a>
                <div class="browse" style="float: left">
                    <asp:FileUpload ID="btnBrowse" runat="server" CssClass="fileUpload" size="57" /></div>
              
                <div style="float: right; padding-top: 10px; padding-right: 20px">
                    <asp:Button ID="btnImport" runat="server" CssClass="button" Text="Upload" Visible="true"
                        OnClick="btnImport_Click" />
                </div>
            </div>
            <div style="float: left; width: 70%">
                <div style="width: 100%; height: auto; margin-top: 5px">
                    <div>
                        <table id="UploadSalaryValidData">
                        </table>
                    </div>
                    <div id="UploadSalaryValidData_pager">
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