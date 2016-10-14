<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCOA.ascx.cs" Inherits="Hr.Web.Controls.ucCOA" %>
<div>
    <div style="float: left; width: 40%; padding-bottom: 10px; min-height: 300px;">
        <fieldset class="fieldset-panel" style="min-height: 200px;">
            <legend class="fieldset-legend">Account Heads</legend>
            <div style="overflow: auto; max-height: 400px;">
                <asp:TreeView ID="tv" runat="server" OnSelectedNodeChanged="tv_SelectedNodeChanged">
                </asp:TreeView>
            </div>
        </fieldset>
    </div>
    <div class="" style="float: left; width: 52%; padding-bottom: 10px; min-height: 300px;">
        <fieldset class="fieldset-panel" style="min-height: 200px;">
            <legend class="fieldset-legend">Manage Account Head</legend>
            <div>
                <div style="width: 100%; float: left">
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Account Level</a>
                        </div>
                        <div class="div182Px">
                            <asp:TextBox ID="txtAcLevel" runat="server" CssClass="txtwidth178px accountLevel readonly"
                                Style="width: 50px;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Account Code</a>
                        </div>
                        <div class="div182Px">
                            <asp:TextBox ID="txtAcCode" runat="server" CssClass="txtwidth178px accountCode readonly"
                                Style="width: 200px;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Account Head</a>
                        </div>
                        <div class="div182Px">
                            <asp:TextBox ID="txtAhead" runat="server" CssClass="txtwidth178px accountHead" Style="width: 200px;"></asp:TextBox>
                            <asp:Button ID="btnUpdate" runat="server" CssClass="button" Style="margin-top: 0px;
                                height: 20px; padding: 0px" Text="Update" ValidationGroup="save" OnClick="btnUpdate_Click" />
                            <asp:Button ID="btnDelete" runat="server" CssClass="button" Style="margin-top: 0px;
                                height: 20px; padding: 0px" Text="Delete" ValidationGroup="save" OnClick="btnDelete_Click" />
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Child Head</a>
                        </div>
                        <div class="div182Px">
                            <asp:TextBox ID="txtCHead" runat="server" CssClass="txtwidth178px accountHead" Style="width: 200px;"></asp:TextBox>
                            <asp:Button ID="btnCreate" runat="server" CssClass="button" Style="margin-top: 0px;
                                height: 20px; padding: 0px" Text="Create" ValidationGroup="save" OnClick="btnCreate_Click" />
                        </div>
                    </div>
                    <div class="lblAndTxtStyle" style="margin-left: 36%; width: 20%; float: left">
                        <asp:CheckBox ID="chkActive" runat="server" CssClass="cbStyle" />
                        <asp:Label ID="Label9" runat="server" CssClass="lblStyle" Style="margin-top: 3px">Active</asp:Label>
                    </div>
                    <div class="lblAndTxtStyle" style="margin-left: 1%; width: 20%; float: left">
                        <asp:CheckBox ID="chkIsSubsidiary" runat="server" CssClass="cbStyle" />
                        <asp:Label ID="Label1" runat="server" CssClass="lblStyle" Style="margin-top: 3px">Is Subsidiary</asp:Label>
                    </div>
                </div>
            </div>
        </fieldset>
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $(".readonly").attr("readonly", true);
        $(".readonly").css("background-color", "#EEEEEE");
    });
</script>
