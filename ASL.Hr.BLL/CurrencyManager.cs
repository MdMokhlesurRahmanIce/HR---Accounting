using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class CurrencyManager
    {
        public CustomList<Gen_Currency> GetAllGen_Currency()
        {
            return Gen_Currency.GetAllGen_Currency();
        }
        public void SaveCurrency(ref CustomList<Gen_Currency> CurrencyList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(CurrencyList);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, CurrencyList);
                //object scope_Identity = conManager.InsertData(blnTranStarted, BankKist);

                //BankKist.AcceptChanges();
                
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
        private void ReSetSPName(CustomList<Gen_Currency> BaknkList)
        {
            #region Look Up Entity
            BaknkList.InsertSpName = "spInsertGen_Currency";
            BaknkList.UpdateSpName = "spUpdateGen_Currency";
            BaknkList.DeleteSpName = "spDeleteGen_Currency";
            #endregion
        }
    }
}
