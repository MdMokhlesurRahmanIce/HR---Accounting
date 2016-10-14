using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASL.DATA;
using ASL.Hr.DAO;
using ASL.DAL;
using ASL.STATIC;

namespace ASL.Hr.BLL
{
    public class MonthlySalarProcessManager
    {
        public CustomList<Organization> GetAllCompany()
        {
            return Organization.GetAllOrganization(2);
        }
        public CustomList<Gen_LookupEnt> GetAllGen_Grade()
        {
            return Gen_LookupEnt.GetAllGen_LookupEnt(1);
        }
        public CustomList<Organization> GetAllBranch()
        {
            return Organization.GetAllOrganization(4);
        }
        public CustomList<Organization> GetAllOrganizationById(int orgKey)
        {
            return Organization.GetAllOrganizationById(orgKey);
        }
        public CustomList<LineInfo> GetAllLineInfo(int orgKey)
        {
            return LineInfo.GetAllLineInfo(orgKey);
        }
        public CustomList<Organization> GetAllDept()
        {
            return Organization.GetAllOrganization(6);
        }
        public CustomList<Designation> GetAllDesignation()
        {
            return Designation.GetAllDesignation();
        }
        public CustomList<Designation> GetAllDesignation(Int32 gradeKey)
        {
            return Designation.GetAllDesignation(gradeKey);
        }
        public CustomList<Gen_FY> GetAllGen_FY()
        {
            return Gen_FY.GetAllGen_FY();
        }
        public CustomList<Gen_Month> GetAllGen_Month()
        {
            return Gen_Month.GetAllGen_Month();
        }
        public CustomList<HRM_Emp> doSearch(string empkey)
        {
            return HRM_Emp.doSearch(empkey);
        }
        public CustomList<HRM_Emp> GetAllHRM_Emp()
        {
            return HRM_Emp.GetAllHRM_Emp();
        }
    }
}
