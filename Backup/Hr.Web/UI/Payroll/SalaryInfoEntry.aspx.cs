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
//using  Web.Hr.Controls;
using System.Collections;
using System.Data.SqlClient;
using System.Globalization;


namespace Hr.Web.UI.Payroll
{
    public partial class SalaryInfoEntry : PageBase
    {
        SalaryInfoEntryManager manager = new SalaryInfoEntryManager();
        #region Constractor
        public SalaryInfoEntry()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                //InitializieCombo();
                //InitializeSession();
            }
        }
        #endregion
        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<HRM_Emp> EmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session["View_EmpList"];
                CustomList<HRM_Emp> SaveableEmpList = EmpList.FindAll(f => f.IsChecked == true);
                CustomList<EmployeeSalaryTemp> StructureTempEmpSalary = (CustomList<EmployeeSalaryTemp>)Session["SalaryInfoEntry_grdSalaryEntryList"];
                CustomList<EmployeeSalaryTemp> TempEmpSalary = new CustomList<EmployeeSalaryTemp>();
                foreach (HRM_Emp H in SaveableEmpList)
                {

                    foreach (EmployeeSalaryTemp S in StructureTempEmpSalary)
                    {
                        EmployeeSalaryTemp ST = new EmployeeSalaryTemp();
                        ST.EmpKey = H.EmpKey;
                        ST.SalaryHeadKey = S.SalaryHeadKey;
                        ST.SalaryRuleCode = S.SalaryRuleCode;
                        ST.IsFixed = S.IsFixed;
                        ST.Amount = S.Amount;
                        ST.AddedBy = CurrentUserSession.UserCode;
                        ST.DateAdded = DateTime.Now;
                        TempEmpSalary.Add(ST);
                    }

                }

                CustomList<EmployeeSalary> InsertSalaryList = new CustomList<EmployeeSalary>();
                CustomList<EmployeeSalary> DeleteSalaryList = new CustomList<EmployeeSalary>();
                if (chkApproved.Checked)
                {
                    TempEmpSalary.ForEach(s => s.DateApproved = DateTime.Now);
                    TempEmpSalary.ForEach(s => s.ApprovedBy = CurrentUserSession.UserCode);
                    foreach (EmployeeSalaryTemp t in TempEmpSalary)
                    {
                        EmployeeSalary newObjInsert = new EmployeeSalary();
                        newObjInsert.EmpKey = t.EmpKey;
                        newObjInsert.SalaryRuleCode = t.SalaryRuleCode;
                        newObjInsert.SalaryHeadKey = t.SalaryHeadKey;
                        newObjInsert.IsFixed = t.IsFixed;
                        newObjInsert.Amount = t.Amount;
                        InsertSalaryList.Add(newObjInsert);

                        EmployeeSalary newObjDelete = new EmployeeSalary();
                        newObjDelete.SalaryHeadKey = t.SalaryHeadKey;
                        newObjDelete.EmpKey = t.EmpKey;
                        newObjDelete.Delete();
                        DeleteSalaryList.Add(newObjDelete);
                    }
                }
                if (!CheckUserAuthentication(TempEmpSalary, DeleteSalaryList, InsertSalaryList)) return;
                manager.SaveSalaryInfo(ref TempEmpSalary, ref DeleteSalaryList, ref InsertSalaryList);
                //txtSalaryRuleID.Text = manager.SalaryRuleCode;
                this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);

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
        #endregion
    }
}