jQuery(document).ready
(
	function () {
	    jQuery('#grdEmployeeList').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmployeeList&SessionVarName=EmployeeBasicInformation_EmployeeList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmployeeList&editMode=1&SessionVarName=EmployeeBasicInformation_EmployeeList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Code', 'Name','Col 3','Col 4','Col 5']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
						{ 'name': 'EmpCode', 'index': 'EmpCode', 'width': 60 },
						{ 'name': 'EmpName', 'index': 'EmpName', 'width': 150 },
                        { 'name': 'Col3', 'index': 'Col3', 'width': 80 },
                        { 'name': 'Col4', 'index': 'Col4', 'width': 80 }, 
                        { 'name': 'Col5', 'index': 'Col5', 'width': 80 }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
                , shrinkToFit: false
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
                    else {
                        retval = jQuery.ajax
                        (
                            {
                                url: rootPath + "GridHelperClasses/SearchGridHandler.ashx?SearchMode=_SearchByEmpCode&MultiSelect=" + false + "&SelectedVids=" + 0 + "&empCode=" + _empCode,
                                async: false
                            }
                        ).responseText;
                        __doPostBack("SearchEmployee");
                    }
                }
				, sortable: true
				, rowNum: 20
				, rowList: [20, 40, 60]
				, caption: 'Employee List'
				, autowidth: true
				, height: '100%'
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

