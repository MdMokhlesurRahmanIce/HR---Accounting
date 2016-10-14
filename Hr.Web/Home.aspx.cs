using System;
using ASL.Web.Framework;

namespace Hr.Web
{
    public partial class Home : PageBase
    {
        public Home()
        {
            RequiresAuthorization = true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.Title = StaticInfo.CompanyName;
                ltlEmpCode.Text = CurrentUserSession.EmployeeCode;
                ltlEmpName.Text = CurrentUserSession.EmpName;
                ltlEmpType.Text = CurrentUserSession.EmpType;
                ltlGrade.Text = CurrentUserSession.Grade;
                ltlDesignation.Text = CurrentUserSession.Designation;
                ltlDepartment.Text = CurrentUserSession.Department;
                ltlUnit.Text = CurrentUserSession.Company;
            }
        }
        protected void lnkPersonalContent_Click(Object sender, EventArgs e)
        {
            try
            {
                Server.Transfer("~/UI/EmployeeBasicInfo/EmployeeBasicInformation.aspx?empcode=" + ltlEmpCode.Text + "&selectedtab=" + 9);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        protected void lnkProfile_Click(Object sender, EventArgs e)
        {
            try
            {
                //EmpBase obj = new EmpBase();
                //obj.EmpKey = CurrentUserSession.EmpKey.ToString();
                Server.Transfer("~/UI/EmployeeBasicInfo/EmployeeBasicInformation.aspx?empcode=" + ltlEmpCode.Text + "&EmpKey=" + CurrentUserSession.EmpKey + "&selectedtab=" + 0);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        protected void lnkReports_Click(Object sender, EventArgs e)
        {
            try
            {
                Server.Transfer("~/ReportViewer.aspx?empCode=" + ltlEmpCode.Text + "&EmpKey=" + CurrentUserSession.EmpKey);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        protected void lnkLeave_Click(Object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/UI/LeaveManagement/LeaveTransaction.aspx?empCodeForLeave=" + ltlEmpCode.Text);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        protected void lnkLeaveApproval_Click(Object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/UI/LeaveManagement/LeaveTransactionApproval.aspx?EmpKey=" + CurrentUserSession.EmpKey);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        protected void lnkCompanyPolicies_Click(Object sender, EventArgs e)
        {
            try
            {
                Server.Transfer("~/UI/Setup/CompanyPolicies.aspx");
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
