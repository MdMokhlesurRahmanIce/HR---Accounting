<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="EvalManagement.aspx.cs" Inherits="Hr.Web.UI.Evaluation.EvalManagement" %>

<%@ Register Src="~/Controls/SearchEmployee.ascx" TagName="ucEmployeeSearch" TagPrefix="asl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/HR/GridScripts/HRM_Eval.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            try {
                $("input[id$='txtDateFrom'], .date-picker").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date, yearRange: '1930:2050' });
                $("input[id$='txtDateTo']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date, yearRange: '1930:2050' });
                $("input[id$='txtLastDayOfPromosion']").datepicker({ dateFormat: "dd/mm/yy", showButtonPanel: true, changeMonth: true, changeYear: true, onSelect: function () { }, defaultDate: new Date, yearRange: '1930:2050' });
            }
            catch (e) {
                alert(e);
            }
        });
      
    </script>
    <style type="text/css">
        .divborder
        {
            border: 1px solid rgb(182, 179, 174);
        }
        .divpad
        {
            padding: 5px;
        }
        .lbl
        {
            width: 20%;
            margin: 1px 5px;
            padding: 3px 3px 3px;
            float: left;
        }
        .lbl2
        {
            width: 12%;
            margin: 1px 5px;
            padding: 3px 3px 3px;
            float: left;
        }
        .lblFull
        {
            width: 60%;
            margin: 1px 5px;
            padding: 4px 3px 3px;
            float: left;
        }
        .txtb
        {
            width: 80%;
            margin: 1px 5px;
            float: left;
            border: 1px solid rgb(182, 179, 174);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-header">
            <asp:Label ID="lblFrmHeader" runat="server"></asp:Label>
        </div>
        <div class="form-details">
            <div style="width: 20%; float: left">
                <asl:ucEmployeeSearch ID="Header1" runat="server" />
            </div>
            <div style="width: 80%; float: left">
                <div>
                    <%--                <st:ucEmployeeSearch ID="ucEmployeeSearch1" runat="server">
                </st:ucEmployeeSearch>--%>
<%--                    <div style="float: left;">
                        <asp:Label ID="ltrEmp" runat="server" CssClass="lblStyle"></asp:Label>
                        <asp:HiddenField ID="hfEmpKey" runat="server" />
                        <asp:TextBox ID="txtEmployee" runat="server" CssClass="txtb" MaxLength="100" Visible="false"></asp:TextBox>
                        <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidatorEmp1"
                            ControlToValidate="txtEmployee" runat="server" ForeColor="Red" ErrorMessage="Employee  is required"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </div>--%>
                </div>
                <div class="clear">
                </div>
                <div class="divpad">
                    <fieldset class="fieldset-panel">
                        <legend class="fieldset-legend">Assessment Period</legend>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl">
                                <a>From</a>
                            </div>
                            <div style="float: left; width: 27%">
                                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="txtb" MaxLength="100" Width="70%"></asp:TextBox>
                                <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                    ControlToValidate="txtDateFrom" runat="server" ForeColor="Red" ErrorMessage="From Date  is required"
                                    ValidationGroup="Save">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="bglbl lbl">
                                <a>To</a>
                            </div>
                            <div style="float: left; width: 27%">
                                <asp:TextBox ID="txtDateTo" runat="server" CssClass="txtb" MaxLength="100" Width="60%"></asp:TextBox>
                                <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                    ControlToValidate="txtDateTo" runat="server" ForeColor="Red" ErrorMessage="To Date  is required"
                                    ValidationGroup="Save">*</asp:RequiredFieldValidator>
                                <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle btn-enable" ImageUrl="~/images/new 20X20.png"
                                    OnClick="btnNew_Click" OnClientClick="enableControl()" />
                                <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle btn-enable"
                                    ImageUrl="~/images/Search 20X20.png" OnClick="btnFind_Click" />
                                <asp:HiddenField ID="hf_EvalKey" runat="server" />
                            </div>
                        </div>
                    </fieldset>
                </div>
                <div class="divpad">
                    <fieldset class="fieldset-panel">
                        <legend class="fieldset-legend">Details of Employee</legend>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl">
                                <a>Name</a>
                            </div>
                            <div class="lbl">
                                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="bglbl lbl">
                                <a>Date of Join</a>
                            </div>
                            <div class="lbl">
                                <asp:Label ID="lblDOJ" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl">
                                <a>Designation</a>
                            </div>
                            <div class="lbl">
                                <asp:Label ID="lblDesig" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="bglbl lbl">
                                <a>Date of Confirmation</a>
                            </div>
                            <div class="lbl">
                                <asp:Label ID="LblCinfirmation" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl">
                                <a>Dept./Section</a>
                            </div>
                            <div class="lbl">
                                <asp:Label ID="lblDept" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="bglbl lbl">
                                <a>Present Grade</a>
                            </div>
                            <div class="lbl">
                                <asp:Label ID="lblPresentGrade" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl">
                                <a>Nature of Employment</a>
                            </div>
                            <div class="lbl">
                                <asp:Label ID="lblNatureOfEmp" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="bglbl lbl">
                                <a>Work Station</a>
                            </div>
                            <div class="lbl">
                                <asp:Label ID="lblWorkStat" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl">
                                <a>Length of Service With WINGS Group (Years)</a>
                            </div>
                            <div class="lbl">
                                <asp:Label ID="lblLengthofWings" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="bglbl lbl">
                                <a>Total Length of Service (Years)</a>
                            </div>
                            <div class="lbl">
                                <asp:Label ID="lblTotalServiceLength" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl">
                                <a>Academic Qualification</a>
                            </div>
                            <div class="lblFull">
                                <asp:Label ID="lblAcademicQualification" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl">
                                <a>Professional Qualification</a>
                            </div>
                            <div class="lblFull">
                                <asp:Label ID="lblProfQual" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <div class="divpad">
                    <fieldset class="fieldset-panel">
                        <legend class="fieldset-legend">Rating Scale – please put your rating as per the following
                            table *</legend>
                        <div class="lblAndTxtStyle">
                            <div class="lblFull">
                                <div class="bglbl  lblFull">
                                    <a>9 -10 = Outstanding Performance (exceeds set expectations by a wide margin)</a>
                                </div>
                                <div class="bglbl  lblFull">
                                    <a>7 - 8 = Excellent Performance (exceed set expectations)</a>
                                </div>
                                <div class="bglbl  lblFull">
                                    <a>4 - 6 = Good Performance (meets the expectations) </a>
                                </div>
                                <div class="bglbl  lblFull">
                                    <a>2 - 3 = Below Average Performance (needs substantial improvement)</a>
                                </div>
                                <div class="bglbl  lblFull">
                                    <a>0 - 1 = Very poor performance (needs disciplinary action)</a>
                                </div>
                            </div>
                            <div class="bglbl lbl">
                                <a>* Fraction is not acceptable</a>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <br />
                <div style="width: 100%; height: auto; margin-top: 5px">
                    <div>
                        <table id="grdPerformanceAreas">
                        </table>
                    </div>
                    <div id="grdPerformanceAreas_pager">
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="bglbl  lbl" style="width: auto">
                        <a>Total (average between supervisor and reviewer)</a>
                    </div>
                    <div>
                        <asp:Label ID="ltrTotalAvg" runat="server" Text="Label" Width="50px"></asp:Label>
                    </div>
                </div>
                <div class="divpad">
                    <fieldset class="fieldset-panel">
                        <legend class="fieldset-legend">Performance as a whole</legend>
                        <div style="width: 40%; float: left">
                            <div class="lblAndTxtStyle">
                                <asp:RadioButton GroupName="Performance" ID="rboPerformance90" Enabled="false" class="rdo"
                                    runat="server" Text="90 -100 =  Outstanding  Performance" />
                            </div>
                            <div class="lblAndTxtStyle">
                                <asp:RadioButton GroupName="Performance" ID="rboPerformance70" Enabled="false" class="rdo"
                                    runat="server" Text="70 - 89  = Excellent Performance" />
                            </div>
                            <div class="lblAndTxtStyle">
                                <asp:RadioButton GroupName="Performance" ID="rboPerformance40" Enabled="false" class="rdo"
                                    runat="server" Text="40 - 69  = Good   Performance" />
                            </div>
                        </div>
                        <div style="width: 40%; float: left">
                            <div class="lblAndTxtStyle">
                                <asp:RadioButton GroupName="Performance" ID="rboPerformance20" Enabled="false" class="rdo"
                                    runat="server" Text="20 - 39  =  Below Average Performance" />
                            </div>
                            <div class="lblAndTxtStyle">
                                <asp:RadioButton GroupName="Performance" ID="rboPerformance00" Enabled="false" class="rdo"
                                    runat="server" Text="00 - 19  =  Very poor performance" />
                            </div>
                        </div>
                    </fieldset>
                </div>
                <div id="divLastYearComm" class="divpad" style="display: none">
                    <fieldset class="fieldset-panel">
                        <legend class="fieldset-legend">Last year’s comment</legend>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl">
                                <a>Special Qualifications or ability (if any)</a>
                            </div>
                            <div style="width: 75%; float: left">
                                <asp:TextBox ID="txtSpecQulification" runat="server" CssClass="txtwidth178px allowEnter"
                                    MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl">
                                <a>Shortcomings/Limitations</a>
                            </div>
                            <div style="width: 75%; float: left">
                                <asp:TextBox ID="txtLimitations" runat="server" CssClass="txtwidth178px allowEnter"
                                    MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl">
                                <a>Suggestions for Improvement</a>
                            </div>
                            <div style="width: 75%; float: left">
                                <asp:TextBox ID="txtImprovment" runat="server" CssClass="txtwidth178px allowEnter"
                                    MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <div id="divThisYearComment" class="divpad" style="display: none">
                    <fieldset class="fieldset-panel">
                        <legend class="fieldset-legend">This year’s comment</legend>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl">
                                <a>Special Qualifications or ability (if any)</a>
                            </div>
                            <div style="width: 75%; float: left">
                                <asp:TextBox ID="txtThisSpecQualification" runat="server" CssClass="txtwidth178px allowEnter"
                                    MaxLength="450" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl">
                                <a>Improvement status on last year’s comment for shortcomings/limitations & suggestions</a>
                            </div>
                            <div style="width: 75%; float: left">
                                <asp:TextBox ID="txtThisSortCommings" runat="server" CssClass="txtwidth178px allowEnter"
                                    MaxLength="450" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl">
                                <a>Suggestions for Improvement on any issues / areas that may require</a>
                            </div>
                            <div style="width: 75%; float: left">
                                <asp:TextBox ID="txtThisSuggestion" runat="server" CssClass="txtwidth178px allowEnter"
                                    MaxLength="450" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <div id="divTranning" class="divpad" style="display: none">
                    <fieldset class="fieldset-panel">
                        <legend class="fieldset-legend">Training </legend>
                        <div style="width: 100%">
                            <div class="bglbl  lbl">
                                <a>Training Provided (Last Year) </a>
                            </div>
                            <div class="lblAndTxtStyle">
                                <div style="width: 100%; padding: 3px;">
                                    <asp:TextBox ID="txtLastYearTranning" runat="server" CssClass="txtwidth178px allowEnter"
                                        MaxLength="500" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div style="width: 100%">
                            <div class="bglbl  lbl">
                                <a>Training Required / Proposed (Present Year) </a>
                            </div>
                            <div class="lblAndTxtStyle">
                                <div style="width: 100%; padding: 3px;">
                                    <asp:TextBox ID="txtPreYaerTranning" runat="server" CssClass="txtwidth178px allowEnter"
                                        MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <div id="divSuggestion" class="divpad" style="display: none">
                    <fieldset class="fieldset-panel">
                        <legend class="fieldset-legend">Suggestions for Improvement in any issues / areas</legend>
                        <div style="width: 100%">
                            <asp:TextBox ID="txtSuggestion" runat="server" CssClass="txtwidth178px allowEnter"
                                MaxLength="450" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </fieldset>
                </div>
                <div id="divSignaturePerformance" class="divpad" style="display: none">
                    <fieldset class="fieldset-panel">
                        <legend class="fieldset-legend">Signature with comment and acknowledgement by the Employee
                            on the above performance</legend>
                        <div style="width: 100%">
                            <asp:TextBox ID="txtSigPerformance" runat="server" CssClass="txtwidth178px allowEnter"
                                MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </fieldset>
                </div>
                <div id="divEvaluRecom" class="divpad" style="display: none">
                    <fieldset class="fieldset-panel">
                        <legend class="fieldset-legend">Evaluator’s Recommendation with signature ( Not to be
                            seen by the employee )</legend>
                        <div style="width: 100%">
                            <asp:TextBox ID="txtEvalutorRec" runat="server" CssClass="txtwidth178px allowEnter"
                                MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </fieldset>
                </div>
                <div id="divReviewerRecom" class="divpad" style="display: none">
                    <fieldset class="fieldset-panel">
                        <legend class="fieldset-legend">Reviewer’s Recommendation with signature ( Not to be
                            seen by the employee)</legend>
                        <div style="width: 100%">
                            <asp:TextBox ID="txtReveiwerRec" runat="server" CssClass="txtwidth178px allowEnter"
                                MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </fieldset>
                </div>
                <div id="divHRRecom" class="divpad" style="display: none">
                    <fieldset class="fieldset-panel">
                        <legend class="fieldset-legend">Comment & signature of HR</legend>
                        <div style="width: 100%">
                            <asp:TextBox ID="txtHrRecom" runat="server" CssClass="txtwidth178px allowEnter" MaxLength="500"
                                TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </fieldset>
                </div>
                <div id="div1" class="divpad">
                    <fieldset class="fieldset-panel">
                        <legend class="fieldset-legend">Salary & other benefits (for Corporate HR department
                            use only)</legend>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl2">
                                <a>Components </a>
                            </div>
                            <div class="bglbl  lbl2">
                                <a>At Joining </a>
                            </div>
                            <div class="bglbl  lbl2">
                                <a>Previous </a>
                            </div>
                            <div class="bglbl  lbl2">
                                <a>Present </a>
                            </div>
                            <div class="bglbl  lbl2">
                                <a>Proposed </a>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl2">
                                <a>Date</a>
                            </div>
                            <div style="float: left">
                                <asp:TextBox ID="txtDateJoin" runat="server" CssClass="txtb date-picker" MaxLength="10"></asp:TextBox>
                                <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                    ControlToValidate="txtDateJoin" runat="server" ForeColor="Red" ErrorMessage="Joining date is required"
                                    ValidationGroup="Save">*</asp:RequiredFieldValidator>
                            </div>
                            <div style="float: left">
                                <asp:TextBox ID="txtDatePrevious" runat="server" CssClass="txtb date-picker" MaxLength="10"></asp:TextBox>
                                <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                    ControlToValidate="txtDatePrevious" runat="server" ForeColor="Red" ErrorMessage="Previous date is required"
                                    ValidationGroup="Save">*</asp:RequiredFieldValidator>
                            </div>
                            <div style="float: left">
                                <asp:TextBox ID="txtDatePresent" runat="server" CssClass="txtb date-picker" MaxLength="10"></asp:TextBox>
                                <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                    ControlToValidate="txtDatePresent" runat="server" ForeColor="Red" ErrorMessage="Present date is required"
                                    ValidationGroup="Save">*</asp:RequiredFieldValidator>
                            </div>
                            <div style="float: left">
                                <asp:TextBox ID="txtDateProposed" runat="server" CssClass="txtb date-picker" MaxLength="10"></asp:TextBox>
                                <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                    ControlToValidate="txtDateProposed" runat="server" ForeColor="Red" ErrorMessage="Proposed Date is required"
                                    ValidationGroup="Save">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl2">
                                <a>Gross</a>
                            </div>
                            <div style="float: left">
                                <asp:TextBox ID="txtGrossJoin" runat="server" CssClass="txtb" MaxLength="100"></asp:TextBox>
                                <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                                    ControlToValidate="txtGrossJoin" runat="server" ForeColor="Red" ErrorMessage="Joining Salary  is required"
                                    ValidationGroup="Save">*</asp:RequiredFieldValidator>
                            </div>
                            <div style="float: left">
                                <asp:TextBox ID="txtPreviousSalary" runat="server" CssClass="txtb" MaxLength="100"></asp:TextBox>
                                <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                    ControlToValidate="txtPreviousSalary" runat="server" ForeColor="Red" ErrorMessage="Previous Salary  is required"
                                    ValidationGroup="Save">*</asp:RequiredFieldValidator>
                            </div>
                            <div style="float: left">
                                <asp:TextBox ID="txtPresentSalary" runat="server" CssClass="txtb" MaxLength="100"></asp:TextBox>
                                <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                                    ControlToValidate="txtPresentSalary" runat="server" ForeColor="Red" ErrorMessage="Present Salary  is required"
                                    ValidationGroup="Save">*</asp:RequiredFieldValidator>
                            </div>
                            <div style="float: left">
                                <asp:TextBox ID="txtPurpose" runat="server" CssClass="txtb" MaxLength="100"></asp:TextBox>
                                <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator10"
                                    ControlToValidate="txtPurpose" runat="server" ForeColor="Red" ErrorMessage="Proposed Salary  is required"
                                    ValidationGroup="Save">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl2">
                                <a>Date of Last Promotion</a>
                            </div>
                            <div>
                                <asp:TextBox ID="txtLastDayOfPromosion" runat="server" CssClass="txtb" MaxLength="100"
                                    Width="100px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="lblAndTxtStyle">
                            <div class="bglbl  lbl2">
                                <a>To be Promoted As</a>
                            </div>
                            <div class="div182Px">
                                <asp:DropDownList ID="ddlDesignation" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="div2" class="divpad">
                            <fieldset class="fieldset-panel">
                                <legend class="fieldset-legend">Other Recommendation</legend>
                                <div class="div182Px">
                                    <asp:DropDownList ID="drpOtherRecom" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </fieldset>
                        </div>
                    </fieldset>
                </div>
            </div>
            <div class="form-bottom">
                <div class="btnRight">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click"
                        Text="Save" ValidationGroup="Save" OnClientClick="CheckValidity();" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnClear" runat="server" CssClass="button" OnClick="btnClear_Click"
                        Text="Cancel" Visible="true" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnDelete" runat="server" CssClass="button" OnClick="btnDelete_Click"
                        Text="Delete" Visible="false" OnClientClick="return confirm('Are you sure you want to delete this record?')" />
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
