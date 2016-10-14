jQuery(document).ready
		(
			function () {
			    jQuery('#grdSalesUploadFromExcel').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSalesUploadFromExcel&SessionVarName=SalesUploader_DailySoWiseSalesList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSalesUploadFromExcel&editMode=1&SessionVarName=SalesUploader_DailySoWiseSalesList'
						, datatype: 'json'
						, page: 1
					    , colNames: ['VID', 'Sales Officer(SO)', 'Section', 'Gross Sales', 'Free Sales', 'Commission', 'PD Commission', 'Net Sales', 'Distributor Com', 'VAT', 'Inventory']
					    , colModel:
					        [
					    	    { 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
					            { 'name': 'SOName', 'index': 'SOName', 'width': 150 },
					            { 'name': 'Section', 'index': 'Section', 'width': 100 },
					            { 'name': 'Gross', 'index': 'Gross', 'width': 100 },
					            { 'name': 'FreeSales', 'index': 'FreeSales', 'width': 150 },
                                { 'name': 'Commission', 'index': 'Commission', 'width': 100 },
                                { 'name': 'PDC', 'index': 'PDC', 'width': 100 },
                                { 'name': 'Cash', 'index': 'Cash', 'width': 100 },
                                { 'name': 'DistributorCom', 'index': 'DistributorCom', 'width': 100 },
                                { 'name': 'VAT', 'index': 'VAT', 'width': 100 },
                                { 'name': 'Inventory', 'index': 'Inventory', 'width': 100 }
					        ]
                        , viewrecords: true
						, rownumbers: true
						, scrollrows: true
						, pager: jQuery('#grdSalesUploadFromExcel_pager')
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
                        , footerrow: true
			            , userDataOnFooter: true
			            , postData: { FooterRowCaption: '"SOName":"Total:"',
			                AggregateColumn: '[Gross]:Sum,[FreeSales]:Sum,[Commission]:Sum,[PDC]:Sum,[Cash]:Sum,[DistributorCom]:Sum,[VAT]:Sum,[Inventory]:Sum'
			            }
						, rowNum: 20
						, rowList: [20, 40, 60]
						, caption: 'Sales Upload'
						, autowidth: true
						, height: '250'
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdSalesUploadFromExcel_pager',
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




