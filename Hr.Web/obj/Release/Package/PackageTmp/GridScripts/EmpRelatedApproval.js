jQuery(document).ready
(
	function () {
	    jQuery('#grdEmpRelatedApproval').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpRelatedApproval&SessionVarName=EmployeeInfoComonApproval_EmpList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpRelatedApproval&editMode=1&SessionVarName=EmployeeInfoComonApproval_EmpList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', '...', 'Code', 'Name', 'RejoiningDate', 'Designation', 'StaffCategory', 'Department', 'DOJ', 'DOS', 'SeparationAction', 'SeparationCause', 'OfficialRemarks', 'Added By']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'IsChecked', 'index': 'IsChecked', 'align': 'center', 'width': 20 },
                        { 'name': 'EmpCode', 'index': 'EmpCode', 'width': 100 },
                        { 'name': 'EmpName', 'index': 'EmpName', 'width': 150 },
                        { 'name': 'RejoiningDate', 'index': 'RejoiningDate', 'width': 100, editable: true, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1930:2012' }) } } },
                        { 'name': 'Designation', 'index': 'Designation', 'width': 150 },
                        { 'name': 'StaffCategory', 'index': 'StaffCategory', 'width': 100 },
                        { 'name': 'Department', 'index': 'Department', 'width': 100 },
                        { 'name': 'DOJ', 'index': 'DOJ', 'width': 100 },
                        { 'name': 'DOS', 'index': 'DOS', 'width': 100 },
                        { 'name': 'SeparationAction', 'index': 'SeparationAction', 'width': 150 },
                        { 'name': 'SeparationCause', 'index': 'SeparationCause', 'width': 150 },
                        { 'name': 'OfficialRemarks', 'index': 'OfficialRemarks', 'width': 150 },
                        { 'name': 'AddedBy', 'index': 'AddedBy', 'width': 100 }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
                , shrinkToFit: false
				, pager: jQuery('#grdEmpRelatedApproval_pager')
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
				, caption: 'Employee List'
                , editDialogOptions:
				    {
				        modal: true,
				        closeAfterEdit: true,
				        closeOnEscape: false,
				        viewPagerButtons: false,
				        recreateForm: true,
				        bottominfo: "Fields marked with (*) are required"
				    }
				, autowidth: true
				, height: '240'
			    , gridComplete: addCheckBox_grdAllApproval
				, viewsortcols: [false, 'vertical', true]

			}
		)
		.navGrid
		(
			'#grdEmpRelatedApproval_pager',
			{
			    'edit': true, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdEmpRelatedApproval').getGridParam('editDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

function addCheckBox_grdAllApproval() {

    var SessionVarName = 'EmployeeInfoComonApproval_EmpList';
    var ColumnName = 'IsChecked';
    var isSelectAll = 1;

    var ids = jQuery("#grdEmpRelatedApproval").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdEmpRelatedApproval").jqGrid('getRowData', cid);
        var chk;
        if (data.IsChecked == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
            isSelectAll = 0;
        }
        jQuery("#grdEmpRelatedApproval").jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};

