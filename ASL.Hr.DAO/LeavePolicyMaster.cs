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
    public class LeavePolicyMaster : BaseItem
    {
        public LeavePolicyMaster()
        {
            SetAdded();
        }

        #region Properties

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

        private System.String _Details;
        [Browsable(true), DisplayName("Details")]
        public System.String Details
        {
            get
            {
                return _Details;
            }
            set
            {
                if (PropertyChanged(_Details, value))
                    _Details = value;
            }
        }

        private System.String _PolicyDescription;
        [Browsable(true), DisplayName("PolicyDescription")]
        public System.String PolicyDescription
        {
            get
            {
                return _PolicyDescription;
            }
            set
            {
                if (PropertyChanged(_PolicyDescription, value))
                    _PolicyDescription = value;
            }
        }

        private System.String _LeaveCategory;
        [Browsable(true), DisplayName("LeaveCategory")]
        public System.String LeaveCategory
        {
            get
            {
                return _LeaveCategory;
            }
            set
            {
                if (PropertyChanged(_LeaveCategory, value))
                    _LeaveCategory = value;
            }
        }

        private System.Boolean _LeaveDayFixed;
        [Browsable(true), DisplayName("LeaveDayFixed")]
        public System.Boolean LeaveDayFixed
        {
            get
            {
                return _LeaveDayFixed;
            }
            set
            {
                if (PropertyChanged(_LeaveDayFixed, value))
                    _LeaveDayFixed = value;
            }
        }

        private System.Boolean _LeaveDayProp;
        [Browsable(true), DisplayName("LeaveDayProp")]
        public System.Boolean LeaveDayProp
        {
            get
            {
                return _LeaveDayProp;
            }
            set
            {
                if (PropertyChanged(_LeaveDayProp, value))
                    _LeaveDayProp = value;
            }
        }

        private System.Boolean _LeavedayBasedOnWDays;
        [Browsable(true), DisplayName("LeavedayBasedOnWDays")]
        public System.Boolean LeavedayBasedOnWDays
        {
            get
            {
                return _LeavedayBasedOnWDays;
            }
            set
            {
                if (PropertyChanged(_LeavedayBasedOnWDays, value))
                    _LeavedayBasedOnWDays = value;
            }
        }
        private System.Boolean _LeavedaysBasedOnSLength;
        [Browsable(true), DisplayName("LeavedaysBasedOnSLength")]
        public System.Boolean LeavedaysBasedOnSLength
        {
            get
            {
                return _LeavedaysBasedOnSLength;
            }
            set
            {
                if (PropertyChanged(_LeavedayBasedOnWDays, value))
                    _LeavedaysBasedOnSLength = value;
            }
        }

        private System.Boolean _LeaveAllocFixed;
        [Browsable(true), DisplayName("LeaveAllocFixed")]
        public System.Boolean LeaveAllocFixed
        {
            get
            {
                return _LeaveAllocFixed;
            }
            set
            {
                if (PropertyChanged(_LeaveAllocFixed, value))
                    _LeaveAllocFixed = value;
            }
        }

        private System.Boolean _LeaveAllocProp;
        [Browsable(true), DisplayName("LeaveAllocProp")]
        public System.Boolean LeaveAllocProp
        {
            get
            {
                return _LeaveAllocProp;
            }
            set
            {
                if (PropertyChanged(_LeaveAllocProp, value))
                    _LeaveAllocProp = value;
            }
        }

        private System.String _LeaveAllocType;
        [Browsable(true), DisplayName("LeaveAllocType")]
        public System.String LeaveAllocType
        {
            get
            {
                return _LeaveAllocType;
            }
            set
            {
                if (PropertyChanged(_LeaveAllocType, value))
                    _LeaveAllocType = value;
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

        private System.Int32 _WorkingDays;
        [Browsable(true), DisplayName("WorkingDays")]
        public System.Int32 WorkingDays
        {
            get
            {
                return _WorkingDays;
            }
            set
            {
                if (PropertyChanged(_WorkingDays, value))
                    _WorkingDays = value;
            }
        }

        private System.Int32 _LeaveDays;
        [Browsable(true), DisplayName("LeaveDays")]
        public System.Int32 LeaveDays
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

        private System.String _LeaveCalculationDepandsOn;
        [Browsable(true), DisplayName("LeaveCalculationDepandsOn")]
        public System.String LeaveCalculationDepandsOn
        {
            get
            {
                return _LeaveCalculationDepandsOn;
            }
            set
            {
                if (PropertyChanged(_LeaveCalculationDepandsOn, value))
                    _LeaveCalculationDepandsOn = value;
            }
        }

        private System.Int32 _StartAfter;
        [Browsable(true), DisplayName("StartAfter")]
        public System.Int32 StartAfter
        {
            get
            {
                return _StartAfter;
            }
            set
            {
                if (PropertyChanged(_StartAfter, value))
                    _StartAfter = value;
            }
        }

        private System.Boolean _IsCarryForword;
        [Browsable(true), DisplayName("IsCarryForword")]
        public System.Boolean IsCarryForword
        {
            get
            {
                return _IsCarryForword;
            }
            set
            {
                if (PropertyChanged(_IsCarryForword, value))
                    _IsCarryForword = value;
            }
        }

        private System.Int32 _YearlyMaxDays;
        [Browsable(true), DisplayName("YearlyMaxDays")]
        public System.Int32 YearlyMaxDays
        {
            get
            {
                return _YearlyMaxDays;
            }
            set
            {
                if (PropertyChanged(_YearlyMaxDays, value))
                    _YearlyMaxDays = value;
            }
        }

        private System.Int32 _MaxAccumulation;
        [Browsable(true), DisplayName("MaxAccumulation")]
        public System.Int32 MaxAccumulation
        {
            get
            {
                return _MaxAccumulation;
            }
            set
            {
                if (PropertyChanged(_MaxAccumulation, value))
                    _MaxAccumulation = value;
            }
        }

        private System.Boolean _IsConsecutiveLimit;
        [Browsable(true), DisplayName("IsConsecutiveLimit")]
        public System.Boolean IsConsecutiveLimit
        {
            get
            {
                return _IsConsecutiveLimit;
            }
            set
            {
                if (PropertyChanged(_IsConsecutiveLimit, value))
                    _IsConsecutiveLimit = value;
            }
        }

        private System.Int32 _ConsecutiveLimitDays;
        [Browsable(true), DisplayName("ConsecutiveLimitDays")]
        public System.Int32 ConsecutiveLimitDays
        {
            get
            {
                return _ConsecutiveLimitDays;
            }
            set
            {
                if (PropertyChanged(_ConsecutiveLimitDays, value))
                    _ConsecutiveLimitDays = value;
            }
        }

        private System.String _LeaveAllowcationProcess;
        [Browsable(true), DisplayName("LeaveAllowcationProcess")]
        public System.String LeaveAllowcationProcess
        {
            get
            {
                return _LeaveAllowcationProcess;
            }
            set
            {
                if (PropertyChanged(_LeaveAllowcationProcess, value))
                    _LeaveAllowcationProcess = value;
            }
        }

        private System.Boolean _AllowPreceedingHolidays;
        [Browsable(true), DisplayName("AllowPreceedingHolidays")]
        public System.Boolean AllowPreceedingHolidays
        {
            get
            {
                return _AllowPreceedingHolidays;
            }
            set
            {
                if (PropertyChanged(_AllowPreceedingHolidays, value))
                    _AllowPreceedingHolidays = value;
            }
        }

        private System.Boolean _AllowSucceedingHolidays;
        [Browsable(true), DisplayName("AllowSucceedingHolidays")]
        public System.Boolean AllowSucceedingHolidays
        {
            get
            {
                return _AllowSucceedingHolidays;
            }
            set
            {
                if (PropertyChanged(_AllowSucceedingHolidays, value))
                    _AllowSucceedingHolidays = value;
            }
        }

        private System.Boolean _AllowSandwitch;
        [Browsable(true), DisplayName("AllowSandwitch")]
        public System.Boolean AllowSandwitch
        {
            get
            {
                return _AllowSandwitch;
            }
            set
            {
                if (PropertyChanged(_AllowSandwitch, value))
                    _AllowSandwitch = value;
            }
        }

        private System.Boolean _IsAllowAdvanceLeave;
        [Browsable(true), DisplayName("IsAllowAdvanceLeave")]
        public System.Boolean IsAllowAdvanceLeave
        {
            get
            {
                return _IsAllowAdvanceLeave;
            }
            set
            {
                if (PropertyChanged(_IsAllowAdvanceLeave, value))
                    _IsAllowAdvanceLeave = value;
            }
        }

        private System.String _CalenderType;
        [Browsable(true), DisplayName("CalenderType")]
        public System.String CalenderType
        {
            get
            {
                return _CalenderType;
            }
            set
            {
                if (PropertyChanged(_CalenderType, value))
                    _CalenderType = value;
            }
        }

        private System.Boolean _IsHourlyLeave;
        [Browsable(true), DisplayName("IsHourlyLeave")]
        public System.Boolean IsHourlyLeave
        {
            get
            {
                return _IsHourlyLeave;
            }
            set
            {
                if (PropertyChanged(_IsHourlyLeave, value))
                    _IsHourlyLeave = value;
            }
        }

        private System.Boolean _IsHourlyLeaveAdjust;
        [Browsable(true), DisplayName("IsHourlyLeaveAdjust")]
        public System.Boolean IsHourlyLeaveAdjust
        {
            get
            {
                return _IsHourlyLeaveAdjust;
            }
            set
            {
                if (PropertyChanged(_IsHourlyLeaveAdjust, value))
                    _IsHourlyLeaveAdjust = value;
            }
        }

        private System.Decimal _AdjustedHour;
        [Browsable(true), DisplayName("AdjustedHour")]
        public System.Decimal AdjustedHour
        {
            get
            {
                return _AdjustedHour;
            }
            set
            {
                if (PropertyChanged(_AdjustedHour, value))
                    _AdjustedHour = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _LeaveType, _PolicyDescription, _LeaveCategory, _LeaveDayFixed, _LeaveDayProp, _LeavedayBasedOnWDays,_LeavedaysBasedOnSLength, _LeaveAllocFixed, _LeaveAllocProp, _LeaveAllocType, _DayStatus, _WorkingDays, _LeaveDays, _LeaveCalculationDepandsOn, _StartAfter, _IsCarryForword, _YearlyMaxDays, _MaxAccumulation, _IsConsecutiveLimit, _ConsecutiveLimitDays, _LeaveAllowcationProcess, _AllowPreceedingHolidays, _AllowSucceedingHolidays, _AllowSandwitch, _IsAllowAdvanceLeave, _CalenderType, _IsHourlyLeave, _IsHourlyLeaveAdjust, _AdjustedHour, _AddedBy, _DateAdded.Value(StaticInfo.DateFormat), _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat) };
            else if (IsModified)
                parameterValues = new Object[] {_LeavePolicyID , _LeaveType, _PolicyDescription, _LeaveCategory, _LeaveDayFixed, _LeaveDayProp, _LeavedayBasedOnWDays, _LeavedaysBasedOnSLength, _LeaveAllocFixed, _LeaveAllocProp, _LeaveAllocType, _DayStatus, _WorkingDays, _LeaveDays, _LeaveCalculationDepandsOn, _StartAfter, _IsCarryForword, _YearlyMaxDays, _MaxAccumulation, _IsConsecutiveLimit, _ConsecutiveLimitDays, _LeaveAllowcationProcess, _AllowPreceedingHolidays, _AllowSucceedingHolidays, _AllowSandwitch, _IsAllowAdvanceLeave, _CalenderType, _IsHourlyLeave, _IsHourlyLeaveAdjust, _AdjustedHour, _AddedBy, _DateAdded.Value(StaticInfo.DateFormat), _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat) };
            else if (IsDeleted)
                parameterValues = new Object[] { _LeavePolicyID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _LeavePolicyID = reader.GetInt32("LeavePolicyID");
            _LeaveType = reader.GetString("LeaveType");
            _PolicyDescription = reader.GetString("PolicyDescription");
            _LeaveCategory = reader.GetString("LeaveCategory");
            _LeaveDayFixed = reader.GetBoolean("LeaveDayFixed");
            _LeaveDayProp = reader.GetBoolean("LeaveDayProp");
            _LeavedayBasedOnWDays = reader.GetBoolean("LeavedayBasedOnWDays");
            _LeavedaysBasedOnSLength = reader.GetBoolean("LeavedaysBasedOnSLength");
            _LeaveAllocFixed = reader.GetBoolean("LeaveAllocFixed");
            _LeaveAllocProp = reader.GetBoolean("LeaveAllocProp");
            _LeaveAllocType = reader.GetString("LeaveAllocType");
            _DayStatus = reader.GetString("DayStatus");
            _WorkingDays = reader.GetInt32("WorkingDays");
            _LeaveDays = reader.GetInt32("LeaveDays");
            _LeaveCalculationDepandsOn = reader.GetString("LeaveCalculationDepandsOn");
            _StartAfter = reader.GetInt32("StartAfter");
            _IsCarryForword = reader.GetBoolean("IsCarryForword");
            _YearlyMaxDays = reader.GetInt32("YearlyMaxDays");
            _MaxAccumulation = reader.GetInt32("MaxAccumulation");
            _IsConsecutiveLimit = reader.GetBoolean("IsConsecutiveLimit");
            _ConsecutiveLimitDays = reader.GetInt32("ConsecutiveLimitDays");
            _LeaveAllowcationProcess = reader.GetString("LeaveAllowcationProcess");
            _AllowPreceedingHolidays = reader.GetBoolean("AllowPreceedingHolidays");
            _AllowSucceedingHolidays = reader.GetBoolean("AllowSucceedingHolidays");
            _AllowSandwitch = reader.GetBoolean("AllowSandwitch");
            _IsAllowAdvanceLeave = reader.GetBoolean("IsAllowAdvanceLeave");
            _CalenderType = reader.GetString("CalenderType");
            _IsHourlyLeave = reader.GetBoolean("IsHourlyLeave");
            _IsHourlyLeaveAdjust = reader.GetBoolean("IsHourlyLeaveAdjust");
            _AdjustedHour = reader.GetDecimal("AdjustedHour");
            _AddedBy = reader.GetString("AddedBy");
            _DateAdded = reader.GetDateTime("DateAdded");
            _UpdatedBy = reader.GetString("UpdatedBy");
            _UpdatedDate = reader.GetDateTime("UpdatedDate");
            _Details = reader.GetString("Details");
            SetUnchanged();
        }
        public static CustomList<LeavePolicyMaster> GetAllLeavePolicyMaster()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeavePolicyMaster> LeavePolicyMasterCollection = new CustomList<LeavePolicyMaster>();
            IDataReader reader = null;
            String sql = "exec spGetAllLeavePolicyInfo";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeavePolicyMaster newLeavePolicyMaster = new LeavePolicyMaster();
                    newLeavePolicyMaster.SetData(reader);
                    LeavePolicyMasterCollection.Add(newLeavePolicyMaster);
                }
                LeavePolicyMasterCollection.InsertSpName = "spInsertLeavePolicyMaster";
                LeavePolicyMasterCollection.UpdateSpName = "spUpdateLeavePolicyMaster";
                LeavePolicyMasterCollection.DeleteSpName = "spDeleteLeavePolicyMaster";
                return LeavePolicyMasterCollection;
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
        public static CustomList<LeavePolicyMaster> GetSelectedLeavePolicyMaster( int leavePolicyid)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeavePolicyMaster> LeavePolicyMasterCollection = new CustomList<LeavePolicyMaster>();
            IDataReader reader = null;
            String sql = "exec spGetSelectedLeavePolicyInfo "+ leavePolicyid;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeavePolicyMaster newLeavePolicyMaster = new LeavePolicyMaster();
                    newLeavePolicyMaster.SetData(reader);
                    LeavePolicyMasterCollection.Add(newLeavePolicyMaster);
                }
                LeavePolicyMasterCollection.InsertSpName = "spInsertLeavePolicyMaster";
                LeavePolicyMasterCollection.UpdateSpName = "spUpdateLeavePolicyMaster";
                LeavePolicyMasterCollection.DeleteSpName = "spDeleteLeavePolicyMaster";
                return LeavePolicyMasterCollection;
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
        public static CustomList<LeavePolicyMaster> GetLeaveType()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeavePolicyMaster> LeavePolicyMasterCollection = new CustomList<LeavePolicyMaster>();
            IDataReader reader = null;
            String sql = "select LeavePolicyID,LeaveType From LeavePolicyMaster";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeavePolicyMaster newLeavePolicyMaster = new LeavePolicyMaster();
                    newLeavePolicyMaster.LeavePolicyID = reader.GetInt32("LeavePolicyID");
                    newLeavePolicyMaster.LeaveType = reader.GetString("LeaveType");
                    LeavePolicyMasterCollection.Add(newLeavePolicyMaster);
                }
                return LeavePolicyMasterCollection;
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