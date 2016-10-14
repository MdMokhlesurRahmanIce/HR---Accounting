<%@ Page Title="House keeping" Language="C#" MasterPageFile="~/site.master"
    AutoEventWireup="true" CodeBehind="LookupEnt.aspx.cs" Inherits="Hr.Web.UI.Setup.LookupEnt"
    EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/Gen_LookupEnt.js") %> " type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= ddlEntityType.ClientID %>").change(function (e) {
                var entityType = $("#<%= ddlEntityType.ClientID %>").val();
                var retVal = jQuery.ajax
                        	        (
                        	            {
                        	                url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=FilterByEntityType&EntityType=' + entityType,
                        	                async: false
                        	            }
                                    ).responseText;
                $("#grdLookupEnt").trigger("reloadGrid");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server" Text="System Configuration"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 40%">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Entity Type</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlEntityType" runat="server" CssClass="drpwidth180px">
                        </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlEntityType"
                    runat="server" ForeColor="Red" ErrorMessage="EntityType is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 100%; height: auto; margin-top: 5px">
                <div>
                    <table id="grdLookupEnt">
                    </table>
                </div>
                <div id="grdLookupEnt_pager">
                </div>
            </div>
        </div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="save"
                    OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
