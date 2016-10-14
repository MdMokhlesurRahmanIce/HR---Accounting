
jQuery(document).ready
(
	function () {
	    jQuery('#grdProductionDataCapture').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdProductionDataCapture&SessionVarName=DataCapture_DataCaptureDynamicGridList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdProductionDataCapture&editMode=1&SessionVarName=DataCapture_DataCaptureDynamicGridList'
				, datatype: 'json'
			    , page: 1
				, colNames: ['VID', 'Code', 'Name', 'Rate ID', 'Qty', 'Rate', 'Value', 'Capture Date']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'EmpCode', 'index': 'EmpCode', 'width': 50 },
                        { 'name': 'EmpName', 'index': 'EmpName', 'width': 100 },
                        { 'name': 'DataCaptureRateRuleID', 'index': 'DataCaptureRateRuleID', 'width': 200 },
                        { 'name': 'Qty', 'index': 'Qty', 'width': 50 },
                        { 'name': 'Rate', 'index': 'Rate', 'width': 50 },
                        { 'name': 'Value', 'index': 'Value', 'width': 50 },
                        { 'name': 'ProcessDate', 'index': 'ProcessDate', 'width': 50 }
					]
                , onSelectRow: function (id) {
                    var retVal = jQuery.ajax
                    	        (
                    	            {
                    	                url: rootPath + 'GridHelperClasses/ProductionDataCaptureDataHandler.ashx?CallMode=UpdateDataCaptureGrid&VID=' + id,
                    	                async: false
                    	            }
                                ).responseText
                    if (retVal != "") {
                        var items = retVal.split(';');
                        if (items[0] != "")
                            $("#cphBody_cphInfbody_txtEmpCode").val(items[0]);
                        if (items[1] != "")
                            $("#cphBody_cphInfbody_ddlRateID").val(items[1]);
                        if (items[2] != "")
                            $("#cphBody_cphInfbody_txtQty").val(items[2]);
                        if (items[3] != "")
                            $("#cphBody_cphInfbody_txtRate").val(items[3]);
                        if (items[4] != "")
                            $("#cphBody_cphInfbody_txtCaptureDate").val(items[4]);
                    }
                }
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdProductionDataCapture_pager')
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
				, caption: 'Rate'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdProductionDataCapture_pager',
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
