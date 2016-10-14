using System;
using ASL.DATA;
using ASL.DAL;
using ASL.Hr.DAO;
using ASL.STATIC;
using ACC.DAO;
namespace ASL.Hr.BLL
{
    public class SalesUploadController
    {
        public CustomList<Acc_VoucherDet> GetAllSOList()
        {
            return Acc_VoucherDet.GetAllSOList();
        }
        public CustomList<Acc_VoucherDet> GetSOList()
        {
            return Acc_VoucherDet.GetSOList();
        }
    }
}
