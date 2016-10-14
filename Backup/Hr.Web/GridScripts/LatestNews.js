jQuery(document).ready
(
	function () {
	    jQuery('#grdLatestNews').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdLatestNews&SessionVarName=LatestNewsSetup_LatestNewsList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdLatestNews&editMode=1&SessionVarName=LatestNewsSetup_LatestNewsList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'News', 'Is Latest']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 20, 'index': 'VID' },
				        { 'name': 'NewsDetails', 'index': 'NewsDetails', 'width': 200, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { maxlength: "500"} },
				        { 'name': 'IsLatest', 'index': 'IsLatest', 'align': 'center', 'width': 10, editable: true, edittype:'checkbox', editoptions: { value:"True:False"},formatter: "checkbox" }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdLatestNews_pager')
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
				, caption: 'Latest News'
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
				                    //beforeSubmit: BeforeSubmit_Color,
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
				                    //beforeSubmit: BeforeSubmit_Color,
				                    bottominfo: "Fields marked with (*) are required"
				                }
                                , ondblClickRow: function (rowid) {
                                    $(".ui-icon-pencil").click();
                                }
			}
		)
		.navGrid
		(
			'#grdLatestNews_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdLatestNews').getGridParam('editDialogOptions')
   			, jQuery('#grdLatestNews').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

function BeforeSubmit_Color(postdata, formid) {
    var vid;

    if (postdata.grdColor_id == '_empty')
        vid = -1;
    else
        vid = postdata.grdColor_id;
    var CountryCode = postdata.CountryName;
    var retVal = jQuery.ajax
                    (
                        {
                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=DuplicateCountryCheck&CountryCode=' + CountryCode + '&VID=' + vid,
                            async: false
                        }
                    ).responseText;
    if (retVal == "True") {
        if (postdata.grdColor_id == '_empty')
            return [false, "Add Failed! Because same Color Code found.", ""]
        else
            return [false, "UpDate Failed! Because same Color Code found.", ""];
    }
    else {
        return [true, "", ""];
    }
}
