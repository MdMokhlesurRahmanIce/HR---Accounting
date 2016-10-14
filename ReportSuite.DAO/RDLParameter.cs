using System;
using System.Data;

namespace ReportSuite.DAO
{
    public class RDLParameter
    {
        private String name = String.Empty;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private DbType dbType = DbType.String;
        public DbType DbType
        {
            get { return dbType; }
            set { dbType = value; }
        }

        private String prompt = String.Empty;
        public String Prompt
        {
            get { return prompt; }
            set { prompt = value; }
        }

        private Object value = null;
        public Object Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public override String ToString()
        {
            return name;            
        }
        private String defaultValue = String.Empty;
        public String DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        }
       
    }
}
