jQuery(document).ready
(
	function () {
	    jQuery('#grdOutOfOfficeEntry').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdOutOfOfficeEntry&SessionVarName=EmpOutOffOfficeEntry_EmpList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdOutOfOfficeEntry&editMode=1&SessionVarName=EmpOutOffOfficeEntry_EmpList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID','Code','Name', 'Date', 'Start Time', 'End Time', 'Project', 'Stay Place', 'Reason', 'Remarks']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'EmpCode', 'index': 'EmpCode', 'width': 50 },
                        { 'name': 'EmpName', 'index': 'EmpName', 'width': 100 },
                        { 'name': 'Date', 'index': 'Date', 'width': 70},
                        { 'name': 'StartTime', 'index': 'StartTime'},
                        { 'name': 'EndTime', 'index': 'EndTime','width': 70 },
                        { 'name': 'Project', 'index': 'Project', 'width': 70, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=EmpOutOffOfficeEntry_ProjectList&DataTextField=HKName&NeedBlank=Empty&DataValueField=HKID')} },
                        { 'name': 'StayPlace', 'index': 'StayPlace', 'width': 70 },
                        { 'name': 'Reason', 'index': 'Reason', 'width': 100},
                        { 'name': 'Remarks', 'index': 'Remarks', 'width': 100 }
                     ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdOutOfOfficeEntry_pager')
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
				, caption: 'Out Of Office Entry'
				, autowidth: true
				, height: '240'
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdOutOfOfficeEntry_pager',
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

