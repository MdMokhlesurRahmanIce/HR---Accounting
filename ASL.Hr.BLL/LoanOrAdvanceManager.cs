using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
   public class LoanOrAdvanceManager
    {
        private String loanCode = String.Empty;
        public String LoanCode
        {
            get { return loanCode; }
        }
       public CustomList<SalaryHead> GetAllSalaryHead()
       {
           return SalaryHead.GetAllSalaryHead();
       }
       public CustomList<LoanProcess> GetAllLoanProcess(string loanCode)
       {
           return LoanProcess.GetAllLoanProcess(loanCode);
       }
       public CustomList<LoanDefination> GetAllLoanDefination()
       {
           return LoanDefination.GetAllLoanDefination();
       }
       public CustomList<Gen_LookupEnt> GetAllGen_LookupEnt()
       {
           return Gen_LookupEnt.GetAllGen_LookupEnt(12);
       }
       public void SaveLoan(ref CustomList<LoanDefination> LoanDefinitionMaster,ref CustomList<LoanProcess> LoanProcessDetail)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {

               blnTranStarted = true;
               conManager.BeginTransaction();
               ReSetSPName(ref LoanDefinitionMaster, ref LoanProcessDetail);
               GetNewLoanCode(ref conManager, ref LoanDefinitionMaster, ref LoanProcessDetail);
               blnTranStarted = true;

               conManager.SaveDataCollectionThroughCollection(blnTranStarted, LoanDefinitionMaster, LoanProcessDetail);

               LoanDefinitionMaster.AcceptChanges();
               LoanProcessDetail.AcceptChanges();
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
                   blnTranStarted = false;
                   conManager.Dispose();
               }
           }
       }
       private void ReSetSPName(ref CustomList<LoanDefination> LoanDefinationList, ref CustomList<LoanProcess> LoanProcessDetail)
       {
           #region Loan Definition
           LoanDefinationList.InsertSpName = "spInsertLoanDefination";
           LoanDefinationList.UpdateSpName = "spUpdateLoanDefination";
           LoanDefinationList.DeleteSpName = "spDeleteLoanDefination";
           #endregion
           #region Loan Process
           LoanProcessDetail.InsertSpName = "spInsertLoanProcess";
           LoanProcessDetail.UpdateSpName = "spUpdateLoanProcess";
           LoanProcessDetail.DeleteSpName = "spDeleteLoanProcess";
           #endregion
       }
       private void GetNewLoanCode(ref ConnectionManager conManager, ref CustomList<LoanDefination> LoanDefinationList, ref CustomList<LoanProcess> LoanProcessList)
       {
           String newLoanCode = String.Empty;
           try
           {
               CustomList<LoanDefination> addedLoanDefinationList = LoanDefinationList.FindAll(f => f.IsAdded);
               if (addedLoanDefinationList.Count != 0)
               {
                   newLoanCode = StaticInfo.MakeUniqueCode("LoanCode", 20, DateTime.Today.ToString(), "yy", "LC", "-", "");
                   LoanDefinationList[0].LoanCode = newLoanCode;
                   loanCode = newLoanCode;
               }
               else
               {
                   loanCode = LoanDefinationList[0].LoanCode;
               }
               CustomList<LoanProcess> AddedLoanProcess = LoanProcessList.FindAll(f=>f.IsAdded);
               foreach (LoanProcess lP in AddedLoanProcess)
               {
                   lP.LoanCode = LoanDefinationList[0].LoanCode;
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public void DeletelstLoan(ref CustomList<LoanDefination> LoanDefinitionList,ref CustomList<LoanProcess> LoanProcessList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               //ReSetSPName(SalaryRuleBackupList);
               ReSetSPName(ref LoanDefinitionList, ref LoanProcessList);
               conManager.BeginTransaction();
               blnTranStarted = true;
               conManager.SaveDataCollectionThroughCollection(blnTranStarted, LoanProcessList, LoanDefinitionList);
               LoanProcessList.AcceptChanges();
               LoanDefinitionList.AcceptChanges();
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
