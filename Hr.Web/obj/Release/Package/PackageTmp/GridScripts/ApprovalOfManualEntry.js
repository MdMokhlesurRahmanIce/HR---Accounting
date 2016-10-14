var subgrid_table_id, pager_id, vid,id="";
jQuery(document).ready
(
	function () {
	    jQuery('#grdApprovalOfManualEntry').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdApprovalOfManualEntry&SessionVarName=ApprovalOfManualEntry_UserList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdApprovalOfManualEntry&editMode=1&SessionVarName=ApprovalOfManualEntry_UserList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', '...', 'EmpKey', 'EmpName']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'IsChecked', 'index': 'IsChecked', 'width': 7, 'align': 'center' },
                        { 'name': 'UserCode', 'index': 'UserCode', 'hidden': true, 'width': 50 },
                        { 'name': 'EmpName', 'index': 'EmpName', 'width': 150 }
                     ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdApprovalOfManualEntry_pager')
				, loadError: jqGrid_aspnet_loadErrorHandler
			    , subGrid: true
			    , subGridRowExpanded: ApprovalOfManualEntry
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
                    if (id != "") {
                        id = "";
                        return;
                    }
                    var sessionVarName = "ApprovalOfManualEntry_UserList";
                    var sessionVarNameSubGrid = "ApprovalOfManualEntry_AttManualList";
                    var row = $("#grdApprovalOfManualEntry").getRowData(rowid);
                    var userCode = row.UserCode;
                    var retVal = jQuery.ajax
                                        (
                                            {
                                                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllCheckOrUncheckUserWiseEmp&SessionVarName=' + sessionVarName + '&SessionVarNameSubGrid=' + sessionVarNameSubGrid + '&UserCode=' + userCode,
                                                async: false
                                            }
                                        ).responseText
                    if (retVal == "True") {
                        $("#cphBody_cphInfbody_chkApprovalOfManualEntry").attr('checked', false);
                    }
                    else {
                        $("#cphBody_cphInfbody_chkApprovalOfManualEntry").attr('checked', true);
                    }
                    $("#grdApprovalOfManualEntry").trigger("reloadGrid");
                }
				, sortable: true
				, rowNum: 10
				, rowList: [10, 20, 30]
			   	, caption: 'Approval Of Manual Entry'
				, autowidth: true
				, height: '240'
                , gridComplete: addCheckBox_grdApprovalOfManualEntry
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdApprovalOfManualEntry_pager',
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



function ApprovalOfManualEntry(subgrid_id, row_id) {

    try {
        subgrid_table_id = subgrid_id + "_t";
        pager_id = "p_" + subgrid_table_id;

        var parentGridID = subgrid_id.toString().substring(0, subgrid_id.toString().lastIndexOf("_"));
        $("#" + parentGridID).restoreRow(row_id);
        var row = $("#" + parentGridID).getRowData(row_id);

        var UserCode = row.UserCode;
        $("#" + subgrid_id).html("<table id='" + subgrid_table_id + "' class='scroll'></table><div id='" + pager_id + "' class='scroll'></div>");

        jQuery("#" + subgrid_table_id).jqGrid
                (
                    {
                        url: rootPath + 'GridHelperClasses/SubGridGenericHandler.ashx?SessionVarName=ApprovalOfManualEntry_AttManualList&AddedBy=' + UserCode
                        , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=' + subgrid_table_id + '&editMode=1&SessionVarName=ApprovalOfManualEntry_AttManualList'
                        , datatype: "json"
                        , colNames: ['VID', '...', 'AddedBy', 'EmpKey','EmpCode', 'EmpName', 'WorkDate', 'CInTime', 'COutTime', 'CDayStatus', 'COT', 'InTime', 'OutTime', 'DayStatus', 'OT']
                        , colModel:
                        	[
                        	    { 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                                { 'name': 'IsChecked', 'index': 'IsChecked', 'width': 20, 'align': 'center' },
                                { 'name': 'AddedBy', 'index': 'AddedBy', 'width': 50, editable: true, 'hidden': true },
                                { 'name': 'EmpKey', 'index': 'EmpKey', 'hidden': true, 'width': 50 },
                                { 'name': 'EmpCode', 'index': 'EmpCode', 'width': 70 },
                                { 'name': 'EmpName', 'index': 'EmpName', 'width': 120 },
                                { 'name': 'Workdate', 'index': 'Workdate', 'width': 75 },
                                { 'name': 'CInTime', 'index': 'CInTime', 'width': 135 },
                                { 'name': 'COutTime', 'index': 'COutTime', 'width': 135 },
                                { 'name': 'CDayStatus', 'index': 'CDayStatus', 'width': 70 },
                                { 'name': 'COT', 'index': 'COT', 'width': 50 },
                                { 'name': 'InTime', 'index': 'InTime', 'width': 100 },
                                { 'name': 'OutTime', 'index': 'OutTime', 'width': 100 },
                                { 'name': 'DayStatus', 'index': 'DayStatus', 'width': 70 },
                                { 'name': 'OT', 'index': 'OT', 'width': 50 },
                             ]
                        , page: 1
                        , jsonReader:
			            {
			                root: 'rows',
			                page: 'currentpage',
			                total: 'totalpages',
			                records: 'pagerecords',
			                repeatitems: false
			            }
                        , beforeSelectRow: function (rowid, e) {
                            id = rowid
//                            var data = jQuery("#grdApprovalOfManualEntry").jqGrid('getRowData', rowid);
//                            alert(data.AddedBy);
//                            $("#grdApprovalOfManualEntry").trigger("reloadGrid");
                        }
                        , autowidth: true
                        , shrinkToFit: false
                        , rowNum: 20
                        , pager: pager_id
                        , sortorder: "asc"
                        , height: '100%'
                        , gridComplete: addCheckBox_subGrdApprovalOfManualEntry
                    }
                )

                .navGrid
	            (
		            "#" + pager_id,
		            {
		                'edit': false, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
		            }
                )
    }
    catch (e) {
        alert(e);
    }

}

function addCheckBox_subGrdApprovalOfManualEntry() {

    var SessionVarName = 'ApprovalOfManualEntry_AttManualList';
    var ColumnName = 'IsChecked';
    var isSelectAll = 1;

    var ids = jQuery("#" + subgrid_table_id).jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#" + subgrid_table_id).jqGrid('getRowData', cid);
        var chk;
        if (data.IsChecked == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
            isSelectAll = 0;
        }
        jQuery("#" + subgrid_table_id).jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};
function addCheckBox_grdApprovalOfManualEntry() {

    var SessionVarName = 'ApprovalOfManualEntry_UserList';
    var ColumnName = 'IsChecked';
    var isSelectAll = 1;

    var ids = jQuery("#grdApprovalOfManualEntry").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdApprovalOfManualEntry").jqGrid('getRowData', cid);
        var chk;
        if (data.IsChecked == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
            isSelectAll = 0;
        }
        jQuery("#grdApprovalOfManualEntry").jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};


