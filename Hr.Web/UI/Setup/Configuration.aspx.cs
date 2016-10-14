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
    public partial class Configuration : PageBase
    {
        SettingsManager ManagerSettings = new SettingsManager();
        //SettingsManager manager = new SettingsManager();
        #region Session Variables
        private CustomList<Settings> _SettingsList
        {
            get
            {
                if (Session["Settings_SettingsList"] == null)
                    return new CustomList<Settings>();
                else
                    return (CustomList<Settings>)Session["Settings_SettingsList"];
            }
            set
            {
                Session["Settings_SettingsList"] = value;
            }
        }
        private CustomList<Settings> _AllSettingsList
        {
            get
            {
                if (Session["Settings_AllSettingsList"] == null)
                    return new CustomList<Settings>();
                else
                    return (CustomList<Settings>)Session["Settings_AllSettingsList"];
            }
            set
            {
                Session["Settings_AllSettingsList"] = value;
            }
        }
        private CustomList<Settings> _AllSettingsInfo
        {
            get
            {
                if (Session["Settings_AllSettingsInfo"] == null)
                    return new CustomList<Settings>();
                else
                    return (CustomList<Settings>)Session["Settings_AllSettingsInfo"];
            }
            set
            {
                Session["Settings_AllSettingsInfo"] = value;
            }
        }
        #endregion
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeSession();
                ClearControls();
                InitializeControls();
            }
        }
        #endregion
        #region All Methods
        private void ClearControls()
        {
            try
            {
                //  txtSettingsName.Text = string.Empty;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void InitializeSession()
        {
            try
            {
                _SettingsList = new CustomList<Settings>();
                _AllSettingsList = new CustomList<Settings>();
                _AllSettingsInfo = new CustomList<Settings>();

                _AllSettingsInfo = ManagerSettings.GetAllSettingsInfo();  // .GetAllSettingsInfo();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void InitializeControls()
        {
            CustomList<Settings> obj1 = ManagerSettings.GetAllSettingsList();

            _AllSettingsList = obj1;

            ddlSettingsName.DataSource = _AllSettingsList;
            ddlSettingsName.DataTextField = "SettingsName";
            ddlSettingsName.DataValueField = "SettingsName";
            ddlSettingsName.DataBind();
            ddlSettingsName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlSettingsName.SelectedIndex = 0;

        }
        private void SetDataFromControls(ref CustomList<Settings> SettingsList)
        {
            try
            {
                foreach (Settings s in SettingsList)
                {
                    s.SettingsName = ddlSettingsName.SelectedValue;
                }
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
                CustomList<Settings> lstSettings = _SettingsList;
                SetDataFromControls(ref lstSettings);
                if (lstSettings.Count != 0)
                {
                    ManagerSettings.SaveSettings(ref lstSettings);
                    ClearControls();
                    InitializeSession();
                    CustomList<Settings> searchList = _AllSettingsInfo.FindAll(f => f.SettingsName == ddlSettingsName.SelectedValue);
                    _SettingsList = searchList;
                }
            }
            catch (Exception ex)
            {
             //   Message.ShowMessage(StaticInfo.SavedSuccessfullyMsg);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<Settings> lstSettings = _SettingsList;
                foreach (Settings s in lstSettings)
                {
                    s.Delete();
                }
                if (lstSettings.Count != 0)
                {
                    ManagerSettings.DeleteSettings(ref lstSettings);
                    ClearControls();
                    InitializeSession();
                   // Message.ShowMessage(StaticInfo.DeletedSuccessfullyMsg);
                }
            }
            catch (Exception ex)
            {
               // Message.ShowMessage(StaticInfo.DeletedErrorMsg);
            }
        }
        #endregion
        #region Text Change Event
        protected void txtSettingsName_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        protected void ddlSettingsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CustomList<Settings> searchList = _AllSettingsInfo.FindAll(f => f.SettingsName == ddlSettingsName.SelectedValue);
                _SettingsList = searchList;
            }
            catch (Exception ex)
            {

                throw (ex);
            }

        }
    }
}