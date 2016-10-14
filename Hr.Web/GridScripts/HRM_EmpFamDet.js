jQuery(document).ready
(
	function () {
	    jQuery('#grdEmpFamDet').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpFamDet&SessionVarName=EmployeeBasicInformation_EmpFamDetList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpFamDet&editMode=1&SessionVarName=EmployeeBasicInformation_EmpFamDetList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Name', 'Relation', 'Date of Birth', 'Blood Group', 'Occupation', 'Age', 'Is Insurance', 'Remark']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'index': 'VID' },
						{ 'name': 'ChildName', 'index': 'ChildName', editable: true, 'width': 100 },
						{ 'name': 'Relation', 'index': 'Relation', editable: true, 'width': 75, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
						{ 'name': 'DOB', 'index': 'DOB', editable: true, 'width': 70, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1930:2050' }) } } },
                        { 'name': 'BloodGroup', 'index': 'BloodGroup', editable: true, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=EmployeeBasicInfo_BloodGroupList&DataTextField=ElementName&NeedBlank=Empty&DataValueField=ElementName')} },
						{'name': 'Occupation', 'index': 'Occupation', editable: true, 'width': 70, editable: true },
                        { 'name': 'Age', 'index': 'Age', editable: true, 'width': 100, editable: false },
                        {'name': 'IsInsurance', 'index': 'IsInsurance', 'align': 'center', width: 100, editable: true, edittype: "checkbox", formatter: 'checkbox' },
						{ 'name': 'Remark', 'index': 'Remark', editable: true, edittype: "textarea", 'width': 100, editoptions: { rows: "2", cols: "15"} },
					]
				, viewrecords: true
				, rownumbers: true
                , scroll: true
                , shrinkToFit: false
				, scrollrows: true
				, pager: jQuery('#grdEmpFamDet_pager')
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
				, autowidth: true
				, height: '100%'
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
				                    //modal: true,
				                    closeAfterEdit: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    bottominfo: "Fields marked with (*) are required"
				                }
                 , gridComplete: addCheckBox_grdFamilyDetails
			}
		)
		.navGrid
		(
			'#grdEmpFamDet_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdEmpFamDet').getGridParam('editDialogOptions')
   			, jQuery('#grdEmpFamDet').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);


function addCheckBox_grdFamilyDetails() {

    var SessionVarName = 'EmployeeBasicInformation_EmpFamDetList';
    var ColumnName = 'IsInsurance';
    var isSelectAll = 1;

    var ids = jQuery("#grdEmpFamDet").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdEmpFamDet").jqGrid('getRowData', cid);
        var chk;
        if (data.IsChecked == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
            isSelectAll = 0;
        }
        jQuery("#grdEmpFamDet").jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};

	