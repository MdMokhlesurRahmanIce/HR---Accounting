<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="EmployeeBasicInformation.aspx.cs" Inherits="Hr.Web.UI.EmployeeBasicInfo.EmployeeBasicInformation" %>

<%@ Register Src="~/Controls/SearchEmployee.ascx" TagName="empSearch2" TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmployeeGeneralInfo.ascx" TagName="EmployeeBasicInfo"
    TagPrefix="asl" %>
<%@ Register Src="~/Controls/ucSalaryInfo.ascx" TagName="Salary" TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmployeeAddressInformation.ascx" TagName="EmployeeAddressInfo"
    TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmployeeEducationInformation.ascx" TagName="EmployeeEducationInfo"
    TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmployeeFamilyInfo.ascx" TagName="EmployeeFamilyInfo"
    TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmpHistory.ascx" TagName="EmpHistory" TagPrefix="asl" %>
<%@ Register Src="~/Controls/ucLanguage.ascx" TagName="EmpLanguage" TagPrefix="asl" %>
<%@ Register Src="~/Controls/EmpAttachmentInfo.ascx" TagName="EmpAttachmentInfo"
    TagPrefix="asl" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src='<%= ResolveUrl("~/GridScripts/Lotus-12_EmployeeList.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/GridScripts/JobResponsibility.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/GridScripts/OtherSkillInfo.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/GridScripts/EmployeeInfo_SkillInfo.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/GridScripts/grdMedicalReimbursment.js") %>' type="text/javascript"></script>
    <style type="text/css">
        #tabMarker .lblAndTxtStyle
        {
            font-family: 'Microsoft Sans Serif' ,Sans-Serif,Arial;
        }
    </style>
    <script type="text/javascript">
        var $tabs;
        var selectedtab;
        // bind to accordion object
        $(document).ready(function () {
            $("input[id$='txtDOJ'], .date-picker").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1950:2050' });
            //disabled shiftrule
         
   
           
            $('#cphBody_cphInfbody_txtStartDate').attr("disabled", false);
            //accordion
            $(function () {
                var fixScroll = function (event, ui) {
                    $(event.target).find('ui-accordion-content-active').css('overflow', 'visible');
                }
                $('#container').accordion({
                    header: "h3",
                    create: fixScroll,
                    change: fixScroll
                });
                //end accordion
            });
            $("#cphBody_cphInfbody_btnSave").click(function (e) {
                var shiftRule = $('#cphBody_cphInfbody_ddlShiftRuleCode').val();
                var shiftPlan = $('#cphBody_cphInfbody_ddlShiftPlan').val();
                var StartDate = $('#cphBody_cphInfbody_txtStartDate').val();

                if (shiftPlan != "" && shiftRule != "" && StartDate == "") {
                    ShowMessageBox("HR", "Please Select Start Date!");
                    return false;
                }

            });
            $("#cphBody_cphInfbody_btnUpdate").click(function (e) {

                var shiftRule = $('#cphBody_cphInfbody_ddlShiftRuleCode').val();

                var shiftPlan = $('#cphBody_cphInfbody_ddlShiftPlan').val();
                // alert(shiftPlan);
                var StartDate = $('#cphBody_cphInfbody_txtStartDate').val();
                //   alert(StartDate);

                if ((shiftPlan != "" || shiftRule != "") && StartDate == "") {
                    ShowMessageBox("HR", "Please Select Start Date!");
                    return false;
                }

            });

            $(function () {
                $tabs = $("#divTab").tabs();
                $tabs.tabs('select', selectedtab);
                $("#divTab").bind("tabsselect", function (e, tab) {
                    $('#cphBody_cphInfbody_hfSelectedtab').val(tab.index);
                    if (tab.index == 3) {
                        if ($('#cphBody_cphInfbody_ctrlEmployeeGeneralInfo_ddlGender').val() == "89") {
                            $('.maternity').show();
                        }
                        else {
                            $('#cphBody_cphInfbody_txtMaternityLimit').val("");
                            $('.maternity').hide();
                        }
                    }
                });
                //alert(selectedtab);
                //maternity
            });

            // actions taken upon clicking the expand all (collapse all) link
            $('#container #expand').click(function () {
                // if link was expand then show and toggle text
                var currHTML = $('#container #expand').html();
                if (currHTML.indexOf("Expand All") > 0) {
                    $('#container .accordion').slideDown();
                    $('#container #expand').html("<IMG src=\"/images/MINUS.gif\"/> Collapse All");
                }
                // if link was collapse then hide and toggle text
                else {
                    $('#container .accordion').slideUp();
                    $('#container .accordion').each(function (i) {
                        if (i == 0) $(this).slideDown();
                    });
                    $('#container #expand').html("<IMG src=\"/images/PLUS.gif\"/> Expand All");
                }
            });
            $('#cphBody_cphInfbody_ddlEmployeeType_nc').change(function () {
                if ($('#cphBody_cphInfbody_ddlEmployeeType_nc').val() == "90") {
                    $('#cphBody_cphInfbody_txtEndDate').val("");
                    $('#cphBody_cphInfbody_ddlVendor').val("");
                    $('#cphBody_cphInfbody_ddlVendorID').val("");
                    $('#cphBody_cphInfbody_txtEndDate').attr("disabled", true);
                    $('#cphBody_cphInfbody_ddlVendor').attr("disabled", true);
                    $('#cphBody_cphInfbody_txtVendorID').attr("disabled", true);
                    $('#cphBody_cphInfbody_txtRetairmentDate').attr("disabled", false);
                }
                else {
                    $('#cphBody_cphInfbody_txtRetairmentDate').val("");
                    $('#cphBody_cphInfbody_txtEndDate').attr("disabled", false);
                    $('#cphBody_cphInfbody_ddlVendor').attr("disabled", false);
                    $('#cphBody_cphInfbody_txtVendorID').attr("disabled", false);
                    $('#cphBody_cphInfbody_txtRetairmentDate').attr("disabled", true);
                }
            });
        });
        $('#cphBody_cphInfbody_ddlShiftRuleCode').change(function () {

            $('#cphBody_cphInfbody_ddlShiftPlan').val("");
        });
       

        function toggleShiftRuleclick(ctrl) {
            if (ctrl.checked) {
                $('#cphBody_cphInfbody_ddlShiftRuleCode').attr("disabled", false);
                $('#cphBody_cphInfbody_txtStartDate').attr("disabled", false);
                $('#cphBody_cphInfbody_ddlShiftPlan').attr("disabled", true);
                //   $('#cphBody_cphInfbody_ddlShiftPlan').hide();

            }
            else {
                $('#cphBody_cphInfbody_ddlShiftRuleCode').attr("disabled", true);
                $('#cphBody_cphInfbody_txtStartDate').attr("disabled", false);
                $('#cphBody_cphInfbody_ddlShiftPlan').attr("disabled", false);

                // $('#cphBody_cphInfbody_ddlShiftPlan').show();
                //$('#cphBody_cphInfbody_ddlShiftRuleCode').hide();
            }
        };
        function toggleOTclick(ctrl) {
            if (ctrl.checked) {
                $('#cphBody_cphInfbody_txtOTEntitleDate').attr("disabled", false);
            }
            else {
                $('#cphBody_cphInfbody_txtOTEntitleDate').attr("disabled", true);
            }
        };
        function togglePFclick(ctrl) {
            if (ctrl.checked) {
                $('#cphBody_cphInfbody_txtPFEntitleDate').attr("disabled", false);
                $('#cphBody_cphInfbody_ddlPFCompany').attr("disabled", false);
                $('#cphBody_cphInfbody_txtPFNominee').attr("disabled", false);
                $('#cphBody_cphInfbody_txtPFAccNo').attr("disabled", false);
                $('#cphBody_cphInfbody_txtPFRelation').attr("disabled", false);
                $('#cphBody_cphInfbody_txtPFNomineeAdd').attr("disabled", false);
            }
            else {
                $('#cphBody_cphInfbody_txtPFEntitleDate').attr("disabled", true);
                $('#cphBody_cphInfbody_ddlPFCompany').attr("disabled", true);
                $('#cphBody_cphInfbody_txtPFNominee').attr("disabled", true);
                $('#cphBody_cphInfbody_txtPFAccNo').attr("disabled", true);
                $('#cphBody_cphInfbody_txtPFRelation').attr("disabled", true);
                $('#cphBody_cphInfbody_txtPFNomineeAdd').attr("disabled", true);
            }
        };
        function toggleInsuranceclick(ctrl) {
            if (ctrl.checked) {
                $('#cphBody_cphInfbody_txtInsuranceEntitleDate').attr("disabled", false);
                $('#cphBody_cphInfbody_ddlInsuranceCompany').attr("disabled", false);
                $('#cphBody_cphInfbody_txtInsuranceNominee').attr("disabled", false);
                $('#cphBody_cphInfbody_txtInsuranceAccNo').attr("disabled", false);
                $('#cphBody_cphInfbody_txtInsuranceRelation').attr("disabled", false);
                $('#cphBody_cphInfbody_txtInsuranceNomineeAdd').attr("disabled", false);
            }
            else {
                $('#cphBody_cphInfbody_txtInsuranceEntitleDate').attr("disabled", true);
                $('#cphBody_cphInfbody_ddlInsuranceCompany').attr("disabled", true);
                $('#cphBody_cphInfbody_txtInsuranceNominee').attr("disabled", true);
                $('#cphBody_cphInfbody_txtInsuranceAccNo').attr("disabled", true);
                $('#cphBody_cphInfbody_txtInsuranceRelation').attr("disabled", true);
                $('#cphBody_cphInfbody_txtInsuranceNomineeAdd').attr("disabled", true);
            }
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <asp:HiddenField ID="hfSupervisorCode" runat="server" />
            <asp:HiddenField ID="hfFuctionalBossCode" runat="server" />
            <asp:HiddenField ID="hfAdminBossCode" runat="server" />
            <div style="float: right; padding-right: 10px; padding-bottom: 5px">
            <asp:Label ID="Label1"  runat="server" Text="Label" ></asp:Label>
            </div>
            <div style="width: 23%; float: left; padding-right: 10px">
                <asl:empSearch2 ID="ctrlEmpSearch2" runat="server"></asl:empSearch2>
            </div>
            <div id="divTab" style="width: 75%; float: left; padding-bottom: 10px;" onclick="return divTab_onclick()">
                <ul>
                    <li><a href="#tabEmployeeGeneralInfo">Personal</a></li>
                    <li><a href="#tabEmployeeAddressInformation">Address</a></li>
                    <li><a href="#tabOfficialInfo">Official</a></li>
                    <li><a href="#tabEntitlement">Entitle Info</a></li>
                    <li><a href="#tabSalry">Salary</a></li>
                    <li><a href="#tabJobResponsibility">Job Responsibility</a></li>
                    <li><a href="#tabHistory">History</a></li>
                    <li><a href="#tabSkill">Skill info</a></li>
                    <li><a href="#tabOthers">Others</a></li>
                    <li class="abc"><a href="#tabEmpAttachmentInfo">Attachments</a></li>
                </ul>
                <div id="tabEmployeeGeneralInfo">
                    <asl:EmployeeBasicInfo ID="ctrlEmployeeGeneralInfo" runat="server"></asl:EmployeeBasicInfo>
                </div>
                <div id="tabEmployeeAddressInformation">
                    <asl:EmployeeAddressInfo ID="ctrlEmployeeAddressInfo" runat="server"></asl:EmployeeAddressInfo>
                </div>
                <div id="tabOfficialInfo">
                    <div style="width: 99%; float: left">
                        <div style="width: 99%; float: left">
                            <div style="width: 33%; float: left">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px1 bglbl">
                                        <a>DOJ</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="txtDOJ" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                    </div>
                                    <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                        ControlToValidate="txtDOJ" runat="server" ForeColor="Red" ErrorMessage="DOJ is required"
                                        ValidationGroup="Save">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div style="width: 33%; float: left">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px1 bglbl">
                                        <a>DOC</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="txtDOC" runat="server" CssClass="txtwidth178px date-picker" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 33%; float: left">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px1 bglbl">
                                        <a>DOS</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="txtDOS" runat="server" CssClass="txtwidth178px date-picker" Enabled="false"
                                            MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div style="width: 99%; float: left">
                            <div style="width: 33%; float: left">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px1 bglbl">
                                        <a>Service Length</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="txtServiceLength" runat="server" Enabled="false" CssClass="txtwidth178px date-picker"
                                            MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 33%; float: left">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px1 bglbl">
                                        <a>Tamp. ID</a>
                                    </div>
                                    <div class="div182Px">
                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="drpwidth180px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 33%; float: left">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px1 bglbl">
                                        <a>Cell Phone</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="txtCellPhone" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div style="width: 99%; float: left">
                            <div style="width: 33%; float: left">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px1 bglbl">
                                        <a>Land Phone</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="txtLandPhone" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 33%; float: left">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px1 bglbl">
                                        <a>Email</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="txtOfficialEmail" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                             <div style="width: 33%; float: left">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px1 bglbl">
                                        <a>Emp Type</a>
                                    </div>
                                    <div class="div182Px">
                                        <asp:DropDownList ID="ddlEmployeeType_nc" runat="server" CssClass="drpwidth180px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            
                        </div>
                        <div style="width: 99%; float: left">
                           
                            <div style="width: 33%; float: left">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px1 bglbl">
                                        <a>Vendor</a>
                                    </div>
                                    <div class="div182Px">
                                        <asp:DropDownList ID="ddlVendor" runat="server" CssClass="drpwidth180px" Enabled="false">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 33%; float: left;">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px1 bglbl">
                                        <a>Vendor ID</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="txtVendorID" runat="server" CssClass="txtwidth178px" MaxLength="100"
                                            Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 33%; float: left;">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px1 bglbl">
                                        <a>End Date</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="txtwidth178px date-picker"
                                            MaxLength="100" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div style="width: 99%; float: left">
                            <div style="width: 33%; float: left">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px1 bglbl">
                                        <a>DOR</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="txtRetairmentDate" runat="server" CssClass="txtwidth178px date-picker"
                                            MaxLength="100" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                             <div style="width: 33%; float: left">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px1 bglbl">
                                        <a>NT ID</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="txtNTId" runat="server" CssClass="txtwidth178px"
                                            MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div style="float: left; width: 99%">
                                <br />
                                <a style="font-size: medium">Position Info</a>
                            </div>
                        </div>
                        <div style="float: left; width: 99%">
                            <asp:Panel ID="Panel1" runat="server" Style="height: auto;">
                            </asp:Panel>
                        </div>
                        <div style="float: left; width: 99%">
                            <div style="float: left; width: 33%">
                                <div style="float: left; width: 99%">
                                    <br />
                                    <a style="font-size: medium">Other Info</a>
                                </div>
                                <div style="float: left; width: 99%;">
                                    <div class="lblAndTxtStyle">
                                        <div class="divlblwidth100px1">
                                            <a>Punch Card1</a>
                                        </div>
                                        <div class="div80Px">
                                            <asp:TextBox ID="txtPunchCardNo" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="lblAndTxtStyle">
                                        <div class="divlblwidth100px1">
                                            <a>Punch Card2</a>
                                        </div>
                                        <div class="div80Px">
                                            <asp:TextBox ID="txtPunchCardNo2" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="lblAndTxtStyle">
                                        <asp:CheckBox ID="chkShiftRuleApplicable" Text="Shift Rule Applicable" onclick="toggleShiftRuleclick(this);"
                                            runat="server" />
                                    </div>
                                    <div class="lblAndTxtStyle">
                                        <div class="divlblwidth100px1">
                                            <a>Shift Plan</a>
                                        </div>
                                        <div class="div182Px">
                                            <asp:DropDownList ID="ddlShiftPlan" runat="server" CssClass="drpwidth180px">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="lblAndTxtStyle">
                                        <div class="divlblwidth100px1">
                                            <a>Shift Rule Code</a>
                                        </div>
                                        <div class="div182Px">
                                            <asp:DropDownList ID="ddlShiftRuleCode" runat="server" CssClass="drpwidth180px">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="lblAndTxtStyle">
                                        <div class="divlblwidth100px1">
                                            <a>Start Date</a>
                                        </div>
                                        <div class="div80Px">
                                            <asp:TextBox ID="txtStartDate" runat="server" CssClass="txtwidth178px date-picker"
                                                MaxLength="100"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="float: left; width: 33%">
                                <div style="float: left; width: 99%;">
                                    <br />
                                    <br />
                             
                                   
                                    <div style="float: left; width: 80%">
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Supervisor</a>
                                            </div>
                                            <div class="div80Px">
                                                <asp:TextBox ID="txtSupervisor" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float: left; margin-left: 5px;">
                                        <asp:ImageButton ID="btnFindSupervisor" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png"
                                            OnClick="btnFindSupervisor_Click" />
                                    </div>
                                    <div style="float: left; width: 80%">
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>HOD</a>
                                            </div>
                                            <div class="div80Px">
                                                <asp:TextBox ID="txtFunctionalBoss" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float: left; margin-left: 5px;">
                                        <asp:ImageButton ID="btnFunctionalBoss" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png"
                                            OnClick="btnFunctionalBoss_Click" />
                                    </div>
                                    <div style="float: left; width: 80%; visibility:hidden ">
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Admin Boss</a>
                                            </div>
                                            <div class="div80Px">
                                                <asp:TextBox ID="txtAdminBoss" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float: left; margin-left: 5px; visibility:hidden">
                                        <asp:ImageButton ID="btnAdminBoss" runat="server" CssClass="btnImageStyle" ImageUrl="~/images/Search 20X20.png"
                                            OnClick="btnAdminBoss_Click" />
                                    </div>
                                </div>
                            </div>
                            <div style="float: left; width: 20%">
                                <div style="float: left; width: 99%;">
                                    <br />
                                 
                               
                                    <a>Designation</a>
                                    <div class="lblAndTxtStyle">
                                        <div class="div80Px">
                                            <asp:TextBox ID="txtSupervisorDesig" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="lblAndTxtStyle">
                                        <div class="div80Px">
                                            <asp:TextBox ID="txtFunctionalBossDesig" runat="server" CssClass="txtwidth178px
                                            " MaxLength="100"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="lblAndTxtStyle" style="visibility: hidden">
                                        <div class="div80Px">
                                            <asp:TextBox ID="txtAdminBossDesig" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="float: left; width: 12%">
                                <div style="float: left; width: 100%;">
                                    <br />
                                   
                                    <a>Note</a>
                                    <div class="lblAndTxtStyle">
                                        <div class="div80Px">
                                            <asp:TextBox ID="txtDescription" runat="server" CssClass="txtwidth178px allowEnter"
                                                Width="100px" TextMode="MultiLine" MaxLength="100"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tabEntitlement">
                    <div style="width: 99%; float: left">
                        <div style="width: 99%; float: left">
                            <div id="container">
                                <div id="expand" style="text-align: right">
                                    <img src="/images/plus.gif" />
                                    Expand All</div>
                                <h3 class="headline">
                                    <a href="#">OT</a></h3>
                                <div class="accordion">
                                    <div class="lblAndTxtStyle">
                                        <asp:CheckBox ID="chkOT" Text="Over Time" onclick="toggleOTclick(this);" runat="server" />
                                    </div>
                                    <div class="lblAndTxtStyle">
                                        <div class="divlblwidth100px1" style="width: 15%">
                                            <a>OT Entitle Date</a>
                                        </div>
                                        <div class="div80Px">
                                            <asp:TextBox ID="txtOTEntitleDate" runat="server" CssClass="txtwidth178px date-picker"
                                                Width="40%" MaxLength="100" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="lblAndTxtStyle">
                                        <asp:CheckBox ID="chkOffDayOT" Text="Off Day OT" runat="server" />
                                    </div>
                                    <div class="lblAndTxtStyle">
                                        <asp:CheckBox ID="chkHolidayBenefit" Text="Holiday Benefit" runat="server" />
                                    </div>
                                </div>
                                <h3 class="headline">
                                    <a href="#">PF Information</a></h3>
                                <div class="accordion">
                                    <div class="lblAndTxtStyle">
                                        <asp:CheckBox ID="chkPF" Text="PF" onclick="togglePFclick(this);" runat="server" />
                                    </div>
                                    <div style="float: left; width: 50%">
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>PF Entitle Date</a>
                                            </div>
                                            <div class="div80Px">
                                                <asp:TextBox ID="txtPFEntitleDate" runat="server" CssClass="txtwidth178px date-picker"
                                                    Width="50%" MaxLength="100" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>PF Acc No</a>
                                            </div>
                                            <div class="div80Px">
                                                <asp:TextBox ID="txtPFAccNo" runat="server" CssClass="txtwidth178px" MaxLength="100"
                                                    Width="50%" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>PF Company</a>
                                            </div>
                                            <div class="div182Px">
                                                <asp:DropDownList ID="ddlPFCompany" runat="server" CssClass="drpwidth180px" Width="50%"
                                                    Enabled="false">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float: left; width: 50%">
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>PF Nominee</a>
                                            </div>
                                            <div class="div80Px">
                                                <asp:TextBox ID="txtPFNominee" runat="server" CssClass="txtwidth178px" MaxLength="100"
                                                    Width="50%" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Relation With Nom.</a>
                                            </div>
                                            <div class="div80Px">
                                                <asp:TextBox ID="txtPFRelation" runat="server" CssClass="txtwidth178px" MaxLength="100"
                                                    Width="50%" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Address of Nominee</a>
                                            </div>
                                            <div class="div80Px">
                                                <asp:TextBox ID="txtPFNomineeAdd" runat="server" CssClass="txtwidth178px" MaxLength="100"
                                                    Width="50%" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <h3 class="headline">
                                    <a href="#">Insurance Information</a></h3>
                                <div class="accordion">
                                    <div class="lblAndTxtStyle">
                                        <asp:CheckBox ID="chkInsuranceInfo" Text="Insurance" onclick="toggleInsuranceclick(this);"
                                            runat="server" />
                                    </div>
                                    <div style="float: left; width: 50%">
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Insurance Entitle Date</a>
                                            </div>
                                            <div class="div80Px">
                                                <asp:TextBox ID="txtInsuranceEntitleDate" runat="server" CssClass="txtwidth178px date-picker"
                                                    Width="50%" MaxLength="100" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Insrance No</a>
                                            </div>
                                            <div class="div80Px">
                                                <asp:TextBox ID="txtInsuranceAccNo" runat="server" CssClass="txtwidth178px" MaxLength="100"
                                                    Width="50%" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Insurance Company</a>
                                            </div>
                                            <div class="div182Px">
                                                <asp:DropDownList ID="ddlInsuranceCompany" runat="server" CssClass="drpwidth180px"
                                                    Width="50%" Enabled="false">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float: left; width: 50%">
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Insurance Nominee</a>
                                            </div>
                                            <div class="div80Px">
                                                <asp:TextBox ID="txtInsuranceNominee" runat="server" CssClass="txtwidth178px" MaxLength="100"
                                                    Width="50%" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Relateion with Nom.</a>
                                            </div>
                                            <div class="div80Px">
                                                <asp:TextBox ID="txtInsuranceRelation" runat="server" CssClass="txtwidth178px" MaxLength="100"
                                                    Width="50%" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Address of Nominee</a>
                                            </div>
                                            <div class="div80Px">
                                                <asp:TextBox ID="txtInsuranceNomineeAdd" runat="server" CssClass="txtwidth178px"
                                                    MaxLength="100" Width="50%" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <h3 class="headline">
                                    <a href="#">Medical Reimbursement</a></h3>
                                <div class="accordion">
                                    <div style="width: 30%; float: left">
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Fiscal Year</a>
                                            </div>
                                            <div class="div182Px">
                                                <asp:DropDownList ID="ddlYear_nc" runat="server" CssClass="drpwidth180px">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Self Limit</a>
                                            </div>
                                            <div class="div80Px">
                                                <asp:TextBox ID="txtSelfLimit" runat="server" Text="Unlimited" Enabled="false" CssClass="txtwidth178px"
                                                    MaxLength="100" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Family Limit</a>
                                            </div>
                                            <div class="div80Px">
                                                <asp:TextBox ID="txtFamilyLimit" runat="server" CssClass="txtwidth178px" MaxLength="100"
                                                    onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle maternity" style="display: none">
                                            <div class="divlblwidth100px1">
                                                <a>Maternity Limit</a>
                                            </div>
                                            <div class="div80Px">
                                                <asp:TextBox ID="txtMaternityLimit" runat="server" CssClass="txtwidth178px" MaxLength="100"
                                                    onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="width: 30%; float: left">
                                        <div class="lblAndTxtStyle">
                                            <a>Remarks</a>
                                            <asp:TextBox ID="txtMedicalRemarks" runat="server" CssClass="txtwidth178px allowEnter"
                                                MaxLength="250" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <h3 class="headline">
                                    <a href="#">Policy Tagging</a></h3>
                                <div class="accordion">
                                    <div style="width: 60%; float: left">
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Leave Rule</a>
                                            </div>
                                            <div class="div182Px">
                                                <asp:DropDownList ID="ddlLeaveRule" runat="server" CssClass="drpwidth180px" Width="50%">
                                                </asp:DropDownList>
                                                <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                    ControlToValidate="ddlLeaveRule" runat="server" ForeColor="Red" ErrorMessage="Leave Rule is not Given!!"
                                                    ValidationGroup="Save">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Maternity Rule</a>
                                            </div>
                                            <div class="div182Px">
                                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="drpwidth180px" Width="50%">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Currency Rule</a>
                                            </div>
                                            <div class="div182Px">
                                                <asp:DropDownList ID="DropDownList4" runat="server" CssClass="drpwidth180px" Width="50%">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="lblAndTxtStyle">
                                            <div class="divlblwidth100px1">
                                                <a>Absenteeism Rule</a>
                                            </div>
                                            <div class="div182Px">
                                                <asp:DropDownList ID="DropDownList5" runat="server" CssClass="drpwidth180px" Width="50%">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tabSalry">
                    <asl:Salary ID="ctrlSalaryInfo" runat="server"></asl:Salary>
                </div>
                <div id="tabJobResponsibility">
                    <div style="width: 99%; float: left">
                        <div style="width: 95%">
                            <table id="grdJobResponsibility">
                            </table>
                            <div id="grdJobResponsibility_pager">
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tabHistory">
                    <asl:EmployeeEducationInfo ID="ctrlEmployeeEducationInfo" runat="server"></asl:EmployeeEducationInfo>
                    <br />
                    <div id="ff">
                        <asl:EmpHistory ID="ctrlEmpHistory" runat="server"></asl:EmpHistory>
                    </div>
                </div>
                <div id="tabSkill">
                    <div id="tabSkillInfo" style="height: auto; width: 99%; background-color: #FDF7EA;">
                        <div>
                            <div id="grdSkill" class="ui-jqgrid" style="width: 99%; float: left; background-color: #FDF7EA;">
                                <table id="grdSkillInfo">
                                </table>
                            </div>
                            <div id="grdSkillInfo_pager">
                            </div>
                        </div>
                        <div id="grdOtherSkill" style="width: 99%; float: left; background-color: #FDF7EA;">
                            <div class="ui-jqgrid">
                                <table id="grdOtherSkillInfo">
                                </table>
                            </div>
                            <div id="grdOtherSkillInfo_pager">
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tabOthers">
                    <div id="tabEmployeeLanguage">
                        <asl:EmpLanguage ID="ctrlLanguage" runat="server"></asl:EmpLanguage>
                    </div>
                    <div>
                        <br />
                        <div style="width: 50%; float: left">
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth100px bglbl">
                                    <a>Reference1</a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtReference1" runat="server" CssClass="txtwidth178px allowEnter"
                                        TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                                </div>
                            </div>
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth100px bglbl">
                                    <a>Relation1</a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtRelation1" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div style="width: 50%; float: left">
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth100px bglbl">
                                    <a>Reference2</a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtReference2" runat="server" CssClass="txtwidth178px allowEnter"
                                        TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                                </div>
                            </div>
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth100px bglbl">
                                    <a>Relation2</a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtRelation2" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tabEmpAttachmentInfo">
                    <asl:EmpAttachmentInfo ID="ctrlEmpAttachmentInfo" runat="server"></asl:EmpAttachmentInfo>
                </div>
            </div>
            <div style="clear: both">
            </div>
            <div class="form-bottom">
                <div class="btnRight">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click"
                        Text="Save" ValidationGroup="Save" OnClientClick="CheckValidity();" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnUpdate" runat="server" CssClass="button" OnClick="btnUpdate_Click"
                        Text="Update" Visible="false" ValidationGroup="Save" OnClientClick="CheckValidity();" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnClear" runat="server" CssClass="button" OnClick="btnClear_Click"
                        Text="Cancel" Visible="true" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" Visible="false"
                        OnClientClick="return confirm('Are you sure you want to delete this record?')" />
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hfSelectedtab" runat="server" Value="0" />
    </div>
</asp:Content>
