using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.Hr.BLL;
using ASL.DATA;
using ASL.Web.Framework;
using System.Data.SqlClient;

namespace Hr.Web.Controls
{
    public partial class EducationQualification : System.Web.UI.UserControl
    {
        private readonly OrganizationManager organizationManager;

        #region Ctor
        public EducationQualification()
        {
            organizationManager = new OrganizationManager();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                PopulateControl();
                btnCancel.Visible = false;
                btnDelete.Visible = false;
                btnRefresh.Visible = false;
            }
        }

        private void PopulateControl()
        {
            Session["EducationQualification_Hr"] = organizationManager.GetAllEducationQualification();
        }

        #region Button event

        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
        }
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
        }
        protected void btnUserAdd_Click(object sender, ImageClickEventArgs e)
        {
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var eduQuals = (CustomList<ASL.Hr.DAO.EducationQualification>)Session["EducationQualification_Hr"];
                organizationManager.SaveEduQual(ref eduQuals);
                ((PageBase)this.Page).SuccessMessage = ASL.STATIC.StaticInfo.SavedSuccessfullyMsg;
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
        }

        #endregion
    }
}