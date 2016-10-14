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
    public class UserGroupList : BaseItem
    {
        public UserGroupList()
        {
            SetAdded();
        }

        #region Properties

        [Browsable(true), DisplayName("Name")]
        public System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (PropertyChanged(_Name, value))
                    _Name = value;
            }
        }
        private System.String _Name;
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
        private System.String _GroupName;


        #endregion
        public override Object[] GetParameterValues()
        {
            return null;
        }
        protected override void SetData(IDataRecord reader)
        {
            //_Name = reader.GetString("Name");
            _GroupName = reader.GetString("GroupName");
            SetUnchanged();
        }
        public static CustomList<UserGroupList> GetAllUserGroupWithUserCode(string userCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<UserGroupList> UserGroupListCollection = new CustomList<UserGroupList>();
            String sql = "Exec spUserGroupList'" + userCode + "'";
            IDataReader reader = null;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    UserGroupList newUserGroup = new UserGroupList();
                    newUserGroup.SetData(reader);
                    UserGroupListCollection.Add(newUserGroup);
                }
                reader.Close();
                return UserGroupListCollection;
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

