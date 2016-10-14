jQuery(document).ready
		(
			function () {
			    jQuery('#PromotionApproval').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=PromotionApproval&SessionVarName=Bank_BankMasterList'
						, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=PromotionApproval&editMode=1&SessionVarName=Bank_BankMasterList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Code', 'Name', 'Designation', 'Effective Date', 'Criteria', 'PreHKName', 'PostHkName', 'ApprovalType', 'Addedby', 'UpdatedBy', 'Remarks']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 25, 'index': 'VID' },
								{ 'name': 'EmpCode', 'index': 'EmpCode', 'width': 100, 'editable': false },
                                { 'name': 'EmpName', 'index': 'EmpName', 'width': 150, 'editable': false },
								{ 'name': 'Designation', 'index': 'Designation', 'width': 120, 'editable': true },
                                { 'name': 'LeaveType', 'index': 'LeaveType', 'width': 100, 'editable': true },
								{ 'name': 'LeaveType', 'index': 'LeaveType', 'width': 80, 'editable': true },
								{ 'name': 'ApprovedDays', 'index': 'ApprovedDays', 'width': 70, 'editable': false },
                                { 'name': 'LeaveReason', 'index': 'LeaveReason', 'width': 150, 'editable': true },
                                { 'name': 'IsForwarded', 'index': 'IsForwarded', 'width': 60, 'editable': true, 'align': 'center' },
                                { 'name': 'IsRecomended', 'index': 'IsRecomended', 'width': 60, 'editable': true, 'align': 'center' },
                                { 'name': 'IsApproved', 'index': 'IsApproved', 'width': 70, 'editable': true, 'align': 'center' },
                                { 'name': 'IsRejected', 'index': 'IsRejected', 'width': 70, 'editable': true, 'align': 'center' }
							]
						, viewrecords: true
						, rownumbers: true
						, scrollrows: true
						, pager: jQuery('#PromotionApproval_pager')
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
						, rowNum: 5
						, rowList: [10, 20, 30]
						, caption: 'Salary Process Approval'
						, width: '100%'
				        , height: '150'
					    //, onSelectRow
					    /* , beforeSelectRow: function (id) { 
					    alert("shamim");
					    var sessionVarName = "Bank_BankMasterList";
					    var retVal = jQuery.ajax
					    (
					    {
					    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllCheckOrUncheck&SessionVarName=' + sessionVarName,
					    async: false
					    }
					    ).responseText
					    if (retVal == "True") {
					    $("#cphBody_cphInfbody_chkForwarded").attr('checked', false);
					    }
					    else {
					    $("#cphBody_cphInfbody_chkForwarded").attr('checked', true);
					    }
					    }*/
                        , gridComplete: addCheckBox_Forwarded
						, viewsortcols: [true, 'vertical', true]
					}
				)
				.navGrid
				(
					'#PromotionApproval_pager',
					{
					    'edit': false, 'add': false, 'del': false, 'search': false, 'refresh': false, 'view': false, 'position': 'left', 'cloneToTop': true
					}
				)
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);


function addCheckBox_Forwarded() {
    //  alert('shaikat');
    var SessionVarName = 'Bank_BankMasterList';
    var ColumnName = 'IsForwarded';
    var ids = jQuery("#PromotionApproval").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#PromotionApproval").jqGrid('getRowData', cid);
        var chk;
        if (data.IsForwarded == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#PromotionApproval").jqGrid('setRowData', ids[i], { IsForwarded: chk });
        // AllcheckOrUncheck(ColumnName);
    }

    var ColumnName = 'IsRecomended';
    var ids = jQuery("#PromotionApproval").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#PromotionApproval").jqGrid('getRowData', cid);
        var chk;
        if (data.IsRecomended == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdateOnMenuItem('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#PromotionApproval").jqGrid('setRowData', ids[i], { IsRecomended: chk });
        // AllcheckOrUncheck(ColumnName);
    }

    var ColumnName = 'IsApproved';
    var ids = jQuery("#PromotionApproval").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#PromotionApproval").jqGrid('getRowData', cid);
        var chk;
        if (data.IsApproved == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#PromotionApproval").jqGrid('setRowData', ids[i], { IsApproved: chk });
        // AllcheckOrUncheck(ColumnName);
    }

    var ColumnName = 'IsRejected';
    var ids = jQuery("#PromotionApproval").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#PromotionApproval").jqGrid('getRowData', cid);
        var chk;
        if (data.IsRejected == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#PromotionApproval").jqGrid('setRowData', ids[i], { IsRejected: chk });
        // AllcheckOrUncheck(ColumnName);
    }
}