jQuery(document).ready
(
	function () {
	    jQuery('#grdShiftPlan').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdShiftPlan&SessionVarName=ShiftPlan_ShiftBreakInfoList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdShiftPlan&editMode=1&SessionVarName=ShiftPlan_ShiftBreakInfoList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Remark', 'Break Out Time', 'Break In Time', 'Break End Margin', 'Break Time']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'Remark', 'index': 'Remark', 'width': 50, editable: true },
                        { 'name': 'LunchOutTime', 'index': 'LunchOutTime', 'editable': true, 'width': 50, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { size: 15, maxlengh: 10, dataInit: function (element) {
                            $(element).datetimepicker({ ampm: true, hourGrid: 4, minuteGrid: 10, hourMin: 8, hourMax: 24, showButtonPanel: true, dateFormat: 'dd/mm/yy'
                                 , onClose: function (dateText, inst) {
                                     var LunchInTimeTextBox = $('#LunchInTime');
                                     if (LunchInTimeTextBox.val() != '') {
                                         var LunchInTime = new Date(LunchInTimeTextBox.val());
                                         LunchOutTime = new Date(dateText)
                                         if (LunchInTime > LunchOutTime) {
                                             var diff = Math.abs(new Date(LunchInTime) - new Date(LunchOutTime));
                                             var seconds = Math.floor(diff / 1000);
                                             var minutes = Math.floor(seconds / 60);
                                             seconds = seconds % 60;
                                             var hours = Math.floor(minutes / 60);
                                             minutes = minutes % 60;
                                             alert(hours + ":" + minutes);
                                             $('#LunchTime').val(hours + ":" + minutes);
                                         }
                                     }
                                 }, changeMonth: true, changeYear: true
                            })
                        }
                        }
                        },
                        { 'name': 'LunchInTime', 'index': 'LunchInTime', 'editable': true, 'width': 50, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { size: 15, maxlengh: 10, dataInit: function (element) {
                            $(element).datetimepicker({ ampm: true, hourGrid: 4, minuteGrid: 10, hourMin: 8, hourMax: 24, showButtonPanel: true, dateFormat: 'dd/mm/yy'
                         , onClose: function (dateText, inst) {
                             var LunchOutTimeTextBox = $('#LunchOutTime');
                             if (LunchOutTimeTextBox.val() != '') {
                                 var LunchOutTime = new Date(LunchOutTimeTextBox.val());
                                 LunchInTime = new Date(dateText)
                                 if (LunchInTime > LunchOutTime) {
                                     var diff = Math.abs(new Date(LunchInTime) - new Date(LunchOutTime));
                                     var seconds = Math.floor(diff / 1000);
                                     var minutes = Math.floor(seconds / 60);
                                     seconds = seconds % 60;
                                     var hours = Math.floor(minutes / 60);
                                     minutes = minutes % 60;
                                     $('#LunchTime').val(hours + ":" + minutes);
                                 }
                             }
                         }, changeMonth: true, changeYear: true
                            })
                        } 
                        }
                        },
                        { 'name': 'LunchInEndMargin', 'index': 'LunchInEndMargin', 'editable': true, 'width': 50, editrules: { required: false }, editoptions: { size: 15, maxlengh: 10, dataInit: function (element) { $(element).datetimepicker({ ampm: true, hourGrid: 4, minuteGrid: 10, hourMin: 8, hourMax: 24, showButtonPanel: true, dateFormat: 'dd/mm/yy', changeMonth: true, changeYear: true }) } } },
                        { 'name': 'LunchTime', 'index': 'LunchTime', 'editable': true },
                     ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdShiftPlan_pager')
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
                , caption: 'Shift Break'
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
				                    beforeShowForm: fn_beforeShowForm,
				                    beforeSubmit: BeforeSubmit_ShiftBreak,
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
				                    beforeShowForm: fn_beforeShowForm,
				                    beforeSubmit: BeforeSubmit_ShiftBreak,
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , ondblClickRow: function (rowid) {
                       $(".ui-icon-pencil").click();
                   }
			}
		)
		.navGrid
		(
			'#grdShiftPlan_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}

           , jQuery('#grdShiftPlan').getGridParam('editDialogOptions')
           , jQuery('#grdShiftPlan').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

function fn_beforeShowForm(formid) {
    var nameColumnField = $('#tr_InTime', formid);
    $('<tr class="FormData" id="tr_AddInfo"><td><input type=textbox style="width:0px; border:0 solid"></td></tr>').insertBefore(nameColumnField);
}

function BeforeSubmit_ShiftBreak(postdata, formid) {
//break minute
    var lunchtmie = postdata.LunchTime;
    var items = lunchtmie.split(":");
    var lunchMinute = parseInt(items[0]) * 60 + parseInt(items[1]);
    //end
    items =$('#cphBody_cphInfbody_txtWorkingHour').val().split(":");
    var workHour = parseInt(items[0]) * 60 + parseInt(items[1]);
    if (workHour > lunchMinute) {
        workHour = workHour - lunchMinute;
        var hours = Math.floor(workHour / 60);
        var minute = workHour % 60;
        $('#cphBody_cphInfbody_txtWorkingHour').val(hours.toString() + ":" + minute.toString());
    }
    return [true, "", ""];
}
