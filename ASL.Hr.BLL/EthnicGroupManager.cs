using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class EthnicGroupManager
    {
        public CustomList<Gen_Ethnic> GetAllGen_Ethnic()
        {
            return Gen_Ethnic.GetAllGen_Ethnic();
        }
        public CustomList<Gen_LookupEnt> GetAllGen_LookupEnt()
        {
            return Gen_LookupEnt.GetAllGen_LookupEnt(2);
        }
        public void SaveEthnicGroup(ref CustomList<Gen_Ethnic> EthnicGroupList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(EthnicGroupList);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, EthnicGroupList);

                EthnicGroupList.AcceptChanges();

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
        private void ReSetSPName(CustomList<Gen_Ethnic> EthnicGroupList)
        {
            try
            {
                #region Ethnic Group
                EthnicGroupList.InsertSpName = "spInsertGen_Ethnic";
                EthnicGroupList.UpdateSpName = "spUpdateGen_Ethnic";
                EthnicGroupList.DeleteSpName = "spDeleteGen_Ethnic";
                #endregion
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
