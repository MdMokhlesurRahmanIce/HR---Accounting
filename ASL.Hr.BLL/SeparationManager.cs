using System;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using ASL.Hr.DAO;

namespace ASL.Hr.BLL
{
    public class SeparationManager
    {
        public CustomList<SeparationGrid> GetAllUnapprovedSeparation()
        {
            return SeparationGrid.GetAllUnapprovedSeparation();
        }

        #region Save
        public void SaveSeparation(ref CustomList<SeparationGrid> SeparationList)
        {
            var conManager = new ConnectionManager(ConnectionName.HR);
            bool blnTranStarted = false;
            try
            {
                blnTranStarted = true;
                conManager.BeginTransaction();

                ReSetSPName(ref SeparationList);

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, SeparationList);

                blnTranStarted = false;
                conManager.CommitTransaction();

                SeparationList.AcceptChanges();

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
        public void ReSetSPName(ref CustomList<SeparationGrid> SeparationList)
        {
            try
            {
                #region Settings
                SeparationList.InsertSpName = "spInsertSeparation";
                SeparationList.UpdateSpName = "spUpdateSeparation";
                SeparationList.DeleteSpName = "spDeleteSeparation";
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
