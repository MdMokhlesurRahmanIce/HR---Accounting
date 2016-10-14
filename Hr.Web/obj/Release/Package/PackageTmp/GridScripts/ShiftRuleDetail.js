jQuery(document).ready
		(
			function () {
			    jQuery('#grdShiftRuleDetail').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdShiftRuleDetail&SessionVarName=ShiftRule_ShiftRuleDetailList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdShiftRuleDetail&editMode=1&SessionVarName=ShiftRule_ShiftRuleDetailList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Shift', 'Alise', 'Shift In Time', 'Shift Out Time', 'Days']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'ShiftID', 'index': 'ShiftID', 'editable': true, 'width': 50, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, 'formatter': 'select', edittype: "select", editoptions: { value: GetDropDownSource('SessionVarName=ShiftRule_ShiftPlanList&DataTextField=ALISE&DataValueField=ShiftID')} },
								{ 'name': 'Alise', 'index': 'Alise', 'editable': true, 'width': 50 },
                                { 'name': 'ShiftInTime', 'index': 'ShiftInTime', 'editable': true, 'width': 50 },
                                { 'name': 'ShiftOutTime', 'index': 'ShiftOutTime', 'editable': true, 'width': 50 },
                                { 'name': 'Days', 'index': 'Days', 'editable': true, 'width': 50 }
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdShiftRuleDetail_pager')
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
						, caption: 'Shift Rule'
						, autowidth: true
						, height: '100%'
						, viewsortcols: [false, 'vertical', true]
                        , addDialogOptions:
				                {
				                    modal: true,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                        , editDialogOptions:
				                {
				                    modal: true,
				                    closeAfterEdit: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    bottominfo: "Fields marked with (*) are required"
				                }
					}
				)
				.navGrid
				(
					'#grdShiftRuleDetail_pager',
					{
					    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
                 , jQuery('#grdShiftRuleDetail').getGridParam('editDialogOptions')
   			     , jQuery('#grdShiftRuleDetail').getGridParam('addDialogOptions')
			     );
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);



