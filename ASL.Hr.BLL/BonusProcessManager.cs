using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
   public class BonusProcessManager
    {
       public CustomList<Settings> GetAllSalaryYear()
       {
           return Settings.GetAllSalaryYear();
       }
       public CustomList<Settings> GetAllSalaryMonths(string Year)
       {
           return Settings.GetAllSalaryMonths(Year);
       }
    }
}
