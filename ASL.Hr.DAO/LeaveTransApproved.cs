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
    public class LeaveTransApproved : BaseItem
    {
        public LeaveTransApproved()
        {
            SetAdded();
        }

        #region Properties

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

        private System.String _SalaryRuleCode;
        [Browsable(true), DisplayName("SalaryRuleCode")]
        public System.String SalaryRuleCode
        {
            get
            {
                return _SalaryRuleCode;
            }
            set
            {
                if (PropertyChanged(_SalaryRuleCode, value))
                    _SalaryRuleCode = value;
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

        private System.String _Designation;
        [Browsable(true), DisplayName("Designation")]
        public System.String Designation
        {
            get
            {
                return _Designation;
            }
            set
            {
                if (PropertyChanged(_Designation, value))
                    _Designation = value;
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

        private System.String _StaffCategory;
        [Browsable(true), DisplayName("StaffCategory")]
        public System.String StaffCategory
        {
            get
            {
                return _StaffCategory;
            }
            set
            {
                if (PropertyChanged(_StaffCategory, value))
                    _StaffCategory = value;
            }
        }

        private System.DateTime _DOJ;
        [Browsable(true), DisplayName("DOJ"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DOJ
        {
            get
            {
                return _DOJ;
            }
            set
            {
                if (PropertyChanged(_DOJ, value))
                    _DOJ = value;
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

        private System.Int64 _TransID;
        [Browsable(true), DisplayName("TransID")]
        public System.Int64 TransID
        {
            get
            {
                return _TransID;
            }
            set
            {
                if (PropertyChanged(_TransID, value))
                    _TransID = value;
            }
        }


        private System.Int32 _ShiftID;
        [Browsable(true), DisplayName("ShiftID")]
        public System.Int32 ShiftID
        {
            get
            {
                return _ShiftID;
            }
            set
            {
                if (PropertyChanged(_ShiftID, value))
                    _ShiftID = value;
            }
        }

        private System.DateTime _TransactionDate;
        [Browsable(true), DisplayName("TransactionDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime TransactionDate
        {
            get
            {
                return _TransactionDate;
            }
            set
            {
                if (PropertyChanged(_TransactionDate, value))
                    _TransactionDate = value;
            }
        }

        private System.String _LeaveYear;
        [Browsable(true), DisplayName("LeaveYear")]
        public System.String LeaveYear
        {
            get
            {
                return _LeaveYear;
            }
            set
            {
                if (PropertyChanged(_LeaveYear, value))
                    _LeaveYear = value;
            }
        }

        private System.String _LeavePolicyID;
        [Browsable(true), DisplayName("LeavePolicyID")]
        public System.String LeavePolicyID
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

        private System.Int32 _LeaveRuleKey;
        [Browsable(true), DisplayName("LeaveRuleKey")]
        public System.Int32 LeaveRuleKey
        {
            get
            {
                return _LeaveRuleKey;
            }
            set
            {
                if (PropertyChanged(_LeaveRuleKey, value))
                    _LeaveRuleKey = value;
            }
        }
        private System.String _LeaveRuleCode;
        [Browsable(true), DisplayName("LeaveRuleCode")]
        public System.String LeaveRuleCode
        {
            get
            {
                return _LeaveRuleCode;
            }
            set
            {
                if (PropertyChanged(_LeaveRuleCode, value))
                    _LeaveRuleCode = value;
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

        private System.Decimal _LeaveDays;
        [Browsable(true), DisplayName("LeaveDays")]
        public System.Decimal LeaveDays
        {
            get
            {
                return _LeaveDays;
            }
            set
            {
                if (PropertyChanged(_LeaveDays, value))
                    _LeaveDays = value;
            }
        }
        private System.DateTime _ApprovedFrom;
        [Browsable(true), DisplayName("ApprovedFrom"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime ApprovedFrom
        {
            get
            {
                return _ApprovedFrom;
            }
            set
            {
                if (PropertyChanged(_ApprovedFrom, value))
                    _ApprovedFrom = value;
            }
        }

        private System.DateTime _ApprovedTo;
        [Browsable(true), DisplayName("ApprovedTo"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime ApprovedTo
        {
            get
            {
                return _ApprovedTo;
            }
            set
            {
                if (PropertyChanged(_ApprovedTo, value))
                    _ApprovedTo = value;
            }
        }

        private System.Decimal _ApprovedDays;
        [Browsable(true), DisplayName("ApprovedDays")]
        public System.Decimal ApprovedDays
        {
            get
            {
                return _ApprovedDays;
            }
            set
            {
                if (PropertyChanged(_ApprovedDays, value))
                    _ApprovedDays = value;
            }
        }
        private System.String _LeaveReason;
        [Browsable(true), DisplayName("LeaveReason")]
        public System.String LeaveReason
        {
            get
            {
                return _LeaveReason;
            }
            set
            {
                if (PropertyChanged(_LeaveReason, value))
                    _LeaveReason = value;
            }
        }

        private System.String _LeaveAvailPlace;
        [Browsable(true), DisplayName("LeaveAvailPlace")]
        public System.String LeaveAvailPlace
        {
            get
            {
                return _LeaveAvailPlace;
            }
            set
            {
                if (PropertyChanged(_LeaveAvailPlace, value))
                    _LeaveAvailPlace = value;
            }
        }

        private System.String _Contact;
        [Browsable(true), DisplayName("Contact")]
        public System.String Contact
        {
            get
            {
                return _Contact;
            }
            set
            {
                if (PropertyChanged(_Contact, value))
                    _Contact = value;
            }
        }

        private System.Boolean _IsForwarded;
        [Browsable(true), DisplayName("IsForwarded")]
        public System.Boolean IsForwarded
        {
            get
            {
                return _IsForwarded;
            }
            set
            {
                if (PropertyChanged(_IsForwarded, value))
                    _IsForwarded = value;
            }
        }

        private System.Boolean _IsRecomended;
        [Browsable(true), DisplayName("IsRecomended")]
        public System.Boolean IsRecomended
        {
            get
            {
                return _IsRecomended;
            }
            set
            {
                if (PropertyChanged(_IsRecomended, value))
                    _IsRecomended = value;
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

        private System.Boolean _IsRejected;
        [Browsable(true), DisplayName("IsRejected")]
        public System.Boolean IsRejected
        {
            get
            {
                return _IsRejected;
            }
            set
            {
                if (PropertyChanged(_IsRejected, value))
                    _IsRejected = value;
            }
        }

        private System.Boolean _IsPostApproved;
        [Browsable(true), DisplayName("IsPostApproved")]
        public System.Boolean IsPostApproved
        {
            get
            {
                return _IsPostApproved;
            }
            set
            {
                if (PropertyChanged(_IsPostApproved, value))
                    _IsPostApproved = value;
            }
        }

        private System.String _ApprovedBy;
        [Browsable(true), DisplayName("ApprovedBy")]
        public System.String ApprovedBy
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

        private System.DateTime _DateApproved;
        [Browsable(true), DisplayName("DateApproved"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DateApproved
        {
            get
            {
                return _DateApproved;
            }
            set
            {
                if (PropertyChanged(_DateApproved, value))
                    _DateApproved = value;
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
        private System.String _EmpPicture;
        [Browsable(true), DisplayName("EmpPicture")]
        public System.String EmpPicture
        {
            get
            {
                return _EmpPicture;
            }
            set
            {
                if (PropertyChanged(_EmpPicture, value))
                    _EmpPicture = value;
            }
        }

        private System.String _LeaveSubstitute;
        [Browsable(true), DisplayName("LeaveSubstitute")]
        public System.String LeaveSubstitute
        {
            get
            {
                return _LeaveSubstitute;
            }
            set
            {
                if (PropertyChanged(_LeaveSubstitute, value))
                    _LeaveSubstitute = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _ShiftID, _TransactionDate.Value(StaticInfo.DateFormat), _LeaveYear, _LeavePolicyID, _LeaveRuleKey, _FromDate.Value(StaticInfo.DateFormat), _ToDate.Value(StaticInfo.DateFormat), _LeaveDays, _ApprovedFrom.Value(StaticInfo.DateFormat), _ApprovedTo.Value(StaticInfo.DateFormat), _ApprovedDays, _LeaveReason, _LeaveAvailPlace, _Contact, _IsForwarded, _IsRecomended, _IsApproved, _IsRejected, _IsPostApproved, _ApprovedBy, _DateApproved.Value(StaticInfo.DateFormat), _AddedBy, _DateAdded.Value(StaticInfo.DateFormat), _UpdatedBy, _DateUpdated.Value(StaticInfo.DateFormat), _LeaveSubstitute };
            else if (IsModified)
                parameterValues = new Object[] { _TransID, _EmpKey, _ShiftID, _TransactionDate.Value(StaticInfo.DateFormat), _LeaveYear, _LeavePolicyID, _LeaveRuleKey, _FromDate.Value(StaticInfo.DateFormat), _ToDate.Value(StaticInfo.DateFormat), _LeaveDays, _ApprovedFrom.Value(StaticInfo.DateFormat), _ApprovedTo.Value(StaticInfo.DateFormat), _ApprovedDays, _LeaveReason, _LeaveAvailPlace, _Contact, _IsForwarded, _IsRecomended, _IsApproved, _IsRejected, _IsPostApproved, _ApprovedBy, _DateApproved.Value(StaticInfo.DateFormat), _AddedBy, _DateAdded.Value(StaticInfo.DateFormat), _UpdatedBy, _DateUpdated.Value(StaticInfo.DateFormat), _LeaveSubstitute };
            else if (IsDeleted)
                parameterValues = new Object[] { _TransID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _TransID = reader.GetInt64("TransID");
            _EmpKey = reader.GetInt64("EmpKey");
            _ShiftID = reader.GetInt32("ShiftID");
            _TransactionDate = reader.GetDateTime("TransactionDate");
            _LeaveYear = reader.GetString("LeaveYear");
            _LeavePolicyID = reader.GetString("LeavePolicyID");
            _LeaveType = reader.GetString("LeaveType");
            _LeaveRuleKey = reader.GetInt32("LeaveRuleKey");
            _FromDate = reader.GetDateTime("FromDate");
            _ToDate = reader.GetDateTime("ToDate");
            _LeaveDays = reader.GetDecimal("LeaveDays");
            _ApprovedFrom = reader.GetDateTime("ApprovedFrom");
            _ApprovedTo = reader.GetDateTime("ApprovedTo");
            _ApprovedDays = reader.GetDecimal("ApprovedDays");
            _LeaveReason = reader.GetString("LeaveReason");
            _LeaveAvailPlace = reader.GetString("LeaveAvailPlace");
            _Contact = reader.GetString("Contact");
            _IsForwarded = reader.GetBoolean("IsForwarded");
            _IsRecomended = reader.GetBoolean("IsRecomended");
            _IsApproved = reader.GetBoolean("IsApproved");
            _IsRejected = reader.GetBoolean("IsRejected");
            _IsPostApproved = reader.GetBoolean("IsPostApproved");
            _ApprovedBy = reader.GetString("ApprovedBy");
            _DateApproved = reader.GetDateTime("DateApproved");
            _AddedBy = reader.GetString("AddedBy");
            _DateAdded = reader.GetDateTime("DateAdded");
            _UpdatedBy = reader.GetString("UpdatedBy");
            _DateUpdated = reader.GetDateTime("DateUpdated");
            _LeaveSubstitute = reader.GetString("LeaveSubstitute");
            SetUnchanged();
        }
        public void SetData2(IDataRecord reader)
        {
            _EmpCode = reader.GetString("EmpCode");
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpName = reader.GetString("EmpName");
            _EmpKey = reader.GetInt64("EmpKey");
            _ShiftID = reader.GetInt32("ShiftID");
            _LeaveRuleKey = reader.GetInt32("LeaveRuleKey");
            _Designation = reader.GetString("Designation");
            _StaffCategory = reader.GetString("StaffCategory");
            _EmpPicture = reader.GetString("EmpPicture");
            _DOJ = reader.GetDateTime("DOJ");
            SetUnchanged();
        }
        public void SetDataDayLeaves(IDataRecord reader)
        {
            _EmpCode = reader.GetString("EmpCode");
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpName = reader.GetString("EmpName");
            _Designation = reader.GetString("Designation");
            _Department = reader.GetString("Department");
            _LeaveType = reader.GetString("LeaveType");
            _TransactionDate = reader.GetDateTime("TransactionDate");
            _LeaveYear = reader.GetString("LeaveYear");
            _LeavePolicyID = reader.GetString("LeavePolicyID");
            _LeaveDays = reader.GetDecimal("LeaveDays");
            _LeaveRuleKey = reader.GetInt32("LeaveRuleKey");
            _FromDate = reader.GetDateTime("FromDate");
            _ToDate = reader.GetDateTime("ToDate");
            _ApprovedFrom = reader.GetDateTime("ApprovedFrom");
            _ApprovedTo = reader.GetDateTime("ApprovedTo");
            _ApprovedDays = reader.GetDecimal("ApprovedDays");
            _LeaveReason = reader.GetString("LeaveReason");
            _IsForwarded = reader.GetBoolean("IsForwarded");
            _IsRecomended = reader.GetBoolean("IsRecomended");
            _IsApproved = reader.GetBoolean("IsApproved");
            _IsRejected = reader.GetBoolean("IsRejected");
            _TransID = reader.GetInt64("TransID");
            SetUnchanged();
        }
        public static CustomList<LeaveTransApproved> GetAllLeaveTransApproved()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeaveTransApproved> LeaveTransApprovedCollection = new CustomList<LeaveTransApproved>();
            IDataReader reader = null;
            const String sql = "exec spGetAllLeaveTransactions";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeaveTransApproved newLeaveTransApproved = new LeaveTransApproved();
                    newLeaveTransApproved.SetData(reader);
                    LeaveTransApprovedCollection.Add(newLeaveTransApproved);
                }
                return LeaveTransApprovedCollection;
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
        public static CustomList<LeaveTransApproved> GetEmpWiseAllLeaveTransApproved(string LeaveYear, string EmployeeCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeaveTransApproved> LeaveTransApprovedCollection = new CustomList<LeaveTransApproved>();
            IDataReader reader = null;
            String sql = "exec spGetEmpWiseAllLeaveTransactions '" + LeaveYear + "','" + EmployeeCode + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeaveTransApproved newLeaveTransApproved = new LeaveTransApproved();
                    newLeaveTransApproved.SetData(reader);
                    LeaveTransApprovedCollection.Add(newLeaveTransApproved);
                }
                return LeaveTransApprovedCollection;
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
        public static CustomList<LeaveTransApproved> GetLeaveEligibleEmp(string EmployeeCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeaveTransApproved> LeaveTransApprovedCollection = new CustomList<LeaveTransApproved>();
            IDataReader reader = null;
            String sql = "exec spGetEligibleEmpForLeaveTrans '" + EmployeeCode + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeaveTransApproved newLeaveTransApproved = new LeaveTransApproved();
                    newLeaveTransApproved.SetData2(reader);
                    LeaveTransApprovedCollection.Add(newLeaveTransApproved);
                }
                return LeaveTransApprovedCollection;
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
        public static CustomList<LeaveTransApproved> GetUnApprovedDayLeaves()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeaveTransApproved> LeaveTransApprovedCollection = new CustomList<LeaveTransApproved>();
            IDataReader reader = null;
            String sql = "exec spGetDayLeaves";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeaveTransApproved newLeaveTransApproved = new LeaveTransApproved();
                    newLeaveTransApproved.SetDataDayLeaves(reader);
                    LeaveTransApprovedCollection.Add(newLeaveTransApproved);
                }
                return LeaveTransApprovedCollection;
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
        public static CustomList<LeaveTransApproved> GetUnApprovedDayLeaves(string empKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeaveTransApproved> LeaveTransApprovedCollection = new CustomList<LeaveTransApproved>();
            IDataReader reader = null;
            String sql = "exec spGetDayLeavesRepotiee '" + empKey + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeaveTransApproved newLeaveTransApproved = new LeaveTransApproved();
                    newLeaveTransApproved.SetDataDayLeaves(reader);
                    LeaveTransApprovedCollection.Add(newLeaveTransApproved);
                }
                return LeaveTransApprovedCollection;
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


