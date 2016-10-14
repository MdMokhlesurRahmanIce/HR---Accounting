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

namespace Hr.Web.UI.Attendance
{
    public partial class WHDeclaration : PageBase
    {
        WHDeclarationManager manager = new WHDeclarationManager();
        #region Session Variable
        private CustomList<WHCalendar> WHCalendarList
        {
            get
            {
                if (Session["WHDeclaration_WHCalendarList"] == null)
                    return new CustomList<WHCalendar>();
                else
                    return (CustomList<WHCalendar>)Session["WHDeclaration_WHCalendarList"];
            }
            set
            {
                Session["WHDeclaration_WHCalendarList"] = value;
            }
        }
        private CustomList<WHCalendar> EmpList
        {
            get
            {
                if (Session["WHDeclaration_EmpList"] == null)
                    return new CustomList<WHCalendar>();
                else
                    return (CustomList<WHCalendar>)Session["WHDeclaration_EmpList"];
            }
            set
            {
                Session["WHDeclaration_EmpList"] = value;
            }
        }
        private CustomList<WHCalendar> WHEmpList
        {
            get
            {
                if (Session["WHDeclaration_WHEmpList"] == null)
                    return new CustomList<WHCalendar>();
                else
                    return (CustomList<WHCalendar>)Session["WHDeclaration_WHEmpList"];
            }
            set
            {
                Session["WHDeclaration_WHEmpList"] = value;
            }
        }
        #endregion
        #region Constructur
        public WHDeclaration()
        {
            RequiresAuthorization = true;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //load ddlDayType
                ddlDayStatus.Items.Insert(0, new ListItem() { Value = "", Text = "" });
                ddlDayStatus.Items.Insert(1, new ListItem() { Value = "1", Text = "W" });
                ddlDayStatus.Items.Insert(2, new ListItem() { Value = "2", Text = "H" });
                ddlDayStatus.Items.Insert(2, new ListItem() { Value = "3", Text = "Str" });

                InitializeSession();
            }
        }
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                WHCalendarList = new CustomList<WHCalendar>();
                EmpList = new CustomList<WHCalendar>();
                WHEmpList = new CustomList<WHCalendar>();
                //Session["View_EmpList"] = new CustomList<HRM_Emp>();
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
                FormUtil.ClearForm(this, FormClearOptions.ClearAll, false);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Button Event
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
                //rdoDeclaration.Checked = true;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<WHCalendar> WHCalendarEmpList = WHEmpList;
                WHCalendarEmpList.ForEach(s => s.Delete());
                if (WHCalendarEmpList.Count != 0)
                {
                    if (CheckUserAuthentication(WHCalendarEmpList).IsFalse()) return;
                    manager.DeleteWHCalendar(ref WHCalendarEmpList);
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