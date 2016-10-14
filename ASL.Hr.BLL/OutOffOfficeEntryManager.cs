using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class OutOffOfficeEntryManager
    {
        public CustomList<HouseKeepingValue> GetAllProject()
        {
            return HouseKeepingValue.GetAllSingleEntity("spGetAllProject");
        }
        public CustomList<OutOfOfficeInfo> GetAllOutOutOfOfficeEntry(string date)
        {
            return OutOfOfficeInfo.GetAllOutOutOfOfficeEntry(date);
        }
        public CustomList<OutOfOfficeInfo> GetExistingEntry(string fromDate, string toDate, string empKey)
        {
            return OutOfOfficeInfo.GetExistingEntry(fromDate, toDate, empKey);
        }
        public void SaveOutOfOfficeEntry(ref CustomList<OutOfOfficeInfo> lstOutOfOfficeInfo)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                lstOutOfOfficeInfo.InsertSpName = "spInsertOutOfOfficeInfo";
                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstOutOfOfficeInfo);
                lstOutOfOfficeInfo.AcceptChanges();

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
        public void DeleteWHCalendar(ref CustomList<OutOfOfficeInfo> OutOfOfficeInfoList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                // ReSetSPName(WHCalEmpList);
                OutOfOfficeInfoList.DeleteSpName = "spDeleteOutOfOfficeInfo";
                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, OutOfOfficeInfoList);
                OutOfOfficeInfoList.AcceptChanges();
                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
            }
            catch (Exception ex)
            {
                conManager.RollBack();
                throw (ex);
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
