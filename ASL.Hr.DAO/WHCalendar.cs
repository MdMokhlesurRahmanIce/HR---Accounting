using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using System.Web;
using System.Text;

namespace ASL.Hr.DAO
{
    [Serializable]
    public class WHCalendar : BaseItem
    {
        public WHCalendar()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _CalendarKey;
        [Browsable(true), DisplayName("CalendarKey")]
        public System.Int64 CalendarKey
        {
            get
            {
                return _CalendarKey;
            }
            set
            {
                if (PropertyChanged(_CalendarKey, value))
                    _CalendarKey = value;
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

        private System.DateTime _WorkOffDate;
        [Browsable(true), DisplayName("WorkOffDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime WorkOffDate
        {
            get
            {
                return _WorkOffDate;
            }
            set
            {
                if (PropertyChanged(_WorkOffDate, value))
                    _WorkOffDate = value;
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

        private System.String _Shift;
        [Browsable(true), DisplayName("Shift")]
        public System.String Shift
        {
            get
            {
                return _Shift;
            }
            set
            {
                if (PropertyChanged(_Shift, value))
                    _Shift = value;
            }
        }

        private System.String _DayType;
        [Browsable(true), DisplayName("DayType")]
        public System.String DayType
        {
            get
            {
                return _DayType;
            }
            set
            {
                if (PropertyChanged(_DayType, value))
                    _DayType = value;
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

        private System.Boolean _IsFake;
        [Browsable(true), DisplayName("IsFake")]
        public System.Boolean IsFake
        {
            get
            {
                return _IsFake;
            }
            set
            {
                if (PropertyChanged(_IsFake, value))
                    _IsFake = value;
            }
        }

        private System.DateTime _Date;
        [Browsable(true), DisplayName("Date"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                if (PropertyChanged(_Date, value))
                    _Date = value;
            }
        }

        private System.String _DateName;
        [Browsable(true), DisplayName("DateName")]
        public System.String DateName
        {
            get
            {
                return _DateName;
            }
            set
            {
                if (PropertyChanged(_DateName, value))
                    _DateName = value;
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

        private System.String _PunchCardNo;
        [Browsable(true), DisplayName("PunchCardNo")]
        public System.String PunchCardNo
        {
            get
            {
                return _PunchCardNo;
            }
            set
            {
                if (PropertyChanged(_PunchCardNo, value))
                    _PunchCardNo = value;
            }
        }

        private System.DateTime _DOJ;
        [Browsable(true), DisplayName("DOJ")]
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

        private System.Boolean _IsSaved;
        [Browsable(true), DisplayName("IsSaved")]
        public System.Boolean IsSaved
        {
            get
            {
                return _IsSaved;
            }
            set
            {
                if (PropertyChanged(_IsSaved, value))
                    _IsSaved = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _WorkOffDate.Value(StaticInfo.DateFormat), _ShiftID, _DayType, _Remarks, _IsFake };
            else if (IsModified)
                parameterValues = new Object[] {_CalendarKey, _EmpKey, _WorkOffDate.Value(StaticInfo.DateFormat), _ShiftID, _DayType, _Remarks, _IsFake };
            else if (IsDeleted)
                parameterValues = new Object[] { _CalendarKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _CalendarKey = reader.GetInt64("CalendarKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _WorkOffDate = reader.GetDateTime("WorkOffDate");
            _ShiftID = reader.GetString("ShiftID");
            _DayType = reader.GetString("DayType");
            _Remarks = reader.GetString("Remarks");
            _IsFake = reader.GetBoolean("IsFake");
            SetUnchanged();
        }
        private void SetDataForWHCalendar(IDataRecord reader)
        {
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            _Designation = reader.GetString("Designation");
            _ShiftID = reader.GetString("ShiftID");
            _Shift = reader.GetString("Shift");
            _PunchCardNo = reader.GetString("PunchCardNo");
            _Department = reader.GetString("Department");
            SetUnchanged();
        }
        public static CustomList<WHCalendar> GetAllWHCalendar(string fromDate,string toDate,string dayType)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<WHCalendar> WHCalendarCollection = new CustomList<WHCalendar>();
            IDataReader reader = null;
            String sql = "EXEC spGetCalendarInfo '" + fromDate + "','" + toDate + "','" + dayType+"'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    WHCalendar newWHCalendar = new WHCalendar();
                    newWHCalendar.SetData(reader);
                    WHCalendarCollection.Add(newWHCalendar);
                }
                return WHCalendarCollection;
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
        public static CustomList<WHCalendar> GetAllEmpWHCalendar()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<WHCalendar> WHCalendarCollection = new CustomList<WHCalendar>();
            string search = String.Empty;
            StringBuilder searchArg;
            searchArg = (StringBuilder)HttpContext.Current.Session[StaticInfo.SearchArg];
            if (searchArg != null) //return WHCalendarCollection;
            {
                search = searchArg.ToString();
                search = search.Length > 0 ? search.Substring(0, search.Length - 1) : string.Empty;
            }

            IDataReader reader = null;
            String sql = "EXEC spGetEmpForSearch1" + search;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    WHCalendar newWHCalendar = new WHCalendar();
                    newWHCalendar.SetDataForWHCalendar(reader);
                    WHCalendarCollection.Add(newWHCalendar);
                }
                return WHCalendarCollection;
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
        public static Int32 IsWH(Int64 empKey,string workDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Int32 isWorkOff = 0;
            try
            {
                String sql = "SELECT Count(*) FROM WHCalendar Where WorkOffDate=Cast('" + workDate + "' as Date) AND EmpKey="+empKey;
                Object empCount = conManager.ExecuteScalarWrapper(sql);
                isWorkOff = Convert.ToInt32(empCount);
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
            return isWorkOff;
        }
        public static Int32 IsLeave(Int64 empKey, string workDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Int32 isWorkOff = 0;
            try
            {
                String sql = " SELECT Count(*) FROM LeaveTransApproved Where (Cast('" + workDate + "' as Date) BETWEEN FromDate AND ToDate) AND IsApproved=1 AND EmpKey=" + empKey;
                Object empCount = conManager.ExecuteScalarWrapper(sql);
                isWorkOff = Convert.ToInt32(empCount);
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
            return isWorkOff;
        }

    }
}
