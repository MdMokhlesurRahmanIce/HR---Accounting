jQuery(document).ready
(
	function () {
	    jQuery('#grdEthnicGroup').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEthnicGroup&SessionVarName=Ethnicgroup_EthnicGroupList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdEthnicGroup&editMode=1&SessionVarName=Ethnicgroup_EthnicGroupList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Religion', 'Ethnic Name']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
				        { 'name': 'ReligionKey', 'index': 'ReligionKey', 'width': 250, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=Ethnicgroup_LookupEntList&DataTextField=ElementName&NeedBlank=Empty&DataValueField=ElementKey')} },
				        { 'name': 'EthnicName', 'index': 'EthnicName', 'width': 250, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdEthnicGroup_pager')
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
				, caption: 'Ethnic Groups'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
                , addDialogOptions:
				                {
				                    modal: true,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    beforeSubmit: BeforeSubmit_EthnicGroup,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , editDialogOptions:
				                {
				                    modal: true,
				                    closeAfterEdit: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    beforeSubmit: BeforeSubmit_EthnicGroup,
				                    bottominfo: "Fields marked with (*) are required"
				                }
			}
		)
		.navGrid
		(
			'#grdEthnicGroup_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdEthnicGroup').getGridParam('editDialogOptions')
   			, jQuery('#cphInfbody_grdEthnicGroup').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

function BeforeSubmit_EthnicGroup(postdata, formid) {
    var vid;

    if (postdata.grdEthnicGroup_id == '_empty')
        vid = -1;
    else
        vid = postdata.grdEthnicGroup_id;
    var religionKey = postdata.ReligionKey;
    var ethnicName = postdata.EthnicName;
    var retVal = jQuery.ajax
            (
                {
                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=DuplicateEthnicNameCheck&ReligionKey=' + religionKey + '&EthnicName=' + ethnicName + '&VID=' + vid,
                    async: false
                }
            ).responseText;
    if (retVal == "True") {
        if (postdata.grdEthnicGroup_id == '_empty')
            return [false, "Add Failed! Because same ethnic group found.", ""]
        else
            return [false, "Update Failed! Because same ethnic group found.", ""];
    }
    else {
        return [true, "", ""];
    }
}
