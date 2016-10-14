using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
   public class MiscAllowDedManager
    {
       public void SaveUploadSalary(ref CustomList<UploadSalary> UploadSalaryList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(UploadSalaryList);
                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, UploadSalaryList);

                UploadSalaryList.AcceptChanges();
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
       private void ReSetSPName(CustomList<UploadSalary> UploadSalaryList)
        {
            #region Upload Salary
            UploadSalaryList.InsertSpName = "spInsertUploadSalary";
            UploadSalaryList.UpdateSpName = "spUpdateUploadSalary";
            #endregion
        }
    }
}
