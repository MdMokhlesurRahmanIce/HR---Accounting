jQuery(document).ready
		(
			function () {
			    jQuery('#grdContactCategoryList').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdContactCategoryList&SessionVarName=ContactInfo_ContactCategoryList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdContactCategoryList&editMode=1&SessionVarName=ContactInfo_ContactCategoryList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID','...', 'Name']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                                { 'name': 'IsChecked', 'index': 'IsChecked', 'width': 10 },
								{ 'name': 'Name', 'index': 'Name', 'width': 85 }
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdContactCategoryList_pager')
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
						, caption: 'Contact Category List'
						, autowidth: true
						, height: '125'
                        , gridComplete: addCheckBox_grdContactCategory
						, viewsortcols: [false, 'vertical', true]

					}
				)
				.navGrid
				(
					'#grdContactCategoryList_pager',
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

function addCheckBox_grdContactCategory() {
    var SessionVarName = 'ContactInfo_ContactCategoryList';
    var ColumnName = 'IsChecked';

    var ids = jQuery("#grdContactCategoryList").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdContactCategoryList").jqGrid('getRowData', cid);
        var chk;
        if (data.IsSaved == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {

            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#grdContactCategoryList").jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};



