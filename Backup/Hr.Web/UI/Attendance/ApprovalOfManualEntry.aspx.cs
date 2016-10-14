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
using Hr.Web.Controls;
using System.Collections;
using System.Data.SqlClient;

namespace Hr.Web.UI.Attendance
{
    public partial class ApprovalOfManualEntry : PageBase
    {
        ApprovalOfManualEntryManager manager = new ApprovalOfManualEntryManager();
        #region Constructur
        public ApprovalOfManualEntry()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variable
        private CustomList<HRM_Emp> UserList
        {
            get
            {
                if (Session["ApprovalOfManualEntry_UserList"] == null)
                    return new CustomList<HRM_Emp>();
                else
                    return (CustomList<HRM_Emp>)Session["ApprovalOfManualEntry_UserList"];
            }
            set
            {
                Session["ApprovalOfManualEntry_UserList"] = value;
            }
        }
        private CustomList<AttendanceManualModification> AttManualList
        {
            get
            {
                if (Session["ApprovalOfManualEntry_AttManualList"] == null)
                    return new CustomList<AttendanceManualModification>();
                else
                    return (CustomList<AttendanceManualModification>)Session["ApprovalOfManualEntry_AttManualList"];
            }
            set
            {
                Session["ApprovalOfManualEntry_AttManualList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmployeeName.Attributes.Add("readonly", "true");
            if (!IsPostBack)
            {
                InitializeSession();
                hfCurrentUser.Value = CurrentUserSession.UserCode;
              //  txtFromDate.Text = DateTime.Now.ToShortDateString();
              //  txtToDate.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (eventTarget == "SearchEmployee")
                {
                    HRM_Emp searchEmp = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as HRM_Emp;
                    if (searchEmp.IsNotNull())
                    {
                        CustomList<HRM_Emp> empList = new CustomList<HRM_Emp>();
                        txtEmployeeName.Text = searchEmp.EmpName;
                        // empList.Add(searchEmp);
                        // Session["View_EmpList"] = empList;
                    }
                }

            }
        }
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                UserList = new CustomList<HRM_Emp>();
                AttManualList = new CustomList<AttendanceManualModification>();
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
                //CommonHelper.CreateSearchString();
                CustomList<HRM_Emp> EmpList = manager.ManualEntryUserList();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("EmpCode", "Employee Code");
                columns.Add("EmpName", "Employee Name");

                StaticInfo.SearchItem(EmpList, "Emp Info", "SearchEmployee", SearchColumnConfig.GetColumnConfig(typeof(HRM_Emp), columns), 500, GlobalEnums.enumSearchType.StoredProcedured);
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
    }
}