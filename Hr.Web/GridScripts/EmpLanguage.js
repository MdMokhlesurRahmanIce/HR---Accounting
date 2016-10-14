jQuery(document).ready
(
	function () {
	    jQuery('#grdEmpLanguage').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpLanguage&SessionVarName=EmployeeBasicInformation_EmpLanguageList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpLanguage&editMode=1&SessionVarName=EmployeeBasicInformation_EmpLanguageList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Language', 'Writing', 'Reading', 'Spoken', 'Mother Language']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
				        { 'name': 'LanguageName', 'index': 'LanguageName', 'width': 200, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
						{ 'name': 'Writing', 'index': 'Writing', 'width': 120, editable: true },
                        { 'name': 'Reading', 'index': 'Reading', 'width': 120, editable: true },
                        { 'name': 'Spoken', 'index': 'Spoken', 'width': 120, editable: true },
                        { 'name': 'MotherLanguage', 'index': 'MotherLanguage', 'width': 120, editable: true, edittype: "checkbox", formatter: 'checkbox' }
                    ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdEmpLanguage_pager')
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
				, caption: 'Language'
				, autowidth: true
				, height: '120'
				, viewsortcols: [false, 'vertical', true]
                , addDialogOptions:
				                {
				                    modal: true,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , editDialogOptions:
				                {
				                    modal: true,
				                    closeAfterEdit: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    bottominfo: "Fields marked with (*) are required"
				                }
			}
		)
		.navGrid
		(
			'#grdEmpLanguage_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdEmpLanguage').getGridParam('editDialogOptions')
   			, jQuery('#grdEmpLanguage').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);