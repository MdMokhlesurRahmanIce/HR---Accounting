jQuery(document).ready
(
	function () {
	    try {
	        jQuery('#grdBS').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdBS&SessionVarName=BalanceSheet_BalanceSheetList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdBS&editMode=1&SessionVarName=BalanceSheet_BalanceSheetList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Account Head', 'Balance']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'COAName', 'index': 'COAName', 'width': 70 },
				        { 'name': 'Bal', 'index': 'Bal', 'width': 70, 'align': 'right' },
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdBS_pager')
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
			    //                , footerrow: true
			    //	            , userDataOnFooter: true
			    //				, postData: { FooterRowCaption: '"COAKey":"Total:"',
			    //				    AggregateColumn: '[Dr]:Sum,[Cr]:Sum'
			    //				}
				, rowNum: 10
				, rowList: [10, 20, 30]
				, caption: 'Balance Sheet'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdBS_pager',
			{
			    'edit': false, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
		);
	    }
	    catch (e) {
	        alert(e.ToString());
	    }
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

