jQuery(document).ready
		(
			function () {
			    jQuery('#grdLookupEnt').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdLookupEnt&SessionVarName=LookupEnt_LookupEntListByEntityType'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdLookupEnt&editMode=1&SessionVarName=LookupEnt_LookupEntListByEntityType'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Name', 'Description', 'Entity Key', 'Caption']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'ElementName', 'index': 'ElementName', 'editable': true, 'width': 50, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
								{ 'name': 'ElementDesc', 'index': 'ElementDesc', 'editable': true, 'width': 100},
								{ 'name': 'EntityKey', 'index': 'EntityKey', 'editable': true, 'hidden': true, 'width': 50},
								{ 'name': 'EntityCap', 'index': 'EntityCap', 'editable': true, 'width': 50 },
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdLookupEnt_pager')
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
						, caption: 'Entities'
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
					'#grdLookupEnt_pager',
					{
					    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
                 , jQuery('#grdLookupEnt').getGridParam('editDialogOptions')
   			     , jQuery('#grdLookupEnt').getGridParam('addDialogOptions')
			     );
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);



