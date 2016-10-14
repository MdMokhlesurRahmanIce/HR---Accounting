<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchEmployee.ascx.cs"
    Inherits="Hr.Web.Controls.SearchEmployee" %>
<script src="<%= ResolveUrl("~/gridscripts/Lotus-12_EmployeeList.js") %> " type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    $(document).ready(function () {

        $('#cphBody_cphInfbody_ctrlEmpSearch2_txtSearch').keyup(function (event) {
            var searchString = $(this).val();
            var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=Lotus_12_SearchEmpList&SearchString=' + searchString,
                        async: false
                    }
                ).responseText;
            $("#grdEmployeeList").trigger("reloadGrid");

            var _empCode = $(this).val();
            employeeIdKeyup(event, _empCode);
        });
        $('#cphBody_cphInfbody_Header1_txtSearch').keyup(function (event) {
            var searchString = $(this).val();
            var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=Lotus_12_SearchEmpList&SearchString=' + searchString,
                        async: false
                    }
                ).responseText;
            $("#grdEmployeeList").trigger("reloadGrid");

            var _empCode = $(this).val();
            employeeIdKeyup(event, _empCode);
        });
    });
</script>
<div>
    <div style="float: left; width: 80%">
        <asp:TextBox ID="txtSearch" runat="server" CssClass="txtwidth178px" Width="95%" MaxLength="100"
            AutoCompleteType="None"></asp:TextBox>
    </div>
    <div style="float: left; margin-left: 5px;">
        <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/new 20X20.png"
            OnClick="btnNew_Click" />
        <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png"
            OnClick="btnFind_Click" />
    </div>
    <div style="clear: both">
    </div>
    <div>
        <div>
            <table id="grdEmployeeList">
            </table>
        </div>
       <!-- <div id="grdEmployee1_pager">
        </div>-->
    </div>
</div>
