<%@ Page Title="House keeping" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="Configuration.aspx.cs" Inherits="Hr.Web.UI.Setup.Configuration" EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src='<%= ResolveUrl("~/GridScripts/ConfigurationGrid.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var QString = 'SessionVarName=Settings_AllSettingsList&acField=SettingsName';
            var retString = jQuery.ajax
            (
                {
                    url: rootPath + '/GridHelperClasses/DropDownSource.ashx?' + QString,
                    async: false
                }
            ).responseText;

            var arrayStr = new Array();
            arrayStr = retString.split(";");
            arrayStr = arrayStr.sort();


        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="System Configuration"></asp:Label>
        </div>
        <div class="form-details">
            <div class="lblAndTxtStyle" style="width: 300px; float: left">
                <div class="divlblwidth100px bglbl">
                    <a>Settings Name</a>
                </div>
                <div class="div80Px">
                    <asp:DropDownList ID="ddlSettingsName" Font-Size="12px" runat="server" CssClass="drpwidth180px txtWidth"
                        OnSelectedIndexChanged="ddlSettingsName_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div>
            <div style="padding-left: 25px; float: left; width: 90%;">
                <table id="grdSettings">
                </table>
            </div>
            <div id="grdSettings_pager">
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save"
                    OnClick="btnSave_Click" />
            </div>
        </div>
        <br />
    </div>
</asp:Content>
