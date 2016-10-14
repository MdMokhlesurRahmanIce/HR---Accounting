jQuery(document).ready
(
	function () {
	    jQuery('#grdHourWisePayment').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdHourWisePayment&SessionVarName=OtherSalaryRule_HourWisePaymentList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdHourWisePayment&editMode=1&SessionVarName=OtherSalaryRule_HourWisePaymentList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Condition', 'Time Start', 'Time End', 'Criteria', 'Salary Head', 'Amount']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 20, 'index': 'VID' },
					    { 'name': 'Condition', 'index': 'Condition', 'width': 70, editable: true, edittype: "select", editoptions: { value: "IsLess:Is Less;IsGreater:Is Greater;IsEqual:Is Equal;Between:Between", defaultValue: "IsLess" }, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
                        { 'name': 'FromTime', 'index': 'FromTime', 'align': 'left', 'width': 70, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { size: 15, maxlengh: 10, dataInit: function (element) { $(element).timepicker({ showSecond: false, timeFormat: 'hh:mm:ss', stepHour: 1, stepMinute: 1, hourGrid: 4, minuteGrid: 10 }) } } },
                        { 'name': 'ToTime', 'index': 'ToTime', 'align': 'left', 'width': 70, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { size: 15, maxlengh: 10, dataInit: function (element) { $(element).timepicker({ showSecond: false, timeFormat: 'hh:mm:ss', stepHour: 1, stepMinute: 1, hourGrid: 4, minuteGrid: 10 }) } } },
			    //{ 'name': 'ToTime', 'index': 'ToTime', 'align': 'left', 'width': 70, editable: true, editoptions: { disabled: true,size: 15, maxlengh: 10, dataInit: function (element) { $(element).timepicker({ showSecond: false, timeFormat: 'hh:mm:ss', stepHour: 1, stepMinute: 1, hourGrid: 4, minuteGrid: 10 }) } } },
                        {'name': 'sCriteria', 'index': 'sCriteria', 'width': 70, editable: true, edittype: "select", editoptions: { value: "Fixed:Fixed;Percentage:Percentage", defaultValue: "Fixed", dataEvents: [{ type: 'change', fn: fn_Disable}] }, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
                        { 'name': 'SalaryHeadID', 'index': 'SalaryHeadID', 'width': 100, editable: true, editoptions: { disabled: true }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=OtherSalaryRule_SalaryHeadList&DataTextField=HeadName&NeedBlank=Empty&DataValueField=SalaryHeadKey')} },
                        { 'name': 'Amount', 'index': 'Amount', 'align': 'left', 'width': 70, editable: true, editrules: { required: true, number: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
			    //{ 'name': 'ShiftID', 'index': 'ShiftID', 'width': 100, editable: true, editoptions: { disabled: true }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=OtherSalaryRule_ShiftPlanList&DataTextField=ALISE&NeedBlank=Empty&DataValueField=ShiftID') }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} }
                    ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdHourWisePayment_pager')
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
				, caption: 'Based On Out Time'
				, autowidth: true
				, height: '100'
				, viewsortcols: [false, 'vertical', true]
                , addDialogOptions:
				                {
				                    modal: true,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    //afterSubmit: fn_PreApprovedLeaveType,
				                    //beforeSubmit: BeforeSubmit_Entry,
				                    beforeShowForm: fn_Disable,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , editDialogOptions:
				                {
				                    modal: true,
				                    closeAfterEdit: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    //afterSubmit: fn_PreApprovedLeaveType,
				                    //beforeSubmit: BeforeSubmit_Entry,
				                    beforeShowForm: fn_Disable,
				                    bottominfo: "Fields marked with (*) are required"
				                }
                                , ondblClickRow: function (rowid) {
                                    $(".ui-icon-pencil").click();
                                }
			}
		)
		.navGrid
		(
			'#grdHourWisePayment_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdHourWisePayment').getGridParam('editDialogOptions')
   			, jQuery('#grdHourWisePayment').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);
function fn_Disable() {
    if ($("#sCriteria").val() == "Fixed")
        $("#SalaryHeadID").attr("disabled", true);
    else
        $("#SalaryHeadID").attr("disabled", false);
    return true;
}
function AfterCellChange(e) {
    if ($("#Condition").val() == "Between")
        $("#ToTime").attr("disabled", false);
    else
        $("#ToTime").attr("disabled", true);

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
