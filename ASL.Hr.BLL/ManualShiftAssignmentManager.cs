using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASL.DATA;
using ASL.Hr.DAO;
using ASL.DAL;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
  public class ManualShiftAssignmentManager
    {
      public CustomList<ShiftPlan> GetAllShiftPlanShiftRoster()
      {
          return ShiftPlan.GetAllShiftPlanShiftRoster();
      }
      public void SaveShiftRosterManualAssignment(ref CustomList<ShiftRoster> ShiftRosterList)
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
            #region Shift Manual Shift Assignment
            ShiftRosterList.InsertSpName = "spInsertShiftRosterManualAssign";
            #endregion
        }
        public void UpdateManualShift(ref CustomList<ShiftRoster> ShiftRosterList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPNameManualShift(ShiftRosterList);

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
        private void ReSetSPNameManualShift(CustomList<ShiftRoster> ShiftRosterList)
        {
            #region Shift Manual Shift Assignment
            ShiftRosterList.InsertSpName = "spUpdateAssignManualShift";
            #endregion
        }
    }
}
