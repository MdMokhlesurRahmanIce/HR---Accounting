using System;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using ASL.Hr.DAO;

namespace ASL.Hr.BLL
{
   public class ReportManager
    {
       //public CustomList<PF_Company> GetCompany()
       //{
       //    return PF_Company.GetAllPF_Company();
       //}
       public DataSet GetTransactionDataSources(String orgKey, String fromDate, String toDate,Boolean isPost)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;
           String spName = String.Empty;
           //String spInstrument = String.Empty;
           try
           {

               DataSet dsLoad = new DataSet();
               DataSet dsReturn = new DataSet();

               conManager.BeginTransaction();
               blnTranStarted = true;
               int approved = 0;
               if (isPost == false)
                   approved = 0;
               else
                   approved = 1;
               spName = String.Format("Exec Acc_Rpt_PeriodicTrans  @OrgKey = '{0}',@DateFrom = '{1}',@DateTo = '{2}',@IsPost={3}", orgKey, fromDate, toDate, approved);
               conManager.OpenDataSetThroughAdapter(spName, ref dsLoad, true);
               dsLoad.Tables[0].TableName = "Acc_Rpt_PeriodicTrans";
               dsReturn.Tables.Add(dsLoad.Tables[0].Copy());

               //spName = String.Format("Exec spRDLCPFInvestmentVoucher  @VoucherID = '{0}'", investmentID);
               //conManager.OpenDataSetThroughAdapter(spName, ref dsLoad, true);
               //dsLoad.Tables[0].TableName = "spRDLCPFInvestmentVoucher";
               //dsReturn.Tables.Add(dsLoad.Tables[0].Copy());

               conManager.CommitTransaction();
               blnTranStarted = false;
               //
               return dsReturn;
           }
           catch (Exception ex)
           {
               if (blnTranStarted)
               {
                   conManager.RollBack();
               }
               throw (ex);
           }
       }
       public DataSet GetTrialBalanceDataSources(String orgKey, String fromDate, String toDate)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;
           String spName = String.Empty;
           try
           {

               DataSet dsLoad = new DataSet();
               DataSet dsReturn = new DataSet();

               conManager.BeginTransaction();
               blnTranStarted = true;

               spName = String.Format("Exec Acc_Rpt_TB  @OrgKey = '{0}',@DateFrom = '{1}',@DateTo = '{2}'", orgKey, fromDate, toDate);
               conManager.OpenDataSetThroughAdapter(spName, ref dsLoad, true);
               dsLoad.Tables[0].TableName = "Acc_Rpt_TB";
               dsReturn.Tables.Add(dsLoad.Tables[0].Copy());

               conManager.CommitTransaction();
               blnTranStarted = false;
               return dsReturn;
           }
           catch (Exception ex)
           {
               if (blnTranStarted)
               {
                   conManager.RollBack();
               }
               throw (ex);
           }
       }
       public DataSet GetBalanceSheetDataSources(String orgKey, String fromDate, String toDate,String fY)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;
           String spName = String.Empty;
           try
           {

               DataSet dsLoad = new DataSet();
               DataSet dsReturn = new DataSet();

               conManager.BeginTransaction();
               blnTranStarted = true;

               spName = String.Format("Exec Acc_Rpt_BS  @OrgKey = '{0}',@DateFrom = '{1}',@DateTo = '{2}',@FYKey={3}", orgKey, fromDate, toDate, fY);
               conManager.OpenDataSetThroughAdapter(spName, ref dsLoad, true);
               dsLoad.Tables[0].TableName = "Acc_Rpt_BS";
               dsReturn.Tables.Add(dsLoad.Tables[0].Copy());

               conManager.CommitTransaction();
               blnTranStarted = false;
               return dsReturn;
           }
           catch (Exception ex)
           {
               if (blnTranStarted)
               {
                   conManager.RollBack();
               }
               throw (ex);
           }
       }
       public DataSet GetLedgerDataSources(String orgKey, String fromDate, String toDate, String COAKey)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;
           String spName = String.Empty;
           try
           {

               DataSet dsLoad = new DataSet();
               DataSet dsReturn = new DataSet();

               conManager.BeginTransaction();
               blnTranStarted = true;

               spName = String.Format("Exec Acc_Rpt_Ledger  @OrgKey = '{0}',@DateFrom = '{1}',@DateTo = '{2}',@COAKey={3}", orgKey, fromDate, toDate, COAKey);
               conManager.OpenDataSetThroughAdapter(spName, ref dsLoad, true);
               dsLoad.Tables[0].TableName = "Acc_Rpt_Ledger";
               dsReturn.Tables.Add(dsLoad.Tables[0].Copy());

               spName = String.Format("Exec Acc_Rpt_Ledger;2  @OrgKey = '{0}',@DateFrom = '{1}',@DateTo = '{2}',@COAKey={3}", orgKey, fromDate, toDate, COAKey);
               conManager.OpenDataSetThroughAdapter(spName, ref dsLoad, true);
               dsLoad.Tables[0].TableName = "Acc_Rpt_Ledger;2";
               dsReturn.Tables.Add(dsLoad.Tables[0].Copy());

               spName = String.Format("Exec Acc_Rpt_Ledger;3  @OrgKey = '{0}',@DateFrom = '{1}',@DateTo = '{2}',@COAKey={3}", orgKey, fromDate, toDate, COAKey);
               conManager.OpenDataSetThroughAdapter(spName, ref dsLoad, true);
               dsLoad.Tables[0].TableName = "Acc_Rpt_Ledger;3";
               dsReturn.Tables.Add(dsLoad.Tables[0].Copy());

               spName = String.Format("Exec Acc_Rpt_Ledger;4  @OrgKey = '{0}',@DateFrom = '{1}',@DateTo = '{2}',@COAKey={3}", orgKey, fromDate, toDate, COAKey);
               conManager.OpenDataSetThroughAdapter(spName, ref dsLoad, true);
               dsLoad.Tables[0].TableName = "Acc_Rpt_Ledger;4";
               dsReturn.Tables.Add(dsLoad.Tables[0].Copy());

               conManager.CommitTransaction();
               blnTranStarted = false;
               return dsReturn;
           }
           catch (Exception ex)
           {
               if (blnTranStarted)
               {
                   conManager.RollBack();
               }
               throw (ex);
           }
       }
       public DataSet GetIncomeStatementDataSources(String orgKey, String fromDate, String toDate, String fY)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;
           String spName = String.Empty;
           try
           {

               DataSet dsLoad = new DataSet();
               DataSet dsReturn = new DataSet();

               conManager.BeginTransaction();
               blnTranStarted = true;

               spName = String.Format("Exec Acc_Rpt_PL  @OrgKey = '{0}',@DateFrom = '{1}',@DateTo = '{2}',@FYKey={3}", orgKey, fromDate, toDate, fY);
               conManager.OpenDataSetThroughAdapter(spName, ref dsLoad, true);
               dsLoad.Tables[0].TableName = "Acc_Rpt_PL";
               dsReturn.Tables.Add(dsLoad.Tables[0].Copy());

               conManager.CommitTransaction();
               blnTranStarted = false;
               return dsReturn;
           }
           catch (Exception ex)
           {
               if (blnTranStarted)
               {
                   conManager.RollBack();
               }
               throw (ex);
           }
       }
       public DataSet GetVoucherDataSources(String voucherNo)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;
           String spName = String.Empty;
           try
           {

               DataSet dsLoad = new DataSet();
               DataSet dsReturn = new DataSet();

               conManager.BeginTransaction();
               blnTranStarted = true;

               spName = String.Format("Exec spPreviewVoucher  @VoucherNo = '{0}'", voucherNo);
               conManager.OpenDataSetThroughAdapter(spName, ref dsLoad, true);
               dsLoad.Tables[0].TableName = "spPreviewVoucher";
               dsReturn.Tables.Add(dsLoad.Tables[0].Copy());

               conManager.CommitTransaction();
               blnTranStarted = false;
               return dsReturn;
           }
           catch (Exception ex)
           {
               if (blnTranStarted)
               {
                   conManager.RollBack();
               }
               throw (ex);
           }
       }
       public DataSet GetCompany(String orgKey)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;
           String spName = String.Empty;
           try
           {

               DataSet dsLoad = new DataSet();
               DataSet dsReturn = new DataSet();

               conManager.BeginTransaction();
               blnTranStarted = true;

               spName = String.Format("Exec spGetCompany @OrgKey = '{0}'", orgKey);
               conManager.OpenDataSetThroughAdapter(spName, ref dsLoad, true);
               dsLoad.Tables[0].TableName = "spGetCompany";
               dsReturn.Tables.Add(dsLoad.Tables[0].Copy());

               conManager.CommitTransaction();
               blnTranStarted = false;
               return dsReturn;
           }
           catch (Exception ex)
           {
               if (blnTranStarted)
               {
                   conManager.RollBack();
               }
               throw (ex);
           }
       }
    
     //public DataSet GetDempEmpDataSources(String empCode)
     //  {
     //      ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
     //      Boolean blnTranStarted = false;
     //      String spName = String.Empty;
     //      try
     //      {

     //          DataSet dsLoad = new DataSet();
     //          DataSet dsReturn = new DataSet();

     //          conManager.BeginTransaction();
     //          blnTranStarted = true;

     //          spName = String.Format("Exec spPreviewVoucher  @empCode = {0}", empCode);
     //          conManager.OpenDataSetThroughAdapter(spName, ref dsLoad, true);
     //          dsLoad.Tables[0].TableName = "spPreviewVoucher";
     //          dsReturn.Tables.Add(dsLoad.Tables[0].Copy());

     //          conManager.CommitTransaction();
     //          blnTranStarted = false;
     //          return dsReturn;
     //      }
     //      catch (Exception ex)
     //      {
     //          if (blnTranStarted)
     //          {
     //              conManager.RollBack();
     //          }
     //          throw (ex);
     //      }
     }
}
