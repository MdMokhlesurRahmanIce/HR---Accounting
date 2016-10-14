using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
   public class AttPaymentInfoManager
    {
       //public CustomList<LeavePolicyMaster> GetAllLV_LeavePolicyMasterForAttPaymentInfo()
       //{
       //    return LeavePolicyMaster.GetAllLV_LeavePolicyMasterForAttPaymentInfo();
       //}
       public CustomList<SalaryHead> GetAllSalaryHead()
       {
           return SalaryHead.GetAllSalaryHead();
       }
    }
}
