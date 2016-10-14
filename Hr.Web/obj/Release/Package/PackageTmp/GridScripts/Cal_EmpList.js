jQuery(document).ready
(
	function () {
	    jQuery('#grdCalendar').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdCalendar&SessionVarName=View_EmpList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdCalendar&editMode=1&SessionVarName=View_EmpList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', '...', 'Code', 'Name', 'Designation', 'Shift', 'StaffCategory', 'Department']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'IsChecked', 'index': 'IsChecked', 'align': 'center', 'width': 20 },
                        { 'name': 'EmpCode', 'index': 'EmpCode', 'width': 100 },
                        { 'name': 'EmpName', 'index': 'EmpName', 'width': 150 },
                        { 'name': 'Designation', 'index': 'Designation', 'width': 150 },
                        { 'name': 'Shift', 'index': 'Shift', 'width': 150 },
                        { 'name': 'StaffCategory', 'index': 'StaffCategory', 'width': 150 },
                        { 'name': 'Department', 'index': 'Department', 'width': 150 }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
                , shrinkToFit: false
				, pager: jQuery('#grdCalendar_pager')
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
                , beforeSelectRow: function (rowid, e) {
                    var sessionVarName = "View_EmpList";
                    var retVal = jQuery.ajax
                    (
                        {
                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllCheckOrUncheck&SessionVarName=' + sessionVarName,
                            async: false
                        }
                    ).responseText
                    if (retVal == "True") {
                        $("#cphBody_cphInfbody_ctrlEmpList_chkEmp").attr('checked', false);
                    }
                    else {
                        $("#cphBody_cphInfbody_ctrlEmpList_chkEmp").attr('checked', true);
                    }
                }
				, sortable: true
				, rowNum: 10
				, rowList: [10, 20, 30]
				, caption: 'Employee List'
				, autowidth: true
				, height: '240'
			    , gridComplete: addCheckBox_grdCalendar
				, viewsortcols: [false, 'vertical', true]

			}
		)
		.navGrid
		(
			'#grdCalendar_pager',
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

function addCheckBox_grdCalendar() {

    var SessionVarName = 'View_EmpList';
    var ColumnName = 'IsChecked';
    var isSelectAll = 1;

    var ids = jQuery("#grdCalendar").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdCalendar").jqGrid('getRowData', cid);
        var chk;
        if (data.IsChecked == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
            isSelectAll = 0;
        }
        jQuery("#grdCalendar").jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};

