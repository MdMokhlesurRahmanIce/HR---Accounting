jQuery(document).ready
(
	function () {
	    jQuery('#grdOTSlab').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdOTSlab&SessionVarName=OTSlab_OTSlabList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdOTSlab&editMode=1&SessionVarName=OTSlab_OTSlabList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Slab Type', 'Duration', 'RateType', 'Amount', 'Salary Head', 'Days', 'MultificationFactor', 'Sequence']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
				        { 'name': 'SlabType', 'index': 'SlabType', 'width': 80, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
				        { 'name': 'Duration', 'index': 'Duration', 'width': 40, editable: true, editrules: { required: true, number:true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>'} },
                        { 'name': 'RateType', 'index': 'RateType', 'width': 80, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=OTSlab_DropdownList&DataTextField=Text&NeedBlank=Empty&DataValueField=ValueField'), dataEvents: [{ type: 'change', fn: AfterCellChange}]} },
                        { 'name': 'Amount', 'index': 'Amount', 'width': 50, editable: true },
                        { 'name': 'SalaryHead', 'index': 'SalaryHead', 'width': 80, editable: true, editrules: { required: false }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=OTSlab_SalaryHeadList&DataTextField=HeadName&NeedBlank=Empty&DataValueField=SalaryHeadKey')} },
                        { 'name': 'Days', 'index': 'Days', 'width': 40, editable: true, editrules: { number: true} },
                        { 'name': 'MultificationFactor', 'index': 'MultificationFactor', 'width': 40, editable: true },
                        { 'name': 'SequenceNo', 'index': 'SequenceNo', 'width': 30, editable: true }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdOTSlab_pager')
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
				, caption: 'OT Slab'
				, autowidth: true
				, height: '240'
				, viewsortcols: [false, 'vertical', true]
                , addDialogOptions:
				                {
				                    width: 500,
				                    modal: true,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    beforeShowForm: function (formid) {
				                        var retVal = jQuery.ajax
                                                    (
                                                        {
                                                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=getRowCountFromDatabase',
                                                            async: false
                                                        }
                                                    ).responseText;

				                        $("#SequenceNo").val(retVal);
				                    },
				                    beforeSubmit: BeforeSubmit_OTSlab,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , editDialogOptions:
				                {
				                    width: 500,
				                    modal: true,
				                    closeAfterEdit: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    beforeSubmit: BeforeSubmit_OTSlab,
				                    bottominfo: "Fields marked with (*) are required"
				                }
			}
		)
		.navGrid
		(
			'#grdOTSlab_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdOTSlab').getGridParam('editDialogOptions')
   			, jQuery('#grdOTSlab').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

function BeforeSubmit_OTSlab(postdata, formid) {
    var vid;

    if (postdata.grdOTSlab_id == '_empty')
        vid = -1;
    else
        vid = postdata.grdOTSlab_id;
    var slabType = postdata.SlabType;
    var retVal = jQuery.ajax
            (
                {
                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=DuplicateSlabTypeCheck&SlabType=' + slabType + '&VID=' + vid,
                    async: false
                }
            ).responseText;
    if (retVal == "True") {
        if (postdata.grdEthnicGroup_id == '_empty')
            return [false, "Add Failed! Because same slab type found.", ""]
        else
            return [false, "Update Failed! Because same slab type found.", ""];
    }
    else {
        return [true, "", ""];
    }
}

function AfterCellChange(e) {
    var thisval = $(e.target).val();
    if (thisval == 2) {
        $("#SalaryHead").attr("disabled", true);
        $("#Days").attr("disabled", true);
        $("#MultificationFactor").attr("disabled", true);
        $("#Amount").attr("disabled", false);
        return false;
    }
    else {
        $("#Amount").attr("disabled", true);
        $("#SalaryHead").attr("disabled", false);
        $("#Days").attr("disabled", false);
        $("#MultificationFactor").attr("disabled", false);
        return false;
    }
}


