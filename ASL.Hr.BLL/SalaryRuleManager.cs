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
    public class SalaryRuleManager
    {
        private String salaryRuleCode = String.Empty;
        public String SalaryRuleCode
        {
            get { return salaryRuleCode; }
        }
        public CustomList<SalaryHead> GetAllSalaryHeadForSalaryRule()
        {
            return SalaryHead.GetAllSalaryHeadForSalaryRule();
        }
        public CustomList<SalaryRuleBackup> GetAllSalaryRuleBackup()
        {
            return SalaryRuleBackup.doSearch("");
        }
        public CustomList<SalaryRuleBackup> GetAllSalaryRuleBackup(string salaryRuleCode)
        {
            return SalaryRuleBackup.GetAllSalaryRuleBackup(salaryRuleCode);
        }
        public void SaveSalaryRule(ref CustomList<SalaryRuleBackup> SalaryRuleBackupList, ref CustomList<SalaryRule> DeletedSalaryRuleList, ref CustomList<SalaryRule> SalaryRuleList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(SalaryRuleBackupList, DeletedSalaryRuleList, SalaryRuleList);
                GetNewSalaryRuleCode(ref conManager, ref SalaryRuleBackupList, ref SalaryRuleList);
                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, SalaryRuleBackupList, DeletedSalaryRuleList, SalaryRuleList);

                SalaryRuleBackupList.AcceptChanges();
                SalaryRuleList.AcceptChanges();
                DeletedSalaryRuleList.AcceptChanges();
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
        private void ReSetSPName(CustomList<SalaryRuleBackup> SalaryRuleBackupList, CustomList<SalaryRule> DeletedSalaryRuleList, CustomList<SalaryRule> SalaryRuleList)
        {
            #region Salary Rule Backup
            SalaryRuleBackupList.InsertSpName = "spInsertSalaryRuleBackup";
            SalaryRuleBackupList.UpdateSpName = "spUpdateSalaryRuleBackup";
            #endregion
            #region Salary Rule
            SalaryRuleList.InsertSpName = "spInsertSalaryRule";
            DeletedSalaryRuleList.DeleteSpName = "spDeleteSalaryRule";
            #endregion
        }
        private void GetNewSalaryRuleCode(ref ConnectionManager conManager, ref CustomList<SalaryRuleBackup> SalaryRuleBackupList, ref CustomList<SalaryRule> SalaryRuleList)
        {
            String newSalaryRuleCode = String.Empty;
            try
            {
                CustomList<SalaryRuleBackup> addedSalaryRuleList = SalaryRuleBackupList.FindAll(f => f.IsAdded);
                if (addedSalaryRuleList.Count != 0)
                {
                    newSalaryRuleCode = StaticInfo.MakeUniqueCode("SalaryRuleCode", 20, DateTime.Today.ToString(), "yy", "SRC", "-", "");
                    SalaryRuleBackupList.ForEach(f => f.SalaryRuleCode = newSalaryRuleCode);
                    SalaryRuleList.ForEach(f=>f.SalaryRuleCode=newSalaryRuleCode);
                    salaryRuleCode = newSalaryRuleCode;
                }
                else
                {
                    salaryRuleCode = SalaryRuleBackupList[0].SalaryRuleCode;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeletelstSalaryRuleBackup(ref CustomList<SalaryRuleBackup> SalaryRuleBackupList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                //ReSetSPName(SalaryRuleBackupList);
                SalaryRuleBackupList.DeleteSpName = "spDeleteSalaryRuleBackup";
                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, SalaryRuleBackupList);
                SalaryRuleBackupList.AcceptChanges();
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
