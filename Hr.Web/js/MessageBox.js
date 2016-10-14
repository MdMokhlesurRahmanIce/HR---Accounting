function ShowMessageBox(Title, Message) {
    document.getElementById('divMessageDialog').innerHTML = "<p> <span class='ui-icon ui-icon-alert' style='float: left; margin: 0 7px 50px 0;'> </span>" + Message + " </p> ";
    var divMessage = $("#divMessageDialog");
    divMessage.dialog('open');
    $.fx.speeds._default = 1000;
    divMessage.dialog
    (
        {
            title: Title,
            closeOnEscape: false,
            modal: true,
            hide: "explode",
            buttons:
            {
                Ok: function () {
                    $(this).dialog('close');
                }
            }
        }
    )
};

function ShowConfirmBox(Title, Message, OkButtonFunName, CancelButtonFunName) {
    document.getElementById('divMessageDialog').innerHTML = "<p> <span class='ui-icon ui-icon-alert' style='float: left; margin: 0 7px 50px 0;'> </span>" + Message + " </p> ";
    var divMessage = $("#divMessageDialog");
    $.fx.speeds._default = 0;
    divMessage.dialog
    (
        {
            title: Title,
            hide: "",
            closeOnEscape: true,
            modal: true,
            buttons:
            {
                Cancel: function () {
                    $(this).dialog('close');
                    window[CancelButtonFunName]();
                },
                Ok: function () {
                    $(this).dialog('close');
                    window[OkButtonFunName]();
                }
            }
        }
    )
};