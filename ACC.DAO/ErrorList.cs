using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ACC.DAO
{
    [Serializable]
    public class ErrorList : BaseItem
    {
        public ErrorList()
        {
            SetAdded();
        }

        #region Properties

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

        private System.String _Error;
        [Browsable(true), DisplayName("Error")]
        public System.String Error
        {
            get
            {
                return _Error;
            }
            set
            {
                if (PropertyChanged(_Error, value))
                    _Error = value;
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
