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
    public partial class LeaveTransactionBulk : PageBase
    {
        ShiftRosterManager ManagerShiftRoster = new ShiftRosterManager();
        //SettingsManager ManagerSettings = new SettingsManager(); 
        LeaveYearManager ManagerLeaveYear = new LeaveYearManager();
        #region Sesson Variable
        private CustomList<ASL.Hr.DAO.ShiftRoster> _ShiftRosterProcess
        {
            get
            {
                if (Session["ShiftRosterProcess"] == null)
                    return new CustomList<ASL.Hr.DAO.ShiftRoster>();
                else
                    return (CustomList<ASL.Hr.DAO.ShiftRoster>)Session["ShiftRosterProcess"];
            }
            set
            {
                Session["ShiftRosterProcess"] = value;
            }
        }
        private CustomList<WHCalendar> WHCalendarList
        {
            get
            {
                if (Session["WHDeclaration_WHCalendarList"] == null)
                    return new CustomList<WHCalendar>();
                else
                    return (CustomList<WHCalendar>)Session["WHDeclaration_WHCalendarList"];
            }
            set
            {
                Session["WHDeclaration_WHCalendarList"] = value;
            }
        }
        private CustomList<AttendanceManualModification> _AttnManual
        {
            get
            {
                if (Session["AttendanceManual_DailyManualAttendanceList"] == null)
                    return new CustomList<AttendanceManualModification>();
                else
                    return (CustomList<AttendanceManualModification>)Session["AttendanceManual_DailyManualAttendanceList"];
            }
            set
            {
                Session["AttendanceManual_DailyManualAttendanceList"] = value;
            }
        }
        private CustomList<WHCalendar> EmpList
        {
            get
            {
                if (Session["WHDeclaration_EmpList"] == null)
                    return new CustomList<WHCalendar>();
                else
                    return (CustomList<WHCalendar>)Session["WHDeclaration_EmpList"];
            }
            set
            {
                Session["WHDeclaration_EmpList"] = value;
            }
        }

        private CustomList<WHCalendar> WHEmpList
        {
            get
            {
                if (Session["WHDeclaration_WHEmpList"] == null)
                    return new CustomList<WHCalendar>();
                else
                    return (CustomList<WHCalendar>)Session["WHDeclaration_WHEmpList"];
            }
            set
            {
                Session["WHDeclaration_WHEmpList"] = value;
            }
        }
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CustomList<ASL.Hr.DAO.EmpFilterSets> S = (CustomList<EmpFilterSets>)Session["ucEmpSearch_FilterSetsList"];
                //_OutOfOfficeInfo = new CustomList<ASL.Hr.DAO.OutOfOffice>();
                WHCalendarList = new CustomList<WHCalendar>();

                //load ddlDayType

                InitializeSession();
                InitializeControls();
            }


        }
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                WHCalendarList = new CustomList<WHCalendar>();
                EmpList = new CustomList<WHCalendar>();
                WHEmpList = new CustomList<WHCalendar>();
                _AttnManual = new CustomList<AttendanceManualModification>();
                _ShiftRosterProcess = new CustomList<ShiftRoster>();

                //Session["View_EmpList"] = new CustomList<HRM_Emp>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void ClearControls()
        {
            try
            {
                FormUtil.ClearForm(this, FormClearOptions.ClearAll, false);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
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
                //ddlLeaveYear.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                //ddlLeaveYear.SelectedValue = LeaveYearList.Find(f => f.IsClosed == false).LeaveYearID; ;

                //int a = ManagerSettings.GetSelectedSettingsInfo("GridDataLoadAtPageLoad")[0].CharType.ToInt();
                //if (a == 1)
                //{
                //    EmpSearchManager manager = new EmpSearchManager();

                //    CustomList<EmployeeInfoForSearch> EmpList = new CustomList<EmployeeInfoForSearch>();
                //    EmpList = manager.GetAllViewEmpForLeave("spGetEmpForLeaveTransaction", ddlLeaveYear.SelectedValue.ToString(), "");
                    
                //    HttpContext.Current.Session[StaticInfo.EmpListSessionVarName] = EmpList;
                //}

               
               
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //CustomList<ShiftRoster> SR = new CustomList<ShiftRoster>();
           // CustomList<ShiftRoster> ExistingSR = new CustomList<ShiftRoster>();
           // string tableName = HttpContext.Current.Session["TableName"].ToString();
           // ExistingSR = ManagerShiftRoster.GetAllShiftRoster(txtFromDate.Text, txtToDate.Text, tableName);
          //  SR = (CustomList<ASL.Hr.DAO.ShiftRoster>)_ShiftRosterProcess;

            ///// Process -1 : All Newly processsed date will be checked with the Existing 
            //foreach (ShiftRoster S in SR)
            //{
            //    if (ExistingSR.Find(f => f.EmployeeKey == S.EmployeeKey && f.ShiftDate == S.ShiftDate).IsNull())
            //        S.SetAdded();
            //    else
            //    {
            //        S.ShiftRosterKey = ExistingSR.Find(f => f.EmployeeKey == S.EmployeeKey && f.ShiftDate == S.ShiftDate).ShiftRosterKey;
            //        S.SetModified();
            //    }
            //}

            ///// Process -2 : Existing Data Delete & Then New Data Save

            //foreach (ShiftRoster S in ExistingSR)
            //{
            //    S.Delete();
            //}
            //foreach (ShiftRoster S in SR)
            //{
            //    S.SetAdded();
            //}

            //ManagerShiftRoster.SaveShiftRosterProcess(ref ExistingSR, ref SR);
            //HttpContext.Current.Session["View_EmpList"] = new CustomList<EmployeeInfoForSearch>();
            //Message.ShowMessageBox("Shift Roster Data Saved Successfully!!!");
            _ShiftRosterProcess = new CustomList<ShiftRoster>();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
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
