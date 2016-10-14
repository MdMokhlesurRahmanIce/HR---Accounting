using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
   public class BankManager
    {
       public CustomList<Gen_Bank> GetAllGen_Bank()
       {
           return Gen_Bank.GetAllGen_Bank();
       }
       public CustomList<Bank_Branch> GetAllBank_Branch(Int32 bankKey)
       {
           return Bank_Branch.GetAllBank_Branch(bankKey);
       }
        public void SaveBank(ref CustomList<Gen_Bank> BankMasterList, ref CustomList<Bank_Branch> BankBranchList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(BankMasterList, BankBranchList);
                Int32 bankKey = BankMasterList[0].BankKey;
                blnTranStarted = true;
                if (BankMasterList[0].IsAdded)
                    bankKey = Convert.ToInt32(conManager.InsertData(blnTranStarted, BankMasterList));
                else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, BankMasterList);
                var bankBranch = (CustomList<Bank_Branch>)BankBranchList;
                bankBranch.ForEach(x => x.BankKey = bankKey);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, bankBranch);

                BankMasterList.AcceptChanges();
                BankBranchList.AcceptChanges();

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
        private void ReSetSPName(CustomList<Gen_Bank> BankMasterList, CustomList<Bank_Branch> BankBranchList)
        {
            #region Bank 
            BankMasterList.InsertSpName = "spInsertGen_Bank";
            BankMasterList.UpdateSpName = "spUpdateGen_Bank";
            BankMasterList.DeleteSpName = "spDeleteGen_Bank";
            #endregion
            #region Branch
            BankBranchList.InsertSpName = "spInsertBank_Branch";
            BankBranchList.UpdateSpName = "spUpdateBank_Branch";
            BankBranchList.DeleteSpName = "spDeleteBank_Branch";
            #endregion
        }
    }
}
