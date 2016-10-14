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
    public class EvalItemManager
    {
        public CustomList<HRM_EvalItem> GetAllHRM_EvalItem()
        {
            return HRM_EvalItem.GetAllHRM_EvalItem();
        }
        //public CustomList<Gen_LookupEnt> GetAllEvalutionCritaria()
        //{
        //    //return Gen_Grade.GetAllGen_Grade();
        //    return Gen_LookupEnt.GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup.CVEvalutionCritaria);
        //}

        public void SaveFiscalYear(ref CustomList<HRM_EvalItem> Gen_FYList)
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
        private void ReSetSPName(CustomList<HRM_EvalItem> HRM_EvalItemCollection)
        {
            #region Look Up Entity
            HRM_EvalItemCollection.InsertSpName = "spInsertHRM_EvalItem";
            HRM_EvalItemCollection.UpdateSpName = "spUpdateHRM_EvalItem";
            HRM_EvalItemCollection.DeleteSpName = "spDeleteHRM_EvalItem";
            #endregion
        }
    }
}
