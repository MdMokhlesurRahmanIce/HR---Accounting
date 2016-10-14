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
using System.Web;

namespace ST.Infrastructure.Security
{
    public partial class Profile : PageBase
    {
        ProfileManager manager = new ProfileManager();
        #region Session Event
        private CustomList<UserProfile> UserProfileList
        {
            get
            {
                if (Session["Profile_UserProfileList"] == null)
                    return new CustomList<UserProfile>();
                else
                    return (CustomList<UserProfile>)Session["Profile_UserProfileList"];
            }
            set
            {
                Session["Profile_UserProfileList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                if (((PageBase)this.Page).CurrentUserSession.IsNull())
                {
                    HttpContext.Current.Response.Redirect("~/Security/Login.aspx?back_url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
                }
                //Loding Application
                ddlDefalultApplication.DataSource = manager.GetAllApplication();
                ddlDefalultApplication.DataTextField = "ApplicationName";
                ddlDefalultApplication.DataValueField = "ApplicationID";
                ddlDefalultApplication.DataBind();
                ddlDefalultApplication.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlDefalultApplication.SelectedIndex = 0;

                UserProfileList = new CustomList<UserProfile>();
                UserProfileList = manager.GetAllUserProfile(CurrentUserSession.UserCode);
                if (UserProfileList.Count != 0)
                {
                    ddlTheme.SelectedValue = UserProfileList[0].ThemeName;
                    ddlDefalultApplication.SelectedValue = UserProfileList[0].DefaultAppID.ToString();
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<UserProfile> lstUserProfile = UserProfileList;
                if (lstUserProfile.Count == 0)
                {
                    UserProfile uP = new UserProfile();
                    lstUserProfile.Add(uP);
                }
                UserProfile uPObj=lstUserProfile[0];
                uPObj.UserCode = CurrentUserSession.UserCode;
                uPObj.ThemeName = ddlTheme.SelectedValue;
                uPObj.DefaultAppID = ddlDefalultApplication.SelectedValue.ToInt();
                //UserProfileList.Add(uPObj);
                manager.SaveUserProfile(ref lstUserProfile);
                this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);

                CurrentUserSession.DefaultApplicationID = ddlDefalultApplication.SelectedValue.ToInt();
                CurrentUserSession.DefaultTheme = ddlTheme.SelectedValue;
                Session["Static_Theme"] = ddlTheme.SelectedValue;
                Response.Redirect(Request.RawUrl);
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
    }
}