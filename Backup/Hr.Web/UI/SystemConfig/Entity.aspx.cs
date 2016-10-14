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
using Hr.Web.Controls;
using System.Collections;
using System.Data.SqlClient;

namespace Hr.Web.UI.SystemConfig
{
    public partial class Entity : PageBase
    {
        EntityManager manager=new EntityManager();
        HKEntryManager HkManager = new HKEntryManager();
        #region Constructur
        public Entity()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<EntityList> EntityList
        {
            get
            {
                if (Session["Entity_EntityList"] == null)
                    return new CustomList<EntityList>();
                else
                    return (CustomList<EntityList>)Session["Entity_EntityList"];
            }
            set
            {
                Session["Entity_EntityList"] = value;
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
                EntityList = new CustomList<EntityList>();
                EntityList = HkManager.GetAllEntityListForHouseKeeping();

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
                CustomList<EntityList> lstEntity = EntityList;

                if (lstEntity.Count!=0)
                {
                    if (!CheckUserAuthentication(lstEntity)) return;
                    manager.SaveEntity(ref lstEntity);
                    EntityList = manager.GetAllEntityList();
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