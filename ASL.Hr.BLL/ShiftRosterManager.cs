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
   public class ShiftRosterManager
    {
       public CustomList<ShiftPlan> GetAllShiftPlanShiftRoster()
       {
           return ShiftPlan.GetAllShiftPlanShiftRoster();
       }
       public CustomList<ShiftRule> GetAllShiftRule()
       {
           return ShiftRule.GetAllShiftRule();
       }
       public CustomList<ShiftRuleDetail> GetAllShiftRuleDetail()
       {
           return ShiftRuleDetail.GetAllShiftRuleDetail();
       }
       public CustomList<ShiftRoster> GetAllProcessedShiftRoster(string fromDate,string toDate)
       {
           return ShiftRoster.GetAllProcessedShiftRoster(fromDate, toDate);
       }
       public CustomList<ShiftRoster> ProcessShiftRoster(string fromDate, string toDate, string tableName)
       {
           return ShiftRoster.ProcessShiftRoster(fromDate, toDate, tableName);
       }
       public CustomList<ShiftRoster> DeleteExistingShiftRoster(string fromDate, string toDate, string tableName)
       {
           return ShiftRoster.DeleteExistingShiftRoster(fromDate, toDate, tableName);
       }
       public void SaveShiftRoster(ref CustomList<ShiftRoster> ShiftRosterList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPName(ShiftRosterList);

               blnTranStarted = true;

               conManager.SaveDataCollectionThroughCollection(blnTranStarted, ShiftRosterList);

               ShiftRosterList.AcceptChanges();

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
       private void ReSetSPName(CustomList<ShiftRoster> ShiftRosterList)
       {
           #region Shift Plan Master
           ShiftRosterList.InsertSpName = "spInsertShiftRoster";
           ShiftRosterList.UpdateSpName = "spUpdateShiftRoster";
           #endregion
       }
    }
}
