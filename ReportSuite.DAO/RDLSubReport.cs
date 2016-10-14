using System;

namespace ReportSuite.DAO
{
    public class RDLSubReport
    {
        public RDLSubReport()
        {
        }

        private String reportName = String.Empty;
        public String ReportName
        {
            get { return reportName; }
            set { reportName = value; }
        }       
        //
        private String reportPath = String.Empty;
        public String ReportPath
        {
            get { return reportPath; }
            set { reportPath = value; }
        }        
        //
        public override String ToString()
        {
            return reportName;
        }
    }
}
