jQuery(document).ready
		(
			function () {
			    jQuery('#grdUserGroup').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdUserGroup&SessionVarName=GroupInfromation_UserGroupList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdUserGroup&editMode=1&SessionVarName=GroupInfromation_UserGroupList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', '...', 'Code', 'Name']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                                { 'name': 'IsSaved', 'index': 'IsSaved', 'align': 'center', width: 7 },
								{ 'name': 'UserCode', 'index': 'UserCode', width: 30 },
								{ 'name': 'Name', 'index': 'Name', width: 70 },
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: false
						, pager: jQuery('#grdUserGroup_pager')
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
					    //, sortname: 'IsSaved desc'
						, rowNum: 10
						, rowList: [10, 20, 30]
						, caption: 'User'
						, autowidth: true
						, height: '180'
						, gridComplete: addCheckBox_UserGroup
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdUserGroup_pager',
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

function addCheckBox_UserGroup() {
    var SessionVarName = 'GroupInfromation_UserGroupList';
    var ColumnName = 'IsSaved';

    var ids = jQuery("#grdUserGroup").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdUserGroup").jqGrid('getRowData', cid);
        var chk;
        if (data.IsSaved == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
            //__doPostBack('curCheckbox', vid);
        }
        else {

            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";

        }
        jQuery("#grdUserGroup").jqGrid('setRowData', ids[i], { IsSaved: chk });

    }
};
