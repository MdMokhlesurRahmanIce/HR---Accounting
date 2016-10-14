jQuery(document).ready
		(
			function () {
			    jQuery('#grdSalaryProcess').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSalaryProcess&SessionVarName=SalaryProcess_SalaryProcessList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSalaryProcess&editMode=1&SessionVarName=SalaryProcess_SalaryProcessList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Code', 'EmpKey', 'Name', 'YearNo', 'MonthNo', 'HeadName', 'Currency <br/> Name', 'Amount', 'Pay Currency <br/> Name', 'Pay Amount']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'EmpCode', 'index': 'EmpCode', 'width': 150 },
                                { 'name': 'EmpKey', 'index': 'EmpKey','hidden': true, 'width': 150 },
                                { 'name': 'EmpName', 'index': 'EmpName', 'width': 200 },
                                { 'name': 'YearNo', 'index': 'YearNo', 'width': 100 },
                                { 'name': 'MonthNo', 'index': 'MonthNo', 'width': 100 },
                                { 'name': 'HeadName', 'index': 'HeadName', 'width': 150 },
                                { 'name': 'CurrencyName', 'index': 'CurrencyName', 'width': 100 },
                                { 'name': 'CalculatedAmount', 'index': 'CalculatedAmount', 'width': 150 },
                                { 'name': 'PayCurrencyName', 'index': 'PayCurrencyName', 'width': 100 },
                                { 'name': 'PayCurrencyValue', 'index': 'PayCurrencyValue', 'width': 150 }
							]
						, viewrecords: true
						, rownumbers: true
						, scrollrows: true
						, pager: jQuery('#grdSalaryProcess_pager')
						, loadError: jqGrid_aspnet_loadErrorHandler
						, hoverrows: true
                        , loadComplete: function () {
                            var ids = jQuery("#grdSalaryProcess").jqGrid('getDataIDs');
                            for (var i = 0; i < ids.length; i++) {
                                var data = jQuery("#grdSalaryProcess").jqGrid('getRowData', ids[i]);
                                if (data.ModifiedOrApprovedFlag == "A") {
                                    ChangeRowColorApproved(i);
                                }
                                if (data.ModifiedOrApprovedFlag == "M") {
                                    ChangeRowColorModified(i);
                                }
                            }
                        }
						, jsonReader:
						{
						    root: 'rows',
						    page: 'currentpage',
						    total: 'totalpages',
						    records: 'pagerecords',
						    repeatitems: false
						}
						, sortable: true
						, rowNum: 20
						, rowList: [20, 40, 60]
						, caption: 'Salary Process'
						, autowidth: true
						, height: '250'
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdSalaryProcess_pager',
					{
					    'edit': false, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
                 , jQuery('#grdSalaryProcess').getGridParam('editDialogOptions')
   			     , jQuery('#grdSalaryProcess').getGridParam('addDialogOptions')
			     );
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);
function ChangeRowColorApproved(rowId) {
    $("#grdSalaryProcess").jqGrid('setRowData', rowId, false, { color: 'red' });
}
function ChangeRowColorModified(rowId) {
    $("#grdSalaryProcess").jqGrid('setRowData', rowId, false, { color: 'green' });
}





