jQuery(document).ready
(
	function () {
	    jQuery('#grdDisciplinaryAction').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdDisciplinaryAction&SessionVarName=Bank_BankBranchList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdDisciplinaryAction&editMode=1&SessionVarName=Bank_BankBranchList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Code No', 'HR Ref', 'Description', 'Date', 'Taken Action']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'BranchName', 'index': 'BranchName', 'width': 50, 'editable': true },
								{ 'name': 'Address', 'index': 'Address', 'width': 50, 'editable': true },
								{ 'name': 'ContactPerson', 'index': 'ContactPerson', 'width': 50, 'editable': true },
								{ 'name': 'ContactCellNo', 'index': 'ContactCellNo', 'width': 20, 'editable': true },
								{ 'name': 'LandPhone', 'index': 'LandPhone', 'width': 50, 'editable': true },

							]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdDisciplinaryAction_pager')
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
				, caption: 'Branch'
				, autowidth: true
				, height: '240'
				, viewsortcols: [false, 'vertical', true]
                , addDialogOptions:
				                {
				                    modal: true,
				                    width: 500,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    //beforeSubmit: BeforeSubmit_LineSetup,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , editDialogOptions:
				                {
				                    modal: true,
				                    width: 500,
				                    closeAfterEdit: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    //beforeSubmit: BeforeSubmit_LineSetup,
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , ondblClickRow: function (rowid) {
                       $(".ui-icon-pencil").click();
                   }

			}
		)
		.navGrid
		(
			'#grdDisciplinaryAction_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdDisciplinaryAction').getGridParam('editDialogOptions')
   			, jQuery('#grdDisciplinaryAction').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

function BeforeSubmit_LineSetup(postdata, formid) {
    var vid;

    if (postdata.grdLineSetup_id == '_empty')
        vid = -1;
    else
        vid = postdata.grdLineSetup_id;
    var CompanyName = postdata.OrgName;
    var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=DuplicateCompanyNameCheck&CompanyCode=' + CompanyName + '&VID=' + vid,
                        async: false
                    }
                ).responseText;
    if (retVal == "False") {
        if (postdata.grdCompany_id == '_empty')
            return [false, "Add Failed! Because same line name found.", ""]
        else
            return [false, "Update Failed! Because same line name found.", ""];
    }
    else {
        return [true, "", ""];
    }
}
