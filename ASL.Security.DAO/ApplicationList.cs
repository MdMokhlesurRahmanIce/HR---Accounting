using System;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
//using ASL.STATIC;
using ASL.STATIC;

namespace ASL.Security.DAO
{
    [Serializable]
    public class ApplicationList : BaseItem
    {
        public ApplicationList()
        {
            SetAdded();
        }
       
        #region Properties
        private System.String _ApplicationID;
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

        private System.String _ApplicationName;
        [Browsable(true), DisplayName("ApplicationName")]
        public System.String ApplicationName
        {
            get
            {
                return _ApplicationName;
            }
            set
            {
                if (PropertyChanged(_ApplicationName, value))
                    _ApplicationName = value;
            }
        }
        private System.String _AddedBy;
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
        private System.String _UpdatedBy;
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
        private System.DateTime _DateAdded;
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
        private System.DateTime _DateUpdated;
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



        #endregion

        public override Object[] GetParameterValues()
        {
            return null;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ApplicationID = reader.GetString("ApplicationID");
            _ApplicationName = reader.GetString("ApplicationName");
            _AddedBy = reader.GetString("AddedBy");
            _UpdatedBy = reader.GetString("UpdatedBy");
            _DateAdded = reader.GetDateTime("DateAdded");
            _DateUpdated = reader.GetDateTime("DateUpdated");
            SetUnchanged();
        }
        public static CustomList<ApplicationList> GetAllApplicationName(string companyID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<ApplicationList> ApplicationCollection = new CustomList<ApplicationList>();
            IDataReader reader = null;
            String sql = "Exec spApplication '" + companyID + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ApplicationList newApplication = new ApplicationList();
                    newApplication.SetData(reader);
                    ApplicationCollection.Add(newApplication);
                }
                reader.Close();
                return ApplicationCollection;
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
