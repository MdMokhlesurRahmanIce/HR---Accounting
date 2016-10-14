using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.DATA;
using ASL.STATIC;
//using ST.ImageHandler;
using ASL.Security.BLL;
using ASL.Security.DAO;
using ASL.Web.Framework;
using System.Data.SqlClient;

namespace Hr.Web.UI.Security
{
    public partial class SecurityRuleInfo : PageBase
    {
        SecurityManager manager = new SecurityManager();
        CustomList<ASL.Security.DAO.SecurityRule> objSecurityRuleList = new CustomList<ASL.Security.DAO.SecurityRule>();
        CustomList<RuleDetails> objSecurityRuleDetailList = new CustomList<RuleDetails>();
        CustomList<TempRuleDetails> objTempSecurityRuleList = new CustomList<TempRuleDetails>();

        #region Constructur
        public SecurityRuleInfo()
        {
            RequiresAuthorization = true;
        }
        #endregion

        #region Session Value
        private CustomList<ApplicationList> AllApplicationList
        {
            get
            {
                if (Session["SecurityRule_ApplicationList"] == null)
                    return new CustomList<ApplicationList>();
                else
                    return (CustomList<ApplicationList>)Session["SecurityRule_ApplicationList"];
            }
            set
            {
                Session["SecurityRule_ApplicationList"] = value;
            }
        }
        private CustomList<ASL.Security.DAO.Menu> MenuList
        {
            get
            {
                if (Session["SecurityRule_MenuList"] == null)
                    return new CustomList<ASL.Security.DAO.Menu>();
                else
                    return (CustomList<ASL.Security.DAO.Menu>)Session["SecurityRule_MenuList"];
            }
            set
            {
                Session["SecurityRule_MenuList"] = value;
            }
        }
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
        private CustomList<TempRuleDetails> TempSecurityRuleDetailList
        {
            get
            {
                if (Session["SecurityRule_TempSecurityRuleDetailList"] == null)
                    return new CustomList<TempRuleDetails>();
                else
                    return (CustomList<TempRuleDetails>)Session["SecurityRule_TempSecurityRuleDetailList"];
            }
            set
            {
                Session["SecurityRule_TempSecurityRuleDetailList"] = value;
            }
        }
        private CustomList<RuleDetails> SecurityRuleDetailList
        {
            get
            {
                if (Session["SecurityRule_SecurityRuleDetailList"] == null)
                    return new CustomList<RuleDetails>();
                else
                    return (CustomList<RuleDetails>)Session["SecurityRule_SecurityRuleDetailList"];
            }
            set
            {
                Session["SecurityRule_SecurityRuleDetailList"] = value;
            }
        }

        private CustomList<Application> ApplicationList
        {
            get
            {
                if (Session["SecurityRule_ApplicationList"] == null)
                    return new CustomList<Application>();
                else
                    return (CustomList<Application>)Session["SecurityRule_ApplicationList"];
            }
            set
            {
                Session["SecurityRule_ApplicationList"] = value;
            }
        }
        #endregion

        #region View State

        #endregion

        #region Page event
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
                    btnRefresh.Visible = false;
                }
                else
                {
                    Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                    String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                    //if (eventTarget.Equals("SelectGridRow"))
                    //{
                    //    CustomList<ST.SECURITY.DAO.Menu> menu = manager.GetAllMenuByApplicationID(hfApplicationID.Value.ToString());
                    //    MenuList = menu.FindAll(f => f.FormName != "");
                    //    foreach (ST.SECURITY.DAO.Menu m in MenuList)
                    //    {
                    //        CustomList<RuleDetails> tSROList = SecurityRuleDetailList.FindAll(f => f.ObjectID == m.MenuID && f.ApplicationID == m.ApplicationID);
                    //        foreach (RuleDetails tSRO in tSROList)
                    //        {
                    //            m.CanInsert = tSRO.CanInsert;
                    //            m.CanSelect = tSRO.CanSelect;
                    //            m.CanUpdate = tSRO.CanUpdate;
                    //            m.CanDelete = tSRO.CanDelete;
                    //        }
                    //    }
                    //}
                    if (Request["__EVENTTARGET"] == "SearchSecurityRule")
                    {
                        ASL.Security.DAO.SecurityRule searchSecurityRule = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as ASL.Security.DAO.SecurityRule;
                        objSecurityRuleList.Add(searchSecurityRule);
                        SecurityRuleList = objSecurityRuleList;
                        if (searchSecurityRule.IsNotNull())
                            PopulateSecurityRuleInformation(searchSecurityRule);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region All Methods
        private void EnableAllControls(Boolean status)
        {
            try
            {
                txtSecurityRuleCode.Enabled = status;
                cboApplication.Enabled = status;
                txtSecurityRuleName.Enabled = status;
                //txtSecurityRuleDescription.Enabled = status;


                btnSave.Enabled = status;
                btnRefresh.Enabled = status;
                btnCancel.Enabled = status;
                btnDelete.Enabled = status;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void PopulateSecurityRuleInformation(ASL.Security.DAO.SecurityRule sR)
        {
            try
            {
                SetDataInControls(sR);
                objSecurityRuleDetailList = manager.GetAllSecurityRule_ObjectWithSecurityRule(sR.SecurityRuleCode);
                SecurityRuleDetailList = objSecurityRuleDetailList;
                if (SecurityRuleDetailList.Count != 0)
                {
                    cboApplication.SelectedValue = SecurityRuleDetailList[0].ApplicationID;

                    CustomList<ASL.Security.DAO.Menu> menu = manager.GetAllMenuByApplicationID(SecurityRuleDetailList[0].ApplicationID);
                    MenuList = menu.FindAll(f => f.FormName != "");
                    CustomList<RuleDetails> tSROList = SecurityRuleDetailList.FindAll(f => f.ApplicationID == SecurityRuleDetailList[0].ApplicationID);
                    foreach (RuleDetails tSRO in tSROList)
                    {
                        CustomList<ASL.Security.DAO.Menu> sMemuList = MenuList.FindAll(f => f.ApplicationID == tSRO.ApplicationID && f.MenuID == tSRO.ObjectID);
                        foreach (ASL.Security.DAO.Menu m in sMemuList)
                        {
                            m.CanInsert = tSRO.CanInsert;
                            m.CanSelect = tSRO.CanSelect;
                            m.CanUpdate = tSRO.CanUpdate;
                            m.CanDelete = tSRO.CanDelete;
                        }
                    }
                }

                //if (SecurityRuleDetailList.Count != 0)
                //{
                //    foreach (RuleDetails sRO in SecurityRuleDetailList)
                //    {
                //        TempRuleDetails objNewSRO = new TempRuleDetails();
                //        objNewSRO.ApplicationID = sRO.ApplicationID;
                //        objNewSRO.ObjectID = sRO.ObjectID;
                //        objNewSRO.ObjectType = "Menu";
                //        objNewSRO.CanInsert = sRO.CanInsert;
                //        objNewSRO.CanSelect = sRO.CanSelect;
                //        objNewSRO.CanUpdate = sRO.CanUpdate;
                //        objNewSRO.CanDelete = sRO.CanDelete;
                //        TempSecurityRuleDetailList.Add(objNewSRO);
                //    }
                //}

                //CheckedApplicationList();
                //foreach (Application a in ApplicationList)
                //{
                //    if (a.IsSaved == true)
                //    {
                //CustomList<ST.SECURITY.DAO.Menu> menu = manager.GetAllMenuByApplicationID(a.ApplicationID);
                //MenuList = menu.FindAll(f => f.FormName != "");
                //CustomList<RuleDetails> tSROList = SecurityRuleDetailList.FindAll(f => f.ApplicationID == a.ApplicationID);
                //foreach (RuleDetails tSRO in tSROList)
                //{
                //    CustomList<ST.SECURITY.DAO.Menu> sMemuList = MenuList.FindAll(f => f.ApplicationID == tSRO.ApplicationID && f.MenuID == tSRO.ObjectID);
                //    foreach (ST.SECURITY.DAO.Menu m in sMemuList)
                //    {
                //        m.CanInsert = tSRO.CanInsert;
                //        m.CanSelect = tSRO.CanSelect;
                //        m.CanUpdate = tSRO.CanUpdate;
                //        m.CanDelete = tSRO.CanDelete;
                //    }
                //}
                //break;
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //private void CheckedApplicationList()
        //{
        //    try
        //    {
        //        foreach (Application a in ApplicationList)
        //        {
        //            CustomList<RuleDetails> upDate = SecurityRuleDetailList.FindAll(f => f.ApplicationID == a.ApplicationID);
        //            CustomList<RuleDetails> newUpdate = new CustomList<RuleDetails>();
        //            newUpdate = upDate.FindAll(f => f.CanInsert == true || f.CanSelect == true || f.CanUpdate == true || f.CanDelete == true);
        //            if (newUpdate.Count != 0)
        //                a.IsSaved = true;
        //            else
        //                a.IsSaved = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        private void SetDataInControls(ASL.Security.DAO.SecurityRule sR)
        {
            try
            {
                txtSecurityRuleCode.Text = sR.SecurityRuleCode.ToString();
                //cboCompany.SelectedValue = sR.CompanyID.ToString();
                txtSecurityRuleName.Text = sR.SecurityRuleName.ToString();
                //txtSecurityRuleDescription.Text = sR.SecurityRuleDescription.ToString();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void InitializieCombo()
        {
            try
            {
                cboApplication.DataSource = manager.GetAllApplication();
                cboApplication.DataTextField = "ApplicationName";
                cboApplication.DataValueField = "ApplicationID";
                cboApplication.DataBind();
                cboApplication.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                cboApplication.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void ClearControls()
        {
            try
            {
                txtSecurityRuleCode.Text = String.Empty;
                cboApplication.SelectedValue = String.Empty;
                txtSecurityRuleName.Text = String.Empty;
                //txtSecurityRuleDescription.Text = String.Empty;
                //drpApplication.SelectedValue = String.Empty;
                chkSelect.Checked = false;
                chkInsert.Checked = false;
                chkUpdate.Checked = false;
                chkDelete.Checked = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void InitializeSession()
        {
            try
            {
                AllApplicationList = new CustomList<ApplicationList>();
                MenuList = new CustomList<ASL.Security.DAO.Menu>();
                SecurityRuleList = new CustomList<ASL.Security.DAO.SecurityRule>();
                SecurityRuleDetailList = new CustomList<RuleDetails>();
                ApplicationList = new CustomList<Application>();
                ApplicationList = manager.GetAllApplication();
                TempSecurityRuleDetailList = new CustomList<TempRuleDetails>();
                Session["PersonName"] = CurrentUserSession.PersonName;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void SetDataControlsToSecurityRuleObject(ref CustomList<ASL.Security.DAO.SecurityRule> securityRuleList)
        {
            try
            {
                ASL.Security.DAO.SecurityRule objSecurityRule = securityRuleList[0];
                objSecurityRule.SecurityRuleCode = txtSecurityRuleCode.Text;
                objSecurityRule.SecurityRuleName = txtSecurityRuleName.Text;
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
                txtSecurityRuleCode.Text = StaticInfo.NewIDString;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
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
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                InitializieCombo();
                ClearControls();
                InitializeSession();
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
                CustomList<ASL.Security.DAO.SecurityRule> lstSecurityRule = SecurityRuleList;
                if (lstSecurityRule.Count == 0)
                {
                    ASL.Security.DAO.SecurityRule newSecurityRule = new ASL.Security.DAO.SecurityRule();
                    lstSecurityRule.Add(newSecurityRule);
                }

                SetDataControlsToSecurityRuleObject(ref lstSecurityRule);
                CustomList<ASL.Security.DAO.Menu> AllMenu = (CustomList<ASL.Security.DAO.Menu>)Session["SecurityRule_MenuList"];
                CustomList<ASL.Security.DAO.Menu> selectedMenu = AllMenu.FindAll(f => f.CanSelect || f.CanInsert || f.CanUpdate || f.CanDelete);
                objSecurityRuleDetailList = new CustomList<RuleDetails>();
                foreach (ASL.Security.DAO.Menu m in selectedMenu)
                {
                    RuleDetails obj = new RuleDetails();
                    obj.ApplicationID = m.ApplicationID;
                    obj.ObjectID = m.MenuID;
                    obj.ObjectType = "menu";
                    obj.CanSelect = m.CanSelect;
                    obj.CanInsert = m.CanInsert;
                    obj.CanUpdate = m.CanUpdate;
                    obj.CanDelete = m.CanDelete;
                    objSecurityRuleDetailList.Add(obj);
                }
                //objSecurityRuleDetailList = SecurityRuleDetailList;
                if (!CheckUserAuthentication(lstSecurityRule, objSecurityRuleDetailList)) return;
                if (lstSecurityRule.IsNotNull())
                {
                    #region Delete
                    CustomList<RuleDetails> securityRuleObject = manager.GetAllSecurityRule_ObjectWithSecurityRule(lstSecurityRule[0].SecurityRuleCode);
                    if (securityRuleObject.Count != 0)
                    {
                        foreach (RuleDetails obj in securityRuleObject)
                        {
                            obj.Delete();
                        }
                        manager.TempSecurityRule_ObjectDelete(ref securityRuleObject);
                    }
                    #endregion

                    manager.SaveSecurityRule(ref lstSecurityRule, ref objSecurityRuleDetailList);
                    txtSecurityRuleCode.Text = manager.SecurityRuleInfoID;
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
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                InitializeSession();

                CustomList<ASL.Security.DAO.SecurityRule> items = manager.GettblSecurityRuleForSearch();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("SecurityRuleCode", "Security Rule Code");
                columns.Add("SecurityRuleName", "Security Rule Name");
                //columns.Add("CustomerDisplay", "Customer");
                //columns.Add("SecurityRuleDescription", "Security Rule Description");
                //columns.Add("ApplicationID", "Application ID");
                //columns.Add("CompanyID", "Company ID");

                StaticInfo.SearchItem(items, "Security Rule Info", "SearchSecurityRule", ASL.Web.Framework.SearchColumnConfig.GetColumnConfig(typeof(ASL.Security.DAO.SecurityRule), columns), 500);
                EnableAllControls(true);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ("Error: <br>" + ex.Message + "<br>Call Stack: <br>" + ex.StackTrace);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            objSecurityRuleList = SecurityRuleList;
            objSecurityRuleDetailList = SecurityRuleDetailList;
            //objSecurityRuleList = new CustomList<SecurityRule>();
            if (SecurityRuleList.Count != 0)
            {
                foreach (RuleDetails sRO in objSecurityRuleDetailList)
                {
                    if (sRO.IsDeleted.IsFalse())
                        sRO.Delete();
                }

                foreach (ASL.Security.DAO.SecurityRule sR in objSecurityRuleList)
                {
                    //SecurityRule obj = new SecurityRule();
                    //obj.SecurityRuleCode = sR.SecurityRuleCode;
                    //obj.Delete();
                    //objSecurityRuleList.Add(obj);
                    //sR.ApplicationID = null;
                    if (sR.IsDeleted.IsFalse())
                        sR.Delete();
                }
                if (CheckUserAuthentication(objSecurityRuleDetailList, objSecurityRuleList).IsFalse()) return;
                manager.DeleteSecurityRule(ref objSecurityRuleDetailList, ref objSecurityRuleList);
                ClearControls();
                InitializeSession();
                this.ErrorMessage = (StaticInfo.DeletedSuccessfullyMsg);
                EnableAllControls(false);
            }
        }
        #endregion
        #region Combo Event
        //protected void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //AllApplicationList = manager.GetAllApplicationName(cboCompany.SelectedValue.ToString());
        //}
        //protected void drpApplication_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    MenuList = manager.GetAllMenuByApplicationID(drpApplication.SelectedValue);
        //}
        #endregion
    }
}
