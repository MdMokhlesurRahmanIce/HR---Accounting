jQuery(document).ready
(
	function () {
	    jQuery('#grdMedicalAllowanceTrans').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdMedicalAllowanceTrans&SessionVarName=MadicalReinversement_MedicalAllowanceTransList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdMedicalAllowanceTrans&editMode=1&SessionVarName=MadicalReinversement_MedicalAllowanceTransList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Type', 'Transaction<br/>Date', 'Amount', 'Description', 'Remarks']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'index': 'VID' },
						{ 'name': 'Type', 'index': 'Type', editable: true, editrules: { required: true }, 'width': 100, edittype: 'select', formatter: 'select', editoptions: { value: "1:Self;2:Family;3:Maternity" }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
						{ 'name': 'TransDate', 'index': 'TransDate', editable: true, 'width': 75, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1930:2090' }) } } },
						{ 'name': 'Amount', 'index': 'Amount', editable: true, 'width': 70, editrules: { required: true,number:true }, 'align': 'right', formatter: 'currency', formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
						{ 'name': 'Description', 'index': 'Description', editable: true, 'width': 70, editable: true },
                        { 'name': 'Remarks', 'index': 'Remarks', editable: true, 'width': 100, editable: true },
					]
				, viewrecords: true
				, rownumbers: true
                , scroll: true
                , shrinkToFit: true
				, scrollrows: true
				, pager: jQuery('#grdMedicalAllowanceTrans_pager')
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
				, caption: 'Medical Allowances'
				, width: '560'
				, height: '100%'
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
			'#grdMedicalAllowanceTrans_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdMedicalAllowanceTrans').getGridParam('editDialogOptions')
   			, jQuery('#grdMedicalAllowanceTrans').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);
