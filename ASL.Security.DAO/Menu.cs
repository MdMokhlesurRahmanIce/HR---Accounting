using System;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
//using ASL.STATIC;
using ASL.STATIC;
using ASL.Security.DAO;

namespace ASL.Security.DAO
{
    [Serializable]
    public class Menu : BaseItem
    {
        public Menu()
        {
            SetAdded();
        }

        #region Properties
        [Browsable(true), DisplayName("MenuID")]
        public System.String MenuID
        {
            get
            {
                return _MenuID;
            }
            set
            {
                if (PropertyChanged(_MenuID, value))
                    _MenuID = value;
            }
        }
        private System.String _MenuID;
        [Browsable(true), DisplayName("ApplicationID")]
        public System.String ApplicationID
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
        private System.String _ApplicationID;
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
        [Browsable(true), DisplayName("IsVisible")]
        public System.Int32 IsVisible
        {
            get
            {
                return _IsVisible;
            }
            set
            {
                if (PropertyChanged(_IsVisible, value))
                    _IsVisible = value;
            }
        }
        private System.Int32 _IsVisible;
        [Browsable(true), DisplayName("Type")]
        public System.Int32 Type
        {
            get
            {
                return _Type;
            }
            set
            {
                if (PropertyChanged(_Type, value))
                    _Type = value;
            }
        }
        private System.Int32 _Type;
        [Browsable(true), DisplayName("Description")]
        public System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (PropertyChanged(_Description, value))
                    _Description = value;
            }
        }
        private System.String _Description;
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
        [Browsable(true), DisplayName("DataType")]
        public System.String DataType
        {
            get
            {
                return _DataType;
            }
            set
            {
                if (PropertyChanged(_DataType, value))
                    _DataType = value;
            }
        }
        private System.String _DataType;
        [Browsable(true), DisplayName("RestrictionLimit")]
        public System.Int32 RestrictionLimit
        {
            get
            {
                return _RestrictionLimit;
            }
            set
            {
                if (PropertyChanged(_RestrictionLimit, value))
                    _RestrictionLimit = value;
            }
        }
        private System.Int32 _RestrictionLimit;
        [Browsable(true), DisplayName("Assembly")]
        public System.String Assembly
        {
            get
            {
                return _Assembly;
            }
            set
            {
                if (PropertyChanged(_Assembly, value))
                    _Assembly = value;
            }
        }
        private System.String _Assembly;
        [Browsable(true), DisplayName("NameSpace")]
        public System.String NameSpace
        {
            get
            {
                return _NameSpace;
            }
            set
            {
                if (PropertyChanged(_NameSpace, value))
                    _NameSpace = value;
            }
        }
        private System.String _NameSpace;
        [Browsable(true), DisplayName("MethodName")]
        public System.String MethodName
        {
            get
            {
                return _MethodName;
            }
            set
            {
                if (PropertyChanged(_MethodName, value))
                    _MethodName = value;
            }
        }
        private System.String _MethodName;
        [Browsable(true), DisplayName("IsAdminOnly")]
        public System.Boolean IsAdminOnly
        {
            get
            {
                return _IsAdminOnly;
            }
            set
            {
                if (PropertyChanged(_IsAdminOnly, value))
                    _IsAdminOnly = value;
            }
        }
        private System.Boolean _IsAdminOnly;
        [Browsable(true), DisplayName("ResourceLocation")]
        public System.String ResourceLocation
        {
            get
            {
                return _ResourceLocation;
            }
            set
            {
                if (PropertyChanged(_ResourceLocation, value))
                    _ResourceLocation = value;
            }
        }
        private System.String _ResourceLocation;
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
        [Browsable(true), DisplayName("AddedBy")]
        public System.String AddedBy
        {
            get
            {
                return _AddedBy;
            }
            set
            {
                if (PropertyChanged(_AddedBy, value))
                    _AddedBy = value;
            }
        }
        private System.String _AddedBy;
        [Browsable(true), DisplayName("UpdatedBy")]
        public System.String UpdatedBy
        {
            get
            {
                return _UpdatedBy;
            }
            set
            {
                if (PropertyChanged(_UpdatedBy, value))
                    _UpdatedBy = value;
            }
        }
        private System.String _UpdatedBy;
        [Browsable(true), DisplayName("DateAdded")]
        public System.DateTime DateAdded
        {
            get
            {
                return _DateAdded;
            }
            set
            {
                if (PropertyChanged(_DateAdded, value))
                    _DateAdded = value;
            }
        }
        private System.DateTime _DateAdded;
        [Browsable(true), DisplayName("DateUpdated")]
        public System.DateTime DateUpdated
        {
            get
            {
                return _DateUpdated;
            }
            set
            {
                if (PropertyChanged(_DateUpdated, value))
                    _DateUpdated = value;
            }
        }
        private System.DateTime _DateUpdated;
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ApplicationID, _ValueMember, _DisplayMember, _ParentID, _IsVisible, _Type, _Description, _FormName, _MenuType, _MenuSequence, _DataType, _RestrictionLimit, _Assembly, _NameSpace, _MethodName, _IsAdminOnly, _ResourceLocation };
            else if (IsModified)
                parameterValues = new Object[] { _ApplicationID, _ValueMember, _DisplayMember, _ParentID, _IsVisible, _Type, _Description, _FormName, _MenuType, _MenuSequence, _DataType, _RestrictionLimit, _Assembly, _NameSpace, _MethodName, _IsAdminOnly, _ResourceLocation };
            else if (IsDeleted)
                parameterValues = new Object[] { _MenuID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _MenuID = reader.GetString("MenuID");
            _ApplicationID = reader.GetString("ApplicationID");
            _ValueMember = reader.GetInt32("ValueMember");
            _DisplayMember = reader.GetString("DisplayMember");
            _ParentID = reader.GetInt32("ParentID");
            _IsVisible = reader.GetInt32("IsVisible");
            _Type = reader.GetInt32("Type");
            _Description = reader.GetString("Description");
            _FormName = reader.GetString("FormName");
            _MenuType = reader.GetString("MenuType");
            _MenuSequence = reader.GetInt32("MenuSequence");
            _DataType = reader.GetString("DataType");
            //_RestrictionLimit = reader.GetInt32("RestrictionLimit");
            //_Assembly = reader.GetString("Assembly");
            //_NameSpace = reader.GetString("NameSpace");
            //_MethodName = reader.GetString("MethodName");
            //_IsAdminOnly = reader.GetBoolean("IsAdminOnly");
            //_ResourceLocation = reader.GetString("ResourceLocation");
            SetUnchanged();
        }
        public static CustomList<Menu> GetAllMenuByApplicationID(int applicationID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<Menu> MenuCollection = new CustomList<Menu>();
            IDataReader reader = null;
            String sql = String.Format("Select * from Menu Where ApplicationID = '" + applicationID + "'and FormName is not NULL");
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Menu newMenu = new Menu();
                    newMenu.SetData(reader);
                    MenuCollection.Add(newMenu);
                }
                MenuCollection.InsertSpName = "spInsertMenu";
                MenuCollection.UpdateSpName = "spUpdateMenu";
                MenuCollection.DeleteSpName = "spDeleteMenu";
                return MenuCollection;
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

        public static CustomList<Menu> GetAllMenuItemsByUserCode(string UserCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<Menu> MenuCollection = new CustomList<Menu>();
            IDataReader reader = null;

            conManager.OpenDataReader(out reader, "spWebGetMenuAndAccessRights", UserCode);
            try
            {
                while (reader.Read())
                {
                    Menu newMenu = new Menu();
                    newMenu.SetData(reader);
                    MenuCollection.Add(newMenu);
                }

                MenuCollection.InsertSpName = "spInsertMenu";
                MenuCollection.UpdateSpName = "spUpdateMenu";
                MenuCollection.DeleteSpName = "spDeleteMenu";
                return MenuCollection;
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

        public static Menu GetAllAccessRightsOfAPage(string UserCode, int ObjectID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            IDataReader reader = null;

            conManager.OpenDataReader(out reader, "spWebGetMenuAndAccessRights", UserCode, ObjectID);
            try
            {
                Menu menu = new Menu();
                while (reader.Read())
                {
                    menu.SetData(reader);
                }
                return menu;
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