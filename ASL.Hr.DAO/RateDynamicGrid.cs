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
    public class RateDynamicGrid : BaseItem
    {
        public RateDynamicGrid()
        {
            SetAdded();
        }
        #region Properties

        private System.Int32 _RateKey1;
        [Browsable(true), DisplayName("RateKey1")]
        public System.Int32 RateKey1
        {
            get
            {
                return _RateKey1;
            }
            set
            {
                if (PropertyChanged(_RateKey1, value))
                    _RateKey1 = value;
            }
        }

        private System.Int32 _RateKey2;
        [Browsable(true), DisplayName("RateKey2")]
        public System.Int32 RateKey2
        {
            get
            {
                return _RateKey2;
            }
            set
            {
                if (PropertyChanged(_RateKey2, value))
                    _RateKey2 = value;
            }
        }

        private System.Int32 _RateKey3;
        [Browsable(true), DisplayName("RateKey3")]
        public System.Int32 RateKey3
        {
            get
            {
                return _RateKey3;
            }
            set
            {
                if (PropertyChanged(_RateKey3, value))
                    _RateKey3 = value;
            }
        }

        private System.Int32 _RateKey4;
        [Browsable(true), DisplayName("RateKey4")]
        public System.Int32 RateKey4
        {
            get
            {
                return _RateKey4;
            }
            set
            {
                if (PropertyChanged(_RateKey4, value))
                    _RateKey4 = value;
            }
        }

        private System.Int32 _RateKey5;
        [Browsable(true), DisplayName("RateKey5")]
        public System.Int32 RateKey5
        {
            get
            {
                return _RateKey5;
            }
            set
            {
                if (PropertyChanged(_RateKey5, value))
                    _RateKey5 = value;
            }
        }

        private System.Int32 _RateKey6;
        [Browsable(true), DisplayName("RateKey6")]
        public System.Int32 RateKey6
        {
            get
            {
                return _RateKey6;
            }
            set
            {
                if (PropertyChanged(_RateKey6, value))
                    _RateKey6 = value;
            }
        }

        private System.Int32 _Key1;
        [Browsable(true), DisplayName("Key1")]
        public System.Int32 Key1
        {
            get
            {
                return _Key1;
            }
            set
            {
                if (PropertyChanged(_Key1, value))
                    _Key1 = value;
            }
        }

        private System.Int32 _Key2;
        [Browsable(true), DisplayName("Key2")]
        public System.Int32 Key2
        {
            get
            {
                return _Key2;
            }
            set
            {
                if (PropertyChanged(_Key2, value))
                    _Key2 = value;
            }
        }

        private System.Int32 _Key3;
        [Browsable(true), DisplayName("Key3")]
        public System.Int32 Key3
        {
            get
            {
                return _Key3;
            }
            set
            {
                if (PropertyChanged(_Key3, value))
                    _Key3 = value;
            }
        }

        private System.Int32 _Key4;
        [Browsable(true), DisplayName("Key4")]
        public System.Int32 Key4
        {
            get
            {
                return _Key4;
            }
            set
            {
                if (PropertyChanged(_Key4, value))
                    _Key4 = value;
            }
        }

        private System.Int32 _Key5;
        [Browsable(true), DisplayName("Key5")]
        public System.Int32 Key5
        {
            get
            {
                return _Key5;
            }
            set
            {
                if (PropertyChanged(_Key5, value))
                    _Key5 = value;
            }
        }

        private System.Int32 _Key6;
        [Browsable(true), DisplayName("Key6")]
        public System.Int32 Key6
        {
            get
            {
                return _Key6;
            }
            set
            {
                if (PropertyChanged(_Key6, value))
                    _Key6 = value;
            }
        }

        private System.Int32 _Key7;
        [Browsable(true), DisplayName("Key7")]
        public System.Int32 Key7
        {
            get
            {
                return _Key7;
            }
            set
            {
                if (PropertyChanged(_Key7, value))
                    _Key7 = value;
            }
        }

        private System.Decimal _Rate;
        [Browsable(true), DisplayName("Rate")]
        public System.Decimal Rate
        {
            get
            {
                return _Rate;
            }
            set
            {
                if (PropertyChanged(_Rate, value))
                    _Rate = value;
            }
        }

        private System.String _RateID;
        [Browsable(true), DisplayName("RateID")]
        public System.String RateID
        {
            get
            {
                return _RateID;
            }
            set
            {
                if (PropertyChanged(_RateID, value))
                    _RateID = value;
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
