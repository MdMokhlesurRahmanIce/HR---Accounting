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
    public class CustomerWisePer : BaseItem
    {
        public CustomerWisePer()
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

        private System.Int32 _FiscalYear;
        [Browsable(true), DisplayName("FiscalYear")]
        public System.Int32 FiscalYear
        {
            get
            {
                return _FiscalYear;
            }
            set
            {
                if (PropertyChanged(_FiscalYear, value))
                    _FiscalYear = value;
            }
        }

        private System.DateTime _FromDate;
        [Browsable(true), DisplayName("FromDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime FromDate
        {
            get
            {
                return _FromDate;
            }
            set
            {
                if (PropertyChanged(_FromDate, value))
                    _FromDate = value;
            }
        }

        private System.DateTime _ToDate;
        [Browsable(true), DisplayName("ToDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime ToDate
        {
            get
            {
                return _ToDate;
            }
            set
            {
                if (PropertyChanged(_ToDate, value))
                    _ToDate = value;
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

        private System.Int32 _CustomerId;
        [Browsable(true), DisplayName("CustomerId")]
        public System.Int32 CustomerId
        {
            get
            {
                return _CustomerId;
            }
            set
            {
                if (PropertyChanged(_CustomerId, value))
                    _CustomerId = value;
            }
        }

        private System.Decimal _Amount;
        [Browsable(true), DisplayName("Amount")]
        public System.Decimal Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                if (PropertyChanged(_Amount, value))
                    _Amount = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _FiscalYear, _FromDate.Value(StaticInfo.DateFormat), _ToDate.Value(StaticInfo.DateFormat), _EmpKey, _CustomerId, _Amount, _Remarks };
            else if (IsModified)
                parameterValues = new Object[] {_RowID, _FiscalYear, _FromDate.Value(StaticInfo.DateFormat), _ToDate.Value(StaticInfo.DateFormat), _EmpKey, _CustomerId, _Amount, _Remarks };
            else if (IsDeleted)
                parameterValues = new Object[] { _RowID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _RowID = reader.GetInt32("RowID");
            _FiscalYear = reader.GetInt32("FiscalYear");
            _FromDate = reader.GetDateTime("FromDate");
            _ToDate = reader.GetDateTime("ToDate");
            _EmpKey = reader.GetInt64("EmpKey");
            _CustomerId = reader.GetInt32("CustomerId");
            _Amount = reader.GetDecimal("Amount");
            _Remarks = reader.GetString("Remarks");
            SetUnchanged();
        }
        public static CustomList<CustomerWisePer> GetAllCustomerWisePer()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<CustomerWisePer> CustomerWisePerCollection = new CustomList<CustomerWisePer>();
            IDataReader reader = null;
            const String sql = "select * from CustomerWisePer";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CustomerWisePer newCustomerWisePer = new CustomerWisePer();
                    newCustomerWisePer.SetData(reader);
                    CustomerWisePerCollection.Add(newCustomerWisePer);
                }
                CustomerWisePerCollection.InsertSpName = "spInsertCustomerWisePer";
                CustomerWisePerCollection.UpdateSpName = "spUpdateCustomerWisePer";
                CustomerWisePerCollection.DeleteSpName = "spDeleteCustomerWisePer";
                return CustomerWisePerCollection;
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
        public static CustomList<CustomerWisePer> GetAllCustomerInfo(string EmpCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<CustomerWisePer> CustomerWisePerCollection = new CustomList<CustomerWisePer>();
            IDataReader reader = null;
            String sql = "select * from CustomerWisePer C Join HRM_Emp E On C.EmpKey=E.EmpKey where E.EmpCode = '"+ EmpCode+"'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CustomerWisePer newCustomerWisePer = new CustomerWisePer();
                    newCustomerWisePer.SetData(reader);
                    CustomerWisePerCollection.Add(newCustomerWisePer);
                }
                CustomerWisePerCollection.InsertSpName = "spInsertCustomerWisePer";
                CustomerWisePerCollection.UpdateSpName = "spUpdateCustomerWisePer";
                CustomerWisePerCollection.DeleteSpName = "spDeleteCustomerWisePer";
                return CustomerWisePerCollection;
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