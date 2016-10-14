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
    public class TempEmpManager
    {
        //public CustomList<HR.DAO.Settings> GetAllSettingsList()
        //{
        //    return HR.DAO.Settings.GetAllSettingsList();
        //}
        //public CustomList<HR.DAO.Settings> GetAllSettingsInfo()
        //{
        //    return HR.DAO.Settings.GetAllSettingsInfo();
        //}

        #region Save
        public void SaveSettings(ref CustomList<TempEmpCode> TempEmpList)
        {
            var conManager = new ConnectionManager(ConnectionName.HR);
            bool blnTranStarted = false;
            try
            {
                blnTranStarted = true;
                conManager.BeginTransaction();

                ReSetSPName(ref TempEmpList);

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, TempEmpList);

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
        public void ReSetSPName(ref CustomList<TempEmpCode> TempEmpList)
        {
            try
            {
                #region TempEmpList
                TempEmpList.InsertSpName = "spInsertEmpForManualAttendance";
                TempEmpList.UpdateSpName = "spUpdateSettings";
                TempEmpList.DeleteSpName = "spDeleteSettings";
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