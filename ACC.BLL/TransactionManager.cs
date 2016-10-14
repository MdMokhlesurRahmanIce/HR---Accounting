using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ACC.DAO;
using ASL.STATIC;

namespace ACC.BLL
{
   public class TransactionManager
    {
        public CustomList<Organization> GetAllCompany()
        {
            return Organization.GetAllOrganization(2);
        }
        public CustomList<Acc_VoucherDet> GetAllAcc_VoucherDet(Int32 orgKey, Int32 isPost, string fromDate, string toDate)
        {
            return Acc_VoucherDet.GetAllAcc_VoucherDet(orgKey, isPost, fromDate, toDate);
        }
        public CustomList<Acc_VoucherDet> GetAllAcc_VoucherDet(Int32 orgKey, string fromDate, string toDate, Int32 head)
        {
            return Acc_VoucherDet.GetAllAcc_VoucherDet(orgKey, fromDate, toDate, head);
        }
        public Decimal GetAllAcc_VoucherDet(Int32 orgKey, string fromDate, string toDate, Int32 head, string spName)
        {
            return Acc_VoucherDet.GetAllAcc_VoucherDet(orgKey, fromDate, toDate, head, spName);
        }
    }
}
