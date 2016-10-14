jQuery(document).ready
(
	function () {
	    try {
	        jQuery('#grdSummaryBalance').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSummaryBalance&SessionVarName=TrialBalance_SummaryBalanceList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSummaryBalance&editMode=1&SessionVarName=TrialBalance_SummaryBalanceList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Account Head', 'Dr', 'Cr']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'COAName', 'index': 'COAName', 'width': 70 }, //, editable: true, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=PFVoucher_AccCOAList&DataTextField=COAName&NeedBlank=Empty&DataValueField=COAKey')} },
				        {'name': 'Dr', 'index': 'Dr', 'width': 70, 'align': 'right' },
				        { 'name': 'Cr', 'index': 'Cr', 'width': 70, 'align': 'right' },
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdSummaryBalance_pager')
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
			'#grdSummaryBalance_pager',
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

