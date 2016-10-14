jQuery(document).ready
		(
			function () {
			    jQuery('#grdUserGroupList').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdUserGroupList&SessionVarName=UserInformation_UserGroupList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdUserGroupList&editMode=1&SessionVarName=UserInformation_UserGroupList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Group Name']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'GroupName', 'index': 'GroupName', width: 60 }
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdUserGroupList_pager')
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
						, caption: 'Group'
						, autowidth: true
						, height: '100%'
					    //, gridComplete: addCheckBox_grdApplication
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdUserGroupList_pager',
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