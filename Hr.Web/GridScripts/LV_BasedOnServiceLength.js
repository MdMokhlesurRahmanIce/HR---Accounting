jQuery(document).ready
		(
			function() {
			    jQuery('#grdBasedOnServiceLength').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdBasedOnServiceLength&SessionVarName=LeavePolicy_LVPolicyDetList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdBasedOnServiceLength&editMode=1&SessionVarName=LeavePolicy_LVPolicyDetList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Min Days', 'Max Days', 'Leave Days']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'MinDays', 'index': 'MinDays', width: 70, editable: true, editrules: { required: true, number: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
								{ 'name': 'MaxDays', 'index': 'MaxDays', width: 70, editable: true, editrules: { required: true, number: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
                                { 'name': 'LeaveDays', 'index': 'LeaveDays', width: 70, editable: true, editrules: { required: true, number: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: false
						, pager: jQuery('#grdBasedOnServiceLength_pager')
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
						, caption: 'Based On Service Length'
						, autowidth: true
						, height: '100%'
						, viewsortcols: [false, 'vertical', true]
                        , addDialogOptions:
				                {
				                    modal: true,
				                    width: 500,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    errorTextFormat: function(data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                        , editDialogOptions:
				                    {
				                        modal: true,
				                        width: 500,
				                        closeAfterEdit: true,
				                        closeOnEscape: false,
				                        viewPagerButtons: false,
				                        bottominfo: "Fields marked with (*) are required"
				                    }
                   , ondblClickRow: function(rowid) {
                       $(".ui-icon-pencil").click();
                   }
					}
				)
				.navGrid
				(
					'#grdBasedOnServiceLength_pager',
					{
					    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
                    , jQuery('#grdBasedOnServiceLength').getGridParam('editDialogOptions')
   			        , jQuery('#grdBasedOnServiceLength').getGridParam('addDialogOptions')
				);
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);