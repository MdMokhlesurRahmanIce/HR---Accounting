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
using Hr.Web.UI.EmployeeBasicInfo;

namespace Hr.Web.Controls
{
    public partial class SearchEmployee : System.Web.UI.UserControl
    {
        public readonly EmployeeManager _empManager;
        public readonly MonthlySalarProcessManager _salaryManager;
        #region Ctor
        public SearchEmployee()
        {
            _empManager = new EmployeeManager();
            _salaryManager = new MonthlySalarProcessManager();
        }
        #endregion
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
        private CustomList<ASL.Hr.DAO.LeaveTransApproved> _LeaveTransactionsFromSearchControl
        {
            get
            {
                if (Session["LeaveTransactionsFromSearchControl"] == null)
                    return new CustomList<ASL.Hr.DAO.LeaveTransApproved>();
                else
                    return (CustomList<ASL.Hr.DAO.LeaveTransApproved>)Session["LeaveTransactionsFromSearchControl"];
            }
            set
            {
                Session["LeaveTransactionsFromSearchControl"] = value;
            }
        }
        private CustomList<ASL.Hr.DAO.LeaveSummery> _LeaveSummeryFromSurchControl
        {
            get
            {
                if (Session["LeaveSummeryFromSearchControl"] == null)
                    return new CustomList<ASL.Hr.DAO.LeaveSummery>();
                else
                    return (CustomList<ASL.Hr.DAO.LeaveSummery>)Session["LeaveSummeryFromSearchControl"];
            }
            set
            {
                Session["LeaveSummeryFromSearchControl"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                EmployeeList = new CustomList<HRM_Emp>();
                string empKey = Request.QueryString.Get("EmpKey");
                Session["ProfileEmpKey"] = empKey;
                if (empKey.IsNullOrEmpty())
                {
                    EmployeeList = _empManager.GetEmpInfo("");
                }
                else
                {
                    EmployeeList = _empManager.GetReportees(Convert.ToInt64(empKey));
                }
                string empcode = Request.QueryString.Get("empCodeForLeave");
                if (empcode.IsNotNullOrEmpty())
                {
                    LeaveInformationTrans(empcode);
                }
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);

                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (Request["__EVENTTARGET"] == "SearchEmployee")
                {
                    string empCode = txtSearch.Text;
                    var page2 = this.Page;
                    string s2 = page2.Page.ToString();
                    //string s3 = page2.Items.ToString();
                    //string s1 = page2.Title.ToString();
                    HRM_Emp searchEmp = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as HRM_Emp;
                    if (s2 == "ASP.ui_leavemanagement_leavetransaction_aspx")
                    {
                        if (empCode != "" || searchEmp.EmpCode != "")
                        {
                            empCode = searchEmp.EmpCode;
                            txtSearch.Text = searchEmp.EmpCode;
                            LeaveInformationTrans(empCode);
                        }
                    }
                    else if (s2 == "ASP.ui_leavemanagement_leaveallocation_aspx")
                    {
                        if (empCode != "" || searchEmp.EmpCode != "")
                        {
                            empCode = searchEmp.EmpCode;
                            txtSearch.Text = searchEmp.EmpCode;
                            LeaveInformation(empCode);
                        }
                    }
                    else if (s2 == "ASP.ui_employeebasicinfo_madicalreinversement_aspx")
                    {
                        if (empCode != "" || searchEmp.EmpCode != "")
                        {
                            empCode = searchEmp.EmpCode;
                            txtSearch.Text = searchEmp.EmpCode;
                            MedicalAllowance(empCode);
                        }
                    }
                    else if (s2 == "ASP.ui_employeebasicinfo_promotionincrement_aspx")
                    {
                        if (empCode != "" || searchEmp.EmpCode != "")
                        {
                            empCode = searchEmp.EmpCode;
                            txtSearch.Text = searchEmp.EmpCode;
                            Promotion(empCode);
                        }
                    }
                    else if (s2 == "ASP.ui_payroll_customerinfo_aspx")
                    {
                        if (empCode != "" || searchEmp.EmpCode != "")
                        {
                            empCode = searchEmp.EmpCode;
                            txtSearch.Text = searchEmp.EmpCode;
                            CustomerInfo(empCode);
                        }
                    }
                    else if (s2 == "ASP.ui_employeebasicinfo_employeebasicinformation_aspx")
                    {
                        if (searchEmp.IsNotNull())
                        {
                            var page = this.Page as EmployeeBasicInformation;
                            var emp = _empManager.GetEmpByCode(searchEmp.EmpCode);
                            page.ClearControls();
                            txtSearch.Text = searchEmp.EmpCode;
                            #region populate other tab
                            page.PopulteControl(emp);
                            #endregion

                            (this.Parent.FindControl("btnSave") as Button).Visible = false;
                            (this.Parent.FindControl("btnUpdate") as Button).Visible = true;
                            //(this.Parent.FindControl("btnDelete") as Button).Visible = true;
                        }
                    }
                    else
                    {
                    }
                }
            }
        }
        private void LeaveInformation(string empCode)
        {
            try
            {
                var page = this.Page as Hr.Web.UI.LeaveManagement.LeaveAllocation;
                page.SetDateFromObjToControl(empCode);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void LeaveInformationTrans(string empCode)
        {
            try
            {
                var page = this.Page as Hr.Web.UI.LeaveManagement.LeaveTransaction;
                page.SetDateFromObjToControl(empCode);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void Promotion(string empCode)
        {
            try
            {
                var page = this.Page as Hr.Web.UI.EmployeeBasicInfo.PromotionIncrement;
                page.SetDateFromObjToControl(empCode);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void CustomerInfo(string empCode)
        {
            try
            {
                var page = this.Page as Hr.Web.UI.Payroll.CustomerInfo;
                page.SetDateFromObjToControl(empCode);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void MedicalAllowance(string empCode)
        {
            try
            {
                var page = this.Page as Hr.Web.UI.EmployeeBasicInfo.MadicalReinverseement;
                page.SetDateFromObjToControl(empCode);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            Session["EmpKey"] = "0";
            var page = this.Page as EmployeeBasicInformation;
            page.ClearControls();
        }
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                Session[StaticInfo.SearchArg] = sb;

                string empKey = Request.QueryString.Get("EmpKey");
                CustomList<HRM_Emp> ProcessedAndUnProcessedList = new CustomList<HRM_Emp>();
                if (empKey.IsNullOrEmpty())
                {
                    ProcessedAndUnProcessedList = _salaryManager.doSearch(empKey);
                }
                else
                {
                    ProcessedAndUnProcessedList = _empManager.GetReportees(Convert.ToInt64(empKey));
                }
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("EmpCode", "Employee Code");
                columns.Add("EmpName", "Employee Name");
                columns.Add("Staff Category", "Staff Category");
                columns.Add("Designation", "Designation");
                columns.Add("Department", "Department");
                columns.Add("JobLocation", "Job Location");
                //columns.Add("LOB","LOB");
                columns.Add("SupervisorName", "SupervisorName");
                columns.Add("EmpStatus", "EmpStatus");

                StaticInfo.SearchItem(ProcessedAndUnProcessedList, "Emp Info", "SearchEmployee", SearchColumnConfig.GetColumnConfig(typeof(HRM_Emp), columns), 750, GlobalEnums.enumSearchType.StoredProcedured);
                //StaticInfo.SearchItem(items, "Emp Info", "SearchEmployee", SearchColumnConfig.GetColumnConfig(typeof(HRM_Emp), columns), 500);
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