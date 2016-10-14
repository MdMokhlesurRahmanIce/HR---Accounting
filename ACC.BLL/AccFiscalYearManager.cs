using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASL.DATA;
using ASL.DAL;
using ACC.DAO;
using ASL.STATIC;

namespace ACC.BLL
{
   public class AccFiscalYearManager
    {
       public CustomList<Gen_AccFY> GetAllGen_AccFY()
        {
            return Gen_AccFY.GetAllGen_AccFY();
        }

       public void SaveAccFiscalYear(ref CustomList<Gen_AccFY> Gen_AccFYList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(Gen_AccFYList);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, Gen_AccFYList);
                //object scope_Identity = conManager.InsertData(blnTranStarted, BankKist);

                Gen_AccFYList.AcceptChanges();

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
        private void ReSetSPName(CustomList<Gen_AccFY> Gen_AccFYCollection)
        {
            #region Acc Fiscal Year
            Gen_AccFYCollection.InsertSpName = "spInsertGen_accFY";
            Gen_AccFYCollection.UpdateSpName = "spUpdateGen_accFY";
            Gen_AccFYCollection.DeleteSpName = "spDeleteGen_accFY";
            #endregion
        }
    }
}
