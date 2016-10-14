using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using System.Web;
using System.Web.SessionState;

namespace ASL.Security.DAO
{
    [Serializable]
    public class LeftMenuItems : BaseItem
    {
        public LeftMenuItems()
        {
            SetAdded();
        }

        #region Properties
        [Browsable(true), DisplayName("ObjectID")]
        public System.Int32 ObjectID
        {
            get
            {
                return _ObjectID;
            }
            set
            {
                if (PropertyChanged(_ObjectID, value))
                    _ObjectID = value;
            }
        }
        private System.Int32 _ObjectID;
        [Browsable(true), DisplayName("ApplicationID")]
        public System.Int32 ApplicationID
        {
            get
            {
                return _ApplicationID;
            }
            set
            {
                if (PropertyChanged(_ApplicationID, value))
                    _ApplicationID = value;
            }
        }
        private System.Int32 _ApplicationID;
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
        private System.Int32 _ParentID;
        [Browsable(true), DisplayName("FormName")]
        public System.String FormName
        {
            get
            {
                return _FormName;
            }
            set
            {
                if (PropertyChanged(_FormName, value))
                    _FormName = value;
            }
        }
        private System.String _FormName;
        [Browsable(true), DisplayName("DisplayMember")]
        public System.String DisplayMember
        {
            get
            {
                return _DisplayMember;
            }
            set
            {
                if (PropertyChanged(_DisplayMember, value))
                    _DisplayMember = value;
            }
        }
        private System.String _DisplayMember;
        [Browsable(true), DisplayName("MenuType")]
        public System.String MenuType
        {
            get
            {
                return _MenuType;
            }
            set
            {
                if (PropertyChanged(_MenuType, value))
                    _MenuType = value;
            }
        }
        private System.String _MenuType;
        [Browsable(true), DisplayName("MenuSequence")]
        public System.Int32 MenuSequence
        {
            get
            {
                return _MenuSequence;
            }
            set
            {
                if (PropertyChanged(_MenuSequence, value))
                    _MenuSequence = value;
            }
        }
        private System.Int32 _MenuSequence;
        [Browsable(true), DisplayName("ValueMember")]
        public System.Int32 ValueMember
        {
            get
            {
                return _ValueMember;
            }
            set
            {
                if (PropertyChanged(_ValueMember, value))
                    _ValueMember = value;
            }
        }
        private System.Int32 _ValueMember;
        [Browsable(true), DisplayName("ObjectType")]
        public System.String ObjectType
        {
            get
            {
                return _ObjectType;
            }
            set
            {
                if (PropertyChanged(_ObjectType, value))
                    _ObjectType = value;
            }
        }
        private System.String _ObjectType;
        [Browsable(true), DisplayName("CanSelect")]
        public System.Boolean CanSelect
        {
            get
            {
                return _CanSelect;
            }
            set
            {
                if (PropertyChanged(_CanSelect, value))
                    _CanSelect = value;
            }
        }
        private System.Boolean _CanSelect;
        [Browsable(true), DisplayName("CanInsert")]
        public System.Boolean CanInsert
        {
            get
            {
                return _CanInsert;
            }
            set
            {
                if (PropertyChanged(_CanInsert, value))
                    _CanInsert = value;
            }
        }
        private System.Boolean _CanInsert;
        [Browsable(true), DisplayName("CanUpdate")]
        public System.Boolean CanUpdate
        {
            get
            {
                return _CanUpdate;
            }
            set
            {
                if (PropertyChanged(_CanUpdate, value))
                    _CanUpdate = value;
            }
        }
        private System.Boolean _CanUpdate;
        [Browsable(true), DisplayName("CanDelete")]
        public System.Boolean CanDelete
        {
            get
            {
                return _CanDelete;
            }
            set
            {
                if (PropertyChanged(_CanDelete, value))
                    _CanDelete = value;
            }
        }
        private System.Boolean _CanDelete;
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ApplicationID, _ParentID, _FormName, _DisplayMember, _MenuType, _MenuSequence, _ValueMember };
            else if (IsModified)
                parameterValues = new Object[] { _ApplicationID, _ParentID, _FormName, _DisplayMember, _MenuType, _MenuSequence, _ValueMember };
            else if (IsDeleted)
                parameterValues = new Object[] { _ObjectID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ObjectID = reader.GetInt32("ObjectID");
            //_ApplicationID = reader.GetInt32("ApplicationID");
            _ParentID = reader.GetInt32("ParentID");
            _FormName = reader.GetString("FormName");
            _DisplayMember = reader.GetString("DisplayMember");
            _MenuType = reader.GetString("MenuType");
            _MenuSequence = reader.GetInt32("MenuSequence");
            _ValueMember = reader.GetInt32("ValueMember");
            _ObjectType = reader.GetString("ObjectType");
            _CanSelect = reader.GetBoolean("CanSelect");
            _CanInsert = reader.GetBoolean("CanInsert");
            _CanUpdate = reader.GetBoolean("CanUpdate");
            _CanDelete = reader.GetBoolean("CanDelete");
            SetUnchanged();
        }
        public static CustomList<LeftMenuItems> GetAllLeftMenuItems()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<LeftMenuItems> LeftMenuItemsCollection = new CustomList<LeftMenuItems>();
            IDataReader reader = null;
            const String sql = "select MenuID as ObjectID, ApplicationID, ParentID, FormName, DisplayMember,MenuType, MenuSequence, ValueMember,'menu' As ObjectType, CAST(1 as bit) CanSelect, CAST(1 as bit) CanInsert,CAST (1 as bit) CanUpdate, CAST (1as bit) CanDelete from Menu";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeftMenuItems newLeftMenuItems = new LeftMenuItems();
                    newLeftMenuItems.SetData(reader);
                    LeftMenuItemsCollection.Add(newLeftMenuItems);
                }
                LeftMenuItemsCollection.InsertSpName = "spInsertLeftMenuItems";
                LeftMenuItemsCollection.UpdateSpName = "spUpdateLeftMenuItems";
                LeftMenuItemsCollection.DeleteSpName = "spDeleteLeftMenuItems";
                return LeftMenuItemsCollection;
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

        public static CustomList<LeftMenuItems> GetAllLeftMenuItemsByUserCodeAndApplicationID(string userCode, int applicationId)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<LeftMenuItems> LeftMenuItemsCollection = new CustomList<LeftMenuItems>();
            IDataReader reader = null;

            if (HttpContext.Current.Session["UserSession_LeftMenu"] != null)
                return (CustomList<LeftMenuItems>)HttpContext.Current.Session["UserSession_LeftMenu"];

            conManager.OpenDataReader(out reader, "spWebGetMenusByUserAndApplication", userCode, applicationId);
           
            try
            {
                while (reader.Read())
                {
                    LeftMenuItems newLeftMenuItems = new LeftMenuItems();
                    newLeftMenuItems.SetData(reader);
                    LeftMenuItemsCollection.Add(newLeftMenuItems);
                }

                LeftMenuItemsCollection.InsertSpName = "spInsertLeftMenuItems";
                LeftMenuItemsCollection.UpdateSpName = "spUpdateLeftMenuItems";
                LeftMenuItemsCollection.DeleteSpName = "spDeleteLeftMenuItems";

                HttpContext.Current.Session["UserSession_LeftMenu"] = LeftMenuItemsCollection;
                return LeftMenuItemsCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager != null)
                {
                    conManager.CloseConnection();
                    conManager.Dispose();
                }
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
    }
}