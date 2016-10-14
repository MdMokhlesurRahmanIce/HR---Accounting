jQuery(document).ready
		(
			function () {
			    jQuery('#LeaveTypeSelection').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=LeaveTypeSelection&SessionVarName=OtherSalaryRule_LeaveTypeList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=LeaveTypeSelection&editMode=1&SessionVarName=OtherSalaryRule_LeaveTypeList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', '...', 'Leave ID', 'Type']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'IsChecked', 'index': 'IsChecked', 'align': 'center', width: 20 },
                                { 'name': 'LeavePolicyID', 'index': 'LeavePolicyID', 'width': 80 },
                                { 'name': 'LeaveType', 'index': 'LeaveType', 'width': 100 }
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#LeaveTypeSelection_pager')
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
						, caption: 'Leave Type Selection'
						, autowidth: true
						, height: '80'
						, gridComplete: addCheckBox_LeaveTypeSelection
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#LeaveTypeSelection_pager',
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

function addCheckBox_LeaveTypeSelection() {
    var SessionVarName = 'OtherSalaryRule_LeaveTypeList';
    var ColumnName = 'IsChecked';

    var ids = jQuery("#LeaveTypeSelection").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#LeaveTypeSelection").jqGrid('getRowData', cid);
        var chk;
        if (data.IsSaved == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {

            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";

        }
        jQuery("#LeaveTypeSelection").jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};
