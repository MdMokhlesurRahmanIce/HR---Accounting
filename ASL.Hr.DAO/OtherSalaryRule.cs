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
    public class OtherSalaryRule : BaseItem
    {
        public OtherSalaryRule()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _RuleKey;
        [Browsable(true), DisplayName("RuleKey")]
        public System.Int32 RuleKey
        {
            get
            {
                return _RuleKey;
            }
            set
            {
                if (PropertyChanged(_RuleKey, value))
                    _RuleKey = value;
            }
        }

        private System.String _RuleName;
        [Browsable(true), DisplayName("RuleName")]
        public System.String RuleName
        {
            get
            {
                return _RuleName;
            }
            set
            {
                if (PropertyChanged(_RuleName, value))
                    _RuleName = value;
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

        private System.Boolean _IsAttBased;
        [Browsable(true), DisplayName("IsAttBased")]
        public System.Boolean IsAttBased
        {
            get
            {
                return _IsAttBased;
            }
            set
            {
                if (PropertyChanged(_IsAttBased, value))
                    _IsAttBased = value;
            }
        }

        private System.String _EffectedSalaryHeadID;
        [Browsable(true), DisplayName("EffectedSalaryHeadID")]
        public System.String EffectedSalaryHeadID
        {
            get
            {
                return _EffectedSalaryHeadID;
            }
            set
            {
                if (PropertyChanged(_EffectedSalaryHeadID, value))
                    _EffectedSalaryHeadID = value;
            }
        }

        private System.String _sCriteria;
        [Browsable(true), DisplayName("sCriteria")]
        public System.String sCriteria
        {
            get
            {
                return _sCriteria;
            }
            set
            {
                if (PropertyChanged(_sCriteria, value))
                    _sCriteria = value;
            }
        }

        private System.String _SalaryHeadID;
        [Browsable(true), DisplayName("SalaryHeadID")]
        public System.String SalaryHeadID
        {
            get
            {
                return _SalaryHeadID;
            }
            set
            {
                if (PropertyChanged(_SalaryHeadID, value))
                    _SalaryHeadID = value;
            }
        }

        private System.Boolean _IsFixed;
        [Browsable(true), DisplayName("IsFixed")]
        public System.Boolean IsFixed
        {
            get
            {
                return _IsFixed;
            }
            set
            {
                if (PropertyChanged(_IsFixed, value))
                    _IsFixed = value;
            }
        }

        private System.Decimal _Amount;
        [Browsable(true), DisplayName("Amount")]
        public System.Decimal Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                if (PropertyChanged(_Amount, value))
                    _Amount = value;
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

        private System.Int32 _DivisibleFactorType;
        [Browsable(true), DisplayName("DivisibleFactorType")]
        public System.Int32 DivisibleFactorType
        {
            get
            {
                return _DivisibleFactorType;
            }
            set
            {
                if (PropertyChanged(_DivisibleFactorType, value))
                    _DivisibleFactorType = value;
            }
        }

        private System.Int32 _Factor;
        [Browsable(true), DisplayName("Factor")]
        public System.Int32 Factor
        {
            get
            {
                return _Factor;
            }
            set
            {
                if (PropertyChanged(_Factor, value))
                    _Factor = value;
            }
        }

        private System.Decimal _Days;
        [Browsable(true), DisplayName("Days")]
        public System.Decimal Days
        {
            get
            {
                return _Days;
            }
            set
            {
                if (PropertyChanged(_Days, value))
                    _Days = value;
            }
        }

        private System.Boolean _IsWExclude;
        [Browsable(true), DisplayName("IsWExclude")]
        public System.Boolean IsWExclude
        {
            get
            {
                return _IsWExclude;
            }
            set
            {
                if (PropertyChanged(_IsWExclude, value))
                    _IsWExclude = value;
            }
        }

        private System.Boolean _IsHExclude;
        [Browsable(true), DisplayName("IsHExclude")]
        public System.Boolean IsHExclude
        {
            get
            {
                return _IsHExclude;
            }
            set
            {
                if (PropertyChanged(_IsHExclude, value))
                    _IsHExclude = value;
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

        private System.DateTime _DateApproved;
        [Browsable(true), DisplayName("DateApproved"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DateApproved
        {
            get
            {
                return _DateApproved;
            }
            set
            {
                if (PropertyChanged(_DateApproved, value))
                    _DateApproved = value;
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

        private System.DateTime _DateUpdated;
        [Browsable(true), DisplayName("DateUpdated"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DateUpdated
        {
            get
            {
                return _DateUpdated;
            }
            set
            {
                if (PropertyChanged(_DateUpdated, value))
                    _DateUpdated = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _RuleName, _Description, _IsAttBased, _EffectedSalaryHeadID, _sCriteria, _SalaryHeadID, _IsFixed, _Amount, _DayStatus, _DivisibleFactorType, _Factor, _IsWExclude, _IsHExclude, _Shift, _LeaveType, _DateApproved.Value(StaticInfo.DateFormat), _ApprovedBy, _DateAdded.Value(StaticInfo.DateFormat), _DateUpdated.Value(StaticInfo.DateFormat), _AddedBy, _UpdatedBy };
            else if (IsModified)
                parameterValues = new Object[] { _RuleKey, _RuleName, _Description, _IsAttBased, _EffectedSalaryHeadID, _sCriteria, _SalaryHeadID, _IsFixed, _Amount, _DayStatus, _DivisibleFactorType, _Factor, _IsWExclude, _IsHExclude, _Shift, _LeaveType, _DateApproved.Value(StaticInfo.DateFormat), _ApprovedBy, _DateAdded.Value(StaticInfo.DateFormat), _DateUpdated.Value(StaticInfo.DateFormat), _AddedBy, _UpdatedBy };
            else if (IsDeleted)
                parameterValues = new Object[] { _RuleKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _RuleKey = reader.GetInt32("RuleKey");
            _RuleName = reader.GetString("RuleName");
            _Description = reader.GetString("Description");
            _IsAttBased = reader.GetBoolean("IsAttBased");
            _EffectedSalaryHeadID = reader.GetString("EffectedSalaryHeadID");
            _sCriteria = reader.GetString("sCriteria");
            _SalaryHeadID = reader.GetString("SalaryHeadID");
            _IsFixed = reader.GetBoolean("IsFixed");
            _Amount = reader.GetDecimal("Amount");
            _DayStatus = reader.GetString("DayStatus");
            _DivisibleFactorType = reader.GetInt32("DivisibleFactorType");
            _Factor = reader.GetInt32("Factor");
            _IsWExclude = reader.GetBoolean("IsWExclude");
            _IsHExclude = reader.GetBoolean("IsHExclude");
            _Shift = reader.GetString("Shift");
            _LeaveType = reader.GetString("LeaveType");
            _DateApproved = reader.GetDateTime("DateApproved");
            _ApprovedBy = reader.GetString("ApprovedBy");
            _DateAdded = reader.GetDateTime("DateAdded");
            _DateUpdated = reader.GetDateTime("DateUpdated");
            _AddedBy = reader.GetString("AddedBy");
            _UpdatedBy = reader.GetString("UpdatedBy");
            SetUnchanged();
        }
        public static CustomList<OtherSalaryRule> GetAllOtherSalaryRule()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<OtherSalaryRule> OtherSalaryRuleCollection = new CustomList<OtherSalaryRule>();
            IDataReader reader = null;
            const String sql = "select *from OtherSalaryRule";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    OtherSalaryRule newOtherSalaryRule = new OtherSalaryRule();
                    newOtherSalaryRule.SetData(reader);
                    OtherSalaryRuleCollection.Add(newOtherSalaryRule);
                }
                OtherSalaryRuleCollection.InsertSpName = "spInsertOtherSalaryRule";
                OtherSalaryRuleCollection.UpdateSpName = "spUpdateOtherSalaryRule";
                OtherSalaryRuleCollection.DeleteSpName = "spDeleteOtherSalaryRule";
                return OtherSalaryRuleCollection;
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
