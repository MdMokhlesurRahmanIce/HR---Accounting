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
    public partial class FiscalYear : PageBase
    {
        FiscalYearManager manager = new FiscalYearManager();
        #region Constructur
        public FiscalYear()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<Gen_FY> Gen_FYList
        {
            get
            {
                if (Session["FiscalYear_Gen_FYList"] == null)
                    return new CustomList<Gen_FY>();
                else
                    return (CustomList<Gen_FY>)Session["FiscalYear_Gen_FYList"];
            }
            set
            {
                Session["FiscalYear_Gen_FYList"] = value;
            }
        }
        private CustomList<HouseKeepingValue> Gen_OrgList
        {
            get
            {
                if (Session["FiscalYear_Gen_OrgList"] == null)
                    return new CustomList<HouseKeepingValue>();
                else
                    return (CustomList<HouseKeepingValue>)Session["FiscalYear_Gen_OrgList"];
            }
            set
            {
                Session["FiscalYear_Gen_OrgList"] = value;
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
                Gen_FYList = new CustomList<Gen_FY>();
                Gen_FYList = manager.GetAllGen_FY();
                Gen_OrgList = manager.GetAllCompany();
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
                CustomList<Gen_FY> lstBank = (CustomList<Gen_FY>)Gen_FYList;
                if (lstBank.IsNotNull())
                {
                    if (!CheckUserAuthentication(lstBank)) return;
                    manager.SaveFiscalYear(ref lstBank);
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