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
   public class CompanyPoliciesFileManager
    {
       public CustomList<HRM_PolicyFileAttach> GetAllHRM_PolicyFileAttach()
       {
           return HRM_PolicyFileAttach.GetAllHRM_PolicyFileAttach();
       }
       public void SaveCompanyPolicies(ref CustomList<HRM_PolicyFileAttach> CompanyPoliciesList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(CompanyPoliciesList);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, CompanyPoliciesList);

                conManager.CommitTransaction();
                CompanyPoliciesList.AcceptChanges();
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
       private void ReSetSPName(CustomList<HRM_PolicyFileAttach> CompanyPoliciesList)
        {
            #region Company Policies
            CompanyPoliciesList.InsertSpName = "spInsertHRM_PolicyFileAttach";
            CompanyPoliciesList.UpdateSpName = "spUpdateHRM_PolicyFileAttach";
            CompanyPoliciesList.DeleteSpName = "spDeleteHRM_PolicyFileAttach";
            #endregion
        }
    }
}
