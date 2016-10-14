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
    public class LoanProcess : BaseItem
    {
        public LoanProcess()
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

        private System.Int32 _InstallmentNo;
        [Browsable(true), DisplayName("InstallmentNo")]
        public System.Int32 InstallmentNo
        {
            get
            {
                return _InstallmentNo;
            }
            set
            {
                if (PropertyChanged(_InstallmentNo, value))
                    _InstallmentNo = value;
            }
        }

        private System.Int32 _PaymentSequence;
        [Browsable(true), DisplayName("PaymentSequence")]
        public System.Int32 PaymentSequence
        {
            get
            {
                return _PaymentSequence;
            }
            set
            {
                if (PropertyChanged(_PaymentSequence, value))
                    _PaymentSequence = value;
            }
        }

        private System.DateTime _InstallmentDate;
        [Browsable(true), DisplayName("InstallmentDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime InstallmentDate
        {
            get
            {
                return _InstallmentDate;
            }
            set
            {
                if (PropertyChanged(_InstallmentDate, value))
                    _InstallmentDate = value;
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

        private System.Decimal _Balance;
        [Browsable(true), DisplayName("Balance")]
        public System.Decimal Balance
        {
            get
            {
                return _Balance;
            }
            set
            {
                if (PropertyChanged(_Balance, value))
                    _Balance = value;
            }
        }

        private System.String _SalaryProcID;
        [Browsable(true), DisplayName("SalaryProcID")]
        public System.String SalaryProcID
        {
            get
            {
                return _SalaryProcID;
            }
            set
            {
                if (PropertyChanged(_SalaryProcID, value))
                    _SalaryProcID = value;
            }
        }

        private System.Boolean _IsApproved;
        [Browsable(true), DisplayName("IsApproved")]
        public System.Boolean IsApproved
        {
            get
            {
                return _IsApproved;
            }
            set
            {
                if (PropertyChanged(_IsApproved, value))
                    _IsApproved = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _LoanCode, _InstallmentNo, _PaymentSequence, _InstallmentDate.Value(StaticInfo.DateFormat), _InstallmentAmount, _Balance, _SalaryProcID, _IsApproved, _DateAdded.Value(StaticInfo.DateFormat), _DateUpdated.Value(StaticInfo.DateFormat), _AddedBy, _UpdatedBy, _InterestAmount };
            else if (IsModified)
                parameterValues = new Object[] { _LoanCode, _InstallmentNo, _PaymentSequence, _InstallmentDate.Value(StaticInfo.DateFormat), _InstallmentAmount, _Balance, _SalaryProcID, _IsApproved, _DateAdded.Value(StaticInfo.DateFormat), _DateUpdated.Value(StaticInfo.DateFormat), _AddedBy, _UpdatedBy, _InterestAmount };
            else if (IsDeleted)
                parameterValues = new Object[] { _LoanCode, _InstallmentNo, _PaymentSequence };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _LoanCode = reader.GetString("LoanCode");
            _InstallmentNo = reader.GetInt32("InstallmentNo");
            _PaymentSequence = reader.GetInt32("PaymentSequence");
            _InstallmentDate = reader.GetDateTime("InstallmentDate");
            _InstallmentAmount = reader.GetDecimal("InstallmentAmount");
            _Balance = reader.GetDecimal("Balance");
            _SalaryProcID = reader.GetString("SalaryProcID");
            _IsApproved = reader.GetBoolean("IsApproved");
            _DateAdded = reader.GetDateTime("DateAdded");
            _DateUpdated = reader.GetDateTime("DateUpdated");
            _AddedBy = reader.GetString("AddedBy");
            _UpdatedBy = reader.GetString("UpdatedBy");
            _InterestAmount = reader.GetDecimal("InterestAmount");
            SetUnchanged();
        }
        public static CustomList<LoanProcess> GetAllLoanProcess()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LoanProcess> LoanProcessCollection = new CustomList<LoanProcess>();
            IDataReader reader = null;
            const String sql = "select *from LoanProcess";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LoanProcess newLoanProcess = new LoanProcess();
                    newLoanProcess.SetData(reader);
                    LoanProcessCollection.Add(newLoanProcess);
                }
                LoanProcessCollection.InsertSpName = "spInsertLoanProcess";
                LoanProcessCollection.UpdateSpName = "spUpdateLoanProcess";
                LoanProcessCollection.DeleteSpName = "spDeleteLoanProcess";
                return LoanProcessCollection;
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
        public static CustomList<LoanProcess> GetAllLoanProcess(string loanCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LoanProcess> LoanProcessCollection = new CustomList<LoanProcess>();
            IDataReader reader = null;
            String sql = "select *from LoanProcess Where LoanCode='"+loanCode+"'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LoanProcess newLoanProcess = new LoanProcess();
                    newLoanProcess.SetData(reader);
                    LoanProcessCollection.Add(newLoanProcess);
                }
                return LoanProcessCollection;
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
