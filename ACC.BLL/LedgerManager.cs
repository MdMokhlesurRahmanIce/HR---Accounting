using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ACC.DAO;
using ASL.STATIC;

namespace ACC.BLL
{
   public class LedgerManager
    {
       public CustomList<Organization> GetAllCompany()
       {
           return Organization.GetAllOrganization(2);
       }
       public CustomList<Acc_COA> GetAllAcc_COA()
       {
           return Acc_COA.GetAllAcc_COA();
       }
    }
}
