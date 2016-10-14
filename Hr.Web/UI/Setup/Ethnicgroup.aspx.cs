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
    public partial class Ethnicgroup : PageBase
    {
        /*EthnicGroupManager manager = new EthnicGroupManager();
        #region Constructur
        public Ethnicgroup()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<Gen_Ethnic> EthnicGroupList
        {
            get
            {
                if (Session["Ethnicgroup_EthnicGroupList"] == null)
                    return new CustomList<Gen_Ethnic>();
                else
                    return (CustomList<Gen_Ethnic>)Session["Ethnicgroup_EthnicGroupList"];
            }
            set
            {
                Session["Ethnicgroup_EthnicGroupList"] = value;
            }
        }

        private CustomList<Gen_LookupEnt> LookupEntList
        {
            get
            {
                if (Session["Ethnicgroup_LookupEntList"] == null)
                    return new CustomList<Gen_LookupEnt>();
                else
                    return (CustomList<Gen_LookupEnt>)Session["Ethnicgroup_LookupEntList"];
            }
            set
            {
                Session["Ethnicgroup_LookupEntList"] = value;
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
                EthnicGroupList = new CustomList<Gen_Ethnic>();
                EthnicGroupList = manager.GetAllGen_Ethnic();

                LookupEntList = new CustomList<Gen_LookupEnt>();
                LookupEntList = manager.GetAllGen_LookupEnt();
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
                CustomList<Gen_Ethnic> EthnicGroup = (CustomList<Gen_Ethnic>)EthnicGroupList;
                if (EthnicGroup.IsNotNull())
                {
                    if (!CheckUserAuthentication(EthnicGroup)) return;
                    manager.SaveEthnicGroup(ref EthnicGroup);
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
*/
    }
}