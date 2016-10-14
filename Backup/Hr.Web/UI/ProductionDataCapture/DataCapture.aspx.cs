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

namespace Hr.Web.UI.ProductionDataCapture
{
    public partial class DataCapture : PageBase
    {
        DataCaptureManager manager = new DataCaptureManager();
        #region Constractor
        public DataCapture()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variable
        private CustomList<ASL.Hr.DAO.ProductionDataCapture> DataCaptureDynamicGridList
        {
            get
            {
                if (Session["DataCapture_DataCaptureDynamicGridList"] == null)
                    return new CustomList<ASL.Hr.DAO.ProductionDataCapture>();
                else
                    return (CustomList<ASL.Hr.DAO.ProductionDataCapture>)Session["DataCapture_DataCaptureDynamicGridList"];
            }
            set
            {
                Session["DataCapture_DataCaptureDynamicGridList"] = value;
            }
        }
        private CustomList<DataCaptureRate> DataCaptureRateList
        {
            get
            {
                if (ViewState["DataCapture_DataCaptureRateList"] == null)
                    return new CustomList<DataCaptureRate>();
                else
                    return (CustomList<DataCaptureRate>)ViewState["DataCapture_DataCaptureRateList"];
            }
            set
            {
                ViewState["DataCapture_DataCaptureRateList"] = value;
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
                    InitializeCombo();
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
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                DataCaptureDynamicGridList = new CustomList<ASL.Hr.DAO.ProductionDataCapture>();
                //EmpListList = new CustomList<ASL.Hr.DAO.ProductionDataCapture>();
                //EmpListList = manager.GetAllProductionDataCaptureEmp();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void InitializeCombo()
        {
            try
            {
                #region Rate Rule
                DataCaptureRateList = manager.GetAllDataCapRateRuleID();
                ddlRateID.DataSource = DataCaptureRateList;
                ddlRateID.DataTextField = "DataCapRateRuleID";
                ddlRateID.DataValueField = "DataCapRateRuleID";
                ddlRateID.DataBind();
                ddlRateID.Items.Insert(0, new ListItem() { Value = "", Text = "" });
                #endregion
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
        #region Combo Event
        protected void ddlRateID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataCaptureRate dCR = DataCaptureRateList.Find(f => f.DataCapRateRuleID == (ddlRateID.SelectedValue == null ? String.Empty : ddlRateID.SelectedValue));
                if (dCR.IsNotNull())
                    txtRate.Text = dCR.Rate.ToString();
                else
                    txtRate.Text = String.Empty;
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
                CustomList<ASL.Hr.DAO.ProductionDataCapture> lstProductionDataCapture = DataCaptureDynamicGridList;
                CustomList<ASL.Hr.DAO.ProductionDataCapture> ProductionDataCaptureList = lstProductionDataCapture.FindAll(f=>f.IsAdded || f.IsModified || f.IsDeleted);
                if (!CheckUserAuthentication(ProductionDataCaptureList)) return;
                manager.SaveProductionDataCapture(ref ProductionDataCaptureList);
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