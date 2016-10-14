using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using ASL.DATA;
using ASL.Hr.BLL;
using ASL.Hr.DAO;
using ASL.STATIC;
using ASL.Web.Framework;

namespace Hr.Web.UI.LeaveManagement
{
    public partial class LeaveTransaction : PageBase
    {


        LeaveYearManager ManagerLeaveYear = new LeaveYearManager();
        LeaveSummeryManager ManagerLeaveSummery = new LeaveSummeryManager();
        LeaveTransApprovedMnager ManagerLeaveTrans = new LeaveTransApprovedMnager();
        public readonly MonthlySalarProcessManager _salaryManager = new MonthlySalarProcessManager();
        string LeaveYear = "";
        string EmployeeCode = "";
        #region Sesson Variable
        private CustomList<ASL.Hr.DAO.LeaveTransApproved> _LeaveTransactions
        {
            get
            {
                if (Session["LeaveTransaction_LeaveTransactions"] == null)
                    return new CustomList<ASL.Hr.DAO.LeaveTransApproved>();
                else
                    return (CustomList<ASL.Hr.DAO.LeaveTransApproved>)Session["LeaveTransaction_LeaveTransactions"];
            }
            set
            {
                Session["LeaveTransaction_LeaveTransactions"] = value;
            }
        }
        private CustomList<HourlyLeaveTrans> _HourlyLeaveTransactions
        {
            get
            {
                if (Session["LeaveTransaction_HourlyLeaveTransactions"] == null)
                    return new CustomList<HourlyLeaveTrans>();
                else
                    return (CustomList<HourlyLeaveTrans>)Session["LeaveTransaction_HourlyLeaveTransactions"];
            }
            set
            {
                Session["LeaveTransaction_HourlyLeaveTransactions"] = value;
            }
        }
        private CustomList<ASL.Hr.DAO.LeaveTransApproved> _LeaveTransactionsBack
        {
            get
            {
                if (Session["LeaveTransaction_LeaveTransactionsBack"] == null)
                    return new CustomList<ASL.Hr.DAO.LeaveTransApproved>();
                else
                    return (CustomList<ASL.Hr.DAO.LeaveTransApproved>)Session["LeaveTransaction_LeaveTransactionsBack"];
            }
            set
            {
                Session["LeaveTransaction_LeaveTransactionsBack"] = value;
            }
        }
        private CustomList<ASL.Hr.DAO.LeaveTransApproved> _RunnignEmpInfo
        {
            get
            {
                if (Session["LeaveTransaction_RunningEmpInfo"] == null)
                    return new CustomList<ASL.Hr.DAO.LeaveTransApproved>();
                else
                    return (CustomList<ASL.Hr.DAO.LeaveTransApproved>)Session["LeaveTransaction_RunningEmpInfo"];
            }
            set
            {
                Session["LeaveTransaction_RunningEmpInfo"] = value;
            }
        }
        private CustomList<ASL.Hr.DAO.LeaveTransApproved> _LeaveTransactionsToDelete
        {
            get
            {
                if (Session["LeaveTransaction_LeaveTransactionsToDelete"] == null)
                    return new CustomList<ASL.Hr.DAO.LeaveTransApproved>();
                else
                    return (CustomList<ASL.Hr.DAO.LeaveTransApproved>)Session["LeaveTransaction_LeaveTransactionsToDelete"];
            }
            set
            {
                Session["LeaveTransaction_LeaveTransactionsToDelete"] = value;
            }
        }
        private CustomList<HourlyLeaveTrans> _HourlyLeaveTransactionsToDelete
        {
            get
            {
                if (Session["LeaveTransaction_HourlyLeaveTransactionsToDelete"] == null)
                    return new CustomList<HourlyLeaveTrans>();
                else
                    return (CustomList<HourlyLeaveTrans>)Session["LeaveTransaction_HourlyLeaveTransactionsToDelete"];
            }
            set
            {
                Session["LeaveTransaction_HourlyLeaveTransactionsToDelete"] = value;
            }
        }
        private CustomList<ASL.Hr.DAO.LeaveSummery> _LeaveSummery
        {
            get
            {
                if (Session["LeaveTransaction_LeaveSummery"] == null)
                    return new CustomList<ASL.Hr.DAO.LeaveSummery>();
                else
                    return (CustomList<ASL.Hr.DAO.LeaveSummery>)Session["LeaveTransaction_LeaveSummery"];
            }
            set
            {
                Session["LeaveTransaction_LeaveSummery"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                InitializeSession();
                InitializeControls();
                leaveFromHome.Visible = false;
                string empcode = Request.QueryString.Get("empCodeForLeave");
                if (empcode.IsNotNullOrEmpty())
                {
                    Header1.Visible = false;
                    divTest.Style.Add("display", "none");
                    leaveFromHome.Visible = true;
                }
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (eventTarget.Equals("SearchEmployee"))
                {
                    string EmployeeCode = ((TextBox)this.Header1.FindControl("txtSearch")).Text.ToString();
                    this.IsPostBack.IsFalse();
                }
                else if (eventTarget.Equals("SelectGridRow"))
                {
                    String eventArgument = Request["__EVENTARGUMENT"].IsNullOrEmpty() ? String.Empty : Request["__EVENTARGUMENT"];
                    hidSelectedRow.Value = eventArgument;
                    LeaveTransApproved leaveTrans = _LeaveTransactions.Find(item => item.VID == eventArgument.ToInt());
                    CustomList<LeaveTransApproved> obj = new CustomList<LeaveTransApproved>();
                    if (leaveTrans.IsNotNull())
                    {
                        obj.Add(leaveTrans);
                    }

                    if (leaveTrans.IsNotNull())
                    {
                        Session["SelectedGridRow"] = leaveTrans;
                        _LeaveTransactionsToDelete = obj;
                        SetLeaveTransDateFromObjToControl(ref obj);
                    }
                }
                else if (eventTarget.Equals("SelectHourlyLeaveGridRow"))
                {
                    String eventArgument = Request["__EVENTARGUMENT"].IsNullOrEmpty() ? String.Empty : Request["__EVENTARGUMENT"];
                    hidSelectedRow.Value = eventArgument;
                    ASL.Hr.DAO.HourlyLeaveTrans HourlyLeaveTrans = _HourlyLeaveTransactions.Find(item => item.VID == eventArgument.ToInt());
                    CustomList<ASL.Hr.DAO.HourlyLeaveTrans> obj = new CustomList<ASL.Hr.DAO.HourlyLeaveTrans>();
                    if (HourlyLeaveTrans.IsNotNull())
                    {
                        obj.Add(HourlyLeaveTrans);
                    }

                    if (HourlyLeaveTrans.IsNotNull())
                    {
                        Session["SelectedGridRow"] = HourlyLeaveTrans;
                        _HourlyLeaveTransactionsToDelete = obj;
                        SetHourlyLeaveTransDataFromObjToControl(HourlyLeaveTrans);
                    }
                }
                else if (eventTarget.Equals("SearchSupervisor"))
                {
                    HRM_Emp searchEmp = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as HRM_Emp;
                    txtLeaveSubstitute.Text = searchEmp.EmpName;
                    hfLeaveSubstitute.Value = searchEmp.EmpCode;
                }
            }


        }
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                _LeaveTransactions = new CustomList<LeaveTransApproved>();
                _LeaveSummery = new CustomList<LeaveSummery>();
                _HourlyLeaveTransactions = new CustomList<HourlyLeaveTrans>();
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

                _LeaveTransactions = new CustomList<LeaveTransApproved>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void SetLeaveTransDateFromObjToControl(ref CustomList<LeaveTransApproved> PassedLeaveTrans)
        {
            if (PassedLeaveTrans[0].LeavePolicyID.IsNotNullOrEmpty())
                ddlLeaveType.SelectedValue = ddlLeaveType.Items.FindByValue(PassedLeaveTrans[0].LeavePolicyID) == null ? "" : ddlLeaveType.Items.FindByValue(PassedLeaveTrans[0].LeavePolicyID).Value;
            txtLeaveFrom.Text = PassedLeaveTrans[0].FromDate.ToShortDateString();
            txtLeaveTo.Text = PassedLeaveTrans[0].ToDate.ToShortDateString();
            txtDays.Text = PassedLeaveTrans[0].LeaveDays.ToString();
            txtReason.Text = PassedLeaveTrans[0].LeaveReason;
            txtAvailPlace.Text = PassedLeaveTrans[0].LeaveAvailPlace;
            txtAdditionalContact.Text = PassedLeaveTrans[0].Contact;
        }
        private void SetHourlyLeaveTransDataFromObjToControl(ASL.Hr.DAO.HourlyLeaveTrans objHourlyLeave)
        {
            try
            {
                if (objHourlyLeave.LeavePolicyID.IsNotNullOrEmpty())
                    ddlLeaveType.SelectedValue = ddlLeaveType.Items.FindByValue(objHourlyLeave.LeavePolicyID) == null ? "" : ddlLeaveType.Items.FindByValue(objHourlyLeave.LeavePolicyID).Value;
                txtWorkDate.Text = objHourlyLeave.LeaveDate.ToShortDateString();
                txtFrom.Text = objHourlyLeave.LeaveFrom;
                txtTo.Text = objHourlyLeave.LeaveTo;
                txtLeaveHours.Text = objHourlyLeave.TotalHour.ToString();
                txtReason.Text = objHourlyLeave.LeaveReason;
                txtAvailPlace.Text = objHourlyLeave.LeaveAvailPlace;
                txtAdditionalContact.Text = objHourlyLeave.ContactNo;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
        public void SetLeaveTransDateFromControlToObj(ref CustomList<LeaveTransApproved> PassedLeaveTrans, ref CustomList<HourlyLeaveTrans> HourlyLeaveTrans)
        {
            if (HourlyLeaveTrans.Count == 0)
            {
                LeaveTransApproved obj = PassedLeaveTrans[0];
                obj.EmpKey = _RunnignEmpInfo[0].EmpKey;
                obj.ShiftID = _RunnignEmpInfo[0].ShiftID;
                obj.LeaveYear = ddlLeaveYear.SelectedValue;
                obj.TransactionDate = DateTime.Now;
                obj.LeaveRuleKey = _RunnignEmpInfo[0].LeaveRuleKey;
                obj.LeavePolicyID = ddlLeaveType.SelectedValue;

                obj.LeaveType = ddlLeaveType.SelectedItem.ToString();
                obj.FromDate = txtLeaveFrom.Text.ToDateTime();
                obj.ToDate = txtLeaveTo.Text.ToDateTime();
                obj.LeaveDays = txtDays.Text.ToInt();
                obj.ApprovedFrom = obj.FromDate;
                obj.ApprovedTo = obj.ToDate;
                obj.ApprovedDays = obj.LeaveDays;
                obj.LeaveReason = txtReason.Text;
                obj.LeaveAvailPlace = txtAvailPlace.Text;
                obj.Contact = txtAdditionalContact.Text;
                obj.LeaveSubstitute = hfLeaveSubstitute.Value;
            }
            else
            {
                HourlyLeaveTrans obj = HourlyLeaveTrans[0];
                obj.EmpKey = _RunnignEmpInfo[0].EmpKey;
                obj.LeavePolicyID = ddlLeaveType.SelectedValue;
                obj.LeaveDate = txtWorkDate.Text.ToDateTime();
                obj.LeaveFrom = txtFrom.Text;
                obj.LeaveTo = txtTo.Text;
                obj.TotalHour = txtLeaveHours.Text.ToDecimal();
                obj.HRApprovedFrom = txtFrom.Text;
                obj.HRApprovedTo = txtTo.Text;
                obj.HRApprovedHour = obj.TotalHour;
                obj.LeaveReason = txtReason.Text;
                obj.LeaveAvailPlace = txtAvailPlace.Text;
                obj.ContactNo = txtAdditionalContact.Text;
                obj.LeaveSubstitute = hfLeaveSubstitute.Value;
            }
        }
        public void SetDateFromObjToControl(string EmployeeCode)
        {
            string LeaveYear = ddlLeaveYear.SelectedValue;
            _RunnignEmpInfo = ManagerLeaveTrans.GetLeaveEligibleEmp(EmployeeCode);
            if (_RunnignEmpInfo.Count != 0)
            {
                ClearLeaveControls();

                txtEmployeeName.Text = _RunnignEmpInfo[0].EmpName;
                txtDesignation.Text = _RunnignEmpInfo[0].Designation;
                txtDOJ.Text = _RunnignEmpInfo[0].DOJ.ToShortDateString();
                txtStaffCategory.Text = _RunnignEmpInfo[0].StaffCategory;
                txtLeaveRule.Text = _RunnignEmpInfo[0].LeaveRuleKey.ToString();
                imgGarment.ImageUrl = ResolveUrl(_RunnignEmpInfo[0].EmpPicture);

                hidSelectedRow.Value = "";
                _LeaveTransactionsToDelete = new CustomList<LeaveTransApproved>();
                CustomList<LeaveTransApproved> LT = ManagerLeaveTrans.GetEmpWiseAllLeaveTransApproved(LeaveYear, EmployeeCode);
                CustomList<LeaveSummery> LS = ManagerLeaveSummery.GetEmpWiseLeaveSummery(LeaveYear, EmployeeCode);
                _HourlyLeaveTransactions = ManagerLeaveSummery.GetAllHourlyLeaveTrans(ddlLeaveYear.SelectedValue.ToInt(), _RunnignEmpInfo[0].EmpKey);

                
                _LeaveTransactionsBack = LT;

                if (LS.Count != 0)
                {
                    ddlLeaveType.DataSource = LS;
                    ddlLeaveType.DataTextField = "LeaveType";
                    ddlLeaveType.DataValueField = "LeavePolicyID";
                    ddlLeaveType.DataBind();
                    ddlLeaveType.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    ddlLeaveType.SelectedIndex = 0;
                }

                if (LT.Count != 0)
                {
                    _LeaveTransactions = LT;
                }
                else
                {

                    _LeaveTransactions = new CustomList<LeaveTransApproved>();
                }
                if (LS.Count != 0)
                {
                    _LeaveSummery = LS;

                }
                else _LeaveSummery = new CustomList<LeaveSummery>();
            }
            else ((PageBase)this.Page).ErrorMessage = "Leave Rule Not Tagged. So, Employee Is NOT Eligible for Leave!!!";

        }
        private void InitializeControls()
        {
            try
            {
                CustomList<Gen_FY> LeaveYearList = ManagerLeaveYear.GetAllGen_FY();
                ddlLeaveYear.DataSource = LeaveYearList;
                ddlLeaveYear.DataTextField = "FYName";
                ddlLeaveYear.DataValueField = "FYKey";
                ddlLeaveYear.DataBind();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        public void ClearLeaveControls()
        {
            _LeaveTransactionsToDelete = new CustomList<LeaveTransApproved>();
            ddlLeaveType.SelectedIndex = 0;
            txtLeaveFrom.Text = string.Empty;
            txtLeaveTo.Text = string.Empty;
            txtDays.Text = string.Empty;
            txtReason.Text = string.Empty;
            txtAvailPlace.Text = string.Empty;
            txtAdditionalContact.Text = String.Empty;
            txtWorkDate.Text = string.Empty;
            txtFrom.Text = string.Empty;
            txtTo.Text = string.Empty;
            txtLeaveHours.Text = string.Empty;
        }
        protected void btnFindSupervisor_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string EmployeeCode = ((TextBox)this.Header1.FindControl("txtSearch")).Text.ToString();
                CustomList<HRM_Emp> EmpList = _salaryManager.doSearch(EmployeeCode);
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("EmpCode", "Employee Code");
                columns.Add("EmpName", "Employee Name");

                StaticInfo.SearchItem(EmpList, "Emp Info", "SearchSupervisor", SearchColumnConfig.GetColumnConfig(typeof(HRM_Emp), columns), 500, GlobalEnums.enumSearchType.StoredProcedured);
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<LeaveTransApproved> SaveableLeaveTrans = (CustomList<LeaveTransApproved>)_LeaveTransactionsToDelete;
                CustomList<HourlyLeaveTrans> SaveHourlyLeaveTrans = (CustomList<HourlyLeaveTrans>)_HourlyLeaveTransactionsToDelete;
                foreach (HourlyLeaveTrans H in SaveHourlyLeaveTrans)
                {
                    if (H.TransactionID == 0) H.SetAdded();
                    else H.SetModified();

                }
                if (!chkHourlyLeave.Checked)
                {
                    if (SaveableLeaveTrans.Count == 0)
                    {
                        LeaveTransApproved newObj = new LeaveTransApproved();
                        SaveableLeaveTrans.Add(newObj);
                        SaveHourlyLeaveTrans = new CustomList<HourlyLeaveTrans>();
                        _HourlyLeaveTransactionsToDelete = new CustomList<HourlyLeaveTrans>();
                    }
                }
                else
                {
                    if (SaveHourlyLeaveTrans.Count == 0)
                    {
                        HourlyLeaveTrans newObj = new HourlyLeaveTrans();
                        SaveHourlyLeaveTrans.Add(newObj);
                        SaveableLeaveTrans = new CustomList<LeaveTransApproved>();
                        _LeaveTransactionsToDelete = new CustomList<LeaveTransApproved>();
                    }
                }
                SetLeaveTransDateFromControlToObj(ref SaveableLeaveTrans, ref SaveHourlyLeaveTrans);
                ManagerLeaveTrans.SaveLeaveTrans(ref SaveableLeaveTrans, ref SaveHourlyLeaveTrans);
                _LeaveTransactionsBack = new CustomList<LeaveTransApproved>();
                ClearLeaveControls();
                LeaveYear = ddlLeaveYear.SelectedValue;
                EmployeeCode = ((TextBox)this.Header1.FindControl("txtSearch")).Text.ToString();
                _LeaveTransactions = ManagerLeaveTrans.GetEmpWiseAllLeaveTransApproved(LeaveYear, EmployeeCode);
                _HourlyLeaveTransactions = ManagerLeaveSummery.GetAllHourlyLeaveTrans(ddlLeaveYear.SelectedValue.ToInt(), _RunnignEmpInfo[0].EmpKey);
                ((PageBase)this.Page).SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //if (_LeaveTransactionsToDelete.Count == 0)
            //{
            //    ((PageBase)this.Page).ErrorMessage = "No Data To Delete!!\nPlease Select The Transaction First.";
            //}
            //else
            //{
            foreach (LeaveTransApproved L in _LeaveTransactionsToDelete)
            {
                L.Delete();
            }
            foreach (HourlyLeaveTrans hLT in _HourlyLeaveTransactionsToDelete)
            {
                hLT.Delete();
            }
            CustomList<LeaveTransApproved> obj = _LeaveTransactionsToDelete;
            CustomList<HourlyLeaveTrans> objHourlyLeave = _HourlyLeaveTransactionsToDelete;
            ManagerLeaveTrans.DeleteLeaveTransaction(ref obj, ref objHourlyLeave);
            string LeaveYear = ddlLeaveYear.SelectedValue;
            string EmployeeCode = ((TextBox)this.Header1.FindControl("txtSearch")).Text.ToString();
            _LeaveTransactionsToDelete = new CustomList<LeaveTransApproved>();
            ClearLeaveControls();
            _LeaveTransactions = ManagerLeaveTrans.GetEmpWiseAllLeaveTransApproved(LeaveYear, EmployeeCode);
            ((PageBase)this.Page).SuccessMessage = (StaticInfo.DeletedSuccessfullyMsg);
            // }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearLeaveControls();
            //CustomList<ShiftRoster> ExistingSR = new CustomList<ShiftRoster>();
            ////SR = (CustomList<ASL.Hr.DAO.ShiftRoster>)_ShiftRosterProcess;
            //string tableName = HttpContext.Current.Session["TableName"].ToString();
            //ExistingSR = ManagerShiftRoster.GetAllShiftRoster(txtFromDate.Text, txtToDate.Text, tableName);
            //foreach (ShiftRoster S in ExistingSR)
            //{
            //    S.Delete();
            //}
            //ManagerShiftRoster.DeleteShiftRosterProcess(ref ExistingSR);

            //_ShiftRosterProcess = new CustomList<ShiftRoster>();
            //HttpContext.Current.Session["View_EmpList"] = new CustomList<EmployeeInfoForSearch>();
            //Message.ShowMessageBox("Shift Roster Data Deleted Successfully!!!");
        }

    }
}
