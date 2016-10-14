jQuery(document).ready
(
	function () {
	    jQuery('#grdSkillInfo').jqGrid
		(
			{

			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSkillInfo&SessionVarName=EmployeeBasicInfo_SkillInfo'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSkillInfo&editMode=1&SessionVarName=EmployeeBasicInfo_SkillInfo'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', '...', 'Item', 'Skill Category', 'Description', 'SMV', 'Rating']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'index': 'VID' },
						{ 'name': 'IsCheck', 'index': 'IsCheck', 'align': 'center', 'width': 10, searchoptions: { sopt: ['cn']} },
						{ 'name': 'SkillArea', 'index': 'SkillArea', 'width': 40 },
						{ 'name': 'SkillCategory', 'index': 'SkillCategory', 'width': 50 },

						{ 'name': 'Description', 'index': 'Description', 'width': 60 },
						{ 'name': 'SMV', 'index': 'SMV', 'width': 30 },
						{ 'name': '', 'index': '', 'width': 30, 'editable': true }
					]
                , multiselect: false
				, viewrecords: true
				, scrollrows: true
			    , pager: jQuery('#grdSkillInfo_pager')
				, loadError: jqGrid_aspnet_loadErrorHandler
				, gridComplete: addCheckBox_grdMenu
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
				, pginput: false
				, rowNum: 20
				, rowList: [20, 30, 40]
				, caption: 'Skill Info'
			    , autowidth: true
				, autohight: true
				, editDialogOptions:
		                  {
		                      width: '400',
		                      modal: true,
		                      closeAfterEdit: true,
		                      closeOnEscape: true,
		                      viewPagerButtons: false,
		                      bottominfo: "Fields marked with (*) are required"
		                  }
				, viewsortcols: [false, 'vertical', true]
			}
		)
    	.navGrid
   		(

   			'#grdSkillInfo_pager',
   			{
   			    'edit': true, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true


   			}
   			, jQuery('#grdSkillInfo').getGridParam('editDialogOptions')
   			, jQuery('#grdSkillInfo').getGridParam('editDialogOptions')
	    );
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {   //alert("See Shaikat");
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

function addCheckBox_grdMenu() {
    var SessionVarName = 'EmployeeBasicInfo_SkillInfo';

    var ColumnName = 'IsCheck';

    var ids = jQuery("#grdSkillInfo").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdSkillInfo").jqGrid('getRowData', cid);
        var chk;
        if (data.IsCheck == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }

        jQuery("#grdSkillInfo").jqGrid('setRowData', ids[i], { IsCheck: chk });


    }

};
