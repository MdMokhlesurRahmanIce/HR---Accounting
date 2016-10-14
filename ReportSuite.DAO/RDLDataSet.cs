using System;
using System.Collections.Generic;

namespace ReportSuite.DAO
{
    public class RDLDataSet
    {
        public RDLDataSet()
        {
            this.tables = new List<RDLTable>();
        }

        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private List<RDLTable> tables = null;
        public List<RDLTable> Tables
        {
            get { return tables; }
            set { tables = value; }
        }
        public override String ToString()
        {
            return name;
        }
    }
}
