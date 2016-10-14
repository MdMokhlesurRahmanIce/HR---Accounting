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
    public partial class AttendanceManual : PageBase
    {
        DailyAttendanceManger manager = new DailyAttendanceManger();
        #region Session
        private CustomList<AttendanceManualModification> DailyManualAttendanceList
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
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                    InitializeSession();
                    hfCurrentUser.Value = CurrentUserSession.UserCode;
                    txtFromDate.Text = DateTime.Now.ToShortDateString();
                    txtToDate.Text = DateTime.Now.ToShortDateString();
                    string times = manager.GetBufferTime();
                    string[] items = times.Split(',');
                    if (items.Count() == 4)
                    {
                        txtIntimeBuffer.Text = items[0];
                        txtShiftOutTime.Text = items[1];
                        txtLunchInBuffertime.Text = items[2];
                        txtLunchOutBuffertime.Text = items[3];
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                DailyManualAttendanceList = new CustomList<AttendanceManualModification>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
    }
}