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
    public class ShiftPlan : BaseItem
    {
        public ShiftPlan()
        {
            SetAdded();
        }

        #region Properties

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

        private System.Int32 _ShiftType;
        [Browsable(true), DisplayName("ShiftType")]
        public System.Int32 ShiftType
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

        private System.String _Description;
        [Browsable(true), DisplayName("Description")]
        public System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (PropertyChanged(_Description, value))
                    _Description = value;
            }
        }

        private System.Boolean _IsActive;
        [Browsable(true), DisplayName("IsActive")]
        public System.Boolean IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                if (PropertyChanged(_IsActive, value))
                    _IsActive = value;
            }
        }

        private System.Boolean _IsDefault;
        [Browsable(true), DisplayName("IsDefault")]
        public System.Boolean IsDefault
        {
            get
            {
                return _IsDefault;
            }
            set
            {
                if (PropertyChanged(_IsDefault, value))
                    _IsDefault = value;
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

        private System.String _ShiftInStartMargin;
        [Browsable(true), DisplayName("ShiftInStartMargin")]
        public System.String ShiftInStartMargin
        {
            get
            {
                return _ShiftInStartMargin;
            }
            set
            {
                if (PropertyChanged(_ShiftInStartMargin, value))
                    _ShiftInStartMargin = value;
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

        private System.String _ShiftOutEndMargin;
        [Browsable(true), DisplayName("ShiftOutEndMargin")]
        public System.String ShiftOutEndMargin
        {
            get
            {
                return _ShiftOutEndMargin;
            }
            set
            {
                if (PropertyChanged(_ShiftOutEndMargin, value))
                    _ShiftOutEndMargin = value;
            }
        }

        private System.String _AbsentEndmargin;
        [Browsable(true), DisplayName("AbsentEndmargin")]
        public System.String AbsentEndmargin
        {
            get
            {
                return _AbsentEndmargin;
            }
            set
            {
                if (PropertyChanged(_AbsentEndmargin, value))
                    _AbsentEndmargin = value;
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

        private System.String _EarlyOutMargin;
        [Browsable(true), DisplayName("EarlyOutMargin")]
        public System.String EarlyOutMargin
        {
            get
            {
                return _EarlyOutMargin;
            }
            set
            {
                if (PropertyChanged(_EarlyOutMargin, value))
                    _EarlyOutMargin = value;
            }
        }

        private System.Boolean _IsAutoCalculate;
        [Browsable(true), DisplayName("IsAutoCalculate")]
        public System.Boolean IsAutoCalculate
        {
            get
            {
                return _IsAutoCalculate;
            }
            set
            {
                if (PropertyChanged(_IsAutoCalculate, value))
                    _IsAutoCalculate = value;
            }
        }

        private System.Boolean _IsProcessInSameDate;
        [Browsable(true), DisplayName("IsProcessInSameDate")]
        public System.Boolean IsProcessInSameDate
        {
            get
            {
                return _IsProcessInSameDate;
            }
            set
            {
                if (PropertyChanged(_IsProcessInSameDate, value))
                    _IsProcessInSameDate = value;
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

        private System.String _Type;
        [Browsable(true), DisplayName("Type")]
        public System.String Type
        {
            get
            {
                return _Type;
            }
            set
            {
                if (PropertyChanged(_Type, value))
                    _Type = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ShiftType, _ALISE, _Description, _IsActive, _IsDefault, _ShiftIntime, _ShiftInStartMargin, _ShiftOutTime, _ShiftOutEndMargin, _AbsentEndmargin, _LateMargin, _EarlyOutMargin, _IsAutoCalculate, _IsProcessInSameDate };
            else if (IsModified)
                parameterValues = new Object[] { _ShiftID, _ShiftType, _ALISE, _Description, _IsActive, _IsDefault, _ShiftIntime, _ShiftInStartMargin, _ShiftOutTime, _ShiftOutEndMargin, _AbsentEndmargin, _LateMargin, _EarlyOutMargin, _IsAutoCalculate, _IsProcessInSameDate };
            else if (IsDeleted)
                parameterValues = new Object[] { _ShiftID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ShiftID = reader.GetInt32("ShiftID");
            _ShiftType = reader.GetInt32("ShiftType");
            _ALISE = reader.GetString("ALISE");
            _Description = reader.GetString("Description");
            _IsActive = reader.GetBoolean("IsActive");
            _IsDefault = reader.GetBoolean("IsDefault");
            _ShiftIntime = reader.GetString("ShiftIntime");
            _ShiftInStartMargin = reader.GetString("ShiftInStartMargin");
            _ShiftOutTime = reader.GetString("ShiftOutTime");
            _ShiftOutEndMargin = reader.GetString("ShiftOutEndMargin");
            _AbsentEndmargin = reader.GetString("AbsentEndmargin");
            _LateMargin = reader.GetString("LateMargin");
            _EarlyOutMargin = reader.GetString("EarlyOutMargin");
            _IsAutoCalculate = reader.GetBoolean("IsAutoCalculate");
            _IsProcessInSameDate = reader.GetBoolean("IsProcessInSameDate");
            SetUnchanged();
        }
        private void SetDataShiftRoster(IDataRecord reader)
        {
            _ShiftID = reader.GetInt32("ShiftID");
            _ALISE = reader.GetString("ALISE");
            _ShiftIntime = reader.GetString("ShiftIntime");
            _ShiftOutTime = reader.GetString("ShiftOutTime");
            SetUnchanged();
        }
        private void SetDataShift(IDataRecord reader)
        {
            _ShiftID = reader.GetInt32("ShiftID");
            _ALISE = reader.GetString("ALISE");
            SetUnchanged();
        }
        public static CustomList<ShiftPlan> GetAllShiftPlan()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ShiftPlan> ShiftPlanCollection = new CustomList<ShiftPlan>();
            IDataReader reader = null;
            const String sql = "select * from ShiftPlan";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ShiftPlan newShiftPlan = new ShiftPlan();
                    newShiftPlan.SetData(reader);
                    ShiftPlanCollection.Add(newShiftPlan);
                }
                ShiftPlanCollection.InsertSpName = "spInsertShiftPlan";
                ShiftPlanCollection.UpdateSpName = "spUpdateShiftPlan";
                ShiftPlanCollection.DeleteSpName = "spDeleteShiftPlan";
                return ShiftPlanCollection;
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
        public static CustomList<ShiftPlan> GetAllShiftPlanShiftRoster()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ShiftPlan> ShiftPlanCollection = new CustomList<ShiftPlan>();
            IDataReader reader = null;
            const String sql = "select * from ShiftPlan";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ShiftPlan newShiftPlan = new ShiftPlan();
                    newShiftPlan.SetDataShiftRoster(reader);
                    ShiftPlanCollection.Add(newShiftPlan);
                }
                return ShiftPlanCollection;
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
        public static CustomList<ShiftPlan> GetAllShift()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ShiftPlan> ShiftPlanCollection = new CustomList<ShiftPlan>();
            IDataReader reader = null;
            const String sql = "select ShiftID,ALISE from ShiftPlan";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ShiftPlan newShiftPlan = new ShiftPlan();
                    newShiftPlan.SetDataShift(reader);
                    ShiftPlanCollection.Add(newShiftPlan);
                }
                return ShiftPlanCollection;
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
