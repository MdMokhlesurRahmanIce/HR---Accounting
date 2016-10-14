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
    public class ShiftRoster : BaseItem
    {
        public ShiftRoster()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _ShiftRosterKey;
        [Browsable(true), DisplayName("ShiftRosterKey")]
        public System.Int64 ShiftRosterKey
        {
            get
            {
                return _ShiftRosterKey;
            }
            set
            {
                if (PropertyChanged(_ShiftRosterKey, value))
                    _ShiftRosterKey = value;
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

        private System.DateTime _ShiftDate;
        [Browsable(true), DisplayName("ShiftDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime ShiftDate
        {
            get
            {
                return _ShiftDate;
            }
            set
            {
                if (PropertyChanged(_ShiftDate, value))
                    _ShiftDate = value;
            }
        }

        private System.Int64 _ShiftID;
        [Browsable(true), DisplayName("ShiftID")]
        public System.Int64 ShiftID
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
        private System.String _ModifiedOrApprovedFlag;
        [Browsable(true), DisplayName("ModifiedOrApprovedFlag")]
        public System.String ModifiedOrApprovedFlag
        {
            get
            {
                return _ModifiedOrApprovedFlag;
            }
            set
            {
                if (PropertyChanged(_ModifiedOrApprovedFlag, value))
                    _ModifiedOrApprovedFlag = value;
            }
        }

        private System.Boolean _IsDelete;
        [Browsable(true), DisplayName("IsDelete")]
        public System.Boolean IsDelete
        {
            get
            {
                return _IsDelete;
            }
            set
            {
                if (PropertyChanged(_IsDelete, value))
                    _IsDelete = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] {  _EmpKey, _ShiftDate.Value(StaticInfo.DateFormat), _ShiftID, _Type, _IsApproved };
            else if (IsModified)
                parameterValues = new Object[] { _ShiftRosterKey,_EmpKey, _ShiftDate.Value(StaticInfo.DateFormat), _ShiftID, _Type, _IsApproved };
            else if (IsDeleted)
                parameterValues = new Object[] { _ShiftRosterKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ShiftRosterKey = reader.GetInt64("ShiftRosterKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _ShiftDate = reader.GetDateTime("ShiftDate");
            _ShiftID = reader.GetInt64("ShiftID");
            _Type = reader.GetString("Type");
            _IsApproved = reader.GetBoolean("IsApproved");
            SetUnchanged();
        }
        private void SetDataShiftRoster(IDataRecord reader)
        {
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            _Designation = reader.GetString("Designation");
            _ShiftDate = reader.GetDateTime("ShiftDate");
            _ShiftID = reader.GetInt64("ShiftID");
            _ShiftType = reader.GetString("ShiftType");
            _ALISE = reader.GetString("ALISE");
            _Type = reader.GetString("Type");
            _IsApproved = reader.GetBoolean("IsApproved");
            
            SetUnchanged();
        }
        public static CustomList<ShiftRoster> GetAllShiftRoster()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ShiftRoster> ShiftRosterCollection = new CustomList<ShiftRoster>();
            IDataReader reader = null;
            const String sql = "select *from ShiftRoster";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ShiftRoster newShiftRoster = new ShiftRoster();
                    newShiftRoster.SetData(reader);
                    ShiftRosterCollection.Add(newShiftRoster);
                }
                ShiftRosterCollection.InsertSpName = "spInsertShiftRoster";
                ShiftRosterCollection.UpdateSpName = "spUpdateShiftRoster";
                ShiftRosterCollection.DeleteSpName = "spDeleteShiftRoster";
                return ShiftRosterCollection;
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
        public static CustomList<ShiftRoster> ProcessShiftRoster(string fromDate, string toDate, string tableName)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ShiftRoster> ShiftRosterCollection = new CustomList<ShiftRoster>();
            string search = String.Empty;
            search = CommonHelper.CreateSearchString();
            search = "@FromDate='" + fromDate + "',@ToDate='" + toDate + "'," + search;
            search = search.Length > 0 ? search.Substring(0, search.Length - 1) : string.Empty;


            IDataReader reader = null;
            String sql = "exec spShiftRosterProcessByShaikat '" + fromDate + "','" + toDate + "','" + tableName + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ShiftRoster newShiftRoster = new ShiftRoster();
                    newShiftRoster.SetDataShiftRoster(reader);
                    ShiftRosterCollection.Add(newShiftRoster);
                }
                ShiftRosterCollection.InsertSpName = "spInsertShiftRoster";
                ShiftRosterCollection.UpdateSpName = "spUpdateShiftRoster";
                ShiftRosterCollection.DeleteSpName = "spDeleteShiftRoster";
                return ShiftRosterCollection;
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
        public static CustomList<ShiftRoster> DeleteExistingShiftRoster(string fromDate, string toDate, string tableName)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ShiftRoster> ShiftRosterCollection = new CustomList<ShiftRoster>();
  


            IDataReader reader = null;
            String sql = "exec spDeleteExistingShiftRoster '" + fromDate + "','" + toDate + "','" + tableName + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                   // ShiftRoster newShiftRoster = new ShiftRoster();
                   // newShiftRoster.SetDataShiftRoster(reader);
                   // ShiftRosterCollection.Add(newShiftRoster);
                }
                ShiftRosterCollection.InsertSpName = "spInsertShiftRoster";
                ShiftRosterCollection.UpdateSpName = "spUpdateShiftRoster";
                ShiftRosterCollection.DeleteSpName = "spDeleteShiftRoster";
                return ShiftRosterCollection;
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
        public static CustomList<ShiftRoster> GetAllProcessedShiftRoster(string fromDate, string toDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ShiftRoster> ShiftRosterCollection = new CustomList<ShiftRoster>();
            string search = String.Empty;
            search = CommonHelper.CreateSearchString();
            search = "@FromDate='" + fromDate + "',@ToDate='" + toDate + "'," + search;
            search = search.Length > 0 ? search.Substring(0, search.Length - 1) : string.Empty;


            IDataReader reader = null;
            String sql = "EXEC spGetShiftSRosteredEmp " + search;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ShiftRoster newShiftRoster = new ShiftRoster();
                    newShiftRoster.SetDataShiftRoster(reader);
                    ShiftRosterCollection.Add(newShiftRoster);
                }
                ShiftRosterCollection.InsertSpName = "spInsertShiftRoster";
                ShiftRosterCollection.UpdateSpName = "spUpdateShiftRoster";
                ShiftRosterCollection.DeleteSpName = "spDeleteShiftRoster";
                return ShiftRosterCollection;
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