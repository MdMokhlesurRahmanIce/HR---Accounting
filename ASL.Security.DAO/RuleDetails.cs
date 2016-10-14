using System;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ASL.Security.DAO
{
    [Serializable]
    public class RuleDetails : BaseItem
    {
        public RuleDetails()
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ApplicationID, _ObjectID, _SecurityRuleCode, _ObjectType, _CanSelect, _CanInsert, _CanUpdate, _CanDelete};
            else if (IsModified)
                parameterValues = new Object[] { _ApplicationID, _ObjectID, _SecurityRuleCode, _ObjectType, _CanSelect, _CanInsert, _CanUpdate, _CanDelete};
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
            SetUnchanged();
        }
        public static CustomList<RuleDetails> GetAllSecurityRule_ObjectWithSecurityRule(string securityRuleCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<RuleDetails> SecurityRule_ObjectCollection = new CustomList<RuleDetails>();
            IDataReader reader = null;
            String sql = "Select * from RuleDetails where SecurityRuleCode='" + securityRuleCode + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    RuleDetails newSecurityRule_Object = new RuleDetails();
                    newSecurityRule_Object.SetData(reader);
                    SecurityRule_ObjectCollection.Add(newSecurityRule_Object);
                }
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
        public static CustomList<RuleDetails> GetAllSecurityRule_ObjectWithApplicationID(string applicationID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<RuleDetails> SecurityRule_ObjectCollection = new CustomList<RuleDetails>();
            IDataReader reader = null;
            String sql = "Select * from RuleDetails where ApplicationID='" + applicationID + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    RuleDetails newSecurityRule_Object = new RuleDetails();
                    newSecurityRule_Object.SetData(reader);
                    SecurityRule_ObjectCollection.Add(newSecurityRule_Object);
                }
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