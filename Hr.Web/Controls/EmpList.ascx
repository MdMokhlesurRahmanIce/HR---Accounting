<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmpList.ascx.cs" Inherits="Hr.Web.Controls.EmpList" %>
<script src="<%= ResolveUrl("~/gridscripts/Cal_EmpList.js") %> " type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%= chkEmp.ClientID %>").click(function (e) {
            var status = $(this).is(':checked');
            var sessionVarName = "View_EmpList";
            var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AllSelectOrAllClearEmp&Status=' + status + '&SessionVarName=' + sessionVarName,
                        async: false
                    }
                ).responseText
            $("#grdCalendar").trigger("reloadGrid");
        });
        $("#<%= txtEmpCode.ClientID %>").keyup(function (event) {
            var _empCode = $(this).val();
            var selectionCriteria = $('#cphBody_cphInfbody_ctrlEmpList_ddlSelectionCritaria').val();
            if (event.keyCode == 13 && event.which == 13) {
                if (_empCode == '') return;
                else {
                    retval = jQuery.ajax
                        (
                            {
                                url: rootPath + "GridHelperClasses/DataHandler.ashx?CallMode=_SearchByEmpCode&SelectionCriteria=" + selectionCriteria + "&EmpCode=" + _empCode,
                                async: false
                            }
                        ).responseText;
                    if (retval == "false") {
                        ShowMessageBox("HR", "No employee found with this Employee ID.");
                        return false;
                    }
                    else {
                        $("#grdCalendar").trigger("reloadGrid");
                        $('#cphBody_cphInfbody_ctrlEmpList_txtEmpCode').val("");
                    }
                }
            }
        });
    });

</script>
<div>
    <div>
        <div style="float: left; width: 80%">
            <a>Employee Code</a>
            <asp:TextBox ID="txtEmpCode" runat="server" CssClass="txtwidth178px" Width="99.6%"
                MaxLength="100"></asp:TextBox>
        </div>
        <div style="float: left; width: 20%">
            <a>Search Options</a>
            <asp:DropDownList ID="ddlSelectionCritaria" runat="server" CssClass="drpwidth180px"
                Width="92.6%" Font-Size="11px">
                <asp:ListItem Text="EmpCode" Value="EmpCode" Selected="True"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
        </div>
    </div>
    <div style="clear: both">
    </div>
    <div style="width: 98.6%">
        <table id="grdCalendar">
        </table>
    </div>
    <div id="grdCalendar_pager">
    </div>
    <div style="margin-left: 0px; text-align: left; vertical-align: middle;">
        <span class="lblStyle">Select All</span>
        <asp:CheckBox ID="chkEmp" CssClass="selectAll" Text="" runat="server" />
    </div>
</div>
