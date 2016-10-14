using System;

namespace ASL.DATA
{
    public class CustomAttributes
    {
        /// <summary>
        /// This custom attribute is to provide the indication that the associated -
        /// property will be the primary key of a data table.
        /// 
        /// AttributeTargets - is only the "Property".
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class IsPrimaryAttribute : Attribute
        {
            private Boolean _isPrimary;

            // Constructor  
            public IsPrimaryAttribute(bool isPrimary)
            {
                this._isPrimary = isPrimary;
            }

            // IsPrimary
            public Boolean IsPrimary
            {
                get { return _isPrimary; }
            }
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class FormatString : Attribute
        {
            private String _format;

            // Constructor  
            public FormatString(String format)
            {
                this._format = format;
            }

            // Format
            public String Format
            {
                get { return this._format; }
            }
        }
    }
}
