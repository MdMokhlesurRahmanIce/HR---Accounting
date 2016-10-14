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
    public partial class Currency : PageBase
    {

        CurrencyManager currencyManager = new CurrencyManager();
        #region Constructur
        public Currency()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<Gen_Currency> CurrencyList
        {
            get
            {
                if (Session["Currency_CurrencyList"] == null)
                    return new CustomList<Gen_Currency>();
                else
                    return (CustomList<Gen_Currency>)Session["Currency_CurrencyList"];
            }
            set
            {
                Session["Currency_CurrencyList"] = value;
            }
        }
        #endregion

        #region Page 
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
                CurrencyList = new CustomList<Gen_Currency>();
                CurrencyList = currencyManager.GetAllGen_Currency();
                
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
                CustomList<Gen_Currency> FCurrency = (CustomList<Gen_Currency>)CurrencyList;
                foreach (Gen_Currency c in FCurrency)
                {
                    if (c.AddedBy.IsNullOrEmpty())
                    {
                        c.AddedBy = CurrentUserSession.UserCode;
                        c.DateAdded = DateTime.Now;
                    }
                    else
                    {
                        c.UpdateBy = CurrentUserSession.UserCode;
                        c.DateUpdate = DateTime.Now;
                        c.SetModified();
                    }
                }
                if (FCurrency.IsNotNull())
                {
                    if (!CheckUserAuthentication(FCurrency)) return;
                    currencyManager.SaveCurrency(ref FCurrency);
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