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
    public partial class SalaryProcess : PageBase
    {
        SettingsManager managerSettings = new SettingsManager();
        #region Session Variable

        #region Constructur
        public SalaryProcess()
        {
            RequiresAuthorization = true;
        }
        #endregion
        private CustomList<SalaryProcess> grdSalaryProcessList
        {
            get
            {
                if (Session["SalaryProcess_SalaryProcessList"] == null)
                    return new CustomList<SalaryProcess>();
                else
                    return (CustomList<SalaryProcess>)Session["SalaryProcess_SalaryProcessList"];
            }
            set
            {
                Session["SalaryProcess_SalaryProcessList"] = value;
            }
        }


        private void InitializeSession()
        {
            try
            {
                grdSalaryProcessList = new CustomList<SalaryProcess>();

            }
            catch (Exception ex)
            {

                throw (ex);
            }

        }
        #endregion
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                #region Salary Year Month
                ddlyearno.DataSource = managerSettings.GetAllSalaryYear();
                ddlyearno.DataTextField = "CharType";
                ddlyearno.DataValueField = "CharType";
                ddlyearno.DataBind();
                ddlyearno.Items.Insert(0, new ListItem() { Value = "", Text = "" });
                #endregion




                //InitializieCombo();
                InitializeSession();
            }
        }
        #endregion
        #region Button Event
        protected void ddlyearno_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomList<Settings> obj = managerSettings.GetAllSalaryMonths(ddlyearno.SelectedValue);
            ddlMonthNo.DataSource = obj;
            ddlMonthNo.DataTextField = "Data1";
            ddlMonthNo.DataValueField = "NumType";
            ddlMonthNo.DataBind();
            ddlMonthNo.Items.Insert(0, new ListItem() { Value = "", Text = "" });
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<EmployeeSalaryTemp> TempEmpSalary = (CustomList<EmployeeSalaryTemp>)Session["SalaryInfoEntry_grdSalaryEntryList"];
                TempEmpSalary.ForEach(s => s.AddedBy = CurrentUserSession.UserCode);
                TempEmpSalary.ForEach(s => s.DateAdded = DateTime.Now);
                CustomList<EmployeeSalary> InsertSalaryList = new CustomList<EmployeeSalary>();
                CustomList<EmployeeSalary> DeleteSalaryList = new CustomList<EmployeeSalary>();
                InitializeSession();
                /* if (chkApproved.Checked)
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
                 */
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