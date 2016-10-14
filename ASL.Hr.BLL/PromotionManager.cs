using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class PromotionManager
    {
        public CustomList<TransferAndPromotionHistory> GetAllExistingInfoForPromotion(string EmpCode, Int32 promotionOrTransferCritaria)
        {
            return TransferAndPromotionHistory.GetAllExistingInfoForPromotion(EmpCode, promotionOrTransferCritaria);
        }
        public CustomList<Gen_LookupEnt> GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup entitySetup)
        {
            return Gen_LookupEnt.GetAllGen_LookupEnt(entitySetup);
        }
        public CustomList<LeaveTransApproved> GetLeaveEligibleEmp(string EmployeeCode)
        {
            return LeaveTransApproved.GetLeaveEligibleEmp(EmployeeCode);
        }
        public CustomList<TransferAndPromotionHistory> GetAllEmpForTransferApproval()
        {
            return TransferAndPromotionHistory.GetAllEmpForTransferApproval();
        }
        public CustomList<TransferAndPromotionHistory> GetAllTransferApproval()
        {
            return TransferAndPromotionHistory.GetAllTransferApproval();
        }
        public CustomList<TransferAndPromotionHistory> GetAllEmpForPromotionApproval()
        {
            return TransferAndPromotionHistory.GetAllEmpForPromotionApproval();
        }
        public CustomList<TransferAndPromotionHistory> GetAllPromotionApproval()
        {
            return TransferAndPromotionHistory.GetAllPromotionApproval();
        }
        public CustomList<SalaryRuleBackup> GetAllSalaryRuleBackup()
        {
            return SalaryRuleBackup.GetAllSalaryRuleBackup();
        }
        public void SavePromotion(ref CustomList<TransferAndPromotionHistory> PromotionList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();
                //ReSetSPName(MedicalReinTransList);
                PromotionList.InsertSpName = "spInsertTransferAndPromotionHistory";
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, PromotionList);
                //object scope_Identity = conManager.InsertData(blnTranStarted, BankKist);
                PromotionList.AcceptChanges();

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
