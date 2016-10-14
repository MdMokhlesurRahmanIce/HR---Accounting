using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.DATA;
using ASL.STATIC;
using ASL.Security.BLL;
using ASL.Security.DAO;
using ASL.Web.Framework;
using System.Data.SqlClient;

namespace Hr.Web.UI.Security
{
    public partial class GroupInformation : PageBase
    {
        GroupInformationManager manager = new GroupInformationManager();
        CustomList<GroupRule> groupSecurityRuleList = new CustomList<GroupRule>();
        CustomList<Group> groupList = new CustomList<Group>();
        CustomList<UserGroup> objUserGroupList = new CustomList<UserGroup>();

        #region Constructur
        public GroupInformation()
        {
            RequiresAuthorization = true;
        }
        #endregion

        #region Session Event

        //private CustomList<Group> GroupList
        //{
        //    get
        //    {
        //        if (Session["SecurityRule_GroupList"] == null)
        //            return new CustomList<CSRL.SECURITY.DAO.SecurityRule>();
        //        else
        //            return (CustomList<CSRL.SECURITY.DAO.SecurityRule>)Session["SecurityRule_GroupList"];
        //    }
        //    set
        //    {
        //        Session["SecurityRule_GroupList"] = value;
        //    }
        //}

        private CustomList<ASL.Security.DAO.SecurityRule> SecurityRuleList
        {
            get
            {
                if (Session["SecurityRule_SecurityRuleCodeList"] == null)
                    return new CustomList<ASL.Security.DAO.SecurityRule>();
                else
                    return (CustomList<ASL.Security.DAO.SecurityRule>)Session["SecurityRule_SecurityRuleCodeList"];
            }
            set
            {
                Session["SecurityRule_SecurityRuleCodeList"] = value;
            }
        }

        //private CustomList<ASL.Security.DAO.Menu> MenuList
        //{
        //    get
        //    {
        //        if (Session["SecurityRule_MenuList"] == null)
        //            return new CustomList<ASL.Security.DAO.Menu>();
        //        else
        //            return (CustomList<ASL.Security.DAO.Menu>)Session["SecurityRule_MenuList"];
        //    }
        //    set
        //    {
        //        Session["SecurityRule_MenuList"] = value;
        //    }
        //}
        private CustomList<UserGroup> UserGroupList
        {
            get
            {
                if (Session["GroupInfromation_UserGroupList"] == null)
                    return new CustomList<UserGroup>();
                else
                    return (CustomList<UserGroup>)Session["GroupInfromation_UserGroupList"];
            }
            set
            {
                Session["GroupInfromation_UserGroupList"] = value;
            }
        }
        private CustomList<Group> SearchGroupList
        {
            get
            {
                if (Session["GroupInfromation_SearchGroupList"] == null)
                    return new CustomList<Group>();
                else
                    return (CustomList<Group>)Session["GroupInfromation_SearchGroupList"];
            }
            set
            {
                Session["GroupInfromation_SearchGroupList"] = value;
            }
        }
        private CustomList<GroupRule> SearchGroupSecurityRuleList
        {
            get
            {
                if (Session["GroupInfromation_SearchGroupSecurityRuleList"] == null)
                    return new CustomList<GroupRule>();
                else
                    return (CustomList<GroupRule>)Session["GroupInfromation_SearchGroupSecurityRuleList"];
            }
            set
            {
                Session["GroupInfromation_SearchGroupSecurityRuleList"] = value;
            }
        }
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                    InitializieCombo();

                    ClearControls();
                    InitializeSession();
                    EnableAllControls(false);

                }
                else
                {
                    Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                    String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                    if (Request["__EVENTTARGET"] == "SearchGroup")
                    {
                        Group searchGroup = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as Group;
                        groupList.Add(searchGroup);
                        SearchGroupList = groupList;
                        if (searchGroup.IsNotNull())
                            PopulateGroupInformation(searchGroup);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region All Method
        private void PopulateGroupInformation(Group group)
        {
            try
            {
                SetDataInControls(group);
                groupSecurityRuleList = new CustomList<GroupRule>();
                SecurityRuleList = new CustomList<ASL.Security.DAO.SecurityRule>();
                SecurityRuleList = manager.GetAlltblSecurityRule();
                groupSecurityRuleList = manager.GetAllGroupSecurityRule(group.GroupCode);
                SearchGroupSecurityRuleList = groupSecurityRuleList;
                foreach (ASL.Security.DAO.SecurityRule sR in SecurityRuleList)
                {
                    CustomList<GroupRule> gSRList = groupSecurityRuleList.FindAll(f => f.SecurityRuleCode == sR.SecurityRuleCode);
                    foreach (GroupRule gSR in gSRList)
                    {
                        sR.IsSaved = true;
                    }
                }
                //PopulateMenuItem();

                UserGroupList = new CustomList<UserGroup>();
                UserGroupList = manager.GetAllUser();
                CustomList<UserGroup> SelectedUser = manager.GetAllUserGroup(group.GroupCode);
                foreach (UserGroup uG in UserGroupList)
                {
                    UserGroup user = SelectedUser.Find(f => f.UserCode == uG.UserCode);
                    if (user.IsNotNull())
                    {
                        uG.IsSaved = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void SetDataInControls(Group group)
        {
            try
            {
                txtGroupCode.Text = group.GroupCode;
                txtGroupName.Text = group.GroupName;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //private void PopulateMenuItem()
        //{
        //    try
        //    {
        //        //MenuList = new CustomList<ASL.Security.DAO.Menu>();
        //        //MenuList = manager.GetAllMenuByApplicationID(drpApplication.SelectedValue.ToString());
        //        CustomList<ASL.Security.DAO.SecurityRule> SelectedAllSecurityRuleList = SecurityRuleList.FindAll(f => f.IsSaved);
        //        CustomList<RuleDetails> sROList = new CustomList<RuleDetails>();
        //        if (SelectedAllSecurityRuleList.IsNotNull())
        //        {
        //            foreach (ASL.Security.DAO.SecurityRule sR in SelectedAllSecurityRuleList)
        //            {
        //                sROList = manager.GetAllSecurityRule_ObjectWithSecurityRule(sR.SecurityRuleCode);
        //                foreach (RuleDetails sRO in sROList)
        //                {
        //                    foreach (ASL.Security.DAO.Menu m in MenuList)
        //                    {
        //                        if (m.MenuID == sRO.ObjectID && m.ApplicationID == sRO.ApplicationID)
        //                        {
        //                            m.CanInsert = sRO.CanInsert;
        //                            m.CanSelect = sRO.CanSelect;
        //                            m.CanUpdate = sRO.CanUpdate;
        //                            m.CanDelete = sRO.CanDelete;
        //                        }
        //                    }
        //                }
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        private void InitializieCombo()
        {
            //drpCompany.DataSource = manager.GetAllCompany_Entity();
            //drpCompany.DataTextField = "Company_Name";
            //drpCompany.DataValueField = "CompanyID";
            //drpCompany.DataBind();
            //drpCompany.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            //drpCompany.SelectedIndex = 0;

            //drpDefaultApplication.DataSource = manager.GetAllApplication();
            //drpDefaultApplication.DataTextField = "ApplicationName";
            //drpDefaultApplication.DataValueField = "ApplicationID";
            //drpDefaultApplication.DataBind();
            //drpDefaultApplication.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            //drpDefaultApplication.SelectedIndex = 0;

            //drpApplication.DataSource = manager.GetAllApplication();
            //drpApplication.DataTextField = "ApplicationName";
            //drpApplication.DataValueField = "ApplicationID";
            //drpApplication.DataBind();
            //drpApplication.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            //drpApplication.SelectedIndex = 0;

            //drpUser.DataSource = manager.GetAllUsers();
            //drpUser.DataTextField = "Name";
            //drpUser.DataValueField = "UserCode";
            //drpUser.DataBind();
            //drpUser.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            //drpUser.SelectedIndex = 0;
        }
        private void InitializeSession()
        {
            SecurityRuleList = new CustomList<ASL.Security.DAO.SecurityRule>();
            SecurityRuleList = manager.GetAlltblSecurityRule();
            //MenuList = new CustomList<ASL.Security.DAO.Menu>();
            UserGroupList = new CustomList<UserGroup>();
            UserGroupList = manager.GetAllUser();
            SearchGroupList = new CustomList<Group>();
            SearchGroupSecurityRuleList = new CustomList<GroupRule>();
        }
        private void ClearControls()
        {
            try
            {
                //drpCompany.SelectedValue = String.Empty;
                txtGroupCode.Text = String.Empty;
                txtGroupName.Text = String.Empty;
                //txtGroupDescription.Text = String.Empty;
                //drpDefaultApplication.SelectedValue = String.Empty;
                //drpUser.SelectedValue = String.Empty;
                //drpApplication.SelectedValue = String.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void EnableAllControls(Boolean status)
        {
            try
            {
                //drpCompany.Enabled = status;
                txtGroupCode.Enabled = status;
                txtGroupName.Enabled = status;
                //txtGroupDescription.Enabled = status;
                //drpDefaultApplication.Enabled = status;
                //drpUser.Enabled = status;
                //drpApplication.Enabled = status;

                btnSave.Enabled = status;
                btnDelete.Enabled = status;
                btnCancel.Enabled = status;
                btnRefresh.Enabled = status;
                //btnUserAdd.Enabled = status;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetDataFromControls(ref CustomList<Group> lstGroup)
        {
            try
            {
                #region Group
                Group group = lstGroup[0];
                group.GroupCode = txtGroupCode.Text;
                group.GroupName = txtGroupName.Text;
                #endregion

                #region Group Security Rule

                #region Delete
                CustomList<GroupRule> TempGroupSecurityRule = manager.GetAllGroupSecurityRule(lstGroup[0].GroupCode);
                if (TempGroupSecurityRule.Count != 0)
                {
                    foreach (GroupRule objGroupSecurityRule in TempGroupSecurityRule)
                    {
                        objGroupSecurityRule.Delete();
                    }
                    manager.DeleteTempData(ref TempGroupSecurityRule);
                }
                #endregion

                CustomList<ASL.Security.DAO.SecurityRule> SelectedSecurityRuleList = SecurityRuleList.FindAll(f => f.IsSaved);
                foreach (ASL.Security.DAO.SecurityRule sR in SelectedSecurityRuleList)
                {
                    GroupRule gSR = new GroupRule();
                    gSR.ApplicationID = "1";
                    gSR.GroupCode = txtGroupCode.Text;
                    gSR.SecurityRuleCode = sR.SecurityRuleCode;
                    //gSR.CompanyID = drpCompany.SelectedValue;
                    groupSecurityRuleList.Add(gSR);
                }
                #endregion
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Button Event
        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearControls();
                InitializeSession();
                EnableAllControls(true);
                btnDelete.Enabled = false;
                txtGroupCode.Text = StaticInfo.NewIDString;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeSession();
                InitializieCombo();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<Group> items = manager.GetAllGroup();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("GroupCode", "Group Code");
                columns.Add("GroupName", "Group Name");

                StaticInfo.SearchItem(items, "Group Info", "SearchGroup", ASL.Web.Framework.SearchColumnConfig.GetColumnConfig(typeof(Group), columns), 500);
                EnableAllControls(true);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ("Error: <br>" + ex.Message + "<br>Call Stack: <br>" + ex.StackTrace);
            }
        }
        //protected void btnUserAdd_Click(object sender, ImageClickEventArgs e)
        //{
        //    try
        //    {
        //            int itemCount = 0;
        //            itemCount = UserGroupList.Count;
        //            if (itemCount == 0)
        //            {
        //                UserGroup uG = new UserGroup();
        //                //uG.UserCode = drpUser.SelectedValue;
        //                uG.GroupCode = txtGroupCode.Text;
        //                UserGroupList.Add(uG);
        //            }
        //            else
        //            {
        //                itemCount = itemCount + 1;
        //                UserGroup uG = new UserGroup();
        //                uG.UserCode = drpUser.SelectedValue;
        //                uG.GroupCode = txtGroupCode.Text;
        //                UserGroupList.Add(uG);
        //            }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                InitializieCombo();

                ClearControls();
                InitializeSession();
                EnableAllControls(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                CustomList<Group> lstGroup = SearchGroupList;
                if (lstGroup.Count == 0)
                {
                    Group newGroup = new Group();
                    lstGroup.Add(newGroup);
                }

                CustomList<GroupRule> lstGroupSecurityRule = SearchGroupSecurityRuleList;
                if (lstGroupSecurityRule.Count == 0)
                {
                    GroupRule newGroupSecurityRule = new GroupRule();
                    lstGroupSecurityRule.Add(newGroupSecurityRule);
                }

                SetDataFromControls(ref lstGroup);
                objUserGroupList = UserGroupList.FindAll(f => f.IsSaved);
                foreach (UserGroup uG in objUserGroupList)
                {
                    uG.SetAdded();
                }
                if (groupList.IsNotNull())
                {
                    CustomList<UserGroup> TempUserGroup = manager.GetAllUserGroup(lstGroup[0].GroupCode);
                    if (TempUserGroup.Count != 0)
                    {
                        foreach (UserGroup uG in TempUserGroup)
                        {
                            uG.Delete();
                        }
                    }
                    if (!CheckUserAuthentication(lstGroup, groupSecurityRuleList, objUserGroupList)) return;
                    manager.SaveGroup(ref TempUserGroup, ref lstGroup, ref groupSecurityRuleList, ref objUserGroupList);
                    txtGroupCode.Text = manager.GroupID;
                    this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                }
            }
            catch (SqlException ex)
            {
                this.ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                objUserGroupList = new CustomList<UserGroup>();
                objUserGroupList = UserGroupList.FindAll(f=>f.IsSaved);
                groupList = SearchGroupList;
                groupSecurityRuleList = SearchGroupSecurityRuleList;
                if (groupList[0].GroupCode != StaticInfo.NewIDString && groupList.Count != 0)
                {
                    foreach (UserGroup uG in objUserGroupList)
                    {
                        if (uG.IsDeleted.IsFalse())
                            uG.Delete();
                    }

                    foreach (GroupRule gSR in groupSecurityRuleList)
                    {
                        if (gSR.IsDeleted.IsFalse())
                            gSR.Delete();
                    }
                    foreach (Group group in groupList)
                    {
                        if (group.IsDeleted.IsFalse())
                            group.Delete();
                    }
                    if (CheckUserAuthentication(objUserGroupList, groupSecurityRuleList, groupList).IsFalse()) return;
                    manager.DeleteGroup(ref objUserGroupList, ref groupSecurityRuleList, ref groupList);
                    ClearControls();
                    InitializeSession();
                    this.ErrorMessage = (StaticInfo.DeletedSuccessfullyMsg);
                    EnableAllControls(false);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region Combo Event
        //protected void drpApplication_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //MenuList = manager.GetAllMenuByApplicationID(drpApplication.SelectedValue.ToString());
        //    //PopulateMenuItem();
        //}
        #endregion
    }
}
