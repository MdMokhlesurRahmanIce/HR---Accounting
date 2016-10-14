jQuery(document).ready
(
	function () {
	    try {
	        jQuery('#grdAccFiscalYear').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdAccFiscalYear&SessionVarName=Acc_FiscalYear_Gen_AccFYList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdAccFiscalYear&editMode=1&SessionVarName=Acc_FiscalYear_Gen_AccFYList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Name', 'Start Date', 'End Date', 'Status']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
				        { 'name': 'FYName', 'index': 'FYName', 'width': 150, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { maxlength: "100"} },
				        { 'name': 'SDate', 'index': 'SDate', 'width': 70, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1930:2018' }) } } },
						{ 'name': 'EDate', 'index': 'EDate', 'width': 70, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { dataInit: function (element) { $(element).datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1930:2018' }) } } },
                        { 'name': 'IsActive', 'index': 'IsActive', 'align': 'center', width: 20, editable: true, edittype: "checkbox", formatter: 'checkbox' }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdAccFiscalYear_pager')
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
				, caption: 'Fiscal Year'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
                , addDialogOptions:
				                {
				                    //modal: true,
				                    width: 500,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    beforeSubmit: BeforeSubmit_AccFY,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , editDialogOptions:
				                {
				                   // modal: true,
				                    width: 500,
				                    closeAfterEdit: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    beforeSubmit: BeforeSubmit_AccFY,
				                    bottominfo: "Fields marked with (*) are required"
				                }
			                    , ondblClickRow: function (rowid) {
			                        $('.ui-icon-pencil', '#edit_' + this.id).click();
			                    }
			}
		)
		.navGrid
		(
			'#grdAccFiscalYear_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdAccFiscalYear').getGridParam('editDialogOptions')
   			, jQuery('#grdAccFiscalYear').getGridParam('addDialogOptions')
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

	function BeforeSubmit_AccFY(postdata, formid) {
    var vid;

    if (postdata.grdAccFiscalYear_id == '_empty')
        vid = -1;
    else
        vid = postdata.grdAccFiscalYear_id;
    var FYName = postdata.FYName;
    var SDate = $("#SDate").val();
    var EDate = $("#EDate").val();
    var retVal = jQuery.ajax
                    (
                        {
                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=DuplicateAccFiscalYearCheck&FYName=' + FYName + '&SDate=' + SDate + '&EDate=' + EDate + '&VID=' + vid,
                            async: false
                        }
                    ).responseText;
    if (retVal == "Duplicate") {
        if (postdata.grdAccFiscalYear_id == '_empty')
            return [false, "Add Failed! Duplicate Name or Invalid Date range found.", ""]
        else
            return [false, "UpDate Failed! Duplicate Name or Invalid Date range found.", ""];
    }
    else {
        return [true, "", ""];
    }
}
