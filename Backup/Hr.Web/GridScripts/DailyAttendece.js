jQuery(document).ready
(
	function () {
	    jQuery('#grdDailyAttendance').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdDailyAttendance&SessionVarName=AttendanceProcess_DailyAttendanceList'
			    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdBank&editMode=1&SessionVarName=AttendanceProcess_DailyAttendanceList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Code', 'Name', 'Designation', 'Work<br/>Date', 'Shift<br/>ID', 'Shift Type', 'Shift<br/>In Time', 'Shift<br/>Out Time', 'In Date/Time', 'Out Date/Time', 'Day<br/>Status', 'Details<br/>Status', 'OT', 'Slab01', 'Slab02', 'Pay Hour', 'Late<br/>Margin', 'Late<br/>Min', 'EOut<br/>Min']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 20, 'index': 'VID' },
				        { 'name': 'EmpCode', 'index': 'EmpCode', 'width': 60, 'editable': true },
				        { 'name': 'EmpName', 'index': 'EmpName', 'width': 120 },
                        { 'name': 'Designation', 'index': 'Designation', "width": 120 },
                        { 'name': 'Workdate', 'index': 'Workdate', 'width': 70, 'align': 'center' },
				        { 'name': 'ShiftID', 'index': 'ShiftID', 'width': 40, 'align': 'center' },
				        { 'name': 'ShiftType', 'index': 'ShiftType', 'width': 70, 'align': 'center' },
				        { 'name': 'ShiftIntime', 'index': 'ShiftIntime', 'width': 60, 'align': 'center' },
				        { 'name': 'ShiftOutTime', 'index': 'ShiftOutTime', 'width': 60, 'align': 'center' },
                        { 'name': 'InTime', 'index': 'InTime', 'width': 130, 'align': 'center' },
                        { 'name': 'OutTime', 'index': 'OutTime', 'width': 130, 'align': 'center' },
                        { 'name': 'DayStatus', 'index': 'DayStatus', "width": 40, 'align': 'center' },
                        { 'name': 'AdditionalStatus', 'index': 'AdditionalStatus', "width": 80, 'align': 'center' },
                        { 'name': 'OTHour', 'index': 'OTHour', "width": 50, 'align': 'center', formatter: 'currency' },
						{ 'name': 'Slab01', 'index': 'Slab01', "width": 50, 'align': 'center', formatter: 'currency' },
						{ 'name': 'Slab02', 'index': 'Slab02', "width": 50, 'align': 'center', formatter: 'currency' },
                        { 'name': 'PayHour', 'index': 'PayHour', "width": 50, 'align': 'center', formatter: 'currency' },
                        { 'name': 'LateMargin', 'index': 'LateMargin', 'width': 50, 'align': 'center', formatter: 'currency' },
						{ 'name': 'LateHour', 'index': 'LateHour', "width": 50, 'align': 'center', formatter: 'currency' },
						{ 'name': 'EarlyOutHour', 'index': 'EarlyOutHour', "width": 50, 'align': 'center', formatter: 'currency' }
					]
				, viewrecords: true
				, rownumbers: true
                , shrinkToFit: false
				, scrollrows: true
				, pager: jQuery('#grdDailyAttence_pager')
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
				, caption: 'Attendence Process'
				, autowidth: true
                , viewsortcols: [false, 'vertical', true]
				, height: '250'
			}
		)
		.navGrid
		(
			'#grdDailyAttence_pager',
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