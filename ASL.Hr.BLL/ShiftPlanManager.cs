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
    public class ShiftPlanManager
    {
        private System.Int64 shiftID;
        public System.Int64 _ShiftID
        {
            get
            {
                return shiftID;
            }
            set
            {
                shiftID = value;
            }
        }
        public CustomList<Gen_LookupEnt> GetAllGen_LookupEnt()
        {
            return Gen_LookupEnt.GetAllGen_LookupEnt(13);
        }
        public CustomList<ShiftPlan> GetAllShiftPlan()
        {
            return ShiftPlan.GetAllShiftPlan();
        }
        public CustomList<ShiftBreakInfo> GetAllShiftBreakInfo(Int64 shiftID)
        {
            return ShiftBreakInfo.GetAllShiftBreakInfo(shiftID);
        }
        public CustomList<ShiftPlan> GetAllShift()
        {
            return ShiftPlan.GetAllShift();
        }
        public void SaveShiftPlan(ref CustomList<ShiftPlan> ShiftPlanMasterList, ref CustomList<ShiftBreakInfo> ShiftBreakInfoList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(ShiftPlanMasterList, ShiftBreakInfoList);
                Int64 ShiftPlanID = ShiftPlanMasterList[0].ShiftID;
                blnTranStarted = true;
                if (ShiftPlanMasterList[0].IsAdded)
                    ShiftPlanID = Convert.ToInt32(conManager.InsertData(blnTranStarted, ShiftPlanMasterList));
                else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, ShiftPlanMasterList);
                shiftID = ShiftPlanID;
                var addr = (CustomList<ShiftBreakInfo>)ShiftBreakInfoList;
                addr.ForEach(x => x.ShiftId = ShiftPlanID);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, addr);

                ShiftPlanMasterList.AcceptChanges();
                ShiftBreakInfoList.AcceptChanges();

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
        private void ReSetSPName(CustomList<ShiftPlan> ShiftPlanMasterList, CustomList<ShiftBreakInfo> ShiftBreakInfoList)
        {
            #region Shift Plan Master
            ShiftPlanMasterList.InsertSpName = "spInsertShiftPlan";
            ShiftPlanMasterList.UpdateSpName = "spUpdateShiftPlan";
            ShiftPlanMasterList.DeleteSpName = "spDeleteShiftPlan";
            #endregion
            #region shift Break Info
            ShiftBreakInfoList.InsertSpName = "spInsertShiftBreakInfo";
            ShiftBreakInfoList.UpdateSpName = "spUpdateShiftBreakInfo";
            ShiftBreakInfoList.DeleteSpName = "spDeleteShiftBreakInfo";
            #endregion
        }
        public void DeleteShiftPlan(ref CustomList<ShiftPlan> ShiftPlanMasterList, ref CustomList<ShiftBreakInfo> ShiftPlanBreakInfoList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                ReSetSPName(ShiftPlanMasterList, ShiftPlanBreakInfoList);

                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, ShiftPlanBreakInfoList, ShiftPlanMasterList);
                ShiftPlanBreakInfoList.AcceptChanges();
                ShiftPlanMasterList.AcceptChanges();
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
