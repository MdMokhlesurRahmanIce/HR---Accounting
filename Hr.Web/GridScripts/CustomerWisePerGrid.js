jQuery(document).ready
		(
			function () {
			    jQuery('#grdEmpWisePer').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpWisePer&SessionVarName=CustomerInfo_PerchentageList'
						, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEmpWisePer&editMode=1&SessionVarName=CustomerInfo_PerchentageList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'EmpKey',  'Customer Name', 'Percentage', 'Remarks']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'EmpKey', 'index': 'ContactPerson', 'hidden': true, 'width': 150, 'editable': true},
                            
								{ 'name': 'CustomerId', 'index': 'CustomerId', 'width': 200, 'editable': true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, 'formatter': 'select', edittype: "select", editoptions: { value: GetDropDownSource('SessionVarName=HKInfo&DataTextField=HKName&DataValueField=HKID')} },
								{ 'name': 'Amount', 'index': 'Amount', 'width': 120, 'editable': true },
								{ 'name': 'Remarks', 'index': 'Remarks', 'width': 120, 'editable': true },
							
							]
						, viewrecords: true
						, rownumbers: true
						, scrollrows: true
						, pager: jQuery('#grdEmpWisePer_pager')
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
						, caption: 'Emergency Info', font: 16
						, autowidth: true
						, height: '100%'
						//, onSelectRow: editRow_CustomerInfo
                       , addDialogOptions:
				                {
				                    modal: true,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdEmpWisePer_pager',
					{
					    'edit': false, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
                    , jQuery('#grdEmpWisePer').getGridParam('editDialogOptions')
   			        , jQuery('#grdEmpWisePer').getGridParam('addDialogOptions')
				)
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);


