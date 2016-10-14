  jQuery(document).ready
		(
			function () {
			    jQuery('#cphBody_cphInfbody_grdMenuItem').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=cphBody_cphInfbody_grdMenuItem&SessionVarName=SecurityRule_MenuList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=cphBody_cphInfbody_grdMenuItem&editMode=1&SessionVarName=SecurityRule_MenuList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Name', 'Select', 'Insert', 'Update', 'Delete', 'Menu ID', 'Application ID', 'MenuID']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'DisplayMember', 'index': 'DisplayMember', 'align': 'left', width: 100 },
                                { 'name': 'CanSelect', 'index': 'CanSelect', 'align': 'center', width: 20 },
								{ 'name': 'CanInsert', 'index': 'CanInsert', 'align': 'center', width: 20 },
								{ 'name': 'CanUpdate', 'index': 'CanUpdate', 'align': 'center', width: 20 },
								{ 'name': 'CanDelete', 'index': 'CanDelete', 'align': 'center', width: 20 },
								{ 'name': 'MenuID', 'index': 'MenuID', width: 30, 'hidden': true },
								{ 'name': 'ApplicationID', 'index': 'ApplicationID', width: 30, 'hidden': true },
								{ 'name': 'MenuID', 'index': 'MenuID', width: 30, 'hidden': true }
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdMenuItem_pager')
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
					    //, sortname: 'IsSaved desc'
						, rowNum: 10
						, rowList: [10, 20, 30]
						, caption: 'Menu'
						, autowidth: true
						, height: '100%'
						, gridComplete: addCheckBox_grdCanInsert
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdMenuItem_pager',
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

function addCheckBox_grdCanInsert() {
    var SessionVarName = 'SecurityRule_MenuList';
    var ColumnName = 'CanInsert';
    var ids = jQuery("#cphBody_cphInfbody_grdMenuItem").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#cphBody_cphInfbody_grdMenuItem").jqGrid('getRowData', cid);
        var chk;
        if (data.CanInsert == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdateOnMenuItem('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdateOnMenuItem('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#cphBody_cphInfbody_grdMenuItem").jqGrid('setRowData', ids[i], { CanInsert: chk });
        AllcheckOrUncheck(ColumnName);
    }
    var SessionVarName = 'SecurityRule_MenuList';
    var ColumnName = 'CanSelect';
    var ids = jQuery("#cphBody_cphInfbody_grdMenuItem").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#cphBody_cphInfbody_grdMenuItem").jqGrid('getRowData', cid);
        var chk;
        if (data.CanSelect == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdateOnMenuItem('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdateOnMenuItem('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#cphBody_cphInfbody_grdMenuItem").jqGrid('setRowData', ids[i], { CanSelect: chk });
        AllcheckOrUncheck(ColumnName);
    }
    var SessionVarName = 'SecurityRule_MenuList';
    var ColumnName = 'CanUpdate';
    var ids = jQuery("#cphBody_cphInfbody_grdMenuItem").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#cphBody_cphInfbody_grdMenuItem").jqGrid('getRowData', cid);
        var chk;
        if (data.CanUpdate == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdateOnMenuItem('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdateOnMenuItem('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#cphBody_cphInfbody_grdMenuItem").jqGrid('setRowData', ids[i], { CanUpdate: chk });
        AllcheckOrUncheck(ColumnName);
    }
    var SessionVarName = 'SecurityRule_MenuList';
    var ColumnName = 'CanDelete';
    var ids = jQuery("#cphBody_cphInfbody_grdMenuItem").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#cphBody_cphInfbody_grdMenuItem").jqGrid('getRowData', cid);
        var chk;
        if (data.CanDelete == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdateOnMenuItem('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdateOnMenuItem('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#cphBody_cphInfbody_grdMenuItem").jqGrid('setRowData', ids[i], { CanDelete: chk });
        AllcheckOrUncheck(ColumnName);
    }
};


function afterCellCheckUpdateOnMenuItem(vid, curCheckbox, SessionVarName, ColumnName) {
    var QString = 'SessionVarName=' + SessionVarName + '&editbyforce=true&jqGridID="true"&' + ColumnName + '=' + curCheckbox.checked + '&id=' + vid
    jQuery.ajax
                (
                   {
                       url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?' + QString,
                       async: false
                   }
                 );
    var retVal = jQuery.ajax
        (
            {
                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=MenuAllCheckOrUncheck &ColumnName=' + ColumnName,
                async: false
            }
            ).responseText
    if (ColumnName == "CanInsert") {
        if (retVal == "True") {
            $("#cphBody_cphInfbody_chkInsert").attr('checked', false);
        }
        else {
            $("#cphBody_cphInfbody_chkInsert").attr('checked', true);
        }
    }
    if (ColumnName == "CanSelect") {
        if (retVal == "True") {
            $("#cphBody_cphInfbody_chkSelect").attr('checked', false);
        }
        else {
            $("#cphBody_cphInfbody_chkSelect").attr('checked', true);
        }
    }
    if (ColumnName == "CanUpdate") {
        if (retVal == "True") {
            $("#cphBody_cphInfbody_chkUpdate").attr('checked', false);
        }
        else {
            $("#cphBody_cphInfbody_chkUpdate").attr('checked', true);
        }
    }
    if (ColumnName == "CanDelete") {
        if (retVal == "True") {
            $("#cphBody_cphInfbody_chkDelete").attr('checked', false);
        }
        else {
            $("#cphBody_cphInfbody_chkDelete").attr('checked', true);
        }
    }
};

function AllcheckOrUncheck(ColumnName) {
    var retVal = jQuery.ajax
        (
            {
                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=MenuAllCheckOrUncheck &ColumnName=' + ColumnName,
                async: false
            }
            ).responseText
    if (ColumnName == "CanInsert") {
        if (retVal == "True") {
            $("#cphBody_cphInfbody_chkInsert").attr('checked', false);
        }
        else {
            $("#cphBody_cphInfbody_chkInsert").attr('checked', true);
        }
    }
    if (ColumnName == "CanSelect") {
        if (retVal == "True") {
            $("#cphBody_cphInfbody_chkSelect").attr('checked', false);
        }
        else {
            $("#cphBody_cphInfbody_chkSelect").attr('checked', true);
        }
    }
    if (ColumnName == "CanUpdate") {
        if (retVal == "True") {
            $("#cphBody_cphInfbody_chkUpdate").attr('checked', false);
        }
        else {
            $("#cphBody_cphInfbody_chkUpdate").attr('checked', true);
        }
    }
    if (ColumnName == "CanDelete") {
        if (retVal == "True") {
            $("#cphBody_cphInfbody_chkDelete").attr('checked', false);
        }
        else {
            $("#cphBody_cphInfbody_chkDelete").attr('checked', true);
        }
    }
}
