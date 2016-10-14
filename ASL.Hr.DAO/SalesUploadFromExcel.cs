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
    public class SalesUploadFromExcel : BaseItem
    {
        public SalesUploadFromExcel()
        {
            SetAdded();
        }
        #region Properties
        private System.String _Code;
        [Browsable(true), DisplayName("Code")]
        public System.String Code
        {
            get
            {
                return _Code;
            }
            set
            {
                if (PropertyChanged(_Code, value))
                    _Code = value;
            }
        }
        private System.String _SOName;
        [Browsable(true), DisplayName("SOName")]
        public System.String SOName
        {
            get
            {
                return _SOName;
            }
            set
            {
                if (PropertyChanged(_SOName, value))
                    _SOName = value;
            }
        }
        private System.String _Section;
        [Browsable(true), DisplayName("Section")]
        public System.String Section
        {
            get
            {
                return _Section;
            }
            set
            {
                if (PropertyChanged(_Section, value))
                    _Section = value;
            }
        }

        private System.Decimal _Gross;
        [Browsable(true), DisplayName("Gross")]
        public System.Decimal Gross
        {
            get
            {
                return _Gross;
            }
            set
            {
                if (PropertyChanged(_Gross, value))
                    _Gross = value;
            }
        }

        private System.Decimal _Cash;
        [Browsable(true), DisplayName("Cash")]
        public System.Decimal Cash
        {
            get
            {
                return _Cash;
            }
            set
            {
                if (PropertyChanged(_Cash, value))
                    _Cash = value;
            }
        }

        private System.Decimal _FreeSales;
        [Browsable(true), DisplayName("FreeSales")]
        public System.Decimal FreeSales
        {
            get
            {
                return _FreeSales;
            }
            set
            {
                if (PropertyChanged(_FreeSales, value))
                    _FreeSales = value;
            }
        }

        private System.Decimal _Commission;
        [Browsable(true), DisplayName("Commission")]
        public System.Decimal Commission
        {
            get
            {
                return _Commission;
            }
            set
            {
                if (PropertyChanged(_Commission, value))
                    _Commission = value;
            }
        }

        private System.Decimal _DistributorCom;
        [Browsable(true), DisplayName("DistributorCom")]
        public System.Decimal DistributorCom
        {
            get
            {
                return _DistributorCom;
            }
            set
            {
                if (PropertyChanged(_DistributorCom, value))
                    _DistributorCom = value;
            }
        }

        private System.Decimal _VAT;
        [Browsable(true), DisplayName("VAT")]
        public System.Decimal VAT
        {
            get
            {
                return _VAT;
            }
            set
            {
                if (PropertyChanged(_VAT, value))
                    _VAT = value;
            }
        }

        private System.Decimal _Inventory;
        [Browsable(true), DisplayName("Inventory")]
        public System.Decimal Inventory
        {
            get
            {
                return _Inventory;
            }
            set
            {
                if (PropertyChanged(_Inventory, value))
                    _Inventory = value;
            }
        }
        private System.Decimal _PDC;
        [Browsable(true), DisplayName("PDC")]
        public System.Decimal PDC
        {
            get { return _PDC; }
            set
            {
                if (PropertyChanged(_PDC, value))
                    _PDC = value;
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
