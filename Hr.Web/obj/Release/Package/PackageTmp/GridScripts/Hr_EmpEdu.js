jQuery(document).ready
(
	function () {
	    jQuery('#grdEmpEdu').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpEdu&SessionVarName=EmployeeBasicInformation_EducationList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpEdu&editMode=1&SessionVarName=EmployeeBasicInformation_EducationList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Seq', 'Examination', 'Duration(year)', 'Passing Year', 'Result', 'Institute', 'Board/University', 'Achievement/CGPA']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'index': 'VID', 'width': 70 },
						{ 'name': 'Seq', 'index': 'Seq', 'width': 35, editable: true },
						{ 'name': 'ExamKey', 'index': 'ExamKey', 'width': 100, editable: true, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=EmployeeBasicInformation_EducationQualificationList&DataTextField=EduQualSName&NeedBlank=Empty&DataValueField=EduQualKey')} },
						{ 'name': 'Duration', 'index': 'Duration', 'width': 80, editable: true, editrules: { required: true, number: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
						{ 'name': 'PassingYear', 'index': 'PassingYear', 'width': 70, editable: true, editrules: { required: true, number: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
						{ 'name': 'Result', 'index': 'Result', 'width': 60, editable: true },
						{ 'name': 'Institute', 'index': 'Institute', 'width': 100, editable: true },
						{ 'name': 'BoardUniversity', 'index': 'BoardUniversity', editable: true, 'width': 105 },
						//{ 'name': 'CountryKey', 'index': 'CountryKey', editable: true, 'width': 90, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=EmployeeBasicInformation_CountryList&DataTextField=CountryName&NeedBlank=Empty&DataValueField=CountryKey')} },
						{ 'name': 'AchievementComm', 'index': 'AchievementComm', editable: true, 'width': 200 }
					]
				, viewrecords: true
				, rownumbers: true
                , scroll:true
                , shrinkToFit: false
				, scrollrows: true
				, pager: jQuery('#grdEmpEdu_pager')
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
				, caption: 'General Education'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
                , addDialogOptions:
				                {
				                    modal: true,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    beforeShowForm: fn_beforeShowForm,
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
			'#grdEmpEdu_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdEmpEdu').getGridParam('editDialogOptions')
   			, jQuery('#grdEmpEdu').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

function fn_beforeShowForm(formid) {
    var retVal = jQuery.ajax
        (
            {
                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=getRowCount&sessionName=EmployeeBasicInformation_EducationList',
                async: false
            }
        ).responseText;

    $("#Seq").val(retVal);
}
