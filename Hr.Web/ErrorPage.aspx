<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="ST.ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <div style="padding-top: 200px;">
            <h2>
                An Error Has Occurred !!</h2>
            <p>
                An unexpected error occurred on our website. The website administrator has been
                notified.</p>
            <ul>
                <li>
                    <asp:HyperLink ID="lnkHome" runat="server" NavigateUrl="~/Administration/Default.aspx">Return to the homepage</asp:HyperLink></li>
                <li><a href="javascript:window.close();">Close this window</a></li>
            </ul>
        </div>
    </center>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
