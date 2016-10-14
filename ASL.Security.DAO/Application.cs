using System;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC; 


namespace ASL.Security.DAO
{
    [Serializable]
    public class Application : BaseItem
    {
        public Application()
        {
            SetAdded();
        }

        #region Properties
        [Browsable(true), DisplayName("App ID")]
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
        [Browsable(true), DisplayName("Name")]
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
        private System.String _ApplicationName;
        [Browsable(true), DisplayName("Description")]
        public System.String ApplicationDescription
        {
            get
            {
                return _ApplicationDescription;
            }
            set
            {
                if (PropertyChanged(_ApplicationDescription, value))
                    _ApplicationDescription = value;
            }
        }
        private System.String _ApplicationDescription;
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
        [Browsable(false), DisplayName("ApplicationLogo")]
        public System.Byte[] ApplicationLogo
        {
            get
            {
                return _ApplicationLogo;
            }
            set
            {
                if (PropertyChanged(_ApplicationLogo, value))
                    _ApplicationLogo = value;
            }
        }
        private System.Byte[] _ApplicationLogo;
        [Browsable(false), DisplayName("ApplicationLogoPath")]
        public System.String ApplicationLogoPath
        {
            get
            {
                return _ApplicationLogoPath;
            }
            set
            {
                if (PropertyChanged(_ApplicationLogoPath, value))
                    _ApplicationLogoPath = value;
            }
        }
        private System.String _ApplicationLogoPath;
        [Browsable(true), DisplayName("SequenceNo")]
        public System.Int32 SequenceNo
        {
            get
            {
                return _SequenceNo;
            }
            set
            {
                if (PropertyChanged(_SequenceNo, value))
                    _SequenceNo = value;
            }
        }
        private System.Int32 _SequenceNo;
        [Browsable(false), DisplayName("IsInUse")]
        public System.Boolean IsInUse
        {
            get
            {
                return _IsInUse;
            }
            set
            {
                if (PropertyChanged(_IsInUse, value))
                    _IsInUse = value;
            }
        }
        private System.Boolean _IsInUse;
        [Browsable(true), DisplayName("IsSaved")]
        public System.Boolean IsSaved
        {
            get
            {
                return _IsSaved;
            }
            set
            {
                if (PropertyChanged(_IsSaved, value))
                    _IsSaved = value;
            }
        }
        private System.Boolean _IsSaved;
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ApplicationName, _ApplicationDescription, _IsDefault, _ApplicationLogo, _ApplicationLogoPath, _SequenceNo, _IsInUse };
            else if (IsModified)
                parameterValues = new Object[] { _ApplicationName, _ApplicationDescription, _IsDefault, _ApplicationLogo, _ApplicationLogoPath, _SequenceNo, _IsInUse };
            else if (IsDeleted)
                parameterValues = new Object[] { _ApplicationID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ApplicationID = reader.GetString("ApplicationID");
            _ApplicationName = reader.GetString("ApplicationName");
            //_ApplicationDescription = reader.GetString("ApplicationDescription");
            //_IsDefault = reader.GetBoolean("IsDefault");
            //_ApplicationLogo = null;
            //_ApplicationLogoPath = reader.GetString("ApplicationLogoPath");
            //_SequenceNo = reader.GetInt32("SequenceNo");
            //_IsInUse = reader.GetBoolean("IsInUse");
            SetUnchanged();
        }
        public static CustomList<Application> GetAllApplication()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<Application> ApplicationCollection = new CustomList<Application>();
            IDataReader reader = null;
            const String sql = "Select * from Application";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Application newApplication = new Application();
                    newApplication.SetData(reader);
                    ApplicationCollection.Add(newApplication);
                }
                ApplicationCollection.InsertSpName = "spInsertApplication";
                ApplicationCollection.UpdateSpName = "spUpdateApplication";
                ApplicationCollection.DeleteSpName = "spDeleteApplication";
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