jQuery(document).ready
(
	function () {
	    jQuery('#grdLoanProcess').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdLoanProcess&SessionVarName=LoanAndAdvancedManagement_LoanProcessList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdLoanProcess&editMode=1&SessionVarName=LoanAndAdvancedManagement_LoanProcessList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Loan Code', 'No', 'Date', 'Amount', 'Balance', 'Salary Proc ID', 'Interest Amount']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 20, 'index': 'VID' },
                        { 'name': 'LoanCode', 'index': 'LoanCode', 'align': 'left', 'width': 50 },
                        { 'name': 'PaymentSequence', 'index': 'PaymentSequence', 'width': 30 },
					    { 'name': 'InstallmentDate', 'index': 'InstallmentDate', 'width': 50 },
                        { 'name': 'InstallmentAmount', 'index': 'InstallmentAmount', 'align': 'left', 'width': 50 },
                        { 'name': 'Balance', 'index': 'Balance', 'align': 'left', 'width': 50 },
                        { 'name': 'SalaryProcID', 'index': 'SalaryProcID', 'align': 'left', 'width': 40 },
                        { 'name': 'InterestAmount', 'index': 'InterestAmount', 'align': 'left', 'width': 40 }
                    ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdLoanProcess_pager')
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
				, caption: 'Loan Process'
				, autowidth: true
				, height: '200'
				, viewsortcols: [false, 'vertical', true]
                , onSelectRow: function (id) {
                    var criteria = $("#cphBody_cphInfbody_ddlLoanOrAdvanceReadjustment").val();
                    var interval = $("#cphBody_cphInfbody_txtMonthInterval").val();
                    var retVal = jQuery.ajax
                        (
                            {
                                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=LoanAdjustment&VID=' + id + '&Criteria=' + criteria+'&Interval='+interval,
                                async: false
                            }
                        ).responseText;

                    $("#grdLoanProcess").trigger("reloadGrid");
                    return false
                }
			}
		)
		.navGrid
		(
			'#grdLoanProcess_pager',
			{
			    'edit': false, 'add': false, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);