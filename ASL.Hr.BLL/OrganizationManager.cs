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
    public class OrganizationManager
    {
        #region organization

        public CustomList<Organization> GetAllCompany()
        {
            return Organization.GetAllOrganization(2);
        }

        public CustomList<Organization> GetAllBranch()
        {
            return Organization.GetAllOrganization(4);
        }

        public CustomList<Organization> GetAllDept()
        {
            return Organization.GetAllOrganization(6);
        }

        public void SaveOrganization(ref CustomList<Organization> orgs, string flag, CustomList<Organization> CompanyList = null)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;
            try
            {
                conManager.BeginTransaction();
                ReSetSPName(orgs);
                blnTranStarted = true;
                CustomList<Organization> addedList = new CustomList<Organization>();
                CustomList<Organization> ModifiedList = new CustomList<Organization>();
                string orgCode = "";
               
                switch (flag)
                {
                    case "Company":
                        addedList = orgs.FindAll(f => f.IsAdded);
                        if (addedList.Count != 0)
                        {
                            foreach (Organization o in addedList)
                            {
                                var group = orgs.FindAll(p => !string.IsNullOrEmpty(p.OrgCode));
                                if (group.Count == 0) orgCode = "01";
                                else
                                {
                                    int code = group.Max(p => p.OrgCode.Substring(0, 2).ToInt()) + 1;
                                    orgCode = code.ToString().PadLeft(2, '0');
                                }
                                o.OrgCode = orgCode;
                                o.OrgParentKey = 0;
                                o.OrgLevel = 1;
                            }
                        }
                        conManager.SaveDataCollectionThroughCollection(blnTranStarted, orgs);
                        orgs.AcceptChanges();
                        conManager.CommitTransaction();
                        blnTranStarted = false;
                        break;

                    case "Branch":
                        addedList = orgs.FindAll(f => f.IsAdded);
                        if (addedList.Count != 0)
                        {
                            foreach (Organization o in addedList)
                            {
                                orgCode = CompanyList.Find(p => p.OrgKey == o.OrgParentKey).OrgCode;
                                orgCode = orgCode.Substring(0, 2);

                                var group = orgs.FindAll(p => !string.IsNullOrEmpty(p.OrgCode) && (p.OrgCode.Substring(0, 2) == orgCode));
                                if (group.Count == 0) orgCode += "01";
                                else
                                {
                                    int code = group.Max(p => p.OrgCode.Substring(2, 2).ToInt()) + 1;
                                    orgCode += code.ToString().PadLeft(2, '0');
                                }
                                o.OrgCode = orgCode;

                                o.OrgLevel = 2;
                            }
                        }
                        ModifiedList = orgs.FindAll(f => f.IsModified);
                        foreach (Organization o in ModifiedList)
                        {
                            string pCode = CompanyList.Find(p => p.OrgKey == o.OrgParentKey).OrgCode;
                            string bCode = o.OrgCode.Substring(0, 2);
                            if (pCode != bCode)
                            {
                                orgCode = CompanyList.Find(p => p.OrgKey == o.OrgParentKey).OrgCode;
                                orgCode = orgCode.Substring(0, 2);

                                var group = orgs.FindAll(p => !string.IsNullOrEmpty(p.OrgCode) && (p.OrgCode.Substring(0, 2) == orgCode));
                                if (group.Count == 0) orgCode += "01";
                                else
                                {
                                    int code = group.Max(p => p.OrgCode.Substring(2, 2).ToInt()) + 1;
                                    orgCode += code.ToString().PadLeft(2, '0');
                                }
                                o.OrgCode = orgCode;

                                o.OrgLevel = 2;
                            }
                        }
                        conManager.SaveDataCollectionThroughCollection(blnTranStarted, orgs);
                        orgs.AcceptChanges();
                        conManager.CommitTransaction();
                        blnTranStarted = false;
                        break;

                    case "Department":
                        addedList = orgs.FindAll(f => f.IsAdded);
                        if (addedList.Count != 0)
                        {
                            foreach (Organization o in addedList)
                            {
                                orgCode = o.BranchName;

                                var group = orgs.FindAll(p => !string.IsNullOrEmpty(p.OrgCode) && (p.OrgCode.Substring(0, 4) == orgCode));
                                if (group.Count == 0) orgCode += "01";
                                else
                                {
                                    int code = group.Max(p => p.OrgCode.Substring(4, 2).ToInt()) + 1;
                                    orgCode += code.ToString().PadLeft(2, '0');
                                }
                                o.OrgCode = orgCode;
                                o.OrgParentKey = CompanyList.Find(p => p.OrgCode == o.BranchName).OrgKey;
                                o.OrgLevel = 3;
                            }
                        }
                        ModifiedList = orgs.FindAll(f => f.IsModified);
                        foreach (Organization o in ModifiedList)
                        {
                            string dCode = o.OrgCode.Substring(0, 4);

                            if (dCode != o.BranchName)
                            {
                                orgCode = o.BranchName;

                                var group = orgs.FindAll(p => !string.IsNullOrEmpty(p.OrgCode) && (p.OrgCode.Substring(0, 4) == orgCode));
                                if (group.Count == 0) orgCode += "01";
                                else
                                {
                                    int code = group.Max(p => p.OrgCode.Substring(4, 2).ToInt()) + 1;
                                    orgCode += code.ToString().PadLeft(2, '0');
                                }
                                o.OrgCode = orgCode;
                                o.OrgParentKey = CompanyList.Find(p => p.OrgCode == o.BranchName).OrgKey;
                                o.OrgLevel = 3;
                            }
                        }
                        conManager.SaveDataCollectionThroughCollection(blnTranStarted, orgs);
                        orgs.AcceptChanges();
                        conManager.CommitTransaction();
                        blnTranStarted = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                conManager.RollBack();
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
        }

        private void ReSetSPName(CustomList<Organization> orgs)
        {
            try
            {
                orgs.InsertSpName = "spInsertGen_Org";
                orgs.UpdateSpName = "spUpdateGen_Org";
                orgs.DeleteSpName = "spDeleteGen_Org";
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        #endregion

        #region designation

        public CustomList<Designation> GetAllDesignation()
        {
            return Designation.GetAllDesignation();
        }

        public CustomList<EducationQualification> GetAllEducationQualification()
        {
            return EducationQualification.GetAllEducationQualification();
        }

        public CustomList<Gen_LookupEnt> GetAllGen_LookupEnt()
        {
            return Gen_LookupEnt.GetAllGen_LookupEnt(1);
        }

        public void SaveDesignation(ref CustomList<Designation> designations)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;
            try
            {
                conManager.BeginTransaction();
                ReSetSPName(designations);
                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, designations);
                designations.AcceptChanges();
                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
            }
            catch (Exception)
            {
                conManager.RollBack();
                throw;
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
        }

        private void ReSetSPName(CustomList<Designation> designations)
        {
            designations.InsertSpName = "spInsertDesignation";
            designations.UpdateSpName = "spUpdateDesignation";
            designations.DeleteSpName = "spDeleteDesignation";
        }

        #endregion

        #region education qualification

        public CustomList<EducationQualification> GetAllEduQual()
        {
            return EducationQualification.GetAllEducationQualification();
        }

        public void SaveEduQual(ref CustomList<EducationQualification> eduquals)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;
            try
            {
                conManager.BeginTransaction();
                ReSetSPName(ref eduquals);
                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, eduquals);
                eduquals.AcceptChanges();
                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
            }
            catch (Exception)
            {
                conManager.RollBack();
                throw;
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
        }

        private void ReSetSPName(ref CustomList<EducationQualification> eduquals)
        {
            eduquals.InsertSpName = "spInsertEducationQualification";
            eduquals.UpdateSpName = "spUpdateEducationQualification";
            eduquals.DeleteSpName = "spDeleteEducationQualification";
        }

        #endregion

    }
}
