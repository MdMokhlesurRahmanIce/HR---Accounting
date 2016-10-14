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
    public partial class AttendanceProcess : PageBase
    {
        DailyAttendanceManger dailyAttManger = new DailyAttendanceManger();
        #region Constructur
        public AttendanceProcess()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session
        private CustomList<DailyAttendance> DailyAttendanceList
        {
            get
            {
                if (Session["AttendanceProcess_DailyAttendanceList"] == null)
                    return new CustomList<DailyAttendance>();
                else
                    return (CustomList<DailyAttendance>)Session["AttendanceProcess_DailyAttendanceList"];
            }
            set
            {
                Session["AttendanceProcess_DailyAttendanceList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                    String fromDate = HttpContext.Current.Request.QueryString["FromDate"];
                    String toDate = HttpContext.Current.Request.QueryString["ToDate"];
                    if (fromDate.IsNotNullOrEmpty())
                        txtFromDate.Text = fromDate;
                    else
                        txtFromDate.Text = DateTime.Today.ToShortDateString();
                    if (toDate.IsNotNullOrEmpty())
                        txtToDate.Text = toDate;
                    else
                        txtToDate.Text = DateTime.Today.ToShortDateString();

                    
                    CustomList<ASL.Hr.DAO.AttnendanceSummary> AttnSummaryOfLastProcessDate = dailyAttManger.GetAllAttnendanceSummary("");
                    txtLastProcessdate.Text = AttnSummaryOfLastProcessDate[0].Workdate;
                    txtSummary.Text = "Total Employee : " + AttnSummaryOfLastProcessDate[0].TotalEmployee.ToString()+ ", Attn Processed : "+ AttnSummaryOfLastProcessDate[0].ProcessedEmployee.ToString() +
                        ", Present : "+ AttnSummaryOfLastProcessDate[0].Present.ToString() + ", Late : "+ AttnSummaryOfLastProcessDate[0].Late.ToString() +", Absent : " + AttnSummaryOfLastProcessDate[0].Absent.ToString()+
                    ", Leave : " + AttnSummaryOfLastProcessDate[0].Leave.ToString() + ", WH : " + AttnSummaryOfLastProcessDate[0].WH.ToString() + ", Others : "+
                    AttnSummaryOfLastProcessDate[0].Others.ToString();
                    InitializeSession();
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
                DailyAttendanceList = new CustomList<DailyAttendance>();
                //DailyAttendanceList = dailyAttManger.GetAllAttForDailyAttendanceProcess(
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region process save
        protected void btnProcessSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<DailyAttendance> FDailyAttendence = DailyAttendanceList;
                FDailyAttendence.ForEach(s=>s.SetAdded());
                if (FDailyAttendence.Count != 0)
                {
                    if (!CheckUserAuthentication(FDailyAttendence)) return;
                    dailyAttManger.SaveDailyAttendece(ref FDailyAttendence);
                    FDailyAttendence = new CustomList<DailyAttendance>();
                    this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
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
        #endregion
    }
}