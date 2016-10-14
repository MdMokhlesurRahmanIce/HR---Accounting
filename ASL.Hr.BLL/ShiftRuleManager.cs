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
   public class ShiftRuleManager
    {
       public CustomList<ShiftRule> GetAllShiftRule()
       {
           return ShiftRule.doSearch(string.Empty);
       }
       public CustomList<ShiftPlan> GetAllShiftPlan()
       {
           return ShiftPlan.GetAllShiftPlan();
       }
       public CustomList<ShiftRuleDetail> GetAllShiftRuleDetail(int shiftRuleKey)
       {
           return ShiftRuleDetail.GetAllShiftRuleDetail(shiftRuleKey);
       }
       public void SaveShiftRule(CustomList<ASL.Hr.DAO.ShiftRule> ShiftRuleMasterList, CustomList<ASL.Hr.DAO.ShiftRuleDetail> ShiftRuleDetail)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPName(ref ShiftRuleMasterList,ref ShiftRuleDetail);

               Int32 ShiftRuleKey = ShiftRuleMasterList[0].ShiftRuleKey;
               blnTranStarted = true;
               if (ShiftRuleMasterList[0].IsAdded)
                   ShiftRuleKey = Convert.ToInt32(conManager.InsertData(blnTranStarted, ShiftRuleMasterList));
               else
                   conManager.SaveDataCollectionThroughCollection(blnTranStarted, ShiftRuleMasterList);
               var ShiftDetails = (CustomList<ShiftRuleDetail>)ShiftRuleDetail;
               ShiftDetails.ForEach(x => x.ShiftRuleKey = ShiftRuleKey);
               conManager.SaveDataCollectionThroughCollection(blnTranStarted, ShiftDetails);

               ShiftRuleMasterList.AcceptChanges();
               ShiftRuleDetail.AcceptChanges();
               
               GetNewShiftRuleID(ref conManager, ref ShiftRuleMasterList, ref ShiftRuleDetail);
               blnTranStarted = true;

               conManager.SaveDataCollectionThroughCollection(blnTranStarted, ShiftRuleMasterList, ShiftRuleDetail);

               ShiftRuleMasterList.AcceptChanges();
               ShiftRuleDetail.AcceptChanges();

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
       private void GetNewShiftRuleID(ref ConnectionManager conManager, ref CustomList<ASL.Hr.DAO.ShiftRule> ShiftRuleMasterList, ref CustomList<ASL.Hr.DAO.ShiftRuleDetail> ShiftRuleDetail)
       {
           try
           {
               CustomList<ASL.Hr.DAO.ShiftRuleDetail> tempShiftRuleDetailList = ShiftRuleDetail.FindAll(f => f.IsAdded);
               foreach (ASL.Hr.DAO.ShiftRuleDetail sRD in tempShiftRuleDetailList)
               {
                   sRD.ShiftRuleKey = ShiftRuleMasterList[0].ShiftRuleKey;
               }
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }
       private void ReSetSPName(ref CustomList<ASL.Hr.DAO.ShiftRule> ShiftRuleMasterList,ref CustomList<ASL.Hr.DAO.ShiftRuleDetail> ShiftRuleDetail)
       {
           #region Shift Rule Master
           ShiftRuleMasterList.InsertSpName = "spInsertShiftRule";
           ShiftRuleMasterList.UpdateSpName = "spUpdateShiftRule";
           ShiftRuleMasterList.DeleteSpName = "spDeleteShiftRule";
           #endregion
           #region shift Rule Detail
           ShiftRuleDetail.InsertSpName = "spInsertShiftRuleDetail";
           ShiftRuleDetail.UpdateSpName = "spUpdateShiftRuleDetail";
           ShiftRuleDetail.DeleteSpName = "spDeleteShiftRuleDetail";
           #endregion
       }
       public void DeleteShiftRule(CustomList<ASL.Hr.DAO.ShiftRule> ShiftRuleMasterList, CustomList<ASL.Hr.DAO.ShiftRuleDetail> ShiftRuleDetail)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               ReSetSPName(ref ShiftRuleMasterList,ref ShiftRuleDetail);

               conManager.BeginTransaction();
               blnTranStarted = true;
               conManager.SaveDataCollectionThroughCollection(blnTranStarted, ShiftRuleDetail, ShiftRuleMasterList);
               ShiftRuleMasterList.AcceptChanges();
               ShiftRuleDetail.AcceptChanges();
               conManager.CommitTransaction();
               blnTranStarted = false;
               conManager.Dispose();
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
                   conManager.Dispose();
               }
           }
       }
    }
}
