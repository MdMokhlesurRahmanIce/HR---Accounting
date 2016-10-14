var subgrid_table_id, pager_id, vid;
jQuery(document).ready
(
	function () {
	    jQuery('#grdSalaryHead').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSalaryHead&SessionVarName=SalaryHead_grdSalaryHeadList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSalaryHead&editMode=1&SessionVarName=SalaryHead_grdSalaryHeadList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'ElementKey', 'Head Type']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'HKID', 'index': 'HKID', 'hidden': true, 'width': 50 },
                        { 'name': 'HKName', 'index': 'HKName', 'width': 10 }
                     ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdSalaryHead_pager')
				, loadError: jqGrid_aspnet_loadErrorHandler
                , subGrid: true
				, subGridRowExpanded: SalarySubHeadFunction
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
			   	, caption: 'Salary Head'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdSalaryHead_pager',
			{
			    'edit': false, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);



	function SalarySubHeadFunction(subgrid_id, row_id) {

     try {
    subgrid_table_id = subgrid_id + "_t";
    pager_id = "p_" + subgrid_table_id;

    var parentGridID = subgrid_id.toString().substring(0, subgrid_id.toString().lastIndexOf("_"));
    $("#" + parentGridID).restoreRow(row_id);
    var row = $("#" + parentGridID).getRowData(row_id);
    
    var HKID = row.HKID;
    $("#" + subgrid_id).html("<table id='" + subgrid_table_id + "' class='scroll'></table><div id='" + pager_id + "' class='scroll'></div>");

    jQuery("#" + subgrid_table_id).jqGrid
                (
                    {
                        url: rootPath + 'GridHelperClasses/SubGridGenericHandler.ashx?SessionVarName=SalaryHead_grdSalarySubHeadList&HeadType=' + HKID
                        , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=' + subgrid_table_id + '&editMode=1&SessionVarName=SalaryHead_grdSalarySubHeadList'
                        , datatype: "json"
                        , colNames: ['VID', 'Head Name', 'Description', 'Head Type', 'Sequence No', 'IsVisible', 'IsDisburse', 'IsPerquisite']
                        , colModel:
                        	[
                        	    { 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                                { 'name': 'HeadName', 'index': 'HeadName', 'width': 200, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
                                { 'name': 'Description', 'index': 'Description', 'width': 200, editable: true, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
                                { 'name': 'HeadType', 'index': 'HeadType', 'width': 100, editable: true, 'hidden': true },
                                { 'name': 'SequenceNo', 'index': 'SequenceNo', 'width': 100, editable: true, editrules: { required: true, number: true} },
                                { 'name': 'IsVisible', 'index': 'IsVisible', 'width': 100, editable: true, sortable: false, formatter: 'CheckBoxFormatter', edittype: 'checkbox', editoptions: { value: "True:False" }, formatoptions: { disabled: false} },
                                { 'name': 'IsDisburse', 'index': 'IsDisburse', 'width': 100, editable: true, sortable: false, formatter: 'CheckBoxFormatter', edittype: 'checkbox', editoptions: { value: "True:False" }, formatoptions: { disabled: false} },
                                { 'name': 'IsPerquisite', 'index': 'IsPerquisite', 'width': 100, editable: true, sortable: false, formatter: 'CheckBoxFormatter', edittype: 'checkbox', editoptions: { value: "True:False" }, formatoptions: { disabled: false} },
                        	]
                        , page: 1
                        , jsonReader:
			            {
			                root: 'rows',
			                page: 'currentpage',
			                total: 'totalpages',
			                records: 'pagerecords',
			                repeatitems: false
			            }
                        , autowidth: true
                        , shrinkToFit: false
                        , rowNum: 20
                        , pager: pager_id
                        , sortorder: "asc"
                        , height: '100%'
                        , addDialogOptions:
	    				                {
	    				                    modal: true,
	    				                    closeAfterAdd: true,
	    				                    closeOnEscape: false,
	    				                    viewPagerButtons: false,
	    				                    recreateForm: true,
	    				                    beforeShowForm: function (formid) {
	    				                        $("#HeadType").val(HKID);
	    				                    },
	    				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
	    				                    beforeSubmit: BeforeSubmit_SalaryHead,

	    				                    bottominfo: "Fields marked with (*) are required"
	    				                }
	                       , editDialogOptions:
	    				                {
	    				                    modal: true,
	    				                    closeAfterEdit: true,
	    				                    closeOnEscape: false,
	    				                    recreateForm: true,
	    				                    viewPagerButtons: false,
	    				                    beforeSubmit: BeforeSubmit_SalaryHead,
	    				                    bottominfo: "Fields marked with (*) are required"
	    				                }
                    }
                )

                .navGrid
	            (
		            "#" + pager_id,
		            {
		                'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
		            }
                    , jQuery("#" + subgrid_table_id).getGridParam('editDialogOptions')
   	                , jQuery("#" + subgrid_table_id).getGridParam('addDialogOptions')

                )
		        }
		        catch (e) {
		            alert(e);
		        }
             
}
function BeforeSubmit_SalaryHead(postdata, formid) {
    var HeadName = postdata.HeadName;
    var vid = jQuery("#" + subgrid_table_id).jqGrid('getGridParam', 'selrow');
    var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=DuplicateSalaryHead&HeadName=' + HeadName + '&VID='+ vid,
                        async: false
                    }
                ).responseText;

    if (retVal == "False") {
        if (vid == null)
            return [false, "Add Failed! Because same Salary Head name found.", ""]
        else
            return [false, "Update Failed! Because same Salary Head name found.", ""];
    }
    else {
        return [true, "", ""];
    }
}


