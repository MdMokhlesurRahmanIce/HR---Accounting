<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEmpSearch.ascx.cs"
    Inherits="Hr.Web.Controls.ucEmpSearch" %>
<script src="<%= ResolveUrl("~/gridscripts/SearchGrid.js") %> " type="text/javascript"></script>
<script src="<%= ResolveUrl("~/gridscripts/SearchOptionParameterSelectorMultiselect.js") %> "
    type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $(".ucBtnFind").click(function (e) {
            var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=SearchEmp&SpName=' + spName,
                    	                async: false,
                    	                error: function (xhr, status, error) {
                    	                    ShowMessageBox('Error', xhr.responseText);
                    	                }
                    	            }
                                ).responseText
            $("#grdCalendar").trigger("reloadGrid");
            return false;
        });
    });
    function OpenParameterSelectorMultiselectPopupDialog(vid, headerText) {
        $("#grdMultiselectParameter").jqGrid('setGridParam', { postData: { filters: ''} }).trigger("reloadGrid");
        $("#divParameterSelectorMultiselect").dialog('open');
        $("#divParameterSelectorMultiselect").dialog
        (
            {
                title: headerText,
                height: 450,
                width: 350,
                modal: true,
                zIndex: 10,
                buttons:
                {
                    Ok: function () {
                        var selectedVids = '';
                        selectedVids = jQuery("#grdMultiselectParameter").jqGrid('getGridParam', 'selarrrow');
                        if (selectedVids != null && selectedVids.length != 0) {
                            jQuery.ajax
                            (
                                {
                                    url: rootPath + "GridHelperClasses/DataHandler.ashx?CallMode=SetSelectedParameterValueInParameterGridForSearch&vid=" + vid + "&SelectedVids=" + selectedVids,
                                    async: false
                                }
                            );
                        }
                        $("#grdSearchParameters").trigger("reloadGrid");
                        $(this).dialog('close');
                    }
                }
            }
        )
    }
</script>
<div style="width: 100%; height: auto;">
    <div>
        <table id="grdSearchParameters">
        </table>
    </div>
    <div id="grdSearchParameters_pager">
    </div>
    <div class="lblAndTxtStyle ucEmp" style="width: 100%; margin-left: -4px">
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Employee Name</a>
            </div>
            <div class="div80Px" style="width: 54%">
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="txtwidth178px"></asp:TextBox>
            </div>
            <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle btn-enable ucBtnFind"
                OnClick="btnFind_Click" ImageUrl="~/images/Search 20X20.png" />
        </div>
    </div>
    <div style="clear: both">
    </div>
</div>
<div id="divParameterSelectorMultiselect" style="display: none">
    <div>
        <table id="grdMultiselectParameter">
        </table>
    </div>
    <div id="grdMultiselectParameter_pager">
    </div>
</div>
