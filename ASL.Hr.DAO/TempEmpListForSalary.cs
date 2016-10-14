using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASL.DATA;
using System.ComponentModel;
using System.Data;

namespace ASL.Hr.DAO
{
    public class TempEmpListForSalary:BaseItem
    {
        public TempEmpListForSalary()
        {
            SetAdded();
        }
        private System.Int32 _ID;
        [Browsable(true), DisplayName("ID")]
        public System.Int32 ID
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
        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _EmpKey };
            else if (IsDeleted)
                parameterValues = new Object[] {};
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ID = reader.GetInt32("ID");
            _EmpKey = reader.GetInt64("EmpKey");
           
            SetUnchanged();
        }
    }
}
