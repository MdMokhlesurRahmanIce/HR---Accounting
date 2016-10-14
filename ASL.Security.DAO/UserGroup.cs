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
    public class UserGroup : BaseItem
    {
        public UserGroup()
        {
            SetAdded();
        }

        #region Properties

        [Browsable(true), DisplayName("UserCode")]
        public System.String UserCode
        {
            get
            {
                return _UserCode;
            }
            set
            {
                if (PropertyChanged(_UserCode, value))
                    _UserCode = value;
            }
        }
        private System.String _UserCode;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] {_UserCode, _GroupCode};
            else if (IsModified)
                parameterValues = new Object[] {_UserCode, _GroupCode};
            else if (IsDeleted)
                parameterValues = new Object[] {_UserCode, _GroupCode };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _UserCode = reader.GetString("UserCode");
            _GroupCode = reader.GetString("GroupCode");
            SetUnchanged();
        }
        private void SetDataForUserGroup(IDataRecord reader)
        {
            _UserCode = reader.GetString("UserCode");
            _Name = reader.GetString("Name");
            SetUnchanged();
        }
        public static CustomList<UserGroup> GetAllUserGroup(string groupCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<UserGroup> UserGroupCollection = new CustomList<UserGroup>();
            String sql = "Select *from UserGroup where GroupCode='" + groupCode + "'";
            IDataReader reader = null; ;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    UserGroup newUserGroup = new UserGroup();
                    newUserGroup.SetData(reader);
                    UserGroupCollection.Add(newUserGroup);
                }
                reader.Close();
                return UserGroupCollection;
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
        public static CustomList<UserGroup> GetAllUser()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<UserGroup> UsersCollection = new CustomList<UserGroup>();
            IDataReader reader = null;
            String sql = string.Format("Select * From [User]");
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    UserGroup newUsers = new UserGroup();
                    newUsers.SetDataForUserGroup(reader);
                    UsersCollection.Add(newUsers);
                }
                return UsersCollection;
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
