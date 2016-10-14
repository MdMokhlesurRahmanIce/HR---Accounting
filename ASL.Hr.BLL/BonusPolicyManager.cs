using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
   public class BonusPolicyManager
    {
       public CustomList<SalaryHead> GetAllSalaryHeadForSalaryRule()
       {
           return SalaryHead.GetAllSalaryHeadForSalaryRule();
       }
       public CustomList<BonusPolicyMaster> GetAllBonusPolicyMaster()
       {
           return BonusPolicyMaster.GetAllBonusPolicyMaster();
       }
       public CustomList<BonusPolicyDetails> GetAllBonusPolicyDetails(Int32 policyID)
       {
           return BonusPolicyDetails.GetAllBonusPolicyDetails(policyID);
       }
       public CustomList<Gen_LookupEnt> GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup entitySetup)
       {
           return Gen_LookupEnt.GetAllGen_LookupEnt(entitySetup);
       }
       public void SaveBonusPolicy(ref CustomList<BonusPolicyMaster> BonusPolicyMasterList, ref CustomList<BonusPolicyDetails> BonusPolicyDetailsList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPName(BonusPolicyMasterList, BonusPolicyDetailsList);
               Int32 policyID = BonusPolicyMasterList[0].PolicyID;
               blnTranStarted = true;
               if (BonusPolicyMasterList[0].IsAdded)
                   policyID = Convert.ToInt32(conManager.InsertData(blnTranStarted, BonusPolicyMasterList));
               else
                   conManager.SaveDataCollectionThroughCollection(blnTranStarted, BonusPolicyMasterList);
               var bonusPolicyDetails = (CustomList<BonusPolicyDetails>)BonusPolicyDetailsList;
               bonusPolicyDetails.ForEach(x => x.PolicyID = policyID);
               conManager.SaveDataCollectionThroughCollection(blnTranStarted, bonusPolicyDetails);

               BonusPolicyMasterList.AcceptChanges();
               bonusPolicyDetails.AcceptChanges();

               conManager.CommitTransaction();
               blnTranStarted = false;
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
       public void DeleteBonusPolicy(ref CustomList<BonusPolicyMaster> BonusPolicyMasterList, ref CustomList<BonusPolicyDetails> BonusPolicyDetailsList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               ReSetSPName(BonusPolicyMasterList, BonusPolicyDetailsList);

               conManager.BeginTransaction();
               blnTranStarted = true;
               conManager.SaveDataCollectionThroughCollection(blnTranStarted, BonusPolicyDetailsList, BonusPolicyMasterList);
               conManager.CommitTransaction();
               BonusPolicyDetailsList.AcceptChanges();
               BonusPolicyMasterList.AcceptChanges();

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
       private void ReSetSPName(CustomList<BonusPolicyMaster> BonusPolicyMasterList, CustomList<BonusPolicyDetails> BonusPolicyDetailsList)
       {
           #region Bank
           BonusPolicyMasterList.InsertSpName = "spInsertBonusPolicyMaster";
           BonusPolicyMasterList.UpdateSpName = "spUpdateBonusPolicyMaster";
           BonusPolicyMasterList.DeleteSpName = "spDeleteBonusPolicyMaster";
           #endregion
           #region Branch
           BonusPolicyDetailsList.InsertSpName = "spInsertBonusPolicyDetails";
           BonusPolicyDetailsList.UpdateSpName = "spUpdateBonusPolicyDetails";
           BonusPolicyDetailsList.DeleteSpName = "spDeleteBonusPolicyDetails";
           #endregion
       }
    }
}
