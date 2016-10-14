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
using System.Data.SqlClient;
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
    public partial class LeaveTransactionApproval : PageBase
    {
        LeaveApprovedManager manager = new LeaveApprovedManager();
        #region Session Variables
        private CustomList<LeaveTransApproved> _DayLeaveApproval
        {
            get
            {
                if (Session["LeaveTransactionApproval_DayLeaveApproval"] == null)
                    return new CustomList<LeaveTransApproved>();
                else
                    return (CustomList<LeaveTransApproved>)Session["LeaveTransactionApproval_DayLeaveApproval"];
            }
            set
            {
                Session["LeaveTransactionApproval_DayLeaveApproval"] = value;
            }
        }
        private CustomList<HourlyLeaveTrans> _HourlyLeaveApproval
        {
            get
            {
                if (Session["LeaveTransactionApproval_HourlyLeaveApproval"] == null)
                    return new CustomList<HourlyLeaveTrans>();
                else
                    return (CustomList<HourlyLeaveTrans>)Session["LeaveTransactionApproval_HourlyLeaveApproval"];
            }
            set
            {
                Session["LeaveTransactionApproval_HourlyLeaveApproval"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeSession();
            }
        }
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                _DayLeaveApproval = new CustomList<LeaveTransApproved>();
                _HourlyLeaveApproval = new CustomList<HourlyLeaveTrans>();
                string empKey = Request.QueryString.Get("EmpKey");
                if (empKey.IsNullOrEmpty())
                {
                    _DayLeaveApproval = manager.GetUnApprovedDayLeaves();
                    _HourlyLeaveApproval = manager.HourlyLeaveApproval();
                }
                else
                {
                    _DayLeaveApproval = manager.GetUnApprovedDayLeaves(empKey);
                    _HourlyLeaveApproval = manager.HourlyLeaveApproval(empKey);
                }
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Button Events
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<ASL.Hr.DAO.LeaveTransApproved> lstLeaveTransApproved = _DayLeaveApproval.FindAll(f => f.IsApproved == true);
                CustomList<HourlyLeaveTrans> lstHourlyLeaveTrans = _HourlyLeaveApproval.FindAll(f => f.IsApproved == true);
                foreach (ASL.Hr.DAO.LeaveTransApproved L in lstLeaveTransApproved)
                {
                    //   L.IsApproved = true;
                    L.ApprovedBy = "System";
                    L.DateApproved = DateTime.Now;
                }
                foreach (ASL.Hr.DAO.HourlyLeaveTrans H in lstHourlyLeaveTrans)
                {
                    //   H.IsApproved = true;
                    H.ApprovedBy = "System";
                    H.ApprovedDate = DateTime.Now;
                    H.SetModified();
                }
                manager.SaveLeaveApproval(ref lstLeaveTransApproved, ref lstHourlyLeaveTrans);

                ((PageBase)this.Page).SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                InitializeSession();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
    }
}