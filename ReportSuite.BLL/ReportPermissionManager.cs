using System;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ReportSuite.DAO;
using ASL.STATIC;


namespace ReportSuite.BLL
{
   public class ReportPermissionManager
    {
       public CustomList<ReportPermission> GetAllReportPermissionByUsercode(string userCode)
        {
            return ReportPermission.GetAllReportPermissionByUsercode(userCode);
        }
       public CustomList<ReportPermission> GetAllReportPermission(string userCode)
       {
           return ReportPermission.GetAllReportPermission(userCode);
       }
       public void SaveReportPermission(ref CustomList<ReportPermission> rPList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPName(rPList);


               blnTranStarted = true;

               conManager.SaveDataCollectionThroughCollection(blnTranStarted, rPList);

               rPList.AcceptChanges();


               conManager.CommitTransaction();
               blnTranStarted = false;
               conManager.Dispose();
           }
           catch (Exception Ex)
           {
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
       private void ReSetSPName(CustomList<ReportPermission> rPList)
       {
           #region Report Permission
           rPList.InsertSpName = "spInsertReportPermission";
           rPList.UpdateSpName = "spUpdateReportPermission";
           rPList.DeleteSpName = "spDeleteReportPermission";
           #endregion
       }
    }
}
