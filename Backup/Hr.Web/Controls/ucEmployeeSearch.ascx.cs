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

namespace Hr.Web.Controls
{
    public partial class ucEmployeeSearch : System.Web.UI.UserControl
    {
        MonthlySalarProcessManager _manager;

        public ucEmployeeSearch()
        {
            _manager = new MonthlySalarProcessManager();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtEmployeeName.Attributes.Add("readonly", "true");

                if (IsPostBack.IsFalse())
                {
                    InitializeCombo();
                }
                else
                {
                    Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                    String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                    if (Request["__EVENTTARGET"] == "SearchEmployee")
                    {
                        hfEmpCode.Value = "";
                        HRM_Emp searchEmp = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as HRM_Emp;
                        if (searchEmp.IsNotNull())
                        {
                            txtEmployeeName.Text = searchEmp.EmpName;
                            hfEmpCode.Value = searchEmp.EmpCode;
                            txtEmpID.Text = searchEmp.EmpCode;
                            hfEmpKey.Value = searchEmp.EmpKey.ToString();

                            //added by zaki
                            //if (searchEmp.OrgKey > 0)
                            //{
                            //    string comKey = string.Empty, branKey = string.Empty, depKey = string.Empty;
                            //    GetAllOrgKey(searchEmp.OrgKey, out comKey, out branKey, out depKey);

                            //    ddlCompany.SelectedValue = comKey;
                            //    ddlCompany_SelectedIndexChanged(null, null);
                            //    ddlBranch.SelectedValue = ddlBranch.Items.FindByValue(branKey.ToString()) == null ? "" : branKey;
                            //    ddlBranch_SelectedIndexChanged(null, null);
                            //    ddlDepartment.SelectedValue = ddlDepartment.Items.FindByValue(depKey.ToString()) == null ? "" : depKey;
                            //}
                            //ddlGrade.SelectedValue = ddlGrade.Items.FindByValue(searchEmp.GradeKey.ToString()) == null ? "" : searchEmp.GradeKey.ToString();
                            //ddlGrade_SelectedIndexChanged(null, null);
                            //ddlDesignation.SelectedValue = ddlDesignation.Items.FindByValue(searchEmp.DesigKey.ToString()) == null ? "" : searchEmp.DesigKey.ToString();
                            //end zaki

                            StringBuilder searchString = SearchString();
                            Session[StaticInfo.SearchArg] = searchString;

                            string selectedEmpHeadline = string.Format("Employee Code: {0}. Employee Name: {1}", searchEmp.EmpCode, searchEmp.EmpName);
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "loadEmp", string.Format("loadEmp('{0}','{1}')", searchEmp.EmpCode, selectedEmpHeadline), true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region All Methods
        private void InitializeCombo()
        {
            try
            {
                //Loding Company
                ddlCompany.DataSource = _manager.GetAllCompany();
                ddlCompany.DataTextField = "OrgName";
                ddlCompany.DataValueField = "OrgKey";
                ddlCompany.DataBind();
                ddlCompany.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCompany.SelectedIndex = 0;

                //Loding Grade
                ddlGrade.DataSource = _manager.GetAllGen_Grade();
                ddlGrade.DataTextField = "ElementName";
                ddlGrade.DataValueField = "ElementKey";
                ddlGrade.DataBind();
                ddlGrade.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlGrade.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private StringBuilder SearchString()
        {
            StringBuilder sb = new StringBuilder();
            if (ddlCompany.SelectedValue != "")
            {
                sb.Append("@OrgKey=");
                sb.Append(ddlCompany.SelectedValue.ToInt());
                sb.Append(",");
            }
            if (ddlBranch.SelectedValue != "")
            {
                sb.Append("@BranchKey=");
                sb.Append(ddlBranch.SelectedValue.ToInt());
                sb.Append(",");
            }
            if (ddlDepartment.SelectedValue != "")
            {
                sb.Append("@DepartmentKey=");
                sb.Append(ddlDepartment.SelectedValue.ToInt());
                sb.Append(",");
            }
            if (ddlGrade.SelectedValue != "")
            {
                sb.Append("@GradeKey=");
                sb.Append(ddlGrade.SelectedValue.ToInt());
                sb.Append(",");
            }
            if (ddlDesignation.SelectedValue != "")
            {
                sb.Append("@DesigKey=");
                sb.Append(ddlDesignation.SelectedValue.ToInt());
                sb.Append(",");
            }
            if (hfEmpCode.Value != "")
            {
                sb.Append("@EmpCode=");
                sb.Append(hfEmpCode.Value);
                sb.Append(",");
            }
            //sb.Append("@UserKey=");
            //sb.Append("1");
            //sb.Append(",");

            return sb;
        }
        #endregion
        #region dropdown List Event

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StringBuilder searchString = SearchString();
                Session[StaticInfo.SearchArg] = searchString;

                ddlBranch.DataSource = _manager.GetAllBranch().FindAll(f => f.OrgParentKey == ddlCompany.SelectedValue.ToInt());
                ddlBranch.DataTextField = "OrgName";
                ddlBranch.DataValueField = "OrgKey";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlBranch.SelectedIndex = 0;

                ddlBranch_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StringBuilder searchString = SearchString();
                Session[StaticInfo.SearchArg] = searchString;

                ddlDepartment.DataSource = _manager.GetAllDept().FindAll(f => f.OrgParentKey == ddlBranch.SelectedValue.ToInt());
                ddlDepartment.DataTextField = "OrgName";
                ddlDepartment.DataValueField = "OrgKey";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlDepartment.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StringBuilder searchString = SearchString();
                Session[StaticInfo.SearchArg] = searchString;

                ddlDesignation.DataSource = _manager.GetAllDesignation(ddlGrade.SelectedValue.ToInt());
                ddlDesignation.DataTextField = "DesigName";
                ddlDesignation.DataValueField = "DesigKey";
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlDesignation.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StringBuilder searchString = SearchString();
                Session[StaticInfo.SearchArg] = searchString;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StringBuilder searchString = SearchString();
                Session[StaticInfo.SearchArg] = searchString;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region button event
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (ddlCompany.SelectedValue != "")
                {
                    sb.Append("@OrgKey=");
                    sb.Append(ddlCompany.SelectedValue.ToInt());
                    sb.Append(",");
                }
                if (ddlBranch.SelectedValue != "")
                {
                    sb.Append("@BranchKey=");
                    sb.Append(ddlBranch.SelectedValue.ToInt());
                    sb.Append(",");
                }
                if (ddlDepartment.SelectedValue != "")
                {
                    sb.Append("@DepartmentKey=");
                    sb.Append(ddlDepartment.SelectedValue.ToInt());
                    sb.Append(",");
                }
                if (ddlGrade.SelectedValue != "")
                {
                    sb.Append("@GradeKey=");
                    sb.Append(ddlGrade.SelectedValue.ToInt());
                    sb.Append(",");
                }
                if (ddlDesignation.SelectedValue != "")
                {
                    sb.Append("@DesigKey=");
                    sb.Append(ddlDesignation.SelectedValue.ToInt());
                    sb.Append(",");
                }
                string EmpKey = "";
                Session[StaticInfo.SearchArg] = sb;
                CustomList<HRM_Emp> ProcessedAndUnProcessedList = _manager.doSearch(EmpKey);
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("EmpCode", "Employee Code");
                columns.Add("EmpName", "Employee Name");

                StaticInfo.SearchItem(ProcessedAndUnProcessedList, "Emp Info", "SearchEmployee", SearchColumnConfig.GetColumnConfig(typeof(HRM_Emp), columns), 500, GlobalEnums.enumSearchType.StoredProcedured);
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
        #endregion

        private void GetAllOrgKey(int orgKey, out string comKey, out string branKey, out string depKey)
        {
            comKey = ""; branKey = ""; depKey = "";

            var allOrg = Organization.GetAllOrg();
            var currentOrg = allOrg.Find(x => x.OrgKey == orgKey);

            if (currentOrg.OrgCode.Length == 2)
                comKey = currentOrg.OrgKey.ToString();
            else if (currentOrg.OrgCode.Length == 4)
            {
                var comCode = new string(currentOrg.OrgCode.Take(2).ToArray());
                comKey = allOrg.Where(x => x.OrgCode.Length == 2 && x.OrgCode.Contains(comCode)).FirstOrDefault().OrgKey.ToString();
                branKey = currentOrg.OrgKey.ToString();
            }
            else if (currentOrg.OrgCode.Length == 6)
            {
                var comCode = new string(currentOrg.OrgCode.Take(2).ToArray());
                comKey = allOrg.Where(x => x.OrgCode.Length == 2 && x.OrgCode.Contains(comCode)).FirstOrDefault().OrgKey.ToString();

                var branCode = new string(currentOrg.OrgCode.Take(4).ToArray());
                branKey = allOrg.Where(x => x.OrgCode.Length == 4 && x.OrgCode.Contains(branCode)).FirstOrDefault().OrgKey.ToString();

                depKey = currentOrg.OrgKey.ToString();
            }
        }
    }
}