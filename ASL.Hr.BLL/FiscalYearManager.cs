using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class FiscalYearManager
    {
        public CustomList<Gen_FY> GetAllGen_FY()
        {
            return Gen_FY.GetAllGen_FY();
        }
        public CustomList<HouseKeepingValue> GetAllCompany()
        {
            return HouseKeepingValue.GetCompany();
        }

        public void SaveFiscalYear(ref CustomList<Gen_FY> Gen_FYList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(Gen_FYList);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, Gen_FYList);
                //object scope_Identity = conManager.InsertData(blnTranStarted, BankKist);

                Gen_FYList.AcceptChanges();

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
        private void ReSetSPName(CustomList<Gen_FY> Gen_FYCollection)
        {
            #region Leave Year
            Gen_FYCollection.InsertSpName = "spInsertGen_FY";
            Gen_FYCollection.UpdateSpName = "spUpdateGen_FY";
            Gen_FYCollection.DeleteSpName = "spDeleteGen_FY";
            #endregion
        }
    }
}
