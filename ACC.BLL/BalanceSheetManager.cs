using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ACC.DAO;
using ASL.STATIC;

namespace ACC.BLL
{
    public class BalanceSheetManager
    {
        public CustomList<Organization> GetAllCompany()
        {
            return Organization.GetAllOrganization(2);
        }
        public CustomList<Gen_AccFY> GetAllGen_AccFY()
        {
            return Gen_AccFY.GetAllGen_AccFY();
        }
        public CustomList<Acc_VoucherDet> GetAllAcc_VoucherDetBS(Int32 orgKey, string fromDate, string toDate, Int32 fYKey)
        {
            return Acc_VoucherDet.GetAllAcc_VoucherDetBS(orgKey, fromDate, toDate, fYKey);
        }
    }
}
