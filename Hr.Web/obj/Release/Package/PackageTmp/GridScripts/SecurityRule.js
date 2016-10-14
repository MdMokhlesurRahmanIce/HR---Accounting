jQuery(document).ready
		(
			function() {
			    jQuery('#grdSecurityRule').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSecurityRule&SessionVarName=SecurityRule_SecurityRuleCodeList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSecurityRule&editMode=1&SessionVarName=SecurityRule_SecurityRuleCodeList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', '...', 'Rule Name']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
								{ 'name': 'IsSaved', 'index': 'IsSaved', 'align': 'center', width: 7 },
                                { 'name': 'SecurityRuleCode', 'index': 'SecurityRuleCode', 'width': 100, editable: true, editrules: { required: true }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=SecurityRule_SecurityRuleCodeList&DataTextField=SecurityRuleName&NeedBlank=Empty&DataValueField=SecurityRuleCode')} },
								
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdSecurityRule_pager')
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
						//, sortname: 'IsSaved desc'
						, rowNum: 10
						, rowList: [10, 20, 30]
						, caption: 'Role'
						, autowidth: true
						, height: '100'
						, gridComplete: addCheckBox_grdSecurityRule
//						,onSelectRow: function(id) {
//                                               var data = jQuery("#ctl00_cphBody_grdSecurityRule").jqGrid('getRowData', id);
////                                               var app=data.ApplicationID;
////                                               
////                                               GetApplicationID(app);
//                                               __doPostBack('SelectGridRow', id);
//                                            }
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdSecurityRule_pager',
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

function addCheckBox_grdSecurityRule() {
    var SessionVarName = 'SecurityRule_SecurityRuleCodeList';
    var ColumnName = 'IsSaved';
    
    var ids = jQuery("#grdSecurityRule").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdSecurityRule").jqGrid('getRowData', cid);
        var chk;
        if (data.IsSaved == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
            //__doPostBack('curCheckbox', vid);
        }
        else {
        
            chk = "<input type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
            
        }
        jQuery("#grdSecurityRule").jqGrid('setRowData', ids[i], { IsSaved: chk });
        
    }  
};
