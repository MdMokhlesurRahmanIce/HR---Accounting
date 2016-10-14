jQuery(document).ready
(
	function () {
	    jQuery('#grdValidRejectedData').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdValidRejectedData&SessionVarName=AttendImport_AttRejectedList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Employee Code', 'Punch Card No', 'Punch Date', 'Punch Time', 'Device ID']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'EmpCode', 'index': 'EmpCode', 'width': 50 },
                        { 'name': 'PunchCardNo', 'index': 'PunchCardNo', 'width': 50 },
                        { 'name': 'WorkDate', 'index': 'WorkDate', 'width': 50 },
                        { 'name': 'PTime', 'index': 'PTime', 'width': 50 },
                        { 'name': 'DeviceID', 'index': 'DeviceID', 'width': 50 }
                     ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdValidRejectedData_pager')
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
                , caption: 'Rejected Device Data'
				, autowidth: true
				, height: '120'
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdValidRejectedData_pager',
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
