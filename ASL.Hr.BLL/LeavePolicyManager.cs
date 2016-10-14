using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class LeavePolicyManager
    {
        private String leavePolicyID = String.Empty;
        public String LeavePolicyID
        {
            get { return leavePolicyID; }
        }

        public CustomList<LeavePolicyMaster> GetAllLeavePolicyMaster()
        {
            return LeavePolicyMaster.GetAllLeavePolicyMaster();
        }
        public CustomList<LeavePolicyMaster> GetSelectedLeavePolicyMaster( int policyid )
        {
            return LeavePolicyMaster.GetSelectedLeavePolicyMaster(policyid);
        }
        public CustomList<LeavePolicyDetails> GetAllLeavePolicyDetails(int leavePolicyID)
        {
            return LeavePolicyDetails.GetAllLeavePolicyDetails(leavePolicyID);
        }
        public void SaveLeavePolicy(ref CustomList<LeavePolicyMaster> LeavePolicyMasterList, ref CustomList<LeavePolicyDetails> LeavePolicyDetailsList, ref int LVPolicyId )
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
               
                blnTranStarted = true;
                conManager.BeginTransaction();
                ReSetSPName(ref LeavePolicyMasterList, ref LeavePolicyDetailsList);
                //GetNewPolicyID(ref conManager, ref LeavePolicyMasterList, ref LeavePolicyDetailsList);
                object scope_Identity = conManager.InsertData(blnTranStarted, LeavePolicyMasterList);
                Int32 SID = Convert.ToInt32(scope_Identity);
                LVPolicyId = SID;
             
                if (SID != 0)
                    foreach (LeavePolicyDetails B in LeavePolicyDetailsList)
                    {
                        B.LeavePolicyID = SID;
                    }
                else
                    foreach (LeavePolicyDetails B in LeavePolicyDetailsList)
                    {
                        B.LeavePolicyID = LeavePolicyMasterList[0].LeavePolicyID;
                    }
                if (SID == 0)
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, LeavePolicyMasterList, LeavePolicyDetailsList);
                    
                else conManager.SaveDataCollectionThroughCollection(blnTranStarted,LeavePolicyDetailsList);
                blnTranStarted = true;
                

                conManager.CommitTransaction();
                LeavePolicyMasterList.AcceptChanges();
                LeavePolicyDetailsList.AcceptChanges();
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
        private void ReSetSPName(ref CustomList<LeavePolicyMaster> LeavePolicyMasterList, ref CustomList<LeavePolicyDetails> LeavePolicyDetailsList)
        {
            #region Leave Policy Master
            LeavePolicyMasterList.InsertSpName = "spInsertLeavePolicyMaster";
            LeavePolicyMasterList.UpdateSpName = "spUpdateLeavePolicyMaster";
            LeavePolicyMasterList.DeleteSpName = "spDeleteLeavePolicyMaster";
            #endregion
            #region Leave Policy Master
            LeavePolicyDetailsList.InsertSpName = "spInsertLeavePolicyDetails";
            LeavePolicyDetailsList.UpdateSpName = "spUpdateLeavePolicyDetails";
            LeavePolicyDetailsList.DeleteSpName = "spDeleteLeavePolicyDetails";
            #endregion
        }
        private void GetNewPolicyID(ref ConnectionManager conManager, ref CustomList<LeavePolicyMaster> LeavePolicyMasterList, ref CustomList<LeavePolicyDetails> LeavePolicyDetailsList)
        {
            String newLeavePolicyID = String.Empty;
            try
            {
                CustomList<LeavePolicyMaster> tempLeavePolicyMasterList = LeavePolicyMasterList.FindAll(f => f.IsAdded);
                if (tempLeavePolicyMasterList.Count != 0)
                {
                    newLeavePolicyID = StaticInfo.MakeUniqueCode("LeavePolicyID", 20, DateTime.Today.ToString(), "yy", "LPI", "-", "");
                    LeavePolicyMasterList[0].LeavePolicyID = newLeavePolicyID.ToInt();
                    leavePolicyID = newLeavePolicyID;
                }
                else
                {
                    leavePolicyID = LeavePolicyMasterList[0].LeavePolicyID.ToString();
                }

                CustomList<LeavePolicyDetails> tempLeavePolicyDetailsList = LeavePolicyDetailsList.FindAll(f => f.IsAdded);
                foreach (LeavePolicyDetails lPD in tempLeavePolicyDetailsList)
                {
                    lPD.LeavePolicyID = leavePolicyID.ToInt();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteLeavePolicy(ref CustomList<LeavePolicyMaster> LeavePolicyMasterList, ref CustomList<LeavePolicyDetails> LeavePolicyDetailsList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                ReSetSPName(ref LeavePolicyMasterList, ref LeavePolicyDetailsList);

                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, LeavePolicyDetailsList, LeavePolicyMasterList);
                conManager.CommitTransaction();
                LeavePolicyDetailsList.AcceptChanges();
                LeavePolicyMasterList.AcceptChanges();
            }
            catch (Exception ex)
            {
                conManager.RollBack();
                throw (ex);
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
    }
}
