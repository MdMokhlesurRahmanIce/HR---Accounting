using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASL.DATA;
using ASL.Hr.DAO;
using ASL.DAL;
using ASL.STATIC;
using System.Collections;


namespace ASL.Hr.BLL
{
    public class SalaryHead_Manager
    {
        public CustomList<HouseKeepingValue> GetAllHeadType()
        {
            return HouseKeepingValue.GetAllSingleEntity("spGetHeadType");
        }
        public void SaveSalaryHead(ref CustomList<SalaryHead> SalaryHeadList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(SalaryHeadList);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, SalaryHeadList);
                SalaryHeadList.AcceptChanges();
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

        private void ReSetSPName(CustomList<SalaryHead> SalaryHeadCollection)
        {
            SalaryHeadCollection.InsertSpName = "spInsertSalaryHead";
            SalaryHeadCollection.UpdateSpName = "spUpdateSalaryHead";
            SalaryHeadCollection.DeleteSpName = "spDeleteSalaryHead";
        }



        public CustomList<SalaryHead> GetSalSubHead()
        {
            return SalaryHead.GetAllSalaryHead();
        }
    }
}
