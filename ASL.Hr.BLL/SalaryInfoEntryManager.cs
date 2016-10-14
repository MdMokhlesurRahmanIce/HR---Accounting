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
   public class SalaryInfoEntryManager
    {
       public CustomList<SalaryHead> GetAllSalaryHeadForSalaryRule()
       {
           return SalaryHead.GetAllSalaryHeadForSalaryRule();
       }
       public CustomList<SalaryRuleBackup> GetAllSalaryRuleBackup()
       {
           return SalaryRuleBackup.GetAllSalaryRuleBackup();
       }
       public CustomList<SalaryRule> GetAllSalaryRuleFormula(string salaryRuleCode)
       {
           return SalaryRule.GetAllSalaryRuleFormula(salaryRuleCode);
       }
       public void SaveSalaryInfo(ref CustomList<EmployeeSalaryTemp> EmployeeSalaryTempList, ref CustomList<EmployeeSalary> DeletedEmployeeSalaryList, ref CustomList<EmployeeSalary> InsertedEmployeeSalaryList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();
               ReSetSPName(ref EmployeeSalaryTempList, ref DeletedEmployeeSalaryList, ref InsertedEmployeeSalaryList);
               blnTranStarted = true;
               conManager.SaveDataCollectionThroughCollection(blnTranStarted, EmployeeSalaryTempList, DeletedEmployeeSalaryList, InsertedEmployeeSalaryList);
               EmployeeSalaryTempList.AcceptChanges();
               DeletedEmployeeSalaryList.AcceptChanges();
               InsertedEmployeeSalaryList.AcceptChanges();
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
       private void ReSetSPName(ref CustomList<EmployeeSalaryTemp> EmployeeSalaryTempList,ref CustomList<EmployeeSalary> DeletedEmployeeSalaryList,ref CustomList<EmployeeSalary> InsertedEmployeeSalaryList)
       {
           #region Employee Salary Temp
           EmployeeSalaryTempList.InsertSpName = "spInsertEmployeeSalaryTemp";
           EmployeeSalaryTempList.UpdateSpName = "spUpdateEmployeeSalaryTemp";
           #endregion
           #region Employee Salary
           InsertedEmployeeSalaryList.InsertSpName = "spInsertEmployeeSalary";
           DeletedEmployeeSalaryList.DeleteSpName = "spDeleteEmployeeSalary";
           #endregion
       }

    }
}
