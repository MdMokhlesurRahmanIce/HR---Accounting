using System;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ReportSuite.DAO;
using ASL.STATIC;

namespace ReportSuite.BLL
{
   public class ParameterValueManager
    {
       public CustomList<ParameterFilterValue> GetReportValue(string parent)
       {
           return ParameterFilterValue.GetReportValue(parent);
       }
       public CustomList<ParameterFilterValue> GetReportValueFY(string orgKey)
       {
           return ParameterFilterValue.GetReportValueFY(orgKey);
       }
       public CustomList<ParameterFilterValue> GetReportValueEmp(string search)
       {
           return ParameterFilterValue.GetReportValueEmp(search);
       }
       public CustomList<ParameterFilterValue> GetReportValueDesig(string orgKey)
       {
           return ParameterFilterValue.GetReportValueDesig(orgKey);
       }
    }
}
