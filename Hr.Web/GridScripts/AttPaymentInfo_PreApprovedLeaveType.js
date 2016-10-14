jQuery(document).ready
(
	function () {
	    jQuery('#grdPreApprovedLeaveType').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdPreApprovedLeaveType&SessionVarName=AttendancePaymentInfo_LeavePolicyList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdPreApprovedLeaveType&editMode=1&SessionVarName=AttendancePaymentInfo_LeavePolicyList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID','...', 'Leave Policy ID', 'Leave Type']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 20, 'index': 'VID' },
                        { 'name': 'IsChecked', 'index': 'IsChecked', 'align': 'center', 'width': 20 },
                        { 'name': 'LeavePolicyID', 'index': 'LeavePolicyID', 'align': 'left', 'width': 40 },
                        { 'name': 'LeaveType', 'index': 'LeaveType', 'align': 'left', 'width': 40 }
                    ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdPreApprovedLeaveType_pager')
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
				, caption: 'Pre-Approved Leave Type'
				, width: '220'
				, height: '200'
				, viewsortcols: [false, 'vertical', true]
                , gridComplete: addCheckBox_grdPreApprovedLeaveType
			}
		)
		.navGrid
		(
			'#grdPreApprovedLeaveType_pager',
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

function addCheckBox_grdPreApprovedLeaveType() {

    var SessionVarName = 'AttendancePaymentInfo_LeavePolicyList';
    var ColumnName = 'IsChecked';

    var ids = jQuery("#grdPreApprovedLeaveType").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdPreApprovedLeaveType").jqGrid('getRowData', cid);
        var chk;
        if (data.IsChecked == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#grdPreApprovedLeaveType").jqGrid('setRowData', ids[i], { IsChecked: chk });
    }
};

