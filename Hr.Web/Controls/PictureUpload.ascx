<%@ Control Language="C#"  AutoEventWireup="true" CodeBehind="PictureUpload.ascx.cs"
    Inherits="Hr.Web.Controls.PictureUpload" %>
<div>
    <fieldset id="garmentPicture" style="border-color: gray; border-width: 1px; margin-left: 15px; width: 90%; height:auto;">
        <legend>Picture</legend>
        <div style="text-align: center; vertical-align:middle;">
            <asp:Image ID="imgEmp" runat="server" Style="max-height: 120px; max-width: 81%;" />
        </div>
        <div>
            <asp:Label ID="lblPictureNumber" CssClass="lblStyle" Style="padding-left: 55px" runat="server"></asp:Label>
        </div>
    </fieldset>
    <div  style="margin-left: 15px;">
        <asp:FileUpload ID="btnPictureLoad" runat="server" CssClass="fileUpload" Width="135px" />
    </div>
</div>
