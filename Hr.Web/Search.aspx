<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="ST.Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        body
        {
            margin: 0;
        }
        .style1
        {
            width: 100%;
            height: 241px;
        }
        .style2
        {
        }
        .style3
        {
            width: 17px;
        }
        .style4
        {
            width: 120px;
        }
        td
        {
            font-size: 11px;
            font-family: 'Microsoft Sans Serif' , Sans-Serif, Arial;
        }
    </style>

    <script type="text/javascript">
        //        function closedialog()
        //        {
        //            parent.$('iframe').dialog('close');
        //            parent.location='default.aspx?fr=1';
        //        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td class="style2">
                    Find BY
                </td>
                <td class="style3" colspan="2">
                    &nbsp;
                </td>
                <td class="style4">
                    &nbsp;
                </td>
                <td rowspan="4">
                    &nbsp;<br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:DropDownList ID="cboFindBy" runat="server" Width="300px" AutoPostBack="True"
                        OnSelectedIndexChanged="cboFindBy_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="cboDemands" runat="server" Width="150px" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtSearchText" runat="server" AutoPostBack="True" OnTextChanged="txtSearchText_TextChanged"></asp:TextBox>
                </td>
                <td class="style3" colspan="2">
                    &nbsp;
                </td>
                <td class="style4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="4">
                    <asp:GridView ID="grdFind" runat="server" OnRowDataBound="grdFind_RowDataBound" OnSelectedIndexChanged="grdFind_SelectedIndexChanged"
                        CellPadding="2" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"
                        Width="100%" AllowPaging="True" OnPageIndexChanging="grdFind_PageIndexChanging"
                        PageSize="15">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" VerticalAlign="Middle" />
                        <HeaderStyle BackColor="#B5C7DE" Font-Bold="True" ForeColor="#F7F7F7" HorizontalAlign="Left"
                            VerticalAlign="Middle" />
                        <AlternatingRowStyle BackColor="#F7F7F7" HorizontalAlign="Left" VerticalAlign="Middle" />
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Middle" Height="5px" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="True" Text="Select All"
                        OnCheckedChanged="chkSelectAll_CheckedChanged" />
                </td>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblTotalRow" runat="server" Text="Total Row(s) : "></asp:Label>
                    <br />
                    <asp:Label ID="lblFilteredRow" runat="server" Text="Filtered Row(s) : "></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnSelect" runat="server" Text="Select" OnClick="btnSelect_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
