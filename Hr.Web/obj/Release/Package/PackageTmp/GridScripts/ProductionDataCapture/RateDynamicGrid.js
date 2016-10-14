
jQuery(document).ready
(
	function () {
	    //colNames And ColModels
	    var temp = "";
	    var colNames = "";
	    var colModelString = "";
	    var colModel = "";
	    var result = jQuery.ajax
	    	    	            (
	    	    	                {
	    	    	                    url: rootPath + 'GridHelperClasses/ProductionDataCaptureDataHandler.ashx?CallMode=RateDynamicGrid',
	    	    	                    async: false
	    	    	                }
	    	                    ).responseText;
	    temp = result.split("|");
	    colNames = temp[0].split(",");
	    colModelString = temp[1].split("@");

	    colModel = Array();
	    for (var i = 0; i < colModelString.length; i++) {
	        colModel[i] = eval("(" + colModelString[i] + ")");
	    }
	    //End
	    jQuery('#grdRate').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdRate&SessionVarName=Rate_RateDynamicGridList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdRate&editMode=1&SessionVarName=Rate_RateDynamicGridList'
				, datatype: 'json'
			    , page: 1
				, colNames: colNames
				, colModel: colModel
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdRate_pager')
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
				, caption: 'Rate'
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
				            beforeShowForm: function (formid) {
				                bindevent();
				            },
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
				                    beforeShowForm: function (formid) {
				                        bindevent();
				                    },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , ondblClickRow: function (rowid) {
                       $(".ui-icon-pencil").click();
                   }
			}
		)
		.navGrid
		(
			'#grdRate_pager',
			{
			    'edit': false, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdRate').getGridParam('editDialogOptions')
   			, jQuery('#grdRate').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);
function bindevent() {
    try {
        $("#Key1").change(function (e) {
            var thisval = $(e.target).val();
            var objDropDown = document.getElementById('Key2');
            if (objDropDown != null)
                GetDropDownSource_All1(objDropDown, thisval);

            var objDropDown1 = document.getElementById('Key3');
            if (objDropDown1 != null)
                GetDropDownSource_All2(objDropDown1, thisval);

            var objDropDown2 = document.getElementById('Key4');
            if (objDropDown2 != null)
                GetDropDownSource_All3(objDropDown2, thisval);

            var objDropDown3 = document.getElementById('Key5');
            if (objDropDown3 != null)
                GetDropDownSource_All4(objDropDown3, thisval);

            var objDropDown4 = document.getElementById('Key6');
            if (objDropDown4 != null)
                GetDropDownSource_All5(objDropDown4, thisval);
        });
        $("#Key2").change(function (e) {
            var thisval = $(e.target).val();
            var objDropDown = document.getElementById('Key3');
            if (objDropDown != null)
                GetDropDownSource_All2(objDropDown, thisval);

            var objDropDown2 = document.getElementById('Key4');
            if (objDropDown2 != null)
                GetDropDownSource_All3(objDropDown2, thisval);

            var objDropDown3 = document.getElementById('Key5');
            if (objDropDown3 != null)
                GetDropDownSource_All4(objDropDown3, thisval);

            var objDropDown4 = document.getElementById('Key6');
            if (objDropDown4 != null)
                GetDropDownSource_All5(objDropDown4, thisval);
        });
        $("#Key3").change(function (e) {
            var thisval = $(e.target).val();
            var objDropDown = document.getElementById('Key4');
            if (objDropDown != null)
                GetDropDownSource_All3(objDropDown, thisval);

            var objDropDown3 = document.getElementById('Key5');
            if (objDropDown3 != null)
                GetDropDownSource_All4(objDropDown3, thisval);

            var objDropDown4 = document.getElementById('Key6');
            if (objDropDown4 != null)
                GetDropDownSource_All5(objDropDown4, thisval);
        });
        $("#Key4").change(function (e) {
            var thisval = $(e.target).val();
            var objDropDown = document.getElementById('Key5');
            if (objDropDown != null)
                GetDropDownSource_All4(objDropDown, thisval);

            var objDropDown4 = document.getElementById('Key6');
            if (objDropDown4 != null)
                GetDropDownSource_All5(objDropDown4, thisval);
        });
        $("#Key5").change(function (e) {
            var thisval = $(e.target).val();
            var objDropDown = document.getElementById('Key6');
            if (objDropDown != null)
                GetDropDownSource_All5(objDropDown, thisval);
        });
    }
    catch (err) {
    }
}
function GetDropDownSource_All1(objDropDown, thisval, mode) {
    var QString;

    QString = 'mode=onSelectMode_Key1&thisval=' + thisval;
    var retSourceString = jQuery.ajax
    	(
    	    {
    	        url: rootPath + 'GridHelperClasses/MultiDropdownSource.ashx?' + QString,
    	        async: false
    	    }
        ).responseText;
    $(objDropDown).empty();
    $(objDropDown).append(retSourceString);

};
function GetDropDownSource_All2(objDropDown, thisval, mode) {
    var QString;

    QString = 'mode=onSelectMode_Key2&thisval=' + thisval;
    var retSourceString = jQuery.ajax
    	(
    	    {
    	        url: rootPath + 'GridHelperClasses/MultiDropdownSource.ashx?' + QString,
    	        async: false
    	    }
        ).responseText;
    $(objDropDown).empty();
    $(objDropDown).append(retSourceString);

};
function GetDropDownSource_All3(objDropDown, thisval, mode) {
    var QString;

    QString = 'mode=onSelectMode_Key3&thisval=' + thisval;
    var retSourceString = jQuery.ajax
    	(
    	    {
    	        url: rootPath + 'GridHelperClasses/MultiDropdownSource.ashx?' + QString,
    	        async: false
    	    }
        ).responseText;
    $(objDropDown).empty();
    $(objDropDown).append(retSourceString);

};
function GetDropDownSource_All4(objDropDown, thisval, mode) {
    var QString;

    QString = 'mode=onSelectMode_Key4&thisval=' + thisval;
    var retSourceString = jQuery.ajax
    	(
    	    {
    	        url: rootPath + 'GridHelperClasses/MultiDropdownSource.ashx?' + QString,
    	        async: false
    	    }
        ).responseText;
    $(objDropDown).empty();
    $(objDropDown).append(retSourceString);

};
function GetDropDownSource_All5(objDropDown, thisval, mode) {
    var QString;

    QString = 'mode=onSelectMode_Key5&thisval=' + thisval;
    var retSourceString = jQuery.ajax
    	(
    	    {
    	        url: rootPath + 'GridHelperClasses/MultiDropdownSource.ashx?' + QString,
    	        async: false
    	    }
        ).responseText;
    $(objDropDown).empty();
    $(objDropDown).append(retSourceString);

};