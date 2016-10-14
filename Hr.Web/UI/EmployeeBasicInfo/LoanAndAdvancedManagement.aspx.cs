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
using System.Text;

namespace Hr.Web.UI.EmployeeBasicInfo
{
    public partial class LoanAndAdvancedManagement : PageBase
    {
        public readonly EmployeeManager _empManager = new EmployeeManager();
        public readonly LoanOrAdvanceManager _manager = new LoanOrAdvanceManager();
        #region Session Variables
        private CustomList<HRM_Emp> EmployeeList
        {
            get
            {
                if (Session["LoanAndAdvancedManagement_EmployeeList"] == null)
                    return new CustomList<HRM_Emp>();
                else
                    return (CustomList<HRM_Emp>)Session["LoanAndAdvancedManagement_EmployeeList"];
            }
            set
            {
                Session["LoanAndAdvancedManagement_EmployeeList"] = value;
            }
        }
        private CustomList<LoanDefination> LoanMasterList
        {
            get
            {
                if (Session["LoanAndAdvancedManagement_LoanMasterList"] == null)
                    return new CustomList<LoanDefination>();
                else
                    return (CustomList<LoanDefination>)Session["LoanAndAdvancedManagement_LoanMasterList"];
            }
            set
            {
                Session["LoanAndAdvancedManagement_LoanMasterList"] = value;
            }
        }
        private CustomList<LoanProcess> LoanProcessList
        {
            get
            {
                if (Session["LoanAndAdvancedManagement_LoanProcessList"] == null)
                    return new CustomList<LoanProcess>();
                else
                    return (CustomList<LoanProcess>)Session["LoanAndAdvancedManagement_LoanProcessList"];
            }
            set
            {
                Session["LoanAndAdvancedManagement_LoanProcessList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                //string script = "$(document).ready(function () { $('[id*=btnDelete]').click(); });";
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
                txtInterestRate.Attributes.Add("onChange", "InterestRate()");
                InitializeCombo();
                InitializeSession();
                EmployeeList = new CustomList<HRM_Emp>();
                EmployeeList = _empManager.GetEmpInfo("");
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (Request["__EVENTTARGET"] == "Employee")
                {
                    var empCode = Request["__EVENTARGUMENT"];
                    CustomList<HRM_Emp> empList = _empManager.GetEmpGeneralInfo1(empCode);
                    if (empList.Count != 0)
                    {
                        PopulateGeneralInfo(empList[0]);
                    }
                }
                else if (eventTarget == "SearchLoan")
                {
                    LoanDefination searchLoan = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as LoanDefination;
                    if (searchLoan.IsNotNull())
                    {
                        txtLoanOrAdvanceCode.Text = searchLoan.LoanCode;
                        ddlLoanType.SelectedValue = ddlLoanType.Items.FindByValue(searchLoan.LoanTypeID.ToString()) == null ? "" : ddlLoanType.Items.FindByValue(searchLoan.LoanTypeID.ToString()).Value;
                        txtInterestRate.Text = searchLoan.InterestRate.ToString();
                        txtCanctionAmount.Text = searchLoan.SanctionAmount.ToString();
                        txtFirstInstallmentDate.Text = searchLoan.IstDisbursemenDate.ToShortDateString();
                        ddlReportingHead.SelectedValue = ddlReportingHead.Items.FindByValue(searchLoan.SalaryHeadID.ToString()) == null ? "" : ddlReportingHead.Items.FindByValue(searchLoan.SalaryHeadID.ToString()).Value;
                        txtMonthInterval.Text = searchLoan.MonthInterval.ToString();
                        CustomList<HRM_Emp> empList = _empManager.GetEmpGeneralInfo1(searchLoan.EmployeeCode);
                        if (empList.Count != 0)
                        {
                            PopulateGeneralInfo(empList[0]);
                        }
                        #region Detail
                        LoanProcessList = _manager.GetAllLoanProcess(searchLoan.LoanCode);
                        #endregion
                    }
                }
            }
        }
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                LoanMasterList = new CustomList<LoanDefination>();
                LoanProcessList = new CustomList<LoanProcess>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void InitializeCombo()
        {
            try
            {
                //Salary Head List
                ddlReportingHead.DataSource = _manager.GetAllSalaryHead();
                ddlReportingHead.DataTextField = "HeadName";
                ddlReportingHead.DataValueField = "SalaryHeadKey";
                ddlReportingHead.DataBind();
                ddlReportingHead.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlReportingHead.SelectedIndex = 0;

                //Loan Type List
                ddlLoanType.DataSource = _manager.GetAllGen_LookupEnt();
                ddlLoanType.DataTextField = "ElementName";
                ddlLoanType.DataValueField = "ElementKey";
                ddlLoanType.DataBind();
                ddlLoanType.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlLoanType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void PopulateGeneralInfo(HRM_Emp emp)
        {
            try
            {
                txtEmpCode.Text = emp.EmpCode;
                txtEmpName.Text = emp.EmpName;
                //txtNickName.Text = emp.EmpNickName;
                txtDateOfJoining.Text = emp.DOJ.ToShortDateString();
                txtDateOfConformation.Text = emp.DOC.ToShortDateString();
                txtNationality.Text = emp.NationalityName;
                txtEmpStatus.Text = emp.EmpTypeName;
                txtPunchCardNo.Text = emp.PunchCard;
                txtNationalIDCard.Text = emp.NationalID;
                imgPicture.ImageUrl = ResolveUrl(emp.EmpPicture);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void SetDataFromControlToObj(ref CustomList<LoanDefination> lstLoanDefinitionMaster)
        {
            try
            {
                LoanDefination obj = lstLoanDefinitionMaster[0];
                obj.EmployeeCode = txtEmpCode.Text;
                obj.LoanTypeID = ddlLoanType.SelectedValue.IfEmptyOrNullThenNull();
                obj.SanctionAmount = txtCanctionAmount.Text.ToDecimal();
                obj.IstDisbursemenDate = txtFirstInstallmentDate.Text.ToDateTime();
                obj.InterestRate = txtInterestRate.Text.ToDecimal();
                obj.InterestCollectionInstallmentNo = txtInterestCollectionInsNo.Text.ToInt();
                obj.MonthInterval = txtMonthInterval.Text.ToInt();
                obj.SalaryHeadID = ddlReportingHead.SelectedValue.IfEmptyThenZero();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<LoanDefination> lstLoanMasterList = (CustomList<LoanDefination>)LoanMasterList;
                if (lstLoanMasterList.Count == 0)
                {
                    LoanDefination newLoanDefinition = new LoanDefination();
                    lstLoanMasterList.Add(newLoanDefinition);
                }
                SetDataFromControlToObj(ref lstLoanMasterList);
                CustomList<LoanProcess> lstLoanProcess = (CustomList<LoanProcess>)HttpContext.Current.Session["LoanAndAdvancedManagement_LoanProcessList"];
                _manager.SaveLoan(ref lstLoanMasterList, ref lstLoanProcess);
                if (lstLoanMasterList.Count != 0)
                {
                    txtLoanOrAdvanceCode.Text = _manager.LoanCode;
                    this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                }
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
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<LoanDefination> items = _manager.GetAllLoanDefination();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("LoanCode", "Loan Code");

                StaticInfo.SearchItem(items, "Loan", "SearchLoan", ASL.Web.Framework.SearchColumnConfig.GetColumnConfig(typeof(LoanDefination), columns), 500);
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
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(1000);
                CustomList<LoanDefination> lstLoanDefinition = LoanMasterList;
                if (lstLoanDefinition.Count != 0)
                {
                    lstLoanDefinition.ForEach(f => f.Delete());
                    CustomList<LoanProcess> lstLoanProcess = LoanProcessList;
                    // if (CheckUserAuthentication(lstLoanDefinition, lstLoanProcess).IsFalse()) return;
                    _manager.DeletelstLoan(ref lstLoanDefinition, ref lstLoanProcess);
                    ClearControls();
                    this.SuccessMessage = (StaticInfo.DeletedSuccessfullyMsg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region All Methods
        private void ClearControls()
        {
            try
            {
                FormUtil.ClearForm(this, FormClearOptions.ClearAll, true);
                LoanProcessList = new CustomList<LoanProcess>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
    }
}