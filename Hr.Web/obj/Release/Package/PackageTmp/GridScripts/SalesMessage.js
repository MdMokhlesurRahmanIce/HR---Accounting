jQuery(document).ready
(
	function () {
	    jQuery('#grdErrorList').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdErrorList&SessionVarName=SalesUploader_errorList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Sales Officer(SO)', 'Message']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 20, 'index': 'VID' },
				        { 'name': 'EmpName', 'index': 'EmpName', 'align': 'center', 'width': 200 },
                        { 'name': 'Error', 'index': 'Error', 'align': 'center', 'width': 300 }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdErrorList_pager')
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
				, caption: 'Message'
				, width: '620'
				, height: '240'
				, viewsortcols: [false, 'vertical', true]
			}
		)
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);