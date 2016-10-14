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
   public class LatestNewsManager
    {
       public CustomList<LatestNews> GetAllLatestNews()
       {
           return LatestNews.GetAllLatestNews();
       }
       public CustomList<LatestNews> GetAllLatestNewsForDisplay()
       {
           return LatestNews.GetAllLatestNewsForDisplay();
       }
       public void SaveLatestNews(ref CustomList<LatestNews> LatestNewsList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(LatestNewsList);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, LatestNewsList);

                conManager.CommitTransaction();
                LatestNewsList.AcceptChanges();
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
       private void ReSetSPName(CustomList<LatestNews> LatestNewsList)
        {
            #region Company Policies
            LatestNewsList.InsertSpName = "spInsertLatestNews";
            LatestNewsList.UpdateSpName = "spUpdateLatestNews";
            LatestNewsList.DeleteSpName = "spDeleteLatestNews";
            #endregion
        }
    }
}
