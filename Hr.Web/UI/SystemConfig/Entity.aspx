<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="Entity.aspx.cs" Inherits="Hr.Web.UI.SystemConfig.Entity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src='<%= ResolveUrl("~/GridScripts/SystemConfig_EntityList.js") %>' type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
   <div class="form-wrapper">
           <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="Field Manager"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 100%; height: auto; margin-top: 5px">
                <div>
                    <table id="grdEntityList">
                    </table>
                </div>
                <div id="grdEntityList_pager">
                </div>
            </div>
        </div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save" OnClick="btnSave_Click"/>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
