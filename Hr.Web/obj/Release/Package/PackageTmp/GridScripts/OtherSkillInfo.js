jQuery(document).ready
		(
			function () {
			    jQuery('#grdOtherSkillInfo').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdOtherSkillInfo&SessionVarName=EmployeeBasicInfo_OtherSkillInfo'
						, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdOtherSkillInfo&editMode=1&SessionVarName=EmployeeBasicInfo_OtherSkillInfo'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Skill Category', 'Skill Area', 'Description', 'S.Rating', 'C.Rating', 'I.Rating', 'Remarks', 'ReviewDate']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'SkillCategory', 'index': 'SkillCategory', 'width': 40, 'editable': true },
								{ 'name': 'SkillArea', 'index': 'SkillArea', 'width': 40, 'editable': true },
								{ 'name': 'Description', 'index': 'Description', 'width': 60, 'editable': true },
								{ 'name': 'StandardRating', 'index': 'StandardRating', 'width': 20, 'editable': true },
								{ 'name': 'CurrentRating', 'index': 'CurrentRating', 'width': 20, 'editable': true },
								{ 'name': 'InitialRating', 'index': 'InitialRating', 'width': 20, 'editable': true },
								{ 'name': 'Remarks', 'index': 'Remarks', 'width': 30, 'editable': true },
								{ 'name': 'ReviewDate', 'index': 'ReviewDate', 'width': 25, 'editable': true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy', yearRange: '1930:2090' }) } } },
							]
						, viewrecords: true
						, rownumbers: true
						, scrollrows: true
						, pager: jQuery('#grdOtherSkillInfo_pager')
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
						, caption: 'Other Skill Info'
						, autowidth: true
						, autohight: true
						, onSelectRow: editRow_OtherSkillInfo2
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdOtherSkillInfo_pager',
					{
					    'edit': false, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
				)
				.navButtonAdd('#grdOtherSkillInfo_pager',
		        {
		            caption: "",
		            buttonicon: "ui-icon ui-icon-plus",
		            onClickButton: function () {
		                var retVal = jQuery.ajax
	                    (
	                        {
	                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AddNewOtherSkillInfo',
	                            async: false
	                        }
                        ).responseText;

		                $("#grdOtherSkillInfo").trigger("reloadGrid");
		            },
		            position: "first"
		        });
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);


var lastID_editRow_OtherSkillInfo2;
function editRow_OtherSkillInfo2(rowid) {
    var grid = jQuery("#grdOtherSkillInfo");
    var ids = grid.jqGrid('getDataIDs');
    //            alert('Shaikat');    
    if ((ids.length == 1) || (rowid && rowid !== lastID_editRow_OtherSkillInfo2)) {
        grid.restoreRow(lastID_editRow_OtherSkillInfo2);
        jQuery("#grdOtherSkillInfo").jqGrid('editRow', rowid, true);
        lastID_editRow_OtherSkillInfo2 = rowid;
    }
};
