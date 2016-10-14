$(document).ready(function()
    {
        if ($.browser.mozilla)
        {
            try 
            {
                    var ControlName = 'ctl00_cphBody_rpViewer';
                    var innerScript = '<scr' + 'ipt type="text/javascript">document.getElementById("' + ControlName + '_print").Controller = new ReportViewerHoverButton("' + ControlName + '_print", false, "", "", "", "#ECE9D8", "#DDEEF7", "#99BBE2", "1px #ECE9D8 Solid", "1px #336699 Solid", "1px #336699 Solid");</scr' + 'ipt>';
                    var innerTbody = '<tbody><tr><td><a id="lnlPrint" ><img style="border-width: 0px; padding: 2px; height: 16px; width: 16px;" alt="Print" src="../images/Print.gif" title="Print" /></a></td></tr></tbody>';
                    var innerTable = '<table title="Print" onmouseout="this.Controller.OnNormal();" onmouseover="this.Controller.OnHover();" id="' + ControlName + '_print" style="border: 1px solid rgb(236, 233, 216); background-color: rgb(236, 233, 216); cursor: default;">' + innerScript + innerTbody + '</table>'
                    var outerScript = '<scr' + 'ipt type="text/javascript">document.getElementById("' + ControlName + '_print").Controller.OnNormal();</scr' + 'ipt>';
                    var outerDiv = '<div style="display: inline; font-size: 8pt; height: 30px;" class=" "><table cellspacing="0" cellpadding="0" style="display: inline;"><tbody><tr><td height="28px">' + innerTable + outerScript + '</td></tr></tbody></table></div>';

                    $("#" + ControlName + " > div > div").append(outerDiv);
                    $("#lnlPrint").click( function(){
                        OpenDialog();
                    });                   
                
            }
            catch (e) { alert(e); }
        }
        
        //printer page validation
        if ($('#ctl00_cphBody_rbAllPages').attr('checked') || $('#ctl00_cphBody_rbCurrentPage').attr('checked')) {
            $('#ctl00_cphBody_txtFromPage').attr('disabled', true);
            $('#ctl00_cphBody_txtToPage').attr('disabled', true);
        }
        
        $("#ctl00_cphBody_RadioButton1").click(function(){
          $('#ctl00_cphBody_txtFromPage').attr('disabled', false);
          $('#ctl00_cphBody_txtToPage').attr('disabled', false);
        });
        
        $("#ctl00_cphBody_rbAllPages").click(function(){
          $('#ctl00_cphBody_txtFromPage').attr('disabled', true);
           $('#ctl00_cphBody_txtToPage').attr('disabled', true);
        });
        
        $("#ctl00_cphBody_rbCurrentPage").click(function(){
          $('#ctl00_cphBody_txtFromPage').attr('disabled', true);
           $('#ctl00_cphBody_txtToPage').attr('disabled', true);
        });
    });
    
    function OpenDialog()
    {
        $('#dialog-modal').dialog(
            { 
                autoOpen: false, 
                bgiframe: true, 
                modal: true,
                title: "Printer Setup",
                height: 450,
                width: 325,
                zIndex: 10,
                buttons:
                    {
                        Cancel:function() 
                        {
                            $(this).dialog('close');
                        },
                        Ok: function() 
                        {
                            var e = document.getElementById("ctl00_cphBody_ddlPrinterName");
                            var printerName = e.options[e.selectedIndex].value;
                            var rbPortrait = document.getElementById('ctl00_cphBody_rbPortrait').checked;
                            var noofCopies = document.getElementById('ctl00_cphBody_txtNoofCopies').value;
                            var allPages = document.getElementById('ctl00_cphBody_rbAllPages').checked;
                            var currentPage = document.getElementById('ctl00_cphBody_rbCurrentPage').checked;
                            var fromPageSelected = document.getElementById('ctl00_cphBody_RadioButton1').checked;
                            var fromPage = document.getElementById('ctl00_cphBody_txtFromPage').value;
                            var toPage = document.getElementById('ctl00_cphBody_txtToPage').value;
                            var formatedString = printerName + ';' + noofCopies + ';' + rbPortrait + ';' + allPages + ';' + currentPage + ';' + fromPageSelected + ';' + fromPage + ';' + toPage;
                            
                            if(printerName=='')
                            {
                                alert('Select a printer');
                                return false;
                            }
                            else if(noofCopies =='')
                            {
                                alert('Specify no of copies');
                                document.getElementById('ctl00_cphBody_txtNoofCopies').focus();
                                return false;
                            }
                            else if(fromPageSelected)
                            {
                                if(fromPage=='')
                                {
                                    alert('Please specify From page value');  
                                    document.getElementById('ctl00_cphBody_txtFromPage').focus();
                                    return false;
                                }
                                if(toPage=='')
                                {
                                    alert('Please specify To page value');  
                                    document.getElementById('ctl00_cphBody_txtToPage').focus();
                                    return false;
                                }
                            }
                            
                            __doPostBack("postBackFromParent",formatedString);
                            $(this).dialog('close');
                        }
                    }
                 }
            
            );                         
        $('#dialog-modal').dialog('open');
    }