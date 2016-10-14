using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASL.DATA;
using ASL.Hr.DAO;
using ASL.DAL;
using ASL.STATIC;
using System.Collections;
namespace ASL.Hr.BLL
{
    public class DailyAttendanceManger
    {
        public CustomList<DailyAttendance> GetAllAttForDailyAttendanceProcess(string fromDate, string toDate, string searchStr, string PW, string PH, string PLV, string SinglePunch)
        {
            return DailyAttendance.GetAllAttForDailyAttendanceProcess(fromDate, toDate, searchStr, PW, PH, PLV, SinglePunch);
        }
        public CustomList<AttendanceManualModification> GetAllAttForManualProcess(string spName, string fromDate, string toDate, string str)
        {
            return AttendanceManualModification.GetAllAttForManualProcess(spName, fromDate, toDate, str);
        }
        public CustomList<AttnendanceSummary> GetAllAttnendanceSummary(string Workdate)
        {
            return AttnendanceSummary.GetAllAttnendanceSummary(Workdate);
        }
        public string GetDayStatus(Int64 empKey, int shiftID, string workDate)
        {
            return DailyAttendance.GetDayStatus(empKey, shiftID, workDate);
        }
        public Int32 IsWH(Int64 empKey, string workDate)
        {
            return WHCalendar.IsWH(empKey, workDate);
        }
        public Int32 IsLeave(Int64 empKey, string workDate)
        {
            return WHCalendar.IsLeave(empKey, workDate);
        }
        public string GetBufferTime()
        {
            return Hr_MasterSetup.GetAllHr_MasterSetupBufferTime();
        }
        public void ChangeMasterSetupValue(string itemValue, string parms)
        {
            Hr_MasterSetup.ChangeMasterSetupValue(itemValue, parms);
        }
        public void SaveDailyAttendece(ref CustomList<DailyAttendance> DailyAttendenceList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(DailyAttendenceList);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, DailyAttendenceList);

                DailyAttendenceList.AcceptChanges();
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
        private void ReSetSPName(CustomList<DailyAttendance> DailyAttendenceList)
        {
            #region Daily Attendance
            DailyAttendenceList.InsertSpName = "spInsertDailyAttendance";
            #endregion
        }
        public void SaveAttManual(ref CustomList<AttendanceManualModification> ModifiedAttList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                //ReSetSPName(DailyAttendenceList);
                ModifiedAttList.ForEach(f => f.SetAdded());
                ModifiedAttList.InsertSpName = "spInsertAttendanceManualModification";
                ModifiedAttList.DeleteSpName = "spInsertAttendanceManualModification";
                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, ModifiedAttList);

                ModifiedAttList.AcceptChanges();
                conManager.CommitTransaction();
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
                    blnTranStarted = false;
                    conManager.Dispose();
                }
            }
        }
        public void SaveTmpAttEmp(ref CustomList<HRM_Emp> TmpAttEmpList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();
                TmpAttEmpList.ForEach(f => f.SetAdded());
                TmpAttEmpList.InsertSpName = "spInsertTmpAttProcess";

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, TmpAttEmpList);

                TmpAttEmpList.AcceptChanges();
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
    }
}
