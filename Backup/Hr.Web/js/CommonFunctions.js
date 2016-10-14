var modalWindow;
var rootPath;

function ShowReportViewer() {
    window.open(rootPath + 'ReportPrint.aspx');
}

function doPostBack(findFor) {
    __doPostBack(findFor);
}

function GetDropDownSource(QString) {
    var retSourceString = jQuery.ajax
    	(
    	    {
    	        url: rootPath + 'GridHelperClasses/DropDownSource.ashx?' + QString,
    	        async: false
    	    }
        ).responseText;

    return retSourceString;
}

//------ Grid Cell Check Update ------//
function afterCellCheckUpdate(vid, curCheckbox, SessionVarName, ColumnName) {
    var QString = 'SessionVarName=' + SessionVarName + '&editbyforce=true&jqGridID="true"&' + ColumnName + '=' + curCheckbox.checked + '&id=' + vid
    jQuery.ajax
    (
        {
            url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?' + QString,
            async: false
        }
    );

    if (SessionVarName == "EmployeeAttendace_AttList") {
        var retVal = jQuery.ajax
                                (
                                   {
                                       url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=IsDefaultEmpAtt&ID=' + vid,
                                       async: false
                                   }
                                 ).responseText;
        $("#grdEmpAttProcess").trigger("reloadGrid");
    }
};

//------ Clearing session ------//
var g_isPostBack = false;
function fnOnbeforeunload() {
    if (g_isPostBack == true)
        return;
    else fnOnunload();
}

function fnOnunload() {
    var sPath = window.location.pathname;
    var url = sPath + '?_isPostBack=yes';
    if (g_isPostBack == true)
        return;
    else {
        clearSessionAjaxCall(url);
    }
}
function doUnload() {
    var sPath = window.location.pathname;
    var url = sPath + '?_clearSession=no';
    if (navigator.userAgent.toLowerCase().indexOf("firefox") > 0) {
        var winWidth = document.body.clientWidth;
        var winHeight = document.body.clientHeight;
        if ((winWidth <= 0) || (winHeight <= 0) || (winWidth <= -80)) {
            url = sPath + '?_clearSession=yes';
            clearSessionAjaxCall(url);
        }
    }
    if (navigator.appName == "Microsoft Internet Explorer") {
        if ((window.event.clientX < 0) || (window.event.clientY < 0) || (window.event.clientX < -80)) {
            url = sPath + '?_clearSession=yes';
            clearSessionAjaxCall(url);
        }
    }
}

function clearSessionAjaxCall(webUrl) {
    var xmlHttpObject = null;
    try {
        // Firefox, Opera 8.0+, Safari...
        xmlHttpObject = new XMLHttpRequest();
    }
    catch (ex) {
        // Internet Explorer...
        try {
            xmlHttpObject = new ActiveXObject('Msxml2.XMLHTTP');
        }
        catch (ex) {
            xmlHttpObject = new ActiveXObject('Microsoft.XMLHTTP');
        }
    }

    if (xmlHttpObject == null) {
        window.alert('Clearing session:\\nAJAX is not available in this browser');
        return;
    }

    xmlHttpObject.open("GET", webUrl, false);
    xmlHttpObject.send();
}
//------ End of Clearing session------//

//  call this function to Javascript program to wait
//  param: milliseconds
function delay(millis) {
    var date = new Date();
    var curDate = null;

    do { curDate = new Date(); }
    while (curDate - date < millis);
}

function employeeIdKeyup(event, _empCode) {
    if (event.keyCode == 13 && event.which == 13)
        if (_empCode == '') return;
        else {
            retval = jQuery.ajax
                        (
                            {
                                url: rootPath + "GridHelperClasses/SearchGridHandler.ashx?SearchMode=_SearchByEmpCode&MultiSelect=" + false + "&SelectedVids=" + 0 + "&empCode=" + _empCode,
                                async: false
                            }
                        ).responseText;
            if (retval == 0) {
                ShowMessageBox("HR", "No employee found with this Employee ID.");
                return false;
            }
            else
                __doPostBack("SearchEmployee");
        }
}

//Message
function showServerMsg(className) {
    $('.message-box').children().removeClass();
    $('.message-box').children().addClass(className);

    if ($('.ico-text').parent().parent().attr('class') == 'success') {
        $('.message-box').show();
        $('.ico-text').removeClass('ico-alert-error');
        $('.ico-text').addClass('ico-alert-success');
        setTimeout("autoHide()", 2000);
    }
    if ($('.ico-text').parent().parent().attr('class') == 'error') {
        $('.message-box').show();
        $('.ico-text').removeClass('ico-alert-success');
        $('.ico-text').addClass('ico-alert-error');
    }
    $('.ico-alert-error').click(function () {
        $('.message-box').hide();
    })
    $('.ico-alert-success').click(function () {
        $('.message-box').hide();
    })
}
function autoHide() {
    $('.message-box').hide();
}
function CheckValidity() {
    Page_ClientValidate();
    if (!Page_IsValid) {
        showServerMsg('error');
        $('#lblMsg').html($('.validation-summary').html());
        $('.validation-summary').empty();
        $('.validation-summary').hide();
        setTimeout("$('.validation-summary').hide()", 1);
    }
}
//End Message


//Number Entry

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}
//End