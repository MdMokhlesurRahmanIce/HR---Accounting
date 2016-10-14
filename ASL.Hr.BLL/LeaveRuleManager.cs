using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class LeaveRuleManager
    {

        
        public CustomList<LeaveRuleMaster> GetAllLeaveRuleMaster()
        {
            return LeaveRuleMaster.GetAllLeaveRuleMaster();
        }
        public CustomList<LeaveRuleMaster> GetSelectedLeaveRule(int LeaveRuleKey)
        {
            return LeaveRuleMaster.GetSelectedLeaveRule(LeaveRuleKey);
        }
        public CustomList<LeaveRuleDetails> GetSelectedLeaveRuleDetails(int LeaveRuleKey)
        {
            return LeaveRuleDetails.GetSelectedLeaveRuleDetails(LeaveRuleKey);
        }
        public CustomList<LeavePolicyMaster> GetSelectedLeavePolicyMaster(int policyid)
        {
            return LeavePolicyMaster.GetSelectedLeavePolicyMaster(policyid);
        }

        public void SaveLeaveRule(ref CustomList<LeaveRuleMaster> LeaveRule, ref CustomList<LeavePolicyMaster> LeavePolicyDetails, ref int SID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {

                blnTranStarted = true;
                conManager.BeginTransaction();
                ReSetSPName(ref LeaveRule);
      
                object scope_Identity = conManager.InsertData(blnTranStarted, LeaveRule);
                Int32 LeaveRuleKey = Convert.ToInt32(scope_Identity);

                SID = LeaveRuleKey;
                CustomList<LeaveRuleDetails> objRuleDetails = new CustomList<LeaveRuleDetails>();
                if (SID != 0)
                    foreach (ASL.Hr.DAO.LeavePolicyMaster B in LeavePolicyDetails)
                    {
                        LeaveRuleDetails obj = new LeaveRuleDetails();
                        obj.LeaveRuleKey = SID;
                        obj.LeavePolicyId = B.LeavePolicyID;
                        objRuleDetails.Add(obj);
                    }
                else foreach (ASL.Hr.DAO.LeavePolicyMaster B in LeavePolicyDetails)
                    {
                        //CustomList<ASL.Hr.DAO.LeavePolicyMaster> obj = lstLeaveRuleDetails.FindAll(f => f.IsDeleted == false);
                        CustomList<LeaveRuleDetails> objLRD = LeaveRuleDetails.GetSelectedLeaveRuleDetails(LeaveRule[0].LeaveRuleKey);
                        LeaveRuleDetails obj = new LeaveRuleDetails();
                        obj.LeaveRuleKey = LeaveRule[0].LeaveRuleKey;
                        obj.LeavePolicyId = B.LeavePolicyID;
                        if (objLRD.Find(f => f.LeavePolicyId == obj.LeavePolicyId).IsNull())
                            obj.SetAdded();
                       
                        else
                        {
                            obj.LeaveRuleDetailsKey = objLRD.Find(f => f.LeavePolicyId == obj.LeavePolicyId).LeaveRuleDetailsKey;
                            if (B.IsDeleted.IsTrue()) obj.Delete();
                            else obj.SetModified();
                        }

                        objRuleDetails.Add(obj);
                    }
                ReSetSPName(ref objRuleDetails);
                if (SID == 0)
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, LeaveRule, objRuleDetails);

                else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, objRuleDetails);
                
             

                blnTranStarted = true;

                conManager.CommitTransaction();
                LeaveRule.AcceptChanges();
                objRuleDetails.AcceptChanges();
                
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
        private void ReSetSPName(ref CustomList<LeaveRuleMaster> LeaveRuleList)
        {
            #region Leave Policy Master
            LeaveRuleList.InsertSpName = "spInsertLeaveRuleMaster";
            LeaveRuleList.UpdateSpName = "spUpdateLeaveRuleMaster";
            LeaveRuleList.DeleteSpName = "spDeleteLeaveRuleMaster";
            #endregion
        }
        private void ReSetSPName(ref CustomList<LeaveRuleDetails> LeaveRuleDetails)
        {

            #region Leave Rule Details
            LeaveRuleDetails.InsertSpName = "spInsertLeaveRuleDetails";
            LeaveRuleDetails.UpdateSpName = "spUpdateLeaveRuleDetails";
            LeaveRuleDetails.DeleteSpName = "spDeleteLeaveRuleDetails";
            #endregion

        }

        public void DeleteLeaveRule(ref CustomList<LeaveRuleMaster> LeaveRule, ref CustomList<LeaveRuleDetails> LeaveRuleDetails)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                ReSetSPName(ref LeaveRule);
                ReSetSPName(ref LeaveRuleDetails);

                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, LeaveRule, LeaveRuleDetails);
                conManager.CommitTransaction();
                LeaveRule.AcceptChanges();
                LeaveRuleDetails.AcceptChanges();
             
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
