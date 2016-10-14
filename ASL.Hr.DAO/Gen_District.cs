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
    public class Gen_District : BaseItem
    {
        public Gen_District()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _DistrictKey;
        [Browsable(true), DisplayName("DistrictKey")]
        public System.Int32 DistrictKey
        {
            get
            {
                return _DistrictKey;
            }
            set
            {
                if (PropertyChanged(_DistrictKey, value))
                    _DistrictKey = value;
            }
        }

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

        private System.String _DistrictName;
        [Browsable(true), DisplayName("DistrictName")]
        public System.String DistrictName
        {
            get
            {
                return _DistrictName;
            }
            set
            {
                if (PropertyChanged(_DistrictName, value))
                    _DistrictName = value;
            }
        }

        private System.String _DistrictCode;
        [Browsable(true), DisplayName("DistrictCode")]
        public System.String DistrictCode
        {
            get
            {
                return _DistrictCode;
            }
            set
            {
                if (PropertyChanged(_DistrictCode, value))
                    _DistrictCode = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _CountryKey, _DistrictName, _DistrictCode };
            else if (IsModified)
                parameterValues = new Object[] { _CountryKey, _DistrictName, _DistrictCode };
            else if (IsDeleted)
                parameterValues = new Object[] { _DistrictKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _DistrictKey = reader.GetInt32("DistrictKey");
            _CountryKey = reader.GetInt32("CountryKey");
            _DistrictName = reader.GetString("DistrictName");
            _DistrictCode = reader.GetString("DistrictCode");
            SetUnchanged();
        }
        public static CustomList<Gen_District> GetAllGen_District()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Gen_District> Gen_DistrictCollection = new CustomList<Gen_District>();
            IDataReader reader = null;
            const String sql = "select * from Gen_District";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Gen_District newGen_District = new Gen_District();
                    newGen_District.SetData(reader);
                    Gen_DistrictCollection.Add(newGen_District);
                }
                Gen_DistrictCollection.InsertSpName = "spInsertGen_District";
                Gen_DistrictCollection.UpdateSpName = "spUpdateGen_District";
                Gen_DistrictCollection.DeleteSpName = "spDeleteGen_District";
                return Gen_DistrictCollection;
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