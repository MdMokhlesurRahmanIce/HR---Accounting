
using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ASL.Security.DAO
{
    [Serializable]
    public class Group : BaseItem
    {
        public Group()
        {
            SetAdded();
        }

        #region Properties
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
        [Browsable(true), DisplayName("GroupName")]
        public System.String GroupName
        {
            get
            {
                return _GroupName;
            }
            set
            {
                if (PropertyChanged(_GroupName, value))
                    _GroupName = value;
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
                if (PropertyChanged(_OrgKey, value))
                    _OrgKey = value;
            }
        }
        private System.String _GroupName;
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _GroupCode, _GroupName, _OrgKey };
            else if (IsModified)
                parameterValues = new Object[] { _GroupCode, _GroupName, _OrgKey };
            else if (IsDeleted)
                parameterValues = new Object[] { _GroupCode };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _GroupCode = reader.GetString("GroupCode");
            _GroupName = reader.GetString("GroupName");
            _OrgKey = reader.GetInt32("OrgKey");
            SetUnchanged();
        }
        public static CustomList<Group> doSearch(string whereClause)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<Group> GroupCollection = new CustomList<Group>();
            String sql = string.Format("Select * From [Group] Where 1=1 {0}", whereClause);
            IDataReader reader = null; ;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Group newGroup = new Group();
                    newGroup.SetData(reader);
                    GroupCollection.Add(newGroup);
                }
                reader.Close();
                GroupCollection.SelectSpName = "spSelectGroup";
                GroupCollection.InsertSpName = "spInsertGroup";
                GroupCollection.UpdateSpName = "spUpdateGroup";
                GroupCollection.SelectSpName = "spDeleteGroup";
                return GroupCollection;
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
