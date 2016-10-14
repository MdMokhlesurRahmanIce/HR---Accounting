using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
   public class OTAssignmentManager
    {
       public CustomList<OTAssignment> GetAllOTAssignment(string fromDate, string toDate)
       {
           return OTAssignment.GetAllOTAssignment(fromDate, toDate);
       }
       public void SaveOTAssignment(CustomList<OTAssignment> OTAssignmentList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(OTAssignmentList);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, OTAssignmentList);

                OTAssignmentList.AcceptChanges();

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
       private void ReSetSPName(CustomList<OTAssignment> OTAssignmentList)
        {
            #region OT Assignment
            OTAssignmentList.InsertSpName = "spInsertOTAssignment";
            OTAssignmentList.UpdateSpName = "spUpdateOTAssignment";
            OTAssignmentList.DeleteSpName = "spDeleteOTAssignment";
            #endregion
        }
    }
}
