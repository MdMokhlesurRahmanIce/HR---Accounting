jQuery(document).ready
		(
			function () {
			    jQuery('#grdHourlyLeaveTransacton').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdHourlyLeaveTransacton&SessionVarName=LeaveTransaction_HourlyLeaveTransactions'
						, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdHourlyLeaveTransacton&editMode=1&SessionVarName=LeaveTransaction_HourlyLeaveTransactions'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Type', 'Date', 'From', 'To', 'Hours', 'Reason']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 25, 'index': 'VID' },
								{ 'name': 'LeaveType', 'index': 'LeaveType', 'width': 60, 'editable': false },
                                { 'name': 'LeaveDate', 'index': 'LeaveDate', 'width': 70, 'editable': false },
								{ 'name': 'LeaveFrom', 'index': 'LeaveFrom', 'width': 50, 'editable': false },
								{ 'name': 'LeaveTo', 'index': 'LeaveTo', 'width': 50, 'editable': false },
								{ 'name': 'TotalHour', 'index': 'TotalHour', 'width': 40, 'editable': false },
								{ 'name': 'LeaveReason', 'index': 'LeaveReason', 'width': 100, 'editable': false }
							]
						, viewrecords: true
						, rownumbers: true
						, scrollrows: true
						, pager: jQuery('#grdHourlyLeaveTransacton_pager')
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
						, caption: 'Hourly Leave Transactions'
						, width: '100%'
				        , height: '100%'
						, onSelectRow: function (id) {
//						    selectedID = id;
//						    var spName = "";
//						    var LeaveType = $("#cphBody_cphInfbody_ddlLeaveType option:selected").val();
//						    var LeaveFrom = $("#cphBody_cphInfbody_txtLeaveFrom").val();
//						    var LeaveTo = $("#cphBody_cphInfbody_txtLeaveTo").val();
//						    var LeaveDays = $("#cphBody_cphInfbody_txtDays").val();
//						    var LeaveReason = $("#cphBody_cphInfbody_txtReason").val();
//						    var LeaveAvailPlace = $("#cphBody_cphInfbody_txtAvailPlace").val();
//						    var ContactNo = $("#cphBody_cphInfbody_txtAdditionalContact").val();
//						    var retVal = jQuery.ajax
//                                (
//                                    {

//                                        url: rootPath + 'GridHelperClasses/LV_DataHandler.ashx?CallMode=LeaveTrans_CheckSelectedGridRow&LeaveType=' + LeaveType + '&LeaveFrom=' + LeaveFrom + '&LeaveTo=' + LeaveTo + '&LeaveDays=' + LeaveDays + '&LeaveReason=' + LeaveReason + '&LeaveAvailPlace=' + LeaveAvailPlace + '&ContactNo=' + ContactNo,
//                                        async: false
//                                    }
//                                ).responseText
						    __doPostBack('SelectHourlyLeaveGridRow', id);
						}
						, viewsortcols: [true, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdHourlyLeaveTransacton_pager',
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

//var lastID_editRow_EmploymentHistory;
//function editRow_EmploymentHistory(rowid) {
//    var grid = jQuery("#grdLeaveTransacton");
//    var ids = grid.jqGrid('getDataIDs');
//    if ((ids.length == 1) || (rowid && rowid !== lastID_editRow_EmploymentHistory)) {
//        grid.restoreRow(lastID_editRow_EmploymentHistory);
//        jQuery("#grdLeaveTransacton").jqGrid('editRow', rowid, true);
//        lastID_editRow_EmploymentHistory = rowid;
//    }
//};
