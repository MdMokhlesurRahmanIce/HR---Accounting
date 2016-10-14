using System;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using ASL.Hr.DAO;

namespace ASL.Hr.BLL
{

    public class SalaryProcessManager
    {

        public CustomList<SalaryProcess> doSalaryProcess(string spName, string YearNo, string MonthNo, string FromDate, string Todate, string tableName)
        {
            return SalaryProcess.doSalaryProcess(spName, YearNo, MonthNo, FromDate, Todate, tableName);
        }
        
        public CustomList<SalaryProcess> deleteProcessedSalary(string tableName, string YearNo, string MonthNo)
        {
            return SalaryProcess.deleteProcessedSalary(tableName, YearNo, MonthNo);
        }
        public void DeleteTempEmpListSalary()
        {
            SalaryProcess.DeleteTempEmpListSalary();
        }

        #region Save
        public void SaveSalaryProcess(ref CustomList<SalaryProcess> SalaryProcessList)
        {
            var conManager = new ConnectionManager(ConnectionName.HR);
            bool blnTranStarted = false;
            try
            {
                blnTranStarted = true;
                conManager.BeginTransaction();

                ReSetSPName(ref SalaryProcessList);

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, SalaryProcessList);

                blnTranStarted = false;
                conManager.CommitTransaction();

                SalaryProcessList.AcceptChanges();

                conManager.Dispose();

            }
            catch (Exception ex)
            {
                if (blnTranStarted == true)
                {
                    conManager.RollBack();
                    conManager.Dispose();
                }
                throw (ex);
            }
        }
        #endregion
        #region Reset SP
        public void ReSetSPName(ref CustomList<SalaryProcess> SalaryProcess)
        {
            try
            {
                #region Settings
                SalaryProcess.InsertSpName = "spInsertSalaryProcess";
                SalaryProcess.UpdateSpName = "spUpdateSalaryProcess";
                SalaryProcess.DeleteSpName = "spDeleteSalaryProcess";
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        public void DeleteSettings(ref CustomList<Settings> SettingsList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
               // ReSetSPName(ref SettingsList);
                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, SettingsList);

                SettingsList.AcceptChanges();
                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
            }
            catch (Exception ex)
            {
                conManager.RollBack();
                throw (ex);
            }
        }

        public void DeleteTempEmpListSalary(ref CustomList<TempEmpListForSalary> TempEmpList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                // ReSetSPName(ref SettingsList);
                TempEmpList.DeleteSpName = "spDeleteTempEmpListForSalary";
                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, TempEmpList);

                TempEmpList.AcceptChanges();
                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
            }
            catch (Exception ex)
            {
                conManager.RollBack();
                throw (ex);
            }
        }
        #region SaveTempEmpList
        public void SaveTempEmpListSalary(ref CustomList<TempEmpListForSalary> TempEmpList)
        {
            var conManager = new ConnectionManager(ConnectionName.HR);
            bool blnTranStarted = false;
            try
            {
                blnTranStarted = true;
                conManager.BeginTransaction();

                ReSetSPName1(ref TempEmpList);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, TempEmpList);
                //conManager.SaveDataCollectionThroughCollection(blnTranStarted, TempEmpList);

                blnTranStarted = false;
                conManager.CommitTransaction();

                TempEmpList.AcceptChanges();

                conManager.Dispose();

            }
            catch (Exception ex)
            {
                if (blnTranStarted == true)
                {
                    conManager.RollBack();
                    conManager.Dispose();
                }
                throw (ex);
            }
        }
        #endregion

        #region Reset SP
        public void ReSetSPName1(ref CustomList<TempEmpListForSalary> SalaryProcess)
        {
            try
            {
                #region Settings
                SalaryProcess.InsertSpName = "spInsertTempEmpListForSalary";               
                SalaryProcess.DeleteSpName = "spDeleteTempEmpListForSalary";
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
