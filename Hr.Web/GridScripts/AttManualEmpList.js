jQuery(document).ready
(
	function () {
	    jQuery('#grdAttManual').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdAttManual&SessionVarName=AttendanceManual_DailyManualAttendanceList'
			    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdAttManual&editMode=1&SessionVarName=AttendanceManual_DailyManualAttendanceList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Code', 'Name', 'Shift<br/>ID', 'Alias', 'Shift<br/>In Time', 'Shift<br/>Out Time', 'Late<br/>Margin', 'Work<br/>Date', 'In Date', 'In Time', 'Out Date', 'Out Time', 'Remarks', 'Current<br/>Status', 'Current<br/>OT', 'Modified<br/>Status', 'Modified<br/>OT','Lunch Out','Lunch In']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 20, 'index': 'VID' },
				        { 'name': 'EmpCode', 'index': 'EmployeeCode', 'width': 70 },
				        { 'name': 'EmpName', 'index': 'EmpName', 'width': 120 },
				        { 'name': 'ShiftID', 'index': 'ShiftID', 'width': 30, 'align': 'center' },
                        { 'name': 'Alias', 'index': 'Alias', 'width': 80, 'align': 'center' },
                        { 'name': 'ShiftInTime', 'index': 'ShiftInTime', 'width': 60, 'align': 'center' },
                        { 'name': 'ShiftOutTime', 'index': 'ShiftOutTime', 'width': 60, 'align': 'center' },
                        { 'name': 'LateMargin', 'index': 'LateMargin', 'width': 60, 'align': 'center' },
				        { 'name': 'Workdate', 'index': 'Workdate', 'width': 75, 'align': 'center' },
                        { 'name': 'CInDate', 'index': 'CInDate', 'width': 75, 'editable': true, 'align': 'center', editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1930:2090' }) } } },
                        { 'name': 'CInTime', 'index': 'CInTime', 'editable': true, 'width': 75, 'align': 'center', editrules: { required: false }, editoptions: { size: 15, maxlengh: 10, dataInit: function (element) { $(element).timeEntry({ showSeconds: true }) } } },
                        { 'name': 'COutDate', 'index': 'COutDate', 'width': 75, 'editable': true, 'align': 'center', editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1930:2090' }) } } },
                        { 'name': 'COutTime', 'index': 'COutTime', 'editable': true, 'width': 75, 'align': 'center', editrules: { required: false }, editoptions: { size: 15, maxlengh: 10, dataInit: function (element) { $(element).timeEntry({ showSeconds: true }) } } },
                        { 'name': 'Remarks', 'index': 'Remarks', 'width': 100,'editable': true },
                        { 'name': 'DayStatus', 'index': 'CDayStatus', 'width': 50, 'align': 'center' },
                        { 'name': 'OT', 'index': 'OT', 'width': 50, 'align': 'center' },
                        { 'name': 'CDayStatus', 'index': 'CDayStatus', 'width': 50, 'align': 'center' },
                        { 'name': 'COT', 'index': 'COT', 'width': 50, 'align': 'center' },
                        { 'name': 'LunchOutTime', 'index': 'LunchOutTime', 'width': 60, 'align': 'center' },
                        { 'name': 'LunchInTime', 'index': 'LunchInTime', 'width': 60, 'align': 'center' },
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdAttManual_pager')
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
                , shrinkToFit: false
				, caption: 'Attendence Manual-2'
				, autowidth: true
                , onSelectRow: function (id) {
                    var ids = jQuery("#grdAttManual").jqGrid('getDataIDs');
                    if ((ids.length == 1) || (id)) {
                        var grid = jQuery("#grdAttManual");
                        grid.restoreRow(lastSelectedRow);

                        grid.editRow(id, true, '', '', '', '',
                                function (id) {

//                                    var retVal = jQuery.ajax
//	                                                (
//	                                                   {
//	                                                       url: '../GridHelperClasses/DataHandler.ashx?CallMode=Shoilee_MaterialIssue&ID=' + id,
//	                                                       async: false
//	                                                   }
//                                                   ).responseText;
//                                    if (retVal == "True") {
//                                        ShowMessageBox("Shoilee", "Your Stock Is Going To Be Negative Please Rectify Your Entry!");
//                                    }
//                                    $("#grdAttManual").trigger("reloadGrid");
                                });
                        lastSelectedRow = id;
                    }
                }
                , viewsortcols: [false, 'vertical', true]
				, height: '240'
			    //                , editDialogOptions:
			    //				                {
			    //				                    modal: true,
			    //				                    closeAfterEdit: true,
			    //				                    closeOnEscape: false,
			    //				                    viewPagerButtons: false,
			    //				                    // beforeShowForm: fn_beforeShowForm,
			    //				                    bottominfo: "Fields marked with (*) are required"
			    //				                }
			}
		)
		.navGrid
		(
			'#grdAttManual_pager',
			{
			    'edit': false, 'add': false, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
	    // , jQuery('#grdAttManual').getGridParam('editDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);


var lastSelectedRow;
function editRow(id) {
    if (id) {
        var grid = jQuery("#grdAttManual");
        grid.restoreRow(lastSelectedRow);
        grid.editRow(id, true);
        lastSelectedRow = id;
    }
};