jQuery(document).ready
(
	function () {
	    jQuery('#grdParameters').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdParameters&SessionVarName=ReportViewer_FilterSetList'
			    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdParameters&editMode=1&SessionVarName=ReportViewer_FilterSetList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', '', 'Expression', '', 'Value', '', '', 'DataType', 'TableName', 'IsParameter']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'index': 'VID' },
						{ 'name': 'Caption', 'index': 'Caption', "width": 25, "align": "center" },
						{ 'name': 'ColumnName', 'index': 'ColumnName', "width": 100, sortable: false },
						{ 'name': 'Operators', 'index': 'Operators', "width": 25, "align": "center" },
                        { 'name': 'ColumnValue', 'index': 'ColumnValue', "editable": true, "width": 250, sortable: false },
                        { 'name': 'Button', index: 'Button', width: 25, sortable: false },
                        { 'name': 'OrAnd', 'index': 'OrAnd', "width": 25, "align": "center" },
                        { 'name': 'DataType', 'index': 'DataType', "hidden": true },
                        { 'name': 'TableName', 'index': 'TableName', "hidden": true },
                        { 'name': 'IsParameter', 'index': 'IsParameter', "hidden": true }
					]

				, viewrecords: true
				, scrollrows: true
			    , pager: jQuery('#grdParameters_pager')
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
				, rowNum: 20
				, rowList: [20, 30, 40]
			    , caption: 'Parameters'
			    , width: '540'
				, height: '250'
			    //, autoheight:true
				, viewsortcols: [false, 'vertical', true]
				, cellEdit: true
			    , cellsubmit: 'remote'
				, cellurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdParameters&editMode=1&SessionVarName=ReportViewer_FilterSetList'
				, afterEditCell: function (id, name, val, iRow, iCol) {
				    //to prevent auto-postback
				    $(':input').keydown(function (event) {
				        if (event.keyCode == 13 && event.which == 13)
				            event.preventDefault();
				    });
				    var data = jQuery("#grdParameters").jqGrid('getRowData', id);
				    if (data.DataType == "DateTime" || data.DataType == "System.DateTime" || data.ColumnName == "DateOfJoinFrom" || data.ColumnName == "DateOfJoinTo" || data.ColumnName == "Date" || data.ColumnName == "FromDate" || data.ColumnName == "ToDate" || data.ColumnName == "AsOnDate" || data.ColumnName == "Workdate" || data.ColumnName == "PreviousDate")
				        jQuery("#" + iRow + "_ColumnValue", "#grdParameters").datepicker({ onSelect: function () { $("#grdParameters").jqGrid("saveCell", iRow, iCol); $('#grdParameters').trigger("reloadGrid"); }, showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: "mm/dd/yy" });
				    //end
				}

			}
		)
    	.navGrid
   		(
   			'#grdParameters_pager',
   			{
   			    'edit': false, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
   			}
	    );
	}
);

function addParamButton() {
    var grid = jQuery("#grdParameters");
    var ids = grid.jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cl = ids[i];
        var data = grid.jqGrid('getRowData', cl);
        if (data.ColumnName == "Expression" || data.DataType == "DateTime" || data.DataType == "System.DateTime" || data.ColumnName == "DateOfJoinFrom" || data.ColumnName == "DateOfJoinTo" || data.ColumnName == "Date" || data.ColumnName == "FromDate" || data.ColumnName == "ToDate" || data.ColumnName == "AsOnDate" || data.ColumnName == "Workdate" || data.ColumnName == "PreviousDate") continue;
        var btn = "<input style='height:22px;width:30px;' class=\"btnGridCellButton\" type='button' value='...' onclick=\"afterParamCellButtonClick('" + data.VID + "','" + data.ColumnName + "','" + data.IsParameter + "');\" />";
        grid.jqGrid('setRowData', ids[i], { Button: btn });
    }
};
function afterParamCellButtonClick(vid, columnName, IsParameter) {
    var retVal = jQuery.ajax
	(
	    {
	        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=InitParameterTableValue&ColumnName=' + columnName,
	        async: false,
	        error: function (xhr, status, error) {
	            ShowMessageBox('Error', xhr.responseText);
	        }
	    }
    ).responseText;
    if (retVal == "TRUE") {
        /*if (columnName == "FiscalYear" || columnName == "Month" || columnName == "Company" || columnName == "Branch" || columnName == "Year" || columnName == "Department" || columnName == "PFFiscalYear")
            OpenParameterSelectorPopupDialog(vid, 'Select ' + columnName);
        else*/
            OpenParameterSelectorMultiselectPopupDialog(vid, 'Select ' + columnName);
    }
}
