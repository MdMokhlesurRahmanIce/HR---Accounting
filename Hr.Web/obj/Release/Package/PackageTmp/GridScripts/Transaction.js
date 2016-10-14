jQuery(document).ready
(
	function () {
	    try {
	        jQuery('#grdTransaction').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdTransaction&SessionVarName=Transaction_AccVoucherDetList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdTransaction&editMode=1&SessionVarName=Transaction_AccVoucherDetList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID','Voucher No', 'Voucher Date', 'Account Head', 'Dr', 'Cr']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                         { 'name': 'VoucherNo', 'index': 'VoucherNo', 'width':50 },
                        { 'name': 'VoucherDate', 'index': 'VoucherDate', 'width': 70 },
                        { 'name': 'COAName', 'index': 'COAName', 'width': 100 },
				        { 'name': 'Dr', 'index': 'Dr', 'width': 70, 'align': 'right' },
				        { 'name': 'Cr', 'index': 'Cr', 'width': 70, 'align': 'right' },
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdTransaction_pager')
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
				, rowNum: 1000
				, rowList: [10, 20, 30]
				, caption: 'Voucher'
				, autowidth: true
				, height: '300'
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdTransaction_pager',
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

