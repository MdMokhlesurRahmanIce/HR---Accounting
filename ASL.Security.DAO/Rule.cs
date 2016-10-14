using System;
using System.Web;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;


namespace ASL.Security.DAO
{
    [Serializable]
    public class SecurityRule : BaseItem
    {
        public SecurityRule()
        {
            SetAdded();
        }

        #region Properties
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
        [Browsable(true), DisplayName("SecurityRuleName")]
        public System.String SecurityRuleName
        {
            get
            {
                return _SecurityRuleName;
            }
            set
            {
                if (PropertyChanged(_SecurityRuleName, value))
                    _SecurityRuleName = value;
            }
        }
        private System.String _SecurityRuleName;

        private System.Boolean _IsSaved;
        [Browsable(true), DisplayName("IsSaved")]
        public System.Boolean IsSaved
        {
            get
            {
                return _IsSaved;
            }
            set
            {
                _IsSaved = value;
            }
        }

        private System.Int32 _OrgKey;
        [Browsable(true), DisplayName("OrgKey")]
        public System.Int32 OrgKey
        {
            get
            {
                return _OrgKey;
            }
            set
            {
                _OrgKey = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _SecurityRuleCode, _SecurityRuleName, _OrgKey};
            else if (IsModified)
                parameterValues = new Object[] { _SecurityRuleCode, _SecurityRuleName,_OrgKey};
            else if (IsDeleted)
                parameterValues = new Object[] { _SecurityRuleCode };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _SecurityRuleCode = reader.GetString("SecurityRuleCode");
            _SecurityRuleName = reader.GetString("SecurityRuleName");
            _OrgKey = reader.GetInt32("OrgKey");
            SetUnchanged();
        }
        public static CustomList<SecurityRule> doSearch(string whereClause)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<SecurityRule> tblSecurityRuleCollection = new CustomList<SecurityRule>();
            IDataReader reader = null;
            String sql = string.Format("Select * from [Rule] Where 1=1 {0}", whereClause);

            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SecurityRule newtblSecurityRule = new SecurityRule();
                    newtblSecurityRule.SetData(reader);
                    tblSecurityRuleCollection.Add(newtblSecurityRule);
                }
                return tblSecurityRuleCollection;
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