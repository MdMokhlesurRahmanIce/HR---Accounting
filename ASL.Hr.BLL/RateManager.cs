using System;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class RateManager
    {
        public CustomList<DataCaptureConfiguration> GetAllDataCaptureConfigurationForRate()
        {
            return DataCaptureConfiguration.GetAllDataCaptureConfigurationForRate();
        }
        public CustomList<HouseKeepingValue> GetAllHouseKeepingValueForDropdown(string entityName)
        {
            return HouseKeepingValue.GetAllHouseKeepingValueForDropdown(entityName);
        }
        public CustomList<HouseKeepingValue> GetAllHouseKeepingValueForDropdown(Int32 parentID)
        {
            return HouseKeepingValue.GetAllHouseKeepingValueForDropdown(parentID);
        }
        public CustomList<DataCaptureRate> GetAllRate()
        {
            return DataCaptureRate.GetAllRate();
        }
        public void SaveDataDataCapture(ref CustomList<DataCaptureRate> DataCaptureRateList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(ref DataCaptureRateList);
                blnTranStarted = true;
                //GetNewRateRuleID(ref conManager, blnTranStarted, ref DataCaptureRateList);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, DataCaptureRateList);

                DataCaptureRateList.AcceptChanges();
                conManager.CommitTransaction();
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
        private void ReSetSPName(ref CustomList<DataCaptureRate> DataCaptureRateList)
        {
            #region Data Capture Configuration
            DataCaptureRateList.InsertSpName = "spInsertDataCaptureRate";
            DataCaptureRateList.UpdateSpName = "spUpdateDataCaptureRate";
            DataCaptureRateList.DeleteSpName = "spDeleteDataCaptureRate";
            #endregion
        }
        //private void GetNewRateRuleID(ref ConnectionManager conManager, bool requiredTransaction, ref CustomList<DataCaptureRate> DataCaptureRateList)
        //{
        //    String newDataCaptureRateID = "";
        //    try
        //    {
        //        CustomList<DataCaptureRate> tempDataCaptureRateList = DataCaptureRateList.FindAll(f => f.IsAdded || f.IsModified);
        //        if (tempDataCaptureRateList.Count != 0)
        //        {
        //            newDataCaptureRateID = Convert.ToString(StaticInfo.GetUniqueCodeWithoutSignature(ref conManager, requiredTransaction, "DataCaptureRate", "DataCapRateRuleID", tempDataCaptureRateList[0].DataCapRateRuleID + "-"));
        //            tempDataCaptureRateList[0].DataCapRateRuleID +="-"+newDataCaptureRateID;
        //        }
        //        foreach (DataCaptureRate dCR in tempDataCaptureRateList)
        //        {
        //            dCR.DataCapRateRuleID = tempDataCaptureRateList[0].DataCapRateRuleID;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

       // }
    }

}
