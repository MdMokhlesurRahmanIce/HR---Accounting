using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.DATA;
using ASL.STATIC;
using ASL.Security.BLL;
using ASL.Security.DAO;
//using CSRL.Utilities;
using ASL.Web.Framework;
using System.Data.SqlClient;
using ASL.Hr.DAO;
using Enc = ASL.STATIC.EncDec;

namespace Hr.Web.UI.Security
{
    public partial class UserInformation : PageBase
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(log4net.Appender.RollingFileAppender));
        UserInformationManager manager = new UserInformationManager();
        CustomList<Users> objUserList = new CustomList<Users>();
        #region Constructur
        public UserInformation()
        {
            RequiresAuthorization = true;
        }
        #endregion

        #region Session Value
        private CustomList<Users> UserList
        {
            get
            {
                if (Session["SecurityRule_UserList"] == null)
                    return new CustomList<Users>();
                else
                    return (CustomList<Users>)Session["SecurityRule_UserList"];
            }
            set
            {
                Session["SecurityRule_UserList"] = value;
            }
        }
        private CustomList<UserGroupList> UserGroupList
        {
            get
            {
                if (Session["UserInformation_UserGroupList"] == null)
                    return new CustomList<UserGroupList>();
                else
                    return (CustomList<UserGroupList>)Session["UserInformation_UserGroupList"];
            }
            set
            {
                Session["UserInformation_UserGroupList"] = value;
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
                    InitializeCombo();
                    ClearControls();
                    InitializeSession();
                    EnableAllControls(false);

                }
                else
                {
                    Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                    String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                    if (Request["__EVENTTARGET"] == "SearchUser")
                    {
                        Users searchUser = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as Users;
                        objUserList.Add(searchUser);
                        UserList = objUserList;
                        if (searchUser.IsNotNull())
                        {
                            PopulateUserInformation(searchUser);
                        }
                    }
                    else if (Request["__EVENTTARGET"] == "SearchEmployee")
                    {
                        HRM_Emp searchEmp = Session[ASL.STATIC.StaticInfo.SearchSessionVarName] as HRM_Emp;
                        ddlEmpCode.SelectedValue = searchEmp.EmpCode;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                logger.Warn(ex.ToString());
            }
        }
        #endregion

        #region All Method
        private void InitializeCombo()
        {
            try
            {
                //Loding Emp Code
                ddlEmpCode.DataSource = manager.GetAllEmp();
                ddlEmpCode.DataTextField = "EmpName";
                ddlEmpCode.DataValueField = "EmpCode";
                ddlEmpCode.DataBind();
                ddlEmpCode.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlEmpCode.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void InitializeSession()
        {
            try
            {
                UserGroupList = new CustomList<UserGroupList>();
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
                txtUserCode.Enabled = status;
                txtName.Enabled = status;
                ddlEmpCode.Enabled = status;
                txtUserName.Enabled = status;
                txtPassword.Enabled = status;
                txtConfirmPassword.Enabled = status;
                chkActiveUser.Enabled = status;
                chkAdminUser.Enabled = status;

                btnSave.Enabled = status;
                btnCancel.Enabled = status;
                btnRefresh.Enabled = status;

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void PopulateUserInformation(Users u)
        {
            try
            {
                SetDataInControls(u);
                UserGroupList = manager.GetAllUserGroupWithUserCode(u.UserCode);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void SetDataInControls(Users u)
        {
            try
            {
                txtUserCode.Text = u.UserCode.ToString();
                txtName.Text = u.Name.ToString();
                ddlEmpCode.SelectedValue = u.EmpCode;
                txtUserName.Text = Enc.Decrypt(u.UserName, ASL.STATIC.StaticInfo.encString);
                txtPassword.Attributes.Add("value", Enc.Decrypt(u.Password, ASL.STATIC.StaticInfo.encString));
                txtConfirmPassword.Attributes.Add("value", Enc.Decrypt(u.Password, ASL.STATIC.StaticInfo.encString));
                if (u.IsActive == 1)
                    chkActiveUser.Checked = true;
                else
                    chkActiveUser.Checked = false;
                if (u.IsAdmin == 1)
                    chkAdminUser.Checked = true;
                else
                    chkAdminUser.Checked = false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ClearControls()
        {
            try
            {
                txtUserCode.Text = String.Empty;
                txtName.Text = String.Empty;
                txtUserName.Text = String.Empty;
                ddlEmpCode.SelectedValue = String.Empty;
                txtPassword.Attributes.Add("value", "");
                txtConfirmPassword.Attributes.Add("value", "");
                chkAdminUser.Checked = false;
                chkActiveUser.Checked = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void SetDataControlsToObject(ref CustomList<Users> lstUser)
        {
            try
            {
                Users objUsers = lstUser[0];
                objUsers.UserCode = txtUserCode.Text;
                objUsers.Name = txtName.Text;
                objUsers.EmpCode = ddlEmpCode.SelectedValue;
                objUsers.UserName = Enc.Encrypt(txtUserName.Text.Trim(), ASL.STATIC.StaticInfo.encString);
                objUsers.Password = Enc.Encrypt(txtPassword.Text.Trim(), ASL.STATIC.StaticInfo.encString);
                objUsers.IsAdmin = 1;
                if (chkActiveUser.Checked)
                    objUsers.IsActive = 1;
                else
                    objUsers.IsActive = 0;
                if (chkAdminUser.Checked)
                    objUsers.IsAdmin = 1;
                else
                    objUsers.IsAdmin = 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<Users> lstUser = UserList;
                if (lstUser.Count == 0)
                {
                    Users newUser = new Users();
                    lstUser.Add(newUser);
                }
                SetDataControlsToObject(ref lstUser);

                if (CheckUserAuthentication(lstUser).IsFalse()) return;
                if (lstUser.IsNotNull())
                {
                    if (txtPassword.Text == txtConfirmPassword.Text)
                    {
                        if (!CheckUserAuthentication(lstUser)) return;
                        manager.SaveUser(ref lstUser);
                        txtUserCode.Text = manager.UserCode;
                        this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
                    }
                    else
                        ErrorMessage = "Password and ConfirmPassword does not match!";
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
        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            ClearControls();
            EnableAllControls(true);
            btnDelete.Enabled = false;
            txtUserCode.Text = StaticInfo.NewIDString;
        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<Users> items = manager.GetAllUsers();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("UserCode", "User Code");
                columns.Add("Name", "Name");

                StaticInfo.SearchItem(items, "User Info", "SearchUser", ASL.Web.Framework.SearchColumnConfig.GetColumnConfig(typeof(Users), columns), 500);
                EnableAllControls(true);
            }
            catch (Exception ex)
            {

                this.ErrorMessage = ("Error: <br>" + ex.Message + "<br>Call Stack: <br>" + ex.StackTrace);
            }
        }
        protected void btnEmpFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<HRM_Emp> EmpList = manager.doSearch("check");
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("EmpCode", "Employee Code");
                columns.Add("EmpName", "Employee Name");

                StaticInfo.SearchItem(EmpList, "Emp Info", "SearchEmployee", SearchColumnConfig.GetColumnConfig(typeof(HRM_Emp), columns), 500, GlobalEnums.enumSearchType.StoredProcedured);
            }
            catch (SqlException ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
            InitializeSession();
            EnableAllControls(false);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                objUserList = UserList;
                if (objUserList[0].UserCode != StaticInfo.NewIDString && objUserList.Count != 0)
                {
                    foreach (Users user in objUserList)
                    {
                        if (user.IsDeleted.IsFalse())
                            user.Delete();
                    }
                    if (CheckUserAuthentication(objUserList).IsFalse()) return;
                    manager.DeleteUser(ref objUserList);
                    ClearControls();
                    InitializeSession();
                    this.ErrorMessage = (StaticInfo.DeletedSuccessfullyMsg);
                    EnableAllControls(false);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion
    }
}
