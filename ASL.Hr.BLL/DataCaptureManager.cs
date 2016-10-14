using System;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;


namespace ASL.Hr.BLL
{
   public class DataCaptureManager
    {
       public CustomList<DataCaptureConfiguration> GetAllDataCaptureConfigurationForDataCapture()
       {
           return DataCaptureConfiguration.GetAllDataCaptureConfigurationForDataCapture();
       }
       public CustomList<ProductionDataCapture> GetAllProductionDataCaptureEmp(string empCode)
       {
           return ProductionDataCapture.GetAllProductionDataCaptureEmp(empCode);
       }
       public CustomList<DataCaptureRate> GetAllDataCapRateRuleID()
       {
           return DataCaptureRate.GetAllDataCapRateRuleID();
       }
       public CustomList<ProductionDataCapture> GetAllProductionDataCapture(string date)
       {
           return ProductionDataCapture.GetAllProductionDataCapture(date);
       }
       public CustomList<HRM_Emp> GetAllHRM_Emp()
       {
           return HRM_Emp.GetAllHRM_Emp();
       }
       public void SaveProductionDataCapture(ref CustomList<ProductionDataCapture> ProductionDataCaptureList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPName(ref ProductionDataCaptureList);

               blnTranStarted = true;

               conManager.SaveDataCollectionThroughCollection(blnTranStarted, ProductionDataCaptureList);

               conManager.CommitTransaction();
               ProductionDataCaptureList.AcceptChanges();
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
       private void ReSetSPName(ref CustomList<ProductionDataCapture> ProductionDataCaptureList)
       {
           #region Production Data Capture
           ProductionDataCaptureList.InsertSpName = "spInsertProductionDataCapture";
           ProductionDataCaptureList.UpdateSpName = "spUpdateProductionDataCapture";
           ProductionDataCaptureList.DeleteSpName = "spDeleteProductionDataCapture";
           #endregion
       }
    }
}
