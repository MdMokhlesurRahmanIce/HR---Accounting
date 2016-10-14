jQuery(document).ready
(
	function () {
	    jQuery('#grdEmpHist').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpHist&SessionVarName=EmployeeBasicInformation_EmpHistList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpHist&editMode=1&SessionVarName=EmployeeBasicInformation_EmpHistList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Employer Name', 'Designation', 'Date From', 'Date To', 'Emp. Addr', 'Job Desc', 'Remarks']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'index': 'VID' },
						{ 'name': 'EmployerName', 'index': 'EmployerName', 'width': 120, editable: true },
						{ 'name': 'LastDesigKey', 'index': 'LastDesigKey', 'width': 100, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' } },
						{ 'name': 'DateFrom', 'index': 'DateFrom', 'width': 100, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1930:2012' }) } } },
						{ 'name': 'DateTo', 'index': 'DateTo', 'width': 100, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1930:2012' }) } } },
						{ 'name': 'EmployerAddr', 'index': 'EmployerAddr', 'width': 100, edittype: "textarea", editable: true, editoptions: { rows: "2", cols: "15"} },
						{ 'name': 'JobDesc', 'index': 'JobDesc', editable: true, 'width': 100, edittype: "textarea", editoptions: { rows: "2", cols: "15"} },
						{ 'name': 'Remark', 'index': 'Remark', editable: true, 'width': 130, edittype: "textarea", editoptions: { rows: "2", cols: "15"} },
					]
				, viewrecords: true
				, rownumbers: true
                , scroll: true
                , shrinkToFit: false
				, scrollrows: true
				, pager: jQuery('#grdEmpHist_pager')
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
				, caption: 'Employment Information'
				, autowidth: true
				, height: '100%'
                , width: '100%'
				, viewsortcols: [false, 'vertical', true]
                , addDialogOptions:
				                {
				                   // modal: true,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    //beforeSubmit: BeforeSubmit_Company,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , editDialogOptions:
				                {
				                   // modal: true,
				                    closeAfterEdit: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    //beforeSubmit: BeforeSubmit_Company,
				                    bottominfo: "Fields marked with (*) are required"
				                }
			}
		)
		.navGrid
		(
			'#grdEmpHist_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdEmpHist').getGridParam('editDialogOptions')
   			, jQuery('#grdEmpHist').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);
