jQuery(document).ready
(
	function () {
	    jQuery('#grdAttPaymentRule').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdAttPaymentRule&SessionVarName=AttendancePaymentInfo_AttPaymentRuleList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdAttPaymentRule&editMode=1&SessionVarName=AttendancePaymentInfo_AttPaymentRuleList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Attendance Payment Rule Name', 'Rule For']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 20, 'index': 'VID' },
                        { 'name': 'AttPaymentRuleCode', 'index': 'AttPaymentRuleCode', 'align': 'left', 'width': 70 },
                        { 'name': 'RuleFor', 'index': 'RuleFor', 'width': 90 }
                    ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdAttPaymentRule_pager')
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
				, caption: 'Attendance Payment Rule(s)'
				, autowidth: true
				, height: '200'
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdAttPaymentRule_pager',
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


