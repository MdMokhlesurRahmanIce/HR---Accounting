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

namespace Hr.Web.UI.Evaluation
{
    public partial class EvalItem : PageBase
    {
        EvalItemManager manager = new EvalItemManager();
        #region Constructur
        public EvalItem()
        {
            RequiresAuthorization = true;
        }
        #endregion

        #region Session Event
        //private CustomList<Gen_LookupEnt> TypeList
        //{
        //    get
        //    {
        //        if (Session["EvalItem_TypeList"] == null)
        //            return new CustomList<Gen_LookupEnt>();
        //        else
        //            return (CustomList<Gen_LookupEnt>)Session["EvalItem_TypeList"];
        //    }
        //    set
        //    {
        //        Session["EvalItem_TypeList"] = value;
        //    }
        //}
        private CustomList<HRM_EvalItem> HRM_EvalItemList
        {
            get
            {
                if (Session["EvalItem_HRM_EvalItemList"] == null)
                    return new CustomList<HRM_EvalItem>();
                else
                    return (CustomList<HRM_EvalItem>)Session["EvalItem_HRM_EvalItemList"];
            }
            set
            {
                Session["EvalItem_HRM_EvalItemList"] = value;
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
                HRM_EvalItemList = new CustomList<HRM_EvalItem>();
                HRM_EvalItemList = manager.GetAllHRM_EvalItem();
               // TypeList = manager.GetAllEvalutionCritaria();
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
                CustomList<HRM_EvalItem> lstBank = (CustomList<HRM_EvalItem>)HRM_EvalItemList;
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