jQuery(document).ready
		(
			function () {
			    jQuery('#grdContactSubCategoryList').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdContactSubCategoryList&SessionVarName=ContactInfo_ContactSubCategoryList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdContactSubCategoryList&editMode=1&SessionVarName=ContactInfo_ContactSubCategoryList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID','...', 'Name']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                                { 'name': 'IsChecked', 'index': 'IsChecked', 'width': 10 },
								{ 'name': 'Name', 'index': 'Name', 'width': 100 }
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdContactSubCategoryList_pager')
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
						, caption: 'Contact Sub Category List'
						, autowidth: true
						, height: '125'
                        , gridComplete: addCheckBox_grdContactSubCategory
						, viewsortcols: [false, 'vertical', true]

					}
				)
				.navGrid
				(
					'#grdContactSubCategoryList_pager',
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

function addCheckBox_grdContactSubCategory() {
    var SessionVarName = 'ContactInfo_ContactSubCategoryList';
    var ColumnName = 'IsChecked';

    var ids = jQuery("#grdContactSubCategoryList").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdContactSubCategoryList").jqGrid('getRowData', cid);
        var chk;
        if (data.IsSaved == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {

            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#grdContactSubCategoryList").jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};



