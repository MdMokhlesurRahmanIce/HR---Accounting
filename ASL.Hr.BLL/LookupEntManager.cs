using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
   public class LookupEntManager
    {
        public CustomList<Gen_LookupEnt> GetAllGen_LookupEnt()
        {
            return Gen_LookupEnt.GetAllGen_LookupEnt();
        }
        public void SaveLookupEnt(ref CustomList<Gen_LookupEnt> LookupEnt)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(LookupEnt);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, LookupEnt);

                LookupEnt.AcceptChanges();

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
        private void ReSetSPName(CustomList<Gen_LookupEnt> LookupEnt)
        {
            #region Look Up Entity
            LookupEnt.InsertSpName = "spInsertGen_LookupEnt";
            LookupEnt.UpdateSpName = "spUpdateGen_LookupEnt";
            LookupEnt.DeleteSpName = "spDeleteGen_LookupEnt";
            #endregion
        }
    }
}
