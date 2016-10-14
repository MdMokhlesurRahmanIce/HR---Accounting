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
    public class HRM_EmpEdu : BaseItem
    {
        public HRM_EmpEdu()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _EmpEduKey;
        [Browsable(true), DisplayName("EmpEduKey")]
        public System.Int64 EmpEduKey
        {
            get
            {
                return _EmpEduKey;
            }
            set
            {
                if (PropertyChanged(_EmpEduKey, value))
                    _EmpEduKey = value;
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

        private System.Int32 _Seq;
        [Browsable(true), DisplayName("Seq")]
        public System.Int32 Seq
        {
            get
            {
                return _Seq;
            }
            set
            {
                if (PropertyChanged(_Seq, value))
                    _Seq = value;
            }
        }

        private System.Int32 _ExamKey;
        [Browsable(true), DisplayName("ExamKey")]
        public System.Int32 ExamKey
        {
            get
            {
                return _ExamKey;
            }
            set
            {
                if (PropertyChanged(_ExamKey, value))
                    _ExamKey = value;
            }
        }

        private System.Int32 _GroupKey;
        [Browsable(true), DisplayName("GroupKey")]
        public System.Int32 GroupKey
        {
            get
            {
                return _GroupKey;
            }
            set
            {
                if (PropertyChanged(_GroupKey, value))
                    _GroupKey = value;
            }
        }

        private System.Decimal _Duration;
        [Browsable(true), DisplayName("Duration")]
        public System.Decimal Duration
        {
            get
            {
                return _Duration;
            }
            set
            {
                if (PropertyChanged(_Duration, value))
                    _Duration = value;
            }
        }

        private System.Int32 _PassingYear;
        [Browsable(true), DisplayName("PassingYear")]
        public System.Int32 PassingYear
        {
            get
            {
                return _PassingYear;
            }
            set
            {
                if (PropertyChanged(_PassingYear, value))
                    _PassingYear = value;
            }
        }

        private System.String _Result;
        [Browsable(true), DisplayName("Result")]
        public System.String Result
        {
            get
            {
                return _Result;
            }
            set
            {
                if (PropertyChanged(_Result, value))
                    _Result = value;
            }
        }

        private System.String _Institute;
        [Browsable(true), DisplayName("Institute")]
        public System.String Institute
        {
            get
            {
                return _Institute;
            }
            set
            {
                if (PropertyChanged(_Institute, value))
                    _Institute = value;
            }
        }

        private System.String _BoardUniversity;
        [Browsable(true), DisplayName("BoardUniversity")]
        public System.String BoardUniversity
        {
            get
            {
                return _BoardUniversity;
            }
            set
            {
                if (PropertyChanged(_BoardUniversity, value))
                    _BoardUniversity = value;
            }
        }

        private System.Int32? _CountryKey;
        [Browsable(true), DisplayName("CountryKey")]
        public System.Int32? CountryKey
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

        private System.String _AchievementComm;
        [Browsable(true), DisplayName("AchievementComm")]
        public System.String AchievementComm
        {
            get
            {
                return _AchievementComm;
            }
            set
            {
                if (PropertyChanged(_AchievementComm, value))
                    _AchievementComm = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _Seq, _ExamKey, _GroupKey, _Duration, _PassingYear, _Result, _Institute, _BoardUniversity, _CountryKey, _AchievementComm };
            else if (IsModified)
                parameterValues = new Object[] { _EmpEduKey, _EmpKey, _Seq, _ExamKey, _GroupKey, _Duration, _PassingYear, _Result, _Institute, _BoardUniversity, _CountryKey, _AchievementComm };
            else if (IsDeleted)
                parameterValues = new Object[] { _EmpEduKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _EmpEduKey = reader.GetInt64("EmpEduKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _Seq = reader.GetInt32("Seq");
            _ExamKey = reader.GetInt32("ExamKey");
            _GroupKey = reader.GetInt32("GroupKey");
            _Duration = reader.GetDecimal("Duration");
            _PassingYear = reader.GetInt32("PassingYear");
            _Result = reader.GetString("Result");
            _Institute = reader.GetString("Institute");
            _BoardUniversity = reader.GetString("BoardUniversity");
            _CountryKey = reader.GetInt32("CountryKey");
            _AchievementComm = reader.GetString("AchievementComm");
            SetUnchanged();
        }
        public static CustomList<HRM_EmpEdu> GetAllHRM_EmpEdu()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EmpEdu> HRM_EmpEduCollection = new CustomList<HRM_EmpEdu>();
            IDataReader reader = null;
            const String sql = "select * from hrm_empedu";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EmpEdu newHRM_EmpEdu = new HRM_EmpEdu();
                    newHRM_EmpEdu.SetData(reader);
                    HRM_EmpEduCollection.Add(newHRM_EmpEdu);
                }
                HRM_EmpEduCollection.InsertSpName = "spInsertHRM_EmpEdu";
                HRM_EmpEduCollection.UpdateSpName = "spUpdateHRM_EmpEdu";
                HRM_EmpEduCollection.DeleteSpName = "spDeleteHRM_EmpEdu";
                return HRM_EmpEduCollection;
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

        public static CustomList<HRM_EmpEdu> GetAllEmpEduByEmpKey(string EmpKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EmpEdu> HRM_EmpEduCollection = new CustomList<HRM_EmpEdu>();
            IDataReader reader = null;
            String sql = "select * from hrm_empedu where empkey = " + EmpKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EmpEdu newHRM_EmpEdu = new HRM_EmpEdu();
                    newHRM_EmpEdu.SetData(reader);
                    HRM_EmpEduCollection.Add(newHRM_EmpEdu);
                }
                HRM_EmpEduCollection.InsertSpName = "spInsertHRM_EmpEdu";
                HRM_EmpEduCollection.UpdateSpName = "spUpdateHRM_EmpEdu";
                HRM_EmpEduCollection.DeleteSpName = "spDeleteHRM_EmpEdu";
                return HRM_EmpEduCollection;
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