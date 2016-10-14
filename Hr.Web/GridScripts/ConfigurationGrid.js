jQuery(document).ready
		(
			function () {
			    jQuery('#grdSettings').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSettings&SessionVarName=Settings_SettingsList'
						, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSettings&editMode=1&SessionVarName=Settings_SettingsList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'CharType', 'NumType', 'Data1', 'Data2', 'Data3', 'Remarks', 'SequenceNo']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'CharType', 'index': 'CharType', 'width': 50, 'editable': true },
								{ 'name': 'NumType', 'index': 'NumType', 'width': 35, 'editable': true },
								{ 'name': 'DATA1', 'index': 'DATA1', 'width': 50, 'editable': true },
                                { 'name': 'DATA2', 'index': 'DATA2', 'width': 50, 'editable': true },
                                 { 'name': 'DATA3', 'index': 'DATA3', 'width': 50, 'editable': true },

								{ 'name': 'Remarks', 'index': 'Remarks', 'width': 50, 'editable': true },
								{ 'name': 'SequenceNo', 'index': 'SequenceNo', 'width': 25, 'editable': true }
							]
						, viewrecords: true
						, rownumbers: true
						, scrollrows: true
						, pager: jQuery('#grdSettings_pager')
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
						, rowList: [30, 60, 90]
						, caption: 'Settings'
						, autowidth: true
						, height: '235'
						, onSelectRow: editRow_Settings
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdSettings_pager',
					{
					    'edit': false, 'add': false, 'del': true, 'search': false, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
				)
				.navButtonAdd('#grdSettings_pager',
		        {
		            caption: "",
		            buttonicon: "ui-icon ui-icon-plus",
		            onClickButton: function () {
		                var retVal = jQuery.ajax
	                    (
	                        {
	                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AddNewSetting',
	                            async: false
	                        }
                        ).responseText;

		                $("#grdSettings").trigger("reloadGrid");
		            },
		            position: "first"
		        });
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);

var lastID_editRow_Settings;
function editRow_Settings(rowid) {
    var grid = jQuery("#grdSettings");
    var ids = grid.jqGrid('getDataIDs');
    if ((ids.length == 1) || (rowid && rowid !== lastID_editRow_Settings)) {
        grid.restoreRow(lastID_editRow_Settings);
        jQuery("#grdSettings").jqGrid('editRow', rowid, true);
        lastID_editRow_Settings = rowid;
    }
};				
		

