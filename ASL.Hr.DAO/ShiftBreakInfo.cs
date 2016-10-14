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
    public class ShiftBreakInfo : BaseItem
    {
        public ShiftBreakInfo()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _BreakID;
        [Browsable(true), DisplayName("BreakID")]
        public System.Int64 BreakID
        {
            get
            {
                return _BreakID;
            }
            set
            {
                if (PropertyChanged(_BreakID, value))
                    _BreakID = value;
            }
        }

        private System.Int64 _ShiftId;
        [Browsable(true), DisplayName("ShiftId")]
        public System.Int64 ShiftId
        {
            get
            {
                return _ShiftId;
            }
            set
            {
                if (PropertyChanged(_ShiftId, value))
                    _ShiftId = value;
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

        private System.String _LunchInEndMargin;
        [Browsable(true), DisplayName("LunchInEndMargin")]
        public System.String LunchInEndMargin
        {
            get
            {
                return _LunchInEndMargin;
            }
            set
            {
                if (PropertyChanged(_LunchInEndMargin, value))
                    _LunchInEndMargin = value;
            }
        }

        private System.String _LunchTime;
        [Browsable(true), DisplayName("LunchTime")]
        public System.String LunchTime
        {
            get
            {
                return _LunchTime;
            }
            set
            {
                if (PropertyChanged(_LunchTime, value))
                    _LunchTime = value;
            }
        }

        private System.String _Remark;
        [Browsable(true), DisplayName("Remark")]
        public System.String Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                if (PropertyChanged(_Remark, value))
                    _Remark = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ShiftId, _LunchOutTime, _LunchInTime, _LunchInEndMargin, _LunchTime, _Remark };
            else if (IsModified)
                parameterValues = new Object[] { _BreakID, _ShiftId, _LunchOutTime, _LunchInTime, _LunchInEndMargin, _LunchTime, _Remark };
            else if (IsDeleted)
                parameterValues = new Object[] { _BreakID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _BreakID = reader.GetInt64("BreakID");
            _ShiftId = reader.GetInt32("ShiftId");
            _LunchOutTime = reader["LunchOutTime"].ToString();
            _LunchInTime = reader["LunchInTime"].ToString();
            _LunchInEndMargin = reader["LunchInEndMargin"].ToString();
            _LunchTime = reader["LunchTime"].ToString();
            _Remark = reader.GetString("Remark");
            SetUnchanged();
        }
        public static CustomList<ShiftBreakInfo> GetAllShiftBreakInfo(Int64 shiftID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ShiftBreakInfo> ShiftBreakInfoCollection = new CustomList<ShiftBreakInfo>();
            IDataReader reader = null;
            String sql = "select *from ShiftBreakInfo Where  ShiftID=" + shiftID;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ShiftBreakInfo newShiftBreakInfo = new ShiftBreakInfo();
                    newShiftBreakInfo.SetData(reader);
                    ShiftBreakInfoCollection.Add(newShiftBreakInfo);
                }
                return ShiftBreakInfoCollection;
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
