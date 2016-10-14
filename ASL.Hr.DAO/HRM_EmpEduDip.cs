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
    public class HRM_EmpEduDip : BaseItem
    {
        public HRM_EmpEduDip()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _EmpEduDipKey;
        [Browsable(true), DisplayName("EmpEduDipKey")]
        public System.Int64 EmpEduDipKey
        {
            get
            {
                return _EmpEduDipKey;
            }
            set
            {
                if (PropertyChanged(_EmpEduDipKey, value))
                    _EmpEduDipKey = value;
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

        private System.String _DipName;
        [Browsable(true), DisplayName("DipName")]
        public System.String DipName
        {
            get
            {
                return _DipName;
            }
            set
            {
                if (PropertyChanged(_DipName, value))
                    _DipName = value;
            }
        }

        private System.Int32 _Duration;
        [Browsable(true), DisplayName("Duration")]
        public System.Int32 Duration
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

        private System.String _Description;
        [Browsable(true), DisplayName("Description")]
        public System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (PropertyChanged(_Description, value))
                    _Description = value;
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
        private System.DateTime _From;
        [Browsable(true), DisplayName("From"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime From
        {
            get
            {
                return _From;
            }
            set
            {
                if (PropertyChanged(_From, value))
                    _From = value;
            }
        }

        private System.DateTime _To;
        [Browsable(true), DisplayName("To"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime To
        {
            get
            {
                return _To;
            }
            set
            {
                if (PropertyChanged(_To, value))
                    _To = value;
            }
        }
        private System.String _DipOrTran;
        [Browsable(true), DisplayName("DipOrTran")]
        public System.String DipOrTran
        {
            get
            {
                return _DipOrTran;
            }
            set
            {
                if (PropertyChanged(_DipOrTran, value))
                    _DipOrTran = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _Seq, _DipName, _Duration, _Description, _Result, _Institute, _CountryKey, _AchievementComm, _From.Value(StaticInfo.DateFormat), _To.Value(StaticInfo.DateFormat), _DipOrTran };
            else if (IsModified)
                parameterValues = new Object[] { _EmpEduDipKey, _EmpKey, _Seq, _DipName, _Duration, _Description, _Result, _Institute, _CountryKey, _AchievementComm, _From.Value(StaticInfo.DateFormat), _To.Value(StaticInfo.DateFormat), _DipOrTran };
            else if (IsDeleted)
                parameterValues = new Object[] { _EmpEduDipKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _EmpEduDipKey = reader.GetInt64("EmpEduDipKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _Seq = reader.GetInt32("Seq");
            _DipName = reader.GetString("DipName");
            _Duration = reader.GetInt32("Duration");
            _Description = reader.GetString("Description");
            _Result = reader.GetString("Result");
            _Institute = reader.GetString("Institute");
            _CountryKey = reader.GetInt32("CountryKey");
            _AchievementComm = reader.GetString("AchievementComm");
            _From = reader.GetDateTime("From");
            _To = reader.GetDateTime("To");
            _DipOrTran = reader.GetString("DipOrTran");
            SetUnchanged();
        }
        public static CustomList<HRM_EmpEduDip> GetAllHRM_EmpEduDip()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EmpEduDip> HRM_EmpEduDipCollection = new CustomList<HRM_EmpEduDip>();
            IDataReader reader = null;
            const String sql = "select * from hrm_empedudip";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EmpEduDip newHRM_EmpEduDip = new HRM_EmpEduDip();
                    newHRM_EmpEduDip.SetData(reader);
                    HRM_EmpEduDipCollection.Add(newHRM_EmpEduDip);
                }
                HRM_EmpEduDipCollection.InsertSpName = "spInsertHRM_EmpEduDip";
                HRM_EmpEduDipCollection.UpdateSpName = "spUpdateHRM_EmpEduDip";
                HRM_EmpEduDipCollection.DeleteSpName = "spDeleteHRM_EmpEduDip";
                return HRM_EmpEduDipCollection;
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

        public static CustomList<HRM_EmpEduDip> GetAllDipEduByEmpKey(string EmpKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EmpEduDip> HRM_EmpEduDipCollection = new CustomList<HRM_EmpEduDip>();
            IDataReader reader = null;
            String sql = "select * from hrm_empedudip where empkey = " + EmpKey ;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EmpEduDip newHRM_EmpEduDip = new HRM_EmpEduDip();
                    newHRM_EmpEduDip.SetData(reader);
                    HRM_EmpEduDipCollection.Add(newHRM_EmpEduDip);
                }
                HRM_EmpEduDipCollection.InsertSpName = "spInsertHRM_EmpEduDip";
                HRM_EmpEduDipCollection.UpdateSpName = "spUpdateHRM_EmpEduDip";
                HRM_EmpEduDipCollection.DeleteSpName = "spDeleteHRM_EmpEduDip";
                return HRM_EmpEduDipCollection;
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
        public static CustomList<HRM_EmpEduDip> GetAllDipEduByEmpKey(string EmpKey, string type)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_EmpEduDip> HRM_EmpEduDipCollection = new CustomList<HRM_EmpEduDip>();
            IDataReader reader = null;
            String sql = "select * from hrm_empedudip where empkey = " + EmpKey + " and DipOrTran='" + type + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_EmpEduDip newHRM_EmpEduDip = new HRM_EmpEduDip();
                    newHRM_EmpEduDip.SetData(reader);
                    HRM_EmpEduDipCollection.Add(newHRM_EmpEduDip);
                }
                HRM_EmpEduDipCollection.InsertSpName = "spInsertHRM_EmpEduDip";
                HRM_EmpEduDipCollection.UpdateSpName = "spUpdateHRM_EmpEduDip";
                HRM_EmpEduDipCollection.DeleteSpName = "spDeleteHRM_EmpEduDip";
                return HRM_EmpEduDipCollection;
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