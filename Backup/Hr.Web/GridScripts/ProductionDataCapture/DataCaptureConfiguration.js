jQuery(document).ready
		(
			function () {
			    jQuery('#grdDataCaptureConfiguration').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdDataCaptureConfiguration&SessionVarName=Configuration_DataCaptureConfigurationList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdDataCaptureConfiguration&editMode=1&SessionVarName=Configuration_DataCaptureConfigurationList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Field', 'Capture', 'Sequence', 'Rate','Sequence','Fixed']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                                { 'name': 'Field', 'index': 'Field', 'width': 100 },
                                { 'name': 'IsCapture', 'index': 'IsCapture', 'align': 'center', 'width': 20, editable: true, edittype: 'checkbox', formatter: "checkbox" },
                                { 'name': 'CaptureSeq', 'index': 'CaptureSeq', 'width': 20, editable: true, editrules: { required: true} },
                                { 'name': 'IsRate', 'index': 'IsRate', 'align': 'center', 'width': 20, editable: true, edittype: 'checkbox', formatter: "checkbox" },
                                { 'name': 'RateSeq', 'index': 'RateSeq', 'width': 20, editable: true, editrules: { required: true} },
                                { 'name': 'IsFixed', 'index': 'IsFixed', 'align': 'center', 'width': 20, editable: true, edittype: 'checkbox', formatter: "checkbox" }
							]
                         , onSelectRow: function (id) {
                             var ids = jQuery("#grdDataCaptureConfiguration").jqGrid('getDataIDs');
                             if ((ids.length == 1) || (id)) {
                                 var grid = jQuery("#grdDataCaptureConfiguration");
                                 grid.restoreRow(lastRow);
                                 grid.editRow(id, true, '', '', '', '',
                                function (id) {
//                                    jQuery("#" + id + "_SalaryHeadKey", "#grdSalaryInfoEntry").attr("disabled", true);
                                })
                             }
                         }
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdDataCaptureConfiguration_pager')
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
						, rowNum: 20
						, rowList: [20, 40, 60]
						, caption: 'Configuration'
						, autowidth: true
						, height: '200'
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdDataCaptureConfiguration_pager',
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

var lastRow;
function editRow(id) {
    if (id) {
        var grid = jQuery("#grdDataCaptureConfiguration");
        grid.restoreRow(lastRow);
        grid.editRow(id, true);
        lastRow = id;
    }
};