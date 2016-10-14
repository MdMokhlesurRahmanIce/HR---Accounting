using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASL.DATA;
using ASL.Hr.DAO;
using ASL.DAL;
using ASL.STATIC;
using System.Collections;

namespace ASL.Hr.BLL
{
   public class EmpSearchManager
    {
        
        public HRM_EmpAddr GetSearchEmpAddress(long empKey)
        {
            return HRM_EmpAddr.GetSearchEmpAddress(empKey);
        }
        public HRM_EmpFamily GetSearchEmpFamilyInfo(long empKey)
        {
            return HRM_EmpFamily.GetSearchEmpFamilyInfo(empKey);
        }
        public HRM_EmpFileAttach GetEmpfileByEmpKey(long empKey)
        {
            return HRM_EmpFileAttach.GetEmpfileByEmpKey(empKey);
        }
        public CustomList<HRM_EmpEdu> GetAllEmpEduByEmpKey(string EmpKey)
        {
            return HRM_EmpEdu.GetAllEmpEduByEmpKey(EmpKey);
        }

        public CustomList<HRM_EmpEduDip> GetAllDipEduByEmpKey(string EmpKey)
        {
            return HRM_EmpEduDip.GetAllDipEduByEmpKey(EmpKey);
        }
        public CustomList<HRM_EmpFamDet> GetAllFamDetByFamKey(long famKey)
        {
            return HRM_EmpFamDet.GetAllHRM_EmpFamDetByFamKey(famKey);
        }
        public CustomList<Gen_Relation> GetAllRelation()
        {
            return Gen_Relation.GetAllGen_Relation();
        }
        public CustomList<Gen_LookupEnt> GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup entitySetup)
        {
            return Gen_LookupEnt.GetAllGen_LookupEnt(entitySetup);
        }
        public CustomList<HRM_EmpEmployment> GetAllEmpHistByEmpKey(string EmpKey)
        {
            return HRM_EmpEmployment.GetAllEmpHistByEmpKey(EmpKey);
        }
        public CustomList<Designation> GetAllDesignation()
        {
            return Designation.GetAllDesignation();
        }
        public CustomList<HRM_EmpFileAttach> GetAllEmpfileByEmpKey(string EmpKey)
        {
            return HRM_EmpFileAttach.GetAllEmpfileByEmpKey(EmpKey);
        }
        public CustomList<Gen_Country> GetAllCountry()
        {
            return Gen_Country.GetAllGen_Country();
        }
        public CustomList<EducationQualification> GetAllEduQual()
        {
            return EducationQualification.GetAllEducationQualification();
        }
        public CustomList<EntityList> GetAllEntityList()
        {
            return EntityList.GetAllEntityList();
        }
        public CustomList<HouseKeepingValue> GetAllHouseKeepingValue(string search, string blank)
        {
            return HouseKeepingValue.GetAllHouseKeepingValue(search, blank);
        }
        public CustomList<HouseKeepingValue> GetAllHouseKeepingValue(string entityId)
        {
            return HouseKeepingValue.GetAllHouseKeepingValue(entityId);
        }
        public Int32 GetAllEntityList(string entityKey)
        {
            return EntityList.GetAllEntityList(entityKey);
        }

        //View Emp List  
        public CustomList<HRM_Emp> GetAllViewEmp(string spName, string fromdate, string todate)
        {
            return HRM_Emp.GetAllViewEmp(spName,fromdate, todate);
        }
        public CustomList<HRM_Emp> GetAllViewEmp(string spName, string fromDate, string toDate, string str)
        {
            return HRM_Emp.GetAllViewEmp(spName,fromDate,toDate,str);
        }
        public CustomList<HRM_Emp> doSearch()
        {
            return HRM_Emp.doSearch("");
        }

    }
}
