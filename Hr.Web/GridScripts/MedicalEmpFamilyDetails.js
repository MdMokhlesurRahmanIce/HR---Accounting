jQuery(document).ready
(
	function () {
	    jQuery('#grdMedicalEmpFamDet').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdMedicalEmpFamDet&SessionVarName=MadicalReinversement_EmpFamDetList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdMedicalEmpFamDet&editMode=1&SessionVarName=MadicalReinversement_EmpFamDetList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Name', 'Relation', 'Date of Birth', 'Occupation', 'Age', 'Remark']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'index': 'VID' },
						{ 'name': 'ChildName', 'index': 'ChildName', editable: true, 'width': 100 },
						{ 'name': 'Relation', 'index': 'Relation', editable: true, 'width': 75, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
						{ 'name': 'DOB', 'index': 'DOB', editable: true, 'width': 70, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1930:2090' }) } } },
						{ 'name': 'Occupation', 'index': 'Occupation', editable: true, 'width': 70, editable: true },
                        { 'name': 'Age', 'index': 'Age', editable: true, 'width': 100, editable: false },
						{ 'name': 'Remark', 'index': 'Remark', editable: true, edittype: "textarea", 'width': 100, editoptions: { rows: "2", cols: "15"} },
					]
				, viewrecords: true
				, rownumbers: true
                , scroll: true
                , shrinkToFit: true
				, scrollrows: true
				, pager: jQuery('#grdMedicalEmpFamDet_pager')
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
				, caption: 'Family Details'
				, width: '560'
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdMedicalEmpFamDet_pager',
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
