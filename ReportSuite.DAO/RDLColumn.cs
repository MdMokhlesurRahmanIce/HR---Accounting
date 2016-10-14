using System;

namespace ReportSuite.DAO
{
    public class RDLColumn
    {
        private String name = String.Empty;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private String dataType = String.Empty;
        public String DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }
        //
        private String tableName = String.Empty;
        public String TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        public override String ToString()
        {
            return name;
        }           
    }
}
