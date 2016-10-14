if (Sys != undefined && jQuery != undefined) {
    Sys.WebForms.PageRequestManager.aspAjaxBegin = function (sender, args) { $(document).trigger("ajaxStart", sender, args); };
    Sys.WebForms.PageRequestManager.aspAjaxEnd = function (sender, args) { $(document).trigger("ajaxComplete", sender, args); };
    $(document).ready(function () {
        if (Sys != undefined) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (!prm.get_isInAsyncPostBack()) {
                prm.add_beginRequest(Sys.WebForms.PageRequestManager.aspAjaxBegin);
                prm.add_endRequest(Sys.WebForms.PageRequestManager.aspAjaxEnd);
            }
        }
    });
    $(document).unload(function () {
        if (Sys != undefined) {
            Sys.WebForms.PageRequestManager.getInstance().remove_beginRequest(Sys.WebForms.PageRequestManager.aspAjaxBegin);
            Sys.WebForms.PageRequestManager.getInstance().remove_endRequest(Sys.WebForms.PageRequestManager.aspAjaxEnd);
        }
    });
}