<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeGeneralInfo.ascx.cs"
    Inherits="Hr.Web.Controls.EmployeeGeneralInfo" %>
<%@ Register Src="PictureUpload.ascx" TagName="PictureUpload" TagPrefix="st" %>
<script src="<%= ResolveUrl("~/GridScripts/HRM_EmpFamDet.js" ) %>" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        try {
            $("input[id$='txtDateOfBirth'], .date-picker").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date(), maxDate: 0, dateFormat: 'mm/dd/yy', yearRange: '1930:2052' });
        }
        catch (e)
        { alert(e); }
    });

    function loadEmp_postback() {
        __doPostBack('Pback');
    }
        
</script>
<style type="text/css">
    .width
    {
        width: 59%;
    }
</style>
<asp:HiddenField ID="hfEmpKey" runat="server" Value="0" />
<div style="width: 30%; float: left;">
    <div style="margin-top: 10px; float: left;">
        <st:PictureUpload ID="ctrlPictureUpload" runat="server" />
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Emp Status</a>
        </div>
        <div class="div80Px">
            <asp:TextBox ID="txtEmpStatus" runat="server" Enabled="false"  CssClass="drpwidth180px" MaxLength="100"></asp:TextBox>
        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Nationality</a>
        </div>
        <div class="div182Px">
            <asp:DropDownList ID="ddlNationlity" runat="server" CssClass="drpwidth180px">
            </asp:DropDownList>
        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>National ID</a>
        </div>
        <div class="div80Px">
            <asp:TextBox ID="txtNationalID" runat="server" CssClass="drpwidth180px" MaxLength="100"></asp:TextBox>
        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div class="divlblwidth100px bglbl">
            <a>Gender</a>
        </div>
        <div class="div182Px">
            <asp:DropDownList ID="ddlGender" runat="server" CssClass="drpwidth180px">
            </asp:DropDownList>
        </div>
    </div>
    <div class="lblAndTxtStyle">
        <div style="float: left;">
            <asp:RadioButton GroupName="LocalAndExpatriate" ID="rdoLocal" runat="server" Checked="true" />
        </div>
        <div style="float: left; margin-top: 3px">
            <a>Local</a>
        </div>
        <div style="float: left;">
            <asp:RadioButton GroupName="LocalAndExpatriate" ID="rdoExpatriate" runat="server" />
        </div>
        <div style="float: left; margin-top: 3px">
            <a>Expatriate</a>
        </div>
    </div>
    <div id="divIdentification" style="width: 100%; float: left">
        <div class="lblAndTxtStyle" style="width: 100%; margin-left: 0px">
            <div class="divlblwidth100px bglbl" style="width: 80px">
                <a>Ref By</a>
            </div>
            <div class="div182Px">
                <asp:DropDownList ID="ddlRefBy" Font-Size="12px" runat="server" CssClass="drpwidth180px">
                </asp:DropDownList>
            </div>
        </div>
        <div class="lblAndTxtStyle" style="width: 100%; margin-left: 0px">
            <div class="divlblwidth100px bglbl" style="width: 80px">
                <a>Remarks</a>
            </div>
            <div class="div182Px">
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="drpwidth180px"></asp:TextBox>
            </div>
        </div>
    </div>
</div>
<div style="width: 69%; float: left">
    <div style="width: 20%; float: left" class="lblAndTxtStyle">
        <div class="divlblwidth90per bglbl">
            <a>Salutation</a>
        </div>
        <div>
            <asp:DropDownList ID="ddlSalutation" runat="server" CssClass="drpwidth99per">
            </asp:DropDownList>
            <%--<span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlRelegion"
                    runat="server" ForeColor="Red" ErrorMessage="Relegion is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>--%>
        </div>
    </div>
    <div style="width: 20%; float: left" class="lblAndTxtStyle">
        <div class="divlblwidth90per bglbl">
            <a>Name</a>
        </div>
        <div>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="drpwidth99per" MaxLength="100"></asp:TextBox>
            <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                ControlToValidate="txtFirstName" runat="server" ForeColor="Red" ErrorMessage="Employee name is required"
                ValidationGroup="Save">*</asp:RequiredFieldValidator>
        </div>
    </div>
    <div style="width: 20%; float: left" class="lblAndTxtStyle">
        <div class="divlblwidth90per bglbl">
            <a>JSO Name</a>
        </div>
        <div>
            <asp:TextBox ID="txtMiddleName" runat="server" CssClass="drpwidth99per" MaxLength="100"></asp:TextBox>
        </div>
    </div>
    <div style="width: 20%; float: left" class="lblAndTxtStyle">
        <div class="divlblwidth90per bglbl">
            <a>LastName</a>
        </div>
        <div>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="drpwidth99per" MaxLength="100"></asp:TextBox>
        </div>
    </div>
    <div style="width: 20%; float: left" class="lblAndTxtStyle">
        <div class="divlblwidth90per bglbl">
            <a>NickName</a>
        </div>
        <div>
            <asp:TextBox ID="txtNickName" runat="server" CssClass="drpwidth99per" MaxLength="100"></asp:TextBox>
        </div>
    </div>
</div>
<div style="width: 69%; float: left">
    <div style="width: 50%; float: left">
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Date Of Birth</a>
            </div>
            <div class="div80Px">
                <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Religion</a>
            </div>
            <div class="div182Px">
                <asp:DropDownList ID="ddlRelegion" runat="server" CssClass="drpwidth180px">
                </asp:DropDownList>
                <%--<span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlRelegion"
                    runat="server" ForeColor="Red" ErrorMessage="Relegion is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>--%>
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Ethnic Group</a>
            </div>
            <div class="div182Px">
                <asp:DropDownList ID="ddlEthnicGroup" runat="server" CssClass="drpwidth180px">
                </asp:DropDownList>
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Blood Group</a>
            </div>
            <div class="div182Px">
                <asp:DropDownList ID="ddlBloodGroup" runat="server" CssClass="drpwidth180px">
                </asp:DropDownList>
                <%--<span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddlBloodGroup"
                    runat="server" ForeColor="Red" ErrorMessage="Blood group is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>--%>
            </div>
        </div>
    </div>
    <div style="width: 50%; float: left">
        <div class="lblAndTxtStyle">
            <div class="div80Px" style="width: 40px">
                <asp:TextBox ID="txtYrs" runat="server" Width="32px" CssClass="txtwidth178px" onkeypress="return isNumberKey(event)"></asp:TextBox>
            </div>
            <div class="divlblwidth100px bglbl" style="width: 20px">
                <a>Yrs</a>
            </div>
            <div class="div80Px" style="width: 40px">
                <asp:TextBox ID="txtMonth" runat="server" Width="32px" CssClass="txtwidth178px" onkeypress="return isNumberKey(event)"></asp:TextBox>
            </div>
            <div class="divlblwidth100px bglbl" style="width: 30px">
                <a>Month</a>
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Passport Number</a>
            </div>
            <div class="div80Px">
                <asp:TextBox ID="txtPassportNumber" runat="server" CssClass="drpwidth180px" MaxLength="100"></asp:TextBox>
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Tax Number</a>
            </div>
            <div class="div80Px">
                <asp:TextBox ID="txtTaxNumber" runat="server" CssClass="drpwidth180px" MaxLength="100"></asp:TextBox>
            </div>
        </div>
        <div class="lblAndTxtStyle">
            <div class="divlblwidth100px bglbl">
                <a>Driving Licence</a>
            </div>
            <div class="div80Px">
                <asp:TextBox ID="txtDrivingLicenceNumber" runat="server" CssClass="drpwidth180px"
                    MaxLength="100"></asp:TextBox>
            </div>
        </div>
    </div>
</div>
<div style="width: 35%; float: left">
    <div id="LavContactInfo" style="text-align: left; width: 90%">
        <a style="font-size: large">Contact Information</a>
    </div>
    <div id="divContactInfo" style="float: left; width: 99%">
        <div class="lblAndTxtStyle" style="width: 100%;">
            <div class="divlblwidth100px bglbl">
                <a>Phone No</a>
            </div>
            <div class="div80Px">
                <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="drpwidth180px"></asp:TextBox>
            </div>
        </div>
        <div class="lblAndTxtStyle" style="width: 100%;">
            <div class="divlblwidth100px bglbl">
                <a>Land Phone</a>
            </div>
            <div class="div80Px">
                <asp:TextBox ID="txtLandPhone" runat="server" CssClass="drpwidth180px"></asp:TextBox>
            </div>
        </div>
        <div class="lblAndTxtStyle" style="width: 100%;">
            <div class="divlblwidth100px bglbl">
                <a>Email</a>
            </div>
            <div class="div80Px">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="drpwidth180px"></asp:TextBox>
            </div>
        </div>
        <div id="LavIdentification" class="divlblwidth100px" style="width: 100%; margin-left: -5px">
            <a style="font-size: large">Identification</a>
        </div>
        <div class="lblAndTxtStyle" style="width: 100%;">
            <div class="div80Px" style="width: 45px">
                <asp:TextBox ID="txtHight" runat="server" Width="40px" CssClass="txtwidth178px"></asp:TextBox>
            </div>
            <div class="divlblwidth100px bglbl" style="width: 35px">
                <a>Hight</a>
            </div>
            <div class="div80Px" style="width: 45px">
                <asp:TextBox ID="txtWeight" runat="server" Width="40px" CssClass="txtwidth178px"></asp:TextBox>
            </div>
            <div class="divlblwidth100px bglbl" style="width: 35px">
                <a>Weight</a>
            </div>
        </div>
        <div class="lblAndTxtStyle" style="width: 100%; margin-left: -5px">
            <div class="divlblwidth100px bglbl">
                <a>Per. Remarks</a>
            </div>
            <div class="div80Px">
                <asp:TextBox ID="txtPersonalRemarks" runat="server" CssClass="drpwidth180px"></asp:TextBox>
            </div>
        </div>
    </div>
</div>
<div style="width: 35%; float: left">
    <div id="Div1" style="text-align: left; width: 90%">
        <a style="font-size: large">Family Info</a>
    </div>
    <div id="div2" style="float: left; width: 99%">
        <div class="lblAndTxtStyle" style="width: 100%;">
            <div class="divlblwidth100px bglbl">
                <a>Father Name</a>
            </div>
            <div class="div80Px">
                <asp:TextBox ID="txtFatherName" runat="server" CssClass="drpwidth180px"></asp:TextBox>
            </div>
        </div>
        <div class="lblAndTxtStyle" style="width: 100%;">
            <div class="divlblwidth100px bglbl">
                <a>Mother Name</a>
            </div>
            <div class="div80Px">
                <asp:TextBox ID="txtMotherName" runat="server" CssClass="drpwidth180px"></asp:TextBox>
            </div>
        </div>
        <div class="lblAndTxtStyle" style="width: 100%;">
            <div class="divlblwidth100px bglbl">
                <a>Marital Status</a>
            </div>
            <div class="div182Px">
                <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="drpwidth180px">
                </asp:DropDownList>
            </div>
        </div>
        <div class="lblAndTxtStyle" style="width: 100%;">
            <div class="divlblwidth100px bglbl">
                <a>Spouse Name</a>
            </div>
            <div class="div80Px">
                <asp:TextBox ID="txtSpouseName" runat="server" CssClass="drpwidth180px txtWidth"></asp:TextBox>
            </div>
        </div>
        <div class="lblAndTxtStyle" style="width: 100%;">
            <div class="divlblwidth100px bglbl">
                <a>Spouse Occupation</a>
            </div>
            <div class="div80Px">
                <asp:TextBox ID="txtSpouseOccupation" runat="server" CssClass="drpwidth180px"></asp:TextBox>
            </div>
        </div>
        <div class="lblAndTxtStyle" style="width: 100%;">
            <div class="divlblwidth100px bglbl">
                <a>No Of Chieldren</a>
            </div>
            <div class="div80Px">
                <asp:TextBox ID="txtNoOfChieldren" runat="server" CssClass="drpwidth180px" onkeypress="return isNumberKey(event)"></asp:TextBox>
            </div>
        </div>
    </div>
</div>
<div style="clear: both">
</div>
<div style="width: 99%; float: left">
    <div style="width: 30%; float: left">
        <div style="margin-top: 10px; float: left;">
            <fieldset style="border-color: #E8E6DC; border-width: 2px; width: 81%; height: auto;">
                <legend>Singature</legend>
                <div style="text-align: center; vertical-align: middle;">
                    <asp:Image ID="imgSignature" runat="server" Style="max-height: 120px; max-width: 81%;" />
                </div>
            </fieldset>
            <div class="totalDiv">
                <asp:FileUpload ID="fuSignature" runat="server" />
            </div>
        </div>
    </div>
    <div style="width: 69%; float: left">
        <br />
        <div>
            <table id="grdEmpFamDet">
            </table>
            <div id="grdEmpFamDet_pager">
            </div>
        </div>
    </div>
</div>
