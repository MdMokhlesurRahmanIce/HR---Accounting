jQuery(document).ready
		(
			function () {
			    jQuery('#grdLeaveAllocation').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdLeaveAllocation&SessionVarName=LeaveAllocation_LeaveAllocation'
						, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdLeaveAllocation&editMode=1&SessionVarName=LeaveAllocation_LeaveAllocation'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'LeaveType', 'Advance Leave', 'Opening', 'Allocated', 'Availed', 'Balance', 'Remarks']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 25, 'index': 'VID' },
								{ 'name': 'LeaveType', 'index': 'LeaveType', 'width': 80, 'editable': false },
                                { 'name': 'Advance', 'index': 'Advance', 'width': 100, 'editable': true, 'align': 'right', formatter: 'currency' },
								{ 'name': 'OpeningBalance', 'index': 'OpeningBalance', 'width': 80, 'editable': true, 'align': 'right', formatter: 'currency' },
                                //{ 'name': 'UploadOpeningBalance', 'index': 'UploadOpeningBalance', 'width': 120, 'editable': true, 'align': 'right', formatter: 'currency' },
								{ 'name': 'Allocated', 'index': 'Allocated', 'width': 80, 'editable': true, 'align': 'right', formatter: 'currency' },
								{ 'name': 'Availed', 'index': 'Availed', 'width': 80, 'editable': true, 'align': 'right', formatter: 'currency' },
								{ 'name': 'Balance', 'index': 'Balance', 'width': 80, 'editable': true, 'align': 'right', formatter: 'currency' },
								{ 'name': 'Remarks', 'index': 'Remarks', 'width': 80, 'editable': true }
							]
						, viewrecords: true
						, rownumbers: true
						, scrollrows: true
						, pager: jQuery('#grdLeaveAllocation_pager')
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
						, rowNum: 5
						, rowList: [10, 20, 30]
						, caption: 'Leave Summary'
						, width: '100%'
				        , height: '100%'

						, onSelectRow: editRow_EmploymentHistory
						, viewsortcols: [true, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdEmploymentHistory_pager',
					{
					    'edit': false, 'add': false, 'del': false, 'search': false, 'refresh': false, 'view': false, 'position': 'left', 'cloneToTop': true
					}
				)
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);

var lastID_editRow_EmploymentHistory;
function editRow_EmploymentHistory(rowid) {
    var grid = jQuery("#grdLeaveAllocation");
    var ids = grid.jqGrid('getDataIDs');
    if ((ids.length == 1) || (rowid && rowid !== lastID_editRow_EmploymentHistory)) {
        grid.restoreRow(lastID_editRow_EmploymentHistory);
        jQuery("#grdLeaveAllocation").jqGrid('editRow', rowid, true);
        lastID_editRow_EmploymentHistory = rowid;
    }
};
