jQuery(document).ready
		(
			function () {
			    jQuery('#grdContactList').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdContactList&SessionVarName=ContactInfo_ContactList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdContactList&editMode=1&SessionVarName=ContactInfo_ContactList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Name', 'Card No']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'Name', 'index': 'Name', 'width': 100 },
								{ 'name': 'CardNo', 'index': 'CardNo', 'width': 100 }
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdContactList_pager')
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
						, caption: 'Contact List'
						, autowidth: true
						, height: '250'
						, viewsortcols: [false, 'vertical', true]

					}
				)
				.navGrid
				(
					'#grdContactList_pager',
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



