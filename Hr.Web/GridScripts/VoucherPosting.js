var subgrid_table_id, pager_id;
jQuery(document).ready
(
	function () {
	    jQuery('#grdVoucherPosting').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdVoucherPosting&SessionVarName=PostingVoucher_AccVoucherList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdVoucherPosting&editMode=1&SessionVarName=PostingVoucher_AccVoucherList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', '...', 'Voucher Date', 'Voucher Type', 'Voucher No', 'Payee/Recipient', 'Description', 'Voucher Key']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'IsApproved', 'index': 'IsApproved', 'align': 'center', 'width': 20 },
                        { 'name': 'VoucherDate', 'index': 'VoucherDate', 'width': 50 },
			            { 'name': 'VoucherTypeKey', 'index': 'VoucherTypeKey', 'width': 30, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editable: true, 'formatter': 'select', edittype: "select", editoptions: { value: GetDropDownSource('SessionVarName=PostingVoucher_AccVoucherTypeList&DataTextField=VoucherTypeCode&DataValueField=VoucherTypeKey')} },
                        { 'name': 'VoucherNo', 'index': 'VoucherNo', 'width': 50 },
                        { 'name': 'PayRec', 'index': 'PayRec', 'width': 100 },
                        { 'name': 'VoucherDesc', 'index': 'VoucherDesc', 'width': 170 },
                        { 'name': 'VoucherKey', 'index': 'VoucherKey', 'width': 100, 'hidden': true },
                    ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
                , gridComplete: addCheckBox_grd
				, pager: jQuery('#grdVoucherPosting_pager')
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
                , subGrid: true
				, subGridRowExpanded: ShowVoucherDet
				, rowNum: 10
				, rowList: [10, 20, 30]
				, caption: 'Posting Voucher'
                , beforeSelectRow: function (rowid, e) {
                    var sessionVarName = "PostingVoucher_AccVoucherList";
                    var retVal = jQuery.ajax
                        (
                            {
                                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllCheckOrUncheck1&SessionVarName=' + sessionVarName,
                                async: false
                            }
                        ).responseText
                    if (retVal == "True") {
                        $("#cphBody_cphInfbody_chkApproveOrUnapprove").attr('checked', false);
                    }
                    else {
                        $("#cphBody_cphInfbody_chkApproveOrUnapprove").attr('checked', true);
                    }
                }
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdVoucherPosting_pager',
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

function addCheckBox_grd() {

    var SessionVarName = 'PostingVoucher_AccVoucherList';
    var ColumnName = 'IsApproved';

    var ids = jQuery("#grdVoucherPosting").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdVoucherPosting").jqGrid('getRowData', cid);
        var chk;
        if (data.IsApproved == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#grdVoucherPosting").jqGrid('setRowData', ids[i], { IsApproved: chk });

    }
};

function ShowVoucherDet(subgrid_id, row_id) {
    subgrid_table_id = subgrid_id + "_t";
    pager_id = "p_" + subgrid_table_id;

    var parentGridID = subgrid_id.toString().substring(0, subgrid_id.toString().lastIndexOf("_"));
    $("#" + parentGridID).restoreRow(row_id);
    var row = $("#" + parentGridID).getRowData(row_id);

    var voucherKey = row.VoucherKey;
    var fromDate = $("#cphBody_cphInfbody_ctrlVoucher_txtDateFrom").val();
    var retVal = jQuery.ajax
                        (
                            {
                                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=GetVoucherDet&VoucherKey=' + voucherKey + '&FromDate=' + fromDate,
                                async: false
                            }
                        ).responseText

    $("#" + subgrid_id).html("<table id='" + subgrid_table_id + "' class='scroll'></table><div id='" + pager_id + "' class='scroll'></div>");

    jQuery("#" + subgrid_table_id).jqGrid
                (
                    {
                        url: rootPath + 'GridHelperClasses/SubGridGenericHandler.ashx?SessionVarName=PostingVoucher_AccVoucherDetList&VoucherKey=' + voucherKey
                        , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=' + subgrid_table_id + '&editMode=1&SessionVarName=PostingVoucher_AccVoucherDetList'
                        , datatype: "json"
                        , colNames: ['VID', 'Account Head', 'Dr', 'Cr', 'Balance']
                        , colModel:
                        	[
                        	    { 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        	    { 'name': 'COAKey', 'index': 'COAKey', 'width': 150, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=PostingVoucher_AccCOAList&DataTextField=COAName&NeedBlank=Empty&DataValueField=COAKey')} },
                                { 'name': 'Dr', 'index': 'Dr', 'width': 100, 'align': 'right' },
                                { 'name': 'Cr', 'index': 'Cr', 'width': 100, 'align': 'right' },
                                { 'name': 'Bal', 'index': 'Bal', 'width': 100, 'align': 'right' }
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
                    }
                )
                .navGrid
	            (
		            "#" + pager_id,
		            {
		                'edit': false, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
		            }
                    , jQuery("#" + subgrid_table_id).getGridParam('editDialogOptions')
   	                , jQuery("#" + subgrid_table_id).getGridParam('addDialogOptions')
                )
}


