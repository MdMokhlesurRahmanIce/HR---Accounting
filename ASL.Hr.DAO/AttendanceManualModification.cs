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
    public class AttendanceManualModification : BaseItem
    {
        public AttendanceManualModification()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _ModificationID;
        [Browsable(true), DisplayName("ModificationID")]
        public System.Int64 ModificationID
        {
            get
            {
                return _ModificationID;
            }
            set
            {
                if (PropertyChanged(_ModificationID, value))
                    _ModificationID = value;
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
        private System.DateTime _Workdate;
        [Browsable(true), DisplayName("Workdate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime Workdate
        {
            get
            {
                return _Workdate;
            }
            set
            {
                if (PropertyChanged(_Workdate, value))
                    _Workdate = value;
            }
        }

        private System.Int32? _ShiftID;
        [Browsable(true), DisplayName("ShiftID")]
        public System.Int32? ShiftID
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

        private System.String _Alias;
        [Browsable(true), DisplayName("Alias")]
        public System.String Alias
        {
            get
            {
                return _Alias;
            }
            set
            {
                if (PropertyChanged(_Alias, value))
                    _Alias = value;
            }
        }

        private System.String _InTime;
        [Browsable(true), DisplayName("InTime")]
        public System.String InTime
        {
            get
            {
                return _InTime;
            }
            set
            {
                if (PropertyChanged(_InTime, value))
                    _InTime = value;
            }
        }

        private System.String _ShiftInTime;
        [Browsable(true), DisplayName("ShiftInTime")]
        public System.String ShiftInTime
        {
            get
            {
                return _ShiftInTime;
            }
            set
            {
                if (PropertyChanged(_ShiftInTime, value))
                    _ShiftInTime = value;
            }
        }

        private System.String _OutTime;
        [Browsable(true), DisplayName("OutTime")]
        public System.String OutTime
        {
            get
            {
                return _OutTime;
            }
            set
            {
                if (PropertyChanged(_OutTime, value))
                    _OutTime = value;
            }
        }

        private System.String _ShiftOutTime;
        [Browsable(true), DisplayName("ShiftOutTime")]
        public System.String ShiftOutTime
        {
            get
            {
                return _ShiftOutTime;
            }
            set
            {
                if (PropertyChanged(_ShiftOutTime, value))
                    _ShiftOutTime = value;
            }
        }

        private System.String _LateMargin;
        [Browsable(true), DisplayName("LateMargin")]
        public System.String LateMargin
        {
            get
            {
                return _LateMargin;
            }
            set
            {
                if (PropertyChanged(_LateMargin, value))
                    _LateMargin = value;
            }
        }

        private System.String _DayStatus;
        [Browsable(true), DisplayName("DayStatus")]
        public System.String DayStatus
        {
            get
            {
                return _DayStatus;
            }
            set
            {
                if (PropertyChanged(_DayStatus, value))
                    _DayStatus = value;
            }
        }

        private System.String _AdditionalStatus;
        [Browsable(true), DisplayName("AdditionalStatus")]
        public System.String AdditionalStatus
        {
            get
            {
                return _AdditionalStatus;
            }
            set
            {
                if (PropertyChanged(_AdditionalStatus, value))
                    _AdditionalStatus = value;
            }
        }

        private System.Decimal _OT;
        [Browsable(true), DisplayName("OT")]
        public System.Decimal OT
        {
            get
            {
                return _OT;
            }
            set
            {
                if (PropertyChanged(_OT, value))
                    _OT = value;
            }
        }

        private System.String _CShiftID;
        [Browsable(true), DisplayName("CShiftID")]
        public System.String CShiftID
        {
            get
            {
                return _CShiftID;
            }
            set
            {
                if (PropertyChanged(_CShiftID, value))
                    _CShiftID = value;
            }
        }

        private System.String _CInTime;
        [Browsable(true), DisplayName("CInTime")]
        public System.String CInTime
        {
            get
            {
                return _CInTime;
            }
            set
            {
                if (PropertyChanged(_CInTime, value))
                    _CInTime = value;
            }
        }

        private System.String _COutTime;
        [Browsable(true), DisplayName("COutTime")]
        public System.String COutTime
        {
            get
            {
                return _COutTime;
            }
            set
            {
                if (PropertyChanged(_COutTime, value))
                    _COutTime = value;
            }
        }

        private System.String _CDayStatus;
        [Browsable(true), DisplayName("CDayStatus")]
        public System.String CDayStatus
        {
            get
            {
                return _CDayStatus;
            }
            set
            {
                if (PropertyChanged(_CDayStatus, value))
                    _CDayStatus = value;
            }
        }

        private System.String _CAdditionalStatus;
        [Browsable(true), DisplayName("CAdditionalStatus")]
        public System.String CAdditionalStatus
        {
            get
            {
                return _CAdditionalStatus;
            }
            set
            {
                if (PropertyChanged(_CAdditionalStatus, value))
                    _CAdditionalStatus = value;
            }
        }

        private System.Decimal _COT;
        [Browsable(true), DisplayName("COT")]
        public System.Decimal COT
        {
            get
            {
                return _COT;
            }
            set
            {
                if (PropertyChanged(_COT, value))
                    _COT = value;
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

        private System.String _ApprovedDate;
        [Browsable(true), DisplayName("ApprovedDate")]
        public System.String ApprovedDate
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

        private System.Boolean _IsChecked;
        [Browsable(true), DisplayName("IsChecked")]
        public System.Boolean IsChecked
        {
            get
            {
                return _IsChecked;
            }
            set
            {
                if (PropertyChanged(_IsChecked, value))
                    _IsChecked = value;
            }
        }
        private System.Decimal _LateHour;
        [Browsable(true), DisplayName("LateHour")]
        public System.Decimal LateHour
        {
            get
            {
                return _LateHour;
            }
            set
            {
                if (PropertyChanged(_LateHour, value))
                    _LateHour = value;
            }
        }

        private System.Decimal _EarlyOutHour;
        [Browsable(true), DisplayName("EarlyOutHour")]
        public System.Decimal EarlyOutHour
        {
            get
            {
                return _EarlyOutHour;
            }
            set
            {
                if (PropertyChanged(_EarlyOutHour, value))
                    _EarlyOutHour = value;
            }
        }

        private System.Decimal _PayHour;
        [Browsable(true), DisplayName("PayHour")]
        public System.Decimal PayHour
        {
            get
            {
                return _PayHour;
            }
            set
            {
                if (PropertyChanged(_PayHour, value))
                    _PayHour = value;
            }
        }

        private System.Decimal _OTHour;
        [Browsable(true), DisplayName("OTHour")]
        public System.Decimal OTHour
        {
            get
            {
                return _OTHour;
            }
            set
            {
                if (PropertyChanged(_OTHour, value))
                    _OTHour = value;
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
        private System.String _InDate;
        [Browsable(true), DisplayName("InDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.String InDate
        {
            get
            {
                return _InDate;
            }
            set
            {
                if (PropertyChanged(_InDate, value))
                    _InDate = value;
            }
        }

        private System.String _OutDate;
        [Browsable(true), DisplayName("OutDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.String OutDate
        {
            get
            {
                return _OutDate;
            }
            set
            {
                if (PropertyChanged(_OutDate, value))
                    _OutDate = value;
            }
        }

        private System.String _CInDate;
        [Browsable(true), DisplayName("CInDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.String CInDate
        {
            get
            {
                return _CInDate;
            }
            set
            {
                if (PropertyChanged(_CInDate, value))
                    _CInDate = value;
            }
        }

        private System.String _COutDate;
        [Browsable(true), DisplayName("COutDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.String COutDate
        {
            get
            {
                return _COutDate;
            }
            set
            {
                if (PropertyChanged(_COutDate, value))
                    _COutDate = value;
            }
        }

        private System.String _LunchOutTime;
        [Browsable(true), DisplayName("LunchOutTime")]
        public System.String LunchOutTime
        {
            get
            {
                return _LunchOutTime;
            }
            set
            {
                if (PropertyChanged(_LunchOutTime, value))
                    _LunchOutTime = value;
            }
        }

        private System.String _LunchInTime;
        [Browsable(true), DisplayName("LunchInTime")]
        public System.String LunchInTime
        {
            get
            {
                return _LunchInTime;
            }
            set
            {
                if (PropertyChanged(_LunchInTime, value))
                    _LunchInTime = value;
            }
        }
        private System.Boolean _IsDeleted;
        [Browsable(true), DisplayName("IsDeleted")]
        public System.Boolean IsDeleted
        {
            get
            {
                return _IsDeleted;
            }
            set
            {
                if (PropertyChanged(_IsDeleted, value))
                    _IsDeleted = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _Workdate, _ShiftID, _InDate, _InTime, _OutDate, _OutTime, _DayStatus, _AdditionalStatus, _OT, _CShiftID, _CInDate, _CInTime, _COutDate, _COutTime, _CDayStatus, _CAdditionalStatus, _COT, _Remarks,_LunchOutTime,_LunchInTime, _AddedBy, _ApprovedBy, _AddedDate.Value(StaticInfo.DateFormat), _ApprovedDate, _IsDeleted };
            else if (IsModified)
                parameterValues = new Object[] { _ModificationID, _ApprovedBy, _ApprovedDate, _IsDeleted};
            else if (IsDeleted)
                parameterValues = new Object[] { _EmpKey, _Workdate, _ShiftID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ModificationID = reader.GetInt64("ModificationID");
            _EmpKey = reader.GetInt64("EmpKey");
            _Workdate = reader.GetDateTime("Workdate");
            _ShiftID = reader.GetInt32("ShiftID");
            _InTime = reader.GetString("InTime");
            _OutTime = reader.GetString("OutTime");
            _DayStatus = reader.GetString("DayStatus");
            _AdditionalStatus = reader.GetString("AdditionalStatus");
            _OT = reader.GetDecimal("OT");
            _CShiftID = reader.GetString("CShiftID");
            _CInTime = reader.GetString("CInTime");
            _COutTime = reader.GetString("COutTime");
            _CDayStatus = reader.GetString("CDayStatus");
            _CAdditionalStatus = reader.GetString("CAdditionalStatus");
            _COT = reader.GetDecimal("COT");
            _AddedBy = reader.GetString("AddedBy");
            _ApprovedBy = reader.GetString("ApprovedBy");
            _AddedDate = reader.GetDateTime("AddedDate");
            _ApprovedDate = reader.GetString("ApprovedDate");
            SetUnchanged();
        }
        private void SetDataManul(IDataRecord reader)
        {
            //_ModificationID = reader.GetInt64("ModificationID");
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            _Workdate = reader.GetDateTime("Workdate");
            _ShiftID = reader.GetInt32("ShiftID");
            _InTime = reader.GetString("InTime");
            _OutTime = reader.GetString("OutTime");
            _CInTime = reader.GetString("CInTime");
            _COutTime = reader.GetString("COutTime");
            _OTHour = reader.GetDecimal("OTHour");
            _DayStatus = reader.GetString("DayStatus");
            _InDate = reader.GetString("InDate");
            _OutDate = reader.GetString("OutDate");
            _CInDate = reader.GetString("CInDate");
            _COutDate = reader.GetString("COutDate");
            _LunchInTime = reader.GetString("LunchInTime");
            _LunchOutTime = reader.GetString("LunchOutTime");
            SetUnchanged();
        }

        private void SetDataManulApp(IDataRecord reader)
        {
            _ModificationID = reader.GetInt64("ModificationID");
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            _Workdate = reader.GetDateTime("Workdate");
            _ShiftID = reader.GetInt32("ShiftID");
            _InTime = reader.GetString("InTime");
            _OutTime = reader.GetString("OutTime");
            _DayStatus = reader.GetString("DayStatus");
            _OT = reader.GetDecimal("OT");
            _CInTime = reader.GetString("CInTime");
            _COutTime = reader.GetString("COutTime");
            _CDayStatus = reader.GetString("CDayStatus");
            _COT = reader.GetDecimal("COT");
            _LateHour = reader.GetDecimal("LateHour");
            _EarlyOutHour = reader.GetDecimal("EarlyOutHour");
            _PayHour = reader.GetDecimal("PayHour");
            _OTHour = reader.GetDecimal("OTHour");
            _DayStatus = reader.GetString("DayStatus");
            _AddedBy = reader.GetString("AddedBy").Trim();
            _IsDeleted = reader.GetBoolean("IsDeleted");
            SetUnchanged();
        }
        public static CustomList<AttendanceManualModification> GetAllAttendanceManualModification()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<AttendanceManualModification> AttendanceManualModificationCollection = new CustomList<AttendanceManualModification>();
            IDataReader reader = null;
            const String sql = "select *from AttendanceManualModification";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    AttendanceManualModification newAttendanceManualModification = new AttendanceManualModification();
                    newAttendanceManualModification.SetData(reader);
                    AttendanceManualModificationCollection.Add(newAttendanceManualModification);
                }
                AttendanceManualModificationCollection.InsertSpName = "spInsertAttendanceManualModification";
                AttendanceManualModificationCollection.UpdateSpName = "spUpdateAttendanceManualModification";
                AttendanceManualModificationCollection.DeleteSpName = "spDeleteAttendanceManualModification";
                return AttendanceManualModificationCollection;
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
        public static CustomList<AttendanceManualModification> GetAllAttForManualProcess(string spName, string fromDate, string toDate, string str)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<AttendanceManualModification> DailyAttendanceCollection = new CustomList<AttendanceManualModification>();
            string search = String.Empty;
            search = CommonHelper.CreateSearchString();
            search = "'" + search + "'";
            if (str != "")
            {
                
            }

            IDataReader reader = null;
            try
            {
                String sql = "EXEC " + spName + " '" + fromDate + "','" + toDate + "'," + search + ",'" + str + "'";
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    AttendanceManualModification newAttendance = new AttendanceManualModification();
                    newAttendance.SetDataManul(reader);
                    DailyAttendanceCollection.Add(newAttendance);
                }
                return DailyAttendanceCollection;
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
        public static CustomList<AttendanceManualModification> GetEmpAttManualApproved(string fromDate, string toDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<AttendanceManualModification> DailyAttendanceCollection = new CustomList<AttendanceManualModification>();
            string search = String.Empty;
            search = CommonHelper.CreateSearchString();
            IDataReader reader = null;
            try
            {
                String sql = "EXEC spGetEmpAttManual '" + fromDate + "','" + toDate + "','" + search + "'";
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    AttendanceManualModification newAttendance = new AttendanceManualModification();
                    newAttendance.SetDataManulApp(reader);
                    DailyAttendanceCollection.Add(newAttendance);
                }
                return DailyAttendanceCollection;
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