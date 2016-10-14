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
    public class HRM_SalaryDet : BaseItem
    {
        public HRM_SalaryDet()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _SalDetKey;
        [Browsable(true), DisplayName("SalDetKey")]
        public System.Int64 SalDetKey
        {
            get
            {
                return _SalDetKey;
            }
            set
            {
                if (PropertyChanged(_SalDetKey, value))
                    _SalDetKey = value;
            }
        }

        private System.Int64 _SalKey;
        [Browsable(true), DisplayName("SalKey")]
        public System.Int64 SalKey
        {
            get
            {
                return _SalKey;
            }
            set
            {
                if (PropertyChanged(_SalKey, value))
                    _SalKey = value;
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

        private System.Int64 _EmpAllowDedKey;
        [Browsable(true), DisplayName("EmpAllowDedKey")]
        public System.Int64 EmpAllowDedKey
        {
            get
            {
                return _EmpAllowDedKey;
            }
            set
            {
                if (PropertyChanged(_EmpAllowDedKey, value))
                    _EmpAllowDedKey = value;
            }
        }

        private System.Int32 _CalMethod;
        [Browsable(true), DisplayName("CalMethod")]
        public System.Int32 CalMethod
        {
            get
            {
                return _CalMethod;
            }
            set
            {
                if (PropertyChanged(_CalMethod, value))
                    _CalMethod = value;
            }
        }

        private System.Decimal _Value;
        [Browsable(true), DisplayName("Value")]
        public System.Decimal Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (PropertyChanged(_Value, value))
                    _Value = value;
            }
        }

        private System.Int64 _VoucherKey;
        [Browsable(true), DisplayName("VoucherKey")]
        public System.Int64 VoucherKey
        {
            get
            {
                return _VoucherKey;
            }
            set
            {
                if (PropertyChanged(_VoucherKey, value))
                    _VoucherKey = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _SalKey, _EmpKey, _EmpAllowDedKey, _CalMethod, _Value, _VoucherKey, _IsApproved };
            else if (IsModified)
                parameterValues = new Object[] { _SalDetKey, _IsApproved };
            else if (IsDeleted)
                parameterValues = new Object[] { _SalDetKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _SalDetKey = reader.GetInt64("SalDetKey");
            _SalKey = reader.GetInt64("SalKey");
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpAllowDedKey = reader.GetInt64("EmpAllowDedKey");
            _CalMethod = reader.GetInt32("CalMethod");
            _Value = reader.GetDecimal("Value");
            _VoucherKey = reader.GetInt64("VoucherKey");
            _IsApproved = reader.GetBoolean("IsApproved");
            SetUnchanged();
        }
        public static CustomList<HRM_SalaryDet> GetAllHRM_SalaryDet()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<HRM_SalaryDet> HRM_SalaryDetCollection = new CustomList<HRM_SalaryDet>();
            IDataReader reader = null;
            const String sql = "select *from HRM_SalaryDet";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    HRM_SalaryDet newHRM_SalaryDet = new HRM_SalaryDet();
                    newHRM_SalaryDet.SetData(reader);
                    HRM_SalaryDetCollection.Add(newHRM_SalaryDet);
                }
                HRM_SalaryDetCollection.InsertSpName = "spInsertHRM_SalaryDet";
                HRM_SalaryDetCollection.UpdateSpName = "spUpdateHRM_SalaryDet";
                HRM_SalaryDetCollection.DeleteSpName = "spDeleteHRM_SalaryDet";
                return HRM_SalaryDetCollection;
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
