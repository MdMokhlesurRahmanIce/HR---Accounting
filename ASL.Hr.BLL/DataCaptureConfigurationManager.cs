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
   public class DataCaptureConfigurationManager
    {
       public CustomList<DataCaptureConfiguration> GetAllDataCaptureConfiguration1()
       {
           return DataCaptureConfiguration.GetAllDataCaptureConfiguration1();
       }
       public void SaveDataCaptureConfiguration(ref CustomList<DataCaptureConfiguration> DeleteDataCaptureConfigurationList, ref CustomList<DataCaptureConfiguration> SaveDataCaptureConfigurationList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPName(ref DeleteDataCaptureConfigurationList,ref SaveDataCaptureConfigurationList);

               blnTranStarted = true;

               conManager.SaveDataCollectionThroughCollection(blnTranStarted, DeleteDataCaptureConfigurationList,SaveDataCaptureConfigurationList);

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
       private void ReSetSPName(ref CustomList<DataCaptureConfiguration> DeleteDataCaptureConfigurationList,ref CustomList<DataCaptureConfiguration> SaveDataCaptureConfigurationList)
       {
           #region Data Capture Configuration
           SaveDataCaptureConfigurationList.InsertSpName = "spInsertDataCaptureConfiguration";
           SaveDataCaptureConfigurationList.UpdateSpName = "spUpdateDataCaptureConfiguration";
           SaveDataCaptureConfigurationList.DeleteSpName = "spDeleteDataCaptureConfiguration";
           #endregion
           #region Data Capture Configuration
           DeleteDataCaptureConfigurationList.InsertSpName = "spInsertDataCaptureConfiguration";
           DeleteDataCaptureConfigurationList.UpdateSpName = "spUpdateDataCaptureConfiguration";
           DeleteDataCaptureConfigurationList.DeleteSpName = "spDeleteDataCaptureConfiguration";
           #endregion
       }
    }
}
