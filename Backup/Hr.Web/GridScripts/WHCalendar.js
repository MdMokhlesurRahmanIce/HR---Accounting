jQuery(document).ready
		(
			function () {
			    jQuery('#grdWHCalendar').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdWHCalendar&SessionVarName=WHDeclaration_WHCalendarList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdWHCalendar&editMode=1&SessionVarName=WHDeclaration_WHCalendarList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', '...', 'Date', 'Day Name']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                                {'name': 'IsChecked', 'index': 'IsChecked', 'align': 'center', 'width': 20 },
                                { 'name': 'Date', 'index': 'Date', 'width': 100 },
                                { 'name': 'DateName', 'index': 'DateName', 'width': 100 }
							]
						, viewrecords: true
						, rownumbers: true
                        , beforeSelectRow: function (rowid, e) {
                            var sessionVarName = "WHDeclaration_WHCalendarList";
                            var retVal = jQuery.ajax
                            (
                                {
                                    url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=ShowAllCheckOrUncheck&SessionVarName=' + sessionVarName,
                                    async: false
                                }
                            ).responseText
                            if (retVal == "True") {
                                $("#cphBody_cphInfbody_chkCalendar").attr('checked', false);
                            }
                            else {
                                $("#cphBody_cphInfbody_chkCalendar").attr('checked', true);
                            }
                        }
						, scrollrows: true
						, pager: jQuery('#grdWHCalendar_pager')
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
						, rowNum: 5
						, rowList: [10, 20, 30]
						, caption: 'Days'
						, autowidth: true
						, height: '90'
						, viewsortcols: [false, 'vertical', true]
                        , gridComplete: addCheckBox_grdWHCalendar
					}
				)
				.navGrid
				(
					'#grdWHCalendar_pager',
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
function addCheckBox_grdWHCalendar() {

    var SessionVarName = 'WHDeclaration_WHCalendarList';
    var ColumnName = 'IsChecked';

    var ids = jQuery("#grdWHCalendar").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdWHCalendar").jqGrid('getRowData', cid);
        var chk;
        if (data.IsChecked == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#grdWHCalendar").jqGrid('setRowData', ids[i], { IsChecked: chk });
    }
};

