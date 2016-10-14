var rowsToColor = [];
jQuery(document).ready
(
	function () {
	    jQuery('#grdSeparation').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSeparation&SessionVarName=EmployeeSeperation_SeparationGrid'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSeparation&editMode=1&SessionVarName=EmployeeSeperation_SeparationGrid'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Code', 'Name', 'Designation', 'Department','SeparationID','EmployeeKey', 'SeparationCause','Action', 'EffectiveDate', 'AdditionalRemarks','Notes']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'EmployeeCode', 'index': 'EmployeeCode', 'width': 100 },
                        { 'name': 'EmployeeName', 'index': 'EmployeeName', 'width': 100 },
                        { 'name': 'Designation', 'index': 'Designation', 'width': 100 },
                        { 'name': 'Department', 'index': 'Department', 'width': 100 },
                        { 'name': 'SeparationID', 'index': 'SeparationID','hidden': true,  'width': 100 },
                        { 'name': 'EmployeeKey', 'index': 'EmployeeKey','hidden': true,  'width': 50 },
                        { 'name': 'SeparationCause', 'index': 'SeparationCause', 'width': 150, 'editable': true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, 'formatter': 'select', edittype: "select", editoptions: { value: GetDropDownSource('SessionVarName=EmployeeSeperation_Cause&DataTextField=ElementName&DataValueField=ElementKey')} },
                        { 'name': 'Action', 'index': 'Action', 'width': 150, 'editable': true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, 'formatter': 'select', edittype: "select", editoptions: { value: GetDropDownSource('SessionVarName=EmployeeSeperation_Action&DataTextField=ElementName&DataValueField=ElementKey')} },
                        { 'name': 'EffectiveDate', 'index': 'EffectiveDate', 'width': 100, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1930:2012' }) } } },
                        { 'name': 'AdditionalRemarks', 'index': 'AdditionalRemarks', 'width': 150 ,'editable':true },                        
                        { 'name': 'Notes', 'index': 'Notes', 'Note': 150 ,'editable':true }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdSeparation_pager')
				, loadError: jqGrid_aspnet_loadErrorHandler
				, hoverrows: true
//                , loadComplete: function () {
//                    var ids = jQuery("#grdSeparation").jqGrid('getDataIDs');
//                    var rowId;
//                    for (var i = 0; i < ids.length; i++) {
//                        var data = jQuery("#grdSeparation").jqGrid('getRowData', ids[i]);
//                        if (data.IsSaved == "True") {
//                            disableRow(i);
//                        }
//                    }
//                }
				, jsonReader:
				{
				    root: 'rows',
				    page: 'currentpage',
				    total: 'totalpages',
				    records: 'pagerecords',
				    repeatitems: false
				}
				, sortable: true
				, rowNum: 15
				, rowList: [15, 30, 45]
				, caption: 'Separation List'
				, autowidth: true
				, height: '100%'
				,onSelectRow: editRow_Settings
				, viewsortcols: [false, 'vertical', true]
//				 , editDialogOptions:
//				                {
//				                    modal: true,
//				                    closeAfterEdit: true,
//				                    closeOnEscape: false,
//				                    viewPagerButtons: false,
//				                    bottominfo: "(*) are Mandatory"
//				                }

			}
		)
		.navGrid
		(
			'#grdSeparation_pager',
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
var lastID_editRow_Settings;
        function editRow_Settings(rowid) 
        {							
            var grid = jQuery("#grdSeparation");  
            var ids = grid.jqGrid('getDataIDs');    
            if ((ids.length == 1) || (rowid && rowid !== lastID_editRow_Settings)) 
            {
                grid.restoreRow(lastID_editRow_Settings);
                jQuery("#grdSeparation").jqGrid('editRow', rowid, true);
                lastID_editRow_Settings = rowid;
            }
        };	

function disableRow(rowId) {
    $("#grdSeparation").jqGrid('setRowData', rowId, false, { color: 'red' });
}

