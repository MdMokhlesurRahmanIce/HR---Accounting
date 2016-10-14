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
using System.Configuration;
using System.IO;

namespace Hr.Web.UI.Setup
{
    public partial class CompanyPolicies : PageBase
    {
        public readonly MonthlySalarProcessManager _salaryManager = new MonthlySalarProcessManager();
        public readonly CompanyPoliciesFileManager _manager = new CompanyPoliciesFileManager();
        #region Constructur
        public CompanyPolicies()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variables
        private CustomList<HRM_PolicyFileAttach> EmpFileList
        {
            get
            {
                if (Session["CompanyPolicies_EmpFileList"] == null)
                    return new CustomList<HRM_PolicyFileAttach>();
                else
                    return (CustomList<HRM_PolicyFileAttach>)Session["CompanyPolicies_EmpFileList"];
            }
            set
            {
                Session["CompanyPolicies_EmpFileList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeCombo();
                InitializeSession();
                #region Default Settings
                txtDate.Text = DateTime.UtcNow.ToString(ASL.STATIC.StaticInfo.GridDateFormat);
                #endregion
            }
        }
        #region All Methods
        private void InitializeSession()
        {
            try
            {
                EmpFileList = new CustomList<HRM_PolicyFileAttach>();
                EmpFileList = _manager.GetAllHRM_PolicyFileAttach();
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
                //Loding Company
                CustomList<HouseKeepingValue> OrgList = HouseKeepingValue.GetAllHouseKeepingValueForDropdown("Company"); ;
                ddlCompany.DataSource = OrgList;
                ddlCompany.DataTextField = "HKName";
                ddlCompany.DataValueField = "HKID";
                ddlCompany.DataBind();
                ddlCompany.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCompany.SelectedIndex = 0;
                //if (((PageBase)this.Page).CurrentUserSession.IsAdmin && OrgList.Count > 1)
                //{
                //    ddlCompany.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                //    ddlCompany.SelectedIndex = 0;
                //}
                //else
                //{
                //    ddlCompany_SelectedIndexChanged(null, null);
                //    ddlCompany.Enabled = false;
                //}
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void GetValueFromControl(HRM_PolicyFileAttach f)
        {
            f.PolicyAttachKey = hfPolicyFileKey.Value.ToInt();

            f.OrgKey = ddlCompany.SelectedValue.ToInt();
            f.FileName = txtFileName.Text;
            f.AttachDate = txtDate.Text.ToDateTime(ASL.STATIC.StaticInfo.GridDateFormat);
            f.AttachDesc = txtDescription.Text;

            f.FilePath = GetEmpFile();
        }

        private string GetEmpFile()
        {
            var picture = fuAttachment;

            if (picture != null && !string.IsNullOrEmpty(picture.FileName))
            {
                string savePath = ConfigurationManager.AppSettings["empAttachmentPath"];

                if (!Directory.Exists(Server.MapPath(savePath)))
                {
                    try
                    {
                        Directory.CreateDirectory(Server.MapPath(savePath));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                if (savePath.IsNotNullOrEmpty())
                {
                    var fileInfo = new FileInfo(picture.FileName);
                    var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
                    var path = Server.MapPath(ConfigurationManager.AppSettings["empAttachmentPath"]) + fileName;
                    var dbPath = ConfigurationManager.AppSettings["empAttachmentPath"] + fileName;
                    File.WriteAllBytes(path, picture.FileBytes);
                    return dbPath;
                }
                else
                    return string.Empty;
            }
            return string.Empty;
        }
        #endregion
        #region Button Event
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var eh = new HRM_PolicyFileAttach();
            GetValueFromControl(eh);
            if (!string.IsNullOrEmpty(eh.FileName) && !string.IsNullOrEmpty(eh.FilePath))
                EmpFileList.Add(eh);
            else
                ((PageBase)(this.Page)).ErrorMessage = "File name and File path are required";

            Page page = null;
            page = ((Page)this.Page);

            if (page != null)
                page.ClientScript.RegisterClientScriptBlock(GetType(), "selectedtab", "selectedtab=5", true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<HRM_PolicyFileAttach> CompanyPolicyList = EmpFileList;
                if (!CheckUserAuthentication(CompanyPolicyList)) return;
                _manager.SaveCompanyPolicies(ref CompanyPolicyList);
                this.SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }
        #endregion
    }
}