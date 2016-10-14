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
    public class OTAssignment : BaseItem
    {
        public OTAssignment()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _OTAssignmentKey;
        [Browsable(true), DisplayName("OTAssignmentKey")]
        public System.Int32 OTAssignmentKey
        {
            get
            {
                return _OTAssignmentKey;
            }
            set
            {
                if (PropertyChanged(_OTAssignmentKey, value))
                    _OTAssignmentKey = value;
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

        private System.DateTime _WorkDate;
        [Browsable(true), DisplayName("WorkDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime WorkDate
        {
            get
            {
                return _WorkDate;
            }
            set
            {
                if (PropertyChanged(_WorkDate, value))
                    _WorkDate = value;
            }
        }

        private System.String _OTType;
        [Browsable(true), DisplayName("OTType")]
        public System.String OTType
        {
            get
            {
                return _OTType;
            }
            set
            {
                if (PropertyChanged(_OTType, value))
                    _OTType = value;
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

        private System.Int32 _StaffCategoryKey;
        [Browsable(true), DisplayName("StaffCategoryKey")]
        public System.Int32 StaffCategoryKey
        {
            get
            {
                return _StaffCategoryKey;
            }
            set
            {
                if (PropertyChanged(_StaffCategoryKey, value))
                    _StaffCategoryKey = value;
            }
        }

        private System.String _DesigName;
        [Browsable(true), DisplayName("DesigName")]
        public System.String DesigName
        {
            get
            {
                return _DesigName;
            }
            set
            {
                if (PropertyChanged(_DesigName, value))
                    _DesigName = value;
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

        private System.Boolean _IsAssignOTOnly;
        [Browsable(true), DisplayName("IsAssignOTOnly")]
        public System.Boolean IsAssignOTOnly
        {
            get
            {
                return _IsAssignOTOnly;
            }
            set
            {
                if (PropertyChanged(_IsAssignOTOnly, value))
                    _IsAssignOTOnly = value;
            }
        }

        private System.Boolean _IsPunchOTOnly;
        [Browsable(true), DisplayName("IsPunchOTOnly")]
        public System.Boolean IsPunchOTOnly
        {
            get
            {
                return _IsPunchOTOnly;
            }
            set
            {
                if (PropertyChanged(_IsPunchOTOnly, value))
                    _IsPunchOTOnly = value;
            }
        }

        private System.Boolean _IsHigher;
        [Browsable(true), DisplayName("IsHigher")]
        public System.Boolean IsHigher
        {
            get
            {
                return _IsHigher;
            }
            set
            {
                if (PropertyChanged(_IsHigher, value))
                    _IsHigher = value;
            }
        }

        private System.Boolean _IsLower;
        [Browsable(true), DisplayName("IsLower")]
        public System.Boolean IsLower
        {
            get
            {
                return _IsLower;
            }
            set
            {
                if (PropertyChanged(_IsLower, value))
                    _IsLower = value;
            }
        }

        private System.Decimal _PreviousOT;
        [Browsable(true), DisplayName("PreviousOT")]
        public System.Decimal PreviousOT
        {
            get
            {
                return _PreviousOT;
            }
            set
            {
                if (PropertyChanged(_PreviousOT, value))
                    _PreviousOT = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey, _WorkDate.Value(StaticInfo.DateFormat), _OTType, _OTHour, _IsAssignOTOnly, _IsPunchOTOnly, _IsHigher, _IsLower, _PreviousOT, _IsApproved };
            else if (IsModified)
                parameterValues = new Object[] { _OTAssignmentKey, _EmpKey, _WorkDate.Value(StaticInfo.DateFormat), _OTType, _OTHour, _IsAssignOTOnly, _IsPunchOTOnly, _IsHigher, _IsLower, _PreviousOT, _IsApproved };
            else if (IsDeleted)
                parameterValues = new Object[] { _EmpKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _OTAssignmentKey = reader.GetInt32("OTAssignmentKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _WorkDate = reader.GetDateTime("WorkDate");
            _OTType = reader.GetString("OTType");
            _OTHour = reader.GetDecimal("OTHour");
            _IsAssignOTOnly = reader.GetBoolean("IsAssignOTOnly");
            _IsPunchOTOnly = reader.GetBoolean("IsPunchOTOnly");
            _IsHigher = reader.GetBoolean("IsHigher");
            _IsLower = reader.GetBoolean("IsLower");
            _PreviousOT = reader.GetDecimal("PreviousOT");
            _IsApproved = reader.GetBoolean("IsApproved");
            SetUnchanged();
        }
        private void SetDataOTApproval(IDataRecord reader)
        {
            _OTAssignmentKey = reader.GetInt32("OTAssignmentKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            _Shift = reader.GetString("Shift");
            _WorkDate = reader.GetDateTime("WorkDate");
            _OTType = reader.GetString("OTType");
            _OTHour = reader.GetDecimal("OTHour");
            _PreviousOT = reader.GetDecimal("PreviousOT");
            _IsChecked = reader.GetBoolean("IsChecked");
            _IsApproved = reader.GetBoolean("IsApproved");
            SetUnchanged();
        }
        public static CustomList<OTAssignment> GetAllOTAssignment(string fromDate, string toDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<OTAssignment> OTAssignmentCollection = new CustomList<OTAssignment>();
            string search = String.Empty;
            search = CommonHelper.CreateSearchString();
            search = "@StrSearch='" + search + "'";

            IDataReader reader = null;
            String sql = "EXEC spGetEmpAssignOT '" +fromDate+"','"+toDate+"'," + search;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    OTAssignment newOTAssignment = new OTAssignment();
                    newOTAssignment.SetDataOTApproval(reader);
                    OTAssignmentCollection.Add(newOTAssignment);
                }
                OTAssignmentCollection.InsertSpName = "spInsertOTAssignment";
                OTAssignmentCollection.UpdateSpName = "spUpdateOTAssignment";
                OTAssignmentCollection.DeleteSpName = "spDeleteOTAssignment";
                return OTAssignmentCollection;
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
