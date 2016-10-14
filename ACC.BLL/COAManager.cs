using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ACC.DAO;
using ASL.STATIC;

namespace ACC.BLL
{
    public class COAManager
    {
        public void Save(ref CustomList<Acc_COA> list)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                list.InsertSpName = "spInsertAcc_COA";
                list.UpdateSpName = "spUpdateAcc_COA";
                list.DeleteSpName = "spDeleteAcc_COA";

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, list);

                conManager.CommitTransaction();
                list.AcceptChanges();

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
    }
}
