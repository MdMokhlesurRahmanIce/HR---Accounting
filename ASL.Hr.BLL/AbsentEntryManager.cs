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
  public class AbsentEntryManager
    {
      public void SaveAbsentList(ref CustomList<AbsentEntry> AbsentEntryList)
      {
          ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
          Boolean blnTranStarted = false;

          try
          {
              conManager.BeginTransaction();

              blnTranStarted = true;
              AbsentEntryList.InsertSpName = "spInsertAbsentEntry";
              AbsentEntryList.DeleteSpName = "spDeleteAbsentEntry";
              conManager.SaveDataCollectionThroughCollection(blnTranStarted, AbsentEntryList);

              AbsentEntryList.AcceptChanges();

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
    }
}
