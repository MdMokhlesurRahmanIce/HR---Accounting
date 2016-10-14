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
    public class HRM_EmpAddr : BaseItem
    {
        public HRM_EmpAddr()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _EmpAddrKey;
        [Browsable(true), DisplayName("EmpAddrKey")]
        public System.Int64 EmpAddrKey
        {
            get
            {
                return _EmpAddrKey;
            }
            set
            {
                if (PropertyChanged(_EmpAddrKey, value))
                    _EmpAddrKey = value;
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

        private System.Int32? _PreCountryKey;
        [Browsable(true), DisplayName("PreCountryKey")]
        public System.Int32? PreCountryKey
        {
            get
            {
                return _PreCountryKey;
            }
            set
            {
                if (PropertyChanged(_PreCountryKey, value))
                    _PreCountryKey = value;
            }
        }

        private System.Int32? _PreDistrictKey;
        [Browsable(true), DisplayName("PreDistrictKey")]
        public System.Int32? PreDistrictKey
        {
            get
            {
                return _PreDistrictKey;
            }
            set
            {
                if (PropertyChanged(_PreDistrictKey, value))
                    _PreDistrictKey = value;
            }
        }

        private System.Int32? _PreCity;
        [Browsable(true), DisplayName("PreCity")]
        public System.Int32? PreCity
        {
            get
            {
                return _PreCity;
            }
            set
            {
                if (PropertyChanged(_PreCity, value))
                    _PreCity = value;
            }
        }

        private System.Int32? _PreState;
        [Browsable(true), DisplayName("PreState")]
        public System.Int32? PreState
        {
            get
            {
                return _PreState;
            }
            set
            {
                if (PropertyChanged(_PreState, value))
                    _PreState = value;
            }
        }

        private System.String _PrePS;
        [Browsable(true), DisplayName("PrePS")]
        public System.String PrePS
        {
            get
            {
                return _PrePS;
            }
            set
            {
                if (PropertyChanged(_PrePS, value))
                    _PrePS = value;
            }
        }

        private System.String _BPrePS;
        [Browsable(true), DisplayName("BPrePS")]
        public System.String BPrePS
        {
            get
            {
                return _BPrePS;
            }
            set
            {
                if (PropertyChanged(_BPrePS, value))
                    _BPrePS = value;
            }
        }

        private System.String _PrePO;
        [Browsable(true), DisplayName("PrePO")]
        public System.String PrePO
        {
            get
            {
                return _PrePO;
            }
            set
            {
                if (PropertyChanged(_PrePO, value))
                    _PrePO = value;
            }
        }

        private System.String _BPrePO;
        [Browsable(true), DisplayName("BPrePO")]
        public System.String BPrePO
        {
            get
            {
                return _BPrePO;
            }
            set
            {
                if (PropertyChanged(_BPrePO, value))
                    _BPrePO = value;
            }
        }

        private System.String _CareOf;
        [Browsable(true), DisplayName("CareOf")]
        public System.String CareOf
        {
            get
            {
                return _CareOf;
            }
            set
            {
                if (PropertyChanged(_CareOf, value))
                    _CareOf = value;
            }
        }

        private System.String _BCareOf;
        [Browsable(true), DisplayName("BCareOf")]
        public System.String BCareOf
        {
            get
            {
                return _BCareOf;
            }
            set
            {
                if (PropertyChanged(_BCareOf, value))
                    _BCareOf = value;
            }
        }

        private System.String _PreVillage;
        [Browsable(true), DisplayName("PreVillage")]
        public System.String PreVillage
        {
            get
            {
                return _PreVillage;
            }
            set
            {
                if (PropertyChanged(_PreVillage, value))
                    _PreVillage = value;
            }
        }

        private System.String _BPreVillage;
        [Browsable(true), DisplayName("BPreVillage")]
        public System.String BPreVillage
        {
            get
            {
                return _BPreVillage;
            }
            set
            {
                if (PropertyChanged(_BPreVillage, value))
                    _BPreVillage = value;
            }
        }

        private System.String _PrePostalCode;
        [Browsable(true), DisplayName("PrePostalCode")]
        public System.String PrePostalCode
        {
            get
            {
                return _PrePostalCode;
            }
            set
            {
                if (PropertyChanged(_PrePostalCode, value))
                    _PrePostalCode = value;
            }
        }

        private System.String _BPrePostalCode;
        [Browsable(true), DisplayName("BPrePostalCode")]
        public System.String BPrePostalCode
        {
            get
            {
                return _BPrePostalCode;
            }
            set
            {
                if (PropertyChanged(_BPrePostalCode, value))
                    _BPrePostalCode = value;
            }
        }

        private System.String _PreAdditional;
        [Browsable(true), DisplayName("PreAdditional")]
        public System.String PreAdditional
        {
            get
            {
                return _PreAdditional;
            }
            set
            {
                if (PropertyChanged(_PreAdditional, value))
                    _PreAdditional = value;
            }
        }

        private System.String _BPreAdditional;
        [Browsable(true), DisplayName("BPreAdditional")]
        public System.String BPreAdditional
        {
            get
            {
                return _BPreAdditional;
            }
            set
            {
                if (PropertyChanged(_BPreAdditional, value))
                    _BPreAdditional = value;
            }
        }

        private System.Int32? _PerCountryKey;
        [Browsable(true), DisplayName("PerCountryKey")]
        public System.Int32? PerCountryKey
        {
            get
            {
                return _PerCountryKey;
            }
            set
            {
                if (PropertyChanged(_PerCountryKey, value))
                    _PerCountryKey = value;
            }
        }

        private System.Int32? _PerDistrictKey;
        [Browsable(true), DisplayName("PerDistrictKey")]
        public System.Int32? PerDistrictKey
        {
            get
            {
                return _PerDistrictKey;
            }
            set
            {
                if (PropertyChanged(_PerDistrictKey, value))
                    _PerDistrictKey = value;
            }
        }

        private System.Int32? _PerCity;
        [Browsable(true), DisplayName("PerCity")]
        public System.Int32? PerCity
        {
            get
            {
                return _PerCity;
            }
            set
            {
                if (PropertyChanged(_PerCity, value))
                    _PerCity = value;
            }
        }

        private System.Int32? _PerState;
        [Browsable(true), DisplayName("PerState")]
        public System.Int32? PerState
        {
            get
            {
                return _PerState;
            }
            set
            {
                if (PropertyChanged(_PerState, value))
                    _PerState = value;
            }
        }

        private System.String _PerPS;
        [Browsable(true), DisplayName("PerPS")]
        public System.String PerPS
        {
            get
            {
                return _PerPS;
            }
            set
            {
                if (PropertyChanged(_PerPS, value))
                    _PerPS = value;
            }
        }

        private System.String _BPerPS;
        [Browsable(true), DisplayName("BPerPS")]
        public System.String BPerPS
        {
            get
            {
                return _BPerPS;
            }
            set
            {
                if (PropertyChanged(_BPerPS, value))
                    _BPerPS = value;
            }
        }

        private System.String _PerPO;
        [Browsable(true), DisplayName("PerPO")]
        public System.String PerPO
        {
            get
            {
                return _PerPO;
            }
            set
            {
                if (PropertyChanged(_PerPO, value))
                    _PerPO = value;
            }
        }

        private System.String _BPerPO;
        [Browsable(true), DisplayName("BPerPO")]
        public System.String BPerPO
        {
            get
            {
                return _BPerPO;
            }
            set
            {
                if (PropertyChanged(_BPerPO, value))
                    _BPerPO = value;
            }
        }

        private System.String _PerCareOf;
        [Browsable(true), DisplayName("PerCareOf")]
        public System.String PerCareOf
        {
            get
            {
                return _PerCareOf;
            }
            set
            {
                if (PropertyChanged(_PerCareOf, value))
                    _PerCareOf = value;
            }
        }

        private System.String _BPerCareOf;
        [Browsable(true), DisplayName("BPerCareOf")]
        public System.String BPerCareOf
        {
            get
            {
                return _BPerCareOf;
            }
            set
            {
                if (PropertyChanged(_BPerCareOf, value))
                    _BPerCareOf = value;
            }
        }

        private System.String _PerVillage;
        [Browsable(true), DisplayName("PerVillage")]
        public System.String PerVillage
        {
            get
            {
                return _PerVillage;
            }
            set
            {
                if (PropertyChanged(_PerVillage, value))
                    _PerVillage = value;
            }
        }

        private System.String _BPerVillage;
        [Browsable(true), DisplayName("BPerVillage")]
        public System.String BPerVillage
        {
            get
            {
                return _BPerVillage;
            }
            set
            {
                if (PropertyChanged(_BPerVillage, value))
                    _BPerVillage = value;
            }
        }

        private System.String _PerPostalCode;
        [Browsable(true), DisplayName("PerPostalCode")]
        public System.String PerPostalCode
        {
            get
            {
                return _PerPostalCode;
            }
            set
            {
                if (PropertyChanged(_PerPostalCode, value))
                    _PerPostalCode = value;
            }
        }

        private System.String _BPerPostalCode;
        [Browsable(true), DisplayName("BPerPostalCode")]
        public System.String BPerPostalCode
        {
            get
            {
                return _BPerPostalCode;
            }
            set
            {
                if (PropertyChanged(_BPerPostalCode, value))
                    _BPerPostalCode = value;
            }
        }

        private System.String _PerAdditional;
        [Browsable(true), DisplayName("PerAdditional")]
        public System.String PerAdditional
        {
            get
            {
                return _PerAdditional;
            }
            set
            {
                if (PropertyChanged(_PerAdditional, value))
                    _PerAdditional = value;
            }
        }

        private System.String _BPerAdditional;
        [Browsable(true), DisplayName("BPerAdditional")]
        public System.String BPerAdditional
        {
            get
            {
                return _BPerAdditional;
            }
            set
            {
                if (PropertyChanged(_BPerAdditional, value))
                    _BPerAdditional = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _PreCountryKey, _PreDistrictKey, _PreCity, _PreState, _PrePS, _BPrePS, _PrePO, _BPrePO, _CareOf, _BCareOf, _PreVillage, _BPreVillage, _PrePostalCode, _BPrePostalCode, _PreAdditional, _BPreAdditional, _PerCountryKey, _PerDistrictKey, _PerCity, _PerState, _PerPS, _BPerPS, _PerPO, _BPerPO, _PerCareOf, _BPerCareOf, _PerVillage, _BPerVillage, _PerPostalCode, _BPerPostalCode, _PerAdditional, _BPerAdditional };
            else if (IsModified)
                parameterValues = new Object[] {_EmpAddrKey, _EmpKey, _PreCountryKey, _PreDistrictKey, _PreCity, _PreState, _PrePS, _BPrePS, _PrePO, _BPrePO, _CareOf, _BCareOf, _PreVillage, _BPreVillage, _PrePostalCode, _BPrePostalCode, _PreAdditional, _BPreAdditional, _PerCountryKey, _PerDistrictKey, _PerCity, _PerState, _PerPS, _BPerPS, _PerPO, _BPerPO, _PerCareOf, _BPerCareOf, _PerVillage, _BPerVillage, _PerPostalCode, _BPerPostalCode, _PerAdditional, _BPerAdditional };
            else if (IsDeleted)
                parameterValues = new Object[] { _EmpAddrKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _EmpAddrKey = reader.GetInt64("EmpAddrKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _PreCountryKey = reader.GetInt32("PreCountryKey");
            _PreDistrictKey = reader.GetInt32("PreDistrictKey");
            _PreCity = reader.GetInt32("PreCity");
            _PreState = reader.GetInt32("PreState");
            _PrePS = reader.GetString("PrePS");
            _BPrePS = reader.GetString("BPrePS");
            _PrePO = reader.GetString("PrePO");
            _BPrePO = reader.GetString("BPrePO");
            _CareOf = reader.GetString("CareOf");
            _BCareOf = reader.GetString("BCareOf");
            _PreVillage = reader.GetString("PreVillage");
            _BPreVillage = reader.GetString("BPreVillage");
            _PrePostalCode = reader.GetString("PrePostalCode");
            _BPrePostalCode = reader.GetString("BPrePostalCode");
            _PreAdditional = reader.GetString("PreAdditional");
            _BPreAdditional = reader.GetString("BPreAdditional");
            _PerCountryKey = reader.GetInt32("PerCountryKey");
            _PerDistrictKey = reader.GetInt32("PerDistrictKey");
            _PerCity = reader.GetInt32("PerCity");
            _PerState = reader.GetInt32("PerState");
            _PerPS = reader.GetString("PerPS");
            _BPerPS = reader.GetString("BPerPS");
            _PerPO = reader.GetString("PerPO");
            _BPerPO = reader.GetString("BPerPO");
            _PerCareOf = reader.GetString("PerCareOf");
            _BPerCareOf = reader.GetString("BPerCareOf");
            _PerVillage = reader.GetString("PerVillage");
            _BPerVillage = reader.GetString("BPerVillage");
            _PerPostalCode = reader.GetString("PerPostalCode");
            _BPerPostalCode = reader.GetString("BPerPostalCode");
            _PerAdditional = reader.GetString("PerAdditional");
            _BPerAdditional = reader.GetString("BPerAdditional");
            SetUnchanged();
        }
        private void SetDataSearchEmp(IDataRecord reader)
        {
            //_PreAddr = reader.GetString("PreAddr");
            //_PreDistrictName = reader.GetString("PreDistrictName");
            //_PrePSName = reader.GetString("PrePSName");
            //_PrePOName = reader.GetString("PrePOName");
            //_PrePhone = reader.GetString("PrePhone");
            //_PerAddr = reader.GetString("PerAddr");
            //_PerDistrictName = reader.GetString("PerDistrictName");
            //_PerPSName = reader.GetString("PerPSName");
            //_PerPOName = reader.GetString("PerPOName");
            //_PerPhone = reader.GetString("PerPhone");
            //_ContactPerson = reader.GetString("ContactPerson");
            //_ContactPersonPh = reader.GetString("ContactPersonPh");
            //_ContactPersonAddr = reader.GetString("ContactPersonAddr");
            ////_Remark = reader.GetString("Remark");
            //_ContactPersonRelation = reader.GetString("ContactPersonRelation");
            SetUnchanged();
        }
        public static CustomList<HRM_EmpAddr> GetAllHRM_EmpAddr()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EmpAddr> HRM_EmpAddrCollection = new CustomList<HRM_EmpAddr>();
            IDataReader reader = null;
            const String sql = "select * from hrm_empaddr";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EmpAddr newHRM_EmpAddr = new HRM_EmpAddr();
                    newHRM_EmpAddr.SetData(reader);
                    HRM_EmpAddrCollection.Add(newHRM_EmpAddr);
                }
                HRM_EmpAddrCollection.InsertSpName = "spInsertHRM_EmpAddr";
                HRM_EmpAddrCollection.UpdateSpName = "spUpdateHRM_EmpAddr";
                HRM_EmpAddrCollection.DeleteSpName = "spDeleteHRM_EmpAddr";
                return HRM_EmpAddrCollection;
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

        public static HRM_EmpAddr GetSearchEmpAddress(long empKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            IDataReader reader = null;
            String sql = "EXEC spGetSearchEmpAddress '" + empKey + "'";
            try
            {
                HRM_EmpAddr newHRM_EmpAddr = new HRM_EmpAddr();
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    newHRM_EmpAddr.SetDataSearchEmp(reader);
                }
                return newHRM_EmpAddr;
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

        public static CustomList<HRM_EmpAddr> GetAllEmpAddrByEmpKey(string empKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EmpAddr> HRM_EmpAddrCollection = new CustomList<HRM_EmpAddr>();
            IDataReader reader = null;
            String sql = "select * from hrm_empaddr ea where ea.EmpKey = " + empKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EmpAddr newHRM_EmpAddr = new HRM_EmpAddr();
                    newHRM_EmpAddr.SetData(reader);
                    HRM_EmpAddrCollection.Add(newHRM_EmpAddr);
                }
                HRM_EmpAddrCollection.InsertSpName = "spInsertHRM_EmpAddr";
                HRM_EmpAddrCollection.UpdateSpName = "spUpdateHRM_EmpAddr";
                HRM_EmpAddrCollection.DeleteSpName = "spDeleteHRM_EmpAddr";
                return HRM_EmpAddrCollection;
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