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
    public class SkillInfo : BaseItem
    {
        public SkillInfo()
        {
            SetAdded();
        }

        #region Properties

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

        private System.String _SkillCategory;
        [Browsable(true), DisplayName("SkillCategory")]
        public System.String SkillCategory
        {
            get
            {
                return _SkillCategory;
            }
            set
            {
                if (PropertyChanged(_SkillCategory, value))
                    _SkillCategory = value;
            }
        }

        private System.String _SkillArea;
        [Browsable(true), DisplayName("SkillArea")]
        public System.String SkillArea
        {
            get
            {
                return _SkillArea;
            }
            set
            {
                if (PropertyChanged(_SkillArea, value))
                    _SkillArea = value;
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

        private System.String _ProcessName;
        [Browsable(true), DisplayName("ProcessName")]
        public System.String ProcessName
        {
            get
            {
                return _ProcessName;
            }
            set
            {
                if (PropertyChanged(_ProcessName, value))
                    _ProcessName = value;
            }
        }

        private System.String _OperationType;
        [Browsable(true), DisplayName("OperationType")]
        public System.String OperationType
        {
            get
            {
                return _OperationType;
            }
            set
            {
                if (PropertyChanged(_OperationType, value))
                    _OperationType = value;
            }
        }

        private System.Decimal _SMV;
        [Browsable(true), DisplayName("SMV")]
        public System.Decimal SMV
        {
            get
            {
                return _SMV;
            }
            set
            {
                if (PropertyChanged(_SMV, value))
                    _SMV = value;
            }
        }

        private System.Decimal _InternalTarget;
        [Browsable(true), DisplayName("InternalTarget")]
        public System.Decimal InternalTarget
        {
            get
            {
                return _InternalTarget;
            }
            set
            {
                if (PropertyChanged(_InternalTarget, value))
                    _InternalTarget = value;
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
                parameterValues = new Object[] { _SkillCategory, _SkillArea, _Description, _ProcessName, _OperationType, _SMV, _InternalTarget, _AddedBy, _AddedDate.Value(StaticInfo.DateFormat), _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat) };
            else if (IsModified)
                parameterValues = new Object[] { _SkillCategory, _SkillArea, _Description, _ProcessName, _OperationType, _SMV, _InternalTarget, _AddedBy, _AddedDate.Value(StaticInfo.DateFormat), _UpdatedBy, _UpdatedDate.Value(StaticInfo.DateFormat) };
            else if (IsDeleted)
                parameterValues = new Object[] { _SkillID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _SkillID = reader.GetInt64("SkillID");
            _SkillCategory = reader.GetString("SkillCategory");
            _SkillArea = reader.GetString("SkillArea");
            _Description = reader.GetString("Description");
            _ProcessName = reader.GetString("ProcessName");
            _OperationType = reader.GetString("OperationType");
            _SMV = reader.GetDecimal("SMV");
            _InternalTarget = reader.GetDecimal("InternalTarget");
            _AddedBy = reader.GetString("AddedBy");
            _AddedDate = reader.GetDateTime("AddedDate");
            _UpdatedBy = reader.GetString("UpdatedBy");
            _UpdatedDate = reader.GetDateTime("UpdatedDate");
            SetUnchanged();
        }
        public static CustomList<SkillInfo> GetAllSkillInfo()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SkillInfo> SkillInfoCollection = new CustomList<SkillInfo>();
            IDataReader reader = null;
            const String sql = "select * from SKILLINFO";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SkillInfo newSkillInfo = new SkillInfo();
                    newSkillInfo.SetData(reader);
                    SkillInfoCollection.Add(newSkillInfo);
                }
                SkillInfoCollection.InsertSpName = "spInsertSkillInfo";
                SkillInfoCollection.UpdateSpName = "spUpdateSkillInfo";
                SkillInfoCollection.DeleteSpName = "spDeleteSkillInfo";
                return SkillInfoCollection;
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