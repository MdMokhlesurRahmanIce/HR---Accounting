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
    public class Users : BaseItem
    {
        public Users()
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

        private System.String _EmpCode;
        [Browsable(true), DisplayName("EmpCode")]
        public System.String EmpCode
        {
            get
            {
                return _EmpCode;
            }
            set
            {
                if (PropertyChanged(_EmpCode, value))
                    _EmpCode = value;
            }
        }

        private System.String _EmpName;
        [Browsable(true), DisplayName("EmpName")]
        public System.String EmpName
        {
            get
            {
                return _EmpName;
            }
            set
            {
                if (PropertyChanged(_EmpName, value))
                    _EmpName = value;
            }
        }

        private System.String _Name;
        [Browsable(true), DisplayName("UserName")]
        public System.String UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                if (PropertyChanged(_UserName, value))
                    _UserName = value;
            }
        }
        private System.String _UserName;
        [Browsable(true), DisplayName("Password")]
        public System.String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                if (PropertyChanged(_Password, value))
                    _Password = value;
            }
        }
        private System.String _Password;
        [Browsable(true), DisplayName("IsAdmin")]
        public System.Int32 IsAdmin
        {
            get
            {
                return _IsAdmin;
            }
            set
            {
                if (PropertyChanged(_IsAdmin, value))
                    _IsAdmin = value;
            }
        }
        private System.Int32 _IsAdmin;
        [Browsable(true), DisplayName("IsActive")]
        public System.Int32 IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                if (PropertyChanged(_IsActive, value))
                    _IsActive = value;
            }
        }

        private System.String _EmpType;
        [Browsable(true), DisplayName("EmpType")]
        public System.String EmpType
        {
            get
            {
                return _EmpType;
            }
            set
            {
                if (PropertyChanged(_EmpType, value))
                    _EmpType = value;
            }
        }
        private System.String _Grade;
        [Browsable(true), DisplayName("Grade")]
        public System.String Grade
        {
            get
            {
                return _Grade;
            }
            set
            {
                if (PropertyChanged(_Grade, value))
                    _Grade = value;
            }
        }
        private System.String _Designation;
        [Browsable(true), DisplayName("Designation")]
        public System.String Designation
        {
            get
            {
                return _Designation;
            }
            set
            {
                if (PropertyChanged(_Designation, value))
                    _Designation = value;
            }
        }
        private System.String _Department;
        [Browsable(true), DisplayName("Department")]
        public System.String Department
        {
            get
            {
                return _Department;
            }
            set
            {
                if (PropertyChanged(_Department, value))
                    _Department = value;
            }
        }

        private System.String _Company;
        [Browsable(true), DisplayName("Company")]
        public System.String Company
        {
            get
            {
                return _Company;
            }
            set
            {
                if (PropertyChanged(_Company, value))
                    _Company = value;
            }
        }

        private System.Int64 _EmpKey;
        [Browsable(true), DisplayName("EmpKey")]
        public System.Int64 EmpKey
        {
            get
            {
                return _EmpKey;
            }
            set
            {
                if (PropertyChanged(_EmpKey, value))
                    _EmpKey = value;
            }
        }
        private System.Int32 _IsActive;
        #endregion
        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _UserCode, _Name, _UserName, _Password, _IsAdmin, _IsActive, _EmpCode};
            else if (IsModified)
                parameterValues = new Object[] { _UserCode, _Name, _UserName, _Password, _IsAdmin, _IsActive, _EmpCode };
            else if (IsDeleted)
                parameterValues = new Object[] { _UserCode };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _UserCode = reader.GetString("UserCode");
            _Name = reader.GetString("Name");
            _UserName = reader.GetString("UserName");
            _Password = reader.GetString("Password");
            _IsAdmin = reader.GetInt32("IsAdmin");
            _IsActive = reader.GetInt32("IsActive");
            _EmpCode = reader.GetString("EmpCode");
            SetUnchanged();
        }
        private void SetDataEmp(IDataRecord reader)
        {
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            SetUnchanged();
        }
        private void SetDataDoLogin(IDataRecord reader)
        {
            _UserCode = reader.GetString("UserCode");
            _Name = reader.GetString("Name");
            _UserName = reader.GetString("UserName");
            _Password = reader.GetString("Password");
            _IsAdmin = reader.GetInt32("IsAdmin");
            _IsActive = reader.GetInt32("IsActive");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            _Company = reader.GetString("Company");
            _Department = reader.GetString("Department");
            _EmpType = reader.GetString("EmpType");
            _Grade = reader.GetString("Grade");
            _Designation = reader.GetString("Designation");
            _EmpKey = reader.GetInt64("EmpKey");
            SetUnchanged();
        }
        public static CustomList<Users> doSearch(string whereClause)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<Users> UsersCollection = new CustomList<Users>();
            IDataReader reader = null;
            String sql = string.Format("Select * From [User] Where 1=1 {0}", whereClause);
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Users newUsers = new Users();
                    newUsers.SetData(reader);
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
        public static Users DoLogin(string userName, string password)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            IDataReader reader = null;

            conManager.OpenDataReader(out reader, "spWebLogin ", userName,password);
            try
            {
                Users user = new Users();
                while (reader.Read())
                {
                    user.SetDataDoLogin(reader);
                }
                return user;
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
        public static Users GetUserInfoByEmployeeCode(String employeeCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            IDataReader reader = null;
            String sql = String.Format("Select * From [User] Where EmployeeCode = '{0}'", employeeCode);
            try
            {
                conManager.OpenDataReader(sql, out reader);
                Users user = new Users();
                while (reader.Read())
                {
                    user.SetData(reader);
                    break;
                }
                return user;
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

        public static Users GetDefaultApplicationByUserCode(string userCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            IDataReader reader = null;


            conManager.OpenDataReader(out reader, "spWebGetDefaultApplicationByUserCode", userCode);
            try
            {
                Users user = new Users();
                while (reader.Read())
                {
                    user.SetData(reader);
                    break;
                }
                return user;
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
        public static CustomList<Users> GetAllEmp()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Users> EmpCollection = new CustomList<Users>();
            IDataReader reader = null;
            String sql = String.Format("select EmpCode,EmpName from HRM_Emp");
            try
            {
                conManager.OpenDataReader(sql, out reader);

                while (reader.Read())
                {
                    Users user = new Users();
                    user.SetDataEmp(reader);
                    EmpCollection.Add(user);
                }
                return EmpCollection;
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