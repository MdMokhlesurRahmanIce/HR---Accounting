using System;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using ASL.Security.DAO;


namespace ASL.Security.BLL
{
    public class SecurityManager
    {
        private String securityRuleInfoID = String.Empty;
        public String SecurityRuleInfoID
        {
            get { return securityRuleInfoID; }
        }
        public CustomList<SecurityRule> GetAlltblSecurityRule()
        {
            return SecurityRule.doSearch(String.Empty);
        }
        public CustomList<RuleDetails> GetAllSecurityRule_ObjectWithSecurityRule(string securityRuleCode)
        {
            //int ID = Convert.ToInt32(applicationID);
            return RuleDetails.GetAllSecurityRule_ObjectWithSecurityRule(securityRuleCode);
        }
        public CustomList<RuleDetails> GetAllSecurityRule_ObjectWithApplicationID(string applicationID)
        {
            //int ID = Convert.ToInt32(applicationID);
            return RuleDetails.GetAllSecurityRule_ObjectWithApplicationID(applicationID);
        }
        public CustomList<SecurityRule> GettblSecurityRuleForSearch()
        {
            return SecurityRule.doSearch(String.Empty);
        }
        public CustomList<Company_Entity> GetAllCompany_Entity()
        {
            return Company_Entity.GetAllCompany_Entity();
        }
        public CustomList<ApplicationList> GetAllApplicationName(string companyID)
        {
            return ApplicationList.GetAllApplicationName(companyID);
        }
        public CustomList<Application> GetAllApplication()
        {
            return Application.GetAllApplication();
        }
        public CustomList<Menu> GetAllMenuByApplicationID(string applicationID)
        {
            int ID = Convert.ToInt32(applicationID);
            return Menu.GetAllMenuByApplicationID(ID);
        }

        public Users GetUserByNameAndPassword(string userName, string password)
        {
            return Users.DoLogin(userName, password);
        }

        public CustomList<Menu> GetAllMenuItemsByUserCode(string UserCode)
        {
            return Menu.GetAllMenuItemsByUserCode(UserCode);
        }

        public Menu GetAllAccessRightsOfAPage(string UserCode, int ObjectID)
        {
            return Menu.GetAllAccessRightsOfAPage(UserCode, ObjectID);
        }

        public CustomList<LeftMenuItems> GetAllLeftMenuItemsByUserCodeAndApplicationID(string UserCode, int ObjectID)
        {
            return LeftMenuItems.GetAllLeftMenuItemsByUserCodeAndApplicationID(UserCode, ObjectID);
        }

        public FormAccessRights GetFormAccessRights(string userCode, string formName)
        {
            return FormAccessRights.GetFormAccessRightsByUserCodeAndFormName(userCode, formName);
        }

        public Users GetUserInfoByEmployeeCode(String employeeCode)
        {
            return Users.GetUserInfoByEmployeeCode(employeeCode);
        }

        public CustomList<UserWiseHiddenControls> GetUserWiseHiddenControls(String nameSpace, String formName, String userCode)
        {
            return UserWiseHiddenControls.GetUserWiseHiddenControls(nameSpace, formName, userCode);
        }
        public void SaveSecurityRule(ref CustomList<SecurityRule> securityRuleList, ref CustomList<RuleDetails> securityRuleDetailList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(securityRuleList, securityRuleDetailList);

                GetNewSecurityRuleID(ref conManager, ref securityRuleList, ref securityRuleDetailList);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, securityRuleList, securityRuleDetailList);

                securityRuleList.AcceptChanges();
                securityRuleDetailList.AcceptChanges();


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
        private void ReSetSPName(CustomList<SecurityRule> securityRule, CustomList<RuleDetails> securityRuleDetailList)
        {
            #region Security Rule

            securityRule.InsertSpName = "spInsertRule";
            securityRule.UpdateSpName = "spUpdateRule";
            securityRule.DeleteSpName = "spDeleteRule";
            #endregion
            #region
            securityRuleDetailList.InsertSpName = "spInsertRuleDetails";
            securityRuleDetailList.UpdateSpName = "spUpdateRuleDetails";
            securityRuleDetailList.DeleteSpName = "spDeleteRuleDetails";
            if (securityRuleDetailList.Count != 0)
            {
                if (!securityRuleDetailList[0].IsDeleted)
                {
                    if (securityRuleDetailList.Count != 0)
                    {
                        foreach (RuleDetails sRO in securityRuleDetailList)
                        {
                            sRO.SetAdded();
                        }
                    }
                }
            }
            #endregion
        }
        private void ReSetSPNameForDelete(CustomList<SecurityRule> securityRule, CustomList<RuleDetails> securityRuleDetailList)
        {
            securityRule.DeleteSpName = "spDeleteRule";
            securityRuleDetailList.DeleteSpName = "spDeleteRuleDetails";
        }
        private void GetNewSecurityRuleID(ref ConnectionManager conManager, ref CustomList<SecurityRule> securityRuleList, ref CustomList<RuleDetails> securityRuleDetailList)
        {
            String newSecurityRuleID = String.Empty;
            try
            {
                CustomList<SecurityRule> tempSecurityRuleList = securityRuleList.FindAll(f => f.IsAdded);
                if (tempSecurityRuleList.Count != 0)
                {
                    newSecurityRuleID = StaticInfo.MakeUniqueCode("SecurityRuleCode", 20, DateTime.Today.ToString(), "yy", "SR", "-", "");
                    securityRuleList[0].SecurityRuleCode = newSecurityRuleID;
                    securityRuleInfoID = newSecurityRuleID;
                }
                else
                {
                    securityRuleInfoID = securityRuleList[0].SecurityRuleCode;
                }

                CustomList<RuleDetails> tempSecurityRuleDetailList = securityRuleDetailList.FindAll(f => f.IsAdded);
                foreach (RuleDetails sRO in tempSecurityRuleDetailList)
                {
                    sRO.SecurityRuleCode = securityRuleList[0].SecurityRuleCode;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void DeleteSecurityRule(ref CustomList<RuleDetails> objSecurityRuleDetailList, ref CustomList<SecurityRule> securityRuleList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            Boolean blnTranStarted = false;

            try
            {
                ReSetSPNameForDelete(securityRuleList, objSecurityRuleDetailList);

                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, objSecurityRuleDetailList, securityRuleList);
                objSecurityRuleDetailList.AcceptChanges();
                securityRuleList.AcceptChanges();
                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
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

        public void TempSecurityRule_ObjectDelete(ref CustomList<RuleDetails> lstSecurityRule_Object)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            Boolean blnTranStarted = false;

            try
            {
                ReSetTempSecurityRule_ObjectDeleteSPName(ref lstSecurityRule_Object);
                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstSecurityRule_Object);

                lstSecurityRule_Object.AcceptChanges();
                conManager.CommitTransaction();
                blnTranStarted = false;
                conManager.Dispose();
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

        private void ReSetTempSecurityRule_ObjectDeleteSPName(ref CustomList<RuleDetails> lstSecurityRule_Object)
        {
            #region Temp SecurityRule_Object
            lstSecurityRule_Object.DeleteSpName = "spDeleteRuleDetails";
            #endregion
        }
    }
}
