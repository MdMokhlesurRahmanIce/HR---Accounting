using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ASL.Security.DAO
{
    [Serializable]
    public class GroupRule : BaseItem
    {
        public GroupRule()
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
        [Browsable(true), DisplayName("GroupCode")]
        public System.String GroupCode
        {
            get
            {
                return _GroupCode;
            }
            set
            {
                if (PropertyChanged(_GroupCode, value))
                    _GroupCode = value;
            }
        }
        private System.String _GroupCode;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ApplicationID, _GroupCode, _SecurityRuleCode};
            //else if (IsModified)
            //    parameterValues = new Object[] { _ApplicationID, _GroupCode, _SecurityRuleCode, _CompanyID };
            else if (IsDeleted)
                parameterValues = new Object[] { _ApplicationID, _GroupCode, _SecurityRuleCode };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ApplicationID = reader.GetString("ApplicationID");
            _GroupCode = reader.GetString("GroupCode");
            _SecurityRuleCode = reader.GetString("SecurityRuleCode");
            SetUnchanged();
        }
        public static CustomList<GroupRule> GetAllGroupSecurityRule(string groupCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<GroupRule> GroupSecurityRuleCollection = new CustomList<GroupRule>();
            String sql = "Select  *from GroupRule where GroupCode='" + groupCode + "'";
            IDataReader reader = null;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    GroupRule newGroupSecurityRule = new GroupRule();
                    newGroupSecurityRule.SetData(reader);
                    GroupSecurityRuleCollection.Add(newGroupSecurityRule);
                }
                reader.Close();
                GroupSecurityRuleCollection.InsertSpName = "spInsertGroupRule";
                GroupSecurityRuleCollection.SelectSpName = "spDeleteGroupRule";
                return GroupSecurityRuleCollection;
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