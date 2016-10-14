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
    public class SeparationGrid : BaseItem
    {
        public SeparationGrid()
        {
            SetAdded();
        }

        #region Properties

        private System.String _EmployeeCode;
        [Browsable(true), DisplayName("EmployeeCode")]
        public System.String EmployeeCode
        {
            get
            {
                return _EmployeeCode;
            }
            set
            {
                if (PropertyChanged(_EmployeeCode, value))
                    _EmployeeCode = value;
            }
        }

        private System.String _EmployeeName;
        [Browsable(true), DisplayName("EmployeeName")]
        public System.String EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
            set
            {
                if (PropertyChanged(_EmployeeName, value))
                    _EmployeeName = value;
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

        private System.Int64 _SeparationID;
        [Browsable(true), DisplayName("SeparationID")]
        public System.Int64 SeparationID
        {
            get
            {
                return _SeparationID;
            }
            set
            {
                if (PropertyChanged(_SeparationID, value))
                    _SeparationID = value;
            }
        }

        private System.Int64 _EmployeeKey;
        [Browsable(true), DisplayName("EmployeeKey")]
        public System.Int64 EmployeeKey
        {
            get
            {
                return _EmployeeKey;
            }
            set
            {
                if (PropertyChanged(_EmployeeKey, value))
                    _EmployeeKey = value;
            }
        }

        private System.String _SeparationCause;
        [Browsable(true), DisplayName("SeparationCause")]
        public System.String SeparationCause
        {
            get
            {
                return _SeparationCause;
            }
            set
            {
                if (PropertyChanged(_SeparationCause, value))
                    _SeparationCause = value;
            }
        }

        private System.String _AdditionalRemarks;
        [Browsable(true), DisplayName("AdditionalRemarks")]
        public System.String AdditionalRemarks
        {
            get
            {
                return _AdditionalRemarks;
            }
            set
            {
                if (PropertyChanged(_AdditionalRemarks, value))
                    _AdditionalRemarks = value;
            }
        }

        private System.String _Notes;
        [Browsable(true), DisplayName("Notes")]
        public System.String Notes
        {
            get
            {
                return _Notes;
            }
            set
            {
                if (PropertyChanged(_Notes, value))
                    _Notes = value;
            }
        }

        private System.DateTime _EffectiveDate;
        [Browsable(true), DisplayName("EffectiveDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime EffectiveDate
        {
            get
            {
                return _EffectiveDate;
            }
            set
            {
                if (PropertyChanged(_EffectiveDate, value))
                    _EffectiveDate = value;
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

        private System.String _Action;
        [Browsable(true), DisplayName("Action")]
        public System.String Action
        {
            get
            {
                return _Action;
            }
            set
            {
                if (PropertyChanged(_Action, value))
                    _Action = value;
            }
        }

        private System.Boolean _IsEffected;
        [Browsable(true), DisplayName("IsEffected")]
        public System.Boolean IsEffected
        {
            get
            {
                return _IsEffected;
            }
            set
            {
                if (PropertyChanged(_IsEffected, value))
                    _IsEffected = value;
            }
        }

        private System.Boolean _IsBlackListed;
        [Browsable(true), DisplayName("IsBlackListed")]
        public System.Boolean IsBlackListed
        {
            get
            {
                return _IsBlackListed;
            }
            set
            {
                if (PropertyChanged(_IsBlackListed, value))
                    _IsBlackListed = value;
            }
        }

        private System.String _BlackListCause;
        [Browsable(true), DisplayName("BlackListCause")]
        public System.String BlackListCause
        {
            get
            {
                return _BlackListCause;
            }
            set
            {
                if (PropertyChanged(_BlackListCause, value))
                    _BlackListCause = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmployeeKey, _SeparationCause, _AdditionalRemarks, _Notes, _EffectiveDate.Value(StaticInfo.DateFormat), _ApprovedBy, _ApprovedDate.Value(StaticInfo.DateFormat), _AddedBy, _AddedDate.Value(StaticInfo.DateFormat), _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat), _Action, _IsEffected, _IsBlackListed, _BlackListCause };
            else if (IsModified)
                parameterValues = new Object[] { _SeparationID, _EmployeeKey, _SeparationCause, _AdditionalRemarks, _Notes, _EffectiveDate.Value(StaticInfo.DateFormat), _ApprovedBy, _ApprovedDate.Value(StaticInfo.DateFormat), _AddedBy, _AddedDate.Value(StaticInfo.DateFormat), _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat), _Action, _IsEffected, _IsBlackListed, _BlackListCause };
            else if (IsDeleted)
                parameterValues = new Object[] { _SeparationID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _SeparationID = reader.GetInt64("SeparationID");
            _EmployeeKey = reader.GetInt64("EmployeeKey");
            _SeparationCause = reader.GetString("SeparationCause");
            _AdditionalRemarks = reader.GetString("AdditionalRemarks");
            _Notes = reader.GetString("Notes");
            _EffectiveDate = reader.GetDateTime("EffectiveDate");
            _ApprovedBy = reader.GetString("ApprovedBy");
            _ApprovedDate = reader.GetDateTime("ApprovedDate");
            _AddedBy = reader.GetString("AddedBy");
            _AddedDate = reader.GetDateTime("AddedDate");
            _UpdatedBy = reader.GetString("UpdatedBy");
            _UpdatedDate = reader.GetDateTime("UpdatedDate");
            _Action = reader.GetString("Action");
            _IsEffected = reader.GetBoolean("IsEffected");
            _IsBlackListed = reader.GetBoolean("IsBlackListed");
            _BlackListCause = reader.GetString("BlackListCause");
            SetUnchanged();
        }
        public static CustomList<SeparationGrid> GetAllSeparationGrid()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SeparationGrid> SeparationGridCollection = new CustomList<SeparationGrid>();
            IDataReader reader = null;
            const String sql = "exec spProcSeparationGrid";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SeparationGrid newSeparationGrid = new SeparationGrid();
                    newSeparationGrid.SetData(reader);
                    SeparationGridCollection.Add(newSeparationGrid);
                }
                SeparationGridCollection.InsertSpName = "spInsertSeparationGrid";
                SeparationGridCollection.UpdateSpName = "spUpdateSeparationGrid";
                SeparationGridCollection.DeleteSpName = "spDeleteSeparationGrid";
                return SeparationGridCollection;
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
        public static CustomList<SeparationGrid> GetAllUnapprovedSeparation()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SeparationGrid> SeparationCollection = new CustomList<SeparationGrid>();
            IDataReader reader = null;
            const String sql = "select * from Separation Where ApprovedBy IS NULL And ApprovedDate IS NULL";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SeparationGrid newSeparation = new SeparationGrid();
                    newSeparation.SetData(reader);
                    SeparationCollection.Add(newSeparation);
                }
                SeparationCollection.InsertSpName = "spInsertSeparation";
                SeparationCollection.UpdateSpName = "spUpdateSeparation";
                SeparationCollection.DeleteSpName = "spDeleteSeparation";
                return SeparationCollection;
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