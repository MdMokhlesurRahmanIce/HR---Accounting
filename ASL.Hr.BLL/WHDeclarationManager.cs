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
    public class WHDeclarationManager
    {

        public CustomList<WHCalendar> GetAllEmpWHCalendar()
        {
            return WHCalendar.GetAllEmpWHCalendar();
        }
        public CustomList<WHCalendar> GetAllWHCalendar(string fromDate, string toDate, string dayType)
        {
            return WHCalendar.GetAllWHCalendar(fromDate, toDate, dayType);
        }
        public void SaveEmpWiseCal(ref CustomList<WHCalendar> DeletedList, ref CustomList<WHCalendar> WHCalendarList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(WHCalendarList);
                DeletedList.DeleteSpName = "spDeleteWHCalendar";

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, DeletedList, WHCalendarList);

                DeletedList.AcceptChanges();
                WHCalendarList.AcceptChanges();

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
        public void DeleteWHCalendar(ref CustomList<WHCalendar> WHCalEmpList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                ReSetSPName(WHCalEmpList);

                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, WHCalEmpList);
                WHCalEmpList.AcceptChanges();
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
        private void ReSetSPName(CustomList<WHCalendar> WHCalendarList)
        {
            #region WHCalendar
            WHCalendarList.InsertSpName = "spInsertWHCalendar";
            WHCalendarList.UpdateSpName = "spUpdateWHCalendar";
            WHCalendarList.DeleteSpName = "spDeleteWHCalendar";
            #endregion
        }
    }
}
