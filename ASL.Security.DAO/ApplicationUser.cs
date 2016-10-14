using System;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ASL.Security.DAO
{
    [Serializable]
    public class ApplicationUser : BaseItem
    {
        public ApplicationUser()
        {
            SetAdded();
        }

        #region Properties
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
        [Browsable(true), DisplayName("IsDefault")]
        public System.Boolean IsDefault
        {
            get
            {
                return _IsDefault;
            }
            set
            {
                if (PropertyChanged(_IsDefault, value))
                    _IsDefault = value;
            }
        }
        private System.Boolean _IsDefault;
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
                parameterValues = new Object[] { _ApplicationID, _UserCode, _IsDefault, _CompanyID };
            else if (IsModified)
                parameterValues = new Object[] { _ApplicationID, _UserCode, _IsDefault, _CompanyID };
            else if (IsDeleted)
                parameterValues = new Object[] { _ApplicationID, _UserCode };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ApplicationID = reader.GetInt32("ApplicationID");
            _UserCode = reader.GetString("UserCode");
            _IsDefault = reader.GetBoolean("IsDefault");
            _CompanyID = reader.GetString("CompanyID");
            SetUnchanged();
        }
        public static CustomList<ApplicationUser> GetAllApplicationUser()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<ApplicationUser> ApplicationUserCollection = new CustomList<ApplicationUser>();
            IDataReader reader = null;
            const String sql = "Select * from ApplicationUser";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ApplicationUser newApplicationUser = new ApplicationUser();
                    newApplicationUser.SetData(reader);
                    ApplicationUserCollection.Add(newApplicationUser);
                }
                ApplicationUserCollection.InsertSpName = "spInsertApplicationUser";
                ApplicationUserCollection.UpdateSpName = "spUpdateApplicationUser";
                ApplicationUserCollection.DeleteSpName = "spDeleteApplicationUser";
                return ApplicationUserCollection;
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

        public static ApplicationUser GetDefaultApplicationByUserCode(string userCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            IDataReader reader = null;

            conManager.OpenDataReader(out reader, "spWebGetDefaultApplicationByUserCode", userCode);
            ApplicationUser newApplication = new ApplicationUser(); try
            {
                while (reader.Read())
                {
                    newApplication.SetData(reader);
                }
                return newApplication;
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