jQuery(document).ready
(
	function () {
	    jQuery('#grdSalaryRule').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSalaryRule&SessionVarName=SalaryRule_grdSalaryRuleList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSalaryRule&editMode=1&SessionVarName=SalaryRule_grdSalaryRuleList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Code', 'Fixed', 'Calculation']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'SalaryHeadKey', 'index': 'SalaryHeadKey', 'width': 50, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=SalaryRule_SalaryHeadList&DataTextField=HeadName&NeedBlank=Empty&DataValueField=SalaryHeadKey')} },
                        { 'name': 'IsFixed', 'index': 'IsChecked', 'align': 'center', 'width': 20, edittype: 'checkbox', formatter: "checkbox" },
                        { 'name': 'Formula1', 'index': 'Formula1', 'width': 50 }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdSalaryRule_pager')
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
                , onSelectRow: function (id) {
                    var retVal = jQuery.ajax
                            (
                                {
                                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=GetHeadWiseRule&VID=' + id,
                                    async: false
                                }
                            ).responseText
                    var items = retVal.split(',');
                    if (items[0] == "Fixed") {
                        $("#cphBody_cphInfbody_ucSalaryRule_ddlSalaryHead").val(items[1]);
                        $("#cphBody_cphInfbody_ucSalaryRule_txtParentHeadAmount").val(items[3]);
                        $("#cphBody_cphInfbody_ucSalaryRule_rdoFixed").attr("checked", true);
                        if (items[2] == "True") {
                            $("#cphBody_cphInfbody_ucSalaryRule_rdoFixed1").attr("checked", true);
                        }
                        else {
                            $("#cphBody_cphInfbody_ucSalaryRule_rdoProportionate").attr("checked", true);
                        }
                        $(".tmp5").show();
                        $(".tmp6").show();

                        $(".tmp4").hide();
                        $(".tmp").hide();
                        $(".tmp1").hide();
                        $(".tmp2").hide();
                        $(".tmp3").show();
                    }
                    else if (items[0] == "Percentage") {
                        $(".tmp5").show();
                        $(".tmp6").show();


                        $(".tmp4").hide();
                        $(".tmp").show();
                        $(".tmp1").hide();
                        $(".tmp2").hide();
                        $(".tmp3").show();

                        $("#cphBody_cphInfbody_ucSalaryRule_ddlSalaryHead").val(items[1]);
                        $("#cphBody_cphInfbody_ucSalaryRule_txtParentHeadAmount").val(items[3]);
                        $("#cphBody_cphInfbody_ucSalaryRule_ddlParentHead").val(items[4]);
                        $("#cphBody_cphInfbody_ucSalaryRule_rdoPercentage").attr("checked", true);
                        if (items[2] == "True") {
                            $("#cphBody_cphInfbody_ucSalaryRule_rdoFixed1").attr("checked", true);
                        }
                        else {
                            $("#cphBody_cphInfbody_ucSalaryRule_rdoProportionate").attr("checked", true);
                        }
                    }
                    else if (items[0] == "Partial") {
                        $(".tmp5").show();
                        $(".tmp6").show();


                        $(".tmp4").hide();
                        $(".tmp").show();
                        $(".tmp1").show();
                        $(".tmp2").show();
                        $(".tmp3").show();

                        $("#cphBody_cphInfbody_ucSalaryRule_ddlSalaryHead").val(items[1]);
                        $("#cphBody_cphInfbody_ucSalaryRule_txtParentHeadAmount").val(items[3]);
                        $("#cphBody_cphInfbody_ucSalaryRule_ddlParentHead").val(items[4]);
                        $("#cphBody_cphInfbody_ucSalaryRule_ddlPartialHead").val(items[5]);
                        $("#cphBody_cphInfbody_ucSalaryRule_txtPartialHeadValue").val(items[6]);
                        $("#cphBody_cphInfbody_ucSalaryRule_rdoPartial").attr("checked", true);
                        if (items[6] == "True") {
                            $("#cphBody_cphInfbody_ucSalaryRule_rdoHigher").attr("checked", true);
                        }
                        else {
                            $("#cphBody_cphInfbody_ucSalaryRule_rdoLower").attr("checked", true);
                        }
                        if (items[2] == "True") {
                            $("#cphBody_cphInfbody_ucSalaryRule_rdoFixed1").attr("checked", true);
                        }
                        else {
                            $("#cphBody_cphInfbody_ucSalaryRule_rdoProportionate").attr("checked", true);
                        }
                    }
                    else if (items[0] == "Formula") {
                        $(".tmp5").show();
                        $(".tmp6").show();


                        $(".tmp").hide();
                        $(".tmp1").hide();
                        $(".tmp2").hide();
                        $(".tmp3").hide();
                        $(".tmp4").show();

                        $("#cphBody_cphInfbody_ucSalaryRule_ddlSalaryHead").val(items[1]);
                        $("#cphBody_cphInfbody_ucSalaryRule_txtFormulaEditor").val(items[3]);
                        $("#cphBody_cphInfbody_ucSalaryRule_rdoFormula").attr("checked", true);
                        if (items[2] == "True") {
                            $("#cphBody_cphInfbody_ucSalaryRule_rdoFixed1").attr("checked", true);
                        }
                        else {
                            $("#cphBody_cphInfbody_ucSalaryRule_rdoProportionate").attr("checked", true);
                        }
                    }
                    return false;
                }
				, sortable: true
				, rowNum: 10
				, rowList: [10, 20, 30]
				, caption: 'Salary Rule'
				, autowidth: true
				, height: '100%'
			    //, gridComplete: addCheckBox_grdSalaryRule
				, viewsortcols: [false, 'vertical', true]

			}
		)
		.navGrid
		(
			'#grdSalaryRule_pager',
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

//function addCheckBox_grdSalaryRule() {

//    var SessionVarName = 'SalaryRule_grdSalaryRuleList';
//    var ColumnName = 'IsFixed';
//    var isSelectAll = 1;

//    var ids = jQuery("#grdSalaryRule").jqGrid('getDataIDs');
//    for (var i = 0; i < ids.length; i++) {
//        var cid = ids[i];
//        var data = jQuery("#grdSalaryRule").jqGrid('getRowData', cid);
//        var chk;
//        if (data.IsFixed == "True") {
//            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
//        }
//        else {
//            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
//            isSelectAll = 0;
//        }
//        jQuery("#grdSalaryRule").jqGrid('setRowData', ids[i], { IsFixed: chk });

//    }
//};

