jQuery(document).ready
		(
			function () {
			    jQuery('#grdShiftInfo').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdShiftInfo&SessionVarName=OtherSalaryRule_ShiftPlanList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdShiftInfo&editMode=1&SessionVarName=OtherSalaryRule_ShiftPlanList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', '...', 'Shift ID','Alias']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'IsChecked', 'index': 'IsChecked', 'align': 'center', width: 20 },
                                { 'name': 'ShiftID', 'index': 'ShiftID', 'width': 80 },
                                { 'name': 'ALISE', 'index': 'ALISE', 'width': 100 }
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdShiftInfo_pager')
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
						, caption: 'Shift Info'
						, autowidth: true
						, height: '80'
						, gridComplete: addCheckBox_grdShiftInfo
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdShiftInfo_pager',
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

function addCheckBox_grdShiftInfo() {
    var SessionVarName = 'OtherSalaryRule_ShiftPlanList';
    var ColumnName = 'IsChecked';

    var ids = jQuery("#grdShiftInfo").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdShiftInfo").jqGrid('getRowData', cid);
        var chk;
        if (data.IsSaved == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {

            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";

        }
        jQuery("#grdShiftInfo").jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};
