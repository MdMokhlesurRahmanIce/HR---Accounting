jQuery(document).ready
		(
			function () {
			    jQuery('#grdGetEmployeeEmergencyInfo').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdGetEmployeeEmergencyInfo&SessionVarName=EmployeeBasicInfo_EmployeeEmergencyInfoList'
						, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdGetEmployeeEmergencyInfo&editMode=1&SessionVarName=EmployeeBasicInfo_EmployeeEmergencyInfoList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'ContactPerson', 'Address', 'CellNo', 'LandPhone', 'Relation']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'ContactPerson', 'index': 'ContactPerson', 'width': 150, 'editable': true },
								{ 'name': 'Address', 'index': 'Address','width': 200 , 'editable': true },
								{ 'name': 'CellNo', 'index': 'CellNo','width': 120, 'editable': true },
								{ 'name': 'LandPhone', 'index': 'LandPhone', 'width': 120, 'editable': true },
								{ 'name': 'Relation', 'index': 'Relation', 'editable': true },
							]
						, viewrecords: true
						, rownumbers: true
						, scrollrows: true
						, pager: jQuery('#grdEmployeeEmergencyInfo_pager')
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
						, caption: 'Emergency Info', font: 16
						, autowidth: true
						, height: '100%'
						, onSelectRow: editRow_EmergencyInfo
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdEmployeeEmergencyInfo_pager',
					{
					    'edit': false, 'add': false, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
				)
				.navButtonAdd('#grdEmployeeEmergencyInfo_pager',
		        {
		            caption: "",
		            buttonicon: "ui-icon ui-icon-plus",
		            onClickButton: function () {
		                var retVal = jQuery.ajax
	                    (
	                        {
	                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AddNewEmergencyInfo',
	                            async: false
	                        }
                        ).responseText;

		                $("#grdGetEmployeeEmergencyInfo").trigger("reloadGrid");
		            },
		            position: "first"
		        });
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);

var lastID_editRow_EmergencyInfo;
function editRow_EmergencyInfo(rowid) {
    var grid = jQuery("#grdGetEmployeeEmergencyInfo");
    var ids = grid.jqGrid('getDataIDs');
    if ((ids.length == 1) || (rowid && rowid !== lastID_editRow_EmergencyInfo)) {
        grid.restoreRow(lastID_editRow_EmergencyInfo);
        jQuery("#grdGetEmployeeEmergencyInfo").jqGrid('editRow', rowid, true);
        lastID_editRow_EmergencyInfo = rowid;
    }
};
