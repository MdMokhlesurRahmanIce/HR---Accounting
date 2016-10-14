using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class HKEntryManager
    {
        public CustomList<EntityList> GetAllEntityList()
        {
            return EntityList.GetAllEntityList();
        }
        public CustomList<EntityList> GetAllEntityListForHouseKeeping()
        {
            return EntityList.GetAllEntityListForHouseKeeping();
        }
        public CustomList<HouseKeepingValue> GetAllHouseKeepingValue(string entityKey)
        {
            return HouseKeepingValue.GetAllHouseKeepingValue(entityKey);
        }
        public Int32 GetAllEntityList(string entityKey)
        {
            return EntityList.GetAllEntityList(entityKey);
        }
        public CustomList<HousekeepingHierarchy> GetAllHousekeepingHierarchy(Int32 hKID)
        {
            return HousekeepingHierarchy.GetAllHousekeepingHierarchy(hKID);
        }
        public CustomList<HouseKeepingValue> GetAllHouseKeepingValue()
        {
            return HouseKeepingValue.GetAllHouseKeepingValue();
        }
        public CustomList<HouseKeepingValue> GetAllOfficialInfo()
        {
            return HouseKeepingValue.GetAllOfficialInfo();
        }
        public CustomList<HouseKeepingValue> GetAllCustomerInfo()
        {
            return HouseKeepingValue.GetAllCustomerInfo();
        }
        public void DeleteHKEntry(ref CustomList<HouseKeepingValue> HKList, ref CustomList<HouseKeepingValue> lstParent, ref CustomList<HousekeepingHierarchy> lstChild)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;
            try
            {
                conManager.BeginTransaction();

                ReSetSPName(HKList);

                blnTranStarted = true;

                foreach (HouseKeepingValue h in HKList)
                    h.Delete();
                CustomList<HousekeepingHierarchy> hKHList = new CustomList<HousekeepingHierarchy>();
                CustomList<HousekeepingHierarchy> deletedHKHList = new CustomList<HousekeepingHierarchy>();
                foreach (HouseKeepingValue hKV in lstParent)
                {

                    HousekeepingHierarchy deletedObj = lstChild.Find(f => f.ParentID == hKV.HKID);
                    if (deletedObj.IsNotNull())
                        deletedHKHList.Add(deletedObj);

                }
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, deletedHKHList, HKList);

                deletedHKHList.AcceptChanges();
                hKHList.AcceptChanges();
                HKList.AcceptChanges();

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
        public void SaveHKEntry(ref CustomList<HouseKeepingValue> HKList, ref CustomList<HouseKeepingValue> lstParent, ref CustomList<HousekeepingHierarchy> lstChild)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(HKList);

                blnTranStarted = true;

                Object scope_Identity = null;
                if (HKList[0].IsAdded)
                    scope_Identity = conManager.InsertData(blnTranStarted, HKList);
                else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, HKList);

                CustomList<HousekeepingHierarchy> hKHList = new CustomList<HousekeepingHierarchy>();
                CustomList<HousekeepingHierarchy> deletedHKHList = new CustomList<HousekeepingHierarchy>();
                foreach (HouseKeepingValue hKV in lstParent)
                {
                    if (!hKV.IsSaved)
                    {
                        HousekeepingHierarchy deletedObj = lstChild.Find(f => f.ParentID == hKV.HKID);
                        if (deletedObj.IsNotNull())
                            deletedHKHList.Add(deletedObj);
                    }
                    if (hKV.IsSaved)
                    {
                        HousekeepingHierarchy hKH = new HousekeepingHierarchy();
                        HousekeepingHierarchy deletedHKH = new HousekeepingHierarchy();

                        if (scope_Identity.IsNull())
                        {
                            hKH.HKID = HKList[0].HKID;
                            deletedHKH.HKID = HKList[0].HKID;
                        }
                        else
                        {
                            hKH.HKID = Convert.ToInt32(scope_Identity);
                            deletedHKH.HKID = Convert.ToInt32(scope_Identity);
                            HKList[0].HKID = Convert.ToInt32(scope_Identity);
                        }

                        hKH.ParentID = hKV.HKID;
                        deletedHKH.ParentID = hKV.HKID;
                        hKHList.Add(hKH);
                        deletedHKHList.Add(deletedHKH);
                    }
                }
                deletedHKHList.ForEach(f => f.Delete());
                hKHList.InsertSpName = "spInsertHousekeepingHierarchy";
                hKHList.UpdateSpName = "spUpdateHousekeepingHierarchy";
                hKHList.DeleteSpName = "spDeleteHousekeepingHierarchy";

                deletedHKHList.DeleteSpName = "spDeleteHousekeepingHierarchy";

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, deletedHKHList, hKHList);

                deletedHKHList.AcceptChanges();
                hKHList.AcceptChanges();

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
        private void ReSetSPName(CustomList<HouseKeepingValue> HKVList)
        {
            #region HK

            HKVList.InsertSpName = "spInsertHouseKeepingValue";
            HKVList.UpdateSpName = "spUpdateHouseKeepingValue";
            HKVList.DeleteSpName = "spDeleteHouseKeepingValue";
            #endregion
        }
    }
}
