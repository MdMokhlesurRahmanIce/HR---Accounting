using System;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using ASL.Hr.DAO;

namespace ASL.Hr.BLL
{
    public class LeaveYearManager
    {
        public CustomList<Gen_FY> GetAllGen_FY()
        {
            return Gen_FY.GetAllGen_FY();
        }
    }
}
