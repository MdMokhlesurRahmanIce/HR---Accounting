jQuery(document).ready
(
	function () {
	    jQuery('#grdEmpEduDip').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpEduDip&SessionVarName=EmployeeBasicInformation_DipEducationList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpEduDip&editMode=1&SessionVarName=EmployeeBasicInformation_DipEducationList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Seq', 'Name', 'Duration', 'From', 'To', 'Result', 'Institute', 'Achievement/Comm']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'index': 'VID', 'width': 70 },
						{ 'name': 'Seq', 'index': 'Seq', 'width': 35, editable: true },
						{ 'name': 'DipName', 'index': 'DipName', editable: true, 'width': 140 },
						{ 'name': 'Duration', 'index': 'Duration', editable: true, 'hidden': true, 'width': 70 },
                        { 'name': 'From', 'index': 'From', 'width': 70, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1930:2012' }) } } },
						{ 'name': 'To', 'index': 'To', 'width': 70, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1930:2012' }) } } },
                        { 'name': 'Result', 'index': 'Result', editable: true, 'width': 70 },
						{ 'name': 'Institute', 'index': 'Institute', editable: true, 'width': 150 },
						//{ 'name': 'CountryKey', 'index': 'CountryKey', editable: true, 'width': 90, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=EmployeeBasicInformation_CountryList&DataTextField=CountryName&NeedBlank=Empty&DataValueField=CountryKey')} },
						{ 'name': 'AchievementComm', 'index': 'AchievementComm', editable: true, 'width': 215 },
					]
				, viewrecords: true
				, rownumbers: true
                , scroll: true
                , shrinkToFit: false
				, scrollrows: true
				, pager: jQuery('#grdEmpEduDip_pager')
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
				, caption: 'Diploma / Training'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
                , addDialogOptions:
				                {
				                   // modal: true,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    recreateForm: true,
				                    beforeShowForm: fn_beforeShowForm_Dip,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , editDialogOptions:
				                {
				                   // modal: true,
				                    closeAfterEdit: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    recreateForm: true,
				                    bottominfo: "Fields marked with (*) are required"
				                }
			}
		)
		.navGrid
		(
			'#grdEmpEduDip_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdEmpEduDip').getGridParam('editDialogOptions')
   			, jQuery('#grdEmpEduDip').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

function fn_beforeShowForm_Dip(formid) {
    var retVal = jQuery.ajax
        (
            {
                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=getRowCount&sessionName=EmployeeBasicInformation_DipEducationList',
                async: false
            }
        ).responseText;
    $("#Seq").val(retVal);
}

