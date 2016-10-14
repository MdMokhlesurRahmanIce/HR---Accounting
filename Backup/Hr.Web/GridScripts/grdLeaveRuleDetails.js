jQuery(document).ready
		(
			function () {
			    jQuery('#grdLeaveRuleDetails').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdLeaveRuleDetails&SessionVarName=LeaveRule_LeavePolicyMasterToDisplayOrSave'
						, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdLeaveRuleDetails&editMode=1&SessionVarName=LeaveRule_LeavePolicyMasterToDisplayOrSave'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'LeaveType', 'Description', 'LeaveDay', 'Allocation On', 'After(Days)', 'Remarks']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 25, 'index': 'VID' },

								{ 'name': 'LeaveType', 'index': 'CompanyName', 'width': 130, 'editable': false },

								{ 'name': 'PolicyDescription', 'index': 'PolicyDescription', 'width': 180, 'editable': false },
								{ 'name': 'LeaveDays', 'index': 'LeaveDays', 'width': 130, 'editable': false },
								{ 'name': 'LeaveCalculationDepandsOn', 'index': 'LeaveCalculationDepandsOn', 'width': 130, 'editable': false },
								{ 'name': 'StartAfter', 'index': 'StartAfter', 'width': 130, 'editable': false },
								{ 'name': 'Remarks', 'index': 'Remarks', 'width': 130, 'editable': false }
							]
						, viewrecords: true
						, rownumbers: true
						, scrollrows: true
						, pager: jQuery('#grdLeaveRuleDetails_pager')
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
						, rowNum: 5
						, rowList: [10, 20, 30]
						, caption: 'Leave Summary'
						, width: '100%'
				        , height: '100%'


						, viewsortcols: [true, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdLeaveRuleDetails_pager',
					{
					    'edit': false, 'add': false, 'del': true, 'search': false, 'refresh': false, 'view': false, 'position': 'left', 'cloneToTop': true
					}
				)

			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);


