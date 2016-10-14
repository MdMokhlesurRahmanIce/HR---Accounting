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
    public class HourWisePayment : BaseItem
    {
        public HourWisePayment()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _HourWisePaymentKey;
        [Browsable(true), DisplayName("HourWisePaymentKey")]
        public System.Int32 HourWisePaymentKey
        {
            get
            {
                return _HourWisePaymentKey;
            }
            set
            {
                if (PropertyChanged(_HourWisePaymentKey, value))
                    _HourWisePaymentKey = value;
            }
        }

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

        private System.String _Condition;
        [Browsable(true), DisplayName("Condition")]
        public System.String Condition
        {
            get
            {
                return _Condition;
            }
            set
            {
                if (PropertyChanged(_Condition, value))
                    _Condition = value;
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

        private System.String _ShiftID;
        [Browsable(true), DisplayName("ShiftID")]
        public System.String ShiftID
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

        private System.String _FromTime;
        [Browsable(true), DisplayName("FromTime")]
        public System.String FromTime
        {
            get
            {
                return _FromTime;
            }
            set
            {
                if (PropertyChanged(_FromTime, value))
                    _FromTime = value;
            }
        }

        private System.String _ToTime;
        [Browsable(true), DisplayName("ToTime")]
        public System.String ToTime
        {
            get
            {
                return _ToTime;
            }
            set
            {
                if (PropertyChanged(_ToTime, value))
                    _ToTime = value;
            }
        }

        private System.String _Status;
        [Browsable(true), DisplayName("Status")]
        public System.String Status
        {
            get
            {
                return _Status;
            }
            set
            {
                if (PropertyChanged(_Status, value))
                    _Status = value;
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
                parameterValues = new Object[] { _RuleKey, _sCriteria, _Condition, _SalaryHeadID, _Amount, _ShiftID, _FromTime, _ToTime, _Status, _DateAdded.Value(StaticInfo.DateFormat), _DateUpdated.Value(StaticInfo.DateFormat), _AddedBy, _UpdatedBy };
            else if (IsModified)
                parameterValues = new Object[] { _HourWisePaymentKey, _RuleKey, _sCriteria, _Condition, _SalaryHeadID, _Amount, _ShiftID, _FromTime, _ToTime, _Status, _DateAdded.Value(StaticInfo.DateFormat), _DateUpdated.Value(StaticInfo.DateFormat), _AddedBy, _UpdatedBy };
            else if (IsDeleted)
                parameterValues = new Object[] { _HourWisePaymentKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _HourWisePaymentKey = reader.GetInt32("HourWisePaymentKey");
            _RuleKey = reader.GetInt32("RuleKey");
            _sCriteria = reader.GetString("sCriteria");
            _Condition = reader.GetString("Condition");
            _SalaryHeadID = reader.GetString("SalaryHeadID");
            _Amount = reader.GetDecimal("Amount");
            _ShiftID = reader.GetString("ShiftID");
            _FromTime = reader.GetString("FromTime");
            _ToTime = reader.GetString("ToTime");
            _Status = reader.GetString("Status");
            _DateAdded = reader.GetDateTime("DateAdded");
            _DateUpdated = reader.GetDateTime("DateUpdated");
            _AddedBy = reader.GetString("AddedBy");
            _UpdatedBy = reader.GetString("UpdatedBy");
            SetUnchanged();
        }
        public static CustomList<HourWisePayment> GetAllHourWisePayment(Int32 ruleKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HourWisePayment> HourWisePaymentCollection = new CustomList<HourWisePayment>();
            IDataReader reader = null;
            String sql = "select *from HourWisePayment where RuleKey=" + ruleKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HourWisePayment newHourWisePayment = new HourWisePayment();
                    newHourWisePayment.SetData(reader);
                    HourWisePaymentCollection.Add(newHourWisePayment);
                }
                return HourWisePaymentCollection;
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
