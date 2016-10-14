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
    public class HRM_EmpFamDet : BaseItem
    {
        public HRM_EmpFamDet()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _EmpFamilyDetKey;
        [Browsable(true), DisplayName("EmpFamilyDetKey")]
        public System.Int64 EmpFamilyDetKey
        {
            get
            {
                return _EmpFamilyDetKey;
            }
            set
            {
                if (PropertyChanged(_EmpFamilyDetKey, value))
                    _EmpFamilyDetKey = value;
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

        private System.String _ChildName;
        [Browsable(true), DisplayName("ChildName")]
        public System.String ChildName
        {
            get
            {
                return _ChildName;
            }
            set
            {
                if (PropertyChanged(_ChildName, value))
                    _ChildName = value;
            }
        }

        private System.String _Relation;
        [Browsable(true), DisplayName("Relation")]
        public System.String Relation
        {
            get
            {
                return _Relation;
            }
            set
            {
                if (PropertyChanged(_Relation, value))
                    _Relation = value;
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

        private System.String _BloodGroup;
        [Browsable(true), DisplayName("BloodGroup")]
        public System.String BloodGroup
        {
            get
            {
                return _BloodGroup;
            }
            set
            {
                if (PropertyChanged(_BloodGroup, value))
                    _BloodGroup = value;
            }
        }

        private System.String _Occupation;
        [Browsable(true), DisplayName("Occupation")]
        public System.String Occupation
        {
            get
            {
                return _Occupation;
            }
            set
            {
                if (PropertyChanged(_Occupation, value))
                    _Occupation = value;
            }
        }

        private System.Boolean _IsInsurance;
        [Browsable(true), DisplayName("IsInsurance")]
        public System.Boolean IsInsurance
        {
            get
            {
                return _IsInsurance;
            }
            set
            {
                if (PropertyChanged(_IsInsurance, value))
                    _IsInsurance = value;
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
        private System.String _Age;
        [Browsable(true), DisplayName("Age")]
        public System.String Age
        {
            get
            {
                return _Age;
            }
            set
            {
                if (PropertyChanged(_Age, value))
                    _Age = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _ChildName, _Relation, _DOB.Value(StaticInfo.DateFormat), _BloodGroup, _Occupation, _IsInsurance, _Remark };
            else if (IsModified)
                parameterValues = new Object[] { _EmpKey, _ChildName, _Relation, _DOB.Value(StaticInfo.DateFormat), _BloodGroup, _Occupation, _IsInsurance, _Remark };
            else if (IsDeleted)
                parameterValues = new Object[] { _EmpFamilyDetKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _EmpFamilyDetKey = reader.GetInt64("EmpFamilyDetKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _ChildName = reader.GetString("ChildName");
            _Relation = reader.GetString("Relation");
            _DOB = reader.GetDateTime("DOB");
            _BloodGroup = reader.GetString("BloodGroup");
            _Occupation = reader.GetString("Occupation");
            _IsInsurance = reader.GetBoolean("IsInsurance");
            _Remark = reader.GetString("Remark");
            SetUnchanged();
        }
        public static CustomList<HRM_EmpFamDet> GetAllHRM_EmpFamDet()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EmpFamDet> HRM_EmpFamDetCollection = new CustomList<HRM_EmpFamDet>();
            IDataReader reader = null;
            const String sql = "select * from HRM_EmpFamDet";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EmpFamDet newHRM_EmpFamDet = new HRM_EmpFamDet();
                    newHRM_EmpFamDet.SetData(reader);
                    HRM_EmpFamDetCollection.Add(newHRM_EmpFamDet);
                }
                HRM_EmpFamDetCollection.InsertSpName = "spInsertHRM_EmpFamDet";
                HRM_EmpFamDetCollection.UpdateSpName = "spUpdateHRM_EmpFamDet";
                HRM_EmpFamDetCollection.DeleteSpName = "spDeleteHRM_EmpFamDet";
                return HRM_EmpFamDetCollection;
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
        public static CustomList<HRM_EmpFamDet> GetAllHRM_EmpFamDetByFamKey(long empKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EmpFamDet> HRM_EmpFamDetCollection = new CustomList<HRM_EmpFamDet>();
            IDataReader reader = null;
            String sql = "exec spGetFamilyDetails " + empKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EmpFamDet newHRM_EmpFamDet = new HRM_EmpFamDet();
                    newHRM_EmpFamDet.SetData(reader);
                    HRM_EmpFamDetCollection.Add(newHRM_EmpFamDet);
                }
                HRM_EmpFamDetCollection.InsertSpName = "spInsertHRM_EmpFamDet";
                HRM_EmpFamDetCollection.UpdateSpName = "spUpdateHRM_EmpFamDet";
                HRM_EmpFamDetCollection.DeleteSpName = "spDeleteHRM_EmpFamDet";
                return HRM_EmpFamDetCollection;
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
