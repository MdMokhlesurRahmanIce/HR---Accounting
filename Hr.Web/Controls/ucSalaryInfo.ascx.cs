using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.Hr.BLL;
using ASL.DATA;
using ASL.Hr.DAO;
using Hr.Web.Utils;
using System.Collections;

namespace Hr.Web.Controls
{
    public partial class ucSalaryInfo : System.Web.UI.UserControl
    {
        #region Fileds
        public readonly EmployeeManager _empManager;
        public readonly MonthlySalarProcessManager _salaryManager;
        #endregion
        #region Ctor
        public ucSalaryInfo()
        {
            _empManager = new EmployeeManager();
            _salaryManager = new MonthlySalarProcessManager();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateCombo();
            }
        }
        #region AllMethods
        private void PopulateCombo()
        {
            ddlBank.DataSource = _empManager.GetAllBank(); ;
            ddlBank.DataTextField = "BankSName";
            ddlBank.DataValueField = "BankKey";
            ddlBank.DataBind();
            ddlBank.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            ddlBank.SelectedIndex = 0;

            ddlBranch.DataSource = _empManager.GetAllBank_Branch(0);
            ddlBranch.DataTextField = "BranchSName";
            ddlBranch.DataValueField = "BranchKey";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem() { Value = "", Text = "" });
            ddlBranch.SelectedIndex = 0;
        }
        internal void Save(ArrayList empInfo)
        {
            //if (Session["EmpKey"] == null)
            //    return;
            CustomList<HRM_Emp> empList = (CustomList<HRM_Emp>)empInfo[0];
            empList[0].BankKey = ddlBank.SelectedValue.IfEmptyOrNullThenNull();
            empList[0].BankBranchKey = ddlBranch.SelectedValue.IfEmptyOrNullThenNull();
            empList[0].ContractPerson = txtContactPerson.Text;
            empList[0].AccNo = txtAccNo.Text;
            empList[0].ContractPersonPhone = txtPhone.Text;

            var empSalaryInfo = (CustomList<EmployeeSalaryTemp>)Session["SalaryInfoEntry_grdSalaryEntryList"];
            empInfo.Add(empSalaryInfo);
        }
        internal void PopulateControl(HRM_Emp emp, string UserCode)
        {
            try
            {
                if (emp.BankKey != 0)
                    ddlBank.SelectedValue = ddlBank.Items.FindByValue(emp.BankKey.ToString()) == null ? "" : ddlBank.Items.FindByValue(emp.BankKey.ToString()).Value;
                //if (ddlBank.SelectedValue != "")
                //{
                //    ddlBank_SelectedIndexChanged(null,null);
                //}
                if (emp.BankBranchKey != 0)
                    ddlBranch.SelectedValue = ddlBranch.Items.FindByValue(emp.BankBranchKey.ToString()) == null ? "" : ddlBranch.Items.FindByValue(emp.BankBranchKey.ToString()).Value;
                txtAccNo.Text = emp.AccNo;
                txtContactPerson.Text = emp.ContractPerson;
                txtPhone.Text = emp.ContractPersonPhone;
                
                CustomList<EmployeeSalaryTemp> empSalaryList = _empManager.GetAllEmployeeSalaryByEmpKey(emp.EmpKey, UserCode);
                if (empSalaryList.Count != 0)
                {
                    DropDownList ddlSalaryRule = (DropDownList)ctrlSalaryFormula.FindControl("ddlSalaryRule");
                    ddlSalaryRule.SelectedValue = empSalaryList[0].SalaryRuleCode;
                }
                Session["SalaryInfoEntry_grdSalaryEntryList"] = empSalaryList;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Combo Event
        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlBranch.DataSource = _empManager.GetAllBank_Branch(ddlBank.SelectedValue.ToInt());
            ddlBranch.DataTextField = "BranchSName";
            ddlBranch.DataValueField = "BranchKey";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlBranch.SelectedIndex = 0;
        }
        #endregion
    }
}