using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.Hr.BLL;
using ASL.Hr.DAO;
using ASL.STATIC;
using ASL.DATA;
using ASL.Web.Framework;
using System.Collections;
using System.Data.SqlClient;
using Hr.Web.Controls;
using Hr.Web.Utils;

namespace Hr.Web.UI.EmployeeBasicInfo
{
    public partial class EmployeeBasicInformation : PageBase
    {
        #region Fileds
        EntityManager ManagerEntity = new EntityManager();
        HKEntryManager ManagerHKEntry = new HKEntryManager();
        SkillManager ManagerSkill = new SkillManager();
        public readonly EmployeeManager _empManager;
        string selectedtab = "";
        public readonly MonthlySalarProcessManager _salaryManager = new MonthlySalarProcessManager();
        #endregion

        #region session variable
        private CustomList<ASL.Hr.DAO.EntityList> _EntityList
        {
            get
            {
                if (Session["EmployeeBasicInfo_EntityList"] == null)
                    return new CustomList<ASL.Hr.DAO.EntityList>();
                else
                    return (CustomList<ASL.Hr.DAO.EntityList>)Session["EmployeeBasicInfo_EntityList"];
            }
            set
            {
                Session["EmployeeBasicInfo_EntityList"] = value;
            }
        }
        private CustomList<SkillInfo> EmployeeSkillInfoList
        {
            get
            {
                if (Session["EmployeeBasicInfo_SkillInfo"] == null)
                    return new CustomList<SkillInfo>();
                else
                    return (CustomList<SkillInfo>)Session["EmployeeBasicInfo_SkillInfo"];
            }
            set
            {
                Session["EmployeeBasicInfo_SkillInfo"] = value;
            }
        }
        private CustomList<OtherSkillInfo> EmployeeOtherSkillInfoList
        {
            get
            {
                if (Session["EmployeeBasicInfo_OtherSkillInfo"] == null)
                    return new CustomList<OtherSkillInfo>();
                else
                    return (CustomList<OtherSkillInfo>)Session["EmployeeBasicInfo_OtherSkillInfo"];
            }
            set
            {
                Session["EmployeeBasicInfo_OtherSkillInfo"] = value;
            }
        }
        private CustomList<HRM_Emp> EmployeeList
        {
            get
            {
                if (Session["EmployeeBasicInformation_EmployeeList"] == null)
                    return new CustomList<HRM_Emp>();
                else
                    return (CustomList<HRM_Emp>)Session["EmployeeBasicInformation_EmployeeList"];
            }
            set
            {
                Session["EmployeeBasicInformation_EmployeeList"] = value;
            }
        }
        private CustomList<JobResponsibility> JobResponsibilityList
        {
            get
            {
                if (Session["EmployeeBasicInformation_JobResponsibilityList"] == null)
                    return new CustomList<JobResponsibility>();
                else
                    return (CustomList<JobResponsibility>)Session["EmployeeBasicInformation_JobResponsibilityList"];
            }
            set
            {
                Session["EmployeeBasicInformation_JobResponsibilityList"] = value;
            }
        }
        private CustomList<HRM_EmpFamDet> EmpFamDetList
        {
            get
            {
                if (Session["EmployeeBasicInformation_EmpFamDetList"] == null)
                    return new CustomList<HRM_EmpFamDet>();
                else
                    return (CustomList<HRM_EmpFamDet>)Session["EmployeeBasicInformation_EmpFamDetList"];
            }
            set
            {
                Session["EmployeeBasicInformation_EmpFamDetList"] = value;
            }
        }
        private CustomList<MedicalReinSetup> MedicalAllowanceSetList
        {
            get
            {
                if (Session["EmployeeBasicInformation_MedicalAllowanceSetList"] == null)
                    return new CustomList<MedicalReinSetup>();
                else
                    return (CustomList<MedicalReinSetup>)Session["EmployeeBasicInformation_MedicalAllowanceSetList"];
            }
            set
            {
                Session["EmployeeBasicInformation_MedicalAllowanceSetList"] = value;
            }
        }
        #endregion

        #region Ctor
        public EmployeeBasicInformation()
        {
            _empManager = new EmployeeManager();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                InitializeCombo();
                InitializeSession();
                EmployeeList = new CustomList<HRM_Emp>();
                ClientScript.RegisterClientScriptBlock(GetType(), "IsPostBack", "var isPostBack = true;", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "IsPostBack", "var isPostBack = false;", true);
                selectedtab = hfSelectedtab.Value;
                //selectedtab = Request.QueryString.Get("selectedtab");
                //if (selectedtab == null)
                //selectedtab = "2";
                ClientScript.RegisterClientScriptBlock(GetType(), "selectedtab", "selectedtab = " + selectedtab, true);
                if (Request["__EVENTTARGET"] == "SearchSupervisor")
                {
                    HRM_Emp searchEmp = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as HRM_Emp;
                    txtSupervisor.Text = searchEmp.EmpName;
                    txtSupervisorDesig.Text = searchEmp.Designation;
                    hfSupervisorCode.Value = searchEmp.EmpKey.ToString();
                }
                if (Request["__EVENTTARGET"] == "SearchFunctionalBoss")
                {
                    HRM_Emp searchEmp = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as HRM_Emp;
                    txtFunctionalBoss.Text = searchEmp.EmpName;
                    txtFunctionalBossDesig.Text = searchEmp.Designation;
                    hfFuctionalBossCode.Value = searchEmp.EmpKey.ToString();
                }
                if (Request["__EVENTTARGET"] == "SearchAdminBoss")
                {
                    HRM_Emp searchEmp = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as HRM_Emp;
                    txtAdminBoss.Text = searchEmp.EmpName;
                    txtAdminBossDesig.Text = searchEmp.Designation;
                    hfAdminBossCode.Value = searchEmp.EmpKey.ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox empCodeTextBox = (TextBox)ctrlEmpSearch2.FindControl("txtSearch");
                TextBox firstNameTextBox = (TextBox)ctrlEmployeeGeneralInfo.FindControl("txtFirstName");
                string empCode = HRM_Emp.GetExistingEmp(firstNameTextBox.Text);
                if (empCode.IsNotNullOrEmpty())
                {
                    this.ErrorMessage = "Employee Name Already Exist!";
                    return;
                }
                var empInfo = new ArrayList();

                EmployeeGeneralInfo empGeneralInfo = ctrlEmployeeGeneralInfo as EmployeeGeneralInfo;
                empGeneralInfo.SaveEmpGeneralInfo(empInfo);
                CustomList<HRM_Emp> empList = (CustomList<HRM_Emp>)empInfo[0];
                SetOfficialInfo(empList[0]);

                EmployeeAddressInformation empAddrInfo = ctrlEmployeeAddressInfo as EmployeeAddressInformation;
                empAddrInfo.SaveEmpAddr(empInfo);

                CustomList<JobResponsibility> ResponsibilityList = JobResponsibilityList;
                empInfo.Add(ResponsibilityList);

                EmployeeEducationInformation empEdu = ctrlEmployeeEducationInfo as EmployeeEducationInformation;
                empEdu.SaveEmpEducationInfo(empInfo);

                EmpHistory empHist = ctrlEmpHistory as EmpHistory;
                empHist.Save(empInfo);

                EmpAttachmentInfo empFile = ctrlEmpAttachmentInfo as EmpAttachmentInfo;
                empFile.Save(empInfo);

                EmployeeHKInfoSave(empInfo);

                ucSalaryInfo empSalary = ctrlSalaryInfo as ucSalaryInfo;
                empSalary.Save(empInfo);

                ucLanguage empLanguage = ctrlLanguage as ucLanguage;
                empLanguage.Save(empInfo);

                CustomList<HRM_EmpFamDet> FamilyDetList = EmpFamDetList;
                empInfo.Add(FamilyDetList);

                //Medical
                CustomList<MedicalReinSetup> lstMedicalAllowanceSetup = new CustomList<MedicalReinSetup>();
                MedicalReinSetup newMedicalAllowance = new MedicalReinSetup();
                lstMedicalAllowanceSetup.Add(newMedicalAllowance);
                SetDataMedicalAllowance(ref lstMedicalAllowanceSetup);
                if (lstMedicalAllowanceSetup[0].FYKey == 0)
                    lstMedicalAllowanceSetup = new CustomList<MedicalReinSetup>();
                empInfo.Add(lstMedicalAllowanceSetup);
                //End

                _empManager.SaveEmployeeInfo(empInfo);
                this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                this.btnSave.Visible = false;
                this.btnUpdate.Visible = true;
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }
        private void SetDataMedicalAllowance(ref CustomList<MedicalReinSetup> lstMedicalAllowance)
        {
            try
            {
                if (ddlYear_nc.SelectedValue != "")
                {
                    MedicalReinSetup objMedicalAllowance = lstMedicalAllowance[0];
                    objMedicalAllowance.FYKey = ddlYear_nc.SelectedValue.ToInt();
                    if (txtSelfLimit.Text != "" & txtSelfLimit.Text != "Unlimited")
                        objMedicalAllowance.SelfLimit = txtSelfLimit.Text.ToDecimal();
                    if (txtFamilyLimit.Text != "")
                        objMedicalAllowance.FamilyLimit = txtFamilyLimit.Text.ToDecimal();
                    objMedicalAllowance.Remarks = txtMedicalRemarks.Text;
                    if (txtMaternityLimit.Text != "")
                        objMedicalAllowance.MaternityLimit = txtMaternityLimit.Text.ToDecimal();
                }
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void EmployeeHKInfoSave(ArrayList empInfo)
        {
            CustomList<EmployeeHKInfo> EmpHKList = new CustomList<EmployeeHKInfo>();
            foreach (ASL.Hr.DAO.EntityList M in _EntityList)
            {
                if (M.IsUsed)
                {
                    DropDownList ddl = new DropDownList();
                    EmployeeHKInfo newEHKI = new EmployeeHKInfo();
                    ddl = (DropDownList)Panel1.FindControl("ddl" + M.EntityName.ToString());
                    if (ddl.SelectedValue == "") continue;
                    newEHKI.HKID = ddl.SelectedValue.ToInt();
                    newEHKI.HKName = M.EntityName.ToString();
                    EmpHKList.Add(newEHKI);
                }
            }
            var empHKInfoList = (CustomList<EmployeeHKInfo>)EmpHKList;
            empInfo.Add(empHKInfoList);
        }
        private void SetOfficialInfo(HRM_Emp emp)
        {
            try
            {
                emp.DOJ = txtDOJ.Text.ToString().ToDateTime();
                emp.DOC = txtDOC.Text.ToString().ToDateTime();
                emp.DOS = txtDOS.Text.ToString().ToDateTime();
                emp.DOR = txtRetairmentDate.Text.ToString().ToDateTime();
                emp.OfficialCellPhone = txtCellPhone.Text;
                emp.OfficialLandPhone = txtLandPhone.Text;
                emp.OfficialEmail = txtOfficialEmail.Text;
                emp.EndDate = txtEndDate.Text.ToDateTime(StaticInfo.GridDateFormat);
                emp.Vendor = ddlVendor.SelectedValue.IfEmptyOrNullThenNull();
                emp.VendorID = txtVendorID.Text;
                emp.NTID = txtNTId.Text;
                emp.AddedBy = CurrentUserSession.EmpKey.ToString();
                emp.DateAdded = DateTime.Now;
                if (emp.AddedBy.IsNullOrEmpty())
                    emp.UpdatedBy = CurrentUserSession.EmpKey.ToString();
                if (emp.DateAdded.IsNull())
                    emp.DateUpdated = DateTime.Now;
                emp.PunchCard = txtPunchCardNo.Text;
                emp.PunchCardNo2 = txtPunchCardNo2.Text;
                emp.Supervisor = hfSupervisorCode.Value.IfEmptyOrNullThenNull();
                emp.FunctionalBoss = hfFuctionalBossCode.Value.IfEmptyOrNullThenNull();
                emp.AdminBoss = hfAdminBossCode.Value.IfEmptyOrNullThenNull();
                emp.LeaveRuleKey = ddlLeaveRule.SelectedValue.ToInt();
                emp.EmpType = ddlEmployeeType_nc.SelectedValue.ToInt();
                emp.Note = txtDescription.Text;
                emp.IsShiftRule = chkShiftRuleApplicable.Checked;
                if (emp.IsShiftRule == true)
                {
                    emp.ShiftID = 0;
                    emp.ShiftRuleKey = ddlShiftRuleCode.SelectedValue.ToInt() == -1 ? 0 : ddlShiftRuleCode.SelectedValue.ToInt();
                }
                else
                {
                    emp.ShiftID = ddlShiftPlan.SelectedValue.ToInt() == -1 ? 0 : ddlShiftPlan.SelectedValue.ToInt();
                    emp.ShiftRuleKey = 0;
                }

                //ddlShiftPlan.SelectedValue.ToInt();

                emp.StartDate = txtStartDate.Text.ToString().ToDateTime();
                emp.IsOT = chkOT.Checked;
                emp.OTEntitleDate = txtOTEntitleDate.Text.ToString().ToDateTime();
                emp.IsOffDayOT = chkOffDayOT.Checked;
                emp.IsHolidayBenefit = chkHolidayBenefit.Checked;
                if (chkPF.Checked)
                {
                    emp.IsPF = chkPF.Checked;
                    emp.PFEntitleDate = txtPFEntitleDate.Text.ToString().ToDateTime();
                    emp.PFCompany = ddlPFCompany.SelectedValue.ToInt();
                    emp.PFNominee = txtPFNominee.Text;
                    emp.PFAccNo = txtPFAccNo.Text;
                    emp.PFNomineeRelation = txtPFRelation.Text;
                    emp.AddressOfNominee = txtPFNomineeAdd.Text;
                }
                if (chkInsuranceInfo.Checked)
                {
                    emp.IsInsurance = chkInsuranceInfo.Checked;
                    emp.InsuranceEntitleDate = txtInsuranceEntitleDate.Text.ToString().ToDateTime();
                    emp.InsuranceCompany = ddlInsuranceCompany.SelectedValue.ToInt();
                    emp.InsuranceNominee = txtInsuranceNominee.Text;
                }
                //Start Reference
                emp.Reference1 = txtReference1.Text;
                emp.Relation1 = txtRelation1.Text;
                emp.Reference2 = txtReference2.Text;
                emp.Relation2 = txtRelation2.Text;
                //End Reference
                //Medical Insurance

                //End
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        override protected void OnInit(EventArgs e)
        {
            CustomList<ASL.Hr.DAO.HouseKeepingValue> HkList = ManagerHKEntry.GetAllOfficialInfo();
            _EntityList = ManagerEntity.GetAllEntityListForOfficialInfo();
            int c = 0;
            foreach (ASL.Hr.DAO.EntityList M in _EntityList)
            {
                if (M.FieldType == 1)
                {
                    Label lb;
                    Label lfs;
                    TextBox txt;
                    lb = new Label();
                    lfs = new Label();
                    txt = new TextBox();
                    lb.ID = "lav" + M.EntityName.ToString();
                    lb.Text = M.EntityName;
                    lb.Font.Size = 10;
                    lb.Width = 85;
                    lb.CssClass.PadLeft(5);
                    //lb.BackColor.
                    lfs.Width = 25;
                    lb.CssClass.PadLeft(1);
                    txt.ID = "txt" + M.EntityName;
                    txt.Width = 130;
                    //txt.CssClass("date-picker");
                    txt.Attributes.Add("class", "date-picker");
                    Panel1.Controls.Add(lb);
                    Panel1.Controls.Add(txt);
                    c = c + 2;
                    if ((c % 6) == 0)
                    {
                        Panel1.Controls.Add(new LiteralControl("<br/><br/>"));

                    }
                    else if ((c % 2) == 0 || (c % 4) == 0)
                    {
                        Panel1.Controls.Add(lfs);

                    }


                }
                else if (M.FieldType == 2)
                {

                    Label lb;
                    Label lfs;
                    DropDownList ddl;
                    lb = new Label();
                    ddl = new DropDownList();
                    lb.ID = "lvl" + M.EntityName.ToString();
                    lb.Text = M.EntityName;
                    lb.Width = 85;
                    lfs = new Label();
                    lfs.Width = 25;
                    lfs.CssClass.PadLeft(5);
                    lb.CssClass.PadLeft(10);
                    ddl.ID = "ddl" + M.EntityName.ToString();

                    // User Defined Field
                    ddl.DataSource = HkList.FindAll(f => f.EntityID == M.EntityID);
                    ddl.DataTextField = "HkName";
                    ddl.DataValueField = "HkID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    ddl.SelectedIndex = 0;
                    ddl.Width = 135;
                    ddl.Attributes.Add("class", "drpdynamic");
                    ddl.CssClass.PadLeft(1);

                    Panel1.Controls.Add(lb);
                    Panel1.Controls.Add(ddl);
                    c = c + 2;
                    if ((c % 6) == 0)
                    {
                        Panel1.Controls.Add(new LiteralControl("<br/><br/>"));
                    }
                    else if ((c % 2) == 0 || (c % 4) == 0)
                    {
                        Panel1.Controls.Add(lfs);

                    }
                }
                else if (M.FieldType == 3)
                {
                    Label lb;
                    Label lfs;
                    TextBox txt;
                    lb = new Label();
                    lfs = new Label();
                    txt = new TextBox();
                    lb.ID = "lav" + M.EntityName.ToString();
                    lb.Text = M.EntityName;
                    lb.Font.Size = 10;
                    lb.Width = 85;
                    lb.CssClass.PadLeft(5);
                    //lb.BackColor.
                    lfs.Width = 25;
                    lb.CssClass.PadLeft(1);
                    txt.ID = "txt" + M.EntityName;
                    txt.Width = 130;
                    // txt.CssClass.PadRight(3);
                    Panel1.Controls.Add(lb);
                    Panel1.Controls.Add(txt);
                    c = c + 2;
                    if ((c % 6) == 0)
                    {
                        Panel1.Controls.Add(new LiteralControl("<br/><br/>"));

                    }
                    else if ((c % 2) == 0 || (c % 4) == 0)
                    {
                        Panel1.Controls.Add(lfs);

                    }


                }

            }

            base.OnInit(e);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var empInfo = new ArrayList();

                EmployeeGeneralInfo empGeneralInfo = ctrlEmployeeGeneralInfo as EmployeeGeneralInfo;
                empGeneralInfo.UpdateEmpGeneralInfo(empInfo);
                CustomList<HRM_Emp> empList = (CustomList<HRM_Emp>)empInfo[0];
                SetOfficialInfo(empList[0]);

                EmployeeAddressInformation empAddrInfo = ctrlEmployeeAddressInfo as EmployeeAddressInformation;
                empAddrInfo.UpdateEmpAddr(empInfo);

                CustomList<JobResponsibility> ResponsibilityList = JobResponsibilityList;
                empInfo.Add(ResponsibilityList);

                EmployeeEducationInformation empEdu = ctrlEmployeeEducationInfo as EmployeeEducationInformation;
                empEdu.SaveEmpEducationInfo(empInfo);

                EmpHistory empHist = ctrlEmpHistory as EmpHistory;
                empHist.Update(empInfo);

                EmpAttachmentInfo empFile = ctrlEmpAttachmentInfo as EmpAttachmentInfo;
                empFile.Update(empInfo);

                EmployeeHKInfoSave(empInfo);

                ucSalaryInfo empSalary = ctrlSalaryInfo as ucSalaryInfo;
                empSalary.Save(empInfo);

                ucLanguage empLanguage = ctrlLanguage as ucLanguage;
                empLanguage.Save(empInfo);

                CustomList<HRM_EmpFamDet> FamilyDetList = EmpFamDetList;
                empInfo.Add(FamilyDetList);

                CustomList<MedicalReinSetup> lstMedicalAllowance = MedicalAllowanceSetList;
                if (lstMedicalAllowance.Count == 0)
                {
                    MedicalReinSetup newSetup = new MedicalReinSetup();
                    lstMedicalAllowance.Add(newSetup);
                }
                SetDataMedicalAllowance(ref lstMedicalAllowance);
                if (lstMedicalAllowance[0].FYKey == 0)
                    lstMedicalAllowance = new CustomList<MedicalReinSetup>();
                empInfo.Add(lstMedicalAllowance);

                _empManager.SaveEmployeeInfo(empInfo, "update");

                this.SuccessMessage = (StaticInfo.UpdatedSuccessfullyMsg);
            }

            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeAddressInformation empAddrInfo = ctrlEmployeeAddressInfo as EmployeeAddressInformation;
                empAddrInfo.DeleteEmpAddr();

                EmployeeEducationInformation empEdu = ctrlEmployeeEducationInfo as EmployeeEducationInformation;
                empEdu.Delete();

                EmpHistory empHist = ctrlEmpHistory as EmpHistory;
                empHist.Delete();

                EmpAttachmentInfo empFile = ctrlEmpAttachmentInfo as EmpAttachmentInfo;
                empFile.Delete();

                EmployeeGeneralInfo empGeneralInfo = ctrlEmployeeGeneralInfo as EmployeeGeneralInfo;
                empGeneralInfo.DeleteEmpGeneralInfo();

                this.SuccessMessage = (StaticInfo.DeletedSuccessfullyMsg);
                this.ClearControls();
            }

            catch (Exception ex)
            {
                this.ErrorMessage = ex.InnerException.Message;
            }
        }

        private void InitializeSession()
        {
            try
            {
                JobResponsibilityList = new CustomList<JobResponsibility>();
                EmployeeSkillInfoList = new CustomList<SkillInfo>();
                // EmployeeSkillInfoList = ManagerSkill.GetAllSkillInfo();
                EmployeeOtherSkillInfoList = new CustomList<OtherSkillInfo>();
                EmpFamDetList = new CustomList<HRM_EmpFamDet>();
                

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void InitializeCombo()
        {
            Label1.Visible = false;

            #region PF Company
            ddlPFCompany.DataSource = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.PFCompany);
            ddlPFCompany.DataTextField = "ElementName";
            ddlPFCompany.DataValueField = "ElementKey";
            ddlPFCompany.DataBind();
            ddlPFCompany.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
            #region Insurance Company
            ddlInsuranceCompany.DataSource = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.InsuranceCompany);
            ddlInsuranceCompany.DataTextField = "ElementName";
            ddlInsuranceCompany.DataValueField = "ElementKey";
            ddlInsuranceCompany.DataBind();
            ddlInsuranceCompany.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
            #region Shift Rule
            ddlShiftRuleCode.DataSource = _empManager.GetAllShiftRule();
            ddlShiftRuleCode.DataTextField = "ShiftRuleCode";
            ddlShiftRuleCode.DataValueField = "ShiftRuleKey";
            ddlShiftRuleCode.DataBind();
            ddlShiftRuleCode.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
            #region Shift Plan
            ddlShiftPlan.DataSource = _empManager.GetAllShift();
            ddlShiftPlan.DataTextField = "ALISE";
            ddlShiftPlan.DataValueField = "ShiftID";
            ddlShiftPlan.DataBind();
            ddlShiftPlan.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
            #region Leave Rule Detauls
            ddlLeaveRule.DataSource = _empManager.GetAllLeaveRuleMaster();
            ddlLeaveRule.DataTextField = "LeaveRuleCode";
            ddlLeaveRule.DataValueField = "LeaveRuleKey";
            ddlLeaveRule.DataBind();
            ddlLeaveRule.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
            #region Emp Type
            ddlEmployeeType_nc.DataSource = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.EmployeeType);
            ddlEmployeeType_nc.DataTextField = "ElementName";
            ddlEmployeeType_nc.DataValueField = "ElementKey";
            ddlEmployeeType_nc.DataBind();
            ddlEmployeeType_nc.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
            #region Fiscal Year
            ddlYear_nc.DataSource = _empManager.GetAllGen_FY();
            ddlYear_nc.DataTextField = "FYName";
            ddlYear_nc.DataValueField = "FYKey";
            ddlYear_nc.DataBind();
            #endregion
            #region Vendor
            ddlVendor.DataSource = _empManager.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.Vendor);
            ddlVendor.DataTextField = "ElementName";
            ddlVendor.DataValueField = "ElementKey";
            ddlVendor.DataBind();
            ddlVendor.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            #endregion
        }

        public void PopulteControl(HRM_Emp emp)
        {
            Session["EmpKey"] = emp.EmpKey;
            Label1.Visible = true;
            Label1.Text = _empManager.GetEmpInfoForShowingLevel(emp.EmpCode)[0].Level;
            EmployeeGeneralInfo empGeneralInfo = ctrlEmployeeGeneralInfo as EmployeeGeneralInfo;
            empGeneralInfo.PopulateControl(emp);
            PopulateOfficialInfo(emp);

            EmployeeAddressInformation empAddrInfo = ctrlEmployeeAddressInfo as EmployeeAddressInformation;
            empAddrInfo.PopulateControl();

            EmployeeEducationInformation empEdu = ctrlEmployeeEducationInfo as EmployeeEducationInformation;
            empEdu.PopulateControl();

            EmpHistory empHist = ctrlEmpHistory as EmpHistory;
            empHist.PopulateControl();

            EmpAttachmentInfo empFile = ctrlEmpAttachmentInfo as EmpAttachmentInfo;
            empFile.PopulateControl();

            PopulateEmpHKInfo(emp);

            ucSalaryInfo empSalary = ctrlSalaryInfo as ucSalaryInfo;
            empSalary.PopulateControl(emp, CurrentUserSession.UserCode);

            ucLanguage empLanguage = ctrlLanguage as ucLanguage;
            empLanguage.PopulateControl(emp.EmpKey);

            JobResponsibilityList = _empManager.GetAllJobResponsibility(emp.EmpKey);

            EmpFamDetList = _empManager.GetAllHRM_EmpFamDetByFamKey(emp.EmpKey);

            MedicalAllowanceSetList = _empManager.GetAllMedicalReinSetup(ddlYear_nc.SelectedValue, emp.EmpKey.ToString());
            if (MedicalAllowanceSetList.Count != 0)
                PopulateMedicalInfo(MedicalAllowanceSetList[0]);
            else txtSelfLimit.Text = "Unlimited";

        }
        private void PopulateMedicalInfo(MedicalReinSetup mAS)
        {
            try
            {
                txtSelfLimit.Text = mAS.SelfLimit.ToString() == "" || mAS.SelfLimit.ToString() == "0.00" ? "Unlimited" : mAS.SelfLimit.ToString();
                txtFamilyLimit.Text = mAS.FamilyLimit.ToString();
                txtMedicalRemarks.Text = mAS.Remarks;
                txtMaternityLimit.Text = mAS.MaternityLimit.ToString();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void PopulateEmpHKInfo(HRM_Emp emp)
        {
            CustomList<EmployeeHKInfo> EmpWiseHKInfoList = _empManager.GetAllEmployeeHKInfo(emp.EmpKey);
            foreach (EmployeeHKInfo eHKI in EmpWiseHKInfoList)
            {
                DropDownList ddl = new DropDownList();
                ddl = (DropDownList)Panel1.FindControl("ddl" + eHKI.HKName.ToString());
                ddl.SelectedValue = eHKI.HKID.ToString();
            }
        }
        private void PopulateOfficialInfo(HRM_Emp emp)
        {
            try
            {

                int ServiceLength = 0;
                txtDOJ.Text = emp.DOJ.ToShortDateString() == "1/1/0001" ? "" : emp.DOJ.ToShortDateString();
                ServiceLength = DateTime.Now.Subtract(DateTime.Parse(txtDOJ.Text)).Days;
                txtServiceLength.Text = (ServiceLength / 365).ToString() + " Y(s) " + ((ServiceLength % 365) / 30).ToString() + " M(s) " + ((ServiceLength % 365) % 30).ToString() + " D(s)";
                txtDOC.Text = emp.DOC.ToShortDateString() == "1/1/0001" ? "" : emp.DOC.ToShortDateString();
                txtDOS.Text = emp.DOS.ToShortDateString() == "1/1/0001" ? "" : emp.DOS.ToShortDateString();
                txtRetairmentDate.Text = emp.DOR.ToShortDateString() == "1/1/0001" ? "" : emp.DOR.ToShortDateString();
                txtCellPhone.Text = emp.OfficialCellPhone;
                txtLandPhone.Text = emp.OfficialLandPhone;
                txtOfficialEmail.Text = emp.OfficialEmail;
                if (emp.EmpType != 0 && emp.EmpType != -1)
                    //  ddlEmployeeType_nc.SelectedValue = ddlEmployeeType_nc.Items.FindByValue(emp.EmpType.ToString()) == null ? "90" : ddlEmployeeType_nc.Items.FindByValue(emp.EmpType.ToString()).Value;
                    ddlEmployeeType_nc.SelectedValue = ddlEmployeeType_nc.Items.FindByValue(emp.EmpType.ToString()).Value;
                else ddlEmployeeType_nc.SelectedIndex = 0;
                if (ddlEmployeeType_nc.SelectedValue == "90")
                {
                    txtRetairmentDate.Enabled = true;
                    TextBox DOB = (TextBox)ctrlEmployeeGeneralInfo.FindControl("txtDateOfBirth");
                    txtRetairmentDate.Text =DOB.Text.IsDate() ? DateTime.Parse(DOB.Text).AddYears(59).ToShortDateString() : "";
                    txtRetairmentDate.Enabled = false;
                    ddlVendor.Enabled = false;
                    txtEndDate.Enabled = false;
                    txtVendorID.Enabled = false;

                }
                else
                {
                    txtRetairmentDate.Text = string.Empty;
                    ddlVendor.Enabled = true;
                    txtEndDate.Enabled = true;
                    txtVendorID.Enabled = true;
                }
                txtEndDate.Text = emp.EndDate.ToShortDateString() == "1/1/0001" ? "" : emp.EndDate.ToShortDateString();
                txtNTId.Text = emp.NTID;
                if (emp.Vendor != 0)
                    ddlVendor.SelectedValue = ddlVendor.Items.FindByValue(emp.Vendor.ToString()) == null ? "" : ddlVendor.Items.FindByValue(emp.Vendor.ToString()).Value;
                txtVendorID.Text = emp.VendorID;
                txtPunchCardNo.Text = emp.PunchCard;
                txtPunchCardNo2.Text = emp.PunchCardNo2;
                hfSupervisorCode.Value = emp.Supervisor.ToString();
                HRM_Emp supervisor = new HRM_Emp();
                supervisor = _empManager.GetReportingBoss(Convert.ToInt64(emp.Supervisor));
                txtSupervisor.Text = supervisor.EmpName;
                txtSupervisorDesig.Text = supervisor.Designation;
                hfFuctionalBossCode.Value = emp.FunctionalBoss.ToString();
                supervisor = _empManager.GetReportingBoss(Convert.ToInt64(emp.FunctionalBoss));
                txtFunctionalBoss.Text = supervisor.EmpName;
                txtFunctionalBossDesig.Text = supervisor.Designation;
                hfAdminBossCode.Value = emp.AdminBoss.ToString();
                if (emp.LeaveRuleKey != 0)
                    ddlLeaveRule.SelectedValue = ddlLeaveRule.Items.FindByValue(emp.LeaveRuleKey.ToString()) == null ? "" : ddlLeaveRule.Items.FindByValue(emp.LeaveRuleKey.ToString()).Value;
                supervisor = _empManager.GetReportingBoss(Convert.ToInt64(emp.AdminBoss));
                txtAdminBoss.Text = supervisor.EmpName;
                txtAdminBossDesig.Text = supervisor.Designation;
                txtDescription.Text = emp.Note;
                if (emp.ShiftID != 0)
                    ddlShiftPlan.SelectedValue = ddlShiftPlan.Items.FindByValue(emp.ShiftID.ToString()) == null ? "" : ddlShiftPlan.Items.FindByValue(emp.ShiftID.ToString()).Value;

                txtStartDate.Text = emp.StartDate.ToShortDateString() == "1/1/0001" ? "" : emp.StartDate.ToShortDateString();
                if (emp.IsShiftRule)
                {
                    chkShiftRuleApplicable.Checked = emp.IsShiftRule;
                    ddlShiftRuleCode.Enabled = true;
                    txtStartDate.Enabled = true;
                    ddlShiftPlan.Enabled = false;
                    if (emp.ShiftRuleKey != 0)
                        ddlShiftRuleCode.SelectedValue = emp.ShiftRuleKey.ToString(); //ddlShiftRuleCode.Items.FindByValue(emp.ToString()) == null ? "" : ddlShiftRuleCode.Items.FindByValue(emp.ShiftRuleKey.ToString()).Value;

                }
                else
                {
                    chkShiftRuleApplicable.Checked = emp.IsShiftRule;
                    ddlShiftRuleCode.Enabled = false;
                    txtStartDate.Enabled = true;
                    ddlShiftPlan.Enabled = true;
                }
                if (emp.IsOT)
                {
                    chkOT.Checked = emp.IsOT;
                    txtOTEntitleDate.Enabled = true;
                    txtOTEntitleDate.Text = emp.OTEntitleDate.ToShortDateString();
                }
                chkOffDayOT.Checked = emp.IsOffDayOT;
                chkHolidayBenefit.Checked = emp.IsHolidayBenefit;
                if (emp.IsPF)
                {
                    chkPF.Checked = emp.IsPF;
                    txtPFEntitleDate.Enabled = true;
                    ddlPFCompany.Enabled = true;
                    txtPFNominee.Enabled = true;
                    txtPFAccNo.Enabled = true;
                    txtPFRelation.Enabled = true;
                    txtPFNomineeAdd.Enabled = true;
                    txtPFEntitleDate.Text = emp.PFEntitleDate.ToShortDateString();
                    ddlPFCompany.SelectedValue = ddlPFCompany.Items.FindByValue(emp.PFCompany.ToString()) == null ? "" : ddlPFCompany.Items.FindByValue(emp.PFCompany.ToString()).Value;
                    txtPFNominee.Text = emp.PFNominee;
                    txtPFAccNo.Text = emp.PFAccNo;
                    txtPFRelation.Text = emp.PFNomineeRelation;
                    txtPFNomineeAdd.Text = emp.AddressOfNominee;
                }
                if (emp.IsInsurance)
                {
                    chkInsuranceInfo.Checked = emp.IsInsurance;
                    txtInsuranceEntitleDate.Enabled = true;
                    ddlInsuranceCompany.Enabled = true;
                    txtInsuranceNominee.Enabled = true;
                    txtInsuranceEntitleDate.Text = emp.InsuranceEntitleDate.ToShortDateString();
                    ddlInsuranceCompany.SelectedValue = ddlInsuranceCompany.Items.FindByValue(emp.InsuranceCompany.ToString()) == null ? "" : ddlInsuranceCompany.Items.FindByValue(emp.InsuranceCompany.ToString()).Value;
                    txtInsuranceNominee.Text = emp.InsuranceNominee;
                }
                //Start Reference
                txtReference1.Text = emp.Reference1;
                txtRelation1.Text = emp.Relation1;
                txtReference2.Text = emp.Reference2;
                txtRelation2.Text = emp.Relation2;
                //End Reference
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        private void OfficialInfo(HRM_Emp emp)
        {
            try
            {
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ClearControls()
        {
            try
            {
                FormUtil.ClearForm(this, FormClearOptions.ClearAll, true);
                InitializeSession();
                Session["EmpKey"] = null;
                Image img = (Image)ctrlEmployeeGeneralInfo.FindControl("ctrlPictureUpload").FindControl("imgEmp");
                Image signature = (Image)ctrlEmployeeGeneralInfo.FindControl("imgSignature");
                img.ImageUrl = null;
                signature.ImageUrl = null;
                EmployeeAddressInformation empAddrInfo = ctrlEmployeeAddressInfo as EmployeeAddressInformation;
                empAddrInfo.InitializeSession();
                EmployeeEducationInformation empEdu = ctrlEmployeeEducationInfo as EmployeeEducationInformation;
                empEdu.InitializeSession();
                EmpHistory empHist = ctrlEmpHistory as EmpHistory;
                empHist.InitializationSession();
                EmpAttachmentInfo empFile = ctrlEmpAttachmentInfo as EmpAttachmentInfo;
                empFile.ClearControl();
                ctrlLanguage.InitializationSession();
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnDelete.Visible = false;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        protected void btnFindSupervisor_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                TextBox empCodeTextBox = (TextBox)ctrlEmpSearch2.FindControl("txtSearch");
                string EmpCode = empCodeTextBox.Text;

                CustomList<HRM_Emp> EmpList = _salaryManager.doSearch(EmpCode);
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("EmpCode", "Employee Code");
                columns.Add("EmpName", "Employee Name");
                columns.Add("StaffCategory", "Staff Category");
                columns.Add("Designation", "Designation");
                columns.Add("Department", "Department");
                columns.Add("JobLocation", "Job Location");

                StaticInfo.SearchItem(EmpList, "Emp Info", "SearchSupervisor", SearchColumnConfig.GetColumnConfig(typeof(HRM_Emp), columns), 700, GlobalEnums.enumSearchType.StoredProcedured);
            }
            catch (SqlException ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnFunctionalBoss_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                TextBox empCodeTextBox = (TextBox)ctrlEmpSearch2.FindControl("txtSearch");
                string EmpCode = empCodeTextBox.Text;
                CustomList<HRM_Emp> EmpList = _salaryManager.doSearch(EmpCode);
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("EmpCode", "Employee Code");
                columns.Add("EmpName", "Employee Name");
                columns.Add("StaffCategory", "Staff Category");
                columns.Add("Designation", "Designation");
                columns.Add("Department", "Department");
                columns.Add("JobLocation", "Job Location");

                StaticInfo.SearchItem(EmpList, "Emp Info", "SearchFunctionalBoss", SearchColumnConfig.GetColumnConfig(typeof(HRM_Emp), columns), 700, GlobalEnums.enumSearchType.StoredProcedured);
            }
            catch (SqlException ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnAdminBoss_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                TextBox empCodeTextBox = (TextBox)ctrlEmpSearch2.FindControl("txtSearch");
                string EmpCode = empCodeTextBox.Text;
                CustomList<HRM_Emp> EmpList = _salaryManager.doSearch(EmpCode);
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("EmpCode", "Employee Code");
                columns.Add("EmpName", "Employee Name");
                columns.Add("StaffCategory", "Staff Category");
                columns.Add("Designation", "Designation");
                columns.Add("Department", "Department");
                columns.Add("JobLocation", "Job Location");

                StaticInfo.SearchItem(EmpList, "Emp Info", "SearchAdminBoss", SearchColumnConfig.GetColumnConfig(typeof(HRM_Emp), columns), 700, GlobalEnums.enumSearchType.StoredProcedured);
            }
            catch (SqlException ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }

    }
}