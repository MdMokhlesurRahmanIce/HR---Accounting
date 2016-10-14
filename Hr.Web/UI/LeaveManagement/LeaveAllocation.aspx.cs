using System;
using System.ComponentModel;
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
    public partial class LeaveAllocation : PageBase
    {


        LeaveYearManager ManagerLeaveYear = new LeaveYearManager();
        LeaveSummeryManager ManagerLeaveSummery = new LeaveSummeryManager();
        LeaveTransApprovedMnager ManagerLeaveTrans = new LeaveTransApprovedMnager();
        LeaveAllocationManager manager = new LeaveAllocationManager();
        #region Sesson Variable
        private CustomList<ASL.Hr.DAO.LeaveAllocation> _LeaveAllocation
        {
            get
            {
                if (Session["LeaveAllocation_LeaveAllocation"] == null)
                    return new CustomList<ASL.Hr.DAO.LeaveAllocation>();
                else
                    return (CustomList<ASL.Hr.DAO.LeaveAllocation>)Session["LeaveAllocation_LeaveAllocation"];
            }
            set
            {
                Session["LeaveAllocation_LeaveAllocation"] = value;
            }
        }
        private CustomList<ASL.Hr.DAO.LeaveTransApproved> _RunnignEmpInfo
        {
            get
            {
                if (Session["LeaveAllocation_RunningEmpInfo"] == null)
                    return new CustomList<ASL.Hr.DAO.LeaveTransApproved>();
                else
                    return (CustomList<ASL.Hr.DAO.LeaveTransApproved>)Session["LeaveAllocation_RunningEmpInfo"];
            }
            set
            {
                Session["LeaveAllocation_RunningEmpInfo"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeSession();
                InitializeControls();
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
            }
        }
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                _LeaveAllocation = new CustomList<ASL.Hr.DAO.LeaveAllocation>();
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
            string LeaveYear = ddlLeaveYear.SelectedValue;
            _RunnignEmpInfo = ManagerLeaveTrans.GetLeaveEligibleEmp(EmployeeCode);
            if (_RunnignEmpInfo.Count != 0)
            {
                txtEmployeeName.Text = _RunnignEmpInfo[0].EmpName;
                txtDesignation.Text = _RunnignEmpInfo[0].Designation;
                txtDOJ.Text = _RunnignEmpInfo[0].DOJ.ToShortDateString();
                txtStaffCategory.Text = _RunnignEmpInfo[0].StaffCategory;
                txtLeaveRule.Text = _RunnignEmpInfo[0].LeaveRuleKey.ToString();
                imgGarment.ImageUrl = ResolveUrl(_RunnignEmpInfo[0].EmpPicture);

                CustomList<ASL.Hr.DAO.LeaveAllocation> LS = ManagerLeaveSummery.GetEmpWiseLeaveAllocation(LeaveYear, EmployeeCode);
                if (LS.Count != 0)
                {
                    _LeaveAllocation = LS;

                }
                else _LeaveAllocation = new CustomList<ASL.Hr.DAO.LeaveAllocation>();
            }
            else ((PageBase)this.Page).ErrorMessage = "Leave Rule is Not Tagged. So, This Employee Is NOT Eligible for Leave!!!";

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CustomList<ASL.Hr.DAO.LeaveAllocation> lstLeaveAllocation = _LeaveAllocation.FindAll(f=>f.IsModified);
            string LeaveYear = ddlLeaveYear.SelectedValue;
            string EmployeeCode = ((TextBox)this.Header1.FindControl("txtSearch")).Text.ToString();
            CustomList<ASL.Hr.DAO.LeaveAllocation> deletedList = new CustomList<ASL.Hr.DAO.LeaveAllocation>();
            foreach (ASL.Hr.DAO.LeaveAllocation lA in lstLeaveAllocation)
            {
                lA.SetAdded();
                lA.LeaveYearID = LeaveYear;
                ASL.Hr.DAO.LeaveAllocation deletedObj = new ASL.Hr.DAO.LeaveAllocation();
                deletedObj.LeaveAllocationKey = lA.LeaveAllocationKey;
                deletedObj.Delete();
                deletedList.Add(deletedObj);
            }
            manager.SaveLeaveAllocation(ref deletedList, ref lstLeaveAllocation);
            _LeaveAllocation = ManagerLeaveSummery.GetEmpWiseLeaveAllocation(LeaveYear, EmployeeCode);
            ((PageBase)this.Page).SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
        }
    }
}
