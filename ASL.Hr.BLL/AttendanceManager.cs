using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class AttendanceManager
    {

        public CustomList<ATT_IO> GetAllAttForManualProcess(string date)
        {
            return ATT_IO.GetAllAttForManualProcess(date);
        }
        public void SaveAtt_IO(ref CustomList<ATT_IO> lstAtt_IO)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                lstAtt_IO.InsertSpName = "spInsertDeviceRowData";
                //lstAtt_IO.UpdateSpName = "spUpdateATT_IO";
                //lstAtt_IO.DeleteSpName = "spDeleteATT_IO";

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstAtt_IO);
                lstAtt_IO.AcceptChanges();

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

        public CustomList<Atten_Device> GetDeviceName()
        {
            //if (IsSelecttd())
            //{
            //    return Atten_Device.GetAllAtten_Device();
            //}
            //else
            return Atten_Device.GetAllAtten_Device();
        }

        public Int32 GetMasterSetup(String ItemType)
        {
            return Hr_MasterSetup.GetAllHr_MasterSetup(ItemType);
        }
    }
}
