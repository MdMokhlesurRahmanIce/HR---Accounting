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
    public class LeaveSummery : BaseItem
    {
        public LeaveSummery()
        {
            SetAdded();
        }

        #region Properties

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

        private System.Int32 _LeavePolicyID;
        [Browsable(true), DisplayName("LeavePolicyID")]
        public System.Int32 LeavePolicyID
        {
            get
            {
                return _LeavePolicyID;
            }
            set
            {
                if (PropertyChanged(_LeavePolicyID, value))
                    _LeavePolicyID = value;
            }
        }

        private System.String _LeaveType;
        [Browsable(true), DisplayName("LeaveType")]
        public System.String LeaveType
        {
            get
            {
                return _LeaveType;
            }
            set
            {
                if (PropertyChanged(_LeaveType, value))
                    _LeaveType = value;
            }
        }

        private System.Decimal _Opening;
        [Browsable(true), DisplayName("Opening")]
        public System.Decimal Opening
        {
            get
            {
                return _Opening;
            }
            set
            {
                if (PropertyChanged(_Opening, value))
                    _Opening = value;
            }
        }

        private System.Decimal _Allocated;
        [Browsable(true), DisplayName("Allocated")]
        public System.Decimal Allocated
        {
            get
            {
                return _Allocated;
            }
            set
            {
                if (PropertyChanged(_Allocated, value))
                    _Allocated = value;
            }
        }

        private System.Decimal _Availed;
        [Browsable(true), DisplayName("Availed")]
        public System.Decimal Availed
        {
            get
            {
                return _Availed;
            }
            set
            {
                if (PropertyChanged(_Availed, value))
                    _Availed = value;
            }
        }

        private System.Decimal _Encashed;
        [Browsable(true), DisplayName("Encashed")]
        public System.Decimal Encashed
        {
            get
            {
                return _Encashed;
            }
            set
            {
                if (PropertyChanged(_Encashed, value))
                    _Encashed = value;
            }
        }
        private System.Decimal _Advance;
        [Browsable(true), DisplayName("Advance")]
        public System.Decimal Advance
        {
            get
            {
                return _Advance;
            }
            set
            {
                if (PropertyChanged(_Advance, value))
                    _Advance = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpCode, _LeaveType, _Allocated };
            else if (IsModified)
                parameterValues = new Object[] { _EmpCode, _LeaveType, _Allocated };
            else if (IsDeleted)
                parameterValues = new Object[] { _EmpKey, _LeavePolicyID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _LeaveType = reader.GetString("LeaveType");
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _LeavePolicyID = reader.GetInt32("LeavePolicyID");           
            _Advance = reader.GetDecimal("Advance");
            _Opening = reader.GetDecimal("OpeningBalance");
            _Allocated = reader.GetDecimal("Allocated");
            _Availed = reader.GetDecimal("Availed");
            _Encashed = reader.GetDecimal("Encashed");
            _Balance = reader.GetDecimal("Balance");
            SetUnchanged();

        }
        public static CustomList<LeaveSummery> GetAllLeaveSummery()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeaveSummery> LeaveSummeryCollection = new CustomList<LeaveSummery>();
            IDataReader reader = null;
            const String sql = "exec spLeaveSummery";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeaveSummery newLeaveSummery = new LeaveSummery();
                    newLeaveSummery.SetData(reader);
                    LeaveSummeryCollection.Add(newLeaveSummery);
                }
                LeaveSummeryCollection.InsertSpName = "spInsertLeaveSummery";
                LeaveSummeryCollection.UpdateSpName = "spUpdateLeaveSummery";
                LeaveSummeryCollection.DeleteSpName = "spDeleteLeaveSummery";
                return LeaveSummeryCollection;
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
        public static CustomList<LeaveSummery> GetEmpWiseLeaveSummery(string LeaveYear, string EmployeeCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeaveSummery> LeaveSummeryCollection = new CustomList<LeaveSummery>();
            IDataReader reader = null;
            String sql = "exec spLeaveSummeryEmpWise '" + LeaveYear + "','" + EmployeeCode + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeaveSummery newLeaveSummery = new LeaveSummery();
                    newLeaveSummery.SetData(reader);
                    LeaveSummeryCollection.Add(newLeaveSummery);
                }
                LeaveSummeryCollection.InsertSpName = "spInsertLeaveSummery";
                LeaveSummeryCollection.UpdateSpName = "spUpdateLeaveSummery";
                LeaveSummeryCollection.DeleteSpName = "spDeleteLeaveSummery";
                return LeaveSummeryCollection;
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
