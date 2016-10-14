using System;
using System.Collections.Generic;
using System.Data;

namespace ReportSuite.DAO
{
    public class RDLTable
    {
        public RDLTable()
        {
            parameters = new List<RDLParameter>();
            columns = new List<RDLColumn>();
        }

        private String tableName = String.Empty;
        public String TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        //
        private CommandType commandType = CommandType.Text;
        public CommandType CommandType
        {
            get { return commandType; }
            set { commandType = value; }
        }
        //
        private String commandText = String.Empty;
        public String CommandText
        {
            get { return commandText; }
            set { commandText = value; }
        }

        private List<RDLParameter> parameters = null;
        public List<RDLParameter> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        private List<RDLColumn> columns = null;
        public List<RDLColumn> Columns
        {

            get { return columns; }
            set { columns = value; }
        }
        //
        public override String ToString()
        {
            return tableName;
        }
    }
}
