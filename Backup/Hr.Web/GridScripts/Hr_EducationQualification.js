
jQuery(document).ready
(
	function () {
	    jQuery('#grdEducationQualification').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEducationQualification&SessionVarName=EducationQualification_Hr'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEducationQualification&editMode=1&SessionVarName=EducationQualification_Hr'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Education Name', 'Education Short Name', 'Education Level', 'Remarks']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'EduQualName', 'index': 'EduQualName', editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
						{ 'name': 'EduQualSName', 'index': 'EduQualSName', editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
						{ 'name': 'EduLevel', 'index': 'EduLevel', 'align': 'center', 'width': 50, editable: true, editrules: { number: true, required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
						{ 'name': 'Remarks', 'index': 'Remarks', editable: true, edittype: "textarea", editoptions: { rows: "4", cols: "40", maxlength: "250"} }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdEducationQualification_pager')
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
				, caption: 'Company'
				, autowidth: true
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
				                    //beforeShowForm: fnBeforeShowForm,
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , ondblClickRow: function (rowid) {
                       $(".ui-icon-pencil").click();
                   }

			}
		)
		.navGrid
		(
			'#grdEducationQualification_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdEducationQualification').getGridParam('editDialogOptions')
   			, jQuery('#grdEducationQualification').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);


