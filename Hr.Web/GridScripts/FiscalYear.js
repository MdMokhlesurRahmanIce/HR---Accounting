jQuery(document).ready
(
	function () {
	    try {
	        jQuery('#cphBody_cphInfbody_grdFiscalYear').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=cphBody_cphInfbody_grdFiscalYear&SessionVarName=FiscalYear_Gen_FYList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=cphBody_cphInfbody_grdFiscalYear&editMode=1&SessionVarName=FiscalYear_Gen_FYList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID','Company', 'Name','Start Date', 'End Date', 'Status']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'OrgKey', 'index': 'OrgKey', editable: true, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=FiscalYear_Gen_OrgList&DataTextField=HKName&NeedBlank=Empty&DataValueField=HKID')} },
				        { 'name': 'FYName', 'index': 'FYName', 'width': 150, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { maxlength: "100"} },
				        { 'name': 'SDate', 'index': 'SDate', 'width': 70, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1930:2050' }) } } },
                        { 'name': 'EDate', 'index': 'EDate', 'width': 70, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1930:2050' }) } } },
                        { 'name': 'Status', 'index': 'Status', 'align': 'center', width: 20, editable: true, edittype: "checkbox", formatter: 'checkbox' }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdFiscalYear_pager')
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
				, caption: 'Leave Year'
				, autowidth: true
				, height: '240'
				, viewsortcols: [false, 'vertical', true]
                , addDialogOptions:
				                {
				                    //modal: true,
				                    width: 500,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    beforeSubmit: BeforeSubmit_Bank,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , editDialogOptions:
				                {
				                    //modal: true,
				                    width: 500,
				                    closeAfterEdit: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    beforeSubmit: BeforeSubmit_Bank,
				                    bottominfo: "Fields marked with (*) are required"
				                }
			        , ondblClickRow: function (rowid) {
			            $('.ui-icon-pencil', '#edit_' + this.id).click();
			        }
			}
		)
		.navGrid
		(
			'#grdFiscalYear_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#cphBody_cphInfbody_grdFiscalYear').getGridParam('editDialogOptions')
   			, jQuery('#cphBody_cphInfbody_grdFiscalYear').getGridParam('addDialogOptions')
		);
	    }
	    catch (e) {
	        alert(e.ToString());
	    }
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

function BeforeSubmit_Bank(postdata, formid) {
    var vid;

    if (postdata.cphBody_cphHrBody_cphModuleBody_grdFiscalYear_id == '_empty')
        vid = -1;
    else
        vid = postdata.cphBody_cphHrBody_cphModuleBody_grdFiscalYear_id;
    var FYName = postdata.FYName;
    var Orgkey = $("#OrgKey").val(); // postdata.Orgkey;
    var SDate = $("#SDate").val();
    var EDate = $("#EDate").val();
    var retVal = jQuery.ajax
                    (
                        {
                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=DuplicateFiscalYearCheck&FYName=' + FYName + '&Orgkey=' + Orgkey + '&SDate=' + SDate + '&EDate=' + EDate + '&VID=' + vid,
                            async: false
                        }
                    ).responseText;
    if (retVal == "Duplicate") {
        if (postdata.cphBody_cphHrBody_cphModuleBody_grdFiscalYear_id == '_empty')
            return [false, "Add Failed! Duplicate Name or Invalid Date range found.", ""]
        else
            return [false, "Update Failed! Duplicate Name or Invalid Date range found.", ""];
    }
    else {
        return [true, "", ""];
    }
}
