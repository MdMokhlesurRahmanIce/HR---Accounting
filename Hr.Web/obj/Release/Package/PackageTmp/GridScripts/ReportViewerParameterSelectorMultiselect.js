jQuery(document).ready
(
	function() 
	{
	    jQuery('#grdParameterSelectorMultiselect').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdParameterSelectorMultiselect&SessionVarName=ReportViewer_FilterValueList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', '', '']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'index': 'VID' },
						{ 'name': 'Values', 'index': 'Values', 'hidden': true, searchoptions: { sopt: ['cn']}},
						{ 'name': 'DisplayMember', 'index': 'DisplayMember', "width": 220, searchoptions: { sopt: ['cn']}}					                      
					]
                , multiselect: true
				, viewrecords: true	
				, scroll:true			
				, scrollrows: true	
			    , pager: jQuery('#grdParameterSelectorMultiselect_pager')
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
   			'#grdParameterSelectorMultiselect_pager',
   			{
   			    'edit': false, 'add': false, 'del': false, 'search': false, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
   			}
	    );
	    jQuery("#grdParameterSelectorMultiselect").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false });
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) 
	    {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);
