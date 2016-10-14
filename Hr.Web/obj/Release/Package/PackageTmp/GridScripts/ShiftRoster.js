jQuery(document).ready
		(
			function () {
			    jQuery('#grdShiftPlan').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdShiftPlan&SessionVarName=ShiftRosterProcess_ShiftPlanList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdShiftPlan&editMode=1&SessionVarName=ShiftRosterProcess_ShiftPlanList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', '...', 'Shift', 'ShiftIntime', 'ShiftOutTime', 'Type']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                                { 'name': 'IsChecked', 'index': 'IsChecked', 'align': 'center', 'width': 20 },
								{ 'name': 'ALISE', 'index': 'ALISE', 'width': 50 },
                                { 'name': 'ShiftIntime', 'index': 'ShiftIntime', 'width': 50 },
                                { 'name': 'ShiftOutTime', 'index': 'ShiftOutTime', 'width': 50 },
                                { 'name': 'Type', 'index': 'Type', 'editable': true, 'width': 50, formatter: 'select', edittype: 'select', editoptions: { value: "1:Default;2:OT" }, searchoptions: { defaultValue: 1} }
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdShiftPlan_pager')
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
						, caption: 'Entities'
						, autowidth: true
						, height: '100%'
						, viewsortcols: [false, 'vertical', true]
                        , editDialogOptions:
				                {
				                    modal: true,
				                    closeAfterEdit: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    bottominfo: "Fields marked with (*) are required"
				                }
                      , gridComplete: addCheckBox_grdShiftPlan
					}
				)
				.navGrid
				(
					'#grdShiftPlan_pager',
					{
					    'edit': true, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
                 , jQuery('#grdShiftPlan').getGridParam('editDialogOptions')
   			     , jQuery('#grdShiftPlan').getGridParam('addDialogOptions')
			     );
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);

function addCheckBox_grdShiftPlan() {

    var SessionVarName = 'ShiftRosterProcess_ShiftPlanList';
    var ColumnName = 'IsChecked';
    var isSelectAll = 1;

    var ids = jQuery("#grdShiftPlan").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdShiftPlan").jqGrid('getRowData', cid);
        var chk;
        if (data.IsChecked == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
            isSelectAll = 0;
        }
        jQuery("#grdShiftPlan").jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};




