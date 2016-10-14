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
    public class ProductionDataCapture : BaseItem
    {
        public ProductionDataCapture()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _DataCaptureKey;
        [Browsable(true), DisplayName("DataCaptureKey")]
        public System.Int64 DataCaptureKey
        {
            get
            {
                return _DataCaptureKey;
            }
            set
            {
                if (PropertyChanged(_DataCaptureKey, value))
                    _DataCaptureKey = value;
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

        private System.String _DataCaptureRateRuleID;
        [Browsable(true), DisplayName("DataCaptureRateRuleID")]
        public System.String DataCaptureRateRuleID
        {
            get
            {
                return _DataCaptureRateRuleID;
            }
            set
            {
                if (PropertyChanged(_DataCaptureRateRuleID, value))
                    _DataCaptureRateRuleID = value;
            }
        }

        private System.Int32 _Qty;
        [Browsable(true), DisplayName("Qty")]
        public System.Int32 Qty
        {
            get
            {
                return _Qty;
            }
            set
            {
                if (PropertyChanged(_Qty, value))
                    _Qty = value;
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

        private System.Decimal _Value;
        [Browsable(true), DisplayName("Value")]
        public System.Decimal Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (PropertyChanged(_Value, value))
                    _Value = value;
            }
        }

        private System.DateTime _ProcessDate;
        [Browsable(true), DisplayName("ProcessDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime ProcessDate
        {
            get
            {
                return _ProcessDate;
            }
            set
            {
                if (PropertyChanged(_ProcessDate, value))
                    _ProcessDate = value;
            }
        }

        private System.String _EmpCode;
        [Browsable(true), DisplayName("EmpCode")]
        public System.String EmpCode
        {
            get
            {
                return _EmpCode;
            }
            set
            {
                if (PropertyChanged(_EmpCode, value))
                    _EmpCode = value;
            }
        }

        private System.String _EmpName;
        [Browsable(true), DisplayName("EmpName")]
        public System.String EmpName
        {
            get
            {
                return _EmpName;
            }
            set
            {
                if (PropertyChanged(_EmpName, value))
                    _EmpName = value;
            }
        }

        private System.String _Department;
        [Browsable(true), DisplayName("Department")]
        public System.String Department
        {
            get
            {
                return _Department;
            }
            set
            {
                if (PropertyChanged(_Department, value))
                    _Department = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _DataCaptureRateRuleID, _Qty, _Rate, _ProcessDate.Value(StaticInfo.DateFormat) };
            else if (IsModified)
                parameterValues = new Object[] { _EmpKey, _DataCaptureRateRuleID, _Qty, _Rate, _ProcessDate.Value(StaticInfo.DateFormat) };
            else if (IsDeleted)
                parameterValues = new Object[] { _DataCaptureKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _DataCaptureKey = reader.GetInt64("DataCaptureKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _DataCaptureRateRuleID = reader.GetString("DataCaptureRateRuleID");
            _Qty = reader.GetInt32("Qty");
            _Rate = reader.GetDecimal("Rate");
            _ProcessDate = reader.GetDateTime("ProcessDate");
            SetUnchanged();
        }
        private void SetDataEmp(IDataRecord reader)
        {
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            SetUnchanged();
        }
        public static CustomList<ProductionDataCapture> GetAllProductionDataCapture(string date)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ProductionDataCapture> ProductionDataCaptureCollection = new CustomList<ProductionDataCapture>();
            IDataReader reader = null;
            String sql = "select *from ProductionDataCapture Where ProcessDate='" + date + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ProductionDataCapture newProductionDataCapture = new ProductionDataCapture();
                    newProductionDataCapture.SetData(reader);
                    ProductionDataCaptureCollection.Add(newProductionDataCapture);
                }
                ProductionDataCaptureCollection.InsertSpName = "spInsertProductionDataCapture";
                ProductionDataCaptureCollection.UpdateSpName = "spUpdateProductionDataCapture";
                ProductionDataCaptureCollection.DeleteSpName = "spDeleteProductionDataCapture";
                return ProductionDataCaptureCollection;
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
        public static CustomList<ProductionDataCapture> GetAllProductionDataCaptureEmp(string empCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ProductionDataCapture> ProductionDataCaptureCollection = new CustomList<ProductionDataCapture>();
            IDataReader reader = null;
            String sql = "select EmpCode,EmpKey,EmpName from HRM_Emp Where EmpCode='" + empCode + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ProductionDataCapture newProductionDataCapture = new ProductionDataCapture();
                    newProductionDataCapture.SetDataEmp(reader);
                    ProductionDataCaptureCollection.Add(newProductionDataCapture);
                }
                return ProductionDataCaptureCollection;
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