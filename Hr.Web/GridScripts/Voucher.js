jQuery(document).ready
(
	function () {
	    jQuery('#grdPFVoucher').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdPFVoucher&SessionVarName=PFVoucher_AccVoucherDetList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdPFVoucher&editMode=1&SessionVarName=PFVoucher_AccVoucherDetList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'A/C Head', 'Dr', 'Cr']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'COAKey', 'index': 'COAKey', editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=PFVoucher_AccCOAList&DataTextField=COAName&NeedBlank=Empty&DataValueField=COAKey')} },
				        { 'name': 'Dr', 'index': 'Dr', 'width': 150, editable: true, editrules: { number: true }, 'align': 'right' },
				        { 'name': 'Cr', 'index': 'Cr', 'width': 70, editable: true, editrules: { number: true }, 'align': 'right' },
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
                , scroll: true
				, pager: jQuery('#grdPFVoucher_pager')
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
                , beforeSelectRow: function (rowid, e) {
                    var retVal = jQuery.ajax
                    (
                        {
                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=SetControlForEdit&rowID=' + rowid,
                            async: false
                        }
                    ).responseText
                    var items = retVal.split(',');
                    if (items[1] == "0" || items[1] == "0.00") {
                        $("#cphBody_cphInfbody_ddlCredit").val(items[0]);
                        $("#cphBody_cphInfbody_txtCreditAmount").val(items[2]);

                        $("#cphBody_cphInfbody_ddlDebit").val("");
                        $("#cphBody_cphInfbody_txtDrAmount").val("");
                    }
                    else {
                        $("#cphBody_cphInfbody_ddlDebit").val(items[0]);
                        $("#cphBody_cphInfbody_txtDrAmount").val(items[1]);

                        $("#cphBody_cphInfbody_ddlCredit").val("");
                        $("#cphBody_cphInfbody_txtCreditAmount").val("");
                    }
                }
				, sortable: true
                , sortname: 'VID'
                , sortorder: "desc"
			    , footerrow: true
			    , userDataOnFooter: true
			    , postData: { FooterRowCaption: '"COAKey":"Total:"',
			        AggregateColumn: '[Dr]:Sum,[Cr]:Sum'
			    }
				, rowNum: 100
				, rowList: [10, 20, 30]
				, caption: 'Voucher'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
			}
		)
        .navGrid
		(
			'#grdPFVoucher_pager',
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



