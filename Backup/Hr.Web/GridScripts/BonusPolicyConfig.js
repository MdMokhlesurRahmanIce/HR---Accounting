jQuery(document).ready
(
	function () {
	    jQuery('#grdBonusPolicy').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdBonusPolicy&SessionVarName=BonusPolicyDeclaration_BonusPolicyDetailList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdBonusPolicy&editMode=1&SessionVarName=BonusPolicyDeclaration_BonusPolicyDetailList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Min Length', 'Max Length', 'Calculation Type','Salary Head', 'Amount(%)','Fixed Amount','Method']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
				        { 'name': 'MinDays', 'index': 'MinDays', 'width': 100, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
				        { 'name': 'MaxDays', 'index': 'MaxDays', 'width': 80, editable: true },
                        { 'name': 'CalculationType', 'index': 'CalculationType', 'width': 200, editable: true, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=BonusPolicyDeclaration_DropdownList&DataTextField=Text&NeedBlank=Empty&DataValueField=ValueField'), dataEvents: [{ type: 'change', fn: AfterCellChange}]} },
                        { 'name': 'HeadID', 'index': 'HeadID', 'width': 100, editable: true, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=BonusPolicyDeclaration_SalaryHeadList&DataTextField=HeadName&NeedBlank=Empty&DataValueField=SalaryHeadKey')} },
                        { 'name': 'Percentage', 'index': 'Percentage', 'width': 100, editable: true },
                        { 'name': 'Amount', 'index': 'Amount', 'width': 100, editable: true },
                        { 'name': 'Method', 'index': 'Method', 'width': 100, editable: true, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=BonusPolicyDeclaration_DropdownFixedOrProrataList&DataTextField=Text&NeedBlank=Empty&DataValueField=ValueField')} },
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdBonusPolicy_pager')
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
				, caption: 'Bonus Policy Configuration'
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
			'#grdBonusPolicy_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdBonusPolicy').getGridParam('editDialogOptions')
   			, jQuery('#grdBonusPolicy').getGridParam('addDialogOptions')
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

function AfterCellChange(e) {
    var thisval = $(e.target).val();
    if (thisval == 2) {
        $("#HeadID").attr("disabled", true);
        $("#Percentage").attr("disabled", true);
        $("#Amount").attr("disabled", false);
        return false;
    }
    else {
        $("#HeadID").attr("disabled", false);
        $("#Percentage").attr("disabled", false);
        $("#Amount").attr("disabled", true);
        return false;
    }
}
