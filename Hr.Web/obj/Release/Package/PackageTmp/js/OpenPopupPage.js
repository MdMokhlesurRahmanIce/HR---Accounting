 var modal;
 
 var modalWindow = {
    parent:"body",
    windowId:null,
    content:null,
    width:null,
    height:null,  
    close:function()
    {
	    $(".modal-window").remove();
	    $(".modal-overlay").remove();
    },
    open:function()
    {
	    modal = "";
	    modal += "<div class=\"modal-overlay\"></div>";
	    modal += "<div id=\"" + this.windowId + "\" class=\"modal-window\" style=\"width:" + this.width + "px; height:" + this.height + "px; margin-top:-" + (this.height / 2) + "px; margin-left:-" + (this.width / 2) + "px;\">";
	    modal += this.content;
	    modal += "</div>";	

	    $(this.parent).append(modal);

	    //$(".modal-window").append("<a class=\"close-window\"></a>");
	    $(".close-window").click(function(){alert("class");  modalWindow.close();});
	    $(".modal-overlay").click(function(){modalWindow.close();});
	      
    }
    };
    function openMyModal(source)
    {
    modalWindow.windowId = "myModal";
    modalWindow.width = 855;
    modalWindow.height = 560;
    modalWindow.content = "<iframe width='850' height='550' frameborder='0' scrolling='no' allowtransparency='true' src='" + source + "'></iframe>";
    modalWindow.open();
    };
    function ClosePopUp()
    {
        parent.closePopup();
    }