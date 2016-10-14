jQuery(document).ready
(
	function () {
	    jQuery('#grdBonusProcessDetail').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdBonusProcessDetail&SessionVarName=View_EmpList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdBonusProcessDetail&editMode=1&SessionVarName=View_EmpList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Code', 'Name'/*, 'Designation', 'Shift', 'StaffCategory', 'Department'*/,'Bonus Amount']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'EmpCode', 'index': 'EmpCode', 'width': 100 },
                        { 'name': 'EmpName', 'index': 'EmpName', 'width': 150 },
			    //                        { 'name': 'Designation', 'index': 'Designation', 'width': 150 },
			    //                        { 'name': 'Shift', 'index': 'Shift', 'width': 150 },
			    //                        { 'name': 'StaffCategory', 'index': 'StaffCategory', 'width': 150 },
			    //                        { 'name': 'Department', 'index': 'Department', 'width': 150 }
                        {'name': 'BonusAmount', 'index': 'BonusAmount', 'width': 150 }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
                , shrinkToFit: false
				, pager: jQuery('#grdBonusProcessDetail_pager')
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
				, caption: 'Bonus Process Detail'
				, autowidth: true
				, height: '240'
				, viewsortcols: [false, 'vertical', true]

			}
		)
		.navGrid
		(
			'#grdBonusProcessDetail_pager',
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
