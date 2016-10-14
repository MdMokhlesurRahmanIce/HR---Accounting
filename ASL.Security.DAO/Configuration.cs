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
    public class Configuration : BaseItem
    {
        public Configuration()
        {
            SetAdded();
        }

        #region Properties
        [Browsable(true), DisplayName("ConfigurationID")]
        public System.String ConfigurationID
        {
            get
            {
                return _ConfigurationID;
            }
            set
            {
                if (PropertyChanged(_ConfigurationID, value))
                    _ConfigurationID = value;
            }
        }
        private System.String _ConfigurationID;
        [Browsable(true), DisplayName("ConfigurationName")]
        public System.String ConfigurationName
        {
            get
            {
                return _ConfigurationName;
            }
            set
            {
                if (PropertyChanged(_ConfigurationName, value))
                    _ConfigurationName = value;
            }
        }
        private System.String _ConfigurationName;
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ConfigurationID, _ConfigurationName };
            else if (IsModified)
                parameterValues = new Object[] { _ConfigurationID, _ConfigurationName };
            else if (IsDeleted)
                parameterValues = new Object[] { _ConfigurationID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ConfigurationID = reader.GetString("ConfigurationID");
            _ConfigurationName = reader.GetString("ConfigurationName");
            SetUnchanged();
        }
        public static CustomList<Configuration> GetAllConfiguration()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<Configuration> ConfigurationCollection = new CustomList<Configuration>();
            const String sql = "Select *from tblConfiguration";
            IDataReader reader = null; ;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Configuration newConfiguration = new Configuration();
                    newConfiguration.SetData(reader);
                    ConfigurationCollection.Add(newConfiguration);
                }
                reader.Close();
                ConfigurationCollection.SelectSpName = "spSelectConfiguration";
                ConfigurationCollection.InsertSpName = "spInsertConfiguration";
                ConfigurationCollection.UpdateSpName = "spUpdateConfiguration";
                ConfigurationCollection.SelectSpName = "spDeleteConfiguration";
                return ConfigurationCollection;
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
