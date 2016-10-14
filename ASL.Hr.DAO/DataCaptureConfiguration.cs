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
    public class DataCaptureConfiguration : BaseItem
    {
        public DataCaptureConfiguration()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _RowID;
        [Browsable(true), DisplayName("RowID")]
        public System.Int32 RowID
        {
            get
            {
                return _RowID;
            }
            set
            {
                if (PropertyChanged(_RowID, value))
                    _RowID = value;
            }
        }

        private System.String _Field;
        [Browsable(true), DisplayName("Field")]
        public System.String Field
        {
            get
            {
                return _Field;
            }
            set
            {
                if (PropertyChanged(_Field, value))
                    _Field = value;
            }
        }

        private System.Boolean _IsCapture;
        [Browsable(true), DisplayName("IsCapture")]
        public System.Boolean IsCapture
        {
            get
            {
                return _IsCapture;
            }
            set
            {
                if (PropertyChanged(_IsCapture, value))
                    _IsCapture = value;
            }
        }

        private System.Int32 _CaptureSeq;
        [Browsable(true), DisplayName("CaptureSeq")]
        public System.Int32 CaptureSeq
        {
            get
            {
                return _CaptureSeq;
            }
            set
            {
                if (PropertyChanged(_CaptureSeq, value))
                    _CaptureSeq = value;
            }
        }

        private System.Boolean _IsRate;
        [Browsable(true), DisplayName("IsRate")]
        public System.Boolean IsRate
        {
            get
            {
                return _IsRate;
            }
            set
            {
                if (PropertyChanged(_IsRate, value))
                    _IsRate = value;
            }
        }

        private System.Int32 _RateSeq;
        [Browsable(true), DisplayName("RateSeq")]
        public System.Int32 RateSeq
        {
            get
            {
                return _RateSeq;
            }
            set
            {
                if (PropertyChanged(_RateSeq, value))
                    _RateSeq = value;
            }
        }

        private System.Boolean _IsFixed;
        [Browsable(true), DisplayName("IsFixed")]
        public System.Boolean IsFixed
        {
            get
            {
                return _IsFixed;
            }
            set
            {
                if (PropertyChanged(_IsFixed, value))
                    _IsFixed = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _Field, _IsCapture, _CaptureSeq, _IsRate, _RateSeq, _IsFixed };
            else if (IsModified)
                parameterValues = new Object[] { _RowID, _Field, _IsCapture, _CaptureSeq, _IsRate, _RateSeq, _IsFixed };
            else if (IsDeleted)
                parameterValues = new Object[] { _Field };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _RowID = reader.GetInt32("RowID");
            _Field = reader.GetString("Field");
            _IsCapture = reader.GetBoolean("IsCapture");
            _CaptureSeq = reader.GetInt32("CaptureSeq");
            _IsRate = reader.GetBoolean("IsRate");
            _RateSeq = reader.GetInt32("RateSeq");
            _IsFixed = reader.GetBoolean("IsFixed");
            SetUnchanged();
        }
        private void SetDataForRate(IDataRecord reader)
        {
            _RowID = reader.GetInt32("RowID");
            _Field = reader.GetString("Field");
            SetUnchanged();
        }
        public static CustomList<DataCaptureConfiguration> GetAllDataCaptureConfiguration()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<DataCaptureConfiguration> DataCaptureConfigurationCollection = new CustomList<DataCaptureConfiguration>();
            IDataReader reader = null;
            const String sql = "select *from DataCaptureConfiguration";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    DataCaptureConfiguration newDataCaptureConfiguration = new DataCaptureConfiguration();
                    newDataCaptureConfiguration.SetData(reader);
                    DataCaptureConfigurationCollection.Add(newDataCaptureConfiguration);
                }
                DataCaptureConfigurationCollection.InsertSpName = "spInsertDataCaptureConfiguration";
                DataCaptureConfigurationCollection.UpdateSpName = "spUpdateDataCaptureConfiguration";
                DataCaptureConfigurationCollection.DeleteSpName = "spDeleteDataCaptureConfiguration";
                return DataCaptureConfigurationCollection;
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
        public static CustomList<DataCaptureConfiguration> GetAllDataCaptureConfiguration1()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<DataCaptureConfiguration> DataCaptureConfigurationCollection = new CustomList<DataCaptureConfiguration>();
            IDataReader reader = null;
            const String sql = "Exec spGetDataCaptureConfiguration";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    DataCaptureConfiguration newDataCaptureConfiguration = new DataCaptureConfiguration();
                    newDataCaptureConfiguration.SetData(reader);
                    DataCaptureConfigurationCollection.Add(newDataCaptureConfiguration);
                }
                return DataCaptureConfigurationCollection;
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
        public static CustomList<DataCaptureConfiguration> GetAllDataCaptureConfigurationForRate()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<DataCaptureConfiguration> DataCaptureConfigurationCollection = new CustomList<DataCaptureConfiguration>();
            IDataReader reader = null;
            const String sql = "Select RowID,Field from DataCaptureConfiguration Where IsRate=1";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    DataCaptureConfiguration newDataCaptureConfiguration = new DataCaptureConfiguration();
                    newDataCaptureConfiguration.SetDataForRate(reader);
                    DataCaptureConfigurationCollection.Add(newDataCaptureConfiguration);
                }
                return DataCaptureConfigurationCollection;
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
        public static CustomList<DataCaptureConfiguration> GetAllDataCaptureConfigurationForDataCapture()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<DataCaptureConfiguration> DataCaptureConfigurationCollection = new CustomList<DataCaptureConfiguration>();
            IDataReader reader = null;
            const String sql = "Select RowID,Field from DataCaptureConfiguration Where IsFixed=1";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    DataCaptureConfiguration newDataCaptureConfiguration = new DataCaptureConfiguration();
                    newDataCaptureConfiguration.SetDataForRate(reader);
                    DataCaptureConfigurationCollection.Add(newDataCaptureConfiguration);
                }
                return DataCaptureConfigurationCollection;
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