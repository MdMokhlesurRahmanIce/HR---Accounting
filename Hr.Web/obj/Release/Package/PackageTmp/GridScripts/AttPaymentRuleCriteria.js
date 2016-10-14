jQuery(document).ready
(
	function () {
	    jQuery('#grdAttPaymentRuleCriteria').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdAttPaymentRuleCriteria&SessionVarName=AttendancePaymentInfo_AttPaymentRuleCriteriaList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdAttPaymentRuleCriteria&editMode=1&SessionVarName=AttendancePaymentInfo_AttPaymentRuleCriteriaList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Criteria', 'Day Type', 'Condition', 'Days1', 'Days2']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 20, 'index': 'VID' },
                        { 'name': 'CriteriaName', 'index': 'CriteriaName', 'align': 'left', 'width': 80, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { maxlength: "20"} },
                        { 'name': 'DayStatus', 'index': 'DayStatus', 'width': 60, editable: true, edittype: "select", editoptions: { value: "Present:Present;Absent:Absent;Late:Late;LateAndEarlyOut:Late And Early Out;Leave:Leave", defaultValue: "Present" }, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
					    { 'name': 'Condition', 'index': 'Condition', 'width': 50, editable: true, edittype: "select", editoptions: { value: "IsLess:Is Less;IsGreater:Is Greater;IsEqual:Is Equal;Between:Between", defaultValue: "IsLess", dataEvents: [{ type: 'change', fn: AfterCellChange}] }, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
                        { 'name': 'Days1', 'index': 'Days1', 'align': 'left', 'width': 40, editable: true, editrules: { required: true, number: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
                        { 'name': 'Days2', 'index': 'Days2', 'align': 'left', 'width': 40, editable: true, editrules: { number: true }, editoptions: { disabled: true} }
                    ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdAttPaymentRuleCriteria_pager')
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
				, caption: 'Attendance Payment Rule Criteria'
				, autowidth: true
				, height: '200'
				, viewsortcols: [false, 'vertical', true]
                , addDialogOptions:
				                {
				                    modal: true,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    afterSubmit: fn_PreApprovedLeaveType,
				                    //beforeSubmit: BeforeSubmit_Entry,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , editDialogOptions:
				                {
				                    modal: true,
				                    closeAfterEdit: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    afterSubmit: fn_PreApprovedLeaveType,
				                    //beforeSubmit: BeforeSubmit_Entry,
				                    bottominfo: "Fields marked with (*) are required"
				                }
                                , ondblClickRow: function (rowid) {
                                    $(".ui-icon-pencil").click();
                                }
			}
		)
		.navGrid
		(
			'#grdAttPaymentRuleCriteria_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdAttPaymentRuleCriteria').getGridParam('editDialogOptions')
   			, jQuery('#grdAttPaymentRuleCriteria').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);
function fn_PreApprovedLeaveType() {
    if ($("#DayStatus").val() == "Leave")
        $("#PreApprovedLeaveType").show();
    else
        $("#PreApprovedLeaveType").hide();
    return true;
}
function AfterCellChange(e) {
    if ($("#Condition").val() == "Between")
        $("#Days2").attr("disabled", false);
    else
        $("#Days2").attr("disabled", true);

}
function BeforeSubmit_Entry(postdata, formid) {
    var vid;
    if (postdata.SalaryHeadKey == -1) {
        return [false, "Select Salary Head!", ""];
    }

    if (postdata.grdAttendenceRule_id == '_empty')
        vid = -1;
    else
        vid = postdata.grdAttendenceRule_id;
    var head = postdata.SalaryHeadKey;
    var retVal = jQuery.ajax
                    (
                        {
                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=DuplicateSalaryHeadKeyCheck&HeadName=' + head + '&VID=' + vid,
                            async: false
                        }
                    ).responseText;
    if (retVal == "True") {
        if (postdata.grdAttendenceRule_id == '_empty')
            return [false, "Add Failed! Because same Salary Head found.", ""]
        else
            return [false, "UpDate Failed! Because same Salary Head found.", ""];
    }
    else {
        return [true, "", ""];
    }
}
