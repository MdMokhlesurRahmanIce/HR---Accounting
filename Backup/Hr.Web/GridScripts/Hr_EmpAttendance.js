jQuery(document).ready
(
	function () {
	    jQuery('#grdEmpAttProcess').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpAttProcess&SessionVarName=EmployeeAttendace_AttList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpAttProcess&editMode=1&SessionVarName=EmployeeAttendace_AttList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Employee<br>Code', 'Employee<br>Name', 'Designation', 'Orgnization', 'In-Time', 'Out-Time', 'IsManual', 'Default<br>In / Out Time']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'EmpCode', 'index': 'EmpCode', 'width': 50 },
                        { 'name': 'EmpName', 'index': 'EmpName', 'width': 200 },
                        { 'name': 'DesigName', 'index': 'DesigName', 'width': 100 },
                        { 'name': 'OrgName', 'index': 'OrgName', 'width': 100 },
                        { 'name': 'InTime', 'index': 'InTime', 'editable': true, 'width': 50, editrules: { required: false }, editoptions: { size: 15, maxlengh: 10, dataInit: function (element) { $(element).timepicker({ showSecond: false, timeFormat: 'hh:mm:ss', stepHour: 1, stepMinute: 1, hourGrid: 4, minuteGrid: 10 }) } } },
                        { 'name': 'OutTime', 'index': 'OutTime', 'editable': true, 'width': 50, editrules: { required: false }, editoptions: { size: 15, maxlengh: 10, dataInit: function (element) { $(element).timepicker({ showSecond: false, timeFormat: 'hh:mm:ss', stepHour: 1, stepMinute: 1, hourGrid: 4, minuteGrid: 10 }) } } },
                        { 'name': 'IsManual', 'index': 'IsManual', 'width': 50, editable: true, 'hidden': true },
                        { 'name': 'IsDefault', 'index': 'IsDefault', 'align': 'center', width: 50 }
                     ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdAttProcess_pager')
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
                , editDialogOptions:
				        {
				            modal: true,
				            closeAfterEdit: true,
				            closeOnEscape: false,
				            viewPagerButtons: false,
				            recreateForm: true,
				            beforeShowForm: fn_beforeShowForm_edit,
				            bottominfo: "Fields marked with (*) are required"
				        }
                , gridComplete: addCheckBox_grdAtt
				, caption: 'Attendence Process'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdAttProcess_pager',
			{
			    'edit': true, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
           , jQuery('#grdEmpAttProcess').getGridParam('editDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);


function fn_beforeShowForm_edit(formid) {
    var nameColumnField = $('#tr_InTime', formid);
    $('<tr class="FormData" id="tr_AddInfo"><td><input type=textbox style="width:0px; border:0 solid"></td></tr>').insertBefore(nameColumnField);

    var isManual = $("#IsManual").val();
    if (isManual == 'False') {
        jQuery("#InTime").attr("disabled", true);
        jQuery("#OutTime").attr("disabled", true);
    }
    else {
        jQuery("#InTime").attr("disabled", false);
        jQuery("#OutTime").attr("disabled", false);
    }
}

function addCheckBox_grdAtt() {

    var SessionVarName = 'EmployeeAttendace_AttList';
    var ColumnName = 'IsDefault';

    var ids = jQuery("#grdEmpAttProcess").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdEmpAttProcess").jqGrid('getRowData', cid);
        var chk;
        if (data.IsDefault == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#grdEmpAttProcess").jqGrid('setRowData', ids[i], { IsDefault: chk });


        if (data.IsManual == 'False') {
            chk = "<input type=\"checkbox\" disabled=\"disabled\" >";
        }
        jQuery("#grdEmpAttProcess").jqGrid('setRowData', ids[i], { IsDefault: chk });
    }

};

