jQuery(document).ready
(
	function () {
	    jQuery('#grdSearchParameters').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSearchParameters&SessionVarName=ucEmpSearch_FilterSetsList'
			    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSearchParameters&editMode=1&SessionVarName=ucEmpSearch_FilterSetsList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'entityID', 'Name', '', 'Column Value', 'Value', '']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'index': 'VID' },
                        { 'name': 'EntityID', 'index': 'EntityID', 'hidden': true, "width": 100, sortable: false },
						{ 'name': 'ColumnName', 'index': 'ColumnName', "width": 80, sortable: false },
						{ 'name': 'Operators', 'index': 'Operators', "width": 10, "align": "center" },
                        { 'name': 'ColumnValue', 'index': 'ColumnValue', "editable": true, 'hidden': true, "width": 210, sortable: false },
                        { 'name': 'DisplaySeletedColumnValue', 'index': 'DisplaySeletedColumnValue', "editable": true, "width": 170, sortable: false },
                        { 'name': 'Button', index: 'Button', width: 30, sortable: false },
					]

				, viewrecords: true
                , rownumbers: false
                , shrinkToFit: true
				, scrollrows: true
			    , pager: jQuery('#grdSearchParameters_pager')
				, gridComplete: addParamButton
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
				, rowList: [20, 30, 40]
			    , caption: 'Parameters'
			    , autowidth: '100%'
			    , height: '100%'
				, autoheight: true
				, viewsortcols: [false, 'vertical', true]
                , cellEdit: true
			    , cellsubmit: 'remote'
				, cellurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdParameters&editMode=1&SessionVarName=ucEmpSearch_FilterSetsList'
				, afterEditCell: function (id, name, val, iRow, iCol) {
				    //to prevent auto-postback
				    $(':input').keydown(function (event) {
				        if (event.keyCode == 13 && event.which == 13)
				            event.preventDefault();
				    });
				    //end

				}
            , afterSaveCell: function (rowid, cellname, value, iRow, iCol) {
                var retVal = jQuery.ajax
	                    (
	                        {
	                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=SetActualValue&VID=' + rowid,
	                            async: false
	                        }
                        ).responseText;
            }
			}

		)
    	.navGrid
   		(
   			'#grdSearchParameters_pager',
   			{
   			    'edit': false, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
   			}
	    );
	}
);

function addParamButton() {
    var grid = jQuery("#grdSearchParameters");
    var ids = grid.jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cl = ids[i];
        var data = grid.jqGrid('getRowData', cl);
        if (data.ColumnName == "Expression" || data.DataType == "DateTime" || data.DataType == "System.DateTime" || data.ColumnName == "FromDate" || data.ColumnName == "ToDate" || data.ColumnName == "Date") continue;
        var btn = "<input style='height:22px;width:30px;' class=\"btnGridCellButton\" type='button' value='...' onclick=\"afterParamCellButtonClick('" + data.VID + "','" + data.ColumnName + "','" + data.IsParameter + "','" + data.EntityID + "');\" />";
        grid.jqGrid('setRowData', ids[i], { Button: btn });
    }
};
function afterParamCellButtonClick(vid, columnName, IsParameter, entityId) {
    var retVal = jQuery.ajax
	(
	    {
	        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=SearchOption&EntityID=' + entityId,
	        async: false
	    }
    ).responseText;
    if (retVal != "") {
        ShowMessageBox("HR", retVal);
        return false;
    }
    OpenParameterSelectorMultiselectPopupDialog(vid, 'Select ' + columnName);

}
