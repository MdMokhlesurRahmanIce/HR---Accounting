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
    public class DataCaptureRate : BaseItem
    {
        public DataCaptureRate()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _RateKey;
        [Browsable(true), DisplayName("RateKey")]
        public System.Int32 RateKey
        {
            get
            {
                return _RateKey;
            }
            set
            {
                if (PropertyChanged(_RateKey, value))
                    _RateKey = value;
            }
        }

        private System.Int32 _Field;
        [Browsable(true), DisplayName("Field")]
        public System.Int32 Field
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

        private System.Decimal _Rate;
        [Browsable(true), DisplayName("Rate")]
        public System.Decimal Rate
        {
            get
            {
                return _Rate;
            }
            set
            {
                if (PropertyChanged(_Rate, value))
                    _Rate = value;
            }
        }

        private System.String _DataCapRateRuleID;
        [Browsable(true), DisplayName("DataCapRateRuleID")]
        public System.String DataCapRateRuleID
        {
            get
            {
                return _DataCapRateRuleID;
            }
            set
            {
                if (PropertyChanged(_DataCapRateRuleID, value))
                    _DataCapRateRuleID = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _Field, _Rate, _DataCapRateRuleID };
            else if (IsModified)
                parameterValues = new Object[] { _RateKey, _Field, _Rate, _DataCapRateRuleID };
            else if (IsDeleted)
                parameterValues = new Object[] { _RateKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _RateKey = reader.GetInt32("RateKey");
            _Field = reader.GetInt32("Field");
            _Rate = reader.GetDecimal("Rate");
            _DataCapRateRuleID = reader.GetString("DataCapRateRuleID");
            SetUnchanged();
        }
        private void SetDataRateRule(IDataRecord reader)
        {
            _DataCapRateRuleID = reader.GetString("DataCapRateRuleID");
            _Rate = reader.GetDecimal("Rate");
            SetUnchanged();
        }
        public static CustomList<DataCaptureRate> GetAllRate()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<DataCaptureRate> RateCollection = new CustomList<DataCaptureRate>();
            IDataReader reader = null;
            const String sql = "select *from DataCaptureRate";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    DataCaptureRate newRate = new DataCaptureRate();
                    newRate.SetData(reader);
                    RateCollection.Add(newRate);
                }
                RateCollection.InsertSpName = "spInsertDataCaptureRate";
                RateCollection.UpdateSpName = "spUpdateDataCaptureRate";
                RateCollection.DeleteSpName = "spDeleteDataCaptureRate";
                return RateCollection;
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
        public static CustomList<DataCaptureRate> GetAllDataCapRateRuleID()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<DataCaptureRate> RateCollection = new CustomList<DataCaptureRate>();
            IDataReader reader = null;
            const String sql = "select Distinct DataCapRateRuleID,Rate from DataCaptureRate";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    DataCaptureRate newRate = new DataCaptureRate();
                    newRate.SetDataRateRule(reader);
                    RateCollection.Add(newRate);
                }
                return RateCollection;
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
