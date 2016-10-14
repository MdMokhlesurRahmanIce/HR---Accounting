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
    public class EmployeeSkillInfo : BaseItem
    {
        public EmployeeSkillInfo()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _ID;
        [Browsable(true), DisplayName("ID")]
        public System.Int64 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (PropertyChanged(_ID, value))
                    _ID = value;
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

        private System.Int64 _SkillID;
        [Browsable(true), DisplayName("SkillID")]
        public System.Int64 SkillID
        {
            get
            {
                return _SkillID;
            }
            set
            {
                if (PropertyChanged(_SkillID, value))
                    _SkillID = value;
            }
        }

        private System.String _InitialCapacity;
        [Browsable(true), DisplayName("InitialCapacity")]
        public System.String InitialCapacity
        {
            get
            {
                return _InitialCapacity;
            }
            set
            {
                if (PropertyChanged(_InitialCapacity, value))
                    _InitialCapacity = value;
            }
        }

        private System.String _CurrentCapacity;
        [Browsable(true), DisplayName("CurrentCapacity")]
        public System.String CurrentCapacity
        {
            get
            {
                return _CurrentCapacity;
            }
            set
            {
                if (PropertyChanged(_CurrentCapacity, value))
                    _CurrentCapacity = value;
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

        private System.String _ReviewPeriod;
        [Browsable(true), DisplayName("ReviewPeriod")]
        public System.String ReviewPeriod
        {
            get
            {
                return _ReviewPeriod;
            }
            set
            {
                if (PropertyChanged(_ReviewPeriod, value))
                    _ReviewPeriod = value;
            }
        }

        private System.DateTime _ReviewDate;
        [Browsable(true), DisplayName("ReviewDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime ReviewDate
        {
            get
            {
                return _ReviewDate;
            }
            set
            {
                if (PropertyChanged(_ReviewDate, value))
                    _ReviewDate = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ID, _EmpKey, _SkillID, _InitialCapacity, _CurrentCapacity, _Remarks, _ReviewPeriod, _ReviewDate.Value(StaticInfo.DateFormat), _AddedBy, _AddedDate.Value(StaticInfo.DateFormat), _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat) };
            else if (IsModified)
                parameterValues = new Object[] { _ID, _EmpKey, _SkillID, _InitialCapacity, _CurrentCapacity, _Remarks, _ReviewPeriod, _ReviewDate.Value(StaticInfo.DateFormat), _AddedBy, _AddedDate.Value(StaticInfo.DateFormat), _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat) };
            else if (IsDeleted)
                parameterValues = new Object[] { _ID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ID = reader.GetInt64("ID");
            _EmpKey = reader.GetInt64("EmpKey");
            _SkillID = reader.GetInt64("SkillID");
            _InitialCapacity = reader.GetString("InitialCapacity");
            _CurrentCapacity = reader.GetString("CurrentCapacity");
            _Remarks = reader.GetString("Remarks");
            _ReviewPeriod = reader.GetString("ReviewPeriod");
            _ReviewDate = reader.GetDateTime("ReviewDate");
            _AddedBy = reader.GetString("AddedBy");
            _AddedDate = reader.GetDateTime("AddedDate");
            _UpdatedBy = reader.GetString("UpdatedBy");
            _UpdatedDate = reader.GetDateTime("UpdatedDate");
            SetUnchanged();
        }
        public static CustomList<EmployeeSkillInfo> GetAllEmployeeSkillInfo()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<EmployeeSkillInfo> EmployeeSkillInfoCollection = new CustomList<EmployeeSkillInfo>();
            IDataReader reader = null;
            const String sql = "select *from EmployeeSkillInfo";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    EmployeeSkillInfo newEmployeeSkillInfo = new EmployeeSkillInfo();
                    newEmployeeSkillInfo.SetData(reader);
                    EmployeeSkillInfoCollection.Add(newEmployeeSkillInfo);
                }
                EmployeeSkillInfoCollection.InsertSpName = "spInsertEmployeeSkillInfo";
                EmployeeSkillInfoCollection.UpdateSpName = "spUpdateEmployeeSkillInfo";
                EmployeeSkillInfoCollection.DeleteSpName = "spDeleteEmployeeSkillInfo";
                return EmployeeSkillInfoCollection;
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