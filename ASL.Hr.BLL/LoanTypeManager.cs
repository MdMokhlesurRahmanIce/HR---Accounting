using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
   public class LoanTypeManager
    {
       public CustomList<LoanType> GetAllLoanType()
        {
            return LoanType.GetAllLoanType();
        }
       public void SaveLoanType(ref CustomList<LoanType> LoanTypeList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPName(LoanTypeList);
               Int32 loanTypeID = LoanTypeList[0].LoanTypeID;
               blnTranStarted = true;
               if (LoanTypeList[0].IsAdded)
                   loanTypeID = Convert.ToInt32(conManager.InsertData(blnTranStarted, LoanTypeList));
               else
                   conManager.SaveDataCollectionThroughCollection(blnTranStarted, LoanTypeList);
               LoanTypeList.AcceptChanges();
               LoanTypeList.AcceptChanges();

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
       private void ReSetSPName(CustomList<LoanType> LoanTypeList)
       {
           #region Bank
           LoanTypeList.InsertSpName = "spInsertLoanType";
           LoanTypeList.UpdateSpName = "spUpdateLoanType";
           LoanTypeList.DeleteSpName = "spDeleteLoanType";
           #endregion
       }
    }
}
