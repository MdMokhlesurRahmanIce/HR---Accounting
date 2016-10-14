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
    public class HRM_EmpFamily : BaseItem
    {
        public HRM_EmpFamily()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _EmpFamilyKey;
        [Browsable(true), DisplayName("EmpFamilyKey")]
        public System.Int64 EmpFamilyKey
        {
            get
            {
                return _EmpFamilyKey;
            }
            set
            {
                if (PropertyChanged(_EmpFamilyKey, value))
                    _EmpFamilyKey = value;
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

        private System.String _SpouseName;
        [Browsable(true), DisplayName("SpouseName")]
        public System.String SpouseName
        {
            get
            {
                return _SpouseName;
            }
            set
            {
                if (PropertyChanged(_SpouseName, value))
                    _SpouseName = value;
            }
        }

        private System.Int32 _SpouseOccupation;
        [Browsable(true), DisplayName("SpouseOccupation")]
        public System.Int32 SpouseOccupation
        {
            get
            {
                return _SpouseOccupation;
            }
            set
            {
                if (PropertyChanged(_SpouseOccupation, value))
                    _SpouseOccupation = value;
            }
        }

        private System.DateTime _SpouseDOB;
        [Browsable(true), DisplayName("SpouseDOB"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime SpouseDOB
        {
            get
            {
                return _SpouseDOB;
            }
            set
            {
                if (PropertyChanged(_SpouseDOB, value))
                    _SpouseDOB = value;
            }
        }

        private System.String _FatherInLaw;
        [Browsable(true), DisplayName("FatherInLaw")]
        public System.String FatherInLaw
        {
            get
            {
                return _FatherInLaw;
            }
            set
            {
                if (PropertyChanged(_FatherInLaw, value))
                    _FatherInLaw = value;
            }
        }

        private System.Int32 _FatherInLawOccupation;
        [Browsable(true), DisplayName("FatherInLawOccupation")]
        public System.Int32 FatherInLawOccupation
        {
            get
            {
                return _FatherInLawOccupation;
            }
            set
            {
                if (PropertyChanged(_FatherInLawOccupation, value))
                    _FatherInLawOccupation = value;
            }
        }

        private System.String _MotherInLaw;
        [Browsable(true), DisplayName("MotherInLaw")]
        public System.String MotherInLaw
        {
            get
            {
                return _MotherInLaw;
            }
            set
            {
                if (PropertyChanged(_MotherInLaw, value))
                    _MotherInLaw = value;
            }
        }

        private System.Int32 _MotherInLawOccupation;
        [Browsable(true), DisplayName("MotherInLawOccupation")]
        public System.Int32 MotherInLawOccupation
        {
            get
            {
                return _MotherInLawOccupation;
            }
            set
            {
                if (PropertyChanged(_MotherInLawOccupation, value))
                    _MotherInLawOccupation = value;
            }
        }

        private System.String _Father;
        [Browsable(true), DisplayName("Father")]
        public System.String Father
        {
            get
            {
                return _Father;
            }
            set
            {
                if (PropertyChanged(_Father, value))
                    _Father = value;
            }
        }

        private System.Int32 _FatherOccupation;
        [Browsable(true), DisplayName("FatherOccupation")]
        public System.Int32 FatherOccupation
        {
            get
            {
                return _FatherOccupation;
            }
            set
            {
                if (PropertyChanged(_FatherOccupation, value))
                    _FatherOccupation = value;
            }
        }

        private System.DateTime _FatherDOB;
        [Browsable(true), DisplayName("FatherDOB"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime FatherDOB
        {
            get
            {
                return _FatherDOB;
            }
            set
            {
                if (PropertyChanged(_FatherDOB, value))
                    _FatherDOB = value;
            }
        }

        private System.String _Mother;
        [Browsable(true), DisplayName("Mother")]
        public System.String Mother
        {
            get
            {
                return _Mother;
            }
            set
            {
                if (PropertyChanged(_Mother, value))
                    _Mother = value;
            }
        }

        private System.Int32 _MotherOccupation;
        [Browsable(true), DisplayName("MotherOccupation")]
        public System.Int32 MotherOccupation
        {
            get
            {
                return _MotherOccupation;
            }
            set
            {
                if (PropertyChanged(_MotherOccupation, value))
                    _MotherOccupation = value;
            }
        }

        private System.DateTime _MotherDOB;
        [Browsable(true), DisplayName("MotherDOB"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime MotherDOB
        {
            get
            {
                return _MotherDOB;
            }
            set
            {
                if (PropertyChanged(_MotherDOB, value))
                    _MotherDOB = value;
            }
        }

        private System.String _Remark;
        [Browsable(true), DisplayName("Remark")]
        public System.String Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                if (PropertyChanged(_Remark, value))
                    _Remark = value;
            }
        }

        private System.Int32 _MeritalStatus;
        [Browsable(true), DisplayName("MeritalStatus")]
        public System.Int32 MeritalStatus
        {
            get
            {
                return _MeritalStatus;
            }
            set
            {
                if (PropertyChanged(_MeritalStatus, value))
                    _MeritalStatus = value;
            }
        }
        private System.String _SpouseOccupationName;
        [Browsable(true), DisplayName("SpouseOccupationName")]
        public System.String SpouseOccupationName
        {
            get
            {
                return _SpouseOccupationName;
            }
            set
            {
                if (PropertyChanged(_SpouseOccupationName, value))
                    _SpouseOccupationName = value;
            }
        }

        private System.String _FatherInLawOccupationName;
        [Browsable(true), DisplayName("FatherInLawOccupationName")]
        public System.String FatherInLawOccupationName
        {
            get
            {
                return _FatherInLawOccupationName;
            }
            set
            {
                if (PropertyChanged(_FatherInLawOccupationName, value))
                    _FatherInLawOccupationName = value;
            }
        }

        private System.String _MotherInLawOccupationName;
        [Browsable(true), DisplayName("MotherInLawOccupationName")]
        public System.String MotherInLawOccupationName
        {
            get
            {
                return _MotherInLawOccupationName;
            }
            set
            {
                if (PropertyChanged(_MotherInLawOccupationName, value))
                    _MotherInLawOccupationName = value;
            }
        }

        private System.String _FatherOccupationName;
        [Browsable(true), DisplayName("FatherOccupationName")]
        public System.String FatherOccupationName
        {
            get
            {
                return _FatherOccupationName;
            }
            set
            {
                if (PropertyChanged(_FatherOccupationName, value))
                    _FatherOccupationName = value;
            }
        }

        private System.String _MotherOccupationName;
        [Browsable(true), DisplayName("MotherOccupationName")]
        public System.String MotherOccupationName
        {
            get
            {
                return _MotherOccupationName;
            }
            set
            {
                if (PropertyChanged(_MotherOccupationName, value))
                    _MotherOccupationName = value;
            }
        }

        private System.String _MeritalStatusName;
        [Browsable(true), DisplayName("MeritalStatusName")]
        public System.String MeritalStatusName
        {
            get
            {
                return _MeritalStatusName;
            }
            set
            {
                if (PropertyChanged(_MeritalStatusName, value))
                    _MeritalStatusName = value;
            }
        }
        private System.DateTime _DOB;
        [Browsable(true), DisplayName("DOB"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                if (PropertyChanged(_DOB, value))
                    _DOB = value;
            }
        }

        private System.String _PerAddr;
        [Browsable(true), DisplayName("PerAddr")]
        public System.String PerAddr
        {
            get
            {
                return _PerAddr;
            }
            set
            {
                if (PropertyChanged(_PerAddr, value))
                    _PerAddr = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _SpouseName, _SpouseOccupation, _SpouseDOB.Value(StaticInfo.DateFormat), _FatherInLaw, _FatherInLawOccupation, _MotherInLaw, _MotherInLawOccupation, _Father, _FatherOccupation, _FatherDOB.Value(StaticInfo.DateFormat), _Mother, _MotherOccupation, _MotherDOB.Value(StaticInfo.DateFormat), _Remark, _MeritalStatus };
            else if (IsModified)
                parameterValues = new Object[] { _EmpFamilyKey, _EmpKey, _SpouseName, _SpouseOccupation, _SpouseDOB.Value(StaticInfo.DateFormat), _FatherInLaw, _FatherInLawOccupation, _MotherInLaw, _MotherInLawOccupation, _Father, _FatherOccupation, _FatherDOB.Value(StaticInfo.DateFormat), _Mother, _MotherOccupation, _MotherDOB.Value(StaticInfo.DateFormat), _Remark, _MeritalStatus };
            else if (IsDeleted)
                parameterValues = new Object[] { _EmpFamilyKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _EmpFamilyKey = reader.GetInt64("EmpFamilyKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _SpouseName = reader.GetString("SpouseName");
            _SpouseOccupation = reader.GetInt32("SpouseOccupation");
            _SpouseDOB = reader.GetDateTime("SpouseDOB");
            _FatherInLaw = reader.GetString("FatherInLaw");
            _FatherInLawOccupation = reader.GetInt32("FatherInLawOccupation");
            _MotherInLaw = reader.GetString("MotherInLaw");
            _MotherInLawOccupation = reader.GetInt32("MotherInLawOccupation");
            _Father = reader.GetString("Father");
            _FatherOccupation = reader.GetInt32("FatherOccupation");
            _FatherDOB = reader.GetDateTime("FatherDOB");
            _Mother = reader.GetString("Mother");
            _MotherOccupation = reader.GetInt32("MotherOccupation");
            _MotherDOB = reader.GetDateTime("MotherDOB");
            _Remark = reader.GetString("Remark");
            _MeritalStatus = reader.GetInt32("MeritalStatus");
            SetUnchanged();
        }
        private void SetDataSearchEmp(IDataRecord reader)
        {
            _EmpFamilyKey = reader.GetInt64("EmpFamilyKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _SpouseName = reader.GetString("SpouseName");
            _SpouseOccupation = reader.GetInt32("SpouseOccupation");
            _SpouseDOB = reader.GetDateTime("SpouseDOB");
            _FatherInLaw = reader.GetString("FatherInLaw");
            _FatherInLawOccupation = reader.GetInt32("FatherInLawOccupation");
            _MotherInLaw = reader.GetString("MotherInLaw");
            _MotherInLawOccupation = reader.GetInt32("MotherInLawOccupation");
            _Father = reader.GetString("Father");
            _FatherOccupation = reader.GetInt32("FatherOccupation");
            _FatherDOB = reader.GetDateTime("FatherDOB");
            _Mother = reader.GetString("Mother");
            _MotherOccupation = reader.GetInt32("MotherOccupation");
            _MotherDOB = reader.GetDateTime("MotherDOB");
            _Remark = reader.GetString("Remark");
            _MeritalStatus = reader.GetInt32("MeritalStatus");
            _SpouseOccupationName = reader.GetString("SpouseOccupationName");
            _FatherInLawOccupationName = reader.GetString("FatherInLawOccupationName");
            _MotherInLawOccupationName = reader.GetString("MotherInLawOccupationName");
            _FatherOccupationName = reader.GetString("FatherOccupationName");
            _MotherOccupationName = reader.GetString("MotherOccupationName");
            _MeritalStatusName = reader.GetString("MeritalStatusName");
            SetUnchanged();
        }
        private void SetDataEmp(IDataRecord reader)
        {
            _Father = reader.GetString("Father");
            _SpouseName = reader.GetString("SpouseName");
            _DOB = reader.GetDateTime("DOB");
            _PerAddr = reader.GetString("PerAddr");
        }
        public static CustomList<HRM_EmpFamily> GetAllHRM_EmpFamily()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EmpFamily> HRM_EmpFamilyCollection = new CustomList<HRM_EmpFamily>();
            IDataReader reader = null;
            const String sql = "select * from HRM_EmpFamily";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EmpFamily newHRM_EmpFamily = new HRM_EmpFamily();
                    newHRM_EmpFamily.SetData(reader);
                    HRM_EmpFamilyCollection.Add(newHRM_EmpFamily);
                }
                HRM_EmpFamilyCollection.InsertSpName = "spInsertHRM_EmpFamily";
                HRM_EmpFamilyCollection.UpdateSpName = "spUpdateHRM_EmpFamily";
                HRM_EmpFamilyCollection.DeleteSpName = "spDeleteHRM_EmpFamily";
                return HRM_EmpFamilyCollection;
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

        public static CustomList<HRM_EmpFamily> GetAllEmpFamByEmpKey(string empKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EmpFamily> HRM_EmpFamilyCollection = new CustomList<HRM_EmpFamily>();
            IDataReader reader = null;
            String sql = "select * from HRM_EmpFamily where empkey = " + empKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EmpFamily newHRM_EmpFamily = new HRM_EmpFamily();
                    newHRM_EmpFamily.SetData(reader);
                    HRM_EmpFamilyCollection.Add(newHRM_EmpFamily);
                }
                HRM_EmpFamilyCollection.InsertSpName = "spInsertHRM_EmpFamily";
                HRM_EmpFamilyCollection.UpdateSpName = "spUpdateHRM_EmpFamily";
                HRM_EmpFamilyCollection.DeleteSpName = "spDeleteHRM_EmpFamily";
                return HRM_EmpFamilyCollection;
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
        public static HRM_EmpFamily GetSearchEmpFamilyInfo(long empKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            IDataReader reader = null;
            String sql = "EXEC spGetSearchEmpFamilyInfo '" + empKey + "'";
            try
            {
                HRM_EmpFamily newHRM_EmpFamily = new HRM_EmpFamily();
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    newHRM_EmpFamily.SetDataSearchEmp(reader);
                }
                return newHRM_EmpFamily;
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
        public static HRM_EmpFamily GetEmpGeneralInfo(long empKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            IDataReader reader = null;
            String sql = "EXEC GetGeneralInfo '" + empKey + "'";
            try
            {
                HRM_EmpFamily newHRM_EmpFamily = new HRM_EmpFamily();
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    newHRM_EmpFamily.SetDataEmp(reader);
                }
                return newHRM_EmpFamily;
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