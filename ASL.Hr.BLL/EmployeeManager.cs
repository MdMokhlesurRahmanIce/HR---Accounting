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
    public class EmployeeManager
    {
        public CustomList<HRM_Emp> GetEmpGeneralInfo1(string empCode)
        {
            return HRM_Emp.GetEmpGeneralInfo(empCode);
        }

        public CustomList<HRM_Emp> GetActiveEmpCodeAndEmpKeyOnly()
        {
            return HRM_Emp.GetActiveEmpCodeAndEmpKeyOnly();
        }
        public CustomList<HRM_Emp> GetEmpInfoForShowingLevel(string empCode)
        {
            return HRM_Emp.GetEmpInfoForShowingLevel(empCode);
        }
        public CustomList<EmployeeSalaryTemp> GetAllEmployeeSalaryByEmpKey(Int64 empKey, string usercode)
        {
            return EmployeeSalaryTemp.GetAllEmployeeSalaryByEmpKey(empKey, usercode);
        }
        #region Work flow method
        public CustomList<Gen_Bank> GetAllBank()
        {
            return Gen_Bank.GetAllGen_Bank();
        }

        public CustomList<HRM_Emp> GetReportees(long empKey)
        {
            return HRM_Emp.GetReportees(empKey);
        }
        public CustomList<HRM_Emp> DateRangWiseEmpApplicableShift(string FromDate , string ToDate)
        {
            return HRM_Emp.DateRangWiseEmpApplicableShift(FromDate, ToDate);
        }

        public CustomList<Designation> GetAllDesignation()
        {
            return Designation.GetAllDesignation();
        }

        public CustomList<EducationQualification> GetAllEduQualification()
        {
            return EducationQualification.GetAllEducationQualification();
        }

        public CustomList<Gen_Country> GetAllCountry()
        {
            return Gen_Country.GetAllGen_Country();
        }

        public CustomList<Gen_District> GetAllDistrict()
        {
            return Gen_District.GetAllGen_District();
        }

        public CustomList<EmployeeHKInfo> GetAllEmployeeHKInfo(Int64 empKey)
        {
            return EmployeeHKInfo.GetAllEmployeeHKInfo(empKey);
        }

        public CustomList<Bank_Branch> GetAllBank_Branch(Int32 bankKey)
        {
            return Bank_Branch.GetAllBank_Branch(bankKey);
        }

        public CustomList<Gen_Ethnic> GetAllEthnic()
        {
            return Gen_Ethnic.GetAllGen_Ethnic();
        }

        public CustomList<Gen_Relation> GetAllRelation()
        {
            return Gen_Relation.GetAllGen_Relation();
        }
        
        public CustomList<Gen_Grade> GetAllGrade()
        {
            return Gen_Grade.GetAllGen_Grade();
        }
        public CustomList<ShiftRule> GetAllShiftRule()
        {
            return ShiftRule.GetAllShiftRule();
        }

        public CustomList<ShiftPlan> GetAllShift()
        {
            return ShiftPlan.GetAllShift();
        }

        public CustomList<LeaveRuleMaster> GetAllLeaveRuleMaster()
        {
            return LeaveRuleMaster.GetAllLeaveRuleMaster();
        }

        public CustomList<Gen_LookupEnt> GetAllGen_LookupEnt(ASL.Hr.DAO.enumsHr.enumEntitySetup entitySetup)
        {
            return Gen_LookupEnt.GetAllGen_LookupEnt(entitySetup);
        }
        public CustomList<Gen_Exam> GetAllExam()
        {
            return Gen_Exam.GetAllGen_Exam();
        }
        public CustomList<HRM_Emp> GetEmpInfo(string searchString)
        {
            return HRM_Emp.GetEmpInfo(searchString);
        }
        public CustomList<LanguageInfo> GetAllLanguageInfo(long empKey)
        {
            return LanguageInfo.GetAllLanguageInfo(empKey);
        }

        public HRM_Emp GetReportingBoss(long empKey)
        {
            return HRM_Emp.GetReportingBoss(empKey);
        }
        public CustomList<Gen_FY> GetAllGen_FY()
        {
            return Gen_FY.GetAllGen_FY();
        }
        public CustomList<MedicalReinSetup> GetAllMedicalReinSetup(string fyKey,string empKey)
        {
            return MedicalReinSetup.GetAllMedicalReinSetup(fyKey,empKey);
        }
        #endregion

        #region Emp General Info

        public bool SaveEmpGeneralInfo(ref CustomList<HRM_Emp> empInfo)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(empInfo);

                //GetNewUserID(ref conManager, ref userList);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, empInfo);

                empInfo.AcceptChanges();


                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
                return true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
        }

        public HRM_Emp GetEmpGeneralInfoByEmpCode(string empCode)
        {
            return HRM_Emp.GetEmpByCode(empCode);
        }

        public CustomList<HRM_Emp> GetEmpGeneralInfo()
        {
            return HRM_Emp.GetAllHRM_Emp();
        }


        public CustomList<Gen_Relation> GetAllGen_Relation()
        {
            return Gen_Relation.GetAllGen_Relation();
        }

        private void ReSetSPName(CustomList<HRM_Emp> empInfo)
        {
            #region Employee

            empInfo.InsertSpName = "spInsertHRM_Emp";
            empInfo.UpdateSpName = "spUpdateHRM_Emp";
            empInfo.DeleteSpName = "spDeleteHRM_Emp";
            #endregion
        }

        public HRM_Emp GetEmpByCode(string empCode)
        {
            return HRM_Emp.GetEmpByCode(empCode);
        }
        #endregion

        #region Emp addr
        public bool SaveEmpAddr(ref CustomList<HRM_EmpAddr> empAddr)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(empAddr);

                //GetNewUserID(ref conManager, ref userList);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, empAddr);

                empAddr.AcceptChanges();


                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
                return true;
            }
            catch (Exception Ex)
            {
                conManager.RollBack();
                throw Ex;
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
        }

        private void ReSetSPName(CustomList<HRM_EmpAddr> empAddr)
        {
            empAddr.InsertSpName = "spInsertHRM_EmpAddr";
            empAddr.UpdateSpName = "spUpdateHRM_EmpAddr";
            empAddr.DeleteSpName = "spDeleteHRM_EmpAddr";
        }
        private void ReSetSPName(CustomList<EmployeeEmergencyInfo> emerContact)
        {
            emerContact.InsertSpName = "spInsertEmployeeEmergencyInfo";
            emerContact.UpdateSpName = "spUpdateEmployeeEmergencyInfo";
            emerContact.DeleteSpName = "spDeleteEmployeeEmergencyInfo";
        }
        public CustomList<HRM_EmpAddr> GetAllEmpAddrByEmpKey(string empKey)
        {
            return HRM_EmpAddr.GetAllEmpAddrByEmpKey(empKey);
        }
        public CustomList<EmployeeEmergencyInfo> GetAllEmployeeEmergencyInfo(long empKey)
        {
            return EmployeeEmergencyInfo.GetAllEmployeeEmergencyInfo(empKey);
        }

        #endregion
        #region Job Responsibility
        public CustomList<JobResponsibility> GetAllJobResponsibility(long empKey)
        {
            return JobResponsibility.GetAllJobResponsibility(empKey);
        }
        private void ReSetSPName(CustomList<JobResponsibility> JobResponsibility)
        {
            JobResponsibility.InsertSpName = "spInsertJobResponsibility";
            JobResponsibility.UpdateSpName = "spUpdateJobResponsibility";
            JobResponsibility.DeleteSpName = "spDeleteJobResponsibility";
        }
        #endregion

        #region Family Details

        public CustomList<HRM_EmpFamDet> GetAllHRM_EmpFamDetByFamKey(long empKey)
        {
            return HRM_EmpFamDet.GetAllHRM_EmpFamDetByFamKey(empKey);
        }
        #endregion

        #region Emp Education
        public CustomList<HRM_EmpEdu> GetAllEmpEdu()
        {
            return HRM_EmpEdu.GetAllHRM_EmpEdu();
        }

        public CustomList<HRM_EmpEduDip> GetAllDipEdu()
        {
            return HRM_EmpEduDip.GetAllHRM_EmpEduDip();
        }

        public CustomList<HRM_EmpEdu> GetAllEmpEduByEmpKey(string EmpKey)
        {
            return HRM_EmpEdu.GetAllEmpEduByEmpKey(EmpKey);
        }

        public CustomList<HRM_EmpEduDip> GetAllDipEduByEmpKey(string EmpKey)
        {
            return HRM_EmpEduDip.GetAllDipEduByEmpKey(EmpKey);
        }
        public CustomList<HRM_EmpEduDip> GetAllDipEduByEmpKey(string EmpKey, string type)
        {
            return HRM_EmpEduDip.GetAllDipEduByEmpKey(EmpKey, type);
        }
        public CustomList<EducationQualification> GetAllEduQual()
        {
            return EducationQualification.GetAllEducationQualification();
        }
        public void SaveEmpEdu(ref CustomList<HRM_EmpEdu> eduList, ref CustomList<HRM_EmpEduDip> dipEduList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(eduList);
                ReSetSPName(dipEduList);

                //GetNewUserID(ref conManager, ref userList);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, eduList);

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, dipEduList);

                eduList.AcceptChanges();
                dipEduList.AcceptChanges();

                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
            }
            catch (Exception Ex)
            {
                conManager.RollBack();
                throw Ex;
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
        }

        private void ReSetSPName(CustomList<HRM_EmpEdu> eduList)
        {
            eduList.InsertSpName = "spInsertHRM_EmpEdu";
            eduList.UpdateSpName = "spUpdateHRM_EmpEdu";
            eduList.DeleteSpName = "spDeleteHRM_EmpEdu";
        }

        private void ReSetSPName(CustomList<HRM_EmpEduDip> dipEduList)
        {
            dipEduList.InsertSpName = "spInsertHRM_EmpEduDip";
            dipEduList.UpdateSpName = "spUpdateHRM_EmpEduDip";
            dipEduList.DeleteSpName = "spDeleteHRM_EmpEduDip";
        }
        #endregion

        #region Emp Family
        public CustomList<HRM_EmpFamDet> GetAllFamDet()
        {
            return HRM_EmpFamDet.GetAllHRM_EmpFamDet();
        }

        public CustomList<HRM_EmpFamily> GetAllFam()
        {
            return HRM_EmpFamily.GetAllHRM_EmpFamily();
        }

        public CustomList<HRM_EmpFamily> GetAllEmpFamByEmpKey(string empKey)
        {
            return HRM_EmpFamily.GetAllEmpFamByEmpKey(empKey);
        }

        public CustomList<HRM_EmpFamDet> GetAllFamDetByFamKey(long famKey)
        {
            return HRM_EmpFamDet.GetAllHRM_EmpFamDetByFamKey(famKey);
        }

        public void SaveEmpFam(ref CustomList<HRM_EmpFamily> empFam, ref CustomList<HRM_EmpFamDet> empFamDet)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(empFam);
                ReSetSPName(empFamDet);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, empFam);
                empFam.AcceptChanges();

                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
            }
            catch (Exception Ex)
            {
                conManager.RollBack();
                throw Ex;
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
        }

        public void SaveChild(ref CustomList<HRM_EmpFamily> empFam, ref CustomList<HRM_EmpFamDet> empFamDet)
        {
            var empKey = empFam[0].EmpKey;
            var empFamKey = GetAllFam().Where(x => x.EmpKey == empKey).FirstOrDefault().EmpFamilyKey;
            foreach (var item in empFamDet)
            {
                item.EmpKey = empFamKey;
            }

            if (empFamDet.Count == 0) return;

            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(empFam);
                ReSetSPName(empFamDet);

                blnTranStarted = true;


                conManager.SaveDataCollectionThroughCollection(blnTranStarted, empFamDet);
                empFamDet.AcceptChanges();


                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
            }
            catch (Exception Ex)
            {
                conManager.RollBack();
                throw Ex;
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
        }

        private void ReSetSPName(CustomList<HRM_EmpFamDet> empFamDet)
        {
            empFamDet.InsertSpName = "spInsertHRM_EmpFamDet";
            empFamDet.UpdateSpName = "spUpdateHRM_EmpFamDet";
            empFamDet.DeleteSpName = "spDeleteHRM_EmpFamDet";
        }

        private void ReSetSPName(CustomList<HRM_EmpFamily> empFam)
        {
            empFam.InsertSpName = "spInsertHRM_EmpFamily";
            empFam.UpdateSpName = "spUpdateHRM_EmpFamily";
            empFam.DeleteSpName = "spDeleteHRM_EmpFamily";
        }
        #endregion

        #region Emp History

        public CustomList<HRM_EmpEmployment> GetAllEmpHistory()
        {
            return HRM_EmpEmployment.GetAllHRM_EmpEmployment();
        }

        public CustomList<HRM_EmpEmployment> GetAllEmpHistByEmpKey(string EmpKey)
        {
            return HRM_EmpEmployment.GetAllEmpHistByEmpKey(EmpKey);
        }


        public void SaveEmpHist(ref CustomList<HRM_EmpEmployment> empFamHist)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(empFamHist);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, empFamHist);
                empFamHist.AcceptChanges();

                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
            }
            catch (Exception Ex)
            {
                conManager.RollBack();
                throw Ex;
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
        }

        private void ReSetSPName(CustomList<HRM_EmpEmployment> empFamHist)
        {
            empFamHist.InsertSpName = "spInsertHRM_EmpEmployment";
            empFamHist.UpdateSpName = "spUpdateHRM_EmpEmployment";
            empFamHist.DeleteSpName = "spDeleteHRM_EmpEmployment";
        }

        #endregion

        #region Emp Files

        public CustomList<HRM_EmpFileAttach> GetAllEmpfile()
        {
            return HRM_EmpFileAttach.GetAllHRM_EmpFileAttach();
        }

        public CustomList<HRM_EmpFileAttach> GetAllEmpfileByEmpKey(string EmpKey)
        {
            return HRM_EmpFileAttach.GetAllEmpfileByEmpKey(EmpKey);
        }

        public void SaveEmpFile(ref CustomList<HRM_EmpFileAttach> empFile)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(empFile);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, empFile);
                empFile.AcceptChanges();

                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
            }
            catch (Exception Ex)
            {
                conManager.RollBack();
                throw Ex;
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
        }

        private void ReSetSPName(CustomList<HRM_EmpFileAttach> empFile)
        {
            empFile.InsertSpName = "spInsertHRM_EmpFileAttach";
            empFile.UpdateSpName = "spUpdateHRM_EmpFileAttach";
            empFile.DeleteSpName = "spDeleteHRM_EmpFileAttach";
        }

        private void ReSetSPName(CustomList<EmployeeHKInfo> empHKInfo)
        {
            empHKInfo.InsertSpName = "spInsertEmployeeHKInfo";
            empHKInfo.UpdateSpName = "spUpdateEmployeeHKInfo";
            empHKInfo.DeleteSpName = "spDeleteEmployeeHKInfo";
        }

        #endregion

        public void SaveEmployeeInfo(ArrayList empInfo, string mode = "insert")
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();
                blnTranStarted = true;

                #region save parent

                var genInfo = (CustomList<HRM_Emp>)empInfo[0];
                ReSetSPName(genInfo);
                long empKey = genInfo[0].EmpKey;
                if (mode == "insert")
                    empKey = Convert.ToInt32(conManager.InsertData(blnTranStarted, genInfo));
                else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, genInfo);
                genInfo.AcceptChanges();
                #endregion

                var addr = (CustomList<HRM_EmpAddr>)empInfo[1];
                addr.ForEach(x => x.EmpKey = empKey);
                ReSetSPName(addr);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, addr);
                addr.AcceptChanges();

                var EmergencyContact = (CustomList<EmployeeEmergencyInfo>)empInfo[2];
                EmergencyContact.ForEach(x => x.EmpKey = empKey);
                ReSetSPName(EmergencyContact);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, EmergencyContact);
                EmergencyContact.AcceptChanges();

                var JobResponsibility = (CustomList<JobResponsibility>)empInfo[3];
                JobResponsibility.ForEach(x => x.EmpKey = empKey);
                ReSetSPName(JobResponsibility);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, JobResponsibility);
                JobResponsibility.AcceptChanges();

                var edu = (CustomList<HRM_EmpEdu>)empInfo[4];
                edu.ForEach(x => x.EmpKey = empKey);
                ReSetSPName(edu);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, edu);
                edu.AcceptChanges();

                var dip = (CustomList<HRM_EmpEduDip>)empInfo[5];
                dip.ForEach(x => x.EmpKey = empKey);
                ReSetSPName(dip);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, dip);
                dip.AcceptChanges();

                var hist = (CustomList<HRM_EmpEmployment>)empInfo[6];
                hist.ForEach(x => x.EmpKey = empKey);
                ReSetSPName(hist);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, hist);
                hist.AcceptChanges();

                var file = (CustomList<HRM_EmpFileAttach>)empInfo[7];
                file.ForEach(x => x.EmpKey = empKey);
                ReSetSPName(file);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, file);
                file.AcceptChanges();

                CustomList<EmployeeHKInfo> deletedHKInfoList = new CustomList<EmployeeHKInfo>();
                EmployeeHKInfo newHKInfo = new EmployeeHKInfo();
                newHKInfo.EmpKey = empKey;
                newHKInfo.Delete();
                deletedHKInfoList.Add(newHKInfo);
                deletedHKInfoList.DeleteSpName = "spDeleteEmployeeHKInfo";

                var OfficalInfo = (CustomList<EmployeeHKInfo>)empInfo[8];
                OfficalInfo.ForEach(x => x.EmpKey = empKey);
                ReSetSPName(OfficalInfo);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, deletedHKInfoList, OfficalInfo);
                OfficalInfo.AcceptChanges();

                //Delete from Employee Salary
                CustomList<EmployeeSalary> deletedSalaryList = new CustomList<EmployeeSalary>();
                EmployeeSalary eS = new EmployeeSalary();
                eS.EmpKey = empKey;
                eS.Delete();
                deletedSalaryList.Add(eS);
                deletedSalaryList.DeleteSpName = "spDeleteRoleEmployeeSalary";

                var EmpSalary = (CustomList<EmployeeSalaryTemp>)empInfo[9];
                EmpSalary.ForEach(x => x.EmpKey = empKey);
                ReSetSPName(EmpSalary);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, deletedSalaryList, EmpSalary);
                EmpSalary.AcceptChanges();
                deletedSalaryList.AcceptChanges();

                var EmpLanguage = (CustomList<LanguageInfo>)empInfo[10];
                EmpLanguage.ForEach(x => x.EmpKey = empKey);
                ReSetSPName(EmpLanguage);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, EmpLanguage);
                EmpLanguage.AcceptChanges();

                var EmpFamilyDet = (CustomList<HRM_EmpFamDet>)empInfo[11];
                EmpFamilyDet.ForEach(x => x.EmpKey = empKey);
                ReSetSPName(EmpFamilyDet);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, EmpFamilyDet);
                EmpFamilyDet.AcceptChanges();

                var MedicalAllowance = (CustomList<MedicalReinSetup>)empInfo[12];
                MedicalAllowance.ForEach(x => x.EmpKey = empKey);
                ReSetSPName(MedicalAllowance);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, MedicalAllowance);
                MedicalAllowance.AcceptChanges();

                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
            }
            catch (Exception Ex)
            {
                conManager.RollBack();
                throw Ex;
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
        }
        private void ReSetSPName(CustomList<MedicalReinSetup> empMedicalAllowance)
        {
            empMedicalAllowance.InsertSpName = "spInsertMedicalReinSetup";
            empMedicalAllowance.UpdateSpName = "spUpdateMedicalReinSetup";
            empMedicalAllowance.DeleteSpName = "spDeleteMedicalReinSetup";
        }
        private void ReSetSPName(CustomList<EmployeeSalaryTemp> empSalary)
        {
            empSalary.InsertSpName = "spInsertEmployeeSalaryTemp";
            empSalary.UpdateSpName = "spUpdateEmployeeSalaryTemp";
            empSalary.DeleteSpName = "spDeleteEmployeeSalaryTemp";
        }
        private void ReSetSPName(CustomList<LanguageInfo> empLanguage)
        {
            empLanguage.InsertSpName = "spInsertLanguageInfo";
            empLanguage.UpdateSpName = "spUpdateLanguageInfo";
            empLanguage.DeleteSpName = "spDeleteLanguageInfo";
        }
        private void GetNewCode(ref ConnectionManager conManager, ref CustomList<HRM_Emp> EmpList)
        {
            String newEmpCode = String.Empty;
            try
            {
                CustomList<HRM_Emp> addedEmpList = EmpList.FindAll(f => f.IsAdded);
                if (addedEmpList.Count != 0)
                {
                    newEmpCode = StaticInfo.MakeUniqueCode(ref conManager, "EmpCode", 20, DateTime.Today.ToString(), "yy", "Emp", "-", "");
                    addedEmpList[0].EmpCode = newEmpCode;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}