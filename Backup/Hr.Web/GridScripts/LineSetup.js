jQuery(document).ready
(
	function () {
	    jQuery('#grdLineSetup').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdLineSetup&SessionVarName=LineSetup_LineList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdLineSetup&editMode=1&SessionVarName=LineSetup_LineList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Company', 'Line No', 'Line Name']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'OrgKey', 'index': 'OrgKey', editrules: { required: true }, editable: true, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, 'formatter': 'select', edittype: "select", editoptions: { value: GetDropDownSource('SessionVarName=LineSetup_CompanyList&DataTextField=OrgName&DataValueField=OrgKey')} },
				        { 'name': 'LineNo', 'index': 'LineNo', 'width': 200, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }},
				        { 'name': 'LineName', 'index': 'LineName', 'width': 400, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' } }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdLineSetup_pager')
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
				, caption: 'Company'
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
			'#grdLineSetup_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdLineSetup').getGridParam('editDialogOptions')
   			, jQuery('#grdLineSetup').getGridParam('addDialogOptions')
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
