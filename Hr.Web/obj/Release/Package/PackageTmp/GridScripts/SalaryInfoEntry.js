jQuery(document).ready
		(
			function () {
			    jQuery('#grdSalaryInfoEntry').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSalaryInfoEntry&SessionVarName=SalaryInfoEntry_grdSalaryEntryList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSalaryInfoEntry&editMode=1&SessionVarName=SalaryInfoEntry_grdSalaryEntryList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Salary Head', 'Amount']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': '5%', 'index': 'VID' },
                                { 'name': 'SalaryHeadKey', 'index': 'SalaryHeadKey', 'width': '50%', edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=SalaryInfoEntry_SalaryHeadList&DataTextField=HeadName&NeedBlank=Empty&DataValueField=SalaryHeadKey')} },
                                { 'name': 'Amount', 'index': 'Amount', 'width': '50%', 'align': 'right', 'editable': true }
							]
                         , onSelectRow: function (id) {
                             var retVal = jQuery.ajax
                                    (
                                        {
                                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=EditableSalaryInfoGrid&VID=' + id,
                                            async: false
                                        }
                                    ).responseText
                             if (retVal == "true") {
                                 var ids = jQuery("#grdSalaryInfoEntry").jqGrid('getDataIDs');
                                 if ((ids.length == 1) || (id)) {
                                     var grid = jQuery("#grdSalaryInfoEntry");
                                     grid.restoreRow(lastgrdSalaryInfo);
                                     grid.editRow(id, true, '', '', '', '',
                                function (id) {
                                    jQuery("#" + id + "_SalaryHeadKey", "#grdSalaryInfoEntry").attr("disabled", true);
                                })
                                 }

                             }
                         }
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdSalaryInfoEntry_pager')
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
						, caption: 'Salary Info Entry'
						, width: 320
						, autoheight: true
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdSalaryInfoEntry_pager',
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

var lastgrdSalaryInfo;
function editRow(id) {
    if (id) {
        var grid = jQuery("#grdSalaryInfoEntry");
        grid.restoreRow(lastgrdSalaryInfo);
        grid.editRow(id, true);
        lastgrdSalaryInfo = id;
    }
};