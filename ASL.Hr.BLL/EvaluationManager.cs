using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class EvaluationManager
    {
        #region Work flow method
        //public CustomList<Gen_Desig> GetAllGen_Desig()
        //{
        //    return Gen_Desig.GetAllGen_Desig();
        //}
        public CustomList<HRM_EvalItem> GetAllHRM_EvalItem(int pagetype) //1 = management; 2 = non management
        {
            return HRM_EvalItem.GetAllHRM_EvalItem(pagetype);
        }
        #endregion

        #region EvalItem
        public CustomList<HRM_EvalDet> GetHRM_EvalDet(String EvalKey, int pagetype)
        {
            return HRM_EvalDet.GetHRM_EvalDet(EvalKey, pagetype);
        }
        #endregion

        #region HRM_Eval
        public CustomList<HRM_Eval> GetAllHRM_Eval(String EvalKey)
        {
            return HRM_Eval.GetAllHRM_Eval(EvalKey);
        }
        public CustomList<HRM_Eval> doSearch(String whereClause)
        {
            return HRM_Eval.doSearch(whereClause);
        }
        #endregion

        //public String  GetPreviousTranning(String EmpKey)
        //{
        //    ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
        //    CustomList<HRM_LeaveApp> HRM_LeaveAppCollection = new CustomList<HRM_LeaveApp>();

        //    String  ReturnValue = String.Empty;
        //    String sql = " SELECT    top 1 dbo.TRG_Training.TrgName "+
        //                 " FROM         dbo.TRG_Training INNER JOIN dbo.TRG_TrainingDet ON dbo.TRG_Training.TrgKey = dbo.TRG_TrainingDet.TrgKey INNER JOIN " +
        //                 " dbo.Gen_FY ON dbo.TRG_Training.FYKey = dbo.Gen_FY.FYKey Where dbo.TRG_TrainingDet.EmpKey=" + EmpKey + " AND dbo.Gen_FY.EDate<='" + DateTime.Now.ToString() + "' AND dbo.Gen_FY.SDate<='" + DateTime.Now.ToString() + "' Order By dbo.Gen_FY.FYKey";
        //    try
        //    {
        //        object LeaveAllocation = conManager.ExecuteScalarWrapper(sql);
        //        if (LeaveAllocation.IsNotNull())
        //            ReturnValue = Convert.ToString(LeaveAllocation);
        //        //   ReturnValue = conManager.ExecuteNonQueryWrapper(sql);
        //        return ReturnValue;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {

        //    }
        //}

        #region Save
        private void ReSetSPName(CustomList<HRM_EvalDet> HRM_EvalDettList)
        {
            HRM_EvalDettList.InsertSpName = "spInsertHRM_EvalDet";
            HRM_EvalDettList.UpdateSpName = "spUpdateHRM_EvalDet";
            HRM_EvalDettList.DeleteSpName = "spDeleteHRM_EvalDet";
        }
        private void ReSetSPName(CustomList<HRM_Eval> EmpHistList)
        {
            EmpHistList.InsertSpName = "spInsertHRM_Eval";
            EmpHistList.UpdateSpName = "spUpdateHRM_Eval";
            EmpHistList.DeleteSpName = "spDeleteHRM_Eval";
        }

        public void SaveEvalution(ref CustomList<HRM_Eval> EmpHistList, ref CustomList<HRM_EvalDet> HRM_EvalDettList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();
                blnTranStarted = true;

                long EvalKey = EmpHistList[0].EvalKey;
                ReSetSPName(EmpHistList);
                if (EmpHistList[0].IsAdded)
                    EvalKey = Convert.ToInt32(conManager.InsertData(blnTranStarted, EmpHistList));
                else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, EmpHistList);

                EmpHistList.AcceptChanges();


                var addr = HRM_EvalDettList;
                addr.ForEach(x => x.EvalKey = EvalKey);
                ReSetSPName(addr);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, addr);
                addr.AcceptChanges();


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
        #endregion



    }
}
