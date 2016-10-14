using System;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using ASL.Hr.DAO;


namespace ASL.Hr.BLL
{
    public class LeaveSummeryManager
    {
        public CustomList<ASL.Hr.DAO.LeaveSummery> GetAllLeaveSummery()
        {
            return ASL.Hr.DAO.LeaveSummery.GetAllLeaveSummery();
        }
        public CustomList<ASL.Hr.DAO.LeaveSummery> GetEmpWiseLeaveSummery(string LeaveYear, string id)
        {
            return ASL.Hr.DAO.LeaveSummery.GetEmpWiseLeaveSummery(LeaveYear, id);
        }
        public CustomList<ASL.Hr.DAO.LeaveAllocation> GetEmpWiseLeaveAllocation(string LeaveYear, string id)
        {
            return ASL.Hr.DAO.LeaveAllocation.GetEmpWiseLeaveAllocation(LeaveYear, id);
        }
        public CustomList<HourlyLeaveTrans> GetAllHourlyLeaveTrans(Int32 fYKey, Int64 empKey)
        {
            return HourlyLeaveTrans.GetAllHourlyLeaveTrans(fYKey, empKey);
        }
    }
}
