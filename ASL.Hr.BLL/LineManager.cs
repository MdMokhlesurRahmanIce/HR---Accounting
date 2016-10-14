using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;


namespace ASL.Hr.BLL
{
   public class LineManager
    {
       public CustomList<Organization> GetAllCompany()
       {
           return Organization.GetAllOrganization(2);
       }
       public CustomList<LineInfo> GetAllLineInfo()
       {
           return LineInfo.GetAllLineInfo();
       }
       public void SaveLineInfo(ref CustomList<LineInfo> LineInfoManager)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPName(LineInfoManager);

               blnTranStarted = true;

               conManager.SaveDataCollectionThroughCollection(blnTranStarted, LineInfoManager);

               LineInfoManager.AcceptChanges();

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
       private void ReSetSPName(CustomList<LineInfo> LineInfoManager)
       {
           #region Look Up Entity
           LineInfoManager.InsertSpName = "spInsertLineInfo";
           LineInfoManager.UpdateSpName = "spUpdateLineInfo";
           LineInfoManager.DeleteSpName = "spDeleteLineInfo";
           #endregion
       }
    }
}
