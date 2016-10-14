jQuery(document).ready
(
	function () {
	    jQuery('#grdMultiselectParameter').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdMultiselectParameter&SessionVarName=ucEmpSearch_EntityList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', '', '']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'index': 'VID' },
						{ 'name': 'HKID', 'index': 'HKID', 'hidden': true, searchoptions: { sopt: ['cn']} },
						{ 'name': 'HKName', 'index': 'HKName', "width": 220, searchoptions: { sopt: ['cn']} }
					]
                , multiselect: true
				, viewrecords: true
				, scroll: true
				, scrollrows: true
			    , pager: jQuery('#grdMultiselectParameter_pager')
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
				, pginput: false
				, rowNum: 20
				, rowList: [20, 30, 40]
			    , width: '320'
				, height: '270'
				, viewsortcols: [false, 'vertical', true]
			}
		)
    	.navGrid
   		(
   			'#grdMultiselectParameter_pager',
   			{
   			    'edit': false, 'add': false, 'del': false, 'search': false, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
   			}
	    );
   			jQuery("#grdMultiselectParameter").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false });
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);
