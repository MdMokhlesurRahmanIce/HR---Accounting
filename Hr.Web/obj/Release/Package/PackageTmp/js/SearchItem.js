function LoadSearchGrid(Title, EventTarget, HideColumns, IsMultiSelect, SelectedVids, Width, MustSelectedVids) {
    var RowNum = 15;
    if (IsMultiSelect == undefined) IsMultiSelect = false;
    if (IsMultiSelect) RowNum = 100;
    if (Width == undefined)
        Width = 950;
    jQuery.ajax(
    {
        url: rootPath + 'GridHelperClasses/SearchGridHandler.ashx?SearchMode=Load&HideColumns=' + HideColumns,
        async: false,
        success: function (result) {
            var temp = result.split("|");
            var colNames = temp[0].split(",");
            var colModelString = temp[1].split("@");
            var colModel = Array();
            for (var i = 0; i < colModelString.length; i++) {
                colModel[i] = eval("(" + colModelString[i] + ")");
            }
            jQuery("#grdSearchGrid").jqGrid
            (
                {
                    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdSearchGrid&SessionVarName=ctl00_grdSearchGrid',
                    datatype: 'json',
                    page: 1,
                    colNames: colNames,
                    colModel: colModel,
                    pager: jQuery('#grdSearchGrid_pager'),
                    gridComplete: function () {
                        var vids;
                        $('.jqgrow').click(function (event) {
                            var id = "jqg_" + this.id;
                            if (event.target.className.indexOf("cbox") >= 0) {
                                if (document.getElementById(id).checked) {
                                    SelectedVids = SelectedVids + this.id + ',';
                                }
                                else {
                                    if (MustSelectedVids.match(this.id) == null) {
                                        SelectedVids = SelectedVids.replace(this.id + ',', '');
                                    }
                                    else {
                                        alert('Already used');
                                        return false;
                                    }
                                }
                            }
                            else {
                                if (document.getElementById(id).checked) {
                                    if (MustSelectedVids.match(this.id) == null) {
                                        SelectedVids = SelectedVids.replace(this.id + ',', '');
                                    }
                                    else {
                                        alert('Already used');
                                        return false;
                                    }
                                }
                                else {
                                    SelectedVids = SelectedVids + this.id + ',';
                                }
                            }
                        });

                        if (SelectedVids == undefined) SelectedVids = '';
                        var grid = jQuery("#grdSearchGrid");
                        vids = SelectedVids.split(",");
                        for (var i = 0; i < vids.length; i++) {
                            grid.setSelection(vids[i], true);
                        }
                    },
                    rowNum: RowNum,
                    rowList: [RowNum, RowNum * 2, RowNum * 3],
                    viewrecords: true,
                    sortable: true,
                    height: '340',
                    width: Width - 20,
                    multiselect: IsMultiSelect,
                    jsonReader:
		            {
		                root: 'rows',
		                page: 'currentpage',
		                total: 'totalpages',
		                records: 'pagerecords',
		                repeatitems: false
		            }
                    , ondblClickRow: function (rowid) {
                        $(".ui-button-text").click();
                    }
                }
            )
            .navGrid
            (
	            '#grdSearchGrid_pager',
	            {
	                'edit': false, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
	            }, {}, {}, {}, { closeOnEscape: true, closeAfterSearch: true, multipleSearch: true }
            );
            jQuery("#grdSearchGrid").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false });
        },
        error: function (x, e) {
            alert(x.readyState + " " + x.status + " " + e.msg);
        }
    });

    //Show Grid            
    ShowSearchGrid(Title, EventTarget, IsMultiSelect, Width);
};

datePick = function (elem) {
    jQuery(elem).datepicker();
};

function ShowSearchGrid(Title, EventTarget, IsMultiSelect, Width) {
    var divSearchGrid = $("#divSearchDialog");
    divSearchGrid.dialog('open');
    divSearchGrid.dialog
    (
        {
            title: Title,
            closeOnEscape: false,
            modal: true,
            //height: 500,
            width: Width,
            buttons:
            {
                Ok: function () {
                    var selectedVids = '';
                    if (IsMultiSelect) {
                        selectedVids = jQuery("#grdSearchGrid").jqGrid('getGridParam', 'selarrrow');
                    }
                    else {
                        selectedVids = jQuery("#grdSearchGrid").jqGrid('getGridParam', 'selrow');
                    }
                    //
                    jQuery.ajax
                    (
                        {
                            url: rootPath + "GridHelperClasses/SearchGridHandler.ashx?SearchMode=Retrieve&MultiSelect=" + IsMultiSelect + "&SelectedVids=" + selectedVids,
                            async: false
                        }
                    );
                    //
                    $(this).dialog('close');
                    if (IsMultiSelect) {
                        __doPostBack(EventTarget);
                    }
                    else if (selectedVids.length != 0) {
                        __doPostBack(EventTarget);
                    }
                }
            }
        }
    )
};

//==============Popup=====================JQ
function searchdialog(title) {
    $(".menu_open").hide();
    var horizontalPadding = 30;
    var verticalPadding = 30;
    $('<iframe id="externalSite" class="externalSite" src="../Search.aspx" />').dialog({
        title: title,
        autoOpen: true,
        width: 'auto',
        //position: ['50', '50'],
        position: [50, 50],
        modal: true,
        resizable: false,
        autoResize: false,
        closeOnEscape: false
    }).width(1000 - horizontalPadding).height(500 - verticalPadding);
    return false;
};

//==============Popup=====================Normal
function OpenPopupDialog(ExportOrderID, UOM) {

    var w = 200; /* popup window width*/
    var h = 200; /* popup window height*/
    var l = (screen.width - w) / 2; /*this centers horizontally*/
    var t = (screen.height - h) / 2; /*this centers vertically*/

    var winSettings = "left=" + l + ",top=" + t + ",dialogWidth=" + w + ",dialogHeight=" + h + ",scrollbars=yes, toolbar=0, status=0";
    var winArgs = new Array(ExportOrderID);
    winArgs = window.showModalDialog(rootPath + '/Merchandising/PopupShipDates.aspx?ExportOrderID=' + ExportOrderID + '&UOM= ' + UOM, winArgs, winSettings);
};