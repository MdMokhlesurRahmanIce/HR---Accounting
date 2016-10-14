jQuery(document).ready
		(
			function () {
			    jQuery('#grdHourlyLeaveApproval').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdDayLeaveApproval&SessionVarName=LeaveTransactionApproval_HourlyLeaveApproval'
						, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdDayLeaveApproval&editMode=1&SessionVarName=LeaveTransactionApproval_HourlyLeaveApproval'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Code', 'Name', 'Designation', 'Department', 'Leave Type', 'Date', 'From', 'To', 'Hour', 'Reason', 'Forwarded', 'Recomended', 'Approved', 'Rejected']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 25, 'index': 'VID' },
								{ 'name': 'EmpCode', 'index': 'EmpCode', 'width': 80, 'editable': false },
                                { 'name': 'EmpName', 'index': 'EmpName', 'width': 120, 'editable': false },
								{ 'name': 'Designation', 'index': 'Designation', 'width': 100, 'editable': true },
                                { 'name': 'Department', 'index': 'Department', 'width': 100, 'editable': true },
								{ 'name': 'LeaveType', 'index': 'LeaveType', 'width': 80, 'editable': true },
								{ 'name': 'LeaveDate', 'index': 'LeaveDate', 'width': 90, 'editable': true },
								{ 'name': 'LeaveFrom', 'index': 'LeaveFrom', 'width': 90, 'editable': true },
                                { 'name': 'LeaveTo', 'index': 'LeaveTo', 'width': 70, 'editable': false },
                                { 'name': 'TotalHour', 'index': 'TotalHour', 'width': 50, 'editable': true },
                                { 'name': 'LeaveReason', 'index': 'LeaveReason', 'width': 100, 'editable': true, 'align': 'center' },
                                { 'name': 'IsForwarded', 'index': 'IsForwarded', 'width': 50, 'editable': true, 'align': 'center' },
                                { 'name': 'IsRecomended', 'index': 'IsRecomended', 'width': 50, 'editable': true, 'align': 'center' },
                                { 'name': 'IsApproved', 'index': 'IsApproved', 'width': 50, 'editable': true, 'align': 'center' },
                                { 'name': 'IsRejected', 'index': 'IsRejected', 'width': 50, 'editable': true, 'align': 'center' },
							]
						, viewrecords: true
						, rownumbers: true
						, scrollrows: true
						, pager: jQuery('#grdHourlyLeaveApproval_pager')
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
						, caption: 'Hourly Leave Approval'
						, width: '100%'
				        , height: '150'
					    //						, onSelectRow: function (id) {
					    //						    alert("shamim");
					    //						    var sessionVarName = "LeaveTransactionApproval_DayLeaveApproval";
					    //						    var retVal = jQuery.ajax
					    //                                (
					    //                                    {
					    //                                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllCheckOrUncheck&SessionVarName=' + sessionVarName,
					    //                                        async: false
					    //                                    }
					    //                                ).responseText
					    //						    if (retVal == "True") {
					    //						        $("#cphBody_cphInfbody_chkForwarded").attr('checked', false);
					    //						    }
					    //						    else {
					    //						        $("#cphBody_cphInfbody_chkForwarded").attr('checked', true);
					    //						    }
					    //						}
                        , gridComplete: addCheckBox_Approved
						, viewsortcols: [true, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdHourlyLeaveApproval_pager',
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


function addCheckBox_Approved() {
    var SessionVarName = 'LeaveTransactionApproval_HourlyLeaveApproval';
    var ColumnName = 'IsApproved';
    var ids = jQuery("#grdHourlyLeaveApproval").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdHourlyLeaveApproval").jqGrid('getRowData', cid);
        var chk;
        if (data.IsApproved == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#grdHourlyLeaveApproval").jqGrid('setRowData', ids[i], { IsApproved: chk });
        // AllcheckOrUncheck(ColumnName);
    }

    var ColumnName = 'IsRecomended';
    var ids = jQuery("#grdHourlyLeaveApproval").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdHourlyLeaveApproval").jqGrid('getRowData', cid);
        var chk;
        if (data.IsRecomended == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#grdHourlyLeaveApproval").jqGrid('setRowData', ids[i], { IsRecomended: chk });
        // AllcheckOrUncheck(ColumnName);
    }

    var ColumnName = 'IsForwarded';
    var ids = jQuery("#grdHourlyLeaveApproval").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdHourlyLeaveApproval").jqGrid('getRowData', cid);
        var chk;
        if (data.IsForwarded == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#grdHourlyLeaveApproval").jqGrid('setRowData', ids[i], { IsForwarded: chk });
        // AllcheckOrUncheck(ColumnName);
    }

    var ColumnName = 'IsRejected';
    var ids = jQuery("#grdHourlyLeaveApproval").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdDayLeaveApproval").jqGrid('getRowData', cid);
        var chk;
        if (data.IsRejected == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#grdHourlyLeaveApproval").jqGrid('setRowData', ids[i], { IsRejected: chk });
        // AllcheckOrUncheck(ColumnName);
    }
}