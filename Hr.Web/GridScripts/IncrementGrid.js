jQuery(document).ready
(
	function () {
	    jQuery('#grdIncrement').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdIncrement&SessionVarName=PromotionIncrement_CurrentSalary'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdIncrement&editMode=1&SessionVarName=PromotionIncrement_CurrentSalary'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Salary Head', 'Amount', 'Increment Amount', 'Is Percent']
				, colModel:
					[
                        { 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
						{ 'name': 'SalaryHeadID', 'index': 'SalaryHeadID', "width": 500 },
						{ 'name': 'Amount', 'index': 'Amount', "width": 500 },
						{ 'name': 'IncrementAmount', 'index': 'IncrementAmount', "width": 500, 'editable': true },
						{ 'name': 'IsChecked', 'index': 'IsChecked', 'align': 'center', "width": 250, searchoptions: { sopt: ['cn']} }
					]
			    //, multiselect: true
                , rownumbers: true
				, viewrecords: true
				, scrollrows: true
			    , pager: jQuery('#grdIncrement_pager')
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
				, pginput: false
				, rowNum: 10
				, rowList: [10, 20, 40]
			    , width: 420
				, autoheight: true
				, gridComplete: addCheckBox_grdCalendar
				, onSelectRow: function (id) {
				    var ids = jQuery("#grdIncrement").jqGrid('getDataIDs');
				    if ((ids.length == 1) || (id)) {
				        var grid = jQuery("#grdIncrement");
				        grid.restoreRow(lastSelectedRow);

				        grid.editRow(id, true, '', '', '', '',
                                function (id) {

                                    //                                    var retVal = jQuery.ajax
                                    //	                                                (
                                    //	                                                   {
                                    //	                                                       url: '../GridHelperClasses/DataHandler.ashx?CallMode=Shoilee_MaterialIssue&ID=' + id,
                                    //	                                                       async: false
                                    //	                                                   }
                                    //                                                   ).responseText;
                                    //                                    if (retVal == "True") {
                                    //                                        ShowMessageBox("Shoilee", "Your Stock Is Going To Be Negative Please Rectify Your Entry!");
                                    //                                    }
                                    //                                    $("#grdAttManual").trigger("reloadGrid");
                                });
				        lastSelectedRow = id;
				    }
				}
				, viewsortcols: [false, 'vertical', true]
			}
		)

	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);



var lastSelectedRow;
function editRow(id) {
    if (id) {
        var grid = jQuery("#grdAttManual");
        grid.restoreRow(lastSelectedRow);
        grid.editRow(id, true);
        lastSelectedRow = id;
    }
};

function addCheckBox_grdCalendar() {

    var SessionVarName = 'PromotionIncrement_CurrentSalary';
    var ColumnName = 'IsChecked';
    var isSelectAll = 1;

    var ids = jQuery("#grdIncrement").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdIncrement").jqGrid('getRowData', cid);
        var chk;
        if (data.IsChecked == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
            isSelectAll = 0;
        }
        jQuery("#grdIncrement").jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};


