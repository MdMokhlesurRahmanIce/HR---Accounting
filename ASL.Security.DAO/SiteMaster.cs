using System;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ASL.Security.DAO
{
    [Serializable]
    public class SiteMaster : BaseItem
    {
        public SiteMaster()
        {
            SetAdded();
        }

        #region Properties
        [Browsable(true), DisplayName("SiteID")]
        public System.String SiteID
        {
            get
            {
                return _SiteID;
            }
            set
            {
                if (PropertyChanged(_SiteID, value))
                    _SiteID = value;
            }
        }
        private System.String _SiteID;
        [Browsable(true), DisplayName("SiteShortName")]
        public System.String SiteShortName
        {
            get
            {
                return _SiteShortName;
            }
            set
            {
                if (PropertyChanged(_SiteShortName, value))
                    _SiteShortName = value;
            }
        }
        private System.String _SiteShortName;
        [Browsable(true), DisplayName("SiteName")]
        public System.String SiteName
        {
            get
            {
                return _SiteName;
            }
            set
            {
                if (PropertyChanged(_SiteName, value))
                    _SiteName = value;
            }
        }
        private System.String _SiteName;
        [Browsable(true), DisplayName("SiteAddress")]
        public System.String SiteAddress
        {
            get
            {
                return _SiteAddress;
            }
            set
            {
                if (PropertyChanged(_SiteAddress, value))
                    _SiteAddress = value;
            }
        }
        private System.String _SiteAddress;
        [Browsable(true), DisplayName("IsCurrent")]
        public System.Boolean IsCurrent
        {
            get
            {
                return _IsCurrent;
            }
            set
            {
                if (PropertyChanged(_IsCurrent, value))
                    _IsCurrent = value;
            }
        }
        private System.Boolean _IsCurrent;
        [Browsable(true), DisplayName("IsCentralSite")]
        public System.Boolean IsCentralSite
        {
            get
            {
                return _IsCentralSite;
            }
            set
            {
                if (PropertyChanged(_IsCentralSite, value))
                    _IsCentralSite = value;
            }
        }
        private System.Boolean _IsCentralSite;
        [Browsable(true), DisplayName("CompanyIDEntered")]
        public System.String CompanyIDEntered
        {
            get
            {
                return _CompanyIDEntered;
            }
            set
            {
                if (PropertyChanged(_CompanyIDEntered, value))
                    _CompanyIDEntered = value;
            }
        }
        private System.String _CompanyIDEntered;
        [Browsable(true), DisplayName("CompanyIDLastUpdated")]
        public System.String CompanyIDLastUpdated
        {
            get
            {
                return _CompanyIDLastUpdated;
            }
            set
            {
                if (PropertyChanged(_CompanyIDLastUpdated, value))
                    _CompanyIDLastUpdated = value;
            }
        }
        private System.String _CompanyIDLastUpdated;
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
        [Browsable(true), DisplayName("SiteIDEntered")]
        public System.String SiteIDEntered
        {
            get
            {
                return _SiteIDEntered;
            }
            set
            {
                if (PropertyChanged(_SiteIDEntered, value))
                    _SiteIDEntered = value;
            }
        }
        private System.String _SiteIDEntered;
        [Browsable(true), DisplayName("SiteIDLastUpdated")]
        public System.String SiteIDLastUpdated
        {
            get
            {
                return _SiteIDLastUpdated;
            }
            set
            {
                if (PropertyChanged(_SiteIDLastUpdated, value))
                    _SiteIDLastUpdated = value;
            }
        }
        private System.String _SiteIDLastUpdated;
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _SiteID, _SiteShortName, _SiteName, _SiteAddress, _IsCurrent, _IsCentralSite, _CompanyIDEntered, _CompanyIDLastUpdated, _AddedBy, _DateAdded.Value(StaticInfo.DateFormat), _UpdatedBy, _DateUpdated.Value(StaticInfo.DateFormat), _SiteIDEntered, _SiteIDLastUpdated };
            else if (IsModified)
                parameterValues = new Object[] { _SiteID, _SiteShortName, _SiteName, _SiteAddress, _IsCurrent, _IsCentralSite, _CompanyIDEntered, _CompanyIDLastUpdated, _AddedBy, _DateAdded.Value(StaticInfo.DateFormat), _UpdatedBy, _DateUpdated.Value(StaticInfo.DateFormat), _SiteIDEntered, _SiteIDLastUpdated };
            else if (IsDeleted)
                parameterValues = new Object[] { _SiteID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _SiteID = reader.GetString("SiteID");
            _SiteShortName = reader.GetString("SiteShortName");
            _SiteName = reader.GetString("SiteName");
            _SiteAddress = reader.GetString("SiteAddress");
            _IsCurrent = reader.GetBoolean("IsCurrent");
            _IsCentralSite = reader.GetBoolean("IsCentralSite");
            _CompanyIDEntered = reader.GetString("CompanyIDEntered");
            _CompanyIDLastUpdated = reader.GetString("CompanyIDLastUpdated");
            _AddedBy = reader.GetString("AddedBy");
            _DateAdded = reader.GetDateTime("DateAdded");
            _UpdatedBy = reader.GetString("UpdatedBy");
            _DateUpdated = reader.GetDateTime("DateUpdated");
            _SiteIDEntered = reader.GetString("SiteIDEntered");
            _SiteIDLastUpdated = reader.GetString("SiteIDLastUpdated");
            SetUnchanged();
        }
        public static CustomList<SiteMaster> GetAllSiteMaster()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<SiteMaster> SiteMasterCollection = new CustomList<SiteMaster>();
            IDataReader reader = null;
            const String sql = "Select * From SiteMaster Where IsCurrent = 1";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SiteMaster newSiteMaster = new SiteMaster();
                    newSiteMaster.SetData(reader);
                    SiteMasterCollection.Add(newSiteMaster);
                }
                SiteMasterCollection.InsertSpName = "spInsertSiteMaster";
                SiteMasterCollection.UpdateSpName = "spUpdateSiteMaster";
                SiteMasterCollection.DeleteSpName = "spDeleteSiteMaster";
                return SiteMasterCollection;
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

        public static SiteMaster GetCurrentSite()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            IDataReader reader = null;
            const String sql = "Select * From SiteMaster Where IsCurrent = 1";
            try
            {
                SiteMaster newSiteMaster = new SiteMaster();
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    newSiteMaster.SetData(reader);
                }
                return newSiteMaster;
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