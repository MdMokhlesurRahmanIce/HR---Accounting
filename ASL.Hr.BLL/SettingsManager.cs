using System;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using ASL.Hr.DAO;

namespace ASL.Hr.BLL
{
  
    public class SettingsManager
    {
        public CustomList<Settings> GetAllSettingsList()
        {
            return Settings.GetAllSettingsList();
        }
        public CustomList<Settings> GetFromDateToDate(string YearNo, string MonthNo)
        {
            return Settings.GetFromDateToDate(YearNo, MonthNo);
        }
        public CustomList<Settings> GetAllSettingsInfo()
        {
            return Settings.GetAllSettingsInfo();
        }
        public CustomList<Settings> GetAllSalaryYear()
        {
            return Settings.GetAllSalaryYear();
        }
        public CustomList<Settings> GetAllSalaryMonths( string Year)
        {
            return Settings.GetAllSalaryMonths(Year);
        }
        public CustomList<Settings> GetSelectedSettingsInfo(string SettingsName)
        {
            return Settings.GetSelectedSettingsInfo(SettingsName);
        }

        #region Save
        public void SaveSettings(ref CustomList<Settings> SettingsList)
        {
            var conManager = new ConnectionManager(ConnectionName.HR);
            bool blnTranStarted = false;
            try
            {
                blnTranStarted = true;
                conManager.BeginTransaction();

                ReSetSPName(ref SettingsList);

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, SettingsList);

                blnTranStarted = false;
                conManager.CommitTransaction();

                SettingsList.AcceptChanges();

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
        public void ReSetSPName(ref CustomList<Settings> SettingsList)
        {
            try
            {
                #region Settings
                SettingsList.InsertSpName = "spInsertSettings";
                SettingsList.UpdateSpName = "spUpdateSettings";
                SettingsList.DeleteSpName = "spDeleteSettings";
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
                ReSetSPName(ref SettingsList);
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

    }
}
