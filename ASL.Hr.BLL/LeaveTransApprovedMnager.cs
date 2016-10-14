
using System;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using ASL.Hr.DAO;

namespace ASL.Hr.BLL
{
    public class LeaveTransApprovedMnager
    {
        public CustomList<LeaveTransApproved> GetAllLeaveTransApproved()
        {
            return LeaveTransApproved.GetAllLeaveTransApproved();
        }
        public CustomList<LeaveTransApproved> GetEmpWiseAllLeaveTransApproved(string LeaveYear, string EmployeeCode)
        {
            return LeaveTransApproved.GetEmpWiseAllLeaveTransApproved(LeaveYear, EmployeeCode);
        }
        public CustomList<LeaveTransApproved> GetLeaveEligibleEmp(string EmployeeCode)
        {
            return LeaveTransApproved.GetLeaveEligibleEmp(EmployeeCode);
        }
        public void SaveLeaveTrans(ref CustomList<ASL.Hr.DAO.LeaveTransApproved> LeaveList, ref CustomList<HourlyLeaveTrans> HourlyLeaveTransList)
        {
            var conManager = new ConnectionManager(ConnectionName.HR);
            bool blnTranStarted = false;
            try
            {
                blnTranStarted = true;
                conManager.BeginTransaction();

                ReSetSPName(ref LeaveList, ref HourlyLeaveTransList);
                if (LeaveList.Count != 0)
                {
                    if (LeaveList[0].IsModified)
                    {
                        conManager.SaveDataCollectionThroughCollection(blnTranStarted, LeaveList);
                    }
                    else
                    {
                        conManager.InsertData(blnTranStarted, LeaveList);
                    }
                }
                if (HourlyLeaveTransList.Count != 0)
                {
                    if (HourlyLeaveTransList[0].IsModified)
                    {
                        conManager.SaveDataCollectionThroughCollection(blnTranStarted, HourlyLeaveTransList);
                    }
                    else
                    {
                        conManager.InsertData(blnTranStarted, HourlyLeaveTransList);
                    }
                }
                blnTranStarted = false;
                conManager.CommitTransaction();
                LeaveList.AcceptChanges();
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
        public void DeleteLeaveTransaction(ref CustomList<ASL.Hr.DAO.LeaveTransApproved> LeaveList, ref CustomList<HourlyLeaveTrans> HourlyLeaveList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                ReSetSPName(ref LeaveList, ref HourlyLeaveList);

                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, LeaveList, HourlyLeaveList);
                LeaveList.AcceptChanges();
                HourlyLeaveList.AcceptChanges();

                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
            }
            catch (Exception Ex)
            {
                conManager.RollBack();
                throw Ex;
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
        }
        public void ReSetSPName(ref CustomList<ASL.Hr.DAO.LeaveTransApproved> LeaveList, ref CustomList<HourlyLeaveTrans> HourlyLeaveTrans)
        {
            try
            {
                #region Leave Transaction
                LeaveList.InsertSpName = "spInsertLeaveTransApproved";
                LeaveList.UpdateSpName = "spUpdateLeaveTransApproved";
                LeaveList.DeleteSpName = "spDeleteLeaveTransApproved";
                #endregion
                #region Hourly Leave Transaction
                HourlyLeaveTrans.InsertSpName = "spInsertHourlyLeaveTrans";
                HourlyLeaveTrans.UpdateSpName = "spUpdateHourlyLeaveTrans";
                HourlyLeaveTrans.DeleteSpName = "spDeleteHourlyLeaveTrans";
                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

