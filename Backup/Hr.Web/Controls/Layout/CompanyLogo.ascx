<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompanyLogo.ascx.cs"
    Inherits="Hr.Web.Controls.Layout.CompanyLogo" %>
<script type="text/javascript">
    var davesitems = new Array();
    var ini = 0; var st = 0; var x = 0;var i = 0;
    $(document).ready(function () {
        var lgth = 0;
                var retVal = jQuery.ajax
                    (
                        {
                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=LatestNews',
                            async: false
                        }
                    ).responseText

                if (retVal == "")
                    return;
                else {
                    davesitems = new items(retVal);
                }
        newsclicker();
    });

    function items(retVal) {
        var test = retVal.split(",");
        lgth = test.length;
        for (i = 0; i < test.length; i++) {
            this[i] = test[i]; 
            }
        }
    function newsclicker() {
        $("#ctrlHeader_ctrlCompanyLogo_Label1").text(davesitems[ini]);
        if (st++ == x) {
            //Adjust timer for delay between messages
            st = 0; setTimeout("newsclicker()", 1000); ini++;
            if (ini == lgth) ini = 0; x = davesitems[ini].length;
        } else
        //adjust timer for "clicking speed" eg letter,letter,letter....
            setTimeout("newsclicker()", 100);
    }
</script>
<div style="float: left">
    <div style="float: left">
        <h3>
            <asp:HyperLink ID="hlLogoTxt" NavigateUrl="~/Home.aspx" runat="server" Text="ZAMAN ENTERPRISE" /></h3>
    </div>
    <div style="float: left; color: #8A6741; margin-left: 15px">
        <h3>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h3>
    </div>
</div>
