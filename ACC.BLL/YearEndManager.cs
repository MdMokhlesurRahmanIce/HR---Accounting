using System;
using System.Collections.Generic;
using ASL.DATA;
using ASL.DAL;
using ACC.DAO;
using ASL.STATIC;

namespace ACC.BLL
{
   public class YearEndManager
    {
       public CustomList<Gen_AccFY> GetAllGen_AccFY()
       {
           return Gen_AccFY.GetAllGen_AccFY();
       }
       public void GetAllYearEndProcess(Int32 fYKey)
       {
           Acc_VoucherDet.GetAllYearEndProcess(fYKey);
           return;
       }
    }
}
