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
    public class DailyAttendance : BaseItem
    {
        public DailyAttendance()
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

        private System.Int64 _RowID;
        [Browsable(true), DisplayName("RowID")]
        public System.Int64 RowID
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

        private System.Int64 _AttKey;
        [Browsable(true), DisplayName("AttKey")]
        public System.Int64 AttKey
        {
            get
            {
                return _AttKey;
            }
            set
            {
                if (PropertyChanged(_AttKey, value))
                    _AttKey = value;
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

        private System.String _ShiftID;
        [Browsable(true), DisplayName("ShiftID")]
        public System.String ShiftID
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

        private System.Decimal _Slab_01;
        [Browsable(true), DisplayName("Slab_01")]
        public System.Decimal Slab_01
        {
            get
            {
                return _Slab_01;
            }
            set
            {
                if (PropertyChanged(_Slab_01, value))
                    _Slab_01 = value;
            }
        }

        private System.Decimal _Slab_02;
        [Browsable(true), DisplayName("Slab_02")]
        public System.Decimal Slab_02
        {
            get
            {
                return _Slab_02;
            }
            set
            {
                if (PropertyChanged(_Slab_02, value))
                    _Slab_02 = value;
            }
        }

        private System.Decimal _Slab_03;
        [Browsable(true), DisplayName("Slab_03")]
        public System.Decimal Slab_03
        {
            get
            {
                return _Slab_03;
            }
            set
            {
                if (PropertyChanged(_Slab_03, value))
                    _Slab_03 = value;
            }
        }

        private System.Decimal _Slab_04;
        [Browsable(true), DisplayName("Slab_04")]
        public System.Decimal Slab_04
        {
            get
            {
                return _Slab_04;
            }
            set
            {
                if (PropertyChanged(_Slab_04, value))
                    _Slab_04 = value;
            }
        }

        private System.Decimal _Slab_05;
        [Browsable(true), DisplayName("Slab_05")]
        public System.Decimal Slab_05
        {
            get
            {
                return _Slab_05;
            }
            set
            {
                if (PropertyChanged(_Slab_05, value))
                    _Slab_05 = value;
            }
        }

        private System.Boolean _IsDefaultShift;
        [Browsable(true), DisplayName("IsDefaultShift")]
        public System.Boolean IsDefaultShift
        {
            get
            {
                return _IsDefaultShift;
            }
            set
            {
                if (PropertyChanged(_IsDefaultShift, value))
                    _IsDefaultShift = value;
            }
        }

        private System.Boolean _IsManual;
        [Browsable(true), DisplayName("IsManual")]
        public System.Boolean IsManual
        {
            get
            {
                return _IsManual;
            }
            set
            {
                if (PropertyChanged(_IsManual, value))
                    _IsManual = value;
            }
        }

        private System.Boolean _IsConsistant;
        [Browsable(true), DisplayName("IsConsistant")]
        public System.Boolean IsConsistant
        {
            get
            {
                return _IsConsistant;
            }
            set
            {
                if (PropertyChanged(_IsConsistant, value))
                    _IsConsistant = value;
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

        private System.String _ModificationID;
        [Browsable(true), DisplayName("ModificationID")]
        public System.String ModificationID
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

        private System.String _ALISE;
        [Browsable(true), DisplayName("ALISE")]
        public System.String ALISE
        {
            get
            {
                return _ALISE;
            }
            set
            {
                if (PropertyChanged(_ALISE, value))
                    _ALISE = value;
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
        private System.String _PTime;
        [Browsable(true), DisplayName("PTime")]
        public System.String PTime
        {
            get
            {
                return _PTime;
            }
            set
            {
                if (PropertyChanged(_PTime, value))
                    _PTime = value;
            }
        }
        private System.String _ShiftIntime;
        [Browsable(true), DisplayName("ShiftIntime")]
        public System.String ShiftIntime
        {
            get
            {
                return _ShiftIntime;
            }
            set
            {
                if (PropertyChanged(_ShiftIntime, value))
                    _ShiftIntime = value;
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

        private System.Boolean _IsProcessed;
        [Browsable(true), DisplayName("IsProcessed")]
        public System.Boolean IsProcessed
        {
            get
            {
                return _IsProcessed;
            }
            set
            {
                if (PropertyChanged(_IsProcessed, value))
                    _IsProcessed = value;
            }
        }

        private System.String _ShiftType;
        [Browsable(true), DisplayName("ShiftType")]
        public System.String ShiftType
        {
            get
            {
                return _ShiftType;
            }
            set
            {
                if (PropertyChanged(_ShiftType, value))
                    _ShiftType = value;
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
                parameterValues = new Object[] { _EmpKey, _Workdate.Value(StaticInfo.DateFormat), _ShiftID, _InTime, _OutTime, _LateHour, _EarlyOutHour, _PayHour, _OTHour, _DayStatus, _AdditionalStatus, _Slab_01, _Slab_02, _Slab_03, _Slab_04, _Slab_05, _IsDefaultShift, _IsManual, _IsConsistant, _ModificationID,_Remarks };
            else if (IsModified)
                parameterValues = new Object[] { _AttKey, _EmpKey, _Workdate.Value(StaticInfo.DateFormat), _ShiftID, _InTime, _OutTime, _LateHour, _EarlyOutHour, _PayHour, _OTHour, _DayStatus, _AdditionalStatus, _Slab_01, _Slab_02, _Slab_03, _Slab_04, _Slab_05, _IsDefaultShift, _IsManual, _IsConsistant, _ModificationID,_Remarks };
            else if (IsDeleted)
                parameterValues = new Object[] { _AttKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _AttKey = reader.GetInt64("AttKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _Workdate = reader.GetDateTime("Workdate");
            _ShiftID = reader.GetString("ShiftID");
            _InTime = reader.GetString("InTime");
            _OutTime = reader.GetString("OutTime");
            _LateHour = reader.GetDecimal("LateHour");
            _EarlyOutHour = reader.GetDecimal("EarlyOutHour");
            _IsManual = reader.GetBoolean("IsManual");
            _IsProcessed = reader.GetBoolean("IsProcessed");
            SetUnchanged();
        }
        private void SetDataAtt(IDataRecord reader)
        {
            _RowID = reader.GetInt64("RowID");
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            _Designation = reader.GetString("Designation");
            _Department = reader.GetString("Department");
            _Workdate = reader.GetDateTime("Workdate");
            _ShiftID = reader.GetString("ShiftID");
            _ShiftType = reader.GetString("ShiftType");
            _ShiftIntime = reader.GetString("ShiftIntime");
            _ShiftOutTime = reader.GetString("ShiftOutTime");
            _InTime = reader.GetString("InTime");
            _OutTime = reader.GetString("OutTime");
            _LateHour = reader.GetDecimal("LateHour");
            _EarlyOutHour = reader.GetDecimal("EarlyOutHour");
            _PayHour = reader.GetDecimal("PayHour");
            _OTHour = reader.GetDecimal("OTHour");
            _LateMargin = reader.GetString("LateMargin");
            _DayStatus = reader.GetString("DayStatus");
            _AdditionalStatus = reader.GetString("AdditionalStatus");
            _Slab_01 = reader.GetDecimal("Slab_01");
            _Slab_02 = reader.GetDecimal("Slab_02");
            _Slab_03 = reader.GetDecimal("Slab_03");
            _Slab_04 = reader.GetDecimal("Slab_04");
            _Slab_05 = reader.GetDecimal("Slab_05");
            SetUnchanged();
        }
        public static CustomList<DailyAttendance> GetAllDailyAttendance()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<DailyAttendance> DailyAttendanceCollection = new CustomList<DailyAttendance>();
            IDataReader reader = null;
            const String sql = "select *from DailyAttendance";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    DailyAttendance newDailyAttendance = new DailyAttendance();
                    newDailyAttendance.SetData(reader);
                    DailyAttendanceCollection.Add(newDailyAttendance);
                }
                DailyAttendanceCollection.InsertSpName = "spInsertDailyAttendance";
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
        public static CustomList<DailyAttendance> GetAllAttForDailyAttendanceProcess(string fromDate, string toDate, string searchStr, string PW, string PH, string PLV, string SinglePunch)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<DailyAttendance> DailyAttendanceCollection = new CustomList<DailyAttendance>();
            /*string search = String.Empty;
            search = CommonHelper.CreateSearchString();
            if (search != "")
            {
                search = search.Length > 0 ? search.Substring(0, search.Length - 1) : string.Empty;
                search = "@FromDate='" + fromDate + "',@ToDate='" + toDate + "'," + search;
            }
            else
            {
                search = "@FromDate='" + fromDate + "',@ToDate='" + toDate + "'," + search;
                search = search.Length > 0 ? search.Substring(0, search.Length - 1) : string.Empty;
            }
            search = search + ",@SearchStr='" + searchStr + "'";
            */
    
            IDataReader reader = null;
            try
            {
                String sql = "EXEC spAttendanceProcess '" + fromDate + "','" + toDate + "','" + searchStr + "','" + PW + "','" + PH + "','" + PLV + "','" + SinglePunch+ "'";
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    DailyAttendance newAttendance = new DailyAttendance();
                    newAttendance.SetDataAtt(reader);
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
        public static string GetDayStatus(Int64 empKey, int shiftID, string workDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            string status = "";
            try
            {
                String sql = "EXEC [GetDayStatus] " + empKey + "," + shiftID + ",'" + workDate + "'";
                Object dayStatus = conManager.ExecuteScalarWrapper(sql);
                status = Convert.ToString(dayStatus);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
            return status;
        }
    }
}

