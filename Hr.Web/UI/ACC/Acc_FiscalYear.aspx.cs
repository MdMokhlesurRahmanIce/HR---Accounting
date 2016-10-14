using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACC.BLL;
using ACC.DAO;
using ASL.STATIC;
using ASL.DATA;
using ASL.Web.Framework;
using System.Data.SqlClient;

namespace Hr.Web.UI.ACC
{
    public partial class Acc_FiscalYear : PageBase
    {
        AccFiscalYearManager manager = new AccFiscalYearManager();
        #region Constructur
        public Acc_FiscalYear()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<Gen_AccFY> Gen_AccFYList
        {
            get
            {
                if (Session["Acc_FiscalYear_Gen_AccFYList"] == null)
                    return new CustomList<Gen_AccFY>();
                else
                    return (CustomList<Gen_AccFY>)Session["Acc_FiscalYear_Gen_AccFYList"];
            }
            set
            {
                Session["Acc_FiscalYear_Gen_AccFYList"] = value;
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
                Gen_AccFYList = new CustomList<Gen_AccFY>();
                Gen_AccFYList = manager.GetAllGen_AccFY();
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
                CustomList<Gen_AccFY> lstAccFY = (CustomList<Gen_AccFY>)Gen_AccFYList;
                if (lstAccFY.IsNotNull())
                {
                    if (!CheckUserAuthentication(lstAccFY)) return;
                    manager.SaveAccFiscalYear(ref lstAccFY);
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