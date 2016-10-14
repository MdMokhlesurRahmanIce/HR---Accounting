<%@ Control Language="C#"  AutoEventWireup="true" CodeBehind="EmployeeFamilyInfo.ascx.cs"
    Inherits="Hr.Web.Controls.EmployeeFamilyInfo" %>
<script src="<%= ResolveUrl("~/GridScripts/HRM_EmpFamDet.js" ) %>" type="text/javascript"></script>
<asp:HiddenField ID="hfEmpFamKey" Value="0" runat="server" />

<div style="width: 50%; float: left">
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Father's Name</a>
        </div>
        <div class="div80Px">
            <asp:TextBox ID="txtFathersName" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                            <%--<span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtFathersName"
                    runat="server" ForeColor="Red" ErrorMessage="Father name is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>--%>

        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Occupation</a>
        </div>
        <div class="div182Px">
            <asp:DropDownList ID="ddlFOccupation" runat="server" CssClass="drpwidth180px">
            </asp:DropDownList>
        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Date Of Birth</a>
        </div>
        <div class="div80Px">
            <asp:TextBox ID="txtFDateOfBirth" runat="server" CssClass="txtwidth178px date-picker" MaxLength="100"></asp:TextBox>
        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Mother's Name</a>
        </div>
        <div class="div80Px">
            <asp:TextBox ID="txtMothersName" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                            <%--<span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtMothersName"
                    runat="server" ForeColor="Red" ErrorMessage="Mother name is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>--%>

        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Occupation</a>
        </div>
        <div class="div182Px">
            <asp:DropDownList ID="ddlMOccupation" runat="server" CssClass="drpwidth180px">
            </asp:DropDownList>
        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Date Of Birth</a>
        </div>
        <div class="div80Px">
            <asp:TextBox ID="txtMDateOfBirth" runat="server" CssClass="txtwidth178px date-picker" MaxLength="100"></asp:TextBox>
        </div>
    </div>
</div>
<div style="width: 50%; float: left">
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Marital Status</a>
        </div>
        <div class="div182Px">
            <asp:DropDownList ID="ddlMeritalStatus" runat="server" CssClass="drpwidth180px">
            </asp:DropDownList>
       <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlMeritalStatus"
                    runat="server" ForeColor="Red" ErrorMessage="Merital Status is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Spouse Name</a>
        </div>
        <div class="div80Px">
            <asp:TextBox ID="txtSpouseName" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Occupation</a>
        </div>
        <div class="div182Px">
            <asp:DropDownList ID="ddlOccupation" runat="server" CssClass="drpwidth180px">
            </asp:DropDownList>
        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Date Of Birth</a>
        </div>
        <div class="div80Px">
            <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="txtwidth178px date-picker" MaxLength="100"></asp:TextBox>
        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Father In Law's Name</a>
        </div>
        <div class="div80Px">
            <asp:TextBox ID="txtFatherInLawsName" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Occupation</a>
        </div>
        <div class="div182Px">
            <asp:DropDownList ID="ddlFILOccupation" runat="server" CssClass="drpwidth180px">
            </asp:DropDownList>
        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Mother In Law's Name</a>
        </div>
        <div class="div80Px">
            <asp:TextBox ID="txtMotherInLowsName" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Occupation</a>
        </div>
        <div class="div182Px">
            <asp:DropDownList ID="ddlMILOccupation" runat="server" CssClass="drpwidth180px">
            </asp:DropDownList>
        </div>
    </div>
</div>
<div style="">
    <asp:Label ID="Label1" style="width:17.3%;" CssClass="divlblwidth100px bglbl" Text="Remark" runat="server">    
    </asp:Label>
    <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Columns="111" Rows="5" />
</div>
<div >
    <fieldset class="fieldset-panel">
        <legend class="fieldset-legend">Family details</legend>
        <div>
        <table id="grdEmpFamDet">
        </table>
        <div id="grdEmpFamDet_pager"></div>
        </div>
    </fieldset>
</div>

<%--<div >
    <fieldset class="fieldset-panel">
        <legend class="fieldset-legend">Brother & Sister Info</legend>
    </fieldset>
</div>--%>