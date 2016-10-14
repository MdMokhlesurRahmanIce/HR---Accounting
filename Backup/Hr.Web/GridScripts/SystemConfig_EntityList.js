jQuery(document).ready
(
	function () {
	    jQuery('#grdEntityList').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEntityList&SessionVarName=Entity_EntityList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEntityList&editMode=1&SessionVarName=Entity_EntityList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Entity Name', 'Is Used', 'Is Official<br/>Info', 'Field Type', 'Have Parent', 'Have Child', 'Parent', 'Data<br/>Capture', 'Sequence']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
				        { 'name': 'EntityName', 'index': 'EntityName', 'width': 100, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
                        { 'name': 'IsUsed', 'index': 'IsUsed', 'align': 'center', width: 20, editable: true, edittype: "checkbox", formatter: 'checkbox' },
                        { 'name': 'IsOfficialInfo', 'index': 'IsOfficialInfo', 'align': 'center', width: 20, editable: true, edittype: "checkbox", formatter: 'checkbox' },
                        { 'name': 'FieldType', 'index': 'FieldType', 'width': 20, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
                        { 'name': 'HaveParent', 'index': 'HaveParent', 'align': 'center', width: 20, editable: true, edittype: "checkbox", formatter: 'checkbox' },
                        { 'name': 'HaveChild', 'index': 'HaveChild', 'align': 'center', width: 20, editable: true, edittype: "checkbox", formatter: 'checkbox' },
			            { 'name': 'ParentID', 'index': 'ParentID', 'width': 20, editable: true, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=Entity_EntityList&DataTextField=EntityName&NeedBlank=Empty&DataValueField=EntityID')} },
                        { 'name': 'IsUseToProDataCapture', 'index': 'IsUseToProDataCapture', 'align': 'center', width: 20, editable: true, edittype: "checkbox", formatter: 'checkbox' },
                        {'name': 'Sequence', 'index': 'Sequence', 'width': 20, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdEntityList_pager')
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
				, caption: 'Field List'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
                , addDialogOptions:
				                {
				                    modal: true,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    beforeShowForm: fn_beforeShowForm ,
				                    beforeSubmit: BeforeSubmit_Entity,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , editDialogOptions:
				                {
				                    modal: true,
				                    closeAfterEdit: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    beforeSubmit: BeforeSubmit_Entity,
				                    bottominfo: "Fields marked with (*) are required"
				                }
			}
		)
		.navGrid
		(
			'#grdEntityList_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdEntityList').getGridParam('editDialogOptions')
   			, jQuery('#grdEntityList').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

function BeforeSubmit_Entity(postdata, formid) {
    var vid;

    if (postdata.grdEntityList_id == '_empty')
        vid = -1;
    else
        vid = postdata.grdEntityList_id;

    var entityName = postdata.EntityName;
    var retVal = jQuery.ajax
            (
                {
                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=DuplicateEntityNameCheck&EntityName=' + entityName + '&VID=' + vid,
                    async: false
                }
            ).responseText;
    if (retVal == "True") {
        if (postdata.grdEntityList_id == '_empty')
            return [false, "Add Failed! Because same entity found.", ""]
        else
            return [false, "Update Failed! Because same entity found.", ""];
    }
    else {
        return [true, "", ""];
    }
}


function fn_beforeShowForm(formid) {
var retVal = jQuery.ajax
             (  
                {
                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=getRowCount&sessionName=Entity_EntityList',
                    async: false
                }
              ).responseText;
$("#Sequence").val(retVal);
}

