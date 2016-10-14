<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="YearEndProcess.aspx.cs" Inherits="Hr.Web.UI.ACC.YearEndProcess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[id$='txtProcessDate']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { } });
            $("#cphBody_cphInfbody_btnProcess").click(function (e) {
                ShowConfirmBox("Confirmation", "This will process Year End. Are you sure you want to continue?", "OkButtonClick", "CancelButtonClick");
                return false;
            });
        });
        function CancelButtonClick() {
        }
        function OkButtonClick() {
            var fYKey = $("#cphBody_cphInfbody_ddlFY").val();
            ShowMessageBox('Working...', 'Please Wait. And do not leave this page.Year End Process is in progress. You will be notified when finished.');
            var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=YearEndProcess&FYKey=' + fYKey,
                        async: false,
                        success: function () { ShowMessageBox('Successful', 'Year End Process completed successfully.') },
                        error: function (xhr, status, error) {
                            ShowMessageBox('Error', xhr.responseText);
                        }
                    }
                ).responseText;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Year End Process"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 40%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Fiscal Year</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlFY" runat="server" CssClass="drpwidth180px" Enabled="false">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Process Date</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtProcessDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="width: 45%;">
                <div style="width: 100%; text-align: center">
                    <asp:Button ID="btnProcess" runat="server" CssClass="button" Text="Process" />
                </div>
            </div>
            <div style="clear: both">
            </div>
        </div>
        <br />
    </div>
</asp:Content>
