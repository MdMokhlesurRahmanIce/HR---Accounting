using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.Hr.BLL;
using ASL.Hr.DAO;
using ASL.STATIC;
using ASL.DATA;
using ASL.Web.Framework;
using System.Collections;
using System.Data.SqlClient;
using System.Text;

namespace Hr.Web.UI.Attendance
{
    public partial class EmpOutOffOfficeEntry : PageBase
    {
        OutOffOfficeEntryManager manager = new OutOffOfficeEntryManager();
        #region Constructur
        public EmpOutOffOfficeEntry()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variable
        private CustomList<OutOfOfficeInfo> EmpList
        {
            get
            {
                if (Session["EmpOutOffOfficeEntry_EmpList"] == null)
                    return new CustomList<OutOfOfficeInfo>();
                else
                    return (CustomList<OutOfOfficeInfo>)Session["EmpOutOffOfficeEntry_EmpList"];
            }
            set
            {
                Session["EmpOutOffOfficeEntry_EmpList"] = value;
            }
        }
        private CustomList<HouseKeepingValue> ProjectList
        {
            get
            {
                if (Session["EmpOutOffOfficeEntry_ProjectList"] == null)
                    return new CustomList<HouseKeepingValue>();
                else
                    return (CustomList<HouseKeepingValue>)Session["EmpOutOffOfficeEntry_ProjectList"];
            }
            set
            {
                Session["EmpOutOffOfficeEntry_ProjectList"] = value;
            }
        }
        #endregion
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeSession();
                InitializeCombo();
                hfCurrentUser.Value = CurrentUserSession.UserCode;
            }
        }
        #endregion
        #region All Methods
        private void InitializeCombo()
        {
            try
            {
                //Loding Project
                ProjectList = new CustomList<HouseKeepingValue>();
                ProjectList = manager.GetAllProject();
                ddlVisitPlaceOrProject.DataSource = ProjectList;
                ddlVisitPlaceOrProject.DataTextField = "HKName";
                ddlVisitPlaceOrProject.DataValueField = "HKID";
                ddlVisitPlaceOrProject.DataBind();
                ddlVisitPlaceOrProject.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlVisitPlaceOrProject.SelectedIndex = 0;
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
                EmpList = new CustomList<OutOfOfficeInfo>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Button Events
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<OutOfOfficeInfo> OutOfOfficeEntryList = EmpList;
                OutOfOfficeEntryList.ForEach(s => s.Delete());
                if (OutOfOfficeEntryList.Count != 0)
                {
                    if (CheckUserAuthentication(OutOfOfficeEntryList).IsFalse()) return;
                    manager.DeleteWHCalendar(ref OutOfOfficeEntryList);
                    this.SuccessMessage = (StaticInfo.DeletedSuccessfullyMsg);
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
        #endregion
    }
}