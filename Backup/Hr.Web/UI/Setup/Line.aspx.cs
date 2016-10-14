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
using System.Data.SqlClient;

namespace Hr.Web.UI.Setup
{
    public partial class LineSetup : PageBase
    {
        LineManager manager = new LineManager();

        #region Constructor
        public LineSetup()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<LineInfo> LineList
        {
            get
            {
                if (Session["LineSetup_LineList"] == null)
                    return new CustomList<LineInfo>();
                else
                    return (CustomList<LineInfo>)Session["LineSetup_LineList"];
            }
            set
            {
                Session["LineSetup_LineList"] = value;
            }
        }
        private CustomList<Organization> CompanyList
        {
            get
            {
                if (Session["LineSetup_CompanyList"] == null)
                    return new CustomList<Organization>();
                else
                    return (CustomList<Organization>)Session["LineSetup_CompanyList"];
            }
            set
            {
                Session["LineSetup_CompanyList"] = value;
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
                    InitializeSession();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                LineList = new CustomList<LineInfo>();
                LineList = manager.GetAllLineInfo();
                CompanyList = new CustomList<Organization>();
                CompanyList = manager.GetAllCompany();
            }
            catch (Exception ex)
            {

                throw (ex);
            }

        }
        #endregion
        #region Button Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<LineInfo> lstLineInfo = (CustomList<LineInfo>)LineList;
                if (lstLineInfo.IsNotNull())
                {
                    if (!CheckUserAuthentication(lstLineInfo)) return;
                    manager.SaveLineInfo(ref lstLineInfo);
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
        #endregion
    }
}