jQuery(document).ready
(
	function () {
	    jQuery('#grdPromotion').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSalaryRuleForIncrement&SessionVarName=PromotionIncrement_CurrentPosition'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSalaryRuleForIncrement&editMode=1&SessionVarName=PromotionIncrement_CurrentPosition'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Criteria', 'Present Position', 'Post Position']
				, colModel:
					[
                        { 'name': 'VID', 'key': true, 'hidden': true, 'width': 30, 'index': 'VID' },
						{ 'name': 'EntityName', 'index': 'EntityName', "width": 80 },
						{ 'name': 'PreHKEntryName', 'index': 'PreHKEntryName', "width": 100 },
						{ 'name': 'UpdatedBy', 'index': 'UpdatedBy', "width": 100, 'editable': true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, 'formatter': 'select', edittype: "select", editoptions: { value: GetDropDownSource('SessionVarName=HKInfo&DataTextField=HKName&DataValueField=HKID')} },

					]
			    //, multiselect: true
                , rownumbers: true
				, viewrecords: true
				, scrollrows: true
			    , pager: jQuery('#grdPromotion_pager')
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
			    , width: 340
				, autoheight: true
				, gridComplete: addCheckBox_grdCalendar
				, onSelectRow: function (id) {
				    var ids = jQuery("#grdPromotion").jqGrid('getDataIDs');
				    if ((ids.length == 1) || (id)) {
				        var grid = jQuery("#grdPromotion");
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
		.navGrid
		(
			'#grdPromotion_pager',
			{
			    'edit': true, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true

			}

		);

	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);



var lastSelectedRow;
function editRow(id) {
    if (id) {
        var grid = jQuery("#grdPromotion");
        grid.restoreRow(lastSelectedRow);
        grid.editRow(id, true);
        lastSelectedRow = id;
    }
};

function addCheckBox_grdCalendar() {

    var SessionVarName = 'PromotionIncrement_CurrentPosition';
    var ColumnName = 'IsChecked';
    var isSelectAll = 1;

    var ids = jQuery("#grdSalaryRuleForIncrement").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdSalaryRuleForIncrement").jqGrid('getRowData', cid);
        var chk;
        if (data.IsChecked == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
            isSelectAll = 0;
        }
        jQuery("#grdSalaryRuleForIncrement").jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};


