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
    public partial class EmployeeInfoComonApproval : PageBase
    {
        ApprovalManager manager = new ApprovalManager();
        #region Ctor
        public EmployeeInfoComonApproval()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variables
        private CustomList<HRM_Emp> _EmpList
        {
            get
            {
                if (Session["EmployeeInfoComonApproval_EmpList"] == null)
                    return new CustomList<HRM_Emp>();
                else
                    return (CustomList<HRM_Emp>)Session["EmployeeInfoComonApproval_EmpList"];
            }
            set
            {
                Session["EmployeeInfoComonApproval_EmpList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeCombo();
                InitializeSession();
            }
        }
        #region All Methods
        private void InitializeCombo()
        {
            //load Approval List
            ddlApprovalList.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            ddlApprovalList.Items.Insert(1, new ListItem() { Value = "1", Text = "New Employee Approval" });
            ddlApprovalList.Items.Insert(2, new ListItem() { Value = "2", Text = "Separated Employee Activation" });
            ddlApprovalList.Items.Insert(3, new ListItem() { Value = "3", Text = "Separation Approval" });
        }
        private void InitializeSession()
        {
            try
            {
                _EmpList = new CustomList<HRM_Emp>();
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
                CustomList<HRM_Emp> lstEmp = (CustomList<HRM_Emp>)_EmpList;
                CustomList<HRM_Emp> CheckedList = lstEmp.FindAll(f => f.IsChecked);
                if (ddlApprovalList.SelectedValue == "1")
                {
                    foreach (HRM_Emp emp in CheckedList)
                    {
                        emp.EmpStatus = "Active";
                        emp.SetModified();
                    }
                    CheckedList.UpdateSpName = "spNewEmpApproval";
                    if (CheckedList.IsNotNull())
                    {
                        if (!CheckUserAuthentication(CheckedList)) return;
                        manager.SaveEmpApproval(ref CheckedList);
                        this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                    }
                }
                else if (ddlApprovalList.SelectedValue == "3")
                {
                    CustomList<SeparationGrid> SeparationApprovedList = new CustomList<SeparationGrid>();
                    foreach (HRM_Emp emp in CheckedList)
                    {
                        SeparationGrid newSeparation = new SeparationGrid();
                        newSeparation.EmployeeKey = emp.EmpKey;
                        newSeparation.ApprovedBy = CurrentUserSession.EmpKey.ToString();
                        newSeparation.ApprovedDate = DateTime.Now;
                        newSeparation.SetModified();
                        SeparationApprovedList.Add(newSeparation);
                    }
                    SeparationApprovedList.UpdateSpName = "spEmpSeparationApproval";
                    if (!CheckUserAuthentication(SeparationApprovedList)) return;
                    manager.SaveEmpSeparationApproval(ref SeparationApprovedList);
                    this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                }
                else if (ddlApprovalList.SelectedValue == "2")
                {
                    CustomList<Reactive> ReactiveList = new CustomList<Reactive>();
                    foreach (HRM_Emp emp in CheckedList)
                    {
                        Reactive newReactive = new Reactive();
                        newReactive.EmpKey = emp.EmpKey;
                        newReactive.DOJ = emp.DOJ;
                        emp.DOJ = emp.RejoiningDate;
                        emp.SetModified();
                        ReactiveList.Add(newReactive);
                    }
                    CheckedList.UpdateSpName = "spSeparatedEmpRejoining";
                    ReactiveList.InsertSpName = "spInsertReactive";
                    if (CheckedList.IsNotNull())
                    {
                        if (!CheckUserAuthentication(CheckedList, ReactiveList)) return;
                        manager.SaveEmpReActive(ref CheckedList, ref ReactiveList);
                        this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                    }
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
    }
}