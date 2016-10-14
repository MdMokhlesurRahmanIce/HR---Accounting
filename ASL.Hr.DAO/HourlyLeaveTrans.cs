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
    public class HourlyLeaveTrans : BaseItem
    {
        public HourlyLeaveTrans()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _TransactionID;
        [Browsable(true), DisplayName("TransactionID")]
        public System.Int64 TransactionID
        {
            get
            {
                return _TransactionID;
            }
            set
            {
                if (PropertyChanged(_TransactionID, value))
                    _TransactionID = value;
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

        private System.DateTime _LeaveDate;
        [Browsable(true), DisplayName("LeaveDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime LeaveDate
        {
            get
            {
                return _LeaveDate;
            }
            set
            {
                if (PropertyChanged(_LeaveDate, value))
                    _LeaveDate = value;
            }
        }

        private System.String _LeaveFrom;
        [Browsable(true), DisplayName("LeaveFrom")]
        public System.String LeaveFrom
        {
            get
            {
                return _LeaveFrom;
            }
            set
            {
                if (PropertyChanged(_LeaveFrom, value))
                    _LeaveFrom = value;
            }
        }

        private System.String _LeaveTo;
        [Browsable(true), DisplayName("LeaveTo")]
        public System.String LeaveTo
        {
            get
            {
                return _LeaveTo;
            }
            set
            {
                if (PropertyChanged(_LeaveTo, value))
                    _LeaveTo = value;
            }
        }

        private System.Decimal _TotalHour;
        [Browsable(true), DisplayName("TotalHour")]
        public System.Decimal TotalHour
        {
            get
            {
                return _TotalHour;
            }
            set
            {
                if (PropertyChanged(_TotalHour, value))
                    _TotalHour = value;
            }
        }

        private System.String _HRApprovedFrom;
        [Browsable(true), DisplayName("HRApprovedFrom")]
        public System.String HRApprovedFrom
        {
            get
            {
                return _HRApprovedFrom;
            }
            set
            {
                if (PropertyChanged(_HRApprovedFrom, value))
                    _HRApprovedFrom = value;
            }
        }

        private System.String _HRApprovedTo;
        [Browsable(true), DisplayName("HRApprovedTo")]
        public System.String HRApprovedTo
        {
            get
            {
                return _HRApprovedTo;
            }
            set
            {
                if (PropertyChanged(_HRApprovedTo, value))
                    _HRApprovedTo = value;
            }
        }

        private System.Decimal _HRApprovedHour;
        [Browsable(true), DisplayName("HRApprovedHour")]
        public System.Decimal HRApprovedHour
        {
            get
            {
                return _HRApprovedHour;
            }
            set
            {
                if (PropertyChanged(_HRApprovedHour, value))
                    _HRApprovedHour = value;
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

        private System.String _ContactNo;
        [Browsable(true), DisplayName("ContactNo")]
        public System.String ContactNo
        {
            get
            {
                return _ContactNo;
            }
            set
            {
                if (PropertyChanged(_ContactNo, value))
                    _ContactNo = value;
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

        private System.DateTime _ApprovedDate;
        [Browsable(true), DisplayName("ApprovedDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime ApprovedDate
        {
            get
            {
                return _ApprovedDate;
            }
            set
            {
                if (PropertyChanged(_ApprovedDate, value))
                    _ApprovedDate = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _LeavePolicyID, _LeaveDate.Value(StaticInfo.DateFormat), _LeaveFrom, _LeaveTo, _TotalHour, _HRApprovedFrom, _HRApprovedTo, _HRApprovedHour, _IsForwarded, _IsRecomended, _IsRejected, _IsApproved, _LeaveReason, _LeaveAvailPlace, _ContactNo, _AddedBy, _DateAdded.Value(StaticInfo.DateFormat), _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat), _ApprovedBy, _ApprovedDate.Value(StaticInfo.DateFormat), _LeaveSubstitute };
            else if (IsModified)
                parameterValues = new Object[] { _TransactionID, _EmpKey, _LeavePolicyID, _LeaveDate.Value(StaticInfo.DateFormat), _LeaveFrom, _LeaveTo, _TotalHour, _HRApprovedFrom, _HRApprovedTo, _HRApprovedHour, _IsForwarded, _IsRecomended, _IsRejected, _IsApproved, _LeaveReason, _LeaveAvailPlace, _ContactNo, _AddedBy, _DateAdded.Value(StaticInfo.DateFormat), _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat), _ApprovedBy, _ApprovedDate.Value(StaticInfo.DateFormat), _LeaveSubstitute };
            else if (IsDeleted)
                parameterValues = new Object[] { _TransactionID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _TransactionID = reader.GetInt64("TransactionID");
            _EmpKey = reader.GetInt64("EmpKey");
            _LeavePolicyID = reader.GetString("LeavePolicyID");
            _LeaveDate = reader.GetDateTime("LeaveDate");
            _LeaveFrom = reader.GetString("LeaveFrom");
            _LeaveTo = reader.GetString("LeaveTo");
            _TotalHour = reader.GetDecimal("TotalHour");
            _HRApprovedFrom = reader.GetString("HRApprovedFrom");
            _HRApprovedTo = reader.GetString("HRApprovedTo");
            _HRApprovedHour = reader.GetDecimal("HRApprovedHour");
            _IsForwarded = reader.GetBoolean("IsForwarded");
            _IsRecomended = reader.GetBoolean("IsRecomended");
            _IsRejected = reader.GetBoolean("IsRejected");
            _IsApproved = reader.GetBoolean("IsApproved");
            _LeaveReason = reader.GetString("LeaveReason");
            _LeaveAvailPlace = reader.GetString("LeaveAvailPlace");
            _ContactNo = reader.GetString("ContactNo");
            _AddedBy = reader.GetString("AddedBy");
            _DateAdded = reader.GetDateTime("DateAdded");
            _UpdatedBy = reader.GetString("UpdatedBy");
            _UpdatedDate = reader.GetDateTime("UpdatedDate");
            _ApprovedBy = reader.GetString("ApprovedBy");
            _ApprovedDate = reader.GetDateTime("ApprovedDate");
            _LeaveType = reader.GetString("LeaveType");
            _LeaveSubstitute = reader.GetString("LeaveSubstitute");
            SetUnchanged();
        }
        private void SetDataLeave(IDataRecord reader)
        {
            _EmpCode = reader.GetString("EmpCode");
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpName = reader.GetString("EmpName");
            _Designation = reader.GetString("Designation");
            _LeavePolicyID = reader.GetString("LeavePolicyID");
            _Department = reader.GetString("Department");
            _LeaveType = reader.GetString("LeaveType");
            _LeaveDate = reader.GetDateTime("LeaveDate");
            _LeaveFrom = reader.GetString("LeaveFrom");
            _LeaveTo = reader.GetString("LeaveTo");
            _TotalHour = reader.GetDecimal("TotalHour");
            _HRApprovedFrom = reader.GetString("HRApprovedFrom");
            _HRApprovedTo = reader.GetString("HRApprovedTo");
            _HRApprovedHour = reader.GetDecimal("HRApprovedHour");
            _LeaveReason = reader.GetString("LeaveReason");
            _IsForwarded = reader.GetBoolean("IsForwarded");
            _IsRecomended = reader.GetBoolean("IsRecomended");
            _IsApproved = reader.GetBoolean("IsApproved");
            _IsRejected = reader.GetBoolean("IsRejected");
            _TransactionID = reader.GetInt64("TransactionID");
            SetUnchanged();
        }
        public static CustomList<HourlyLeaveTrans> GetAllHourlyLeaveTrans()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HourlyLeaveTrans> HourlyLeaveTransCollection = new CustomList<HourlyLeaveTrans>();
            IDataReader reader = null;
            const String sql = "select *from HourlyLeaveTrans";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HourlyLeaveTrans newHourlyLeaveTrans = new HourlyLeaveTrans();
                    newHourlyLeaveTrans.SetData(reader);
                    HourlyLeaveTransCollection.Add(newHourlyLeaveTrans);
                }
                HourlyLeaveTransCollection.InsertSpName = "spInsertHourlyLeaveTrans";
                HourlyLeaveTransCollection.UpdateSpName = "spUpdateHourlyLeaveTrans";
                HourlyLeaveTransCollection.DeleteSpName = "spDeleteHourlyLeaveTrans";
                return HourlyLeaveTransCollection;
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
        public static CustomList<HourlyLeaveTrans> GetAllHourlyLeaveTrans(Int32 fYKey, Int64 empKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HourlyLeaveTrans> HourlyLeaveTransCollection = new CustomList<HourlyLeaveTrans>();
            IDataReader reader = null;
            String sql = "EXEC spGetHourlyLeave " + fYKey + "," + empKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HourlyLeaveTrans newHourlyLeaveTrans = new HourlyLeaveTrans();
                    newHourlyLeaveTrans.SetData(reader);
                    HourlyLeaveTransCollection.Add(newHourlyLeaveTrans);
                }
                return HourlyLeaveTransCollection;
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
        public static CustomList<HourlyLeaveTrans> HourlyLeaveApproval()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HourlyLeaveTrans> HourlyLeaveTransCollection = new CustomList<HourlyLeaveTrans>();
            IDataReader reader = null;
            String sql = "EXEC spGetHourlyLeaveTrans";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HourlyLeaveTrans newHourlyLeaveTrans = new HourlyLeaveTrans();
                    newHourlyLeaveTrans.SetDataLeave(reader);
                    HourlyLeaveTransCollection.Add(newHourlyLeaveTrans);
                }
                return HourlyLeaveTransCollection;
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
        public static CustomList<HourlyLeaveTrans> HourlyLeaveApproval(string empKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HourlyLeaveTrans> HourlyLeaveTransCollection = new CustomList<HourlyLeaveTrans>();
            IDataReader reader = null;
            String sql = "EXEC spGetHourlyLeaveTransReportiee '" + empKey + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HourlyLeaveTrans newHourlyLeaveTrans = new HourlyLeaveTrans();
                    newHourlyLeaveTrans.SetDataLeave(reader);
                    HourlyLeaveTransCollection.Add(newHourlyLeaveTrans);
                }
                return HourlyLeaveTransCollection;
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