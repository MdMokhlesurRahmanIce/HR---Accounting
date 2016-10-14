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
    public class MiscEntryDynamicGrid : BaseItem
    {
        public MiscEntryDynamicGrid()
        {
            SetAdded();
        }
        #region Properties

        private System.Int32 _SalaryHeadKey1;
        [Browsable(true), DisplayName("SalaryHeadKey1")]
        public System.Int32 SalaryHeadKey1
        {
            get
            {
                return _SalaryHeadKey1;
            }
            set
            {
                if (PropertyChanged(_SalaryHeadKey1, value))
                    _SalaryHeadKey1 = value;
            }
        }

        private System.Int32 _SalaryHeadKey2;
        [Browsable(true), DisplayName("SalaryHeadKey2")]
        public System.Int32 SalaryHeadKey2
        {
            get
            {
                return _SalaryHeadKey2;
            }
            set
            {
                if (PropertyChanged(_SalaryHeadKey2, value))
                    _SalaryHeadKey2 = value;
            }
        }

        private System.Int32 _SalaryHeadKey3;
        [Browsable(true), DisplayName("SalaryHeadKey3")]
        public System.Int32 SalaryHeadKey3
        {
            get
            {
                return _SalaryHeadKey3;
            }
            set
            {
                if (PropertyChanged(_SalaryHeadKey3, value))
                    _SalaryHeadKey3 = value;
            }
        }

        private System.Int32 _SalaryHeadKey4;
        [Browsable(true), DisplayName("SalaryHeadKey4")]
        public System.Int32 SalaryHeadKey4
        {
            get
            {
                return _SalaryHeadKey4;
            }
            set
            {
                if (PropertyChanged(_SalaryHeadKey4, value))
                    _SalaryHeadKey4 = value;
            }
        }

        private System.Int32 _SalaryHeadKey5;
        [Browsable(true), DisplayName("SalaryHeadKey5")]
        public System.Int32 SalaryHeadKey5
        {
            get
            {
                return _SalaryHeadKey5;
            }
            set
            {
                if (PropertyChanged(_SalaryHeadKey5, value))
                    _SalaryHeadKey5 = value;
            }
        }

        private System.Int32 _SalaryHeadKey6;
        [Browsable(true), DisplayName("SalaryHeadKey6")]
        public System.Int32 SalaryHeadKey6
        {
            get
            {
                return _SalaryHeadKey6;
            }
            set
            {
                if (PropertyChanged(_SalaryHeadKey6, value))
                    _SalaryHeadKey6 = value;
            }
        }

        private System.Int32 _SalaryHeadKey7;
        [Browsable(true), DisplayName("SalaryHeadKey7")]
        public System.Int32 SalaryHeadKey7
        {
            get
            {
                return _SalaryHeadKey7;
            }
            set
            {
                if (PropertyChanged(_SalaryHeadKey7, value))
                    _SalaryHeadKey7 = value;
            }
        }

        private System.String _HeadName1;
        [Browsable(true), DisplayName("HeadName1")]
        public System.String HeadName1
        {
            get
            {
                return _HeadName1;
            }
            set
            {
                if (PropertyChanged(_HeadName1, value))
                    _HeadName1 = value;
            }
        }

        private System.String _HeadName2;
        [Browsable(true), DisplayName("HeadName2")]
        public System.String HeadName2
        {
            get
            {
                return _HeadName2;
            }
            set
            {
                if (PropertyChanged(_HeadName2, value))
                    _HeadName2 = value;
            }
        }

        private System.String _HeadName3;
        [Browsable(true), DisplayName("HeadName3")]
        public System.String HeadName3
        {
            get
            {
                return _HeadName3;
            }
            set
            {
                if (PropertyChanged(_HeadName3, value))
                    _HeadName3 = value;
            }
        }

        private System.String _HeadName4;
        [Browsable(true), DisplayName("HeadName4")]
        public System.String HeadName4
        {
            get
            {
                return _HeadName4;
            }
            set
            {
                if (PropertyChanged(_HeadName4, value))
                    _HeadName4 = value;
            }
        }

        private System.String _HeadName5;
        [Browsable(true), DisplayName("HeadName5")]
        public System.String HeadName5
        {
            get
            {
                return _HeadName5;
            }
            set
            {
                if (PropertyChanged(_HeadName5, value))
                    _HeadName5 = value;
            }
        }

        private System.String _HeadName6;
        [Browsable(true), DisplayName("HeadName6")]
        public System.String HeadName6
        {
            get
            {
                return _HeadName6;
            }
            set
            {
                if (PropertyChanged(_HeadName6, value))
                    _HeadName6 = value;
            }
        }

        private System.String _HeadName7;
        [Browsable(true), DisplayName("HeadName7")]
        public System.String HeadName7
        {
            get
            {
                return _HeadName7;
            }
            set
            {
                if (PropertyChanged(_HeadName7, value))
                    _HeadName7 = value;
            }
        }

        private System.String _HeadName8;
        [Browsable(true), DisplayName("HeadName8")]
        public System.String HeadName8
        {
            get
            {
                return _HeadName8;
            }
            set
            {
                if (PropertyChanged(_HeadName8, value))
                    _HeadName8 = value;
            }
        }

        private System.String _HeadName9;
        [Browsable(true), DisplayName("HeadName9")]
        public System.String HeadName9
        {
            get
            {
                return _HeadName9;
            }
            set
            {
                if (PropertyChanged(_HeadName9, value))
                    _HeadName9 = value;
            }
        }

        private System.String _HeadName10;
        [Browsable(true), DisplayName("HeadName10")]
        public System.String HeadName10
        {
            get
            {
                return _HeadName10;
            }
            set
            {
                if (PropertyChanged(_HeadName10, value))
                    _HeadName10 = value;
            }
        }

        private System.String _HeadName11;
        [Browsable(true), DisplayName("HeadName11")]
        public System.String HeadName11
        {
            get
            {
                return _HeadName11;
            }
            set
            {
                if (PropertyChanged(_HeadName11, value))
                    _HeadName11 = value;
            }
        }

        private System.String _HeadName12;
        [Browsable(true), DisplayName("HeadName12")]
        public System.String HeadName12
        {
            get
            {
                return _HeadName12;
            }
            set
            {
                if (PropertyChanged(_HeadName12, value))
                    _HeadName12 = value;
            }
        }
        private System.String _HeadName13;
        [Browsable(true), DisplayName("HeadName13")]
        public System.String HeadName13
        {
            get
            {
                return _HeadName13;
            }
            set
            {
                if (PropertyChanged(_HeadName13, value))
                    _HeadName13 = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            SetUnchanged();
        }
    }
}
