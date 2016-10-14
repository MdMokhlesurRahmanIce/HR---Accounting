jQuery(document).ready
(
	function () {
	    jQuery('#grdEmpHoldOrUnhold').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpHoldOrUnhold&SessionVarName=EmployeeHold_ShowEmpList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpHoldOrUnhold&editMode=1&SessionVarName=EmployeeHold_ShowEmpList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Name', 'Designagion', 'Grade', 'Dept', 'Branch','Hold','Hold Date']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'EmpKey', 'index': 'EmpKey', editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, 'formatter': 'select', edittype: "select", editoptions: { value: GetDropDownSource('SessionVarName=EmployeeHold_EmpList&DataTextField=EmpName&DataValueField=EmpKey')} },
                        { 'name': 'DesigKey', 'index': 'DesigKey', 'width': 100, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=EmployeeHold_DesignationList&DataTextField=DesigName&NeedBlank=Empty&DataValueField=DesigKey')} },
			            { 'name': 'GradeKey', 'index': 'GradeKey', 'width': 100, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=EmployeeHold_GradeList&DataTextField=ElementName&NeedBlank=Empty&DataValueField=ElementKey')} },
                        { 'name': 'DeptKey', 'index': 'DeptKey', 'align': 'center', width: 100, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=EmployeeHold_DeptList&DataTextField=OrgName&NeedBlank=Empty&DataValueField=OrgKey')} },
                        { 'name': 'BranchKey', 'index': 'BranchKey', 'align': 'center', width: 100, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=EmployeeHold_BranchList&DataTextField=OrgName&NeedBlank=Empty&DataValueField=OrgKey')} },
                        { 'name': 'IsOnHold','index': 'IsOnHold', 'width': 22, 'align': 'center', sortable: false, formatter: 'CheckBoxFormatter', editable: true, edittype: 'checkbox', editoptions: { value: "True:False" },formatoptions: { disabled: false }},
                        { 'name': 'OnHoldDate', 'index': 'OnHoldDate', 'width': 70, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ dateFormat: 'dd/mm/yy' }) } } }

//                        { 'name': 'GrossSalary', 'index': 'GrossSalary', 'width': 70, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
//                        { 'name': 'EffectiveFrom', 'index': 'EffectiveFrom', 'width': 120, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ dateFormat: 'dd/mm/yy' }) } } },
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdEmpHoldOrUnhold_pager')
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
                , editDialogOptions:
				        {
				            modal: true,
				            closeAfterEdit: true,
				            closeOnEscape: false,
				            viewPagerButtons: false,
				            //beforeSubmit: BeforeSubmit_AllowanceAndDeductionSetup,
				            bottominfo: "Fields marked with (*) are required"
				        }
				, caption: 'Employee'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdEmpHoldOrUnhold_pager',
			{
			    'edit': true, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
           , jQuery('#grdEmpHoldOrUnhold').getGridParam('editDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);
