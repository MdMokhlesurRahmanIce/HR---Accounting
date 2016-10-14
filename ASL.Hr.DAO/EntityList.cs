using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ASL.Hr.DAO
{
    [Serializable]
    public class EntityList : BaseItem
    {
        public EntityList()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _EntityID;
        [Browsable(true), DisplayName("EntityID")]
        public System.Int32 EntityID
        {
            get
            {
                return _EntityID;
            }
            set
            {
                if (PropertyChanged(_EntityID, value))
                    _EntityID = value;
            }
        }

        private System.String _EntityName;
        [Browsable(true), DisplayName("EntityName")]
        public System.String EntityName
        {
            get
            {
                return _EntityName;
            }
            set
            {
                if (PropertyChanged(_EntityName, value))
                    _EntityName = value;
            }
        }

        private System.Boolean _IsOfficialInfo;
        [Browsable(true), DisplayName("IsOfficialInfo")]
        public System.Boolean IsOfficialInfo
        {
            get
            {
                return _IsOfficialInfo;
            }
            set
            {
                if (PropertyChanged(_IsOfficialInfo, value))
                    _IsOfficialInfo = value;
            }
        }

        private System.Boolean _IsUsed;
        [Browsable(true), DisplayName("IsUsed")]
        public System.Boolean IsUsed
        {
            get
            {
                return _IsUsed;
            }
            set
            {
                if (PropertyChanged(_IsUsed, value))
                    _IsUsed = value;
            }
        }

        private System.Int32 _Sequence;
        [Browsable(true), DisplayName("Sequence")]
        public System.Int32 Sequence
        {
            get
            {
                return _Sequence;
            }
            set
            {
                if (PropertyChanged(_Sequence, value))
                    _Sequence = value;
            }
        }

        private System.Int32 _ListOfEntity;
        [Browsable(true), DisplayName("ListOfEntity")]
        public System.Int32 ListOfEntity
        {
            get
            {
                return _ListOfEntity;
            }
            set
            {
                if (PropertyChanged(_ListOfEntity, value))
                    _ListOfEntity = value;
            }
        }
        private System.Int32 _FieldType;
        [Browsable(true), DisplayName("FieldType")]
        public System.Int32 FieldType
        {
            get
            {
                return _FieldType;
            }
            set
            {
                if (PropertyChanged(_FieldType, value))
                    _FieldType = value;
            }
        }

        private System.Boolean _HaveParent;
        [Browsable(true), DisplayName("HaveParent")]
        public System.Boolean HaveParent
        {
            get
            {
                return _HaveParent;
            }
            set
            {
                if (PropertyChanged(_HaveParent, value))
                    _HaveParent = value;
            }
        }

        private System.Boolean _HaveChild;
        [Browsable(true), DisplayName("HaveChild")]
        public System.Boolean HaveChild
        {
            get
            {
                return _HaveChild;
            }
            set
            {
                if (PropertyChanged(_HaveChild, value))
                    _HaveChild = value;
            }
        }
        private System.Int32 _ParentID;
        [Browsable(true), DisplayName("ParentID")]
        public System.Int32 ParentID
        {
            get
            {
                return _ParentID;
            }
            set
            {
                if (PropertyChanged(_ParentID, value))
                    _ParentID = value;
            }
        }

        private System.Boolean _IsUseToProDataCapture;
        [Browsable(true), DisplayName("IsUseToProDataCapture")]
        public System.Boolean IsUseToProDataCapture
        {
            get
            {
                return _IsUseToProDataCapture;
            }
            set
            {
                if (PropertyChanged(_IsUseToProDataCapture, value))
                    _IsUseToProDataCapture = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EntityName, _IsUsed, _IsOfficialInfo, _FieldType, _Sequence, _ListOfEntity, _HaveParent, _HaveChild, _ParentID, _IsUseToProDataCapture };
            else if (IsModified)
                parameterValues = new Object[] { _EntityID, _EntityName, _IsUsed, _IsOfficialInfo, _FieldType, _Sequence, _ListOfEntity, _HaveParent, _HaveChild, _ParentID, _IsUseToProDataCapture };
            else if (IsDeleted)
                parameterValues = new Object[] { _EntityID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _EntityID = reader.GetInt32("EntityID");
            _EntityName = reader.GetString("EntityName");
            _IsUsed = reader.GetBoolean("IsUsed");
            _IsOfficialInfo = reader.GetBoolean("IsOfficialInfo");
            _FieldType = reader.GetInt32("FieldType");
            _Sequence = reader.GetInt32("Sequence");
            _ListOfEntity = reader.GetInt32("ListOfEntity");
            _HaveParent = reader.GetBoolean("HaveParent");
            _HaveChild = reader.GetBoolean("HaveChild");
            _ParentID = reader.GetInt32("ParentID");
            _IsUseToProDataCapture = reader.GetBoolean("IsUseToProDataCapture");
            SetUnchanged();
        }
        public static CustomList<EntityList> GetAllEntityList()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<EntityList> EntityListCollection = new CustomList<EntityList>();
            IDataReader reader = null;
            String sql = "Exec spGetSelectionCriteria";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    EntityList newEntityList = new EntityList();
                    newEntityList.SetData(reader);
                    EntityListCollection.Add(newEntityList);
                }
                EntityListCollection.InsertSpName = "spInsertEntityList";
                EntityListCollection.UpdateSpName = "spUpdateEntityList";
                EntityListCollection.DeleteSpName = "spDeleteEntityList";
                return EntityListCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static CustomList<EntityList> GetAllEntityListForHouseKeeping()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<EntityList> EntityListCollection = new CustomList<EntityList>();
            IDataReader reader = null;
            const String sql = "select *from EntityList Where IsUsed=1  And FieldType is NOT NULL";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    EntityList newEntityList = new EntityList();
                    newEntityList.SetData(reader);
                    EntityListCollection.Add(newEntityList);
                }
                EntityListCollection.InsertSpName = "spInsertEntityList";
                EntityListCollection.UpdateSpName = "spUpdateEntityList";
                EntityListCollection.DeleteSpName = "spDeleteEntityList";
                return EntityListCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static Int32 GetAllEntityList(string entityID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);

            Int32 parentID = 0;
            try
            {
                String sql = "select ParentID from EntityList Where  EntityID=" + entityID;
                Object parent = conManager.ExecuteScalarWrapper(sql);
                parentID = Convert.ToInt32(parent);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
            return parentID;
        }
        public static CustomList<EntityList> GetAllEntityListForOfficialInfo()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<EntityList> EntityListCollection = new CustomList<EntityList>();
            IDataReader reader = null;
            const String sql = "select *from EntityList Where IsUsed=1 And IsOfficialInfo=1 And FieldType is NOT NULL";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    EntityList newEntityList = new EntityList();
                    newEntityList.SetData(reader);
                    EntityListCollection.Add(newEntityList);
                }
                return EntityListCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        public static CustomList<EntityList> GetPromotionHiararchy(int PromotionOrSearchCritaria)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<EntityList> EntityListCollection = new CustomList<EntityList>();
            IDataReader reader = null;
            String sql = "spGetPromotionHierarchy " + PromotionOrSearchCritaria;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    EntityList newEntityList = new EntityList();
                    newEntityList.EntityName = reader.GetString("EntityName");
                    EntityListCollection.Add(newEntityList);
                }
                return EntityListCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
    }
}
