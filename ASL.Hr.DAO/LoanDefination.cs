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
    public class LoanDefination : BaseItem
    {
        public LoanDefination()
        {
            SetAdded();
        }

        #region Properties

        private System.String _LoanCode;
        [Browsable(true), DisplayName("LoanCode")]
        public System.String LoanCode
        {
            get
            {
                return _LoanCode;
            }
            set
            {
                if (PropertyChanged(_LoanCode, value))
                    _LoanCode = value;
            }
        }

        private System.String _Descriptions;
        [Browsable(true), DisplayName("Descriptions")]
        public System.String Descriptions
        {
            get
            {
                return _Descriptions;
            }
            set
            {
                if (PropertyChanged(_Descriptions, value))
                    _Descriptions = value;
            }
        }

        private System.String _EmployeeCode;
        [Browsable(true), DisplayName("EmployeeCode")]
        public System.String EmployeeCode
        {
            get
            {
                return _EmployeeCode;
            }
            set
            {
                if (PropertyChanged(_EmployeeCode, value))
                    _EmployeeCode = value;
            }
        }

        private System.Int32? _LoanTypeID;
        [Browsable(true), DisplayName("LoanTypeID")]
        public System.Int32? LoanTypeID
        {
            get
            {
                return _LoanTypeID;
            }
            set
            {
                if (PropertyChanged(_LoanTypeID, value))
                    _LoanTypeID = value;
            }
        }

        private System.Decimal _SanctionAmount;
        [Browsable(true), DisplayName("SanctionAmount")]
        public System.Decimal SanctionAmount
        {
            get
            {
                return _SanctionAmount;
            }
            set
            {
                if (PropertyChanged(_SanctionAmount, value))
                    _SanctionAmount = value;
            }
        }

        private System.DateTime _IstDisbursemenDate;
        [Browsable(true), DisplayName("IstDisbursemenDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime IstDisbursemenDate
        {
            get
            {
                return _IstDisbursemenDate;
            }
            set
            {
                if (PropertyChanged(_IstDisbursemenDate, value))
                    _IstDisbursemenDate = value;
            }
        }

        private System.Decimal _InterestRate;
        [Browsable(true), DisplayName("InterestRate")]
        public System.Decimal InterestRate
        {
            get
            {
                return _InterestRate;
            }
            set
            {
                if (PropertyChanged(_InterestRate, value))
                    _InterestRate = value;
            }
        }

        private System.Decimal _InterestAmount;
        [Browsable(true), DisplayName("InterestAmount")]
        public System.Decimal InterestAmount
        {
            get
            {
                return _InterestAmount;
            }
            set
            {
                if (PropertyChanged(_InterestAmount, value))
                    _InterestAmount = value;
            }
        }

        private System.Int32 _InterestCollectionInstallmentNo;
        [Browsable(true), DisplayName("InterestCollectionInstallmentNo")]
        public System.Int32 InterestCollectionInstallmentNo
        {
            get
            {
                return _InterestCollectionInstallmentNo;
            }
            set
            {
                if (PropertyChanged(_InterestCollectionInstallmentNo, value))
                    _InterestCollectionInstallmentNo = value;
            }
        }

        private System.Int32 _MonthInterval;
        [Browsable(true), DisplayName("MonthInterval")]
        public System.Int32 MonthInterval
        {
            get
            {
                return _MonthInterval;
            }
            set
            {
                if (PropertyChanged(_MonthInterval, value))
                    _MonthInterval = value;
            }
        }

        private System.Boolean _IsAmount;
        [Browsable(true), DisplayName("IsAmount")]
        public System.Boolean IsAmount
        {
            get
            {
                return _IsAmount;
            }
            set
            {
                if (PropertyChanged(_IsAmount, value))
                    _IsAmount = value;
            }
        }

        private System.Decimal _InstallmentAmount;
        [Browsable(true), DisplayName("InstallmentAmount")]
        public System.Decimal InstallmentAmount
        {
            get
            {
                return _InstallmentAmount;
            }
            set
            {
                if (PropertyChanged(_InstallmentAmount, value))
                    _InstallmentAmount = value;
            }
        }

        private System.String _SalaryHeadID;
        [Browsable(true), DisplayName("SalaryHeadID")]
        public System.String SalaryHeadID
        {
            get
            {
                return _SalaryHeadID;
            }
            set
            {
                if (PropertyChanged(_SalaryHeadID, value))
                    _SalaryHeadID = value;
            }
        }

        private System.DateTime _DateAdded;
        [Browsable(true), DisplayName("DateAdded"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DateAdded
        {
            get
            {
                return _DateAdded;
            }
            set
            {
                if (PropertyChanged(_DateAdded, value))
                    _DateAdded = value;
            }
        }

        private System.DateTime _DateUpdated;
        [Browsable(true), DisplayName("DateUpdated"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DateUpdated
        {
            get
            {
                return _DateUpdated;
            }
            set
            {
                if (PropertyChanged(_DateUpdated, value))
                    _DateUpdated = value;
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

        private System.Boolean _InActive;
        [Browsable(true), DisplayName("InActive")]
        public System.Boolean InActive
        {
            get
            {
                return _InActive;
            }
            set
            {
                if (PropertyChanged(_InActive, value))
                    _InActive = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _LoanCode, _Descriptions, _EmployeeCode, _LoanTypeID, _SanctionAmount, _IstDisbursemenDate.Value(StaticInfo.DateFormat), _InterestRate, _InterestAmount, _InterestCollectionInstallmentNo, _MonthInterval, _IsAmount, _InstallmentAmount, _SalaryHeadID, _DateAdded.Value(StaticInfo.DateFormat), _DateUpdated.Value(StaticInfo.DateFormat), _AddedBy, _UpdatedBy, _InActive };
            else if (IsModified)
                parameterValues = new Object[] { _LoanCode, _Descriptions, _EmployeeCode, _LoanTypeID, _SanctionAmount, _IstDisbursemenDate.Value(StaticInfo.DateFormat), _InterestRate, _InterestAmount, _InterestCollectionInstallmentNo, _MonthInterval, _IsAmount, _InstallmentAmount, _SalaryHeadID, _DateAdded.Value(StaticInfo.DateFormat), _DateUpdated.Value(StaticInfo.DateFormat), _AddedBy, _UpdatedBy, _InActive };
            else if (IsDeleted)
                parameterValues = new Object[] { _LoanCode };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _LoanCode = reader.GetString("LoanCode");
            _Descriptions = reader.GetString("Descriptions");
            _EmployeeCode = reader.GetString("EmployeeCode");
            _LoanTypeID = reader.GetInt32("LoanTypeID");
            _SanctionAmount = reader.GetDecimal("SanctionAmount");
            _IstDisbursemenDate = reader.GetDateTime("IstDisbursemenDate");
            _InterestRate = reader.GetDecimal("InterestRate");
            _InterestAmount = reader.GetDecimal("InterestAmount");
            _InterestCollectionInstallmentNo = reader.GetInt32("InterestCollectionInstallmentNo");
            _MonthInterval = reader.GetInt32("MonthInterval");
            _IsAmount = reader.GetBoolean("IsAmount");
            _InstallmentAmount = reader.GetDecimal("InstallmentAmount");
            _SalaryHeadID = reader.GetString("SalaryHeadID");
            _DateAdded = reader.GetDateTime("DateAdded");
            _DateUpdated = reader.GetDateTime("DateUpdated");
            _AddedBy = reader.GetString("AddedBy");
            _UpdatedBy = reader.GetString("UpdatedBy");
            _InActive = reader.GetBoolean("InActive");
            SetUnchanged();
        }
        public static CustomList<LoanDefination> GetAllLoanDefination()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LoanDefination> LoanDefinationCollection = new CustomList<LoanDefination>();
            IDataReader reader = null;
            const String sql = "select *from LoanDefination";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LoanDefination newLoanDefination = new LoanDefination();
                    newLoanDefination.SetData(reader);
                    LoanDefinationCollection.Add(newLoanDefination);
                }
                LoanDefinationCollection.InsertSpName = "spInsertLoanDefination";
                LoanDefinationCollection.UpdateSpName = "spUpdateLoanDefination";
                LoanDefinationCollection.DeleteSpName = "spDeleteLoanDefination";
                return LoanDefinationCollection;
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