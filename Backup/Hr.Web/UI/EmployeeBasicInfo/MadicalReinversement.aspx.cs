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
using System.Data.SqlClient;

namespace Hr.Web.UI.EmployeeBasicInfo
{
    public partial class MadicalReinverseement : PageBase
    {
        MedicalReinversementManager manager;
        #region Ctor
        public MadicalReinverseement()
        {
            manager = new MedicalReinversementManager();
            RequiresAuthorization = true;
        }
        #endregion
        #region Sesson Variable
        private CustomList<MedicalReinTrans> _MedicalAllowanceTransList
        {
            get
            {
                if (Session["MadicalReinversement_MedicalAllowanceTransList"] == null)
                    return new CustomList<MedicalReinTrans>();
                else
                    return (CustomList<MedicalReinTrans>)Session["MadicalReinversement_MedicalAllowanceTransList"];
            }
            set
            {
                Session["MadicalReinversement_MedicalAllowanceTransList"] = value;
            }
        }
        private CustomList<HRM_EmpFamDet> EmpFamDetList
        {
            get
            {
                if (Session["MadicalReinversement_EmpFamDetList"] == null)
                    return new CustomList<HRM_EmpFamDet>();
                else
                    return (CustomList<HRM_EmpFamDet>)Session["MadicalReinversement_EmpFamDetList"];
            }
            set
            {
                Session["MadicalReinversement_EmpFamDetList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeControls();
                InitializeSession();
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (eventTarget.Equals("SearchEmployee"))
                {
                    string EmployeeCode = ((TextBox)this.Header1.FindControl("txtSearch")).Text.ToString();
                }
            }


        }
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                // if (EmpFamDetList.Count == 0)
                EmpFamDetList = new CustomList<HRM_EmpFamDet>();
                // if (_MedicalAllowanceTransList.Count == 0)
                _MedicalAllowanceTransList = new CustomList<MedicalReinTrans>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public void ClearControls()
        {
            try
            {

                //  FormUtil.ClearForm(this, FormClearOptions.ClearAll, false);
                txtEmployeeName.Text = string.Empty;
                txtDesignation.Text = string.Empty;
                txtStaffCategory.Text = string.Empty;
                txtDOJ.Text = string.Empty;
                txtLeaveRule.Text = string.Empty;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public void SetDateFromObjToControl(string EmployeeCode)
        {
            //_RunnignEmpInfo=
            CustomList<LeaveTransApproved> _RunnignEmpInfo = manager.GetLeaveEligibleEmp(EmployeeCode);
            if (_RunnignEmpInfo.Count != 0)
            {
                txtEmployeeName.Text = _RunnignEmpInfo[0].EmpName;
                txtDesignation.Text = _RunnignEmpInfo[0].Designation;
                txtDOJ.Text = _RunnignEmpInfo[0].DOJ.ToShortDateString();
                txtStaffCategory.Text = _RunnignEmpInfo[0].StaffCategory;
                txtLeaveRule.Text = _RunnignEmpInfo[0].LeaveRuleKey.ToString();
                imgGarment.ImageUrl = ResolveUrl(_RunnignEmpInfo[0].EmpPicture);
                hfEmpKey.Value = _RunnignEmpInfo[0].EmpKey.ToString();

                EmpFamDetList = manager.GetAllHRM_EmpFamDetByFamKey(_RunnignEmpInfo[0].EmpKey);
                MedicalReinSetup mASetup = manager.GetAllMedicalBalance(ddlFiscalYear.SelectedValue, _RunnignEmpInfo[0].EmpKey.ToString());
                txtSelfLimit.Text = mASetup.SelfLimit.ToString() == "" || mASetup.SelfLimit  ==0 ? "Unlimited" : mASetup.SelfLimit.ToString();
                txtFamilyLimit.Text = mASetup.FamilyLimit.ToString();
                txtSelfPaidAmount.Text = mASetup.SelfPaid.ToString();
                txtFamilyPaidAmount.Text = mASetup.FamilyPaid.ToString();
                txtFamilyBalance.Text = (mASetup.FamilyLimit - mASetup.FamilyPaid).ToString();
                txtMaternityLimit.Text = mASetup.MaternityLimit.ToString();
                txtMaternityConsume.Text = mASetup.MaternityPaid.ToString();
                txtMaternityBalance.Text = (mASetup.MaternityLimit - mASetup.MaternityPaid).ToString();

                _MedicalAllowanceTransList = manager.GetAllMedicalReinTrans(_RunnignEmpInfo[0].EmpKey.ToString(), ddlFiscalYear.SelectedValue);
            }
        }
        private void InitializeControls()
        {
            try
            {
                CustomList<Gen_FY> FiscalYearList = manager.GetAllGen_FY();
                ddlFiscalYear.DataSource = FiscalYearList;
                ddlFiscalYear.DataTextField = "FYName";
                ddlFiscalYear.DataValueField = "FYKey";
                ddlFiscalYear.DataBind();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<MedicalReinTrans> lstMedicalAllowance = (CustomList<MedicalReinTrans>)_MedicalAllowanceTransList;
                Decimal familyLimit = 0.0M;
                Decimal maternityLimit = 0.0M;
                CustomList<MedicalReinTrans> FamilyLimitList=lstMedicalAllowance.FindAll(f=>f.Type==2);
                CustomList<MedicalReinTrans> MaternityLimitList = lstMedicalAllowance.FindAll(f => f.Type == 3);
                foreach (MedicalReinTrans mT in FamilyLimitList)
                {
                    familyLimit = familyLimit + mT.Amount;
                }
                foreach (MedicalReinTrans mT in MaternityLimitList)
                {
                    maternityLimit = maternityLimit + mT.Amount;
                }
                if (familyLimit > Convert.ToDecimal(txtFamilyLimit.Text))
                {
                    this.ErrorMessage = "Family consumtion amount must be less than or equal to family amount!";
                    return;
                }
                if (maternityLimit > Convert.ToDecimal(txtMaternityLimit.Text))
                {
                    this.ErrorMessage = "Maternity consumtion amount must be less than or equal to Maternity amount!";
                    return;
                }
                if (lstMedicalAllowance.IsNotNull())
                {
                    if (!CheckUserAuthentication(lstMedicalAllowance)) return;
                    CustomList<MedicalReinTrans> SavedMedicalAllowances = lstMedicalAllowance.FindAll(f => f.IsAdded || f.IsModified);
                    foreach (MedicalReinTrans mT in SavedMedicalAllowances)
                    {
                        if (mT.IsAdded)
                        {
                            mT.EmpKey = Convert.ToInt64(hfEmpKey.Value); 
                            mT.FYKey = ddlFiscalYear.SelectedValue.ToInt();
                        }
                    }
                    manager.SaveMedicalAllowance(ref SavedMedicalAllowances);
                    this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                }
            }
            catch (SqlException ex)
            {
                this.ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
        }

    }
}
