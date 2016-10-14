using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using System.Text;
using System.Web;


namespace ASL.Hr.DAO
{
    [Serializable]
    public class Settings : BaseItem
    {
        public Settings()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _SettingsID;
        [Browsable(true), DisplayName("SettingsID")]
        public System.Int32 SettingsID
        {
            get
            {
                return _SettingsID;
            }
            set
            {
                if (PropertyChanged(_SettingsID, value))
                    _SettingsID = value;
            }
        }

        private System.String _SettingsName;
        [Browsable(true), DisplayName("SettingsName")]
        public System.String SettingsName
        {
            get
            {
                return _SettingsName;
            }
            set
            {
                if (PropertyChanged(_SettingsName, value))
                    _SettingsName = value;
            }
        }

        private System.String _CharType;
        [Browsable(true), DisplayName("CharType")]
        public System.String CharType
        {
            get
            {
                return _CharType;
            }
            set
            {
                if (PropertyChanged(_CharType, value))
                    _CharType = value;
            }
        }

        private System.Decimal _NumType;
        [Browsable(true), DisplayName("NumType")]
        public System.Decimal NumType
        {
            get
            {
                return _NumType;
            }
            set
            {
                if (PropertyChanged(_NumType, value))
                    _NumType = value;
            }
        }

        private System.String _DATA1;
        [Browsable(true), DisplayName("DATA1")]
        public System.String DATA1
        {
            get
            {
                return _DATA1;
            }
            set
            {
                if (PropertyChanged(_DATA1, value))
                    _DATA1 = value;
            }
        }

        private System.String _DATA2;
        [Browsable(true), DisplayName("DATA2")]
        public System.String DATA2
        {
            get
            {
                return _DATA2;
            }
            set
            {
                if (PropertyChanged(_DATA2, value))
                    _DATA2 = value;
            }
        }

        private System.String _DATA3;
        [Browsable(true), DisplayName("DATA3")]
        public System.String DATA3
        {
            get
            {
                return _DATA3;
            }
            set
            {
                if (PropertyChanged(_DATA3, value))
                    _DATA3 = value;
            }
        }

        private System.String _DATA4;
        [Browsable(true), DisplayName("DATA4")]
        public System.String DATA4
        {
            get
            {
                return _DATA4;
            }
            set
            {
                if (PropertyChanged(_DATA4, value))
                    _DATA4 = value;
            }
        }

        private System.String _DATA5;
        [Browsable(true), DisplayName("DATA5")]
        public System.String DATA5
        {
            get
            {
                return _DATA5;
            }
            set
            {
                if (PropertyChanged(_DATA5, value))
                    _DATA5 = value;
            }
        }

        private System.String _DATA6;
        [Browsable(true), DisplayName("DATA6")]
        public System.String DATA6
        {
            get
            {
                return _DATA6;
            }
            set
            {
                if (PropertyChanged(_DATA6, value))
                    _DATA6 = value;
            }
        }

        private System.String _DATA7;
        [Browsable(true), DisplayName("DATA7")]
        public System.String DATA7
        {
            get
            {
                return _DATA7;
            }
            set
            {
                if (PropertyChanged(_DATA7, value))
                    _DATA7 = value;
            }
        }

        private System.String _DATA8;
        [Browsable(true), DisplayName("DATA8")]
        public System.String DATA8
        {
            get
            {
                return _DATA8;
            }
            set
            {
                if (PropertyChanged(_DATA8, value))
                    _DATA8 = value;
            }
        }

        private System.String _DATA9;
        [Browsable(true), DisplayName("DATA9")]
        public System.String DATA9
        {
            get
            {
                return _DATA9;
            }
            set
            {
                if (PropertyChanged(_DATA9, value))
                    _DATA9 = value;
            }
        }

        private System.String _DATA10;
        [Browsable(true), DisplayName("DATA10")]
        public System.String DATA10
        {
            get
            {
                return _DATA10;
            }
            set
            {
                if (PropertyChanged(_DATA10, value))
                    _DATA10 = value;
            }
        }

        private System.String _Remarks;
        [Browsable(true), DisplayName("Remarks")]
        public System.String Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                if (PropertyChanged(_Remarks, value))
                    _Remarks = value;
            }
        }

        private System.Int32 _SequenceNo;
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

        private System.DateTime _AddedDate;
        [Browsable(true), DisplayName("AddedDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime AddedDate
        {
            get
            {
                return _AddedDate;
            }
            set
            {
                if (PropertyChanged(_AddedDate, value))
                    _AddedDate = value;
            }
        }

        private System.DateTime _UpdatedDate;
        [Browsable(true), DisplayName("UpdatedDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime UpdatedDate
        {
            get
            {
                return _UpdatedDate;
            }
            set
            {
                if (PropertyChanged(_UpdatedDate, value))
                    _UpdatedDate = value;
            }
        }

        private System.String _AddedBy;
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

        private System.String _UpdatedBy;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _SettingsName, _CharType, _NumType, _DATA1, _DATA2, _DATA3, _DATA4, _DATA5, _DATA6, _DATA7, _DATA8, _DATA9, _DATA10, _Remarks, _SequenceNo, _AddedDate.Value(StaticInfo.DateFormat), _UpdatedDate.Value(StaticInfo.DateFormat), _AddedBy, _UpdatedBy };
            else if (IsModified)
                parameterValues = new Object[] { _SettingsID, _SettingsName, _CharType, _NumType, _DATA1, _DATA2, _DATA3, _DATA4, _DATA5, _DATA6, _DATA7, _DATA8, _DATA9, _DATA10, _Remarks, _SequenceNo, _AddedDate.Value(StaticInfo.DateFormat), _UpdatedDate.Value(StaticInfo.DateFormat), _AddedBy, _UpdatedBy };
            else if (IsDeleted)
                parameterValues = new Object[] { _SettingsID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _SettingsID = reader.GetInt32("SettingsID");
            _SettingsName = reader.GetString("SettingsName");
            _CharType = reader.GetString("CharType");
            _NumType = reader.GetDecimal("NumType");
            _DATA1 = reader.GetString("DATA1");
            _DATA2 = reader.GetString("DATA2");
            _DATA3 = reader.GetString("DATA3");
            _DATA4 = reader.GetString("DATA4");
            _DATA5 = reader.GetString("DATA5");
            _DATA6 = reader.GetString("DATA6");
            _DATA7 = reader.GetString("DATA7");
            _DATA8 = reader.GetString("DATA8");
            _DATA9 = reader.GetString("DATA9");
            _DATA10 = reader.GetString("DATA10");
            _Remarks = reader.GetString("Remarks");
            _SequenceNo = reader.GetInt32("SequenceNo");
            _AddedDate = reader.GetDateTime("AddedDate");
            _UpdatedDate = reader.GetDateTime("UpdatedDate");
            _AddedBy = reader.GetString("AddedBy");
            _UpdatedBy = reader.GetString("UpdatedBy");
            SetUnchanged();
        }
        private void SetDataSettingsName(IDataRecord reader)
        {

            _SettingsName = reader.GetString("SettingsName");
            SetUnchanged();
        }
        private void SetDataCharType(IDataRecord reader)
        {

            _CharType = reader.GetString("CharType");
            SetUnchanged();
        }
        private void SetDataNumType(IDataRecord reader)
        {

            _NumType = reader.GetDecimal("NumType");
            SetUnchanged();
        }
        private void SetDataData1(IDataRecord reader)
        {

            _NumType = reader.GetDecimal("NumType");
            _DATA1 = reader.GetString("DATA1");
            SetUnchanged();
        }
        public static CustomList<Settings> GetAllSettings()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Settings> SettingsCollection = new CustomList<Settings>();
            IDataReader reader = null;
            const String sql = "select * from Settings";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Settings newSettings = new Settings();
                    newSettings.SetData(reader);
                    SettingsCollection.Add(newSettings);
                }
                SettingsCollection.InsertSpName = "spInsertSettings";
                SettingsCollection.UpdateSpName = "spUpdateSettings";
                SettingsCollection.DeleteSpName = "spDeleteSettings";
                return SettingsCollection;
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
        public static CustomList<Settings> GetAllSettingsList()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Settings> SettingsCollection = new CustomList<Settings>();
            IDataReader reader = null;
            String sql = "select Distinct  SettingsName From Settings";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Settings newSettings = new Settings();
                    newSettings.SetDataSettingsName(reader);
                    SettingsCollection.Add(newSettings);
                }
                SettingsCollection.InsertSpName = "spInsertSettings";
                SettingsCollection.UpdateSpName = "spUpdateSettings";
                SettingsCollection.DeleteSpName = "spDeleteSettings";
                return SettingsCollection;
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
         public static CustomList<Settings> GetAllSalaryYear()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Settings> SettingsCollection = new CustomList<Settings>();
            IDataReader reader = null;
            String sql = "select Distinct CharType from Settings where SettingsName='SalaryYearMonth'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Settings newSettings = new Settings();
                    newSettings.SetDataCharType(reader);
                    SettingsCollection.Add(newSettings);
                }
                SettingsCollection.InsertSpName = "spInsertSettings";
                SettingsCollection.UpdateSpName = "spUpdateSettings";
                SettingsCollection.DeleteSpName = "spDeleteSettings";
                return SettingsCollection;
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

        public static CustomList<Settings> GetAllSalaryMonths( string Year)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Settings> SettingsCollection = new CustomList<Settings>();
            IDataReader reader = null;
            String sql = "getMonthDetails '" + Year + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Settings newSettings = new Settings();
                    newSettings.SetDataData1(reader);
                    SettingsCollection.Add(newSettings);
                }
                SettingsCollection.InsertSpName = "spInsertSettings";
                SettingsCollection.UpdateSpName = "spUpdateSettings";
                SettingsCollection.DeleteSpName = "spDeleteSettings";
                return SettingsCollection;
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
        public static CustomList<Settings> GetFromDateToDate(string Year, string MonthNo)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Settings> SettingsCollection = new CustomList<Settings>();
            IDataReader reader = null;
            String sql = " Select * From Settings where SettingsName='SalaryYearMonth' and CharType = '" + Year + "' and NumType='" + MonthNo + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Settings newSettings = new Settings();
                    newSettings.SetData(reader);
                    SettingsCollection.Add(newSettings);
                }
                SettingsCollection.InsertSpName = "spInsertSettings";
                SettingsCollection.UpdateSpName = "spUpdateSettings";
                SettingsCollection.DeleteSpName = "spDeleteSettings";
                return SettingsCollection;
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
        public static CustomList<Settings> GetAllSettingsInfo()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Settings> SettingsCollection = new CustomList<Settings>();
            IDataReader reader = null;
            String sql = "select * From Settings";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Settings newSettings = new Settings();
                    newSettings.SetData(reader);
                    SettingsCollection.Add(newSettings);
                }
                SettingsCollection.InsertSpName = "spInsertSettings";
                SettingsCollection.UpdateSpName = "spUpdateSettings";
                SettingsCollection.DeleteSpName = "spDeleteSettings";
                return SettingsCollection;
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
        public static CustomList<Settings> GetSelectedSettingsInfo(string SettingsName)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Settings> SettingsCollection = new CustomList<Settings>();
            IDataReader reader = null;
            String sql = "select * From Settings where SettingsName='" + SettingsName + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Settings newSettings = new Settings();
                    newSettings.SetData(reader);
                    SettingsCollection.Add(newSettings);
                }
                SettingsCollection.InsertSpName = "spInsertSettings";
                SettingsCollection.UpdateSpName = "spUpdateSettings";
                SettingsCollection.DeleteSpName = "spDeleteSettings";
                return SettingsCollection;
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