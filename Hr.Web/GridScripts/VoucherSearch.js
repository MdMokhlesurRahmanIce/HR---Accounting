var subgrid_table_id, pager_id;
jQuery(document).ready
(
	function () {
	    jQuery('#grdVoucherSearch').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdVoucherSearch&SessionVarName=SearchOrEditVoucher_AccVoucherList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdVoucherSearch&editMode=1&SessionVarName=SearchOrEditVoucher_AccVoucherList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Voucher Date', 'Voucher Type', 'Voucher No', 'Payee/Recipient', 'Description', 'Voucher Key']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'VoucherDate', 'index': 'VoucherDate', 'width': 50 },
			            { 'name': 'VoucherTypeKey', 'index': 'VoucherTypeKey', 'width': 30, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editable: true, 'formatter': 'select', edittype: "select", editoptions: { value: GetDropDownSource('SessionVarName=SearchOrEditVoucher_AccVoucherTypeList&DataTextField=VoucherTypeCode&DataValueField=VoucherTypeKey')} },
                        { 'name': 'VoucherNo', 'index': 'VoucherNo', 'width': 50, formatter: Link },
                        { 'name': 'PayRec', 'index': 'PayRec', 'width': 100 },
                        { 'name': 'VoucherDesc', 'index': 'VoucherDesc', 'width': 170 },
                        { 'name': 'VoucherKey', 'index': 'VoucherKey', 'width': 100, 'hidden': true },
                    ]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdVoucherSearch_pager')
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
				, caption: 'Search/Edit Voucher'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
			    //                , ondblClickRow: function (rowid) {
			    //                    var row = $("#grdVoucherSearch").getRowData(rowid);
			    //                    //                    alert(row.VoucherNo);
			    //                    //                    EmployeeBasicInformation.aspx?empcode=" + empCode
			    //                    return '<a href="/hr/PFInfo/PF/PFVoucher.aspx?VoucherNo=' + row.VoucherNo + '" target="_blank"></a>';
			    //                }
			}
		)
		.navGrid
		(
			'#grdVoucherSearch_pager',
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

function ShowVoucherDet(subgrid_id, row_id) {
    subgrid_table_id = subgrid_id + "_t";
    pager_id = "p_" + subgrid_table_id;

    var parentGridID = subgrid_id.toString().substring(0, subgrid_id.toString().lastIndexOf("_"));
    $("#" + parentGridID).restoreRow(row_id);
    var row = $("#" + parentGridID).getRowData(row_id);

    var voucherKey = row.VoucherKey;

    var retVal = jQuery.ajax
                        (
                            {
                                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=GetSearchVoucherDet&VoucherKey=' + voucherKey,
                                async: false
                            }
                        ).responseText

    $("#" + subgrid_id).html("<table id='" + subgrid_table_id + "' class='scroll'></table><div id='" + pager_id + "' class='scroll'></div>");

    jQuery("#" + subgrid_table_id).jqGrid
                (
                    {
                        url: rootPath + 'GridHelperClasses/SubGridGenericHandler.ashx?SessionVarName=SearchOrEditVoucher_AccVoucherDetList&VoucherKey=' + voucherKey
                        , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=' + subgrid_table_id + '&editMode=1&SessionVarName=SearchOrEditVoucher_AccVoucherDetList'
                        , datatype: "json"
                        , colNames: ['VID', 'Account Head', 'Dr', 'Cr']
                        , colModel:
                        	[
                        	    { 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        	    { 'name': 'COAKey', 'index': 'COAKey', 'width': 150, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=SearchOrEditVoucher_AccCOAList&DataTextField=COAName&NeedBlank=Empty&DataValueField=COAKey')} },
                                { 'name': 'Dr', 'index': 'Dr', 'width': 100, 'align': 'right' },
                                { 'name': 'Cr', 'index': 'Cr', 'width': 100, 'align': 'right' }
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

function Link(cellvalue, options, rowObject) {
    return '<a href="/UI/ACC/Voucher.aspx?VoucherNo=' + cellvalue + '&Match=editVoucher" target="_blank">' + rowObject.VoucherNo + '</a>';
}


