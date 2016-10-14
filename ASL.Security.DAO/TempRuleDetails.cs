using System;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ASL.Security.DAO
{
    [Serializable]
    public class TempRuleDetails : BaseItem
    {
        public TempRuleDetails()
        {
            SetAdded();
        }

        #region Properties
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
        [Browsable(true), DisplayName("ObjectID")]
        public System.String ObjectID
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
        private System.String _ObjectID;
        [Browsable(true), DisplayName("SecurityRuleCode")]
        public System.String SecurityRuleCode
        {
            get
            {
                return _SecurityRuleCode;
            }
            set
            {
                if (PropertyChanged(_SecurityRuleCode, value))
                    _SecurityRuleCode = value;
            }
        }
        private System.String _SecurityRuleCode;
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
        [Browsable(true), DisplayName("CompanyID")]
        public System.String CompanyID
        {
            get
            {
                return _CompanyID;
            }
            set
            {
                if (PropertyChanged(_CompanyID, value))
                    _CompanyID = value;
            }
        }
        private System.String _CompanyID;
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ApplicationID, _ObjectID, _SecurityRuleCode, _ObjectType, _CanSelect, _CanInsert, _CanUpdate, _CanDelete, _AddedBy, _UpdatedBy, _DateAdded.Value(StaticInfo.DateFormat), _DateUpdated.Value(StaticInfo.DateFormat), _CompanyID };
            else if (IsModified)
                parameterValues = new Object[] { _ApplicationID, _ObjectID, _SecurityRuleCode, _ObjectType, _CanSelect, _CanInsert, _CanUpdate, _CanDelete, _AddedBy, _UpdatedBy, _DateAdded.Value(StaticInfo.DateFormat), _DateUpdated.Value(StaticInfo.DateFormat), _CompanyID };
            else if (IsDeleted)
                parameterValues = new Object[] { _ApplicationID, _ObjectID, _SecurityRuleCode, _ObjectType };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ApplicationID = reader.GetString("ApplicationID");
            _ObjectID = reader.GetString("ObjectID");
            _SecurityRuleCode = reader.GetString("SecurityRuleCode");
            _ObjectType = reader.GetString("ObjectType");
            _CanSelect = reader.GetBoolean("CanSelect");
            _CanInsert = reader.GetBoolean("CanInsert");
            _CanUpdate = reader.GetBoolean("CanUpdate");
            _CanDelete = reader.GetBoolean("CanDelete");
            _AddedBy = reader.GetString("AddedBy");
            _UpdatedBy = reader.GetString("UpdatedBy");
            _DateAdded = reader.GetDateTime("DateAdded");
            _DateUpdated = reader.GetDateTime("DateUpdated");
            _CompanyID = reader.GetString("CompanyID");
            SetUnchanged();
        }
        public static CustomList<TempRuleDetails> GetAllSecurityRule_ObjectWithSecurityRule(string securityRuleCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<TempRuleDetails> SecurityRule_ObjectCollection = new CustomList<TempRuleDetails>();
            IDataReader reader = null;
            String sql = "Select * from SecurityRule_Object where SecurityRuleCode='" + securityRuleCode + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    TempRuleDetails newSecurityRule_Object = new TempRuleDetails();
                    newSecurityRule_Object.SetData(reader);
                    SecurityRule_ObjectCollection.Add(newSecurityRule_Object);
                }
                SecurityRule_ObjectCollection.InsertSpName = "spInsertSecurityRule_Object";
                SecurityRule_ObjectCollection.UpdateSpName = "spUpdateSecurityRule_Object";
                SecurityRule_ObjectCollection.DeleteSpName = "spDeleteSecurityRule_Object";
                return SecurityRule_ObjectCollection;
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
        public static CustomList<TempRuleDetails> GetAllSecurityRule_ObjectWithApplicationID(string applicationID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<TempRuleDetails> SecurityRule_ObjectCollection = new CustomList<TempRuleDetails>();
            IDataReader reader = null;
            String sql = "Select * from SecurityRule_Object where ApplicationID='" + applicationID + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    TempRuleDetails newSecurityRule_Object = new TempRuleDetails();
                    newSecurityRule_Object.SetData(reader);
                    SecurityRule_ObjectCollection.Add(newSecurityRule_Object);
                }
                SecurityRule_ObjectCollection.InsertSpName = "spInsertSecurityRule_Object";
                SecurityRule_ObjectCollection.UpdateSpName = "spUpdateSecurityRule_Object";
                SecurityRule_ObjectCollection.DeleteSpName = "spDeleteSecurityRule_Object";
                return SecurityRule_ObjectCollection;
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
