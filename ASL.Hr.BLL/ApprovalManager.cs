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
   public class ApprovalManager
    {
       public CustomList<HRM_Emp> GetNewEmpApproval(string fromDate,string toDate)
       {
           return HRM_Emp.GetNewEmpApproval(fromDate, toDate);
       }
       public CustomList<HRM_Emp> GetEmpSeparationApproval(string fromDate, string toDate)
       {
           return HRM_Emp.GetEmpSeparationApproval(fromDate, toDate);
       }
       public CustomList<HRM_Emp> GetEmpSeparationReActivation(string fromDate, string toDate)
       {
           return HRM_Emp.GetEmpSeparationReActivation(fromDate, toDate);
       }
       public void SaveEmpApproval(ref CustomList<HRM_Emp> CheckedEmpList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               blnTranStarted = true;

               conManager.SaveDataCollectionThroughCollection(blnTranStarted, CheckedEmpList);

               CheckedEmpList.AcceptChanges();

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
       public void SaveEmpSeparationApproval(ref CustomList<SeparationGrid> SeparationEmpList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               blnTranStarted = true;

               conManager.SaveDataCollectionThroughCollection(blnTranStarted, SeparationEmpList);

               SeparationEmpList.AcceptChanges();

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
       public void SaveEmpReActive(ref CustomList<HRM_Emp> CheckedEmpList, ref CustomList<Reactive> ReactiveList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               blnTranStarted = true;

               conManager.SaveDataCollectionThroughCollection(blnTranStarted, CheckedEmpList, ReactiveList);

               CheckedEmpList.AcceptChanges();
               ReactiveList.AcceptChanges();

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
