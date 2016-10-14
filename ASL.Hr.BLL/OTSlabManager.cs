using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class OTSlabManager
    {
        private System.String _OTSlabID;
        public System.String OTSlabID
        {
            get
            {
                return _OTSlabID;
            }
        }
        public CustomList<Gen_LookupEnt> GetAllGen_LookupEnt()
        {
            return Gen_LookupEnt.GetAllGen_LookupEnt(20);
        }
        public CustomList<OTSlab> GetAllOTSlab(string otSlabID)
        {
            return OTSlab.GetAllOTSlab(otSlabID);
        }
        public CustomList<OTSlab> GetAllOTSlab()
        {
            return OTSlab.GetAllOTSlab();
        }
        public CustomList<SalaryHead> GetAllSalaryHeadForSalaryRule()
        {
            return SalaryHead.GetAllSalaryHeadForSalaryRule();
        }
        public Int32 RowCount()
        {
            return OTSlab.RowCount();
        }

        public void SaveOTSlab(ref CustomList<OTSlab> OTSlabList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(OTSlabList);


                blnTranStarted = true;

                Int32 id = OTSlab.RowCount()+1;
                _OTSlabID = id.ToString();
                foreach (OTSlab oTS in OTSlabList)
                {
                    oTS.OTSlabID = id.ToString();
                }

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, OTSlabList);

                OTSlabList.AcceptChanges();

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
        private void ReSetSPName(CustomList<OTSlab> OTSlibList)
        {
            #region OT Slab
            OTSlibList.InsertSpName = "spInsertOTSlab";
            OTSlibList.UpdateSpName = "spUpdateOTSlab";
            OTSlibList.DeleteSpName = "spDeleteOTSlab";
            #endregion
        }
        public void DeleteOTSlab(ref CustomList<OTSlab> OTSlibList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                ReSetSPName(OTSlibList);

                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, OTSlibList);
                OTSlibList.AcceptChanges();
                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
            }
            catch (Exception ex)
            {
                conManager.RollBack();
                throw (ex);
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
