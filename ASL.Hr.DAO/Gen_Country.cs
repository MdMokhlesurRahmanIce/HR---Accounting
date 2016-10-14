using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ASL.Hr.DAO
{
    [Serializable]
    public class Gen_Country : BaseItem
    {
        public Gen_Country()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _CountryKey;
        [Browsable(true), DisplayName("CountryKey")]
        public System.Int32 CountryKey
        {
            get
            {
                return _CountryKey;
            }
            set
            {
                if (PropertyChanged(_CountryKey, value))
                    _CountryKey = value;
            }
        }

        private System.String _CountryName;
        [Browsable(true), DisplayName("CountryName")]
        public System.String CountryName
        {
            get
            {
                return _CountryName;
            }
            set
            {
                if (PropertyChanged(_CountryName, value))
                    _CountryName = value;
            }
        }

        private System.String _CountrySName;
        [Browsable(true), DisplayName("CountrySName")]
        public System.String CountrySName
        {
            get
            {
                return _CountrySName;
            }
            set
            {
                if (PropertyChanged(_CountrySName, value))
                    _CountrySName = value;
            }
        }

        private System.String _CountryCode;
        [Browsable(true), DisplayName("CountryCode")]
        public System.String CountryCode
        {
            get
            {
                return _CountryCode;
            }
            set
            {
                if (PropertyChanged(_CountryCode, value))
                    _CountryCode = value;
            }
        }

        private System.String _GMT;
        [Browsable(true), DisplayName("GMT")]
        public System.String GMT
        {
            get
            {
                return _GMT;
            }
            set
            {
                if (PropertyChanged(_GMT, value))
                    _GMT = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _CountryName, _CountrySName, _CountryCode, _GMT };
            else if (IsModified)
                parameterValues = new Object[] { _CountryName, _CountrySName, _CountryCode, _GMT };
            else if (IsDeleted)
                parameterValues = new Object[] { _CountryKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _CountryKey = reader.GetInt32("CountryKey");
            _CountryName = reader.GetString("CountryName");
            _CountrySName = reader.GetString("CountrySName");
            _CountryCode = reader.GetString("CountryCode");
            _GMT = reader.GetString("GMT");
            SetUnchanged();
        }
        public static CustomList<Gen_Country> GetAllGen_Country()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Gen_Country> Gen_CountryCollection = new CustomList<Gen_Country>();
            IDataReader reader = null;
            const String sql = "select * from Gen_Country";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Gen_Country newGen_Country = new Gen_Country();
                    newGen_Country.SetData(reader);
                    Gen_CountryCollection.Add(newGen_Country);
                }
                Gen_CountryCollection.InsertSpName = "spInsertGen_Country";
                Gen_CountryCollection.UpdateSpName = "spUpdateGen_Country";
                Gen_CountryCollection.DeleteSpName = "spDeleteGen_Country";
                return Gen_CountryCollection;
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