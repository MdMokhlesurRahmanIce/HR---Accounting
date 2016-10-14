jQuery(document).ready
(
	function () {
	    try {
	        jQuery('#grdLedger').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdLedger&SessionVarName=Ledger_AccVoucherDetList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdLedger&editMode=1&SessionVarName=Ledger_AccVoucherDetList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Voucher Date', 'Voucher No', 'Pay Rec', 'Voucher Description', 'Dr', 'Cr']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'VoucherDate', 'index': 'VoucherDate', 'width': 55 },
                        { 'name': 'VoucherNo', 'index': 'VoucherNo', 'width': 50 },
                        { 'name': 'PayRec', 'index': 'PayRec', 'width': 75 },
                        { 'name': 'VoucherDesc', 'index': 'VoucherDesc', 'width': 100 },
				        { 'name': 'Dr', 'index': 'Dr', 'width': 40, 'align': 'right' },
				        { 'name': 'Cr', 'index': 'Cr', 'width': 40, 'align': 'right' },
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdLedger_pager')
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
				, postData: { FooterRowCaption: '"COAKey":"Total:"',
				    AggregateColumn: '[Dr]:Sum,[Cr]:Sum'
				}
				, rowNum: 10
				, rowList: [10, 20, 30]
				, caption: 'Voucher'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdLedger_pager',
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

