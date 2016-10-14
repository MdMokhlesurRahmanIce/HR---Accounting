jQuery(document).ready
		(
			function () {
			    jQuery('#grdHKEntry').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdHKEntry&SessionVarName=HouseKeepingEntry_ParentList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdHKEntry&editMode=1&SessionVarName=HouseKeepingEntry_ParentList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', '...', 'Parent']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'IsSaved', 'index': 'IsSaved', 'align': 'center', width: 40 },
                                { 'name': 'HKName', 'index': 'HKName', 'width': 500, editable: true, editrules: { required: true} },

							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdHKEntry_pager')
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
						, caption: 'Parent List'
						, autowidth: true
						, height: '100'
						, gridComplete: addCheckBox_grdHKEntry
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdHKEntry_pager',
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

function addCheckBox_grdHKEntry() {
    var SessionVarName = 'HouseKeepingEntry_ParentList';
    var ColumnName = 'IsSaved';

    var ids = jQuery("#grdHKEntry").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdHKEntry").jqGrid('getRowData', cid);
        var chk;
        if (data.IsSaved == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#grdHKEntry").jqGrid('setRowData', ids[i], { IsSaved: chk });

    }
};
