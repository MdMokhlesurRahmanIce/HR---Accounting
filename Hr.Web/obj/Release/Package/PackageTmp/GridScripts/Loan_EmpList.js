jQuery(document).ready
(
	function () {
	    jQuery('#grdEmployeeList').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmployeeList&SessionVarName=LoanAndAdvancedManagement_EmployeeList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmployeeList&editMode=1&SessionVarName=LoanAndAdvancedManagement_EmployeeList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Code', 'Name']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
						{ 'name': 'EmpCode', 'index': 'EmpCode', 'width': 60 },
						{ 'name': 'EmpName', 'index': 'EmpName', 'width': 80 }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdEmployee_pager')
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
                , beforeSelectRow: function (rowid, e) {
                    var _empCode = jQuery("#grdEmployeeList").getCell(rowid, "EmpCode");
                    if (_empCode == '') return;
                    __doPostBack("Employee", _empCode);
                }
				, sortable: true
				, rowNum: 20
				, rowList: [10, 20, 30]
				, caption: 'Employee List'
				, autowidth: true
				, height: '320'
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdEmployee_pager',
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

