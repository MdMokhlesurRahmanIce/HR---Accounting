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
    public class SalaryProcess : BaseItem
    {
        public SalaryProcess()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _RowId;
        [Browsable(true), DisplayName("RowId")]
        public System.Int64 RowId
        {
            get
            {
                return _RowId;
            }
            set
            {
                if (PropertyChanged(_RowId, value))
                    _RowId = value;
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

        private System.Int32 _YearNo;
        [Browsable(true), DisplayName("YearNo")]
        public System.Int32 YearNo
        {
            get
            {
                return _YearNo;
            }
            set
            {
                if (PropertyChanged(_YearNo, value))
                    _YearNo = value;
            }
        }

        private System.Int32 _MonthNo;
        [Browsable(true), DisplayName("MonthNo")]
        public System.Int32 MonthNo
        {
            get
            {
                return _MonthNo;
            }
            set
            {
                if (PropertyChanged(_MonthNo, value))
                    _MonthNo = value;
            }
        }

        private System.String _FromDate;
        [Browsable(true), DisplayName("FromDate")]
        public System.String FromDate
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

        private System.String _Todate;
        [Browsable(true), DisplayName("Todate")]
        public System.String Todate
        {
            get
            {
                return _Todate;
            }
            set
            {
                if (PropertyChanged(_Todate, value))
                    _Todate = value;
            }
        }

        private System.DateTime _ProcessingDate;
        [Browsable(true), DisplayName("ProcessingDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime ProcessingDate
        {
            get
            {
                return _ProcessingDate;
            }
            set
            {
                if (PropertyChanged(_ProcessingDate, value))
                    _ProcessingDate = value;
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

        private System.Int32 _SalaryHeadKey;
        [Browsable(true), DisplayName("SalaryHeadKey")]
        public System.Int32 SalaryHeadKey
        {
            get
            {
                return _SalaryHeadKey;
            }
            set
            {
                if (PropertyChanged(_SalaryHeadKey, value))
                    _SalaryHeadKey = value;
            }
        }

        private System.String _HeadName;
        [Browsable(true), DisplayName("HeadName")]
        public System.String HeadName
        {
            get
            {
                return _HeadName;
            }
            set
            {
                if (PropertyChanged(_HeadName, value))
                    _HeadName = value;
            }
        }

        private System.Decimal _OrgAmount;
        [Browsable(true), DisplayName("OrgAmount")]
        public System.Decimal OrgAmount
        {
            get
            {
                return _OrgAmount;
            }
            set
            {
                if (PropertyChanged(_OrgAmount, value))
                    _OrgAmount = value;
            }
        }

        private System.String _CurrencyName;
        [Browsable(true), DisplayName("CurrencyName")]
        public System.String CurrencyName
        {
            get
            {
                return _CurrencyName;
            }
            set
            {
                if (PropertyChanged(_CurrencyName, value))
                    _CurrencyName = value;
            }
        }

        private System.Decimal _CalculatedAmount;
        [Browsable(true), DisplayName("CalculatedAmount")]
        public System.Decimal CalculatedAmount
        {
            get
            {
                return _CalculatedAmount;
            }
            set
            {
                if (PropertyChanged(_CalculatedAmount, value))
                    _CalculatedAmount = value;
            }
        }

        private System.String _PayCurrencyName;
        [Browsable(true), DisplayName("PayCurrencyName")]
        public System.String PayCurrencyName
        {
            get
            {
                return _PayCurrencyName;
            }
            set
            {
                if (PropertyChanged(_PayCurrencyName, value))
                    _PayCurrencyName = value;
            }
        }

        private System.Decimal _PayCurrencyValue;
        [Browsable(true), DisplayName("PayCurrencyValue")]
        public System.Decimal PayCurrencyValue
        {
            get
            {
                return _PayCurrencyValue;
            }
            set
            {
                if (PropertyChanged(_PayCurrencyValue, value))
                    _PayCurrencyValue = value;
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

        private System.Int32 _ApprovedBy;
        [Browsable(true), DisplayName("ApprovedBy")]
        public System.Int32 ApprovedBy
        {
            get
            {
                return _ApprovedBy;
            }
            set
            {
                if (PropertyChanged(_ApprovedBy, value))
                    _ApprovedBy = value;
            }
        }

        private System.Int32 _ApproveDate;
        [Browsable(true), DisplayName("ApproveDate")]
        public System.Int32 ApproveDate
        {
            get
            {
                return _ApproveDate;
            }
            set
            {
                if (PropertyChanged(_ApproveDate, value))
                    _ApproveDate = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _YearNo, _MonthNo, _FromDate, _Todate, _ProcessingDate.Value(StaticInfo.DateFormat), _EmpKey, _SalaryHeadKey, _HeadName, _OrgAmount, _CurrencyName, _CalculatedAmount, _PayCurrencyName, _PayCurrencyValue, _AddedBy, _AddedDate.Value(StaticInfo.DateFormat), _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat), _ApprovedBy, _ApproveDate };
            else if (IsModified)
                parameterValues = new Object[] { _YearNo, _MonthNo, _FromDate, _Todate, _ProcessingDate.Value(StaticInfo.DateFormat), _EmpKey, _SalaryHeadKey, _HeadName, _OrgAmount, _CurrencyName, _CalculatedAmount, _PayCurrencyName, _PayCurrencyValue, _AddedBy, _AddedDate.Value(StaticInfo.DateFormat), _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat), _ApprovedBy, _ApproveDate };
            else if (IsDeleted)
                parameterValues = new Object[] { _RowId };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            //_RowId = reader.GetInt64("RowId");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            _YearNo = reader.GetInt32("YearNo");
            _MonthNo = reader.GetInt32("MonthNo");
            _FromDate = reader.GetString("FromDate");
            _Todate = reader.GetString("Todate");
            _ProcessingDate = reader.GetDateTime("ProcessingDate");
            _EmpKey = reader.GetInt64("EmpKey");
            _SalaryHeadKey = reader.GetInt32("SalaryHeadKey");
            _HeadName = reader.GetString("HeadName");
            _OrgAmount = reader.GetDecimal("OrgAmount");
            _CurrencyName = reader.GetString("CurrencyName");
            _CalculatedAmount = reader.GetDecimal("CalculatedAmount");
            _PayCurrencyName = reader.GetString("PayCurrencyName");
            _PayCurrencyValue = reader.GetDecimal("PayCurrencyValue");
            _AddedBy = reader.GetString("AddedBy");
            _AddedDate = reader.GetDateTime("AddedDate");
            _UpdatedBy = reader.GetString("UpdatedBy");
            _UpdatedDate = reader.GetDateTime("UpdatedDate");
            _ApprovedBy = reader.GetInt32("ApprovedBy");
            _ApproveDate = reader.GetInt32("ApproveDate");
            SetUnchanged();
        }
        public static CustomList<SalaryProcess> GetAllSalaryProcess()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SalaryProcess> SalaryProcessCollection = new CustomList<SalaryProcess>();
            IDataReader reader = null;
            const String sql = "select * from SalaryProcess";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SalaryProcess newSalaryProcess = new SalaryProcess();
                    newSalaryProcess.SetData(reader);
                    SalaryProcessCollection.Add(newSalaryProcess);
                }
                SalaryProcessCollection.InsertSpName = "spInsertSalaryProcess";
                SalaryProcessCollection.UpdateSpName = "spUpdateSalaryProcess";
                SalaryProcessCollection.DeleteSpName = "spDeleteSalaryProcess";
                return SalaryProcessCollection;
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
        public static CustomList<SalaryProcess> doSalaryProcess(string spName, string YearNo, string MonthNo, string fromdate, string toDate, string tableName)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SalaryProcess> SalaryProcessCollection = new CustomList<SalaryProcess>();
            IDataReader reader = null;
            String sql = "exec " + spName + "'" + YearNo + "','" + MonthNo + "','" + fromdate + "','" + toDate + "','" + tableName+"'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SalaryProcess newSalaryProcess = new SalaryProcess();
                    newSalaryProcess.SetData(reader);
                    SalaryProcessCollection.Add(newSalaryProcess);
                }
                SalaryProcessCollection.InsertSpName = "spInsertSalaryProcess";
                SalaryProcessCollection.UpdateSpName = "spUpdateSalaryProcess";
                SalaryProcessCollection.DeleteSpName = "spDeleteSalaryProcess";
                return SalaryProcessCollection;
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
        public static CustomList<SalaryProcess> deleteProcessedSalary(string tableName, string yearno, string month)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SalaryProcess> ShiftRosterCollection = new CustomList<SalaryProcess>();
        

            IDataReader reader = null;
            String sql = "exec spDeleteSalaryProcessTableWise '" + yearno + "','" + month + "','" + tableName + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SalaryProcess newShiftRoster = new SalaryProcess();
                    newShiftRoster.SetData(reader);
                    ShiftRosterCollection.Add(newShiftRoster);
                }
                ShiftRosterCollection.InsertSpName = "spInsertShiftRoster";
                ShiftRosterCollection.UpdateSpName = "spUpdateShiftRoster";
                ShiftRosterCollection.DeleteSpName = "spDeleteShiftRoster";
                return ShiftRosterCollection;
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
        public static CustomList<SalaryProcess> deleteTempEmpListSalary(int ID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SalaryProcess> ShiftRosterCollection = new CustomList<SalaryProcess>();


            IDataReader reader = null;
            String sql = "exec spDeleteTempEmpListForSalary '" + ID + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SalaryProcess newShiftRoster = new SalaryProcess();
                    newShiftRoster.SetData(reader);
                    ShiftRosterCollection.Add(newShiftRoster);
                }
                ShiftRosterCollection.InsertSpName = "spInsertTempEmpListForSalary";
                ShiftRosterCollection.DeleteSpName = "spDeleteTempEmpListForSalary";
                return ShiftRosterCollection;
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

        public static void DeleteTempEmpListSalary()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SalaryProcess> ShiftRosterCollection = new CustomList<SalaryProcess>();


            IDataReader reader = null;
            String sql = "exec spDeleteTempEmpListFoySalary";
            try
            {
                conManager.OpenDataReader(sql, out reader);
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