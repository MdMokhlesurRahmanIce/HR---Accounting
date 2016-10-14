using System;
using System.Collections;
using System.Collections.Specialized;

namespace Hr.Web.GridHelperClasses
{
    public class GridRowAdd
    {
        private Hashtable parentRowKeys;
        private String parentRowKey;
        private NameValueCollection rowData;

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
        public Hashtable ParentRowKeys
        {
            get
            {
                return this.parentRowKeys;
            }
            set
            {
                this.parentRowKeys = value;
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
    }
}

