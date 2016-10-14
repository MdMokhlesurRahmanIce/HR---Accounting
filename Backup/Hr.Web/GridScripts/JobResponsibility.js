jQuery(document).ready
(
	function () {
	    jQuery('#grdJobResponsibility').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdJobResponsibility&SessionVarName=EmployeeBasicInformation_JobResponsibilityList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdJobResponsibility&editMode=1&SessionVarName=EmployeeBasicInformation_JobResponsibilityList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Job Name', 'Description', 'From', 'To', 'Weight', 'Assign Date']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
				        { 'name': 'JobName', 'index': 'JobName', 'width': 130, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
						{ 'name': 'Description', 'index': 'Description', 'width': 130, editable: true },
                        { 'name': 'From', 'index': 'From', 'width': 80, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy'}) } } },
                        { 'name': 'To', 'index': 'To', 'width': 80, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy'}) } } },
                        { 'name': 'Weight', 'index': 'Weight', 'width': 70, editable: true },
                        { 'name': 'AssignDate', 'index': 'AssignDate', 'width': 80, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy'}) } } }
                    ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdJobResponsibility_pager')
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
				, caption: 'Job Responsibility'
				, autowidth: true
				, height: '140'
				, viewsortcols: [false, 'vertical', true]
                , addDialogOptions:
				                {
				                    //modal: true,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , editDialogOptions:
				                {
				                   // modal: true,
				                    closeAfterEdit: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    bottominfo: "Fields marked with (*) are required"
				                }
			}
		)
		.navGrid
		(
			'#grdJobResponsibility_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdJobResponsibility').getGridParam('editDialogOptions')
   			, jQuery('#grdJobResponsibility').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);