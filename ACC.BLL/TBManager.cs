using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ACC.DAO;
using ASL.STATIC;

namespace ACC.BLL
{
   public class TBManager
    {
       public CustomList<Organization> GetAllCompany()
       {
           return Organization.GetAllOrganization(2);
       }
       public CustomList<Acc_VoucherDet> GetAllAcc_VoucherDetTB(Int32 orgKey, string fromDate, string toDate)
       {
           return Acc_VoucherDet.GetAllAcc_VoucherDetTB(orgKey, fromDate, toDate);
       }
    }
}
