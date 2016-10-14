using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
   public class LeaveAllocationManager
    {
       public void SaveLeaveAllocation(ref CustomList<ASL.Hr.DAO.LeaveAllocation> DeletedLeaveList, ref CustomList<ASL.Hr.DAO.LeaveAllocation> SavedLeaveList)
       {
           var conManager = new ConnectionManager(ConnectionName.HR);
           bool blnTranStarted = false;
           try
           {
               blnTranStarted = true;
               conManager.BeginTransaction();
               DeletedLeaveList.DeleteSpName = "spDeleteLeaveAllocation";
               SavedLeaveList.InsertSpName = "spInsertLeaveAllocation";
               conManager.SaveDataCollectionThroughCollection(blnTranStarted, DeletedLeaveList, SavedLeaveList);
               blnTranStarted = false;
               conManager.CommitTransaction();
               DeletedLeaveList.AcceptChanges();
               SavedLeaveList.AcceptChanges();
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
