jQuery(document).ready
		(
			function () {
			    jQuery('#grdShiftRosterProcess').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdShiftRosterProcess&SessionVarName=ShiftRosterProcess_ShiftRosterList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdShiftRosterProcess&editMode=1&SessionVarName=ShiftRosterProcess_ShiftRosterList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Code', 'Name', 'Designation', 'ShiftDate', 'ShiftID', 'Shift Type', 'Alise', 'ModifiedOrApprovedFlag']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'EmpCode', 'index': 'EmpCode', 'width': 150 },

                                { 'name': 'EmpName', 'index': 'EmpName', 'width': 150 },
                                 { 'name': 'Designation', 'index': 'Designation', 'width': 150 },
                                { 'name': 'ShiftDate', 'index': 'ShiftDate', 'width': 150 },
                                { 'name': 'ShiftID', 'index': 'ShiftID', 'width': 150 },
                                { 'name': 'ShiftType', 'index': 'ShiftType', 'width': 150 },
                                { 'name': 'ALISE', 'index': 'ALISE', 'width': 150 },
                                { 'name': 'ModifiedOrApprovedFlag', 'hidden': true, 'width': 50, 'index': 'ModifiedOrApprovedFlag' }
							]
						, viewrecords: true
						, rownumbers: true
						, scrollrows: true
						, pager: jQuery('#grdShiftRosterProcess_pager')
						, loadError: jqGrid_aspnet_loadErrorHandler
						, hoverrows: true
                        , loadComplete: function () {
                            var ids = jQuery("#grdShiftRosterProcess").jqGrid('getDataIDs');
                            for (var i = 0; i < ids.length; i++) {
                                var data = jQuery("#grdShiftRosterProcess").jqGrid('getRowData', ids[i]);
                                if (data.ModifiedOrApprovedFlag == "A") {
                                    ChangeRowColorApproved(i);
                                }
                                if (data.ModifiedOrApprovedFlag == "M") {
                                    ChangeRowColorModified(i);
                                }
                            }
                        }
						, jsonReader:
						{
						    root: 'rows',
						    page: 'currentpage',
						    total: 'totalpages',
						    records: 'pagerecords',
						    repeatitems: false
						}
						, sortable: true
						, rowNum: 20
						, rowList: [20, 40, 60]
						, caption: 'Shift Roster'
						, autowidth: true
						, height: '250'
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdShiftRosterProcess_pager',
					{
					    'edit': false, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
                 , jQuery('#grdShiftRosterProcess').getGridParam('editDialogOptions')
   			     , jQuery('#grdShiftRosterProcess').getGridParam('addDialogOptions')
			     );
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);
function ChangeRowColorApproved(rowId) {
    $("#grdShiftRosterProcess").jqGrid('setRowData', rowId, false, { color: 'red' });
}
function ChangeRowColorModified(rowId) {
    $("#grdShiftRosterProcess").jqGrid('setRowData', rowId, false, { color: 'green' });
}





