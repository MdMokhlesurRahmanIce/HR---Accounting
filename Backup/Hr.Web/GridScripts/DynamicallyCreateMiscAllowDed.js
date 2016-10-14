
jQuery(document).ready
(
	function () {
	    //Misc Allow Ded entry
	    var temp = "";
	    var colNames = "";
	    var colModelString = "";
	    var colModel = "";

	    var result = jQuery.ajax
	    	    	            (
	    	    	                {
	    	    	                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=MiscAllowDedEntryDynamicGrid',
	    	    	                    async: false
	    	    	                }
	    	                    ).responseText;
	    temp = result.split("|");
	    colNames = temp[0].split(",");
	    colModelString = temp[1].split("@");

	    colModel = Array();
	    for (var i = 0; i < colModelString.length; i++) {
	        colModel[i] = eval("(" + colModelString[i] + ")");
	    }
	    //End
	    jQuery('#cphBody_cphInfbody_grdDynamicallyCreateMiscAllowDed').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=cphBody_cphInfbody_grdDynamicallyCreateMiscAllowDed&SessionVarName=MiscAllowDedEntry_MiscEntryDynamicGridList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=cphBody_cphInfbody_grdDynamicallyCreateMiscAllowDed&editMode=1&SessionVarName=MiscAllowDedEntry_MiscEntryDynamicGridList'
				, datatype: 'json'
			    , page: 1
				, colNames: colNames
				, colModel: colModel
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdDynamicallyCreateMiscAllowDed_pager')
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
                , onSelectRow: function (id) {
                    var ids = jQuery("#cphBody_cphInfbody_grdDynamicallyCreateMiscAllowDed").jqGrid('getDataIDs');
                    if ((ids.length == 1) || (id)) {
                        var grid = jQuery("#cphBody_cphInfbody_grdDynamicallyCreateMiscAllowDed");
                        grid.restoreRow(lastgrdSalaryHead);
                        grid.editRow(id, true, '', '', '', '')
                    }
                }
				, sortable: true
				, rowNum: 10
				, rowList: [10, 20, 30]
				, caption: 'Branches'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdDynamicallyCreateMiscAllowDed_pager',
			{
			    'edit': false, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true,
			}
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

var lastgrdSalaryHead;
function editRow(id) {
    if (id) {
        var grid = jQuery("#grdMiscSalaryHead");
        grid.restoreRow(lastgrdSalaryHead);
        grid.editRow(id, true);
        lastgrdSalaryHead = id;
    }
};
