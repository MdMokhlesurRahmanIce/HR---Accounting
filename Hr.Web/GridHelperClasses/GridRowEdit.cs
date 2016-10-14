using System;
using System.Collections.Specialized;
namespace Hr.Web.GridHelperClasses
{
    public class GridRowEdit
    {
        private String parentRowKey;
        private NameValueCollection rowData;
        private String rowKey;

        public string ParentRowKey
        {
            get
            {
                return this.parentRowKey;
            }
            set
            {
                this.parentRowKey = value;
            }
        }

        public NameValueCollection RowData
        {
            get
            {
                return this.rowData;
            }
            set
            {
                this.rowData = value;
            }
        }

        public string RowKey
        {
            get
            {
                return this.rowKey;
            }
            set
            {
                this.rowKey = value;
            }
        }
    }
}

