using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;


namespace ASL.Hr.DAO
{
   public class PopulateDropdownList:BaseItem
    {
        private String text;
        public String Text
        {
            get { return text; }
            set { text = value; }
        }
        private Int32 valueField;
        public Int32 ValueField
        {
            get { return valueField; }
            set { valueField = value; }
        }
        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            //if (IsAdded)
            //    parameterValues = new Object[] { _GradeName, _Remarks };
            //else if (IsModified)
            //    parameterValues = new Object[] { _GradeName, _Remarks };
            //else if (IsDeleted)
            //    parameterValues = new Object[] { _GradeKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            //_GradeKey = reader.GetInt32("GradeKey");
            //_GradeName = reader.GetString("GradeName");
            //_Remarks = reader.GetString("Remarks");
            SetUnchanged();
        }
    }
}
