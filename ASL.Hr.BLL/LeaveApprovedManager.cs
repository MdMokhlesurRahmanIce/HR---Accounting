using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class LeaveApprovedManager
    {
        public CustomList<LeaveTransApproved> GetUnApprovedDayLeaves()
        {
            return LeaveTransApproved.GetUnApprovedDayLeaves();
        }
        public CustomList<HourlyLeaveTrans> HourlyLeaveApproval()
        {
            return HourlyLeaveTrans.HourlyLeaveApproval();
        }
        public CustomList<LeaveTransApproved> GetUnApprovedDayLeaves(string empKey)
        {
            return LeaveTransApproved.GetUnApprovedDayLeaves(empKey);
        }
        public CustomList<HourlyLeaveTrans> HourlyLeaveApproval(string empKey)
        {
            return HourlyLeaveTrans.HourlyLeaveApproval(empKey);
        }
        public void SaveLeaveApproval(ref CustomList<LeaveTransApproved> LeaveTransApprovedList, ref CustomList<HourlyLeaveTrans> HourlyLeaveTransList)
        {
            var conManager = new ConnectionManager(ConnectionName.HR);
            bool blnTranStarted = false;
            try
            {
                blnTranStarted = true;
                conManager.BeginTransaction();
                LeaveTransApprovedList.UpdateSpName = "spUpdateLeaveTransApproved";
                HourlyLeaveTransList.UpdateSpName = "spUpdateHourlyLeaveTrans";
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, LeaveTransApprovedList, HourlyLeaveTransList);
                blnTranStarted = false;
                conManager.CommitTransaction();
                LeaveTransApprovedList.AcceptChanges();
                HourlyLeaveTransList.AcceptChanges();
                conManager.Dispose();
            }
            catch (Exception ex)
            {
                if (blnTranStarted == true)
                {
                    conManager.RollBack();
                    conManager.Dispose();
                }
                throw (ex);
            }
        }
    }
}
