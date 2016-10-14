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
   public class MedicalReinversementManager
    {
       public CustomList<Gen_FY> GetAllGen_FY()
       {
           return Gen_FY.GetAllGen_FY();
       }
       public CustomList<LeaveTransApproved> GetLeaveEligibleEmp(string EmployeeCode)
       {
           return LeaveTransApproved.GetLeaveEligibleEmp(EmployeeCode);
       }
       public CustomList<HRM_Emp> GetSearchEmp(string EmployeeCode)
       {
           return HRM_Emp.GetSearchEmp(EmployeeCode);
       }
       public CustomList<HRM_EmpFamDet> GetAllHRM_EmpFamDetByFamKey(long empKey)
       {
           return HRM_EmpFamDet.GetAllHRM_EmpFamDetByFamKey(empKey);
       }
       public CustomList<CustomerWisePer> GetAllCustomerInfo(string EmpCode)
       {
           return CustomerWisePer.GetAllCustomerInfo(EmpCode);
       }
       public MedicalReinSetup GetAllMedicalBalance(string fyKey,string empKey)
       {
           return MedicalReinSetup.GetAllMedicalBalance(fyKey, empKey);
       }
       public CustomList<MedicalReinTrans> GetAllMedicalReinTrans(string empKey,string fyKey)
       {
           return MedicalReinTrans.GetAllMedicalReinTrans(empKey,fyKey);
       }
       public void SaveMedicalAllowance(ref CustomList<MedicalReinTrans> MedicalReinTransList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPName(MedicalReinTransList);

               blnTranStarted = true;

               conManager.SaveDataCollectionThroughCollection(blnTranStarted, MedicalReinTransList);
               //object scope_Identity = conManager.InsertData(blnTranStarted, BankKist);

               MedicalReinTransList.AcceptChanges();

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
       public void SaveCustomerInfo(ref CustomList<CustomerWisePer> CustomerList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPNameCustomerInfo(CustomerList);

               blnTranStarted = true;

               conManager.SaveDataCollectionThroughCollection(blnTranStarted, CustomerList);
               //object scope_Identity = conManager.InsertData(blnTranStarted, BankKist);

               CustomerList.AcceptChanges();

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
       private void ReSetSPName(CustomList<MedicalReinTrans> MedicalReinTransList)
       {
           #region Leave Year
           MedicalReinTransList.InsertSpName = "spInsertMedicalReinTrans";
           MedicalReinTransList.UpdateSpName = "spUpdateMedicalReinTrans";
           MedicalReinTransList.DeleteSpName = "spDeleteMedicalReinTrans";
           #endregion
       }
       private void ReSetSPNameCustomerInfo(CustomList<CustomerWisePer> CustomerInfo)
       {
           #region Leave Year
           CustomerInfo.InsertSpName = "spInsertCustomerWisePer";
           CustomerInfo.UpdateSpName = "spUpdateCustomerWisePer";
           CustomerInfo.DeleteSpName = "spDeleteCustomerWisePer";
           #endregion
       }
    }
}
