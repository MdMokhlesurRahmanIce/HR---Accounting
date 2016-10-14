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
   public class EntityManager
    {
       public CustomList<EntityList> GetAllEntityListForOfficialInfo()
       {
           return EntityList.GetAllEntityListForOfficialInfo();
       }
 
       public CustomList<EntityList> GetAllEntityList()
       {
           return EntityList.GetAllEntityList();
       }
       public void SaveEntity(ref CustomList<EntityList> EntityList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPName(EntityList);

               blnTranStarted = true;

               conManager.SaveDataCollectionThroughCollection(blnTranStarted, EntityList);

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
       private void ReSetSPName(CustomList<EntityList> EntityList)
       {
           #region Look Up Entity
           EntityList.InsertSpName = "spInsertEntityList";
           EntityList.UpdateSpName = "spUpdateEntityList";
           EntityList.DeleteSpName = "spDeleteEntityList";
           #endregion
       }
    }
}
