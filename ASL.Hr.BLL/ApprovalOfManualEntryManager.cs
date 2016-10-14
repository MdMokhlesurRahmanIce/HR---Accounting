using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
   public class ApprovalOfManualEntryManager
    {
       public CustomList<HRM_Emp> ManualEntryUserList()
       {
           return HRM_Emp.ManualEntryUserList();
       }
       public CustomList<AttendanceManualModification> GetEmpAttManualApproved(string fromDate, string toDate)
       {
           return AttendanceManualModification.GetEmpAttManualApproved(fromDate, toDate);
       }
       public void SaveAttManual(CustomList<AttendanceManualModification> AttManualList,CustomList<DailyAttendance> ManualDailyAtt)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPName(AttManualList, ManualDailyAtt);

               blnTranStarted = true;

               //conManager.SaveDataCollectionThroughCollection(blnTranStarted, AttManualList, ManualDailyAtt);
               conManager.SaveDataCollectionThroughCollection(blnTranStarted, AttManualList);

               AttManualList.AcceptChanges();
               ManualDailyAtt.AcceptChanges();

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
       private void ReSetSPName(CustomList<AttendanceManualModification> AttManualList, CustomList<DailyAttendance> ManualDailyAtt)
       {
           #region Approve Att Manual
           AttManualList.UpdateSpName = "spUpdateAttendanceManualModification";
           ManualDailyAtt.InsertSpName = "spInsertDailyAttendance";
           #endregion
       }
    }
}
