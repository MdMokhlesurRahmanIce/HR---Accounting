<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeAddressInformation.ascx.cs"
    Inherits="Hr.Web.Controls.EmployeeAddressInformation" %>
<asp:HiddenField ID="hfEmpAddrKey" Value="0" runat="server" />
<script src="<%= ResolveUrl("~/gridscripts/EmployeeBasicInfo_EmployeeEmergencyInfo.js") %> "
    type="text/javascript"></script>
<div style="float: left; width: 100%">
    <div id="lavAddress" style="float: left; width: 99%">
        <a style="font-size: large">Address Information</a>
    </div>
    <div id="divAddressInfo" style="float: left; width: 99%">
        <div style="float: left; width: 55%">
            <div id="lavPresent" style="text-align: left; width: 99%; margin-left: 5px">
                <a>Present Address</a>
            </div>
            <div id="divPreInfo" style="width: 99%; float: left; margin-left: 5px">
                <div class="lblAndTxtStyle" style="width: 100%; float: left;">
                    <div class="divlblwidth23per bglbl" style="float: left">
                        <a>Care Of</a>
                    </div>
                    <div class="div80Px" style="width: 59%; float: left;">
                        <asp:TextBox ID="txtPreCO" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth23per bglbl">
                        <a>Vill./ HoldingNo</a>
                    </div>
                    <div class="div80Px" style="width: 59%; float: left;">
                        <asp:TextBox ID="txtVillage" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth23per bglbl">
                        <a>Post Office</a>
                    </div>
                    <div class="div80Px" style="width: 59%; float: left;">
                        <asp:TextBox ID="txtPostOffice" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth23per bglbl">
                        <a>Postal Code</a>
                    </div>
                    <div class="div80Px" style="width: 59%; float: left;">
                        <asp:TextBox ID="txtPostalCode" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth23per bglbl">
                        <a>Police Station</a>
                    </div>
                    <div class="div80Px" style="width: 59%; float: left;">
                        <asp:TextBox ID="txtPS" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth23per bglbl">
                        <a>Additional</a>
                    </div>
                    <div class="div80Px" style="width: 59%; float: left;">
                        <asp:TextBox ID="txtAdditional" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth23per">
                    </div>
                    <div class="div80Px" style="width: 29%; float: left;">
                        <asp:TextBox ID="txtAdditionalLo" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                    <div class="div80Px" style="width: 29%; float: left;">
                        <asp:TextBox ID="txtPSLo" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth23per">
                    </div>
                    <div class="div80Px" style="width: 29%; float: left;">
                        <asp:TextBox ID="txtPostalCodeLo" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                    <div class="div80Px" style="width: 29%; float: left;">
                        <asp:TextBox ID="txtPostOfficeLo" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth23per">
                    </div>
                    <div class="div80Px" style="width: 29%; float: left;">
                        <asp:TextBox ID="txtVillageLo" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                    <div class="div80Px" style="width: 29%; float: left;">
                        <asp:TextBox ID="txtPreCOL" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div style="float: left; width: 45%">
            <div id="LavParmanentAddress" style="text-align: left; width: 99%;">
                <div style="float: left; width: 50%;">
                    <a>Parmanent Address</a>
                </div>
                <div style="float: left; width: 49%;">
                    <asp:CheckBox ID="chkSameAsPresent" runat="server" Text="Same As Present" CssClass="cbStyle" />
                </div>
            </div>
            <div id="divParAddress" style="float: left; width: 100%;">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl" style="width: 80px; float: left">
                        <a>Care Of</a>
                    </div>
                    <div class="div80Px" style="width: 59%; float: left;">
                        <asp:TextBox ID="txtPerCO" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                   
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl" style="width: 80px">
                        <a>Vill./ HoldingNo</a>
                    </div>
                    <div class="div80Px" style="width: 59%; float: left;">
                        <asp:TextBox ID="txtPerVill" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                   
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl" style="width: 80px">
                        <a>Post Office</a>
                    </div>
                    <div class="div80Px" style="width: 59%; float: left;">
                        <asp:TextBox ID="txtPerPostOffice" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl" style="width: 80px">
                        <a>Postal Code</a>
                    </div>
                    <div class="div80Px" style="width: 59%; float: left;">
                        <asp:TextBox ID="txtPerPC" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl" style="width: 80px">
                        <a>Police Station</a>
                    </div>
                    <div class="div80Px" style="width: 59%; float: left;">
                        <asp:TextBox ID="txtPerPS" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl" style="width: 80px">
                        <a>Additional</a>
                    </div>
                    <div class="div80Px" style="width: 59%; float: left;">
                        <asp:TextBox ID="txtPerAdditional" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px" style="width: 80px">
                    </div>
                    <div class="div80Px" style="width: 29%; float: left;">
                        <asp:TextBox ID="txtPerAdditionalLo" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                    <div class="div80Px" style="width: 29%; float: left;">
                        <asp:TextBox ID="txtPerPSLo" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px" style="width: 80px">
                    </div>
                    <div class="div80Px" style="width: 29%; float: left;">
                        <asp:TextBox ID="txtPerPCLo" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                    <div class="div80Px" style="width: 29%; float: left;">
                        <asp:TextBox ID="txtPerPostOfficeLO" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px" style="width: 80px">
                    </div>
                     <div class="div80Px" style="width: 29%; float: left;">
                        <asp:TextBox ID="txtPerVillLo" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                     <div class="div80Px" style="width: 29%; float: left;">
                        <asp:TextBox ID="txtPerCOLo" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div style="float: left; width: 100%">
            <br />
            <div style="width: 55%; float: left;">
                <div style="width: 100%; float: left;">
                    <div class="lblAndTxtStyle" style="width: 55%; float: left;">
                        <div class="divlblwidth23per bglbl" style="width: 43%">
                            <a>District</a>
                        </div>
                        <div class="div80Px" style="width: 53%; float: left;">
                            <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="drpwidth180px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle" style="width: 45%; float: left;">
                        <div class="divlblwidth23per bglbl" style="width: 80px">
                            <a>State</a>
                        </div>
                        <div class="div80Px" style="width: 50%; float: left;">
                            <asp:DropDownList ID="ddlState" Font-Size="12px" runat="server" CssClass="txtwidth178px txtWidth">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div style="width: 100%; float: left;">
                    <div class="lblAndTxtStyle" style="width: 55%; float: left;">
                        <div class="divlblwidth23per bglbl" style="width: 43%">
                            <a>City</a>
                        </div>
                        <div class="div80Px" style="width: 53%; float: left;">
                            <asp:DropDownList ID="ddlCity" runat="server" Font-Size="12px" CssClass="txtwidth178px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle" style="width: 45%; float: left;">
                        <div class="divlblwidth23per bglbl" style="width: 80px">
                            <a>Country</a>
                        </div>
                        <div class="div80Px" style="width: 50%; float: left;">
                            <asp:DropDownList ID="ddlCountry" Font-Size="12px" runat="server" CssClass="txtwidth178px">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div style="width: 44.5%; float: left;">
                <div style="width: 100%; float: left;">
                    <div class="lblAndTxtStyle" style="width: 50%; float: left;">
                        <div class="divlblwidth23per bglbl" style="width: 45%">
                            <a>District</a>
                        </div>
                        <div class="div80Px" style="width: 50%; float: left;">
                            <asp:DropDownList ID="ddlPerDistrict" runat="server" Font-Size="12px" CssClass="txtwidth178px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle" style="width: 50%; float: left;">
                        <div class="divlblwidth23per bglbl" style="width: 40%">
                            <a>State</a>
                        </div>
                        <div class="div80Px" style="width: 50%; float: left;">
                            <asp:DropDownList ID="ddlPerState" runat="server" Font-Size="12px" CssClass="txtwidth178px">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div style="width: 100%; float: left;">
                    <div class="lblAndTxtStyle" style="width: 50%; float: left;">
                        <div class="divlblwidth23per bglbl" style="width: 45%">
                            <a>City</a>
                        </div>
                        <div class="div80Px" style="width: 50%; float: left;">
                            <asp:DropDownList ID="ddlPerCity" runat="server" Font-Size="12px" CssClass="txtwidth178px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle" style="width: 50%; float: left;">
                        <div class="divlblwidth23per bglbl" style="width: 40%">
                            <a>Country</a>
                        </div>
                        <div class="div80Px" style="width: 50%; float: left;">
                            <asp:DropDownList ID="ddlPerCountry" runat="server" Font-Size="12px" CssClass="txtwidth178px">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div style="float: left; width: 99%; height: auto">
        <div class="ui-jqgrid">
            <table id="grdGetEmployeeEmergencyInfo">
            </table>
        </div>
        <div id="grdEmployeeEmergencyInfo_pager">
        </div>
    </div>
</div>
<script type="text/javascript">
    $(function () {
        $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_chkSameAsPresent').click(function () {
            if ($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_chkSameAsPresent').is(':checked')) {
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerCO').val($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPreCO').val());
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerCOLo').val($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPreCOL').val());
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerVill').val($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtVillage').val());
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerVillLo').val($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtVillageLo').val());
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerPostOffice').val($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPostOffice').val());
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerPostOfficeLO').val($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPostOfficeLo').val());
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerPC').val($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPostalCode').val());
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerPCLo').val($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPostalCodeLo').val());
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerPS').val($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPS').val());
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerPSLo').val($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPSLo').val());
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerAdditional').val($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtAdditional').val());
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerAdditionalLo').val($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtAdditionalLo').val());
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_ddlPerDistrict').val($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_ddlDistrict').val());
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_ddlPerState').val($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_ddlState').val());
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_ddlPerCity').val($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_ddlCity').val());
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_ddlPerCountry').val($('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_ddlCountry').val());
            }
            else {
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerCO').val('');
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerCOLo').val('');
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerVill').val('');
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerVillLo').val('');
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerPostOffice').val('');
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerPostOfficeLO').val('');
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerPC').val('');
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerPCLo').val('');
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerPS').val('');
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerPSLo').val('');
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerAdditional').val('');
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_txtPerAdditionalLo').val('');
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_ddlPerDistrict').val('');
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_ddlPerState').val('');
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_ddlPerCity').val('');
                $('#cphBody_cphInfbody_ctrlEmployeeAddressInfo_ddlPerCountry').val('');
            }
        })
    })
</script>
