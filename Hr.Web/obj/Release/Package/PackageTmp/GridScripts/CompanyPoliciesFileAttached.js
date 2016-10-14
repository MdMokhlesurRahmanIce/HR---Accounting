jQuery(document).ready
(
	function () {
	    jQuery('#grdCompanyPoliciesFile').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdCompanyPoliciesFile&SessionVarName=CompanyPolicies_EmpFileList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdCompanyPoliciesFile&editMode=1&SessionVarName=CompanyPolicies_EmpFileList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'File Name', 'Download']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
						{ 'name': 'FileName', 'index': 'FileName', 'width': 400 },
                        { 'name': 'FilePath', 'index': 'FilePath', 'width': 78, formatter: downloadLink }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdCompanyPoliciesFile_pager')
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
				, caption: 'Attachment'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
			}
		)
		.navGrid
		(
			'#grdCompanyPoliciesFile_pager',
			{
			    'edit': false, 'add': false, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

function downloadLink(cellvalue, options, rowObject) {
    return '<a href="/filedownload.aspx?dp=' + cellvalue + '&fn=' + rowObject.FileName + '" target="_blank"> Download </a>';
}