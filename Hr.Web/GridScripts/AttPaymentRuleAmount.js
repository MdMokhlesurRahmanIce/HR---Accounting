jQuery(document).ready
(
	function () {
	    jQuery('#grdAttPaymentRuleAmount').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdAttPaymentRuleAmount&SessionVarName=AttendancePaymentInfo_AttPaymentRuleAmountList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdAttPaymentRuleAmount&editMode=1&SessionVarName=AttendancePaymentInfo_AttPaymentRuleAmountList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Payment Name', 'Calculation', 'Report Head']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 20, 'index': 'VID' },
                        { 'name': 'SalaryHeadID', 'index': 'SalaryHeadID', 'align': 'left', 'width': 70 },
                        { 'name': 'Calculation', 'index': 'Calculation', 'width': 90 },
					    { 'name': 'ReportHeadID', 'index': 'ReportHeadID', 'width': 60, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=AttendancePaymentInfo_SalaryHeadList&DataTextField=HeadName&NeedBlank=Empty&DataValueField=SalaryHeadKey')} }
                    ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdAttPaymentRuleAmount_pager')
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
				, caption: 'Payment Policy'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdAttPaymentRuleAmount_pager',
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


