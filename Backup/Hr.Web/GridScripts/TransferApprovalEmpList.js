jQuery(document).ready
(
	function () {
	    jQuery('#grdEmpTransferApproval').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpTransferApproval&SessionVarName=TransferApproval_TransferEmpList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpTransferApproval&editMode=1&SessionVarName=TransferApproval_TransferEmpList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', '...', 'Code', 'Name', 'DOJ', 'Designation', 'Department', 'Transfer Type', 'Effective Date', 'Added By', 'Added Date', 'EmpKey']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'IsChecked', 'index': 'IsChecked', 'width': 15, 'align': 'center' },
				        { 'name': 'EmpCode', 'index': 'EmpCode', 'width': 100 },
						{ 'name': 'EmpName', 'index': 'EmpName', 'width': 100 },
                        { 'name': 'DOJ', 'index': 'DOJ', 'width': 100 },
                        { 'name': 'Designation', 'index': 'Designation', 'width': 100 },
                        { 'name': 'Department', 'index': 'Department', 'width': 100 },
                        { 'name': 'ElementName', 'index': 'ElementName', 'width': 100 },
                        { 'name': 'EffectiveDate', 'index': 'EffectiveDate', 'width': 100 },
                        { 'name': 'AddedBy', 'index': 'AddedBy', 'width': 100 },
                        { 'name': 'AddedDate', 'index': 'AddedDate', 'width': 100 },
                        { 'name': 'EmpKey', 'index': 'EmpKey', 'hidden': true, 'width': 50 }
                    ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdEmpTransferApproval_pager')
                , subGrid: true
			    , subGridRowExpanded: ApprovalOfTransfer
				, loadError: jqGrid_aspnet_loadErrorHandler
				, hoverrows: true
				, jsonReader:
				{
				    root: 'rows',
				    page: 'currentpage',
				    total: 'totalpages',
				    records: 'pagerecords',
				    repeatitems: false
				}
				, sortable: true
				, rowNum: 10
				, rowList: [10, 20, 30]
				, caption: 'Transfer Approval'
				, autowidth: true
				, height: '140'
                , gridComplete: addCheckBox_grdApprovalOfTransfer
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdEmpTransferApproval_pager',
			{
			    'edit': false, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

function ApprovalOfTransfer(subgrid_id, row_id) {

    try {
        subgrid_table_id = subgrid_id + "_t";
        pager_id = "p_" + subgrid_table_id;

        var parentGridID = subgrid_id.toString().substring(0, subgrid_id.toString().lastIndexOf("_"));
        $("#" + parentGridID).restoreRow(row_id);
        var row = $("#" + parentGridID).getRowData(row_id);

        var EmpKey = row.EmpKey;
        $("#" + subgrid_id).html("<table id='" + subgrid_table_id + "' class='scroll'></table><div id='" + pager_id + "' class='scroll'></div>");

        jQuery("#" + subgrid_table_id).jqGrid
                (
                    {
                        url: rootPath + 'GridHelperClasses/SubGridGenericHandler.ashx?SessionVarName=TransferApproval_TransferCriteria&EmpKey=' + EmpKey
                        , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=' + subgrid_table_id + '&editMode=1&SessionVarName=TransferApproval_TransferCriteria'
                        , datatype: "json"
                        , colNames: ['VID', 'EmpKey', 'Entity Name', 'Present', 'Post']
                        , colModel:
                        	[
                        	    { 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                                { 'name': 'EmpKey', 'index': 'EmpKey', 'width': 50, editable: true, 'hidden': true },
                                { 'name': 'EntityName', 'index': 'EntityName', 'width': 100 },
                                { 'name': 'PreHKEntryName', 'index': 'PreHKEntryName', 'width': 100 },
                                { 'name': 'CurrentHKEntryName', 'index': 'CurrentHKEntryName', 'width': 100 }
                             ]
                        , page: 1
                        , jsonReader:
			            {
			                root: 'rows',
			                page: 'currentpage',
			                total: 'totalpages',
			                records: 'pagerecords',
			                repeatitems: false
			            }
                        , autowidth: true
                        , shrinkToFit: false
                        , rowNum: 20
                        , pager: pager_id
                        , sortorder: "asc"
                        , height: '100%'
                    }
                )

                .navGrid
	            (
		            "#" + pager_id,
		            {
		                'edit': false, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
		            }
                )
    }
    catch (e) {
        alert(e);
    }

}
function addCheckBox_grdApprovalOfTransfer() {

    var SessionVarName = 'TransferApproval_TransferEmpList';
    var ColumnName = 'IsChecked';
    var isSelectAll = 1;

    var ids = jQuery("#grdEmpTransferApproval").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdEmpTransferApproval").jqGrid('getRowData', cid);
        var chk;
        if (data.IsChecked == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
            isSelectAll = 0;
        }
        jQuery("#grdEmpTransferApproval").jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};