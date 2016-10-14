using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASL.Hr.BLL;
using ASL.DATA;
using ASL.Hr.DAO;
using System.IO;
using Hr.Web.Utils;
using ASL.Web.Framework;
using System.Collections;
using System.Configuration;

namespace Hr.Web.Controls
{
    public partial class EmpAttachmentInfo : EmpBase
    {
        #region Fileds
        public readonly EmployeeManager _empManager;
        public readonly MonthlySalarProcessManager _salaryManager;
        #endregion

        #region Properties
        private CustomList<HRM_EmpFileAttach> EmpFileList
        {
            get
            {
                if (Session["EmployeeBasicInformation_EmpFileList"] == null)
                    return new CustomList<HRM_EmpFileAttach>();
                else
                    return (CustomList<HRM_EmpFileAttach>)Session["EmployeeBasicInformation_EmpFileList"];
            }
            set
            {
                Session["EmployeeBasicInformation_EmpFileList"] = value;
            }
        }
        #endregion

        #region Ctor
        public EmpAttachmentInfo()
        {
            _empManager = new EmployeeManager();
            _salaryManager = new MonthlySalarProcessManager();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                InitializationSession();

                #region Default Settings
                txtDate.Text = DateTime.UtcNow.ToString(ASL.STATIC.StaticInfo.GridDateFormat);
                #endregion


            }
        }

        private void InitializationSession()
        {

            //EmpFileList = _empManager.GetAllEmpfileByEmpKey(EmpKey);
            //if (EmpFileList == null)
                EmpFileList = new CustomList<HRM_EmpFileAttach>();
        }

        internal void PopulateControl()
        {
            //hfEmpFileKey.Value = f.EmpAttachKey.ToString();
            //txtDate.Text = f.AttachDate.ToShortDateString();
            //txtDescription.Text = f.AttachDesc;
            //txtFileName.Text = f.FileName;
            InitializationSession();
        }

        private void GetValueFromControl(HRM_EmpFileAttach f)
        {

            f.EmpAttachKey = hfEmpFileKey.Value.ToInt();
            f.EmpKey = EmpKey.ToInt();

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

        internal void Save(ArrayList empInfo)
        {
            var empFile = (CustomList<HRM_EmpFileAttach>)EmpFileList;
            //empFamDet.ForEach(x => x.EmpKey = EmpKey.ToInt());
            //_empManager.SaveEmpFile(ref empFamDet);

            empInfo.Add(empFile);
        }

        internal void Update(ArrayList empInfo)
        {
            //if (Session["EmpKey"] == null)
            //    return;
            Save(empInfo);
            //var empKey = Session["EmpKey"].ToString();
            //var existingAddr = _empManager.GetAllEmpFamByEmpKey(empKey);
            //if (existingAddr.Count == 0)
            //    Save();

            //var empAddr = new HRM_EmpFamily();
            //GetValueFromControl(empAddr);
            //empAddr.SetUnchanged();
            //empAddr.SetModified();

            //var empFam = new CustomList<HRM_EmpFamily>() { empAddr };
            //var empFamDet = (CustomList<HRM_EmpFamDet>)EmpFamDetList;
            //_empManager.SaveEmpFam(ref empFam, ref empFamDet);
        }

        internal void Delete()
        {
            EmpFileList.ForEach(x => x.Delete());
            //Save();
            //var empAddr = new HRM_EmpFamily();
            //GetValueFromControl(empAddr);
            //empAddr.SetUnchanged();
            //empAddr.SetDetached();

            //var empFam = new CustomList<HRM_EmpFamily>() { empAddr };
            //var empFamDet = (CustomList<HRM_EmpFamDet>)EmpFamDetList;
            //_empManager.SaveEmpFam(ref empFam, ref empFamDet);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var eh = new HRM_EmpFileAttach();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var empHistKey = hfEmpFileKey.Value.ToInt();
            var eh = EmpFileList.Find(x => x.EmpAttachKey == empHistKey);
            GetValueFromControl(eh);
            eh.SetModified();
        }



        internal void ClearControl()
        {
            txtDescription.Text = string.Empty;
            txtFileName.Text = string.Empty;
            InitializationSession();
        }
    }
}