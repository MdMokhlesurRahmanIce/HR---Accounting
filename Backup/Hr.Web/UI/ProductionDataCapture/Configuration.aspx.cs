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

namespace Hr.Web.UI.ProductionDataCapture
{
    public partial class Configuration : PageBase
    {
        DataCaptureConfigurationManager manager = new DataCaptureConfigurationManager();
        #region Constructur
        public Configuration()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<DataCaptureConfiguration> DataCaptureConfigurationList
        {
            get
            {
                if (Session["Configuration_DataCaptureConfigurationList"] == null)
                    return new CustomList<DataCaptureConfiguration>();
                else
                    return (CustomList<DataCaptureConfiguration>)Session["Configuration_DataCaptureConfigurationList"];
            }
            set
            {
                Session["Configuration_DataCaptureConfigurationList"] = value;
            }
        }
        #endregion
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
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                DataCaptureConfigurationList = new CustomList<DataCaptureConfiguration>();
                DataCaptureConfigurationList = manager.GetAllDataCaptureConfiguration1();

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
                CustomList<DataCaptureConfiguration> lstDataCaptureConfiguration = DataCaptureConfigurationList;
                CustomList<DataCaptureConfiguration> lstSaveDataCaptureConfiguration = lstDataCaptureConfiguration.FindAll(f => f.IsCapture || f.IsRate || f.IsFixed);
                lstSaveDataCaptureConfiguration.ForEach(f => f.SetAdded());
                CustomList<DataCaptureConfiguration> DeletedList = new CustomList<DataCaptureConfiguration>();
                foreach (DataCaptureConfiguration DCC in lstDataCaptureConfiguration)
                {
                    DataCaptureConfiguration newObj = new DataCaptureConfiguration();
                    newObj.Field = DCC.Field;
                    newObj.Delete();
                    DeletedList.Add(newObj);
                }
                if (!CheckUserAuthentication(lstSaveDataCaptureConfiguration, DeletedList)) return;
                manager.SaveDataCaptureConfiguration(ref DeletedList, ref lstSaveDataCaptureConfiguration);
                this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);

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