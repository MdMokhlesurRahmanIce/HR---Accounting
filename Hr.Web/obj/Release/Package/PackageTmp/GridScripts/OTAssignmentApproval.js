jQuery(document).ready
(
	function () {
	    jQuery('#grdOTAssignmentApproval').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdOTAssignmentApproval&SessionVarName=OTAssignmentApproval_OTAssignmentList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdOTAssignmentApproval&editMode=1&SessionVarName=OTAssignmentApproval_OTAssignmentList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', '...', 'Code', 'Name', 'Designation', 'Shift', 'StaffCategory', 'Workdate', 'OTHour', 'PreviousOT']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'IsChecked', 'index': 'IsChecked', 'align': 'center', 'width': 20 },
                        { 'name': 'EmpCode', 'index': 'EmpCode', 'width': 50 },
                        { 'name': 'EmpName', 'index': 'EmpName', 'width': 50 },
                        { 'name': 'DesigName', 'index': 'DesigName', 'width': 50 },
                        { 'name': 'Shift', 'index': 'Shift', 'width': 50 },
                        { 'name': 'StaffCategory', 'index': 'StaffCategory', 'width': 50 },
                        { 'name': 'WorkDate', 'index': 'WorkDate', 'width': 50 },
                        { 'name': 'OTHour', 'index': 'OTHour', 'width': 50 },
                        { 'name': 'PreviousOT', 'index': 'PreviousOT', 'width': 50 },
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdOTAssignmentApproval_pager')
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
                , beforeSelectRow: function (rowid, e) {
                    var sessionVarName = "OTAssignmentApproval_OTAssignmentList";
                    var retVal = jQuery.ajax
                    (
                        {
                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllCheckOrUncheck&SessionVarName=' + sessionVarName,
                            async: false
                        }
                    ).responseText
                    if (retVal == "True") {
                        $("#cphBody_cphInfbody_chkOTAssignment").attr('checked', false);
                    }
                    else {
                        $("#cphBody_cphInfbody_chkOTAssignment").attr('checked', true);
                    }
                }
				, sortable: true
				, rowNum: 10
				, rowList: [10, 20, 30]
				, caption: 'OT Assignment Approval'
				, autowidth: true
				, height: '230'
			    , gridComplete: addCheckBox_grdOTAssignmentApproval
				, viewsortcols: [false, 'vertical', true]

			}
		)
		.navGrid
		(
			'#grdOTAssignmentApproval_pager',
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

function addCheckBox_grdOTAssignmentApproval() {

    var SessionVarName = 'OTAssignmentApproval_OTAssignmentList';
    var ColumnName = 'IsChecked';
    var isSelectAll = 1;

    var ids = jQuery("#grdOTAssignmentApproval").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdOTAssignmentApproval").jqGrid('getRowData', cid);
        var chk;
        if (data.IsChecked == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
            isSelectAll = 0;
        }
        jQuery("#grdOTAssignmentApproval").jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};

