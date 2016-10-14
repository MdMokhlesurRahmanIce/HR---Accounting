using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ASL.DATA;
using ASL.Hr.DAO;
using ASL.DAL;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class DemoEmpManager
    {
        public CustomList<DemoEmpMaster> GetAllempMaster()
        {
            return DemoEmpMaster.GetAllempMaster();
        }
       

        public void SaveEmp(ref CustomList<DemoEmpMaster> emp)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {

                blnTranStarted = true;
                conManager.BeginTransaction();
                ReSetSPName(ref emp);

                //object scope_Identity = conManager.InsertData(blnTranStarted, emp);
                //Int32 empCode = Convert.ToInt32(scope_Identity);


                // CustomList<DemoEmpMaster> objempDetails = new CustomList<DemoEmpMaster>();                 


                ReSetSPName(ref emp);

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, emp);

                blnTranStarted = true;
                conManager.CommitTransaction();
                emp.AcceptChanges();

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
                    blnTranStarted = false;
                    conManager.Dispose();
                }
            }


        }

        public void DeleteEmp(CustomList<DemoEmpMaster> EmpDetails)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                //ReSetSPName(ref EmpDetails);
                EmpDetails.DeleteSpName = "spDeleteDemoemp";
                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, EmpDetails);
                EmpDetails.AcceptChanges();
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
        private void ReSetSPName(ref CustomList<DemoEmpMaster> EmpDetails)
        {

            #region employee Details
            EmpDetails.InsertSpName = "spInsertDemoemp";
            EmpDetails.UpdateSpName = "spUpdateDemoemp";
            EmpDetails.DeleteSpName = "spDeleteDemoemp";
            #endregion

        }




        
        public CustomList<DemoEmpMaster> GetSelectedemp(int p)
        {
            //throw new NotImplementedException();
            return DemoEmpMaster.GetSelectedemp(p);
        }
    }
}
