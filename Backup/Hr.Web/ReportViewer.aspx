<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs"
    Inherits="Hr.Web.Reports.ReportViewer" Title="Report Viewer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/ReportViewerParameter.js") %> " type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/ReportViewerParameterSelector.js") %> "
        type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/gridscripts/ReportViewerParameterSelectorMultiselect.js") %> "
        type="text/javascript"></script>
    <script type="text/javascript">
        function OpenParameterSelectorPopupDialog(vid, headerText) {
            $("#grdParameterSelector").jqGrid('setGridParam', { postData: { filters: ''} }).trigger("reloadGrid");
            $("#divParameterSelector").dialog('open');
            $("#divParameterSelector").dialog
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
                        var selectedVids = jQuery("#grdParameterSelector").jqGrid('getGridParam', 'selrow');
                        if (selectedVids != null && selectedVids.length != 0) {
                            jQuery.ajax
                            (
                                {
                                    url: rootPath + "GridHelperClasses/DataHandler.ashx?CallMode=SetSelectedParameterValueInParameterGrid&vid=" + vid + "&SelectedVids=" + selectedVids,
                                    async: false
                                }
                            );
                        }
                        $("#grdParameters").trigger("reloadGrid");
                        $(this).dialog('close');
                    }
                }
            }
        )
        }
        function OpenParameterSelectorMultiselectPopupDialog(vid, headerText) {
            $("#grdParameterSelectorMultiselect").jqGrid('setGridParam', { postData: { filters: ''} }).trigger("reloadGrid");
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
                        selectedVids = jQuery("#grdParameterSelectorMultiselect").jqGrid('getGridParam', 'selarrrow');
                        if (selectedVids != null && selectedVids.length != 0) {
                            jQuery.ajax
                            (
                                {
                                    url: rootPath + "GridHelperClasses/DataHandler.ashx?CallMode=SetSelectedParameterValueInParameterGrid&vid=" + vid + "&SelectedVids=" + selectedVids,
                                    async: false
                                }
                            );
                        }
                        $("#grdParameters").trigger("reloadGrid");
                        $(this).dialog('close');
                    }
                }
            }
        )
        }
        function CheckBlankReportParameter() {
            var retSourceString = jQuery.ajax
	    (
	        {
	            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=CheckBlankReportParameter',
	            async: false
	        }
        ).responseText;

            if (retSourceString.length != 0) {
                ShowMessageBox("HR", "Parameter can not be blank.");
                return false;
            }
            //
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Report Viewer"></asp:Label>
        </div>
        <div class="form-details">
            <div class="page">
                <div style="width: 250px; float:left">
                    <asp:TreeView ID="treeMenu" runat="server" OnSelectedNodeChanged="treeMenu_SelectedNodeChanged">
                    </asp:TreeView>
                </div>
                <div style="width: 400px; padding-left: 5px; float:left">
                    <div style="margin-top: 5px">
                        <div>
                            <table id="grdParameters">
                            </table>
                        </div>
                        <div id="grdParameters_pager">
                        </div>
                    </div>
                </div>
            </div>
            <div style="float: right; width: 30%; padding-top: 5px; padding-right: 48px;">
                <div class="btnRight">
                    <asp:Button CssClass="button" ID="btnClear" runat="server" Text="Clear" Font-Bold="True"
                        OnClick="btnClear_Click" /></div>
                <div class="btnRight">
                    <asp:Button CssClass="button" ID="btnPreview" runat="server" Text="Preview" Font-Bold="True"
                        OnClick="btnPreview_Click" /></div>
                <div class="btnRight">
                    <asp:Button CssClass="button" ID="btnSave" runat="server" Text="Save" Font-Bold="True"
                        Enabled="False" Visible="false" /></div>
                        <div class="btnRight">
                    <asp:Button CssClass="button" ID="btnEmail" runat="server" Text="Email" Font-Bold="True"
                        Enabled="True" Visible="True" OnClick="btnEmail_Click" /></div>
            </div>
            <div style="clear: both">
            </div>
            <div id="divParameterSelector" style="display: none">
                <div>
                    <table id="grdParameterSelector">
                    </table>
                </div>
                <div id="grdParameterSelector_pager">
                </div>
            </div>
            <div id="divParameterSelectorMultiselect" style="display: none">
                <div>
                    <table id="grdParameterSelectorMultiselect">
                    </table>
                </div>
                <div id="grdParameterSelectorMultiselect_pager">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
