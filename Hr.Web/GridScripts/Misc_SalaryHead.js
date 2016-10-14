jQuery(document).ready
(
	function () {
	    jQuery('#grdMiscSalaryHead').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdMiscSalaryHead&SessionVarName=MiscAllowDedEntry_SalaryHeadList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdMiscSalaryHead&editMode=1&SessionVarName=MiscAllowDedEntry_SalaryHeadList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', '...', 'Head Name', 'Default Amount', 'Short Name']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'IsChecked', 'index': 'IsChecked', 'align': 'center', 'width': 20 },
                        { 'name': 'HeadName', 'index': 'HeadName', 'width': 100 },
                        { 'name': 'DefaultAmount', 'index': 'DefaultAmount', 'width': 80, 'editable': true, 'align': 'right' },
                        { 'name': 'ShortName', 'index': 'ShortName', 'width': 50, 'align': 'center' }
					]
                , onSelectRow: function (id) {
                    var ids = jQuery("#grdMiscSalaryHead").jqGrid('getDataIDs');
                    if ((ids.length == 1) || (id)) {
                        var grid = jQuery("#grdMiscSalaryHead");
                        grid.restoreRow(lastgrdSalaryHead);
                        grid.editRow(id, true, '', '', '', '')
                    }
                }
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
                , shrinkToFit: false
				, pager: jQuery('#grdMiscSalaryHead_pager')
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
				, caption: 'Salary Head'
				, autowidth: true
				, height: '250'
			    , gridComplete: addCheckBox_grdMisSalaryHead
				, viewsortcols: [false, 'vertical', true]

			}
		)
		.navGrid
		(
			'#grdMiscSalaryHead_pager',
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

function addCheckBox_grdMisSalaryHead() {

    var SessionVarName = 'MiscAllowDedEntry_SalaryHeadList';
    var ColumnName = 'IsChecked';

    var ids = jQuery("#grdMiscSalaryHead").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdMiscSalaryHead").jqGrid('getRowData', cid);
        var chk;
        if (data.IsChecked == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#grdMiscSalaryHead").jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};
var lastgrdSalaryHead;
function editRow(id) {
    if (id) {
        var grid = jQuery("#grdMiscSalaryHead");
        grid.restoreRow(lastgrdSalaryHead);
        grid.editRow(id, true);
        lastgrdSalaryHead = id;
    }
};

