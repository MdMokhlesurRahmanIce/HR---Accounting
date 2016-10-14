var rowsToColor = [];
jQuery(document).ready
(
	function () {
	    jQuery('#grdWHEmpList').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdWHEmpList&SessionVarName=WHDeclaration_WHEmpList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdWHEmpList&editMode=1&SessionVarName=WHDeclaration_WHEmpList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Code', 'Name', 'Shift', 'Day', 'WorkOffDate', 'Day Type', 'Remarks', 'IsSaved']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'EmpCode', 'index': 'EmpCode', 'width': 100 },
                        { 'name': 'EmpName', 'index': 'EmpName', 'width': 100 },
                        { 'name': 'Shift', 'index': 'Shift', 'width': 50 },
                        { 'name': 'DateName', 'index': 'DateName', 'width': 100 },
                        { 'name': 'WorkOffDate', 'index': 'WorkOffDate', 'width': 100 },
                        { 'name': 'DayType', 'index': 'DayType', 'width': 50 },
                        { 'name': 'Remarks', 'index': 'Remarks', 'width': 150 },
                        { 'name': 'IsSaved', 'hidden': true, 'width': 50, 'index': 'IsSaved'}//, formatter: rowColorFormatter }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdWHEmpList_pager')
				, loadError: jqGrid_aspnet_loadErrorHandler
				, hoverrows: true
                , loadComplete: function () {
                    var ids = jQuery("#grdWHEmpList").jqGrid('getDataIDs');
                    var rowId;
                    for (var i = 0; i < ids.length; i++) {
                        var data = jQuery("#grdWHEmpList").jqGrid('getRowData', ids[i]);
                        if (data.IsSaved == "True") {
                            disableRow(i);
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
				, rowNum: 10
				, rowList: [10, 20, 30]
				, caption: 'Employee List'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]

			}
		)
		.navGrid
		(
			'#grdWHEmpList_pager',
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

function disableRow(rowId) {
    $("#grdWHEmpList").jqGrid('setRowData', rowId, false, { color: 'red' });
}

