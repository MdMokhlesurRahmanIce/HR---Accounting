using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using System.Text;
using System.Web;

namespace ASL.Hr.DAO
{
   public class CommonHelper
    {
       public static String CreateSearchString()
       {
           CustomList<EmpFilterSets> SearchList = (CustomList<EmpFilterSets>)HttpContext.Current.Session["ucEmpSearch_FilterSetsList"];
           StringBuilder sb = new StringBuilder();
           if (SearchList.IsNull()) return sb.ToString();
           foreach (EmpFilterSets fS in SearchList)
           {
               switch (fS.ColumnName)
               {
                   case "Company":
                       if (fS.ColumnValue == "") break;
                       sb.Append(" And CompanyID");
                       sb.Append(" in(");
                       sb.Append(fS.ColumnValue);
                       sb.Append(")");
                       break;
                   case "Branch":
                       if (fS.ColumnValue == "") break;
                       sb.Append(" And BranchID");
                       sb.Append(" IN(");
                       sb.Append(fS.ColumnValue);
                       sb.Append(")");
                       break;
                   case "Department":
                       if (fS.ColumnValue == "") break;
                       sb.Append(" AND DepartmentID");
                       sb.Append(" IN(");
                       sb.Append(fS.ColumnValue);
                       sb.Append(")");
                       break;
                   case "Grade":
                       if (fS.ColumnValue == "") break;
                       sb.Append(" AND GradeID");
                       sb.Append(" IN(");
                       sb.Append(fS.ColumnValue);
                       sb.Append(")");
                       break;
                   case "Designation":
                       if (fS.ColumnValue == "") break;
                       sb.Append(" AND DesignationID");
                       sb.Append(" IN(");
                       sb.Append(fS.ColumnValue);
                       sb.Append(")");
                       break;
                   case "Unit":
                       if (fS.ColumnValue == "") break;
                       sb.Append(" AND UnitID");
                       sb.Append(" IN(");
                       sb.Append(fS.ColumnValue);
                       sb.Append(")");
                       break;
                   case "Division":
                       if (fS.ColumnValue == "") break;
                       sb.Append(" AND DivisionID");
                       sb.Append(" IN(");
                       sb.Append(fS.ColumnValue);
                       sb.Append(")");
                       break;
                   case "Sub Division":
                       if (fS.ColumnValue == "") break;
                       sb.Append(" AND [Sub DivisionID]");
                       sb.Append(" IN(");
                       sb.Append(fS.ColumnValue);
                       sb.Append(")");
                       break;
                   case "Staff Category":
                       if (fS.ColumnValue == "") break;
                       sb.Append(" AND [Staff CategoryID]");
                       sb.Append(" IN(");
                       sb.Append(fS.ColumnValue);
                       sb.Append(")");
                       break;
                   case "Section":
                       if (fS.ColumnValue == "") break;
                       sb.Append(" And SectionID");
                       sb.Append(" IN(");
                       sb.Append(fS.ColumnValue);
                       sb.Append(")");
                       break;
                   case "Sub Section":
                       if (fS.ColumnValue == "") break;
                       sb.Append(" AND [Sub SectionID]");
                       sb.Append(" IN(");
                       sb.Append(fS.ColumnValue);
                       sb.Append(")");
                       break;
                   case "Job Location":
                       if (fS.ColumnValue == "") break;
                       sb.Append(" AND [Job LocationID]");
                       sb.Append(" IN(");
                       sb.Append(fS.ColumnValue);
                       sb.Append(")");
                       break;
                   case "Group":
                       if (fS.ColumnValue == "") break;
                       sb.Append(" AND [GroupID]");
                       sb.Append(" IN(");
                       sb.Append(fS.ColumnValue);
                       sb.Append(")");
                       break;
                   case "EmpType":
                       if (fS.ColumnValue == "") break;
                       sb.Append(" AND [EmpType]");
                       sb.Append(" IN(");
                       sb.Append(fS.ColumnValue);
                       sb.Append(")");
                       break;
                   case "Piece Rate":
                       if (fS.ColumnValue == "") break;
                       sb.Append(" AND PieceRateKey");
                       sb.Append(" IN(");
                       sb.Append(fS.ColumnValue);
                       sb.Append(")");
                       break;
                   default: break;
               }
           }
           return sb.ToString();
       }
    }
}
