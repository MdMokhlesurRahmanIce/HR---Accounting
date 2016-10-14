<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadLeaveInfo.aspx.cs"
    Inherits="Hr.Web.UI.LeaveManagement.UploadLeaveInfo" Title="Lotus-12 :: Leave Transactions Upload" %>


<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="totalBody bgBody">
        <div class="mainBody">
            <div>
                <div>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="btnUpload" runat="server" Height="25px" Text="Upload" Width="92px"
                       OnClick="btnUpload_Click" />
                </div>
                <div class="lblAndTxtStyle" style="width: 100%; margin-left: -5px">
                    <div class="divlblwidth100px bglbl" style="width: 80px">
                        <a>Data Type</a>
                    </div>
                    <asp:DropDownList ID="ddlDataType" runat="server" Style="visibility: visible;" CssClass="drpwidth157px"
                            >
                        </asp:DropDownList>
                        
                    <div class="div80Px" style="width: 100%; float: left">
                        
                        <asp:Panel ID="Panel1" Height="500px" Width="90%" runat="server" ScrollBars="Both">
                        <asp:GridView ID="GridView1" runat="server" ></asp:GridView>
                            
                        </asp:Panel>
                    </div>
                </div>
                <div>
                    <br />
                    <div class="btnRight" style="float: left;">
                        <br />
                        <br />
                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Save" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
