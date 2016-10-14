using System;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;
using ASL.Security.DAO;

namespace ASL.Security.BLL
{
    public class GroupInformationManager
    {
        private String groupID = String.Empty;
        public String GroupID
        {
            get { return groupID; }
        }
        public CustomList<Users> GetAllUsers()
        {
            return Users.doSearch(string.Empty);//.GetAllUsers();
        }
        public CustomList<UserGroup> GetAllUser()
        {
            return UserGroup.GetAllUser();
        }
        public CustomList<UserGroup> GetAllUserGroup(string groupCode)
        {
            return UserGroup.GetAllUserGroup(groupCode);
        }
        public CustomList<GroupRule> GetAllGroupSecurityRule(string groupCode)
        {
            return GroupRule.GetAllGroupSecurityRule(groupCode);
        }
        public CustomList<Company_Entity> GetAllCompany_Entity()
        {
            return Company_Entity.GetAllCompany_Entity();
        }
        public CustomList<Application> GetAllApplication()
        {
            return Application.GetAllApplication();
        }
        public CustomList<SecurityRule> GetAlltblSecurityRule()
        {
            return SecurityRule.doSearch(String.Empty);
        }
        public CustomList<Menu> GetAllMenuByApplicationID(string applicationID)
        {
            int ID = Convert.ToInt32(applicationID);
            return Menu.GetAllMenuByApplicationID(ID);
        }
        public CustomList<Group> GetAllGroup()
        {
            return Group.doSearch(String.Empty);
        }
        public CustomList<RuleDetails> GetAllSecurityRule_ObjectWithSecurityRule(string securityRuleCode)
        {
            return RuleDetails.GetAllSecurityRule_ObjectWithSecurityRule(securityRuleCode);
        }

        public void DeleteTempData(ref CustomList<GroupRule> lstGroupSecurityRule)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            Boolean blnTranStarted = false;

            try
            {
                ReSetTempTransactionDeleteSPName(ref lstGroupSecurityRule);
                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstGroupSecurityRule);

                lstGroupSecurityRule.AcceptChanges();
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

        public void ReSetTempTransactionDeleteSPName(ref CustomList<GroupRule> lstGroupSecurityRule)
        {
            try
            {
                #region TempSecurityRule
                lstGroupSecurityRule.DeleteSpName = "spDeleteGroupRule";
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveGroup(ref CustomList<UserGroup> tmpUserGroupList, ref CustomList<Group> groupList, ref CustomList<GroupRule> groupSecurityRuleList, ref CustomList<UserGroup> userGroupList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(tmpUserGroupList,groupList, groupSecurityRuleList, userGroupList);

                GetNewGroupID(ref conManager, ref groupList, ref groupSecurityRuleList, ref userGroupList);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, tmpUserGroupList, groupList, groupSecurityRuleList, userGroupList);

                groupList.AcceptChanges();
                groupSecurityRuleList.AcceptChanges();
                userGroupList.AcceptChanges();

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
        private void ReSetSPName(CustomList<UserGroup> tmpUserGroupList, CustomList<Group> groupList, CustomList<GroupRule> groupSecurityRuleList, CustomList<UserGroup> userGroupList)
        {
            #region Security Rule

            groupList.InsertSpName = "spInsertGroup";
            groupList.UpdateSpName = "spUpdateGroup";
            #endregion
            #region Group Security Rule
            groupSecurityRuleList.InsertSpName = "spInsertGroupRule";
            #endregion
            #region User Group
            userGroupList.InsertSpName = "spInsertUserGroup";
            #endregion
            #region tmp User Group
            tmpUserGroupList.DeleteSpName = "spDeleteUserGroup";
            #endregion
        }
        private void ReSetDeleteSPName(CustomList<Group> groupList, CustomList<GroupRule> groupSecurityRuleList, CustomList<UserGroup> userGroupList)
        {
            #region Security Rule
            groupList.DeleteSpName = "spDeleteGroup";
            #endregion
            #region Group Security Rule
            groupSecurityRuleList.DeleteSpName = "spDeleteGroupRule";
            #endregion
            #region User Group
            userGroupList.DeleteSpName = "spDeleteUserGroup";
            #endregion
        }
        private void GetNewGroupID(ref ConnectionManager conManager, ref CustomList<Group> groupList, ref CustomList<GroupRule> groupSecurityRuleList, ref CustomList<UserGroup> userGroupList)
        {
            String newGroupID = String.Empty;
            try
            {
                CustomList<Group> tempGroupList = groupList.FindAll(f => f.IsAdded);
                if (tempGroupList.Count != 0)
                {
                    foreach (Group group in groupList)
                    {
                        newGroupID = StaticInfo.MakeUniqueCode("GroupCode", 20, DateTime.Today.ToString(), "yy", "G", "-", "");
                        group.GroupCode = newGroupID;
                        groupID = newGroupID;
                    }
                }
                else
                {
                    groupID = groupList[0].GroupCode;
                }

                CustomList<GroupRule> tempGroupSecurityRuleList = groupSecurityRuleList.FindAll(f => f.IsAdded);
                foreach (GroupRule gSR in tempGroupSecurityRuleList)
                {
                    gSR.GroupCode = groupID;
                }
                CustomList<UserGroup> tempUserGroupList = userGroupList.FindAll(f => f.IsAdded);
                foreach (UserGroup uG in tempUserGroupList)
                {
                    uG.GroupCode = groupID;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteGroup(ref CustomList<UserGroup> userGroupList, ref CustomList<GroupRule> groupSecurityRuleList, ref CustomList<Group> groupList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            Boolean blnTranStarted = false;

            try
            {
                ReSetDeleteSPName(groupList, groupSecurityRuleList, userGroupList);

                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, userGroupList, groupSecurityRuleList, groupList);
                userGroupList.AcceptChanges();
                groupSecurityRuleList.AcceptChanges();
                groupList.AcceptChanges();
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
    }
}
