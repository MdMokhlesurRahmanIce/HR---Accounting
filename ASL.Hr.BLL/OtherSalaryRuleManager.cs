using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class OtherSalaryRuleManager
    {
        public CustomList<SalaryHead> GetAllSalaryHead()
        {
            return SalaryHead.GetAllSalaryHead();
        }
        public CustomList<ShiftPlan> GetAllShift()
        {
            return ShiftPlan.GetAllShift();
        }
        public CustomList<LeavePolicyMaster> GetLeaveType()
        {
            return LeavePolicyMaster.GetLeaveType();
        }
        public CustomList<OtherSalaryRule> GetAllOtherSalaryRule()
        {
            return OtherSalaryRule.GetAllOtherSalaryRule();
        }
        public CustomList<HourWisePayment> GetAllHourWisePayment(Int32 ruleKey)
        {
            return HourWisePayment.GetAllHourWisePayment(ruleKey);
        }
        public void SaveOtherSalaryRule(ref CustomList<OtherSalaryRule> OtherSalaryRuleList, ref CustomList<HourWisePayment> lstHourWisePayment)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {

                blnTranStarted = true;
                conManager.BeginTransaction();
                ReSetSPName(ref OtherSalaryRuleList, ref lstHourWisePayment);
                if (OtherSalaryRuleList[0].RuleKey == 0)
                {
                    object scope_Identity = conManager.InsertData(blnTranStarted, OtherSalaryRuleList);
                    Int32 RuleKey = Convert.ToInt32(scope_Identity);
                    foreach (HourWisePayment hWP in lstHourWisePayment)
                    {
                        hWP.RuleKey = RuleKey;
                    }
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, OtherSalaryRuleList, lstHourWisePayment);
                }
                else
                {
                    foreach (HourWisePayment hWP in lstHourWisePayment)
                    {
                        hWP.RuleKey = OtherSalaryRuleList[0].RuleKey;
                    }
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, OtherSalaryRuleList, lstHourWisePayment);
                }
                blnTranStarted = true;
                conManager.CommitTransaction();
                OtherSalaryRuleList.AcceptChanges();
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
        private void ReSetSPName(ref CustomList<OtherSalaryRule> OtherSalaryRuleList, ref CustomList<HourWisePayment> lstHourWisePayment)
        {
            #region Leave Policy Master
            OtherSalaryRuleList.InsertSpName = "spInsertOtherSalaryRule";
            OtherSalaryRuleList.UpdateSpName = "spUpdateOtherSalaryRule";
            OtherSalaryRuleList.DeleteSpName = "spDeleteOtherSalaryRule";
            #endregion
            #region Leave Policy Master
            lstHourWisePayment.InsertSpName = "spInsertHourWisePayment";
            lstHourWisePayment.UpdateSpName = "spUpdateHourWisePayment";
            lstHourWisePayment.DeleteSpName = "spDeleteHourWisePayment";
            #endregion
        }
    }
}
