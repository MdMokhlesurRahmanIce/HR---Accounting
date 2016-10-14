using System;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ASL.Hr.BLL
{
   public class SalaryComponentHelper
    {
       Dictionary<string, decimal> factors = new Dictionary<string, decimal>();
       CustomList<EmployeeSalaryTemp> _EmpSalaryTempList = new CustomList<EmployeeSalaryTemp>();
       public CustomList<EmployeeSalaryTemp> DecodeFormula(ref CustomList<SalaryRule> salaryRuleList)
       {
           try
           {
               DecodeRuleDetails(salaryRuleList);
               // if (EmpList == null) return _EmpSalaryTempList;
               //  foreach (HRM_Emp e in EmpList)
               //  {
               //    foreach (EmployeeSalaryTemp eST in _EmpSalaryTempList)
               //      {
               //       eST.EmpKey = e.EmpKey;
               //  }
               //  }
           }
           catch (Exception ex)
           {

               throw (ex);
           }
           return _EmpSalaryTempList;
       }
       private void DecodeRuleDetails(CustomList<SalaryRule> ruleDetails)
       {
           try
           {
               foreach (SalaryRule item in ruleDetails)
               {
                   var pattern = new Regex(@"(\@.*?\@)", RegexOptions.IgnorePatternWhitespace);

                   foreach (Match m in pattern.Matches(item.Formula2.ToUpper()))
                   {
                      string[] parts = m.Groups[1].Value.Split('@');
                      SalaryRule obj = ruleDetails.Find(f => f.HeadName.ToUpper().Trim() == parts[1].ToUpper().Trim());
                      item.Formula2 = item.Formula2.ToUpper().Replace(m.Groups[1].Value, obj.Formula2);
                   }
                   NCalc.Expression exp = new NCalc.Expression(item.Formula2);
                   object ret = exp.Evaluate();
                   item.Formula2 = ret.ToString();

                   decimal val = 0M;
                   EmployeeSalaryTemp eST = new EmployeeSalaryTemp();
                   eST.SalaryRuleCode = item.SalaryRuleCode;
                   eST.SalaryHeadKey = item.SalaryHeadKey;
                   eST.IsFixed = item.IsFixed;
                   if (decimal.TryParse(item.Formula2, out val))
                       eST.Amount =Math.Round(val,2);
                   _EmpSalaryTempList.Add(eST);
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
    }
}
