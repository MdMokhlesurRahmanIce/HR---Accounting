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
    public class LeaveYear : BaseItem
    {
        public LeaveYear()
        {
            SetAdded();
        }

        #region Properties

        private System.String _LeaveYearID;
        [Browsable(true), DisplayName("LeaveYearID")]
        public System.String LeaveYearID
        {
            get
            {
                return _LeaveYearID;
            }
            set
            {
                if (PropertyChanged(_LeaveYearID, value))
                    _LeaveYearID = value;
            }
        }

        private System.DateTime _StartDate;
        [Browsable(true), DisplayName("StartDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                if (PropertyChanged(_StartDate, value))
                    _StartDate = value;
            }
        }

        private System.DateTime _EndDate;
        [Browsable(true), DisplayName("EndDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                if (PropertyChanged(_EndDate, value))
                    _EndDate = value;
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

        private System.Boolean _IsClosed;
        [Browsable(true), DisplayName("IsClosed")]
        public System.Boolean IsClosed
        {
            get
            {
                return _IsClosed;
            }
            set
            {
                if (PropertyChanged(_IsClosed, value))
                    _IsClosed = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _LeaveYearID, _StartDate.Value(StaticInfo.DateFormat), _EndDate.Value(StaticInfo.DateFormat), _Remarks, _IsClosed };
            else if (IsModified)
                parameterValues = new Object[] { _LeaveYearID, _StartDate.Value(StaticInfo.DateFormat), _EndDate.Value(StaticInfo.DateFormat), _Remarks, _IsClosed };
            else if (IsDeleted)
                parameterValues = new Object[] { _LeaveYearID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _LeaveYearID = reader.GetString("LeaveYearID");
            _StartDate = reader.GetDateTime("StartDate");
            _EndDate = reader.GetDateTime("EndDate");
            _Remarks = reader.GetString("Remarks");
            _IsClosed = reader.GetBoolean("IsClosed");
            SetUnchanged();
        }
        public static CustomList<LeaveYear> GetAllLeaveYear()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<LeaveYear> LeaveYearCollection = new CustomList<LeaveYear>();
            IDataReader reader = null;
            const String sql = "select * from LeaveYear";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    LeaveYear newLeaveYear = new LeaveYear();
                    newLeaveYear.SetData(reader);
                    LeaveYearCollection.Add(newLeaveYear);
                }
                LeaveYearCollection.InsertSpName = "spInsertLeaveYear";
                LeaveYearCollection.UpdateSpName = "spUpdateLeaveYear";
                LeaveYearCollection.DeleteSpName = "spDeleteLeaveYear";
                return LeaveYearCollection;
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